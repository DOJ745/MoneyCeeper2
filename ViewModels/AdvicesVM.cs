using MoneyCeeper.Model;
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
        public string InfoText { get; set; }
        #endregion

        #region Constructors
        public AdvicesVM(IMainWindowsCodeBehind codeBehind, ObservableCollection<Cost> currentCollection)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentCollection = currentCollection;
        }
        #endregion
    }
}
