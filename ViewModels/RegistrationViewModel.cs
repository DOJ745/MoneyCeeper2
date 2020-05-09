﻿using System;
using System.Windows;
using MoneyCeeper.Password_Hash;
using MoneyCeeper.Model;

namespace MoneyCeeper.ViewModels
{
    class RegistrationViewModel : ViewModelBase, IMainWindowsCodeBehind
    {
        // Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        // ctor
        public RegistrationViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

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

        #region Properties
        public string Login { get; set; }
        public string PasswordOne { get; set; }
        public string PasswordTwo { get; set; }
        #endregion

        #region Command Methods
        private void OnRegisterCommand()
        {
            if (PasswordOne == PasswordTwo && Login != null)
            {
                MessageBox.Show("Successful registration!");
                SaltedHash crypt = new SaltedHash(PasswordTwo);
                User newUser = new User { Login = Login,Password = crypt.Hash as string };
                MessageBox.Show("Password - " + PasswordTwo + "\nPassword Hash - " + crypt.Hash);

                using (MainModel context = new MainModel())
                {
                    context.User.Add(newUser);
                    context.SaveChanges();
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
