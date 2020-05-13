using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MoneyCeeper.Model;

namespace MoneyCeeper.ViewModels
{
    class LeftPanelVM : ViewModelBase
    {
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser { get; set;}

        //ctor
        public LeftPanelVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }
        public LeftPanelVM(IMainWindowsCodeBehind codeBehind, User currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
            CurrentUser = currentUser;
            _MainCodeBehind = codeBehind;
        }

        private RelayCommand _FilterDescriptionCommand;
        public RelayCommand FilterDescriptionCommand
        {
            get
            {
                return _FilterDescriptionCommand = _FilterDescriptionCommand ??
                    new RelayCommand(OnFilterDescrCommand, CanFilterDescrCommand);
            }
        }

        private void OnFilterDescrCommand()
        {
            MessageBox.Show($"{CurrentUser.Login} + {CurrentUser.Password}");
        }

        private bool CanFilterDescrCommand()
        {
            return true;
        }
    }
}
