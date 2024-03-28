using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public NewUserModel NewUser { get; set; } // Define NewUser here

        public class NewUserModel
        {
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Create a database connection
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());

                // Create a SQL command. Add `Phone` and `LastLoginTime` to the insert statement.
                string cmdText = "INSERT INTO Users (FirstName, LastName, Email, PasswordHash, LastLoginTime) " +
                                 "VALUES (@firstName, @lastName, @email, @PasswordHash, @LastLoginTime)";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewUser.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewUser.LastName);
                cmd.Parameters.AddWithValue("@email", NewUser.Email);
                cmd.Parameters.AddWithValue("@PasswordHash", SecurityHelper.GeneratePasswordHash(NewUser.Password));
                cmd.Parameters.AddWithValue("@LastLoginTime", DateTime.Now);

                // Open the database
                conn.Open();
                // Execute the SQL command
                cmd.ExecuteNonQuery();
                // Close the database
                conn.Close();

                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }


    }


}
