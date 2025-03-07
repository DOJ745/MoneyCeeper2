﻿using System;
using System.Windows;
using MoneyCeeper.Model;
using MoneyCeeper.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MoneyCeeper.ViewModels
{
    class AddWindowVM : ViewModelBase, IDataErrorInfo
    {
        #region Properties
        public double Price { get; set; }
        public DateTime Date_Time { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category_Type { get; set; }
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;
        public ObservableCollection<Cost> CurrentCollection { get; set; }
        #endregion

        #region Constructors
        public AddWindowVM(IMainWindowsCodeBehind codeBehind, User currentUser, 
            ObservableCollection<Cost> currentCollection)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
            CurrentCollection = currentCollection;
        }
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
                        if (this.Price < 0 || this.Price > 1000000.00)
                            result = "Цена должна быть в пределах от 0 до 1 000 000";
                        break;

                    case "Comment":
                        if ((this.Comment.Length > 300 || this.Comment.Length < 15) && (this.Comment != null))
                            result = "Диапазон символов: 15 - 300";
                        break;

                    case "Description":
                        if (this.Description.Length > 300 && this.Description != null)
                             result = "Максимальное колисество символов - 300";
                        break;

                    case "Date_Time":
                        if( (this.Date_Time.Day < 0 || 
                            this.Date_Time.Day > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) 
                            || (this.Date_Time.Month < 0 || this.Date_Time.Month > 12)
                            || (this.Date_Time.Year < 1920 || this.Date_Time.Year > 2100) )
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
        private RelayCommand _AddCostCommand;
        public RelayCommand AddCostCommand
        {
            get
            {
                return _AddCostCommand = _AddCostCommand ??
                    new RelayCommand(OnAddCommand, ()=> true);
            }
        }

        private RelayCommand _CloseWindowCommand;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return _CloseWindowCommand = _CloseWindowCommand ??
                    new RelayCommand(() => (_MainCodeBehind as AddWindow).Close(), () => true);
            }
        }
        #endregion Commands 

        #region Commands Parameters
        private void OnAddCommand()
        {
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

            CurrentCollection.Add(newCost);
            MessageBox.Show($"Добавление прошло успешно");
        }

        #endregion Commands Parameters
    }
}
