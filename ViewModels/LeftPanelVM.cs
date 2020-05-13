using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MoneyCeeper.Model;
using MoneyCeeper.User_Controls;

namespace MoneyCeeper.ViewModels
{
    class LeftPanelVM : ViewModelBase
    {
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser { get; set; }
        public List<Cost> UnsortedCollection { get; set; }
        public IMainWindowsCodeBehind CurrentUC;

        #region Constructors
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

        public LeftPanelVM(IMainWindowsCodeBehind codeBehind, List<Cost> unsortetCollection, IMainWindowsCodeBehind UC)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
            UnsortedCollection = unsortetCollection;
            _MainCodeBehind = codeBehind;
            CurrentUC = UC;
        }
        #endregion

        #region Commands
        private RelayCommand _FilterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return _FilterCommand = _FilterCommand ??
                    new RelayCommand(OnFilterCommand, ()=> true);
            }
        }

        private RelayCommand _SortCommand;
        public RelayCommand SortCommand
        {
            get
            {
                return _SortCommand = _SortCommand ??
                    new RelayCommand(OnSortCommand, () => true);
            }
        }
        #endregion

        #region Command Parameters
        private void OnSortCommand()
        {
             
        }
        private void OnFilterCommand()
        {
            //UnsortedCollection = (_MainCodeBehind as CostListViewModel).CostCollection;
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).FilterPannel.Children.OfType<RadioButton>().ToList();

            int index = radioSort.FindIndex(radio => radio.IsChecked.Value) - 1;
            if (index >= 0)
            {
                UnsortedCollection = UnsortedCollection.Where(elem => elem.Category == index).ToList();
            }
        }
        #endregion
    }
}
