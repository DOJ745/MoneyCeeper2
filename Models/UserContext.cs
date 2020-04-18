using System.Data.Entity;

namespace MoneyCeeper
{
    class UserContext : DbContext
    {
        public UserContext()
            : base("DefaultConnection")
        {

        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
