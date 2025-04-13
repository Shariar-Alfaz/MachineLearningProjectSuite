using MachineLearningProjectSuite.Application.Dto.Property;
using MachineLearningProjectSuite.Application.Dto.Response;
using MachineLearningProjectSuite.Domain.Entities.Property;

namespace MachineLearningProjectSuite.Application.Feature.Service
{
    public interface IPropertyListingService
    {
        public Task<ResponseModel<AddressDto>> GetAddressAsync();
        public Task<ResponseModel<TypeDto>> GetTypesAsync();
        public Task<ResponseModel<InitRequestModel>> GetInitialDataAsync();
        public Task<ResponseModel<PropertyListing>> GetPagedAsync();
        public Task<ResponseModel<double>> PredictRentAsync(PropertyPredictModel data);
    }
}
