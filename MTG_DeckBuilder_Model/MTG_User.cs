namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MTG_User()
        {
            MTG_Deck = new HashSet<MTG_Deck>();
        }

        [Key]
        public int idMTG_User { get; set; }

        [Required]
        [StringLength(16)]
        public string username { get; set; }

        [Required]
        [StringLength(64)]
        public string email { get; set; }

        [Required]
        [MaxLength(256)]
        public byte[] hash { get; set; }

        [Required]
        [MaxLength(32)]
        public byte[] salt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Deck> MTG_Deck { get; set; }
    }
}
