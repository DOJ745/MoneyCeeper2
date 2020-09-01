using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MoneyCeeper.Model;
using MoneyCeeper.User_Controls;

namespace MoneyCeeper.ViewModels
{
    public class LeftPanelVM : ViewModelBase
    {
        #region Properies
        private IMainWindowsCodeBehind _MainCodeBehind;
        public ObservableCollection<Cost> UnsortedCollection { get; set; }
        public IMainWindowsCodeBehind CurrentUC;
        public IMainWindowsCodeBehind CostVM;
        public string DescSearch { get; set; }
        #endregion

        #region Constructors
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

        private RelayCommand _SearchDescrCommand;
        public RelayCommand SearchDescrCommand
        {
            get
            {
                return _SearchDescrCommand = _SearchDescrCommand ??
                new RelayCommand(OnSearchDescrCommand, () => true);
            }
        }

        private RelayCommand _CancelSearchCommand;
        public RelayCommand CancelSearchCommand
        {
            get
            {
                return _CancelSearchCommand = _CancelSearchCommand ??
                new RelayCommand(OnCancelSearchCommand, () => true);
            }
        }
        #endregion

        #region Command Parameters
        private void OnSortCommand()
        {
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).SortContent.Children.OfType<RadioButton>().ToList();
            UnsortedCollection = (CostVM as CostListVM).CostCollection;
            List<Cost> SortedCollection = new List<Cost>();
            int index = radioSort.FindIndex(radio => radio.IsChecked.Value);
            if(index == 1)
            {
                SortedCollection = UnsortedCollection.OrderBy(elem => elem.Price).ToList();
            }
            if(index == 2)
            {
                SortedCollection = UnsortedCollection.OrderBy(elem => elem.Date_Time).ToList();
            }
            if(index == 3)
            {
                SortedCollection = UnsortedCollection.OrderBy(elem => elem.Description).ToList(); 
            }
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = SortedCollection;
        }
        private void OnCancelSortCommand()
        {
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = (CostVM as CostListVM).CostCollection;
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).SortContent.Children.OfType<RadioButton>().ToList();
            radioSort.First().IsChecked = true;
        }

        private void OnFilterCommand()
        {
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).FilterPannel.Children.OfType<RadioButton>().ToList();

            List<RadioButton> radioSort2 = (CurrentUC as LeftPanelUC).FilterButtons.Children.OfType<RadioButton>().ToList();
            List<Cost> SortedCollection = new List<Cost>();

            UnsortedCollection = (CostVM as CostListVM).CostCollection;
            int index = radioSort.FindIndex(radio => radio.IsChecked.Value);
            int index2 = radioSort2.FindIndex(radio => radio.IsChecked.Value);

            if (index2 >= 0)
            {
                SortedCollection = UnsortedCollection.Where(elem => elem.Category == index2).ToList();
            }

            if((CurrentUC as LeftPanelUC).BeginDate.SelectedDate.HasValue &&
                (CurrentUC as LeftPanelUC).EndDate.SelectedDate.HasValue)
            {
                SortedCollection = UnsortedCollection.Where(elem => (elem.Date_Time >=
                (CurrentUC as LeftPanelUC).BeginDate.SelectedDate.Value) &&
                (elem.Date_Time <= (CurrentUC as LeftPanelUC).EndDate.SelectedDate.Value) ).ToList();
            }

            if((CurrentUC as LeftPanelUC).PriceFirst.Text != string.Empty
                && (CurrentUC as LeftPanelUC).PriceSecond.Text != string.Empty)
            {
                SortedCollection = UnsortedCollection.Where(elem => 
                (elem.Price >= Convert.ToDouble((CurrentUC as LeftPanelUC).PriceFirst.Text)) &&
                elem.Price <= Convert.ToDouble((CurrentUC as LeftPanelUC).PriceSecond.Text)).ToList();

                SortedCollection = SortedCollection.OrderBy(elem => elem.Price).ToList();
            }
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = SortedCollection;
        }

        private void OnCancelFilterCommand()
        {
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = (CostVM as CostListVM).CostCollection;
            List<RadioButton> radioSort =
               (CurrentUC as LeftPanelUC).FilterPannel.Children.OfType<RadioButton>().ToList();
            radioSort.First().IsChecked = true;

            (CurrentUC as LeftPanelUC).PriceFirst.Text = string.Empty;
            (CurrentUC as LeftPanelUC).PriceSecond.Text = string.Empty;

            (CurrentUC as LeftPanelUC).BeginDate.SelectedDate = DateTime.Now;
            (CurrentUC as LeftPanelUC).EndDate.SelectedDate = DateTime.Now;
        }

        private void OnSearchDescrCommand()
        {
            List<Cost> SortedCollection = new List<Cost>();
            UnsortedCollection = (CostVM as CostListVM).CostCollection;
            SortedCollection = UnsortedCollection.Where(elem => elem.Price > 0).ToList();
            Regex regex = new Regex(DescSearch, RegexOptions.IgnoreCase);
            SortedCollection = SortedCollection.FindAll(elem =>
            {
                if (elem.Description.Length != 0)
                {
                    return regex.IsMatch(elem.Description);
                }
                return regex.IsMatch(elem.Description);
            });
            if (SortedCollection.Count == 0)
            {
                MessageBox.Show("Ничего не найдено!");
            }
            else
            {
               (_MainCodeBehind as CostList).COSTLIST.ItemsSource = SortedCollection;
            }
        }

        private void OnCancelSearchCommand()
        {
            (_MainCodeBehind as CostList).COSTLIST.ItemsSource = (CostVM as CostListVM).CostCollection;
            (CurrentUC as LeftPanelUC).DescriptionSearch.Text = string.Empty;
        }
        #endregion
    }
}
