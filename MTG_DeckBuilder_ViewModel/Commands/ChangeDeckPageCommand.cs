using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class ChangeDeckPageCommand : ICommand
    {
        public DeckBuilderVM VM { get; set; }

        public ChangeDeckPageCommand(DeckBuilderVM vm)
        {
            VM = vm;
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            int pageOffset = int.Parse(parameter.ToString());

            if (pageOffset >= 0)
            {
                return VM.Decks.CurrentPage + pageOffset <= VM.Decks.PageCount;
            }
            else
            {
                return VM.Decks.CurrentPage + pageOffset > 0;
            }
        }

        public void Execute(object parameter)
        {
            int pageOffset = int.Parse(parameter.ToString());
            VM.GetDecks(VM.Decks.CurrentPage + pageOffset);
        }
    }
}
