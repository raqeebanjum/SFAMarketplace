using System;
using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@(jacks\.)?sfasu\.edu$", ErrorMessage = "Email must be a SFASU email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{10,}$",
            ErrorMessage = "Password must be at least 10 characters long, contain at least one digit, one lowercase and one uppercase letter.")]
        public string Password { get; set; }

        public int Role { get; set; }
    }
}
