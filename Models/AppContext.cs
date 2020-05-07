using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MoneyCeeper
{
    class AppContext : DbContext
    {
        public AppContext()
            : base("DefaultConnection")
        {

        }

        public virtual DbSet<Cost> CostsSet { get; set; }
        public virtual DbSet<User> UsersSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }
}
