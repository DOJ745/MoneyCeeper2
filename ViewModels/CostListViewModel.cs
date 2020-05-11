using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using MoneyCeeper.Model;

namespace MoneyCeeper.ViewModels
{
    class CostListViewModel : ViewModelBase, IMainWindowsCodeBehind
    {
        //Fields
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;

        //ctor
        public CostListViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public CostListViewModel(IMainWindowsCodeBehind codeBehind, User currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
        }

        #region Properties
        public float Price { get; set; }
        public DateTime Date_Time { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
        public string Username { get; set; }
        #endregion

        private RelayCommand _AddCostCommand;
        public RelayCommand AddCostCommand
        {
            get
            {
                return _AddCostCommand = _AddCostCommand ??
                    new RelayCommand(OnAddCommand, CanAddCommand);
            }
        }

        private void OnAddCommand()
        {
            MessageBox.Show($"currentUser login: - {CurrentUser.Login}");
        }

        private bool CanAddCommand()
        {
            return true;
        }

        public void LoadView(ViewType typeView)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
