using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class User : ViewModelBase
    {
        private string password;
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
