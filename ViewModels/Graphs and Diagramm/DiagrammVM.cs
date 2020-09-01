using MoneyCeeper.Model;
using MoneyCeeper.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoneyCeeper.ViewModels
{
    public class DiagrammVM : ViewModelBase
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        public ObservableCollection<Cost> CostList { get; set; }
        public double TotalCost { get; set; }
        public CategoryEnum Category_Type { get; set; }
        #endregion

        #region Constructors
        public DiagrammVM(IMainWindowsCodeBehind codeBehind, ObservableCollection<Cost> costList)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CostList = costList;
            TotalCost = CostList.Sum(elem => elem.Price);
        }
        #endregion
        #region Commands
        private RelayCommand _BuildDiagramm;
        public RelayCommand BuildDiagramm
        {
            get
            {
                return _BuildDiagramm = _BuildDiagramm ??
                    new RelayCommand(OnBuildDiagramm, () => true);
            }
        }

        private RelayCommand _CloseWindow;
        public RelayCommand CloseWindow
        {
            get
            {
                return _CloseWindow = _CloseWindow ??
                    new RelayCommand(() => (_MainCodeBehind as DiagrammWindow).Close(), () => true);
            }
        }
        #endregion
        #region Command Parameters
        private void OnBuildDiagramm()
        {
            List<CostDiag> Parts = new List<CostDiag>();
            for(int i = 0; i < 11; i++)
            {
                double sum = CategoryTotalPrice(i);
                CostDiag tempCost = new CostDiag { CostPrice = sum, CostCategory = i };
                Parts.Add(tempCost);
            }
            (_MainCodeBehind as DiagrammWindow).MainDiagramm.ItemsSource = Parts;
        }
        #endregion

        #region Diagramm Things
        public double CategoryTotalPrice(int categoryNumber)
        {
            return CostList.Where(item => item.Category == categoryNumber).Sum(sum => sum.Price);
        }

        public class CostDiag
        {
            public double CostPrice { get; set; }
            public int CostCategory { get; set; }
        }
        #endregion
    }
}
        

