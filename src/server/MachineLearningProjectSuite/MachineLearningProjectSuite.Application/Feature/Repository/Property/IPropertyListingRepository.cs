using MachineLearningProjectSuite.Application.Dto.Property;
using MachineLearningProjectSuite.Domain.Entities.Property;
using MachineLearningProjectSuite.Domain.Feature.Repository;

namespace MachineLearningProjectSuite.Application.Feature.Repository.Property
{
    public interface IPropertyListingRepository : IBaseRepository<PropertyListing, Guid>
    {
        public Task<IList<AddressDto>> GetAddressesAsync();
        public Task<IList<TypeDto>> GetTypesAsync();
        public Task<(IList<PropertyListing> propertyListings, int totalCount)> GetPropertyListingsAsync(
            int? beds = null,
            int? bath = null,
            double? area = null,
            int? addressValue = null,
            int? typeValue = null,
            int pageNumber = 1,
            int pageSize = 50);
    }
}
