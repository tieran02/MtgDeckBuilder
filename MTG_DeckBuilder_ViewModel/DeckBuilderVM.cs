using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTG_DeckBuilder_DataAccess;
using MTG_DeckBuilder_Model;
using MTG_DeckBuilder_ViewModel.Commands;

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
                GetCardsBySearchText();
            }
        }

        public ObservableCollection<MTG_Card> Cards { get; set; }
        public ObservableCollection<MTG_Card> CurrentDeckCards { get; set; }
        public MTG_Card SelectedCard { get; set; }

        public AddCardToDeckCommand AddCardToDeckCommand { get; set; }

        public DeckBuilderVM()
        {
            Cards = new ObservableCollection<MTG_Card>();
            CurrentDeckCards = new ObservableCollection<MTG_Card>();
            AddCardToDeckCommand = new AddCardToDeckCommand(this);
            //GetCards();
        }

        public void AddCardToDeck(MTG_Card card)
        {
            CurrentDeckCards.Add(card);
        }

        private async void GetCards()
        {
            var cards = await DatabaseHelper.GetAllCardsFromSetAsync("WAR");

            Cards.Clear();
            foreach (var card in cards)
            {
                //get image url
                card.image = $"https://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={card.multiverseID}&type=card";
                Cards.Add(card);
            }
        }

        private async void GetCardsBySearchText()
        {
            var cards = await DatabaseHelper.GetCardsByName(searchText);

            Cards.Clear();
            foreach (var card in cards)
            {
                //get image url
                card.image = $"https://gatherer.wizards.com/Handlers/Image.ashx?multiverseid={card.multiverseID}&type=card";
                Cards.Add(card);
            }
        }
    }
}
