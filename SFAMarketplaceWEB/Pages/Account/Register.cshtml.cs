using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Models;
using System;
using System.Text.RegularExpressions;

namespace SFAMarketplaceWEB.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; }

        public ActionResult OnPost()
        {
            if (!IsValidEmailDomain(NewUser.Email))
            {
                ModelState.AddModelError("RegisterError", "Email must be a SFASU email.");
                return Page();
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (NewUser.Password != null)
            {
                if (NewUser.Password.Length < 10)
                {
                    ModelState.AddModelError("RegisterError", "Password must be at least 10 characters");
                    return Page();
                }
                if (!hasNumber.IsMatch(NewUser.Password))
                {
                    ModelState.AddModelError("RegisterError", "Password must include at least one number.");
                    return Page();
                }
                if (!hasUpperChar.IsMatch(NewUser.Password) || !hasLowerChar.IsMatch(NewUser.Password))
                {
                    ModelState.AddModelError("RegisterError", "Password must include both upper and lower case letters.");
                    return Page();
                }
            }

            if (ModelState.IsValid)
            {
                if (UsernameDoesNotExist(NewUser.Username) && EmailDoesNotExist(NewUser.Email))
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    if (!UsernameDoesNotExist(NewUser.Username))
                    {
                        ModelState.AddModelError("RegisterError", "This username is already taken.");
                    }
                    if (!EmailDoesNotExist(NewUser.Email))
                    {
                        ModelState.AddModelError("RegisterError", "This email is already taken.");
                    }
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
        private bool IsValidEmailDomain(string email)
        {
            return email.EndsWith("@jacks.sfasu.edu") || email.EndsWith("@sfasu.edu");
        }
        private void RegisterUser()
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                conn.Open();

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
        }

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
                        return !reader.HasRows;
                    }
                }
            }
        }

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
                        return !reader.HasRows;
                    }
                }
            }
        }
    }
}

