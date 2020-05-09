using MoneyCeeper.Model;
using MoneyCeeper.Password_Hash;
using System;
using System.Windows;

namespace MoneyCeeper.ViewModels
{
    public class LoginViewModel : ViewModelBase, IMainWindowsCodeBehind
    {
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public LoginViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public string Login { get; set; }
        public string Password { get; set; }


        private RelayCommand _LoginCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                return _LoginCommand = _LoginCommand ??
                    new RelayCommand(OnLoginCommand, CanLoginCommand);
            }
        }


        private RelayCommand _OpenMenuUCCommand;
        public RelayCommand OpenMenuUCCommand
        {
            get
            {
                return _OpenMenuUCCommand = _OpenMenuUCCommand ??
                    new RelayCommand(OnMenuUCCommand, CanMenuUCCommand);
            }
        }

        private void OnMenuUCCommand()
        {
            _MainCodeBehind.LoadView(ViewType.Menu);
        }

        private bool CanMenuUCCommand()
        {
            return true;
        }

        private void OnLoginCommand()
        {
            using(MainModel context = new MainModel())
            {
                bool verify = SaltedHash.Verify
                    (context.User.Find(Login).Salt, 
                    context.User.Find(Login).Password, 
                    Password);
                MessageBox.Show($"Login - {Login}; Password - {Password};" +
                    $"Result - {verify}");
            }
        }

        private bool CanLoginCommand()
        {
            return true;
        }

        public void LoadView(ViewType typeView)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
