using MoneyCeeper.Model;
using MoneyCeeper.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MoneyCeeper.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для CostList.xaml
    /// </summary>
    public partial class CostList : UserControl, IMainWindowsCodeBehind
    {
        public CostList()
        {
            InitializeComponent();
        }

        public void LoadView(ViewType typeView)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
