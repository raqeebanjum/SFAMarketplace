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

                        conn.Open();
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
