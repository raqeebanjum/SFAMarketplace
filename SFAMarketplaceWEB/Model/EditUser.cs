using System.ComponentModel.DataAnnotations;

public class EditUserModel
{
    public int? UserId { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress]
    public string Email { get; set; }

    public string ProfilePictureURL { get; set; }
}
