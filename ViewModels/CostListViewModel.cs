using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Documents;
using MoneyCeeper.Model;
using MoneyCeeper.Windows;

namespace MoneyCeeper.ViewModels
{
    class CostListViewModel : ViewModelBase, IMainWindowsCodeBehind
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;
        public ObservableCollection<Cost> CostCollection{ get; set; }
        #endregion

        #region Constructors
        public CostListViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CostCollection = new ObservableCollection<Cost>();
        }

        public CostListViewModel(IMainWindowsCodeBehind codeBehind, User currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;

            CostCollection = new ObservableCollection<Cost>();
            using (MainModel context = new MainModel())
            {
                foreach (var elem in context.Cost)
                {
                    if (elem.Username == currentUser.Login)
                    {
                        CostCollection.Add(elem);
                    }
                }
            }
        }
        #endregion

        #region Commands
        private RelayCommand _AddCostCommand;
        public RelayCommand AddCostCommand
        {
            get
            {
                return _AddCostCommand = _AddCostCommand ??
                    new RelayCommand(OnAddCommand, CanAddCommand);
            }
        }
        #endregion

        #region Command Parameters
        private void OnAddCommand()
        {
            AddWindow addWindow = new AddWindow();
            AddWindowVM addVM = new AddWindowVM(addWindow, CurrentUser, CostCollection);
            addWindow.DataContext = addVM;
            addWindow.Show();
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
        #endregion
    }
}
