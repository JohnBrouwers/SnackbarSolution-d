using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Snackbar.MVC.Services
{
    public class ApiService<T> : IApiService<T>
    {
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions jsonOptions;

        public ApiService(IHttpClientFactory factory)
        {
            httpClient = factory.CreateClient("SnacksApi");
            jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<bool> AddAsync(T entity, string controller)
        {
            var response = await httpClient.Post(controller, entity);
            return response.IsSuccessStatusCode;            
        }

        public async Task<bool> DeleteAsync(int id, string controller)
        {
            var response = await httpClient.Delete(controller, id.ToString());
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<T>> GetAsync(string controller)
        {
            var response = await httpClient.Get(controller);
            if (response.IsSuccessStatusCode) 
                return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(await response.Content.ReadAsStreamAsync(), jsonOptions); 
            return new List<T>();
        }

        public async Task<T> GetAsync(int id, string controller)
        {
            var response = await httpClient.Get(controller, id.ToString());
            if (response.IsSuccessStatusCode) 
                return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), jsonOptions);
            return default(T);
        }

        public async Task<bool> UpdateAsync(int id, T entity, string controller)
        {
            var response = await httpClient.Put(controller, id.ToString(), entity);
            return response.IsSuccessStatusCode;            
        }
    }
}
