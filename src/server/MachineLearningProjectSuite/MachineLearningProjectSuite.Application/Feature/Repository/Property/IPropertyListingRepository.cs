using MachineLearningProjectSuite.Domain.Entities;
using MachineLearningProjectSuite.Domain.Feature.Repository;

namespace MachineLearningProjectSuite.Application.Feature.Repository.Property
{
    public interface IPropertyListingRepository : IBaseRepository<PropertyListing, Guid>
    {
    }
}
