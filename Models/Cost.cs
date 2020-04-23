using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class Cost : ViewModelBase
    {
        #region Private Fields
        private string description;
        private string comment;
        private DateTime date_time;
        private string category;
        private double price;
        #endregion

        #region Public Fields
        public int Cost_Id { get; set; }
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string User_Name { get; set; }
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                OnPropertyChanged("Comment");
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public DateTime Date_Time
        {
            get { return date_time; }
            set
            {
                date_time = value;
                OnPropertyChanged("Date_Time");
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }
#endregion
    }
}
