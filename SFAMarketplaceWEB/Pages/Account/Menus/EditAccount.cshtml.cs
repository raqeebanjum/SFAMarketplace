using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Models;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class EditAccountModel : PageModel
    {
        public EditUserModel UserEdit { get; set; } = new EditUserModel();

        public void OnGet()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                PopulateUser(int.Parse(userId));
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    UpdateUserDetails(int.Parse(userId));
                    return RedirectToPage("/Account/Profile");
                }
            }
            return Page();
        }

        private void UpdateUserDetails(int userId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
            UPDATE Users
            SET FirstName = @FirstName,
                LastName = @LastName,
                Username = @Username,
                Email = @Email,
                ProfilePictureURL = @ProfilePictureURL
            WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", UserEdit.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", UserEdit.LastName);
                    cmd.Parameters.AddWithValue("@Username", UserEdit.Username);
                    cmd.Parameters.AddWithValue("@Email", UserEdit.Email);
                    cmd.Parameters.AddWithValue("@ProfilePictureURL", UserEdit.ProfilePictureURL ?? (object)DBNull.Value); // Handle null
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private void PopulateUser(int userId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT UserId, FirstName, LastName, Username, Email, ProfilePictureURL FROM Users WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        UserEdit.UserId = reader.GetInt32(0);
                        UserEdit.FirstName = reader.GetString(1);
                        UserEdit.LastName = reader.GetString(2);
                        UserEdit.Username = reader.GetString(3);
                        UserEdit.Email = reader.GetString(4);
                        UserEdit.ProfilePictureURL = reader.IsDBNull(5) ? null : reader.GetString(5);
                    }
                }
            }
        }

    }
}
