using MoneyCeeper.Model;
using MoneyCeeper.Password_Hash;
using System;
using System.Windows;
using MoneyCeeper.User_Controls;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MoneyCeeper.ViewModels
{
    public class LoginVM : ViewModelBase, IMainWindowsCodeBehind, IDataErrorInfo
    {
        #region Properties
        public string Login { get; set; }
        public string Password { get; set; }
        private IMainWindowsCodeBehind _MainCodeBehind;
        #endregion

        #region Constructors
        public LoginVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }
        #endregion

        #region Validation Members
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Login":
                        if (this.Login.Length < 4 || this.Login.Length > 32)
                            result = "Минимальная длина логина - 4. Максимальная - 32";
                        break;
                }
                return result;
            }
        }

        public string Error => throw new NotImplementedException();
        #endregion

        #region Commands
        private RelayCommand _LoginCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                return _LoginCommand = _LoginCommand ??
                    new RelayCommand(OnLoginCommand, () => true);
            }
        }


        private RelayCommand _OpenMenuUCCommand;
        public RelayCommand OpenMenuUCCommand
        {
            get
            {
                return _OpenMenuUCCommand = _OpenMenuUCCommand ??
                    new RelayCommand(OnMenuUCCommand, () => true);
            }
        }
        #endregion

        #region Command Parameters
        private void OnMenuUCCommand()
        {
            _MainCodeBehind.LoadView(ViewType.Menu);
        }

        private void OnLoginCommand()
        {
            using(MainModel context = new MainModel())
            {
                bool verify = SaltedHash.Verify
                    (context.User.Find(Login).Salt,
                    context.User.Find(Login).Password,
                    Password);
                Regex passwRegex = new Regex("\\W");
                MatchCollection matches;
                if (Password != null)
                {
                    matches = passwRegex.Matches(Password);
                }
                else 
                {
                    matches = passwRegex.Matches(Password);
                }

                if (verify && matches.Count == 0)
                {
                    MainWindow currentWindow = (_MainCodeBehind as MainWindow);

                    CostList costList = new CostList();
                    CostListVM vmCost = new CostListVM(currentWindow, 
                        context.User.Find(Login));
                    currentWindow.DataContext = vmCost;
                    currentWindow.OutputView.Content = costList;

                    RightPanelUC rightPanel = new RightPanelUC();
                    RightPanelVM rightVM = new RightPanelVM(costList, rightPanel, vmCost, currentWindow);
                    rightPanel.DataContext = rightVM;
                    currentWindow.RightPanel.Content = rightPanel;

                    LeftPanelUC leftPanel = new LeftPanelUC();
                    LeftPanelVM leftVM = new LeftPanelVM(costList, leftPanel, vmCost);
                    leftPanel.DataContext = leftVM;
                    currentWindow.LeftPanel.Content = leftPanel;
                }
                else if(matches.Count > 0)
                {
                    MessageBox.Show("В пароле присутствуют запрещённые символы( %, ^, '(', ')', * )", null,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
        }
        #endregion
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
