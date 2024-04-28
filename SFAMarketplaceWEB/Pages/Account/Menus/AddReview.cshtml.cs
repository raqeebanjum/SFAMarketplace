using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SFAMarketplaceWEB.Model;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class AddReviewModel : PageModel
    {
        public Review NewReview { get; set; } = new Review();
        public void OnGet()
        {
            NewReview.BuyerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            // Initialize TransactionDate to today's date
            NewReview.TransactionDate = DateTime.Today;
        }
    }
}
