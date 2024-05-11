using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Models;

namespace SFAMarketplaceWEB.Pages.Account.AdminPage
{
    [Authorize(Policy = "Admin")] // Authorizes only users with "Admin" policy
    public class AddAccountModel : PageModel // Represents the Add Account page model
    {
        [BindProperty]
        public User NewUser { get; set; } // Property for binding user data from the form

        // Handles HTTP POST requests
        public ActionResult OnPost()
        {
            // Checks if model state is valid
            if (ModelState.IsValid)
            {
                // Checks if username and email do not already exist
                if (UsernameDoesNotExist(NewUser.Username) && EmailDoesNotExist(NewUser.Email))
                {
                    AddUser(); // Adds the new user to the database
                    return RedirectToPage("ManageUsers"); // Redirects to ManageUsers page
                }
                else
                {
                    // Adds error message if username or email already exists
                    if (!UsernameDoesNotExist(NewUser.Username))
                    {
                        ModelState.AddModelError("RegisterError", "This username is already taken.");
                    }
                    if (!EmailDoesNotExist(NewUser.Email))
                    {
                        ModelState.AddModelError("RegisterError", "This email is already taken.");
                    }
                    return Page(); // Returns the current page with validation errors
                }
            }
            else
            {
                return Page(); // Returns the current page with validation errors
            }
        }

        // Method to add a new user to the database
        private void AddUser()
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                conn.Open(); // Opens database connection

                string cmdText = @"
                    INSERT INTO Users (FirstName, LastName, Username, Email, PasswordHash, Role, LastLoginTime) 
                    VALUES (@FirstName, @LastName, @Username, @Email, @PasswordHash, @Role, @LastLoginTime)";

                // Executes SQL command to insert new user data into Users table
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", NewUser.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", NewUser.LastName);
                    cmd.Parameters.AddWithValue("@Username", NewUser.Username);
                    cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                    cmd.Parameters.AddWithValue("@PasswordHash", SecurityHelper.GeneratePasswordHash(NewUser.Password));
                    int roleId = NewUser.Email.EndsWith("@admin.com") ? 1 : 2;
                    cmd.Parameters.AddWithValue("@Role", roleId);
                    cmd.Parameters.AddWithValue("@LastLoginTime", DateTime.Now);
                    cmd.ExecuteNonQuery(); // Executes the SQL command
                }
            }
        }

        // Method to check if username does not exist in the database
        private bool UsernameDoesNotExist(string username)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Users WHERE Username = @Username";
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return !reader.HasRows; // Returns true if username does not exist
                    }
                }
            }
        }

        // Method to check if email does not exist in the database
        private bool EmailDoesNotExist(string email)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Users WHERE Email = @Email";
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return !reader.HasRows; // Returns true if email does not exist
                    }
                }
            }
        }
    }
}