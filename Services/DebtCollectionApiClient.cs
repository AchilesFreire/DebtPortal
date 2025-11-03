using DebtPortal.InfraStructure;
using DebtPortal.Models;
using Newtonsoft.Json;

namespace DebtPortal.Services
{
    public class DebtCollectionApiClient : IDebtCollectionApiClient
    {
        private readonly IDebtStreamAPI _debtStreamAPI;

        public DebtCollectionApiClient(IDebtStreamAPI debtStreamAPI)
        {

            _debtStreamAPI = debtStreamAPI;
        }

        public async Task<(UserDto?, ApiCallError?)> LoginAsync(string email, string password)
        {
            var json = JsonConvert.SerializeObject(new { email, password });
            var response = await _debtStreamAPI.LoginAsync(json) ;
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var userDto = JsonConvert.DeserializeObject<UserDto>(jsonResponse);
                return (userDto,null);
            }
            else
            {                
                var apiCallError = JsonConvert.DeserializeObject<ApiCallError>(jsonResponse ?? "");
                return (null, apiCallError);
            }
        }

        public async Task<(bool?, ApiCallError?)> RegisterUserAsync(UserDto userDto)
        {
            var json = JsonConvert.SerializeObject(userDto);
            var response = await _debtStreamAPI.RegisterUserAsync(json);;
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                var apiCallError = JsonConvert.DeserializeObject<ApiCallError>(jsonResponse ?? "");
                return (false, apiCallError);
            }
        }

        public async Task<AccountInfoDto?> AccountInfoAsync(string accountId)
        {
            var response = await _debtStreamAPI.AccountInfoAsync(accountId);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AccountInfoDto>(jsonResponse);
            }
            return null;
        }

        public async Task<(bool?, ApiCallError?)> UpdateAddressAsync(string accountId, AddressDto updateContactDto)
        {
            var json = JsonConvert.SerializeObject(updateContactDto);
            var response = await _debtStreamAPI.UpdateAddressAsync(accountId, json);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                var apiCallError = JsonConvert.DeserializeObject<ApiCallError>(jsonResponse ?? "");
                return (false, apiCallError);
            }
        }
        public async Task<(bool?, ApiCallError?)> UpdateEmailAsync(string accountId, UpdateEmailDto updateContactDto)
        {
            var json = JsonConvert.SerializeObject(updateContactDto);
            var response = await _debtStreamAPI.UpdateEmailAsync(accountId, json);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return (true, null);
            }
            else
            {
                var apiCallError = JsonConvert.DeserializeObject<ApiCallError>(jsonResponse??"");
                return (false, apiCallError);
            }
        }
    }
}
