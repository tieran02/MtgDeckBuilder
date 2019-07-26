using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using MTG_DeckBuilder_Model;

namespace MTG_DeckBuilder_ViewModel.Helpers
{
    public class CardFilterToQuery
    {
        public static void ApplyFilters(CardFilters filterMask, ref IQueryable<MTG_Card> query)
        {
            //Colour filters
            var predicate = PredicateBuilder.New<MTG_Card>();
            if ((filterMask & CardFilters.WHITE) == CardFilters.WHITE)
            {
                predicate = predicate.Or(c => c.manaCost.Contains("{W}"));
            }
            if ((filterMask & CardFilters.BLUE) == CardFilters.BLUE)
            {
                predicate = predicate.Or(c => c.manaCost.Contains("{U}"));
            }
            if ((filterMask & CardFilters.BLACK) == CardFilters.BLACK)
            {
                predicate = predicate.Or(c => c.manaCost.Contains("{B}"));
            }
            if ((filterMask & CardFilters.RED) == CardFilters.RED)
            {
                predicate = predicate.Or(c => c.manaCost.Contains("{R}"));
            }
            if ((filterMask & CardFilters.GREEN) == CardFilters.GREEN)
            {
                predicate = predicate.Or(c => c.manaCost.Contains("{G}"));
            }
            if ((filterMask & CardFilters.COLOURLESS) == CardFilters.COLOURLESS)
            {
                predicate = predicate.Or(c => !c.manaCost.Contains("{W}") && !c.manaCost.Contains("{U}") && !c.manaCost.Contains("{B}") && !c.manaCost.Contains("{R}") && !c.manaCost.Contains("{G}"));
            }
            if (predicate.IsStarted)
                query = query.AsQueryable().Where(predicate);

            //type filters
            predicate = PredicateBuilder.New<MTG_Card>();
            if ((filterMask & CardFilters.LAND) == CardFilters.LAND)
            {
                predicate = predicate.Or(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "land"));
            }
            if ((filterMask & CardFilters.CREATURE) == CardFilters.CREATURE)
            {
                predicate = predicate.Or(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "creature"));
            }
            if ((filterMask & CardFilters.INSTANT) == CardFilters.INSTANT)
            {
                predicate = predicate.Or(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "instant"));
            }
            if ((filterMask & CardFilters.SORCERY) == CardFilters.SORCERY)
            {
                predicate = predicate.Or(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "sorcery"));
            }
            if ((filterMask & CardFilters.ENCHANTMENT) == CardFilters.ENCHANTMENT)
            {
                predicate = predicate.Or(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "enchantment"));
            }
            if ((filterMask & CardFilters.ARTIFACT) == CardFilters.ARTIFACT)
            {
                predicate = predicate.Or(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "artifact"));
            }
            if ((filterMask & CardFilters.PLANESWALKER) == CardFilters.PLANESWALKER)
            {
                predicate = predicate.Or(c => c.MTG_Card_Type.Any(t => t.MTG_Type.typeName == "planeswalker"));
            }
            if (predicate.IsStarted)
                query = query.AsQueryable().Where(predicate);

            //rarity filters
            predicate = PredicateBuilder.New<MTG_Card>();
            if ((filterMask & CardFilters.COMMMON) == CardFilters.COMMMON)
            {
                predicate = predicate.Or(c => c.MTG_Rarity.rarityName == "common");
            }
            if ((filterMask & CardFilters.UNCOMMMON) == CardFilters.UNCOMMMON)
            {
                predicate = predicate.Or(c => c.MTG_Rarity.rarityName == "uncommon");
            }
            if ((filterMask & CardFilters.RARE) == CardFilters.RARE)
            {
                predicate = predicate.Or(c => c.MTG_Rarity.rarityName == "rare");
            }
            if ((filterMask & CardFilters.MYTHIC_RARE) == CardFilters.MYTHIC_RARE)
            {
                predicate = predicate.Or(c => c.MTG_Rarity.rarityName == "mythic");
            }
            if (predicate.IsStarted)
                query = query.AsQueryable().Where(predicate);


            //cmc filters
            predicate = PredicateBuilder.New<MTG_Card>();
            if ((filterMask & CardFilters.ZERO_MANA) == CardFilters.ZERO_MANA)
            {
                predicate = predicate.Or(c => c.cmc == 0);
            }
            if ((filterMask & CardFilters.ONE_MANA) == CardFilters.ONE_MANA)
            {
                predicate = predicate.Or(c => c.cmc == 1);
            }
            if ((filterMask & CardFilters.TWO_MANA) == CardFilters.TWO_MANA)
            {
                predicate = predicate.Or(c => c.cmc == 2);
            }
            if ((filterMask & CardFilters.THREE_MANA) == CardFilters.THREE_MANA)
            {
                predicate = predicate.Or(c => c.cmc == 3);
            }
            if ((filterMask & CardFilters.FOUR_MANA) == CardFilters.FOUR_MANA)
            {
                predicate = predicate.Or(c => c.cmc == 4);
            }
            if ((filterMask & CardFilters.FIVE_MANA) == CardFilters.FIVE_MANA)
            {
                predicate = predicate.Or(c => c.cmc == 5);
            }
            if ((filterMask & CardFilters.SIX_MANA) == CardFilters.SIX_MANA)
            {
                predicate = predicate.Or(c => c.cmc == 6);
            }
            if ((filterMask & CardFilters.SEVEN_MANA) == CardFilters.SEVEN_MANA)
            {
                predicate = predicate.Or(c => c.cmc >= 7);
            }
            if (predicate.IsStarted)
                query = query.AsQueryable().Where(predicate);

            //format filters
            predicate = PredicateBuilder.New<MTG_Card>();
            if ((filterMask & CardFilters.MODERN) == CardFilters.MODERN)
            {
                predicate = predicate.Or(c => c.MTG_Card_Legalities.Any(l => l.MTG_Legality.legalityName == "modern"));
            }
            if ((filterMask & CardFilters.STANDARD) == CardFilters.STANDARD)
            {
                predicate = predicate.Or(c => c.MTG_Card_Legalities.Any(l => l.MTG_Legality.legalityName == "standard"));
            }
            if ((filterMask & CardFilters.LEGACY) == CardFilters.LEGACY)
            {
                predicate = predicate.Or(c => c.MTG_Card_Legalities.Any(l => l.MTG_Legality.legalityName == "legacy"));
            }
            if ((filterMask & CardFilters.COMMANDER) == CardFilters.COMMANDER)
            {
                predicate = predicate.Or(c => c.MTG_Card_Legalities.Any(l => l.MTG_Legality.legalityName == "commander"));
            }
            if ((filterMask & CardFilters.VINTAGE) == CardFilters.VINTAGE)
            {
                predicate = predicate.Or(c => c.MTG_Card_Legalities.Any(l => l.MTG_Legality.legalityName == "vintage"));
            }
            if ((filterMask & CardFilters.PAUPER) == CardFilters.PAUPER)
            {
                predicate = predicate.Or(c => c.MTG_Card_Legalities.Any(l => l.MTG_Legality.legalityName == "pauper"));
            }
            if (predicate.IsStarted)
                query = query.AsQueryable().Where(predicate);
        }
    }
}
