using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;

namespace SFAMarketplaceWEB.Pages.Account
{
    public class LoginModel : PageModel
    {
        public Login LoginUser { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());
                string cmdText = "SELECT PasswordHash FROM Users WHERE Username=@username";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@username", LoginUser.Username);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
                        {
                            return RedirectToPage("Profile");
                        }
                        else
                        {
                            ModelState.AddModelError("Login Error", "Invalid credentials. Try Again.");
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Login Error", "Invalid credentials. Try Again.");
                        return Page();
                    }
                }
                else
                {
                    ModelState.AddModelError("Login Error", "Invalid credentials. Try Again.");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("Login Error", "Invalid credentials. Try Again.");
                return Page();
            }

        }
    }
}
