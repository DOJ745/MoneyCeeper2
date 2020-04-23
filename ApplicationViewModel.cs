using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MoneyCeeper
{
    partial class ApplicationViewModel : INotifyPropertyChanged
    {
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
