using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MTG_DeckBuilder_DataAccess;
using MTG_DeckBuilder_Model;

namespace MTG_DeckBuilder_ViewModel.Helpers
{
    public class DeckParser
    {

        public static async Task<List<MTG_Card>> ImportDeckAsync(string deckString)
        {
            List<MTG_Card> deckCards = new List<MTG_Card>();

            deckString = deckString.Replace("\r","");
            var result = deckString.Split(new[] { '\n' });

            foreach (var cardString in result)
            {
                if (cardString == "")
                    break;

                string[] numbers = Regex.Split(cardString, @"\D+");
                int quantity = numbers[0].Length > 0 ? int.Parse(numbers[0]) : 0;
                int cardNumber = numbers[1].Length > 0 ? int.Parse(numbers[1]) : 0;
                string setCode = cardString.Split('(', ')')[1];

                string cardName = cardString.Substring(numbers[0].Length + 1, cardString.IndexOf('(') - 3);

                var card = await DatabaseHelper.GetCardFromNameAndSet(cardName, setCode);
                if (card != null)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        deckCards.Add(card);
                    }
                }
            }


            return deckCards;
        }
    }
}
