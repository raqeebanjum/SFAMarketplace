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

    public class WishlistModel : PageModel
    {
        public List<Item> WishlistItems { get; set; } = new List<Item>();

        public void OnGet()
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            LoadWishlistItems(userId);
        }

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
        

        
         public IActionResult OnPostRemoveFromWishlist(int itemId)
        {
            string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM Wishlist WHERE UserId = @UserId AND ItemId = @ItemId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ItemId", itemId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return RedirectToPage("/Account/Menus/Cart");
        }

         
         
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
         
         
         


    }
}
