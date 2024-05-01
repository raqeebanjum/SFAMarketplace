using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class EditProfileModel : PageModel
    {
        public UpdatedPassword updatedPassword {  get; set; }

       
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Retrieve the current password hash from the database
            string currentPasswordHash;
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
                SELECT PasswordHash FROM Users WHERE UserId = @userID";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    
                    cmd.Parameters.AddWithValue("@userID", userId);
                    conn.Open();

                    currentPasswordHash = (string)cmd.ExecuteScalar();
                }
            }

            // Verify the old password
            if (!SecurityHelper.VerifyPassword(updatedPassword.OldPassword, currentPasswordHash))
            {
                ModelState.AddModelError("UpdateError", "The old password is incorrect.");
                return Page();
            }

            // Check if old and new passwords are the same
            if (updatedPassword.OldPassword == updatedPassword.NewPassword)
            {
                ModelState.AddModelError("UpdateError", "New password cannot be the same as the old password.");
                return Page();
            }
            if (updatedPassword.NewPassword != updatedPassword.ConfirmPassword)
            {
                ModelState.AddModelError("UpdateError", "New password and confirmation password do not match.");
                return Page();
            }

            // Password strength validation
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            if (updatedPassword.NewPassword.Length < 10 ||
                !hasNumber.IsMatch(updatedPassword.NewPassword) ||
                !hasUpperChar.IsMatch(updatedPassword.NewPassword) ||
                !hasLowerChar.IsMatch(updatedPassword.NewPassword))
            {
                ModelState.AddModelError("UpdateError", "New Password must be at least 10 characters and include at least one number, and both upper and lower case letters.");
                return Page();
            }

            // Update the password in the database
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE Users SET PasswordHash = @passwordHash WHERE UserId = @userID";
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@passwordHash", SecurityHelper.GeneratePasswordHash(updatedPassword.NewPassword));
                    cmd.Parameters.AddWithValue("@userID", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToPage("/Account/Profile");
        }
    }
}




