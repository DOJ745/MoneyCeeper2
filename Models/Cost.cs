using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MoneyCeeper
{
    class Cost : ViewModelBase
    {
        #region Fields
        [Key]
        public int Cost_Id { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [MaxLength(300)]
        public string Comment { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime? Date_Time { get; set; }

        [Required]
        public Category Category_Type { get; set; }

        public string Username { get; set; }

        public User User { get; set; }
        #endregion
    }
}
