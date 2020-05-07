using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class User : ViewModelBase
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
