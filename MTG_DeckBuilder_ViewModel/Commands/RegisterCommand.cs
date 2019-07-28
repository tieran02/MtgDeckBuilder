using MTG_DeckBuilder_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MTG_DeckBuilder_ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }

        public RegisterCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            var user = parameter as MTG_User;

            //if (user == null)
            //    return false;
            //if (string.IsNullOrEmpty(user.Username))
            //    return false;
            //if (string.IsNullOrEmpty(user.Password))
            //    return false;
            //if (string.IsNullOrEmpty(user.Email))
            //    return false;
            //if (string.IsNullOrEmpty(user.LastName))
            //    return false;
            //if (string.IsNullOrEmpty(user.Name))
            //    return false;

            return true;
        }

        public void Execute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            VM.RegisterAsync(passwordBox.Password);
        }

        public event EventHandler CanExecuteChanged;
    }
}
