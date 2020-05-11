using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MoneyCeeper.Model;
using MoneyCeeper.Windows;

namespace MoneyCeeper.ViewModels
{
    class AddWindowVM
    {
        private IMainWindowsCodeBehind _MainCodeBehind;
        public User CurrentUser;

        //ctor
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

        #region Properties
        public float Price { get; set; }
        public DateTime Date_Time { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public int Category_Type { get; set; }
        public string Username { get; set; }
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
            MessageBox.Show($"currentUser Login: - {CurrentUser.Login}");
            Cost newCost = new Cost();

            newCost.Price = Price;
            newCost.Date_Time = Date_Time;
            newCost.Description = Description;
            newCost.Comment = Comment;
            newCost.Category = Category_Type;
            newCost.Username = CurrentUser.Login;

            newCost.User = CurrentUser;

            using (MainModel context = new MainModel())
            {
                context.Cost.Add(newCost);
                context.SaveChanges();
            }
        }

        private bool CanAddCommand()
        {
            return true;
        }
        #endregion Commands Parameters
    }
}
