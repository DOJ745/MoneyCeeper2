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
    public class DiagrammVM : ViewModelBase
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        private ObservableCollection<Cost> CostList { get; set; }

        public CategoryEnum Category_Type { get; set; }
        #endregion
        public DiagrammVM(IMainWindowsCodeBehind codeBehind, ObservableCollection<Cost> costList)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CostList = costList;
        }

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

        private void OnBuildDiagramm()
        {
            var Parts = from elem in CostList
                       select new
                       {
                           CostPrice = elem.Price,
                           CostCategory = elem.Category
                       };
            (_MainCodeBehind as DiagrammWindow).MainDiagramm.ItemsSource = Parts;
        }
    }
}
