using MTG_DeckBuilder_DataAccess;
using MTG_DeckBuilder_Model;
using MTG_DeckBuilder_ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MTG_DeckBuilder_ViewModel
{

    public class LoginVM
    {
        public MTG_User User { get; set; }

        public RegisterCommand RegisterCommand { get; set; }    
        public LoginCommand LoginCommand { get; set; }

        public event EventHandler HasLoggedIn;
        public LoginVM()
        {
            User = new MTG_User();
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }


        public async void LoginAsync(string password)
        {

            using (MtgContext context = new MtgContext())
            {
                var user = context.MTG_User.FirstOrDefault(u => u.username == User.username);
                if (user == null)
                {
                    MessageBox.Show("Password/Username Incorrect", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //get user salt
                var salt = user.salt;
                User.hash = Helpers.PasswordGenerator.CreateHash(password, salt).Hash;

                //check password
                if (User.hash.SequenceEqual(user.hash))
                {
                    //login
                    DatabaseHelper.UserID = user.idMTG_User;
                    HasLoggedIn(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Password/Username Incorrect", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public async void RegisterAsync(string password)
        {
            //hash password
            var passwordStore = Helpers.PasswordGenerator.CreateHash(password, Helpers.PasswordGenerator.GenerateRandomSalt());
            User.hash = passwordStore.Hash;
            User.salt = passwordStore.Salt;

            using (MtgContext context = new MtgContext()) 
            {
                if (context.MTG_User.Any(u => u.username == User.username))
                {
                    //user already exists;
                    MessageBox.Show("User already exists!", "Registration", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                context.MTG_User.Add(User);
                await context.SaveChangesAsync();
                HasLoggedIn(this, new EventArgs());
            }
        }
    }
}
