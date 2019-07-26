using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MTG_DeckBuilder_Model;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class ToggleFilterCommand : ICommand
    {
        public DeckBuilderVM VM { get; set; }

        public ToggleFilterCommand(DeckBuilderVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            CardFilters filter = (CardFilters)parameter;

            VM.CardFilters ^= filter;
            VM.GetCardsBySearchText(1);
        }

        public event EventHandler CanExecuteChanged;
    }
}
