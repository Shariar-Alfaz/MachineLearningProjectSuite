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

        public async Task<(IList<PropertyListing> propertyListings, int totalCount)> GetPropertyListingsAsync(
            int? beds = null,
            int? bath = null,
            double? area = null,
            int? addressValue = null,
            int? typeValue = null,
            int pageNumber = 1,
            int pageSize = 50)
        {
            Dictionary<string, object> parameters = new()
            {
                { "@Beds", beds },
                { "@Bath", bath },
                { "@Area", area },
                { "@AddressValue", addressValue },
                { "@TypeValue", typeValue },
                { "@Skip", pageNumber },
                { "@PageSize", pageSize }
            };

            Dictionary<string, Type> outParams = new()
            {
                {"@Total", typeof(int) }
            };

            var data = await QueryWithStoredProcedureAsync<PropertyListing>("Proc_GetPagedProperty", parameters, outParams);

            return (data.result, (int)data.outValues["@Total"]);
        }

        public async Task<IList<TypeDto>> GetTypesAsync()
        {
            var data = await QueryWithStoredProcedureAsync<TypeDto>("Proc_GetPropertyType");
            return data.result;
        }
    }
}
