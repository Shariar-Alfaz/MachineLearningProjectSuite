using MachineLearningProjectSuite.Application.ApplicationUnitOfWork;
using MachineLearningProjectSuite.Application.Dto.Property;
using MachineLearningProjectSuite.Application.Dto.Response;
using MachineLearningProjectSuite.Application.Feature.Service;
using MachineLearningProjectSuite.Application.Utility.Request;
using MachineLearningProjectSuite.Application.Utility.Response;
using MachineLearningProjectSuite.Domain.Entities.Property;

namespace MachineLearningProjectSuite.Infrastructure.Feature.Service.Property
{
    public class PropertyListingService(
        IApplicationUnitOfWork unitOfWork,
        IResponseModelHandler modelHandler,
        IRequestFilter requestFilter,
        IHttpRequest httpRequest) : IPropertyListingService
    {
        public async Task<ResponseModel<AddressDto>> GetAddressAsync()
        {
            try
            {
                var data = await unitOfWork.PropertyListingRepository.GetAddressesAsync();
                return modelHandler.Success(data);
            }
            catch (Exception ex)
            {
                return modelHandler.Error<AddressDto>(ex.Message);
            }
        }

        public async Task<ResponseModel<InitRequestModel>> GetInitialDataAsync()
        {
            try
            {
                InitRequestModel model = new();
                model.Addresses = await unitOfWork.PropertyListingRepository.GetAddressesAsync();
                model.Types = await unitOfWork.PropertyListingRepository.GetTypesAsync();
                return modelHandler.Success(model);
            }
            catch (Exception ex)
            {
                return modelHandler.Error<InitRequestModel>(ex.Message);
            }

        }

        public async Task<ResponseModel<PropertyListing>> GetPagedAsync()
        {
            try
            {
                int? bed = int.TryParse(requestFilter.GetQueryData("bed"), out int bedData) ? bedData : null;
                int? bath = int.TryParse(requestFilter.GetQueryData("bath"), out int bathData) ? bathData : null;
                double? area = double.TryParse(requestFilter.GetQueryData("area"), out double areaData) ? areaData : null;
                int? addressValue = int.TryParse(requestFilter.GetQueryData("addressValue"), out int addressData) ? addressData : null;
                int? typeValue = int.TryParse(requestFilter.GetQueryData("typeValue"), out int typeData) ? typeData : null;
                var data = await unitOfWork.PropertyListingRepository.GetPropertyListingsAsync(
                        bed,
                        bath,
                        area,
                        addressValue,
                        typeValue,
                        requestFilter.Skip,
                        requestFilter.PageSize
                    );
                return modelHandler.Success(data.propertyListings, data.totalCount);
            }
            catch (Exception ex)
            {
                return modelHandler.Error<PropertyListing>(ex.Message);
            }
        }

        public async Task<ResponseModel<TypeDto>> GetTypesAsync()
        {
            try
            {
                var data = await unitOfWork.PropertyListingRepository.GetTypesAsync();
                return modelHandler.Success(data);
            }
            catch (Exception ex)
            {
                return modelHandler.Error<TypeDto>(ex.Message);
            }
        }

        public async Task<ResponseModel<double>> PredictRentAsync(PropertyPredictModel data)
        {
            try
            {
                var predictedData = await httpRequest.PostAsync<PropertyPredictModel, PropertyPredictResult>("http://127.0.0.1:5000/api/property-price", data);
                var price = Math.Ceiling(predictedData?.PredictedPrice ?? 0);
                return modelHandler.Success(price);
            }
            catch (Exception ex)
            {
                return modelHandler.Error<double>(ex.Message);
            }
        }
    }
}
