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
            using (MoneyCeeperEntities MCE = new MoneyCeeperEntities())
            {
                /*Users tempUser = new Users { Login = "123", Password = "228" };
                MCE.Users.Add(tempUser);
                MCE.SaveChanges();*/
                foreach (var elem in MCE.Users)
                    MessageBox.Show(elem.Login);
            }
        }
    }
}
