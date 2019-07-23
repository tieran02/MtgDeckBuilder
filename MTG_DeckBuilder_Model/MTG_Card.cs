namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_Card
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MTG_Card()
        {
            MTG_Card_Type = new HashSet<MTG_Card_Type>();
            MTG_Card_Supertype = new HashSet<MTG_Card_Supertype>();
            MTG_Card_Legalities = new HashSet<MTG_Card_Legalities>();
            MTG_Card_Subtype = new HashSet<MTG_Card_Subtype>();
            MTG_Deck_Card = new HashSet<MTG_Deck_Card>();
        }

        [StringLength(36)]
        public string id { get; set; }

        public int MTG_Set_id { get; set; }

        public int MTG_Rarity_id { get; set; }

        public int multiverseID { get; set; }

        [Required]
        [StringLength(150)]
        public string name { get; set; }

        [StringLength(16)]
        public string mciNumber { get; set; }

        [StringLength(1250)]
        public string text { get; set; }

        [StringLength(1250)]
        public string flavor { get; set; }

        [StringLength(64)]
        public string manaCost { get; set; }

        public decimal cmc { get; set; }

        [StringLength(5)]
        public string power { get; set; }

        [StringLength(5)]
        public string toughness { get; set; }

        [Required]
        [StringLength(64)]
        public string artist { get; set; }

        [StringLength(8)]
        public string cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Card_Type> MTG_Card_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Card_Supertype> MTG_Card_Supertype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Card_Legalities> MTG_Card_Legalities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Card_Subtype> MTG_Card_Subtype { get; set; }

        public virtual MTG_Rarity MTG_Rarity { get; set; }

        public virtual MTG_Set MTG_Set { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Deck_Card> MTG_Deck_Card { get; set; }

        [NotMapped]
        public string image { get; set; }
    }
}
