using Newtonsoft.Json;
using System.Text;

namespace DebtPortal.InfraStructure
{
    public class DebtStreamAPI : IDebtStreamAPI
    {
        private readonly HttpClient _httpClient;
        private const string ApiBaseUrl = "https://devtestapi.debtstream.co.uk/";
        private const string ApiKey = "PROD-API-KEY-12345";

        public DebtStreamAPI()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
        }

        public async Task<HttpResponseMessage> LoginAsync(string json) 
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("api/webuser/validate", content);
        }

        public async Task<HttpResponseMessage> RegisterUserAsync(string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("api/webuser/register", content);
        }

        public async Task<HttpResponseMessage> AccountInfoAsync(string accountId)
        {
            return await _httpClient.GetAsync($"api/account/{accountId}");
        }

        public async Task<HttpResponseMessage> UpdateAddressAsync(string accountId, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"api/account/{accountId}/address", content);
        }
        public async Task<HttpResponseMessage> UpdateEmailAsync(string accountId, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"api/account/{accountId}/email", content);

        }

    }
}
