using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System;
using System.Security.Claims;
using Microsoft.Data.SqlClient;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]

    public class AddReviewModel : PageModel
    {
        public ReviewSubmission NewReview { get; set; } = new ReviewSubmission();

        public string SellerName { get; set; }

        public void OnGet(int sellerId)
        {
            NewReview.SellerID = sellerId; // Assign the SellerID from the query string
            SellerName = GetSellerName(sellerId); // Fetch the seller's name to display on the page
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                
                    SaveReviewToDatabase(NewReview);
                    return RedirectToPage("ViewReview", new { sellerId = NewReview.SellerID });
               
            }
            return Page();
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

                return result != null ? result.ToString() : "Unknown";
            }
        }

        private void SaveReviewToDatabase(ReviewSubmission review)
        {
            using (var connection = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                string query = "INSERT INTO Reviews (SellerID, BuyerID, Rating, Comment, TransactionDate) VALUES (@SellerID, @BuyerID, @Rating, @Comment, @TransactionDate)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SellerID", review.SellerID);
                cmd.Parameters.AddWithValue("@BuyerID", userId);
                cmd.Parameters.AddWithValue("@Rating", review.Rating);
                cmd.Parameters.AddWithValue("@Comment", review.Comment);
                cmd.Parameters.AddWithValue("@TransactionDate", review.TransactionDate);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
