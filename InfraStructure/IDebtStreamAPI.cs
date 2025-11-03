
namespace DebtPortal.InfraStructure
{
    public interface IDebtStreamAPI
    {
        Task<HttpResponseMessage> AccountInfoAsync(string accountId);
        Task<HttpResponseMessage> LoginAsync(string json);
        Task<HttpResponseMessage> RegisterUserAsync(string json);
        Task<HttpResponseMessage> UpdateAddressAsync(string accountId, string json);
        Task<HttpResponseMessage> UpdateEmailAsync(string accountId, string json);
    }
}