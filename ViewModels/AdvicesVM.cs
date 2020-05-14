using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper.ViewModels
{
    public class AdvicesVM : ViewModelBase
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        private string CurrentUser;
        #endregion

        #region Constructors
        public AdvicesVM(IMainWindowsCodeBehind codeBehind, string currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
        }
        #endregion
    }
}
