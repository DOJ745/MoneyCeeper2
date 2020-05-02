using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        [Magic]
        protected virtual void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
