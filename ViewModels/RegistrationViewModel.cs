using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper.ViewModels
{
    class RegistrationViewModel : ViewModelBase, IMainWindowsCodeBehind
    {
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public RegistrationViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public void LoadView(ViewType typeView)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
