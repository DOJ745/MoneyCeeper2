﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;
using MoneyCeeper.Model;
using MoneyCeeper.Windows;

namespace MoneyCeeper.ViewModels
{
    public class ChangeWindowVM : ViewModelBase, IDataErrorInfo
    {
        #region Constructors
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;
        public ObservableCollection<Cost> CurrentCollection { get; set; }
        public Cost SelectedCost { get; set; }

        public ChangeWindowVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public ChangeWindowVM(IMainWindowsCodeBehind codeBehind, User currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
        }

        public ChangeWindowVM(IMainWindowsCodeBehind codeBehind, User currentUser,
            ObservableCollection<Cost> currentCollection)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
            CurrentCollection = currentCollection;
        }

        public ChangeWindowVM(IMainWindowsCodeBehind codeBehind, User currentUser,
            ObservableCollection<Cost> currentCollection, Cost selectedCost)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
            CurrentCollection = currentCollection;
            SelectedCost = selectedCost;
        }
        #endregion

        #region Properties
        public double Price { get; set; }
        public DateTime Date_Time { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category_Type { get; set; }
        #endregion

        #region Validation Members
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Price":
                        if (this.Price < 0 || this.Price > 1000000.00f)
                            result = "Цена должна быть в пределах от 0 до 1 000 000";
                        break;
                    case "Comment":
                        if ((Comment.Length > 300 || Comment.Length < 15) && (this.Comment != null))
                            result = "Диапазон символов: 15 - 300";
                        break;
                    case "Description":
                        if (this.Description.Length > 300 && this.Description != null)
                            result = "Максимальное колисество символов - 300";
                        break;
                    case "Date_Time":
                        if ((this.Date_Time.Day < 0 ||
                            this.Date_Time.Day > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                            || (this.Date_Time.Month < 0 || this.Date_Time.Month > 12)
                            || (this.Date_Time.Year < 1920 || this.Date_Time.Year > 2100))
                        {
                            result = "Неверный формат даты!";
                        }
                        break;
                }
                return result;
            }
        }

        public string Error => throw new NotImplementedException();
        #endregion

        #region Commands
        private RelayCommand _ChangeCostCommand;
        public RelayCommand ChangeCostCommand
        {
            get
            {
                return _ChangeCostCommand = _ChangeCostCommand ??
                    new RelayCommand(OnChangeCommand, () => true);
            }
        }

        private RelayCommand _CloseWindowCommand;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _CloseWindowCommand = _CloseWindowCommand ??
                    new RelayCommand(() => (_MainCodeBehind as ChangeWindow).Close(), () => true);
            }
        }
        #endregion Commands 

        #region Command Parameters
        private void OnChangeCommand()
        {
            using (MainModel context = new MainModel())
            {
                bool oldValidateOnSaveEnabled = context.Configuration.ValidateOnSaveEnabled;
                try
                {
                    context.Configuration.ValidateOnSaveEnabled = false;

                    context.Entry(SelectedCost).State = EntityState.Deleted;
                    context.SaveChanges();

                    CurrentCollection.Remove(SelectedCost);
                }
                finally
                {
                    context.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                }
            }

            Cost newCost = new Cost();

            newCost.Price = Price;
            newCost.Date_Time = Date_Time;
            newCost.Description = Description;
            newCost.Comment = Comment;
            newCost.Category = (int)Category_Type;
            newCost.Username = CurrentUser.Login;

            using (MainModel context = new MainModel())
            {
                context.Cost.Add(newCost);
                context.SaveChanges();
            }

            MessageBox.Show("Изменение прошло успешно");
            CurrentCollection.Add(newCost);
        }
        #endregion
    }
}
