namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_Card_Legalities
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MTG_Format_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MTG_Legality_id { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(36)]
        public string MTG_Card_id { get; set; }

        [Key]
        [Column(Order = 3)]
        public int id { get; set; }

        public virtual MTG_Card MTG_Card { get; set; }

        public virtual MTG_Format MTG_Format { get; set; }

        public virtual MTG_Legality MTG_Legality { get; set; }
    }
}
