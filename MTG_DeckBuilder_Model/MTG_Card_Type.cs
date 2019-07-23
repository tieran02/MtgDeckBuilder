namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_Card_Type
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MTG_Type_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(36)]
        public string MTG_Card_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int id { get; set; }

        public virtual MTG_Card MTG_Card { get; set; }

        public virtual MTG_Type MTG_Type { get; set; }
    }
}
