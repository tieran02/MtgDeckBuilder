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
        [Column(Order = 0)]
        [StringLength(36)]
        public string MTG_Card_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MTG_Deck_idMTG_Deck { get; set; }

        [Key]
        [Column(Order = 2)]
        public int id { get; set; }

        public virtual MTG_Card MTG_Card { get; set; }

        public virtual MTG_Deck MTG_Deck { get; set; }
    }
}
