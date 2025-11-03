using DebtPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace DebtPortal.ViewModels
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "The AddressLine1 is a mandatory field.")]
        public string? AddressLine1 { get; set; }

        [Required(ErrorMessage = "The AddressLine2 is a mandatory field.")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "The City is a mandatory field.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "The PostCode is a mandatory field.")]
        public string? PostCode { get; set; }

        [Required(ErrorMessage = "The Country is a mandatory field.")]
        public string? Country { get; set; }

        static public AddressViewModel FromDto(AddressDto dto)
        {
            return new AddressViewModel
            {
                AddressLine1 = dto.AddressLine1,
                AddressLine2 = dto.AddressLine2,
                City = dto.City,
                PostCode = dto.PostCode,
                Country = dto.Country
            };
        }
    }
}
