using System;
using System.Windows;
using MoneyCeeper.Password_Hash;
using MoneyCeeper.Model;
using MoneyCeeper.User_Controls;
using System.ComponentModel;

namespace MoneyCeeper.ViewModels
{
    class RegistrationVM : ViewModelBase, IDataErrorInfo
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        public string Login { get; set; }
        public string PasswordOne { get; set; }
        public string PasswordTwo { get; set; }
        #endregion

        #region Constructors
        public RegistrationVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }
        #endregion

        #region Validation Members
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Login":
                        if (this.Login.Length < 4 || this.Login.Length > 32)
                            result = "Минимальная длина логина - 4. Максимальная - 32";
                        break;
                }
                return result;
            }
        }

        public string Error => throw new NotImplementedException();
        #endregion 

        #region Commands
        private RelayCommand _RegisterUserCommand;
        public RelayCommand RegisterUserCommand
        {
            get
            {
                return _RegisterUserCommand = _RegisterUserCommand ??
                    new RelayCommand(OnRegisterCommand, CanRegisterCommand);
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
        #endregion

        #region Command Methods
        private void OnRegisterCommand()
        {
            if (PasswordOne == PasswordTwo && Login != null)
            {
                SaltedHash crypt = new SaltedHash(PasswordTwo);
                User newUser = new User { Login = Login, Password = crypt.Hash as string , Salt = crypt.Salt as string};
                MessageBox.Show("Successful registration!");
                MessageBox.Show("Password - " + PasswordTwo + "\nPassword Hash - " + crypt.Hash);

                using (MainModel context = new MainModel())
                {
                    context.User.Add(newUser);
                    context.SaveChanges();

                    User currentUser = context.User.Find(Login);
                    MessageBox.Show($"Проверка: Login - {currentUser.Login}; Password - {currentUser.Password}");
                }
            }
            else if(!(PasswordOne == PasswordTwo))
            {
                MessageBox.Show("Check password!");
            }
            else
            {
                MessageBox.Show("Check all!");
            }
        }

        private bool CanRegisterCommand()
        {
            return true;
        }

        private void OnMenuUCCommand()
        {
            _MainCodeBehind.LoadView(ViewType.Menu);
        }

        private bool CanMenuUCCommand()
        {
            return true;
        }
        #endregion

        public void LoadView(ViewType typeView)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
