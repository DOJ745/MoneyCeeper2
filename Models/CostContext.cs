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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
