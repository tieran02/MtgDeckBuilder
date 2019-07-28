namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_Deck
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MTG_Deck()
        {
            MTG_Deck_Card = new HashSet<MTG_Deck_Card>();
        }

        [Key]
        public int idMTG_Deck { get; set; }

        public int MTG_User_idMTG_User { get; set; }

        [Required]
        [StringLength(32)]
        public string name { get; set; }

        [StringLength(512)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Deck_Card> MTG_Deck_Card { get; set; }

        public virtual MTG_User MTG_User { get; set; }
    }
}
