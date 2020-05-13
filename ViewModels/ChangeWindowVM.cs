using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public float Price { get; set; }
        public DateTime Date_Time { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public CategoryEnum Category_Type { get; set; }
        public string Username { get; set; }
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
                        /*if (!this.Comment.Contains(','))
                            result = "Разделяйте ключевые слова через запятую!";*/
                        if (Comment.Length > 300 || Comment.Length < 15)
                            result = "Диапазон символов: 15 - 300";
                        /*if (this.Comment == string.Empty)
                            result = "Комментарий не должен быть пустым!";*/
                        break;
                    case "Description":
                        if (this.Description.Length > 300)
                            result = "Максимальное колисество символов - 300";
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

        }
        #endregion
    }
}
