using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_o8.Domain;


namespace myfinance_web_dotnet_o8.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your entities here
            // Example: optionsBuilder.Entity<YourEntity>().ToTable("YourTableName");
            var connectionString = @"Server=YANCRISSOUZA;Database=myfinance;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);

        }

        // Define DbSet properties for your entities
        // public DbSet<YourEntity> YourEntities { get; set; }
        
        // Add more DbSet properties as needed
        
    }
}