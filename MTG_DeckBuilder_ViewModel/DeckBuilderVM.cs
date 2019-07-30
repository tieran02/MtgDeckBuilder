using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTG_DeckBuilder_DataAccess;
using MTG_DeckBuilder_Model;
using MTG_DeckBuilder_ViewModel.Commands;
using MTG_DeckBuilder_ViewModel.Helpers;

namespace MTG_DeckBuilder_ViewModel
{
    public class DeckBuilderVM
    {
        private string searchText;

        public string SearchText
        {   
            get { return searchText; }
            set
            {
                searchText = value;
                GetCardsBySearchText(1);
            }
        }

        public PagedResult<MTG_Card> Cards { get; set; }
        public PagedResult<MTG_Deck> Decks { get; set; }    

        public MTG_Deck CurrentDeck { get; set; }
        public ObservableCollection<MTG_Card> CurrentDeckCards { get; set; }
        public MTG_Card SelectedCard { get; set; }
        public MTG_Deck SelectedDeck { get; set; }


        //Commands
        public AddCardToDeckCommand AddCardToDeckCommand { get; set; }
        public RemoveCardFromDeck RemoveCardFromDeckCommand { get; set; }
        public ChangeCardsPageCommand PageCommand { get; set; }
        public ChangeDeckPageCommand DeckPageCommand { get; set; }
        public CreateDeckCommand CreateDeckCommand { get; set; }
        public LoadDeckCommand LoadDeckCommand { get; set; }


        public ToggleFilterCommand ToggleFilterCommand { get; set; }
        public CardFilters CardFilters { get; set; }

        public DeckBuilderVM()
        {
            Cards = new PagedResult<MTG_Card>();
            Decks = new PagedResult<MTG_Deck>();
            CurrentDeck = new MTG_Deck();
            CurrentDeckCards = new ObservableCollection<MTG_Card>();
            AddCardToDeckCommand = new AddCardToDeckCommand(this);
            RemoveCardFromDeckCommand = new RemoveCardFromDeck(this);
            PageCommand = new ChangeCardsPageCommand(this);
            DeckPageCommand = new ChangeDeckPageCommand(this);
            ToggleFilterCommand = new ToggleFilterCommand(this);
            CreateDeckCommand = new CreateDeckCommand(this);
            LoadDeckCommand = new LoadDeckCommand(this);

            //load cards with no filters (This will only fetch the first 8 cards within the database)
            CardFilters = CardFilters.NONE;
            SearchText = "";

            //string deck = "4 Agent of Treachery (M20) 43\r\n4 Blood Crypt (RNA) 245\r\n2 Blood for Bones (M20) 89\r\n4 Bond of Revival (WAR) 80\r\n4 Chart a Course (XLN) 48\r\n4 Dragonskull Summit (XLN) 252\r\n4 Drakuseth, Maw of Flames (M20) 136\r\n4 Drowned Catacomb (XLN) 253\r\n3 Dusk Legion Zealot (RIX)\r\n1 Island (RIX)\r\n3 Rekindling Phoenix (RIX) 111\r\n2 Steam Vents (GRN) 257\r\n4 Stitcher's Supplier (M19) 121\r\n4 Sulfur Falls (DAR) 247\r\n2 Swamp (RIX)\r\n4 Tomebound Lich (M20) 219\r\n4 Tormenting Voice (M19) 164\r\n3 Watery Grave (GRN) 259\r\n\r\n2 Cavalier of Night (M20) 94\r\n2 Cry of the Carnarium (RNA) 70\r\n2 Duress (M19)\r\n2 Lava Coil (GRN) 108\r\n3 Negate (RIX)\r\n2 Noxious Grasp (M20) 110\r\n2 Thought Erasure (GRN) 206\r\n";
            //ImportDeckAsync(deck);
        }

        public async void GetCardsBySearchText(int page)
        {
            var cards = await DatabaseHelper.GetCardPagesByName(searchText,page,CardFilters);

            Cards.CurrentPage = cards.CurrentPage;
            Cards.PageCount = cards.PageCount;
            Cards.PageSize = cards.PageSize;
            Cards.RowCount = cards.RowCount;

            foreach (var card in cards.Results)
            {
                //get image url
                card.image = $"https://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={card.multiverseID}&type=card";
            }
            Cards.Results = cards.Results;
            PageCommand.RaiseCanExecuteChanged();
        }

        public async void GetDecks(int page)
        {
            var decks = await DatabaseHelper.GetUserDecks(DatabaseHelper.UserID, page);

            Decks.CurrentPage = decks.CurrentPage;
            Decks.PageCount = decks.PageCount;
            Decks.PageSize = decks.PageSize;
            Decks.RowCount = decks.RowCount;
            Decks.Results = decks.Results;
        }

        public async void ImportDeckAsync(string deckString)
        {
            CurrentDeckCards.Clear();
            var cards = await Helpers.DeckParser.ImportDeckAsync(deckString);
            foreach (var card in cards)
            {
                CurrentDeckCards.Add(card);
            }
        }

        public int InsertNewDeck()
        {
            CurrentDeck.MTG_User_idMTG_User = DatabaseHelper.UserID;
            var inserted = DatabaseHelper.InsertDeck(CurrentDeckCards.ToList(), CurrentDeck);
            GetDecks(1);
            return inserted;
        }

        public async void LoadDeck(int deckID)
        {
            var deck = await DatabaseHelper.GetDeckAsync(deckID);

            CurrentDeckCards.Clear();
            foreach (var deckCard in deck.MTG_Deck_Card)
            {
                CurrentDeckCards.Add(deckCard.MTG_Card);
            }

            CurrentDeck.name = deck.name;
            CurrentDeck.description = deck.description;
            CurrentDeck.MTG_Deck_Card = deck.MTG_Deck_Card;

        }
    }
}
