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
        public string ReviewerName { get; set; } 

        public double AverageRating { get; set; }

        public Dictionary<int, double>? RatingDistribution { get; set; }

        public List<Review> SellerReviews { get; set; } = new List<Review>();

        public void OnGet(int sellerId)
        {
            SellerID = sellerId;
            PostedBy = GetSellerName(sellerId);
            SellerReviews = GetReviewsForSeller(sellerId);
            AverageRating = SellerReviews.Any() ? SellerReviews.Average(review => review.Rating) : 0;

            CalculateRatingDistribution(); // This will initialize RatingDistribution even if there are no reviews.
        }



        private void CalculateRatingDistribution()
        {
            RatingDistribution = new Dictionary<int, double>();

            var maxRating = 5; // Assuming 5 is the max rating
                               // Initialize the distribution dictionary with 0 for all possible ratings
            for (int i = 1; i <= maxRating; i++)
            {
                RatingDistribution[i] = 0;
            }

            foreach (var review in SellerReviews)
            {
                int rating = review.Rating;
                if (RatingDistribution.ContainsKey(rating))
                {
                    var count = SellerReviews.Count(r => r.Rating == rating);
                    var percentage = (count / (double)SellerReviews.Count) * 100;
                    RatingDistribution[rating] = percentage;
                }
            }
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
                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }
                else
                {
                    return "Unknown Seller"; // Default value if the seller is not found
                }
            }
        }
        private List<Review> GetReviewsForSeller(int sellerId)
        {
            var reviews = new List<Review>();
            using (var connection = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                connection.Open();
                string query = @"
                SELECT r.ReviewID, r.SellerID, r.BuyerID, r.Rating, r.Comment, r.TransactionDate, u.Username AS ReviewerName
                FROM Reviews r
                INNER JOIN Users u ON r.BuyerID = u.UserID
                WHERE r.SellerID = @SellerID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SellerID", sellerId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reviews.Add(new Review
                            {
                                ReviewID = reader.GetInt32(reader.GetOrdinal("ReviewID")),
                                SellerID = reader.GetInt32(reader.GetOrdinal("SellerID")),
                                BuyerID = reader.GetInt32(reader.GetOrdinal("BuyerID")),
                                Rating = reader.GetInt32(reader.GetOrdinal("Rating")),
                                Comment = reader.GetString(reader.GetOrdinal("Comment")),
                                TransactionDate = reader.GetDateTime(reader.GetOrdinal("TransactionDate")),
                                ReviewerName = reader.GetString(reader.GetOrdinal("ReviewerName")), // Added reviewer's name
                            });
                        }
                    }
                }
            }
            return reviews;
        }
    }
}
