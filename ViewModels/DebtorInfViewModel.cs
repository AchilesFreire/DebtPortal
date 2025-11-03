
using DebtPortal.Models;

namespace DebtPortal.ViewModels
{
    public class DebtorInfViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public AddressViewModel? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        static public DebtorInfViewModel FromDto(DebtorInfoDto dto)
        {
            return new DebtorInfViewModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address != null ? AddressViewModel.FromDto(dto.Address) : null,
                Email = dto.Email,
                Phone = dto.Phone
            };
        }
    }
}