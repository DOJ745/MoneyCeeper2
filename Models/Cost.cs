﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class Cost : ViewModelBase
    {
        #region Fields
        public int Cost_Id { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public DateTime? Date_Time { get; set; }
        public Category Category_Type { get; set; }

        public string Username { get; set; }

        public User User { get; set; }
        #endregion
    }
}
