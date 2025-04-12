using MachineLearningProjectSuite.Application.Dto.Property;
using MachineLearningProjectSuite.Application.Dto.Response;

namespace MachineLearningProjectSuite.Application.Feature.Service
{
    public interface IPropertyListingService
    {
        public Task<ResponseModel<AddressDto>> GetAddressAsync();
        public Task<ResponseModel<TypeDto>> GetTypesAsync();
        public Task<ResponseModel<InitRequestModel>> GetInitialDataAsync();
    }
}
