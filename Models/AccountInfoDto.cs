using System.Globalization;

namespace DebtPortal.Models
{
    public class AccountInfoDto
    {
        public string? Id { get; set; }
        public string? AccountId { get; set; }
        public DebtorInfoDto? DebtorInfo { get; set; }
        public DebtInfoDto? DebtInfo { get; set; }
    }
}
