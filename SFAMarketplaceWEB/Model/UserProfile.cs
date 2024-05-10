using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Model
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Last Login Time")]
        public DateTime LastLoginTime { get; set; }

        public string ProfilePictureURL { get; set; } 
    }
}
