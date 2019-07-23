using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MTG_DeckBuilder_DataAccess;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class ChangeCardsPageCommand : ICommand
    {
        public DeckBuilderVM VM { get; set; }

        public ChangeCardsPageCommand(DeckBuilderVM vm)
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
                return VM.Cards.CurrentPage + pageOffset <= VM.Cards.PageCount;
            }
            else
            {
                return VM.Cards.CurrentPage + pageOffset > 0;
            }
        }

        public void Execute(object parameter)
        {
            int pageOffset = int.Parse(parameter.ToString());
            setVmCards(pageOffset);
        }


        private async void setVmCards(int pageOffset)
        {
            var cards = await DatabaseHelper.GetCardPagesByName(VM.SearchText, VM.Cards.CurrentPage + pageOffset);

            VM.Cards.CurrentPage = cards.CurrentPage;
            VM.Cards.PageCount = cards.PageCount;
            VM.Cards.PageSize = cards.PageSize;
            VM.Cards.RowCount = cards.RowCount;

            VM.Cards.Results = cards.Results;
            RaiseCanExecuteChanged();
        }
    }
}
