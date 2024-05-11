using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Models;
using System;

namespace SFAMarketplaceWEB.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; }

        // Handler for HTTP POST requests
        public ActionResult OnPost()
        {
            // Validate user input
            if (ModelState.IsValid)
            {
                // Check if username and email do not exist in the database
                if (UsernameDoesNotExist(NewUser.Username) && EmailDoesNotExist(NewUser.Email))
                {
                    RegisterUser(); // Register the new user
                    return RedirectToPage("Login"); // Redirect to the login page after successful registration
                }
                else
                {
                    // Display error messages if username or email already exist
                    if (!UsernameDoesNotExist(NewUser.Username))
                    {
                        ModelState.AddModelError("RegisterError", "This username is already taken.");
                    }
                    if (!EmailDoesNotExist(NewUser.Email))
                    {
                        ModelState.AddModelError("RegisterError", "This email is already taken.");
                    }
                    return Page(); // Stay on the registration page
                }
            }
            else
            {
                return Page(); // Stay on the registration page if model state is invalid
            }
        }

        // Method to register a new user
        private void RegisterUser()
        {
            // Establish connection to the database
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                conn.Open();

                // SQL command to insert user data into the database
                string cmdText = @"
                    INSERT INTO Users (FirstName, LastName, Username, Email, PasswordHash, Role, LastLoginTime) 
                    VALUES (@FirstName, @LastName, @Username, @Email, @PasswordHash, @Role, @LastLoginTime)";

                // Execute the SQL command
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", NewUser.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", NewUser.LastName);
                    cmd.Parameters.AddWithValue("@Username", NewUser.Username);
                    cmd.Parameters.AddWithValue("@Email", NewUser.Email);
                    cmd.Parameters.AddWithValue("@PasswordHash", SecurityHelper.GeneratePasswordHash(NewUser.Password));
                    cmd.Parameters.AddWithValue("@Role", 1);
                    cmd.Parameters.AddWithValue("@LastLoginTime", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to check if a username already exists in the database
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
                        return !reader.HasRows; // Return true if username does not exist, false otherwise
                    }
                }
            }
        }

        // Method to check if an email already exists in the database
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
                        return !reader.HasRows; // Return true if email does not exist, false otherwise
                    }
                }
            }
        }
    }
}
