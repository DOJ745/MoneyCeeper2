using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System;

namespace MoneyCeeper
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        #region Commands
        private RelayCommand showTextCommand;
        public RelayCommand ShowTextCommand
        {
            get
            {
                return showTextCommand ?? 
                (showTextCommand = new RelayCommand(obj =>
                   {
                       ShowText("123");
                   })
                );
            }
        }

        public void ShowText(object parametr)
        {
            MessageBox.Show("This is text! And argument: " + Convert.ToString(parametr));
        }
        #endregion
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
