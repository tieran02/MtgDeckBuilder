using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class RemoveDeckCommand : ICommand
    {
        public DeckBuilderVM VM { get; set; }

        public RemoveDeckCommand(DeckBuilderVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int deckId = (int) parameter;
            VM.RemoveDeck(deckId);
        }

        public event EventHandler CanExecuteChanged;
    }
}
