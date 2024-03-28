using System;
using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "The First Name field is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name field is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        public DateTime LastLoginTime { get; set; }
    }
}
