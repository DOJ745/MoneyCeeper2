using System.Windows;
using MoneyCeeper.ViewModels;
using MoneyCeeper.User_Controls_Pages_;
using System.Reflection.Emit;

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
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
    {
        Login,
        Register
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
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // загрузка вьюмодел для кнопок меню
            MenuViewModel vm = new MenuViewModel();
            // даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            // Делаем текущий ViedModel контекстом данных
            this.DataContext = vm;
            // Стартовый View
            LoadView(ViewType.Login);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Login:
                    LoginUC viewLog = new LoginUC();
                    LoginViewModel vmLog = new LoginViewModel(this);
                    viewLog.DataContext = vmLog;
                    this.OutputView.Content = viewLog;
                    break;

                case ViewType.Register:
                    RegistrationUCStyle viewReg = new RegistrationUCStyle();
                    RegistrationViewModel vmReg = new RegistrationViewModel(this);
                    viewReg.DataContext = vmReg;
                    this.OutputView.Content = viewReg;
                    break;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
