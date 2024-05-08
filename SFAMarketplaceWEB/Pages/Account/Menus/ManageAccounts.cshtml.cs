using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using SFAMarketplaceWEB.Models;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
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
                ORDER BY NEWID()";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User
                    {

                        UserId = reader.IsDBNull(reader.GetOrdinal("UserId")) ? 0 : reader.GetInt32(reader.GetOrdinal("UserId")),
                        FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                        LastName = reader.GetString(reader.GetOrdinal("LastName")),
                        Username = reader.GetString(reader.GetOrdinal("username")),
                        Email = reader.GetString(reader.GetOrdinal("email")),
                        Role = reader.GetInt32(reader.GetOrdinal("Role")),
                        Password = reader.GetString(reader.GetOrdinal("PasswordHash")),
                    };
                    if (user.Role != 1) 
                    {
                        users.Add(user);
                    }
                }
            }
        }
    }

}