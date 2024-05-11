using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace SFAMarketplaceWEB.Pages.Account.AdminPage
{
    [Authorize(Policy = "Admin")] // Authorizes only users with "Admin" policy
    [BindProperties]
    public class ManageAccountsModel : PageModel // Represents the Manage Accounts page model
    {
        private readonly ILogger<ManageAccountsModel> _logger; // Logger instance for logging
        public List<User> users { get; set; } = new List<User>(); // List to hold user data

        public ManageAccountsModel(ILogger<ManageAccountsModel> logger)
        {
            _logger = logger; // Initializes logger instance
        }

        // Handles HTTP GET requests
        public void OnGet()
        {
            PopulateUser(); // Populates user data on page load
        }

        // Method to populate user data
        private void PopulateUser()
        {
            users.Clear(); // Clears the list before repopulating it

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                // SQL query modified to exclude users with Role 0
                string cmdText = @"
        SELECT UserId, FirstName, LastName, Username, Email, Role, PasswordHash
        FROM Users
        WHERE Role <> 0
        ORDER BY UserId";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open(); // Opens database connection
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) // Reads each record from the result set
                {
                    var user = new User // Creates a new User object for each record
                    {
                        UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                        FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                        LastName = reader.GetString(reader.GetOrdinal("LastName")),
                        Username = reader.GetString(reader.GetOrdinal("Username")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Role = reader.GetInt32(reader.GetOrdinal("Role")),
                        Password = reader.GetString(reader.GetOrdinal("PasswordHash")),
                    };

                    users.Add(user); // Adds the user to the list
                }
            }
        }

        // Handles HTTP POST requests to delete a user
        public IActionResult OnPostDelete(int userId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Users WHERE UserId = @UserId"; // SQL command to delete user

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId); // Adds parameter for UserId
                    conn.Open(); // Opens database connection
                    cmd.ExecuteNonQuery(); // Executes the SQL command to delete the user
                }
            }

            return RedirectToPage(); // Redirects back to the same page after deletion
        }
    }
}
