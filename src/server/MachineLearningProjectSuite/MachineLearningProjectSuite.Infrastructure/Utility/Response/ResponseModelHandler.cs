using MachineLearningProjectSuite.Application.Dto.Response;
using MachineLearningProjectSuite.Application.Utility.Response;

namespace MachineLearningProjectSuite.Infrastructure.Utility.Response
{
    public class ResponseModelHandler : IResponseModelHandler
    {
        public ResponseModel<T> Error<T>(string? message)
        {
            ResponseModel<T> responseModel = new()
            {
                IsSuccess = false,
                Message = message
            };
            return responseModel;
        }

        public ResponseModel<T> Success<T>(T data, string? message = null)
        {
            ResponseModel<T> responseModel = new()
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
            return responseModel;
        }

        public ResponseModel<T> Success<T>(IList<T> listData, string? message = null)
        {
            ResponseModel<T> responseModel = new()
            {
                IsSuccess = true,
                Message = message,
                ListData = listData
            };
            return responseModel;
        }

        public ResponseModel<T> Success<T>(IList<T> listData, int totalRecords, string? message = null)
        {
            ResponseModel<T> responseModel = new()
            {
                IsSuccess = true,
                Message = message,
                ListData = listData,
                TotalRecords = totalRecords
            };
            return responseModel;
        }
    }
}
