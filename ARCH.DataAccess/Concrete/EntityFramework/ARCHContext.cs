using ARCH.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ARCH.DataAccess.Concrete.EntityFramework
{
    public class ARCHContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"");
        }

        public DbSet<User> User { get; set; }
    }
}
