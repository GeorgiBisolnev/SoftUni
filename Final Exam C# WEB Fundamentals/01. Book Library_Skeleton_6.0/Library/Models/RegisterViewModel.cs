using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.AppUserConst;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required, StringLength(UserNameMax, MinimumLength = UserNameMin)]
        public string UserName { get; set; } = null!;

        [Required,EmailAddress]
        [StringLength(EmailMax, MinimumLength = EmailMin)]
        public string Email { get; set; } = null!;

        [Required, StringLength(PasswordMax, MinimumLength = PasswordMin)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
