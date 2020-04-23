using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System;

namespace MoneyCeeper
{
    public partial class ApplicationViewModel : INotifyPropertyChanged
    {
        private RelayCommand showTextCommand;
        public RelayCommand ShowTextCommand
        {
            get
            {
                return showTextCommand ?? 
                (showTextCommand = new RelayCommand(obj =>
                   {
                       ShowText("12345");
                   })
                );
            }
        }

        public void ShowText(object parametr)
        {
            MessageBox.Show("This is text! And argument: " + Convert.ToString(parametr));
        }

        public void Update()
        {
 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
