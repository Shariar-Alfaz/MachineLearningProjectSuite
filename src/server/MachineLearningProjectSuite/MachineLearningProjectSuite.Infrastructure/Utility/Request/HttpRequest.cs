using System.Text;
using MachineLearningProjectSuite.Application.Utility.Request;
using Newtonsoft.Json;

namespace MachineLearningProjectSuite.Infrastructure.Utility.Request
{
    public class HttpRequest : IHttpRequest
    {
        private readonly HttpClient _httpClient;
        public HttpRequest(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MachineLearningProjectSuite");
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<TResponse?> GetAsync<TResponse>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return default;

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(content);
        }

        public async Task<TResponse?> GetAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.GetAsync(url + "?" + content);
            if (!response.IsSuccessStatusCode) return default;
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode) return default;

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}
