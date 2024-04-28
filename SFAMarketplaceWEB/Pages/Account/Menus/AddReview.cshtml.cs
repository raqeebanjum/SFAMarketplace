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
        public string SellerName { get; set; }
        public int SellerID { get; set; }

        public void OnGet(int sellerId)
        {
            SellerID = sellerId;
            SellerName = GetSellerName(sellerId);
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                SaveReviewDetails();
                return RedirectToPage("ViewReview");
            }
            else
            {
                return Page();
            }



        }
        private string GetSellerName(int sellerId)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                conn.Open();
                string cmdText = "SELECT Username FROM Users WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@UserID", sellerId);

                var result = cmd.ExecuteScalar(); // Use ExecuteScalar when you expect a single value
                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
                else
                {
                    // If there is no such user, or FullName is NULL, return a default value or handle accordingly
                    return "Seller does not exist or name not provided";
                }
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
