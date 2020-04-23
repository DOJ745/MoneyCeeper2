using System;
using System.Windows;
using System.Windows.Input;

namespace MoneyCeeper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public ICommand DoCommand;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DoCommand = new RelayCommand(CommandExecute, CanCommandExecute);
        }

        private void CommandExecute(object parameter)
        {
            MessageBox.Show("Привет. " + Convert.ToString(parameter));
        }

        private bool CanCommandExecute(object parameter)
        {
            return TextBox1.Text != string.Empty;
        }
    }
}
