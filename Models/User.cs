using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class User : ViewModelBase
    {
        [Key]
        [MaxLength(32)]
        public string Login { get; set; }

        [Required]
        [MaxLength(16)]
        public string Password { get; set; }

        public ICollection<Cost> User_Costs { get; set; }

        public User()
        {
            User_Costs = new List<Cost>();
        }
    }
}
