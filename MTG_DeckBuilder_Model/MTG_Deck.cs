using System.ComponentModel;
using System.Runtime.CompilerServices;
using MTG_DeckBuilder_Model.Annotations;

namespace MTG_DeckBuilder_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MTG_Deck : INotifyPropertyChanged
    {
        private string _name;
        private string _description;

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
        public string name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        [StringLength(512)]
        public string description
        {
            get => _description;
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MTG_Deck_Card> MTG_Deck_Card { get; set; }

        public virtual MTG_User MTG_User { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
