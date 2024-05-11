using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    // Require authorization for access
    [Authorize]
    public class WishlistModel : PageModel
    {
        // Property to hold wishlist items
        public List<Item> WishlistItems { get; set; } = new List<Item>();

        // Handler for HTTP GET requests
        public void OnGet()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            LoadWishlistItems(userId);
        }

        // Method to load wishlist items
        private void LoadWishlistItems(string userId)
        {
            WishlistItems = new List<Item>();
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT i.ItemID, i.ItemName, i.ItemPrice, i.ItemPhotoURL1 FROM Wishlist w JOIN Item i ON w.ItemId = i.ItemID WHERE w.UserId = @UserId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    WishlistItems.Add(new Item
                    {
                        ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                        ItemName = reader.GetString(reader.GetOrdinal("ItemName")),
                        ItemPrice = reader.GetDecimal(reader.GetOrdinal("ItemPrice")),
                        ItemPhotoURL1 = reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL1")) ? null : reader.GetString(reader.GetOrdinal("ItemPhotoURL1"))
                    });
                }
            }
        }

        // Method to remove item from wishlist
        public IActionResult OnPostRemoveFromWishlist(int itemId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("", "User is not authenticated.");
                return Page();
            }

            try
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();
                    string cmdText = "DELETE FROM Wishlist WHERE UserId = @UserId AND ItemId = @ItemId";
                    using (var cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            TempData["SuccessMessage"] = "Item successfully removed from wishlist.";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "No item found or already removed.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error removing item from wishlist: " + ex.Message);
            }
            return RedirectToPage(); // Stays on the same page, updating the view to reflect changes
        }

        // Method to move item to cart
        public IActionResult OnPostMoveToCart(int itemId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();
                    int cartId = EnsureUserHasCart(conn, userId);

                    string addToCartText = "INSERT INTO ItemsInCart (CartID, ItemID) VALUES (@CartID, @ItemID)";
                    using (var cmd = new SqlCommand(addToCartText, conn))
                    {
                        cmd.Parameters.AddWithValue("@CartID", cartId);
                        cmd.Parameters.AddWithValue("@ItemID", itemId);
                        cmd.ExecuteNonQuery();
                    }

                    return OnPostRemoveFromWishlist(itemId);
                }
            }
            catch (SqlException ex)
            {
                ModelState.AddModelError("", "Error moving item to cart: " + ex.Message);
                return Page();
            }
        }

        // Method to ensure user has cart
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
