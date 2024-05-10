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
                if (ValidateCredentials() && LoginUser.Username == "johnny") 
                {
                    return RedirectToPage("/Account/AdminPage/ManageUsers");
                }
                else if (ValidateCredentials() )
                {
                    return RedirectToPage("/Account/Menus/PostedItems");
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
        string cmdText = "SELECT PasswordHash, UserID, FirstName, Email, LastLoginTime FROM Users WHERE Username=@username";
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
                    UpdateLastLoginTime(userID);

                    string name = reader.GetString(2);
                    string email = reader.GetString(3);
                    
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, userID.ToString()),
                        new Claim(ClaimTypes.Email, email),
                        new Claim(ClaimTypes.Name, name)
                    };
                    
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
