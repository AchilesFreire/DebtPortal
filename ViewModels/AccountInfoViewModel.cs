using DebtPortal.Models;

namespace DebtPortal.ViewModels
{
    public class AccountInfoViewModel
    {
        public string? Id { get; set; }
        public string? AccountId { get; set; }
        public DebtorInfViewModel? DebtorInfo { get; set; }
        public DebtInfoViewModel? DebtInfo { get; set; }

        public int DaysOverDue => 
            DebtInfo != null 
                && DebtInfo.LastPaymentDate != null 
                ? (DateTime.Now - DebtInfo.LastPaymentDate).Days 
                : 0;

        public int OverDuePayments => 
            DaysOverDue > 30 ? (DaysOverDue - 1) / 30 + 1 : 0;

        public int ContactAttmpts => DaysOverDue; //One attempt per day ( yes, it's anoying ! )

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
