using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System;

namespace MoneyCeeper
{
    public class ApplicationViewModel : ViewModelBase
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
                       ShowText("12345");
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
    }
}
