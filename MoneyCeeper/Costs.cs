namespace MoneyCeeper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Costs
    {
        [Key]
        public int Cost_Id { get; set; }

        public DateTime Date_time { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoty { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [StringLength(150)]
        public string Comment { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(40)]
        public string User_name { get; set; }

        public virtual Users Users { get; set; }
    }
}
