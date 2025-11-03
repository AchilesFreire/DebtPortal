namespace DebtPortal.Models
{
    public class UserDto
    {
        public string? AccountId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Postcode { get; set; }
    }
}
