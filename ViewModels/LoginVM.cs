using MoneyCeeper.Model;
using MoneyCeeper.Password_Hash;
using System;
using System.Windows;
using MoneyCeeper.User_Controls;

namespace MoneyCeeper.ViewModels
{
    public class LoginVM : ViewModelBase, IMainWindowsCodeBehind
    {
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;

        //ctor
        public LoginVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public string Login { get; set; }
        public string Password { get; set; }


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

                if(verify)
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
                else
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
            }
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
