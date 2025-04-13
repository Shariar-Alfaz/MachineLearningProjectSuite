namespace MachineLearningProjectSuite.Application.Utility.Response
{
    public interface IResponseModelHandler
    {
        Dto.Response.ResponseModel<T> Error<T>(string? message);
        Dto.Response.ResponseModel<T> Success<T>(T data, string? message = null);
        Dto.Response.ResponseModel<T> Success<T>(IList<T> listData, string? message = null);
        Dto.Response.ResponseModel<T> Success<T>(IList<T> listData, int totalRecords, string? message = null);
    }
}
