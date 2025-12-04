using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Laboratorio193.Services
{
    public class ApiClient
    {
        private readonly HttpClient _http;

        public ApiClient(string baseUrl)
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetAsync(string relativeUrl)
        {
            var res = await _http.GetAsync(relativeUrl);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadAsStringAsync();
        }
    }
}