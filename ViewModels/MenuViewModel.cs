using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel()
        {

        }

        public IMainWindowsCodeBehind CodeBehind { get; set; }


        /// <summary>
        /// Переход к первой вьюшке
        /// </summary>
        private RelayCommand _LoadLoginUCCommand;
        public RelayCommand LoadLoginUCCommand
        {
            get
            {
                return _LoadLoginUCCommand = _LoadLoginUCCommand ??
                  new RelayCommand(OnLoadLoginUC, CanLoadLoginUC);
            }
        }
        private bool CanLoadLoginUC()
        {
            return true;
        }
        private void OnLoadLoginUC()
        {
            CodeBehind.LoadView(ViewType.Login);
        }


        /// <summary>
        /// Переход ко Второй вьюшке
        /// </summary>
        private RelayCommand _LoadRegistrationUCCommand;
        public RelayCommand LoadRegistrationUCCommand
        {
            get
            {
                return _LoadRegistrationUCCommand = _LoadRegistrationUCCommand ??
                  new RelayCommand(OnLoadSecondUC, CanLoadSecondUC);
            }
        }
        private bool CanLoadSecondUC()
        {
            return true;
        }
        private void OnLoadSecondUC()
        {
            CodeBehind.LoadView(ViewType.Register);
        }
    }
}
