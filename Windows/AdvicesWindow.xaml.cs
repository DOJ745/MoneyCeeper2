using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace MoneyCeeper.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdvicesWindow.xaml
    /// </summary>
    public partial class AdvicesWindow : Window, IMainWindowsCodeBehind
    {
        public AdvicesWindow()
        {
            InitializeComponent();
            string path = "AdviceInfo.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    this.MainInfo.Text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
