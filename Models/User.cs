using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class User : INotifyPropertyChanged
    {
        private string password;
        public int[] Cost_Id
        {
            get { return Cost_Id; }
            set
            {
                Cost_Id = value;
                OnPropertyChanged("Cost_Id");
            }
        }
        public string Login
        {
            get { return Login; }
            set
            {
                Login = value;
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
