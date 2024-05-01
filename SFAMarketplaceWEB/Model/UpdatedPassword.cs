using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Model
{
    public class UpdatedPassword
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Current Password is required.")]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "New Password is required.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm Password is required.")]
        public string ConfirmPassword { get; set; }
    }
}
