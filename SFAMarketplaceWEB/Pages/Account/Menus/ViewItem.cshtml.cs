using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Data;

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
                                ItemPhotoURL1 = !reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL1")) ? reader.GetString("ItemPhotoURL1") : null,
                                ItemPhotoURL2 = !reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL2")) ? reader.GetString("ItemPhotoURL2") : null,
                                ItemPhotoURL3 = !reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL3")) ? reader.GetString("ItemPhotoURL3") : null,
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
            string currentUserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserID))
            {
                // Handle case where user ID isn't found, possibly redirect to login
                return RedirectToPage("/Account/Login");
            }

            try
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();

                    // Ensure the user has a cart
                    int cartId = EnsureUserHasCart(conn, currentUserID);

                    // Insert item into cart
                    string cmdText = @"
                INSERT INTO ItemsInCart (CartID, ItemID)
                VALUES (@CartID, @ItemId)";

                    using (var cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@CartID", cartId);
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        int result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            // No rows inserted
                            return Page();
                        }
                    }
                }

                return RedirectToPage("/Account/Menus/Cart");
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


    }
}
