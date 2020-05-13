using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MoneyCeeper.Model;
using MoneyCeeper.Windows;
using System.ComponentModel;
using MoneyCeeper.User_Controls;
using System.Collections.ObjectModel;

namespace MoneyCeeper.ViewModels
{
    class AddWindowVM : ViewModelBase, IDataErrorInfo
    {
        #region Constructors
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;
        public ObservableCollection<Cost> CurrentCollection { get; set; }

        public AddWindowVM(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }

        public AddWindowVM(IMainWindowsCodeBehind codeBehind, User currentUser)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
        }

        public AddWindowVM(IMainWindowsCodeBehind codeBehind, User currentUser, 
            ObservableCollection<Cost> currentCollection)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
            CurrentUser = currentUser;
            CurrentCollection = currentCollection;
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

            MessageBox.Show($"Current cost:" +
                $"\n Price - {newCost.Price}" +
                $"\n Date - {newCost.Date_Time}" +
                $"\n Description - {newCost.Description}" +
                $"\n Comment - {newCost.Comment}" +
                $"\n Category - {newCost.Category}" +
                $"\n Username - {newCost.Username}");

            using (MainModel context = new MainModel())
            {
                context.Cost.Add(newCost);
                context.SaveChanges();
            }

            CurrentCollection.Add(newCost);
        }

        #endregion Commands Parameters

    }
}
