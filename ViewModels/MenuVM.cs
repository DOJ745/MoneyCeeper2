using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper.ViewModels
{
    public class MenuVM : ViewModelBase
    {
        public IMainWindowsCodeBehind CodeBehind { get; set; }

        /// <summary>
        /// Переход к Login
        /// </summary>
        private RelayCommand _LoadLoginUCCommand;
        public RelayCommand LoadLoginUCCommand
        {
            get
            {
                return _LoadLoginUCCommand = _LoadLoginUCCommand ??
                  new RelayCommand(OnLoadLoginUC, ()=> true);
            }
        }
        private void OnLoadLoginUC()
        {
            CodeBehind.LoadView(ViewType.Login);
        }


        /// <summary>
        /// Переход ко Registration
        /// </summary>
        private RelayCommand _LoadRegistrationUCCommand;
        public RelayCommand LoadRegistrationUCCommand
        {
            get
            {
                return _LoadRegistrationUCCommand = _LoadRegistrationUCCommand ??
                  new RelayCommand(OnLoadSecondUC, ()=> true);
            }
        }
        private void OnLoadSecondUC()
        {
            CodeBehind.LoadView(ViewType.Register);
        }
    }
}
