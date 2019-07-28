using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTG_DeckBuilder_Model
{
    [Flags]
    public enum CardFilters
    {
        NONE = 1 << 0,
        WHITE = 1 << 1,
        BLUE = 1 << 2,
        BLACK = 1 << 3,
        RED = 1 << 4,
        GREEN = 1 << 5,
        COLOURLESS = 1 << 6,
        LAND = 1 << 7,
        CREATURE = 1 << 8,
        INSTANT = 1 << 9,
        SORCERY = 1 << 10,
        ENCHANTMENT = 1 << 11,
        ARTIFACT = 1 << 12,
        PLANESWALKER = 1 << 13,
        COMMMON = 1 << 14,
        UNCOMMMON = 1 << 15,
        RARE = 1 << 16,
        MYTHIC_RARE = 1 << 17,
        ZERO_MANA = 1 << 18,
        ONE_MANA = 1 << 19,
        TWO_MANA = 1 << 20,
        THREE_MANA = 1 << 21,
        FOUR_MANA = 1 << 22,
        FIVE_MANA = 1 << 23,
        SIX_MANA = 1 << 24,
        SEVEN_MANA = 1 << 25,
        MODERN = 1 << 26,
        STANDARD = 1 << 27,
        LEGACY = 1 << 28,
        COMMANDER = 1 << 29,
        VINTAGE = 1 << 30,
        PAUPER = 1 << 31,
    }

    public partial class MTG_Card
    {

        [NotMapped]
        public string image { get; set; }
    }
}
