using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace MoneyCeeper
{
    partial class ApplicationViewModel : INotifyPropertyChanged
    {
        private ICommand showTextCommand;
        public ICommand ShowTextCommand
        {
            get
            {
                return showTextCommand ?? (showTextCommand = new RelayCommand(
                   obj =>
                   {
                       ShowText();
                   }));
            }
        }

        public void ShowText()
        {
            MessageBox.Show("This is text!");
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
