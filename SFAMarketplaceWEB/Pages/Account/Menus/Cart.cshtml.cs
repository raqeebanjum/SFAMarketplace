using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Collections.Generic;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    public class CartPageModel : PageModel 
    {
        public Cart UserCart { get; set; } = new Cart(); 

        public void OnGet()
        {
            string currentUserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            PopulateCart(currentUserID);
        }

        private void PopulateCart(string userId)
        {
            UserCart.Item = new List<ItemsInCart>();

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                conn.Open();
                string cmdText = @"
                SELECT i.ItemID, i.ItemName, i.ItemPrice, i.ItemPhotoURL1, ic.CartItemID
                FROM ItemsInCart ic
                INNER JOIN Item i ON ic.ItemID = i.ItemID
                INNER JOIN Cart c ON ic.CartID = c.CartID
                WHERE c.UserID = @UserID";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var itemInCart = new ItemsInCart
                    {
                        CartItemID = reader.GetInt32(reader.GetOrdinal("CartItemID")),
                        Item = new Item
                        {
                            ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                            ItemName = reader.GetString(reader.GetOrdinal("ItemName")),
                            ItemPrice = reader.GetDecimal(reader.GetOrdinal("ItemPrice")),
                            ItemPhotoURL1 = reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL1")) ? null : reader.GetString(reader.GetOrdinal("ItemPhotoURL1"))
                        }
                    };

                    UserCart.Item.Add(itemInCart);
                }
            }
        }
    }
}
