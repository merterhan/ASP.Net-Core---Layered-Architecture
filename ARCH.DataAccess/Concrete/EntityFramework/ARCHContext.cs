using ARCH.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ARCH.DataAccess.Concrete.EntityFramework
{
    public class ARCHContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=10.1.1.78;Initial Catalog=TESTCORE;User ID=TCDDFiberTitresim_User;Password=1qaz-2wsx.");
        }

        public DbSet<User> User { get; set; }
    }
}
