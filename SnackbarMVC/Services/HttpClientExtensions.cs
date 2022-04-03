using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Snackbar.MVC.Services
{
    public static class HttpClientExtensions 
    {
        public static async Task<HttpResponseMessage> Get(this HttpClient httpClient, string controller, string id = default) 
        {
             return await httpClient.GetAsync(BuildUriPostfix(controller, id));
        }

        public static async Task<HttpResponseMessage> Post<T>(this HttpClient httpClient, string controller, T entity)
        {
                return await httpClient.PostAsJsonAsync(BuildUriPostfix(controller), entity);
        }

        public static async Task<HttpResponseMessage> Put<T>(this HttpClient httpClient, string controller, string id, T entity)
        {             
            return await httpClient.PutAsJsonAsync(BuildUriPostfix(controller, id), entity);
        }

        public static async Task<HttpResponseMessage> Delete(this HttpClient httpClient, string controller, string id)
        {            
            return await httpClient.DeleteAsync(BuildUriPostfix(controller, id));
        }

        private static string BuildUriPostfix(string controller, string id = default) {
            if (!string.IsNullOrWhiteSpace(controller) && !string.IsNullOrWhiteSpace(id))
                return $"{controller}/{id}";
            else if (!string.IsNullOrWhiteSpace(controller))
                return controller;
            else
                throw new InvalidOperationException($"{nameof(BuildUriPostfix)} encountered Null or WhiteSpace on {nameof(controller)} and {nameof(id)}");
        }
    }

}

