using MachineLearningProjectSuite.Application.Dto.Property;
using MachineLearningProjectSuite.Application.Feature.Repository.Property;
using MachineLearningProjectSuite.Domain.Entities.Property;
using MachineLearningProjectSuite.Persistence.Database.Base;
using MachineLearningProjectSuite.Persistence.Feature.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningProjectSuite.Persistence.Feature.Repository.Property
{
    public class PropertyListingRepository(IApplicationDbContext context)
        : BaseRepository<PropertyListing, Guid>((DbContext)context),
            IPropertyListingRepository
    {
        public async Task<IList<AddressDto>> GetAddressesAsync()
        {
            var data = await QueryWithStoredProcedureAsync<AddressDto>("Proc_GetAddressList");
            return data.result;
        }

        public async Task<IList<TypeDto>> GetTypesAsync()
        {
            var data = await QueryWithStoredProcedureAsync<TypeDto>("Proc_GetPropertyType");
            return data.result;
        }
    }
}
