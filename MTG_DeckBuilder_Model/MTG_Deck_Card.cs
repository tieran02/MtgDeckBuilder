namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_Deck_Card
    {
        [Key]
        public int idMTG_Deck_Card { get; set; }

        [Required]
        [StringLength(36)]
        public string MTG_Card_id { get; set; }

        public int MTG_Deck_idMTG_Deck { get; set; }

        public virtual MTG_Card MTG_Card { get; set; }

        public virtual MTG_Deck MTG_Deck { get; set; }
    }
}
