using System.Windows;
using System.Windows.Controls;

namespace MoneyCeeper.User_Controls_Pages_
{
    /// <summary>
    /// Логика взаимодействия для RegistrationUCStyle.xaml
    /// </summary>
    public partial class RegistrationUCStyle : UserControl
    {
        public RegistrationUCStyle()
        {
            InitializeComponent();
        }

        private void UsernameTextBox_Error(object sender, ValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Error.ErrorContent.ToString());
        }
    }
}
