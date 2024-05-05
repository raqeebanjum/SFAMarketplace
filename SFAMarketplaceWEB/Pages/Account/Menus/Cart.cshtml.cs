using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<SelectListItem> PickupLocations { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            string currentUserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            PopulateCart(currentUserID);
            PopulatePickupLocations();
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

        private void PopulatePickupLocations()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT LocationID, LocationName FROM TransactionLocation", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PickupLocations.Add(new SelectListItem
                        {
                            Value = reader["LocationID"].ToString(),
                            Text = reader["LocationName"].ToString()
                        });
                    }
                }
            }
        }

        public IActionResult OnPostDeleteItem(int cartItemId)
        {
            if (cartItemId <= 0)
            {
                return Page();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();
                    string cmdText = "DELETE FROM ItemsInCart WHERE CartItemID = @CartItemID";

                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@CartItemID", cartItemId);
                        cmd.ExecuteNonQuery();
                    }
                }

                TempData["SuccessMessage"] = "Item removed from cart successfully.";
                return RedirectToPage(); 
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error removing item from cart: " + ex.Message);
                return Page();
            }
        }



        public IActionResult OnPostCheckout()
        {
            string currentUserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserID))
            {
                return RedirectToPage("/Account/Login");
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    conn.Open();
                    string cmdText = "DELETE FROM ItemsInCart WHERE CartID IN (SELECT CartID FROM Cart WHERE UserID = @UserID)";

                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", currentUserID);
                        cmd.ExecuteNonQuery();
                    }
                }

                return RedirectToPage("/Account/Menus/Checkout");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error during checkout: " + ex.Message);
                return Page();
            }
        }
    }
}
