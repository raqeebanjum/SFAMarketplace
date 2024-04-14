using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
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
                if (ValidateCredentials())
                {
                    return RedirectToPage("Profile");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid credentials.Try Again.");

                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }


        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT PasswordHash, UserID, FirstName, Email, LastLoginTime, RoleName FROM Users " +
                    "INNER JOIN [Role] ON Users.RoleId = [Role].RoleID WHERE Username=@username";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@username", LoginUser.Username);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (reader.IsDBNull(0))
                    {
                        return false;
                    }
                    else
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
                        {
                            int userID = reader.GetInt32(1);
                            // Calling the method for updating login time here
                            UpdateLastLoginTime(userID);

                            string name = reader .GetString(2);
                            string email = reader.GetString (3);
                            string roleName = reader.GetString(5);

                            
                            Claim emailClaim = new Claim(ClaimTypes.Email, email);
                            Claim nameClaim = new Claim(ClaimTypes.Name, name);
                            Claim roleClaim = new Claim(ClaimTypes.Role, roleName);

                            List<Claim> claims = new List<Claim> { emailClaim, nameClaim, roleClaim };
                            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);




                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
        }

        private void UpdateLastLoginTime(int userID)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE Users SET LastLoginTime=@lastLoginTime WHERE UserID=@userID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
