using MachineLearningProjectSuite.Application.Dto.Property;
using MachineLearningProjectSuite.Domain.Entities.Property;
using MachineLearningProjectSuite.Domain.Feature.Repository;

namespace MachineLearningProjectSuite.Application.Feature.Repository.Property
{
    public interface IPropertyListingRepository : IBaseRepository<PropertyListing, Guid>
    {
        public Task<IList<AddressDto>> GetAddressesAsync();
        public Task<IList<TypeDto>> GetTypesAsync();
    }
}
