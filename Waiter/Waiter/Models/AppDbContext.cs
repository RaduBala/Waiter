using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Waiter.Models
{
    class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        private string dbContextConnectionString;

        public AppDbContext(string connectionString)
        {
            dbContextConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={dbContextConnectionString}");
        }
    }
}
