using System;
using System.Collections.Generic;
using System.Text;
using ARCH.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ARCH.DataAccess.Concrete.EntityFramework
{
    public class MYSQLContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=89.163.242.38;Port=3306;Database=cagrierh_coredb;Uid=cagrierh_admin;Pwd=cagri123456;");
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}
