using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<MTG_Card> CurrentDeckCards { get; set; }
        public MTG_Card SelectedCard { get; set; }

        public AddCardToDeckCommand AddCardToDeckCommand { get; set; }
        public RemoveCardFromDeck RemoveCardFromDeckCommand { get; set; }
        public ChangeCardsPageCommand PageCommand { get; set; }
        public ToggleFilterCommand ToggleFilterCommand { get; set; }
        public CardFilters CardFilters { get; set; }

        public DeckBuilderVM()
        {
            Cards = new PagedResult<MTG_Card>();
            CurrentDeckCards = new ObservableCollection<MTG_Card>();
            AddCardToDeckCommand = new AddCardToDeckCommand(this);
            RemoveCardFromDeckCommand = new RemoveCardFromDeck(this);
            PageCommand = new ChangeCardsPageCommand(this);
            ToggleFilterCommand = new ToggleFilterCommand(this);
            CardFilters = CardFilters.NONE;
            SearchText = "";
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
    }
}
