using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyCeeper.Model;

namespace MoneyCeeper.ViewModels
{
    class RightPanelVM : ViewModelBase
    {
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;

        //ctor
        public RightPanelVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public RightPanelVM(IMainWindowsCodeBehind codeBehind, User currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
        }

        private RelayCommand _CloseMainWindowCommand;
        public RelayCommand CloseMainWindowCommand
        {
            get
            {
                return _CloseMainWindowCommand = _CloseMainWindowCommand ??
                    new RelayCommand(() => (_MainCodeBehind as MainWindow).Close(),() => true);
            }
        }

    }
}
