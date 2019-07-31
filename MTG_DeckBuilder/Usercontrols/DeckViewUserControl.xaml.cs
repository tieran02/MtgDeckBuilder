using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MTG_DeckBuilder_Model;
using MTG_DeckBuilder_ViewModel.Commands;

namespace MTG_DeckBuilder.Usercontrols
{
    /// <summary>
    /// Interaction logic for DeckViewUserControl.xaml
    /// </summary>
    public partial class DeckViewUserControl : UserControl
    {
        public static readonly DependencyProperty RemoveDeckCommandProperty = DependencyProperty.Register(
            "RemoveDeckCommand", typeof(RemoveDeckCommand), typeof(DeckViewUserControl), new PropertyMetadata(default(RemoveDeckCommand)));



        public RemoveDeckCommand RemoveDeckCommand
        {
            get { return (RemoveDeckCommand) GetValue(RemoveDeckCommandProperty); }
            set { SetValue(RemoveDeckCommandProperty, value); }
        }

        public static readonly DependencyProperty DeckProperty = DependencyProperty.Register(
            "Deck", typeof(MTG_Deck), typeof(DeckViewUserControl), new PropertyMetadata(default(MTG_Deck)));

        public MTG_Deck Deck
        {
            get { return (MTG_Deck) GetValue(DeckProperty); }
            set { SetValue(DeckProperty, value); }
        }

        public DeckViewUserControl()
        {
            InitializeComponent();
            //RemoveDeckCommand.CanExecute(1);
        }

    }
}
