using DebtPortal.Models;

namespace DebtPortal.ViewModels
{
    public class AccountInfoViewModel
    {
        public string? Id { get; set; }
        public string? AccountId { get; set; }
        public DebtorInfViewModel? DebtorInfo { get; set; }
        public DebtInfoViewModel? DebtInfo { get; set; }

        static public AccountInfoViewModel FromDto(AccountInfoDto dto)
        {
            return new AccountInfoViewModel
            {
                Id = dto.Id,
                AccountId = dto.AccountId,
                DebtorInfo = dto.DebtorInfo != null ? DebtorInfViewModel.FromDto(dto.DebtorInfo) : null,
                DebtInfo = dto.DebtInfo != null ? DebtInfoViewModel.FromDto(dto.DebtInfo) : null
            };
        }   

    }
}
