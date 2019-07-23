using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MTG_DeckBuilder_Model;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class AddCardToDeckCommand : ICommand
    {
        public DeckBuilderVM VM { get; set; }

        public AddCardToDeckCommand(DeckBuilderVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var card = parameter as MTG_Card;
            VM.AddCardToDeck(card);
        }

        public event EventHandler CanExecuteChanged;
    }
}
