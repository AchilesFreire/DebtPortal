using DebtPortal.Models;

namespace DebtPortal.Services
{
    public interface IDebtCollectionApiClient
    {

        Task<(UserDto, ApiCallError) > LoginAsync(string email, string password);

        Task<(bool?, ApiCallError?)> RegisterUserAsync(UserDto userDto);

        Task<AccountInfoDto?> AccountInfoAsync(string accountId);

        Task<(bool?, ApiCallError?)> UpdateAddressAsync(string accountId, AddressDto updateContactDto);
        
        Task<(bool?, ApiCallError?)> UpdateEmailAsync(string accountId, UpdateEmailDto updateContactDto);
        
    }
}
