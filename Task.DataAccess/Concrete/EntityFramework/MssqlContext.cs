using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Entities.Concrete;

namespace Task.DataAccess.Concrete.EntityFramework
{
    public class MssqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=178.251.43.250,1433\\SQLEXPRESS;Database=TaskDB;User Id=sa;Password=Fidelio06;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }
        public DbSet<LogData> LogDatas { get; set; }
        public DbSet<Product> Products { get; set; }
        

    }
}
