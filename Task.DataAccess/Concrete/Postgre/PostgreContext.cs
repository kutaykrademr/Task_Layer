using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities.Concrete;

namespace Task.DataAccess.Concrete.Postgre
{
    public class PostgreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TaskDB;Username=postgres;Password=13121312");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<LogData> LogDatas { get; set; }

    }
}
