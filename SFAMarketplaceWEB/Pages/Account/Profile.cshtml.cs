using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SFAMarketplaceWEB.Model;

namespace SFAMarketplaceWEB.Pages.Account
{
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
            profile.FirstName = "John";
            profile.LastName = "Doe";
            profile.Email = "johndoe@gmail.com";
            profile.LastLoginTime = DateTime.Now;
        }
    }
}
