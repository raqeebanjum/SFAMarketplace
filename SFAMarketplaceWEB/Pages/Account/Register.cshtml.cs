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

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();

                    bool hasError = false;

                    // Check if the username already exists
                    var checkUsernameCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @Username", conn);
                    checkUsernameCmd.Parameters.AddWithValue("@Username", NewUser.Username);

                    int usernameExists = (int)checkUsernameCmd.ExecuteScalar();
                    if (usernameExists > 0)
                    {
                        ModelState.AddModelError("NewUser.Username", "Username already taken.");
                        hasError = true;
                    }

                    // Check if the email already exists
                    var checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", conn);
                    checkEmailCmd.Parameters.AddWithValue("@Email", NewUser.Email);

                    int emailExists = (int)checkEmailCmd.ExecuteScalar();
                    if (emailExists > 0)
                    {
                        ModelState.AddModelError("NewUser.Email", "Email already taken.");
                        hasError = true;
                    }

                    if (hasError)
                    {
                        return Page();
                    }

                    // If username and email are unique, proceed to insert new user
                    string cmdText = @"
                    INSERT INTO Users (FirstName, LastName, Username, Email, PasswordHash, Role, LastLoginTime) 
                    VALUES (@FirstName, @LastName, @Username, @Email, @PasswordHash, @Role, @LastLoginTime)";

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

                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }







    }
}
