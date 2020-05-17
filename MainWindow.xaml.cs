using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MoneyCeeper.Model;
using MoneyCeeper.ViewModels;
using MoneyCeeper.User_Controls_Pages_;
using MoneyCeeper.User_Controls;

namespace MoneyCeeper
{
    public interface IMainWindowsCodeBehind
    {
        /// <summary>
        /// Показ сообщения для пользователя
        /// </summary>
        /// <param name="message">текст сообщения</param>
        void ShowMessage(string message);

        /// <summary>
        /// Загрузка нужной View
        /// </summary>
        /// <param name="view">экземпляр UserControl</param>
        void LoadView(ViewType typeView);
        //void LoadView(ViewType typeView, string currentUser);
    }

    /// <summary>
    /// Типы View для загрузки
    /// </summary>
    public enum ViewType
    {
        Login,
        Register,
        Menu
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            MenuUC menu = new MenuUC();
            MenuVM vmMenu = new MenuVM();
            vmMenu.CodeBehind = this;
            this.DataContext = vmMenu;
            this.OutputView.Content = menu;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Стартовый View
            LoadView(ViewType.Menu);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Login:
                    LoginUC log = new LoginUC();
                    LoginVM vmLog = new LoginVM(this);
                    this.DataContext = vmLog;
                    this.OutputView.Content = log;
                    break;

                case ViewType.Register:
                    RegistrationUCStyle reg = new RegistrationUCStyle();
                    RegistrationVM vmReg = new RegistrationVM(this);
                    this.DataContext = vmReg;
                    this.OutputView.Content = reg;
                    break;

                case ViewType.Menu:
                    MenuUC menu = new MenuUC();
                    MenuVM vmMenu = new MenuVM();
                    vmMenu.CodeBehind = this;
                    this.DataContext = vmMenu;
                    this.OutputView.Content = menu;
                    break;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
