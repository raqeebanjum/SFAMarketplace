using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Model
{
    public class UserProfile
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }

       
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DateTime LastLoginTime { get; set; }
    }
}
