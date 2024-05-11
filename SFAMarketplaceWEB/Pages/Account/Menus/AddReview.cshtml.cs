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
    [Authorize] // Ensures only authorized users can access this page
    public class AddReviewModel : PageModel
    {
        [BindProperty]
        public ReviewSubmission NewReview { get; set; } = new ReviewSubmission(); // Binds form data to the NewReview model

        public string SellerName { get; set; } // Holds the seller's name to display on the page

        // Initializes page state with data needed on GET request
        public void OnGet(int sellerId)
        {
            NewReview.SellerID = sellerId; // Assign the SellerID from the query string
            SellerName = GetSellerName(sellerId); // Fetch the seller's name to display on the page
        }

        // Handles the POST request to submit a review
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SaveReviewToDatabase(NewReview); // Save review details to the database
                    return RedirectToPage("ViewReview", new { sellerId = NewReview.SellerID }); // Redirect to ViewReview page on successful save
                }
                catch (Exception ex)
                {
                    // Add error information to ModelState if an exception occurs
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the review: " + ex.Message);
                }
            }
            return Page(); // Return to the current page if model state is invalid or on error
        }

        // Retrieves the seller's name from the database
        private string GetSellerName(int sellerId)
        {
            using (var connection = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string query = "SELECT Username FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", sellerId);
                connection.Open();
                var result = cmd.ExecuteScalar();

                return result != null ? result.ToString() : "Unknown"; // Return the seller's username or "Unknown" if not found
            }
        }

        // Inserts the new review into the database
        private void SaveReviewToDatabase(ReviewSubmission review)
        {
            using (var connection = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Get the user ID of the reviewer from the claim

                string query = "INSERT INTO Reviews (SellerID, BuyerID, Rating, Comment, TransactionDate) VALUES (@SellerID, @BuyerID, @Rating, @Comment, @TransactionDate)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SellerID", review.SellerID);
                cmd.Parameters.AddWithValue("@BuyerID", userId);
                cmd.Parameters.AddWithValue("@Rating", review.Rating);
                cmd.Parameters.AddWithValue("@Comment", review.Comment);
                cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now); // Set the current date as the transaction date

                connection.Open();
                cmd.ExecuteNonQuery(); // Execute the insert command
            }
        }
    }
}
