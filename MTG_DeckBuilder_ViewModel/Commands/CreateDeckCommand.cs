using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class CreateDeckCommand : ICommand
    {
        public DeckBuilderVM VM { get; set; }

        public CreateDeckCommand(DeckBuilderVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int inserted = VM.CreateDeck();
        }

    }
}
