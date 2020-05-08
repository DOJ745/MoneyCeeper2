namespace MoneyCeeper
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewModel : DbContext
    {
        public NewModel()
            : base("name=NewModel")
        {
        }

        public virtual DbSet<Costs> Costs { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Costs>()
                .Property(e => e.Price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Costs)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.User_name)
                .WillCascadeOnDelete(false);
        }
    }
}
