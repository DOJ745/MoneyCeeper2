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
        #region Properies
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser { get; set; }
        public List<Cost> SortedCollection { get; set; }
        public IMainWindowsCodeBehind CurrentUC;
        public IMainWindowsCodeBehind CostVM;
        #endregion

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
            SortedCollection = unsortetCollection;
            _MainCodeBehind = codeBehind;
            CurrentUC = UC;
        }

        public LeftPanelVM(IMainWindowsCodeBehind codeBehind, IMainWindowsCodeBehind UC, IMainWindowsCodeBehind costVM)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
            _MainCodeBehind = codeBehind;
            CurrentUC = UC;
            CostVM = costVM;
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

        private RelayCommand _CancelFilterCommand;
        public RelayCommand CancelFilterCommand
        {
            get
            {
                return _CancelFilterCommand = _CancelFilterCommand ??
                    new RelayCommand(OnCancelFilterCommand, () => true);
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

        private RelayCommand _CancelSortCommand;
        public RelayCommand CancelSortCommand
        {
            get
            {
                return _CancelSortCommand = _CancelSortCommand ??
                new RelayCommand(OnCancelSortCommand, () => true);
            }
        }

        #endregion

        #region Command Parameters
        private void OnSortCommand()
        {
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).SortContent.Children.OfType<RadioButton>().ToList();
            SortedCollection = (CostVM as CostListViewModel).CostCollection;

            int index = radioSort.FindIndex(radio => radio.IsChecked.Value);
            if(index == 1)
            {
                SortedCollection = SortedCollection.OrderBy(elem => elem.Price).ToList();
            }
            if(index == 2)
            {
                SortedCollection = SortedCollection.OrderBy(elem => elem.Date_Time).ToList();
            }
            if(index == 3)
            {
                SortedCollection = SortedCollection.OrderBy(elem => elem.Description).ToList(); 
            }
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = SortedCollection;
        }
        private void OnCancelSortCommand()
        {
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = (CostVM as CostListViewModel).CostCollection;
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).SortContent.Children.OfType<RadioButton>().ToList();
            radioSort.First().IsChecked = true;
        }

        private void OnFilterCommand()
        {
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).FilterPannel.Children.OfType<RadioButton>().ToList();

            List<RadioButton> radioSort2 = (CurrentUC as LeftPanelUC).FilterButtons.Children.OfType<RadioButton>().ToList();

            SortedCollection = (CostVM as CostListViewModel).CostCollection;
            int index = radioSort.FindIndex(radio => radio.IsChecked.Value);
            int index2 = radioSort2.FindIndex(radio => radio.IsChecked.Value);

            if (index2 >= 0)
            {
                SortedCollection = SortedCollection.Where(elem => elem.Category == index2).ToList();
            }

            if((CurrentUC as LeftPanelUC).BeginDate.SelectedDate.HasValue)
            {
                SortedCollection = SortedCollection.Where(elem => elem.Date_Time ==
                (CurrentUC as LeftPanelUC).BeginDate.SelectedDate.Value).ToList();
            }

            if((CurrentUC as LeftPanelUC).PriceFirst.Text != string.Empty
                && (CurrentUC as LeftPanelUC).PriceSecond.Text != string.Empty)
            {
                SortedCollection = SortedCollection.Where(elem => (elem.Price >=
                Convert.ToDouble((CurrentUC as LeftPanelUC).PriceFirst.Text)) &&
                elem.Price <= Convert.ToDouble((CurrentUC as LeftPanelUC).PriceSecond.Text)).ToList();

                SortedCollection = SortedCollection.OrderBy(elem => elem.Price).ToList();
            }
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = SortedCollection;
        }

        private void OnCancelFilterCommand()
        {
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = (CostVM as CostListViewModel).CostCollection;
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).FilterPannel.Children.OfType<RadioButton>().ToList();
            radioSort.First().IsChecked = true;
        }
        #endregion
    }
}
