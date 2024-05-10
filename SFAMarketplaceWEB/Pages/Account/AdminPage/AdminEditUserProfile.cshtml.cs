using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Models;
using System;

namespace SFAMarketplaceWEB.Pages.Account.AdminPage
{
    [Authorize(Policy = "Admin")]
    public class AdminEditUserProfileModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }

        public void OnGet(int id)
        {
            PopulateUserDetails(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
            UPDATE Users
            SET FirstName = @FirstName, LastName = @LastName, Username = @Username,
                Email = @Email, PasswordHash = @PasswordHash, ProfilePictureURL = @ProfilePictureURL
            WHERE UserId = @UserId";

                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@FirstName", User.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", User.LastName);
                    cmd.Parameters.AddWithValue("@Username", User.Username);
                    cmd.Parameters.AddWithValue("@Email", User.Email);
                    cmd.Parameters.AddWithValue("@PasswordHash", SecurityHelper.GeneratePasswordHash(User.Password));
                    cmd.Parameters.AddWithValue("@ProfilePictureURL", User.ProfilePictureURL ?? (object)DBNull.Value);  // Handle null URL
                    cmd.Parameters.AddWithValue("@UserId", User.UserId);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToPage("/Account/AdminPage/ManageUsers");
        }

        private void PopulateUserDetails(int userId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT UserId, FirstName, LastName, Username, Email, ProfilePictureURL FROM Users WHERE UserId = @UserId";
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User = new User
                            {
                                UserId = userId,
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                ProfilePictureURL = reader.IsDBNull(reader.GetOrdinal("ProfilePictureURL")) ? null : reader.GetString(reader.GetOrdinal("ProfilePictureURL"))
                            };
                        }
                    }
                }
            }
        }


    }
}
