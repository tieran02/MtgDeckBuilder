using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MTG_DeckBuilder_Model;


namespace MTG_DeckBuilder_DataAccess
{
    public class DatabaseHelper
    {
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

        public static async Task<PagedResult<MTG_Card>> GetCardPagesByName(string name, int page)
        {
            const int PAGE_SIZE = 8;
            var result = new PagedResult<MTG_Card>();
            result.CurrentPage = page;
            result.PageSize = PAGE_SIZE;

            using (var context = new MtgContext())
            {
                var query = from c in context.MTG_Card
                    where c.name.Contains(name)
                    select c;

                result.RowCount = query.Count();
                var pageCount = (double) result.RowCount / PAGE_SIZE;
                result.PageCount = (int) Math.Ceiling(pageCount);

                var skip = (page - 1) * PAGE_SIZE;
                result.Results = await query.OrderBy(c => c.MTG_Set.releaseDate).Skip(skip).Take(PAGE_SIZE).ToListAsync();
            }

            return result;
        }
    }
}
