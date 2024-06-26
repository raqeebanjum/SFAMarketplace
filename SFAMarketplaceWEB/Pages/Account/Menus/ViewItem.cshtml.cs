using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Data;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class ViewItemModel : PageModel
    {
        public Item Item { get; set; }
        public string PostedBy { get; set; } // this is to store the username of whoever posted the item

        public void OnGet(int itemId)
        {
            string deafaultPhoto = "https://dartmoormat.org.uk/wp-content/themes/twentytwentyone-child/img/placeholder.png";

            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
            SELECT i.*, u.Username 
            FROM Item i 
            JOIN Users u ON i.UserID = u.UserID 
            WHERE i.ItemID = @ItemId";

                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Item = new Item
                            {
                                ItemID = reader.GetInt32("ItemID"),
                                UserID = !reader.IsDBNull(reader.GetOrdinal("UserID")) ? reader.GetInt32("UserID") : (int?)null,
                                ItemName = reader.GetString("ItemName"),
                                ItemDescription = reader.GetString("ItemDescription"),
                                ItemPhotoURL1 = IsValidUrl(reader.GetString("ItemPhotoURL1")) ? reader.GetString("ItemPhotoURL1") : deafaultPhoto,
                                ItemPhotoURL2 = IsValidUrl(reader.GetString("ItemPhotoURL2")) ? reader.GetString("ItemPhotoURL2") : deafaultPhoto,
                                ItemPhotoURL3 = IsValidUrl(reader.GetString("ItemPhotoURL3")) ? reader.GetString("ItemPhotoURL3") : deafaultPhoto,
                                ItemPrice = reader.GetDecimal("ItemPrice"),
                                CategoryID = !reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? reader.GetInt32("CategoryID") : (int?)null,
                                ItemTradeStatus = reader.GetBoolean("ItemTradeStatus"),
                                DatePosted = reader.GetDateTime("DatePosted")
                            };
                            PostedBy = reader.GetString("Username"); // Fetch the username
                        }
                        else
                        {
                            // Item not found, handle accordingly
                            Item = null;
                        }
                    }
                }
            }

            if (Item == null)
            {
                // Redirect to an error page or handle the null case
            }
        }


        public IActionResult OnPostAddToCart(int itemId)
        {
            string currentUserID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserID))
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();
                    int cartId = EnsureUserHasCart(conn, currentUserID);

                    // Insert item into cart
                    string addToCartCmd = @"
            INSERT INTO ItemsInCart (CartID, ItemID)
            VALUES (@CartID, @ItemId)";
                    using (var cmd = new SqlCommand(addToCartCmd, conn))
                    {
                        cmd.Parameters.AddWithValue("@CartID", cartId);
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        cmd.ExecuteNonQuery();
                    }

                    // Remove item from Wishlist
                    string removeFromWishlistCmd = @"
            DELETE FROM Wishlist
            WHERE UserId = @UserId AND ItemId = @ItemId";
                    using (var cmd = new SqlCommand(removeFromWishlistCmd, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", currentUserID);
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToPage("/Account/Menus/Cart");
            }
            catch (SqlException ex)
            {
                // Log the error
                return Page();
            }
        }
        public IActionResult OnPostAddToWishlist(int itemId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                // Handle case where user ID isn't found, possibly redirect to login
                return RedirectToPage("/Account/Login");
            }

            try
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();

                    // Insert item into Wishlist
                    string cmdText = @"
            INSERT INTO Wishlist (UserId, ItemId)
            VALUES (@UserId, @ItemId)";

                    using (var cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            // No rows inserted
                            return Page();
                        }
                    }
                }

                return RedirectToPage("/Account/Menus/Wishlist"); // Redirect back to the same page or to the wishlist page
            }
            catch (SqlException ex)
            {
                // Log the error (add logging logic here)
                return Page(); // Optionally return an error message to display
            }
        }



        private int EnsureUserHasCart(SqlConnection conn, string userId)
        {
            string checkCartCmd = "SELECT CartID FROM Cart WHERE UserID = @UserID";
            using (var cartCmd = new SqlCommand(checkCartCmd, conn))
            {
                cartCmd.Parameters.AddWithValue("@UserID", userId);
                var cartIdObj = cartCmd.ExecuteScalar();
                if (cartIdObj != null)
                {
                    return (int)cartIdObj;
                }

                // No cart exists, create one
                string createCartCmd = "INSERT INTO Cart (UserID) OUTPUT INSERTED.CartID VALUES (@UserID)";
                using (var createCmd = new SqlCommand(createCartCmd, conn))
                {
                    createCmd.Parameters.AddWithValue("@UserID", userId);
                    return (int)createCmd.ExecuteScalar();
                }
            }
        }

        bool IsValidUrl(string url)
        {
            Uri uriResult;
            bool isValidUri = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                             && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return isValidUri;
        }


    }
}
