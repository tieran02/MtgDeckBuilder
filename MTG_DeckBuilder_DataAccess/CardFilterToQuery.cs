using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTG_DeckBuilder_Model;

namespace MTG_DeckBuilder_ViewModel.Helpers
{
    public class CardFilterToQuery
    {
        public static void ApplyFilters(CardFilters filterMask, ref IQueryable<MTG_Card> query)
        {

                //Colour filters
                if ((filterMask & CardFilters.WHITE) == CardFilters.WHITE)
                {
                    query = query.Where(c => c.manaCost.Contains("{W}"));
                }
                if ((filterMask & CardFilters.BLUE) == CardFilters.BLUE)
                {
                    query = query.Where(c => c.manaCost.Contains("{U}"));
                }
                if ((filterMask & CardFilters.BLACK) == CardFilters.BLACK)
                {
                    query = query.Where(c => c.manaCost.Contains("{B}"));
                }
                if ((filterMask & CardFilters.RED) == CardFilters.RED)
                {
                    query = query.Where(c => c.manaCost.Contains("{R}"));
                }
                if ((filterMask & CardFilters.GREEN) == CardFilters.GREEN)
                {
                    query = query.Where(c => c.manaCost.Contains("{G}"));
                }
                if ((filterMask & CardFilters.COLOURLESS) == CardFilters.COLOURLESS)
                {
                    query = query.Where(c => !c.manaCost.Contains("{W}") && !c.manaCost.Contains("{U}") && !c.manaCost.Contains("{B}") && !c.manaCost.Contains("{R}") && !c.manaCost.Contains("{G}"));
                }

            //type filters
            if ((filterMask & CardFilters.LAND) == CardFilters.LAND)
            {
                query = query.Where(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "land"));
            }
            if ((filterMask & CardFilters.CREATURE) == CardFilters.CREATURE)
            {
                query = query.Where(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "creature"));
            }
            if ((filterMask & CardFilters.INSTANT) == CardFilters.INSTANT)
            {
                query = query.Where(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "instant"));
            }
            if ((filterMask & CardFilters.SORCERY) == CardFilters.SORCERY)
            {
                query = query.Where(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "sorcery"));
            }
            if ((filterMask & CardFilters.ENCHANTMENT) == CardFilters.ENCHANTMENT)
            {
                query = query.Where(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "enchantment"));
            }
            if ((filterMask & CardFilters.ARTIFACT) == CardFilters.ARTIFACT)
            {
                query = query.Where(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "artifact"));
            }
            if ((filterMask & CardFilters.PLANESWALKER) == CardFilters.PLANESWALKER)
            {
                query = query.Where(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "planeswalker"));
            }

            ////rarity filters
            //if ((filterMask & CardFilters.COMMMON) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Rarity.rarityName == "common");
            //}
            //if ((filterMask & CardFilters.UNCOMMMON) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Rarity.rarityName == "uncommon");
            //}
            //if ((filterMask & CardFilters.RARE) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Rarity.rarityName == "rare");
            //}
            //if ((filterMask & CardFilters.MYTHIC_RARE) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Rarity.rarityName == "mythic");
            //}

            ////cmc filters
            //if ((filterMask & CardFilters.ZERO_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc == 0);
            //}
            //if ((filterMask & CardFilters.ONE_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc == 1);
            //}
            //if ((filterMask & CardFilters.TWO_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc == 2);
            //}
            //if ((filterMask & CardFilters.THREE_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc == 3);
            //}
            //if ((filterMask & CardFilters.FOUR_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc == 4);
            //}
            //if ((filterMask & CardFilters.FIVE_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc == 5);
            //}
            //if ((filterMask & CardFilters.SIX_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc == 6);
            //}
            //if ((filterMask & CardFilters.SEVEN_MANA) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.cmc >= 7);
            //}

            ////format filters
            //if ((filterMask & CardFilters.MODERN) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Card_Legalities.Any(l => l.MTG_Format.formatName == "modern"));
            //}
            //if ((filterMask & CardFilters.STANDARD) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Card_Legalities.Any(l => l.MTG_Format.formatName == "standard"));
            //}
            //if ((filterMask & CardFilters.LEGACY) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Card_Legalities.Any(l => l.MTG_Format.formatName == "legacy"));
            //}
            //if ((filterMask & CardFilters.COMMANDER) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Card_Legalities.Any(l => l.MTG_Format.formatName == "commander"));
            //}
            //if ((filterMask & CardFilters.VINTAGE) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Card_Legalities.Any(l => l.MTG_Format.formatName == "vintage"));
            //}
            //if ((filterMask & CardFilters.PAUPER) != CardFilters.NONE)
            //{
            //    query = query.Where(c => c.MTG_Card_Legalities.Any(l => l.MTG_Format.formatName == "pauper"));
            //}

        }
    }
}
