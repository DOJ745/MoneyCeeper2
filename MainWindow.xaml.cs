using System.Windows;
using MoneyCeeper.ViewModels;
using MoneyCeeper.User_Controls_Pages_;

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
            // делаем эту вьюмодел контекстом данных
            this.DataContext = vm;

            //загрузка стартовой View
            LoadView(ViewType.Login);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Login:
                    LoginUC viewF = new LoginUC();
                    LoginViewModel vmF = new LoginViewModel(this);
                    viewF.DataContext = vmF;
                    this.OutputView.Content = viewF;
                    break;

                case ViewType.Register:
                    RegistrationUCStyle viewS = new RegistrationUCStyle();
                    RegistrationViewModel vmS = new RegistrationViewModel(this);
                    viewS.DataContext = vmS;
                    this.OutputView.Content = viewS;
                    break;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
