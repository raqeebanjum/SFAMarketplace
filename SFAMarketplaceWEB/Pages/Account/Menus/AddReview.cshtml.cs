using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class AddReviewModel : PageModel
    {
        public Review NewReview { get; set; } = new Review();
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                SaveReviewDetails();
                return RedirectToPage("PostedItems");
            }
            else
            {
                return Page();
            }



        }
        private void SaveReviewDetails()
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
                INSERT INTO Review (SellerID, BuyerID, Rating, Comment, TransactionDate)
                VALUES (@SellerID, @BuyerID, @Rating, @Comment, @TransactionDate)";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                    cmd.Parameters.AddWithValue("@BuyerID", userId);
                    cmd.Parameters.AddWithValue("@SellerID", NewReview.SellerID);
                    cmd.Parameters.AddWithValue("@Rating", NewReview.Rating);
                    cmd.Parameters.AddWithValue("@Comment", NewReview.Comment);
                    cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Today); 

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
