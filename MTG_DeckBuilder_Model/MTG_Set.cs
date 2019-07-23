namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_Set
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MTG_Set()
        {
            MTG_Card = new HashSet<MTG_Card>();
        }

        public int id { get; set; }

        public int MTG_SetType_id { get; set; }

        [Required]
        [StringLength(16)]
        public string code { get; set; }

        [Required]
        [StringLength(128)]
        public string name { get; set; }

        [StringLength(16)]
        public string magicCardsInfoCode { get; set; }

        [StringLength(128)]
        public string mcm_name { get; set; }

        public int? mcm_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime releaseDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Card> MTG_Card { get; set; }

        public virtual MTG_SetType MTG_SetType { get; set; }
    }
}
