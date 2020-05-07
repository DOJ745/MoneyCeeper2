using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class User : ViewModelBase
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public ICollection<Cost> User_Costs { get; set; }

        public User()
        {
            User_Costs = new List<Cost>();
        }
    }
}
