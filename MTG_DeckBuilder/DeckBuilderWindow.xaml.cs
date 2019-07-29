using MTG_DeckBuilder.Pages;
using MTG_DeckBuilder_ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace MTG_DeckBuilder
{
    /// <summary>
    /// Interaction logic for DeckBuilderWindow.xaml
    /// </summary>
    public partial class DeckBuilderWindow : Window
    {
        public DeckBuilderWindow()
        {
            InitializeComponent();
            var vm = (DeckBuilderVM)ContentPanel.DataContext;
            ContentFrame.Content = new CardViewPage(vm);
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ExtraFiltersButton_OnClick(object sender, RoutedEventArgs e)
        {
            var filterWindow = new CardFilterWindow();
            filterWindow.DataContext = ContentPanel.DataContext;
            filterWindow.LoadFilters();
            filterWindow.ShowDialog();
        }
    }
}
