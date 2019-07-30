using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using MTG_DeckBuilder_Model;
using MTG_DeckBuilder_ViewModel.Helpers;


namespace MTG_DeckBuilder_DataAccess
{
    public class DatabaseHelper
    {
        public static int UserID { get; set; }

        public static async Task<MTG_Set> GetSetAsync(string setCode)
        {
            using (var context = new MtgContext())
            {
                var query = from s in context.MTG_Set
                    where s.code == setCode
                    select s;


                var set = await query.FirstOrDefaultAsync();
                return set;
            }
        }

        public static async Task<List<MTG_Card>> GetAllCardsFromSetAsync(string setCode)
        {
            List<MTG_Card> mtgCards = new List<MTG_Card>();

            using (var context = new MtgContext())
            {
                var query = from s in context.MTG_Set
                    where s.code == setCode
                    select s.MTG_Card;

                var cards = await query.Take(8).FirstOrDefaultAsync();
                if (cards != null)
                    mtgCards.AddRange(cards);
            }

            return mtgCards;
        }

        public static async Task<MTG_Card> GetCard(string id)
        {
            MTG_Card mtgCard = new MTG_Card();

            using (var context = new MtgContext())
            {
                var query = from c in context.MTG_Card
                    where c.id == id
                    select c;


                var card = await query.FirstOrDefaultAsync();
                if (card != null)
                    mtgCard = card;
            }

            return mtgCard;
        }

        public static async Task<List<MTG_Card>> GetCardsByName(string name)
        {
            List<MTG_Card> mtgCards = new List<MTG_Card>();

            using (var context = new MtgContext())
            {
                var query = from c in context.MTG_Card
                    where c.name.Contains(name)
                    select c;


                var cards = await query.OrderByDescending(c => c.MTG_Set.releaseDate).Take(100).ToListAsync();
                mtgCards.AddRange(cards);
            }

            return mtgCards;
        }

        public static async Task<PagedResult<MTG_Card>> GetCardPagesByName(string name, int page, CardFilters filters = CardFilters.NONE)
        {
            const int PAGE_SIZE = 8;
            var result = new PagedResult<MTG_Card>();
            result.CurrentPage = page;
            result.PageSize = PAGE_SIZE;

            using (var context = new MtgContext())
            {
                var query = from c in context.MTG_Card
                    where c.name.Contains(name) && c.MTG_Set.MTG_SetType.typeName != "promo"
                    select c;

                CardFilterToQuery.ApplyFilters(filters, ref query);


                result.RowCount = query.Count();
                var pageCount = (double) result.RowCount / PAGE_SIZE;
                result.PageCount = (int) Math.Ceiling(pageCount);

                var skip = (page - 1) * PAGE_SIZE;


                result.Results = await query.AsExpandable().OrderByDescending(c => c.MTG_Set.releaseDate).Skip(skip).Take(PAGE_SIZE).ToListAsync();
            }

            return result;
        }

        public static async Task<MTG_Card> GetCardFromNameAndSet(string name, string setCode)
        {
            MTG_Card mtgCard = new MTG_Card();

            using (var context = new MtgContext())
            {
                var query = from c in context.MTG_Card
                    where c.name == name && c.MTG_Set.code == setCode
                    select c;


                var card = await query.FirstOrDefaultAsync();
                if (card != null)
                    mtgCard = card;
                else
                {
                    //get first card of that name
                    query = from c in context.MTG_Card
                    where c.name == name
                    select c;


                    mtgCard = await query.FirstOrDefaultAsync();
                }
            }

            return mtgCard;
        }

        public static async Task<PagedResult<MTG_Deck>> GetUserDecks(int userID, int page)
        {
            const int PAGE_SIZE = 8;
            var result = new PagedResult<MTG_Deck>();
            result.CurrentPage = page;
            result.PageSize = PAGE_SIZE;

            using (var context = new MtgContext())
            {
                var query = from d in context.MTG_Deck
                            where d.MTG_User.idMTG_User == userID
                            select d;


                result.RowCount = query.Count();
                var pageCount = (double)result.RowCount / PAGE_SIZE;
                result.PageCount = (int)Math.Ceiling(pageCount);

                var skip = (page - 1) * PAGE_SIZE;


                result.Results = await query.OrderBy(d => d.name).Skip(skip).Take(PAGE_SIZE).ToListAsync();
            }

            return result;
        }

        public static int InsertDeck(List<MTG_Card> cards ,MTG_Deck deck)
        {
            using (var context = new MtgContext())
            {
                MTG_Deck newDeck = new MTG_Deck();
                newDeck.name = deck.name;
                newDeck.description = deck.description;
                newDeck.MTG_User_idMTG_User = deck.MTG_User_idMTG_User;

                context.MTG_Deck.Add(newDeck);

                foreach (var card in cards)
                {
                    var deckCard = new MTG_Deck_Card();
                    deckCard.MTG_Card_id = card.id;
                    newDeck.MTG_Deck_Card.Add(deckCard);
                }
                return context.SaveChanges();
            }
        }

        public static async Task<MTG_Deck> GetDeckAsync(int id)
        {
            using (var context = new MtgContext())
            {
                var query = context.MTG_Deck
                    .Include(dc => dc.MTG_Deck_Card.Select(c=>c.MTG_Card))
                    .Where(d => d.idMTG_Deck == id);
                    

                return await query.FirstOrDefaultAsync();
            }
        }
    }
}
