using System.ComponentModel.DataAnnotations;

namespace DebtPortal.ViewModels
{
    public class UpdateEmailViewModel
    {
        [Required(ErrorMessage = "The Email is a mandatory field.")]
        [EmailAddress(ErrorMessage = "The Email must be a valid email address.")]
        public string? Email { get; set; }
    }
}