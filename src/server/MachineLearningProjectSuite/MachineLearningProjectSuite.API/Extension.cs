using Autofac;
using MachineLearningProjectSuite.Application.Utility.Seeder;
using MachineLearningProjectSuite.Persistence.Database;

namespace MachineLearningProjectSuite.API
{
    public static class Extension
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var lifeTimeScope = scope.ServiceProvider.GetService<ILifetimeScope>();
            var propertySeeder = lifeTimeScope?.Resolve<IPropertyDataSeeder>();
            using var dbContext = lifeTimeScope?.Resolve<ApplicationDbContext>();
            try
            {
                dbContext?.Database.EnsureCreated();
                var properties = propertySeeder?.GetData();
                if (properties is { Count: > 0 })
                {
                    dbContext?.PropertyListings.AddRange(properties);
                    dbContext?.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine(ex.Message);
            }
            return app;
        }
    }
}
