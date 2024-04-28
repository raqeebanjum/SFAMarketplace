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
            if (ModelState.IsValid)
            {
                SaveReviewToDatabase(NewReview);
                // Pass the sellerId as a route value
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

                if (result != null)
                {
                    return result.ToString(); // Convert the result to string and return it
                }
                else
                {
                    return "Unknown"; // Return a default value if the query returns null
                }
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
