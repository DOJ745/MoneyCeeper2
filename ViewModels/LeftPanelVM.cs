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

        private RelayCommand _FilterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return _FilterCommand = _FilterCommand ??
                    new RelayCommand(OnFilterCommand, ()=> true);
            }
        }

        private void OnFilterCommand()
        {
            
        }
    }
}
