using MachineLearningProjectSuite.Domain.Entities;
using MachineLearningProjectSuite.Persistence.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MachineLearningProjectSuite.Persistence.Database
{
    public class ApplicationDbContext(
        string connectionString,
        string migrationAssembly) : DbContext, IApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(connectionString, (x) => x.MigrationsAssembly(migrationAssembly))
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PropertyListing> PropertyListings { get; set; }
    }
}
