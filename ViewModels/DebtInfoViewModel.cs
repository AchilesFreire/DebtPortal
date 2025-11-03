using DebtPortal.Models;

namespace DebtPortal.ViewModels
{
    public class DebtInfoViewModel
    {
        public string? OriginalCreditor { get; set; }
        public string? DebtReference { get; set; }
        public double? OriginalBalance { get; set; }
        public double CurrentBalance { get; set; }
        public double InterestRate { get; set; }
        public DateTime DateIncurred { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public string? Status { get; set; }
        public string? Currency { get; set; }

        static public DebtInfoViewModel FromDto(DebtInfoDto dto)
        {
            return new DebtInfoViewModel
            {
                OriginalCreditor = dto.OriginalCreditor,
                DebtReference = dto.DebtReference,
                OriginalBalance = dto.OriginalBalance,
                CurrentBalance = dto.CurrentBalance,
                InterestRate = dto.InterestRate,
                DateIncurred = dto.DateIncurred,
                LastPaymentDate = dto.LastPaymentDate,
                Status = dto.Status,
                Currency = dto.Currency
            };
        }
    }
}