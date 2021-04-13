using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DAL.Database
{
    public class DatabaseContext : DbContext
    {
        public const string connectionString = "Server=DESKTOP-P5PPV8L\\SQLEXPRESS;Database=HRManagement;Integrated Security=true;";
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        
        public DbSet<tblEmployees> tblEmployee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblEmployees>().Property(e => e.isManager).HasDefaultValue(false);
        }
    }

    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(DatabaseContext.connectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
