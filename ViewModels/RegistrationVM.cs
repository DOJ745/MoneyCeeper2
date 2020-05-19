using System;
using System.Windows;
using MoneyCeeper.Password_Hash;
using MoneyCeeper.Model;
using MoneyCeeper.User_Controls;
using System.ComponentModel;
using System.Text.RegularExpressions;

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
                        if ((this.Login.Length < 4 || this.Login.Length > 32) && (this.Login != null))
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
                    new RelayCommand(OnRegisterCommand, () => true);
            }
             
        }

        private RelayCommand _OpenMenuUCCommand;
        public RelayCommand OpenMenuUCCommand
        {
            get
            {
                return _OpenMenuUCCommand = _OpenMenuUCCommand ??
                    new RelayCommand(OnMenuUCCommand, () => true);
            }
        }
        #endregion

        #region Command Methods
        private void OnRegisterCommand()
        {
            Regex passwRegex = new Regex("\\W");
            MatchCollection matches1;
            MatchCollection matches2;
            if (PasswordOne != null || PasswordTwo != null)
            {
                matches1 = passwRegex.Matches(PasswordOne);
                matches2 = passwRegex.Matches(PasswordTwo);
            }
            else
            {
                matches1 = passwRegex.Matches(PasswordOne);
                matches2 = passwRegex.Matches(PasswordTwo);
            }

            if (matches1.Count == 0  && matches2.Count == 0 && Login != null)
            {
                SaltedHash crypt = new SaltedHash(PasswordTwo);
                User newUser = new User { Login = Login, 
                    Password = crypt.Hash as string , 
                    Salt = crypt.Salt as string};

                using (MainModel context = new MainModel())
                {
                    if(context.User.Find(Login).Login == newUser.Login)
                    {
                        MessageBox.Show("Пользователь с данным именем уже существует!", null,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        context.User.Add(newUser);
                        context.SaveChanges();
                        MessageBox.Show("Регистрация прошла успешно!", null,
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }   
            }
            else if(!(PasswordOne == PasswordTwo))
            {
                MessageBox.Show("Пароли не совпадают!", null, 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("В пароле присутствуют запрещённые символы( %, ^, '(', ')', * )", null,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnMenuUCCommand()
        {
            _MainCodeBehind.LoadView(ViewType.Menu);
        }
        #endregion
    }
}
