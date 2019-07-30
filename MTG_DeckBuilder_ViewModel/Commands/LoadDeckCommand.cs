using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class LoadDeckCommand : ICommand
    {
        public DeckBuilderVM VM { get; set; }

        public LoadDeckCommand(DeckBuilderVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int deckID = (int) parameter;
            VM.LoadDeck(deckID);
        }

        public event EventHandler CanExecuteChanged;
    }
}
