using MoneyCeeper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper.ViewModels
{
    public class GraphsVM : ViewModelBase
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        private List<Cost> CostList { get; set; }
        #endregion

        #region Constructors
        public GraphsVM(IMainWindowsCodeBehind codeBehind, List<Cost> costList)
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
                    new RelayCommand(On)
            }
        }
        #endregion
    }
}
