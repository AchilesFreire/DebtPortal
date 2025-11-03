namespace DebtPortal.Models
{
    public class AccountDto
    {
        public string? AccountId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
