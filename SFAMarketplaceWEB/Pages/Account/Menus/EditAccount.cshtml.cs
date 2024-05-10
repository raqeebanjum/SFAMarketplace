using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Models;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class EditAccountModel : PageModel
    {
        public EditUserModel User { get; set; } = new EditUserModel();

        public void OnGet(int id)
        {
            PopulateUser(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = @"
                        UPDATE Users
                        SET FirstName = @FirstName,
                            LastName = @LastName,
                            Username = @Username,
                            Email = @Email
                        WHERE UserId = @UserId";

                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", User.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", User.LastName);
                        cmd.Parameters.AddWithValue("@Username", User.Username);
                        cmd.Parameters.AddWithValue("@Email", User.Email);
                        cmd.Parameters.AddWithValue("@UserId", User.UserId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToPage("ManageAccounts");
            }
            else
            {
                return Page();
            }
        }

        private void PopulateUser(int id)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT UserId, FirstName, LastName, Username, Email FROM Users WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@UserId", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User.UserId = reader.GetInt32(0);
                        User.FirstName = reader.GetString(1);
                        User.LastName = reader.GetString(2);
                        User.Username = reader.GetString(3);
                        User.Email = reader.GetString(4);
                    }
                }
            }
        }
    }
}
