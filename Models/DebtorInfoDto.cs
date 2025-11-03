using System.Net;

namespace DebtPortal.Models
{
    public class DebtorInfoDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public AddressDto? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
