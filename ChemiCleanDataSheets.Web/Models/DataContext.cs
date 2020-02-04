using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemiCleanDataSheets.Web.Models
{
    public class DataContext : DbContext
    {
        public DbSet<StoredDataSheet> StoredDataSheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True;");
            }
        }
    }
}
