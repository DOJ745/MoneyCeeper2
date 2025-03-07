﻿using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using MoneyCeeper.Model;
using MoneyCeeper.Windows;

namespace MoneyCeeper.ViewModels
{
    public class CostListVM : ViewModelBase, IMainWindowsCodeBehind
    {
        #region Properties
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;
        public ObservableCollection<Cost> CostCollection{ get; set; }
        public Cost SelectedCost { get; set; }
        #endregion

        #region Constructors
        public CostListVM(IMainWindowsCodeBehind codeBehind, User currentUser)
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
                    new RelayCommand(OnAddCommand, ()=> true);
            }
        }

        private RelayCommand _DeleteCostCommand;
        public RelayCommand DeleteCostCommand
        {
            get
            {
                return _DeleteCostCommand = _DeleteCostCommand ??
                    new RelayCommand(OnDeleteCommand, ()=> true);
            }
        }

        private RelayCommand _ChangeCostCommand;
        public RelayCommand ChangeCostCommand
        {
            get
            {
                return _ChangeCostCommand = _ChangeCostCommand ??
                    new RelayCommand(OnChangeCommand, () => true);
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

        private void OnChangeCommand()
        {
            ChangeWindow changeWindow = new ChangeWindow();
            ChangeWindowVM changeVM = new ChangeWindowVM(changeWindow, CurrentUser, CostCollection, SelectedCost);

            changeVM.Price = SelectedCost.Price;
            changeVM.Description = SelectedCost.Description;
            changeVM.Date_Time = SelectedCost.Date_Time;
            changeVM.Category_Type = (CategoryEnum)SelectedCost.Category;
            changeVM.Comment = SelectedCost.Comment;

            changeWindow.DataContext = changeVM;
            changeWindow.Show();
        }

        private void OnDeleteCommand()
        {
            int result = (int)MessageBox.Show("Вы точно хотите удалить выбранное?",
                null, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == (int)MessageBoxResult.Yes)
            {
                using (MainModel context = new MainModel())
                {
                    bool oldValidateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;
                    try
                    {
                        context.Configuration.ValidateOnSaveEnabled = false;
                        context.Entry(SelectedCost).State = EntityState.Deleted;
                        context.SaveChanges();
                        CostCollection.Remove(SelectedCost);
                    }
                    finally
                    {
                        context.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                    }
                }
            }
        }

        public void LoadView(ViewType typeView)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
