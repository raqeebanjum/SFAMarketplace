using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using SFAMarketplaceWEB.Models;
using System.Data;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class EditAccountModel : PageModel
    {
        public User User { get; set; } = new User();


        public void OnGet(int id)
        {
            PopulateUser(id);
        }

        public IActionResult OnPost(int id)
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
                        Email = @Email,
                        PasswordHash = @PasswordHash
                    WHERE UserId = @userId";

                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", User.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", User.LastName);
                        cmd.Parameters.AddWithValue("@Username", User.Username);
                        cmd.Parameters.AddWithValue("@Email", User.Email);
                        cmd.Parameters.AddWithValue("@PasswordHash", SecurityHelper.GeneratePasswordHash(User.Password));
                        cmd.Parameters.AddWithValue("@userId", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToPage("/Account/Menus/ManageAccounts");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPostDelete(int userId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Users WHERE UserId = @userId";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToPage("/Account/Menus/ManageAccounts");
        }

        private void PopulateUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
            SELECT UserId, FirstName, LastName, Username, Email, PasswordHash
            FROM Users 
            WHERE UserId=@userId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@userId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    User.UserId = id;
                    User.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    User.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    User.Username = reader.GetString(reader.GetOrdinal("Username"));
                    User.Email = reader.GetString(reader.GetOrdinal("Email"));
                    User.Password = reader.GetString(reader.GetOrdinal("PasswordHash"));
                    

                }
            }
        }
    }
}
