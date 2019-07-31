using MTG_DeckBuilder_ViewModel;
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

namespace MTG_DeckBuilder.Pages
{
    /// <summary>
    /// Interaction logic for CardViewPage.xaml
    /// </summary>  
    public partial class CardViewPage : Page
    {
        public DeckBuilderVM VM { get; private set; }

        public CardViewPage(DeckBuilderVM vm)
        {
            InitializeComponent();
            VM = vm;
            DataContext = VM;
        }
    }
}
