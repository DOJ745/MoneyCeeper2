namespace MoneyCeeper.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cost")]
    public partial class Cost
    {
        public int Id { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(300)]
        public string Comment { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public DateTime Date_Time { get; set; }

        public int Category { get; set; }

        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        public virtual User User { get; set; }
    }
}
