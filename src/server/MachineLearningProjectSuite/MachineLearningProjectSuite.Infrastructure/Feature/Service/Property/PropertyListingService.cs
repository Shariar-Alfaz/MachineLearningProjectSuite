using MachineLearningProjectSuite.Application.ApplicationUnitOfWork;
using MachineLearningProjectSuite.Application.Dto.Property;
using MachineLearningProjectSuite.Application.Dto.Response;
using MachineLearningProjectSuite.Application.Feature.Service;
using MachineLearningProjectSuite.Application.Utility.Response;

namespace MachineLearningProjectSuite.Infrastructure.Feature.Service.Property
{
    public class PropertyListingService(
        IApplicationUnitOfWork unitOfWork,
        IResponseModelHandler modelHandler) : IPropertyListingService
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
    }
}
