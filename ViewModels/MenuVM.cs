using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCeeper.ViewModels
{
    public class MenuVM : ViewModelBase
    {
        #region Properies
        public IMainWindowsCodeBehind CodeBehind { get; set; }
        #endregion

        #region Commands
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

        /// <summary>
        /// Переход ко Registration
        /// </summary>
        private RelayCommand _LoadRegistrationUCCommand;
        public RelayCommand LoadRegistrationUCCommand
        {
            get
            {
                return _LoadRegistrationUCCommand = _LoadRegistrationUCCommand ??
                  new RelayCommand(OnLoadRegUC, () => true);
            }
        }
        #endregion

        #region Command Parameters
        private void OnLoadLoginUC()
        {
            CodeBehind.LoadView(ViewType.Login);
        }

        private void OnLoadRegUC()
        {
            CodeBehind.LoadView(ViewType.Register);
        }
        #endregion
    }
}
