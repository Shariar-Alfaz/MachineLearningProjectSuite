namespace MachineLearningProjectSuite.Application.Utility.Request
{
    public interface IHttpRequest : IDisposable
    {
        Task<TResponse?> GetAsync<TResponse>(string url);
        Task<TResponse?> GetAsync<TRequest, TResponse>(string url, TRequest data);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data);
    }
}
