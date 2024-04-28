using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Collections.Generic;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    public class ViewReviewModel : PageModel
    {
        // Assuming you have a User model that includes user-related information
        public string PostedBy { get; set; }
        public int SellerID { get; set; }
        public List<Review> SellerReviews { get; set; } = new List<Review>();

        public void OnGet(int sellerId)
        {
            SellerID = sellerId;
            PostedBy = GetSellerName(sellerId);
            SellerReviews = GetReviewsForSeller(sellerId);
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

        private List<Review> GetReviewsForSeller(int sellerId)
        {
            var reviews = new List<Review>();
            // Replace with your actual database access logic
            using (var connection = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                connection.Open();
                string query = "SELECT * FROM Reviews WHERE SellerID = @SellerID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SellerID", sellerId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var review = new Review
                            {
                                // Assuming your Review model has these properties
                                ReviewID = reader.GetInt32(reader.GetOrdinal("ReviewID")),
                                SellerID = reader.GetInt32(reader.GetOrdinal("SellerID")),
                                BuyerID = reader.GetInt32(reader.GetOrdinal("BuyerID")),
                                Rating = reader.GetInt32(reader.GetOrdinal("Rating")),
                                Comment = reader.GetString(reader.GetOrdinal("Comment")),
                                TransactionDate = reader.GetDateTime(reader.GetOrdinal("TransactionDate")),
                            };
                            reviews.Add(review);
                        }
                    }
                }
            }
            return reviews;
        }
    }
}
