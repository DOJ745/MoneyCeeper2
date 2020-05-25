using MoneyCeeper.Model;
using MoneyCeeper.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoneyCeeper.ViewModels
{

    public class GraphsVM : ViewModelBase
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        private ObservableCollection<Cost> CostList { get; set; }

        public CategoryEnum Category_Type { get; set; }
        #endregion

        #region Constructors
        public GraphsVM(IMainWindowsCodeBehind codeBehind, ObservableCollection<Cost> costList)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CostList = costList;
        }
        #endregion

        #region Commands
        private RelayCommand _BuildGraph;
        public RelayCommand BuildGraph
        {
            get
            {
                return _BuildGraph = _BuildGraph ??
                    new RelayCommand(OnBuildGraph, () => true);
            }
        }

        private RelayCommand _BuildAllGraph;
        public RelayCommand BuildAllGraph
        {
            get
            {
                return _BuildAllGraph = _BuildAllGraph ??
                    new RelayCommand(OnBuildAllGraph, () => true);
            }
        }

        private RelayCommand _CloseWindow;
        public RelayCommand CloseWindow
        {
            get
            {
                return _CloseWindow = _CloseWindow ??
                    new RelayCommand(() => (_MainCodeBehind as GraphsWindow).Close(), () => true);
            }
        }
        #endregion

        #region Command Parameters
        private void OnBuildGraph()
        {
            var Dots = from elem in CostList.Where(elem => elem.Category == (int)Category_Type)
                       select new
                       {
                           CostPrice = elem.Price,
                           CostDate = elem.Date_Time
                       };
            (_MainCodeBehind as GraphsWindow).MainGraph.ItemsSource = Dots;
        }

        private void OnBuildAllGraph()
        {
            var Dots = from elem in CostList
                       select new
                       {
                           CostPrice = elem.Price,
                           CostDate = elem.Date_Time
                       };
            (_MainCodeBehind as GraphsWindow).MainGraph.ItemsSource = Dots;
        }
        #endregion
    }
}
