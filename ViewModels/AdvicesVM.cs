using MoneyCeeper.Model;
using MoneyCeeper.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper.ViewModels
{
    public class AdvicesVM : ViewModelBase
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        private ObservableCollection<Cost> CurrentCollection;
        #endregion

        #region Constructors
        public AdvicesVM(IMainWindowsCodeBehind codeBehind, ObservableCollection<Cost> currentCollection)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentCollection = currentCollection;
        }
        #endregion

        #region Commands
        private RelayCommand _CloseCommand;
        public RelayCommand CloseCommand
        {
            get
            {
                return _CloseCommand = _CloseCommand ??
                    new RelayCommand(() => (_MainCodeBehind as AdvicesWindow).Close(), () => true);
            }
        }
        #endregion
    }
}
