namespace DebtPortal.Models
{
    public class DebtInfoDto
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
    }
}
