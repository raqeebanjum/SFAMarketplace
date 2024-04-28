using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Security.Claims;
using Microsoft.Data.SqlClient;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    public class AddReviewModel : PageModel
    {
        [BindProperty]
        public Review NewReview { get; set; } = new Review();

        public string SellerName { get; set; }

        public void OnGet(int sellerId)
        {
            NewReview.SellerID = sellerId; // Assign the SellerID from the query string
            SellerName = GetSellerName(sellerId); // Fetch the seller's name to display on the page
        }

        public IActionResult OnPost()
        {
            // Fetch the seller's name again in case the page needs to be re-rendered
            SellerName = GetSellerName(NewReview.SellerID);

            if (!ModelState.IsValid)
            {
                // If validation fails, the page is returned, make sure to reload any necessary data
                return Page();
            }

            // Save the new review to the database
            SaveReviewToDatabase(NewReview);

            // Redirect to the ViewReviews page for the seller after posting the review
            return RedirectToPage("/Account/Menus/ViewReview", new { sellerId = NewReview.SellerID });
        }

        private string GetSellerName(int sellerId)
        {
            using (var connection = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string query = "SELECT Username FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", sellerId);
                connection.Open();
                var result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Unknown Seller";
            }
        }

        private void SaveReviewToDatabase(Review review)
        {
            using (var connection = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string query = "INSERT INTO Reviews (SellerID, BuyerID, Rating, Comment, TransactionDate) VALUES (@SellerID, @BuyerID, @Rating, @Comment, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SellerID", review.SellerID);
                cmd.Parameters.AddWithValue("@BuyerID", int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                cmd.Parameters.AddWithValue("@Rating", review.Rating);
                cmd.Parameters.AddWithValue("@Comment", review.Comment);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
