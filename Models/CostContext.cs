using System.Data.Entity;

namespace MoneyCeeper
{
    class CostContext : DbContext
    {
        public CostContext()
            : base("DefaultConnection")
        {

        }

        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
