using System.ComponentModel.DataAnnotations;

namespace DebtPortal.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Email is a mandatory field.")]
        [EmailAddress(ErrorMessage = "The Email must be a valid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The Password is a mandatory field.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "The Password must be at least 6 characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
