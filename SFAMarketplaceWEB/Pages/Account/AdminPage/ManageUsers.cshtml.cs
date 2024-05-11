using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using SFAMarketplaceWEB.Models;

namespace SFAMarketplaceWEB.Pages.Account.AdminPage
{
    [Authorize (Policy="Admin")]
    [BindProperties]
    public class ManageAccountsModel : PageModel
    {
        private readonly ILogger<ManageAccountsModel> _logger;
        public List<User> users { get; set; } = new List<User>();

        public ManageAccountsModel(ILogger<ManageAccountsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PopulateUser();
        }

        private void PopulateUser()
        {
            users.Clear(); 

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
                SELECT UserId, FirstName, LastName, Username, Email, Role, PasswordHash
                FROM Users
                ORDER BY UserId";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User
                    {
                        UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                        FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                        LastName = reader.GetString(reader.GetOrdinal("LastName")),
                        Username = reader.GetString(reader.GetOrdinal("Username")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Role = reader.GetInt32(reader.GetOrdinal("Role")),
                        Password = reader.GetString(reader.GetOrdinal("PasswordHash")),
                    };

                    if (user.Username != "Johnny")
                    {
                        users.Add(user);
                    }
                }
            }
        }

        public IActionResult OnPostDelete(int userId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Users WHERE UserId = @UserId";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToPage();
        }


    }

}