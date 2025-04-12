using Autofac;
using MachineLearningProjectSuite.Application.Feature.Repository.Property;
using MachineLearningProjectSuite.Application.Utility.Seeder;
using MachineLearningProjectSuite.Persistence.Database;
using MachineLearningProjectSuite.Persistence.Database.Base;
using MachineLearningProjectSuite.Persistence.Utility.Seeder;

namespace MachineLearningProjectSuite.Persistence
{
    public class PersistenceModule(string connectionString, string migrationAssembly) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register the ApplicationDbContext with a connection string and assembly name
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<PropertyDataSeeder>().As<IPropertyDataSeeder>()
                .InstancePerLifetimeScope();
            builder.RegisterType<IPropertyListingRepository>().As<IPropertyListingRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
