using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
using LiveCharts;
using LiveCharts.Wpf;
using MTG_DeckBuilder_Model;
using Separator = LiveCharts.Wpf.Separator;

namespace MTG_DeckBuilder.Usercontrols
{
    /// <summary>
    /// Interaction logic for ManaCurveUserControl.xaml
    /// </summary>
    public partial class ManaCurveUserControl : UserControl
    {
        public ManaCurveUserControl()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Card Count",
                    Values = new ChartValues<int> { 0, 0,0, 0, 0, 0, 0 },
                }
            };

            Formatter = value => value.ToString("N");
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Separator Separator { get; set; }

        public static readonly DependencyProperty CardsProperty = DependencyProperty.Register(
            "Cards", typeof(ObservableCollection<MTG_Card>), typeof(ManaCurveUserControl), new PropertyMetadata(default(ObservableCollection<MTG_Card>), MyPropertyChangedCallback));

        public ObservableCollection<MTG_Card> Cards
        {
            get { return (ObservableCollection<MTG_Card>) GetValue(CardsProperty); }
            set { SetValue(CardsProperty, value); }
        }

        private static void MyPropertyChangedCallback( DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Cast the originator of the event to your type...
            ManaCurveUserControl originator = d as ManaCurveUserControl;
            if (originator != null)
            {
                originator.OnMyPropertyChanged(e);
            }
        }

        private void OnMyPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Cards.CollectionChanged += updateManaCurve;
        }

        private void updateManaCurve(object sender, NotifyCollectionChangedEventArgs e)
        {
            int[] manaCurve = new int[7] {0,0,0,0,0,0,0};

            foreach (var card in Cards)
            {
                int cost = Math.Min((int)Math.Ceiling(card.cmc), 7);

                //ignore mana cost of zero or less
                if(cost <= 0)
                    continue;

                manaCurve[cost-1] += 1;
            }

            for (int i = 0; i < 7; i++)
            {
                SeriesCollection[0].Values[i] = manaCurve[i];
            }
        }
    }
}

