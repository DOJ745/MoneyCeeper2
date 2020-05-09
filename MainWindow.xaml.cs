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
            using (MainModel context = new MainModel())
            {
                //User temp = new User {Login = "Login", Password = "123456" };
               // context.User.Add(temp);
                //context.SaveChanges();
                foreach(var elem in context.User)
                {
                    MessageBox.Show("Login - " + elem.Login + ": Password - " + elem.Password);
                }
            }
        }
    }
}
