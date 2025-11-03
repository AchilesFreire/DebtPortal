using System.ComponentModel.DataAnnotations;

namespace DebtPortal.ViewModels
{
    public class UpdateEmailViewModel
    {
        public string? Email { get; set; }

        public string? EmailConfirmation { get; set; }

        public string? Password { get; set; }

        public bool ConfirmEmailChange { get; set; }


    }
}