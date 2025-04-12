using Autofac;
using MachineLearningProjectSuite.Application.Feature.Service;
using MachineLearningProjectSuite.Application.Utility.Request;
using MachineLearningProjectSuite.Application.Utility.Response;
using MachineLearningProjectSuite.Infrastructure.Feature.Service.Property;
using MachineLearningProjectSuite.Infrastructure.Utility.Request;
using MachineLearningProjectSuite.Infrastructure.Utility.Response;

namespace MachineLearningProjectSuite.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register your infrastructure services here
            // For example:
            // builder.RegisterType<YourService>().As<IYourService>().InstancePerLifetimeScope();

            builder.RegisterType<ResponseModelHandler>()
                .As<IResponseModelHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestFilter>()
                .As<IRequestFilter>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PropertyListingService>()
                .As<IPropertyListingService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
