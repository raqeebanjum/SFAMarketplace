using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using SFAMarketplaceWEB.Models;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = ValidateCredentials();
                if (user != null)
                {
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.Role == 0 ? "Admin" : "User")
            };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if (user.Role == 0)
                    {
                        return RedirectToPage("/Account/AdminPage/ManageUsers");
                    }
                    else
                    {
                        return RedirectToPage("/Account/Menus/PostedItems");
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid credentials. Try again.");
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }


        private User ValidateCredentials()
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT UserID, FirstName, Email, PasswordHash, Role FROM Users WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@username", LoginUser.Username);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string passwordHash = reader.GetString(3);
                    if (SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
                    {
                        return new User
                        {
                            UserId = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            Email = reader.GetString(2),
                            Role = reader.GetInt32(4)
                        };
                    }
                }
            }
            return null;
        }

        private void UpdateLastLoginTime(int userID)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE Users SET LastLoginTime = @lastLoginTime WHERE UserID = @userID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
