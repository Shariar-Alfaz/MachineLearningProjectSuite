using MachineLearningProjectSuite.Domain.Entities.Property;
using MachineLearningProjectSuite.Domain.Feature.Repository;

namespace MachineLearningProjectSuite.Application.Feature.Repository.Property
{
    public interface IPropertyListingRepository : IBaseRepository<PropertyListing, Guid>
    {
    }
}
