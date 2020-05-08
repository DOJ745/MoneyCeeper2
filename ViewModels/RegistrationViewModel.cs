using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MoneyCeeper.Password_Hash;

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

        private RelayCommand _RegisterUserCommand;
        public RelayCommand RegisterUserCommand
        {
            get
            {
                return _RegisterUserCommand = _RegisterUserCommand ??
                    new RelayCommand(OnRegisterCommand, CanRegisterCommand);
            }
             
        }

        public string Password { get; set; }


        private void OnRegisterCommand()
        {
            SaltedHash crypt = new SaltedHash(Password);

            MessageBox.Show("You pressed button!");
            _MainCodeBehind.ShowMessage("This is your password - " + Password);
            MessageBox.Show("Hash thing - " + crypt.Hash + "\nHash length - " + crypt.Hash.Length
                +"\nSalt bytes - " + crypt.Salt + 
                "\nVerify result - " + SaltedHash.Verify(crypt.Salt, crypt.Hash, Password));
        }

        private bool CanRegisterCommand()
        {
            return true;
        }

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
