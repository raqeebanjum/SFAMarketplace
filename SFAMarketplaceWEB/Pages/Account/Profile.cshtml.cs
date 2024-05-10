using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public UserProfile profile {  get; set; } = new UserProfile();
        public void OnGet()
        {
            PopulateProfile();
        }

        private void PopulateProfile()
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT UserId, FirstName, LastName, Username, Email, ProfilePictureURL, LastLoginTime FROM Users WHERE Email=@Email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    profile.FirstName = reader.GetString(1);
                    profile.LastName = reader.GetString(2);
                    profile.Username = reader.GetString(3);
                    profile.Email = email;
                    profile.ProfilePictureURL = reader.IsDBNull(5) ? "https://via.placeholder.com/200" : reader.GetString(5);
                    profile.LastLoginTime = reader.GetDateTime(6);
                }
            }
        }


    }
}
