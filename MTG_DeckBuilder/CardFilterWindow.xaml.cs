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
using System.Windows.Shapes;
using MTG_DeckBuilder_Model;
using MTG_DeckBuilder_ViewModel;

namespace MTG_DeckBuilder
{
    /// <summary>
    /// Interaction logic for CardFilterWindow.xaml
    /// </summary>
    public partial class CardFilterWindow : Window
    {
        public CardFilterWindow()
        {
            InitializeComponent();
        }

        public void LoadFilters()
        {
            DeckBuilderVM vm = this.DataContext as DeckBuilderVM;

            var filterMask = vm.CardFilters;
            if ((filterMask & CardFilters.ZERO_MANA) == CardFilters.ZERO_MANA)
            {
                ZeroManaButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.ONE_MANA) == CardFilters.ONE_MANA)
            {
                OneManaButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.TWO_MANA) == CardFilters.TWO_MANA)
            {
                TwoManaButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.THREE_MANA) == CardFilters.THREE_MANA)
            {
                ThreeManaButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.FOUR_MANA) == CardFilters.FOUR_MANA)
            {
                FourManaButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.FIVE_MANA) == CardFilters.FIVE_MANA)
            {
                FiveManaButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.SIX_MANA) == CardFilters.SIX_MANA)
            {
                SixManaButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.SEVEN_MANA) == CardFilters.SEVEN_MANA)
            {
                SevenManaButton.IsChecked = true;
            }

            //types
            if ((filterMask & CardFilters.LAND) == CardFilters.LAND)
            {
                LandButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.CREATURE) == CardFilters.CREATURE)
            {
                CreatureButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.INSTANT) == CardFilters.INSTANT)
            {
                InstantButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.SORCERY) == CardFilters.SORCERY)
            {
                SorceryButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.ENCHANTMENT) == CardFilters.ENCHANTMENT)
            {
                EnchantmentButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.ARTIFACT) == CardFilters.ARTIFACT)
            {
                ArtifactButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.PLANESWALKER) == CardFilters.PLANESWALKER)
            {
                PlaneswalkerButton.IsChecked = true;
            }

            //rarity
            if ((filterMask & CardFilters.COMMMON) == CardFilters.COMMMON)
            {
                CommonButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.UNCOMMMON) == CardFilters.UNCOMMMON)
            {
                UncommonButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.RARE) == CardFilters.RARE)
            {
                RareButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.MYTHIC_RARE) == CardFilters.MYTHIC_RARE)
            {
                MythicButton.IsChecked = true;
            }

            //legality
            if ((filterMask & CardFilters.MODERN) == CardFilters.MODERN)
            {
                ModernButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.STANDARD) == CardFilters.STANDARD)
            {
                StandardButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.LEGACY) == CardFilters.LEGACY)
            {
                LegacyButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.COMMANDER) == CardFilters.COMMANDER)
            {
                CommanderButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.VINTAGE) == CardFilters.VINTAGE)
            {
                VintageButton.IsChecked = true;
            }
            if ((filterMask & CardFilters.PAUPER) == CardFilters.PAUPER)
            {
                PauperButton.IsChecked = true;
            }
        }
    }
}
