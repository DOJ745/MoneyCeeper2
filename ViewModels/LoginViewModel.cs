using System;

namespace MoneyCeeper.ViewModels
{
    public class LoginViewModel : ViewModelBase, IMainWindowsCodeBehind
    {
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public LoginViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        private RelayCommand _OpenMenuUCCommand;
        public RelayCommand OpenMenuUCCommand
        {
            get
            {
                return _OpenMenuUCCommand = _OpenMenuUCCommand ??
                    new RelayCommand(OnMenuUCCommand, CanMenuUCCommand);
            }
        }

        private void OnMenuUCCommand()
        {
            _MainCodeBehind.LoadView(ViewType.Menu);
        }

        private bool CanMenuUCCommand()
        {
            return true;
        }

        public void LoadView(ViewType typeView)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
