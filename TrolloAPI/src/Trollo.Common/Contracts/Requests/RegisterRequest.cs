using System.ComponentModel.DataAnnotations;

namespace Trollo.Common.Contracts.Requests
{
    public class RegisterRequest
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}