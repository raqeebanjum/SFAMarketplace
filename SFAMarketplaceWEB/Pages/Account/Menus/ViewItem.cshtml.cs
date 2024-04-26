using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Data;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
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
                                UserID = reader.IsDBNull("UserID") ? null : reader.GetInt32("UserID"),
                                ItemName = reader.GetString("ItemName"),
                                ItemDescription = reader.GetString("ItemDescription"),
                                ItemPhotoURL1 = reader.IsDBNull("ItemPhotoURL1") ? null : reader.GetString("ItemPhotoURL1"),
                                ItemPhotoURL2 = reader.IsDBNull("ItemPhotoURL2") ? null : reader.GetString("ItemPhotoURL2"),
                                ItemPhotoURL3 = reader.IsDBNull("ItemPhotoURL3") ? null : reader.GetString("ItemPhotoURL3"),
                                ItemPrice = reader.GetDecimal("ItemPrice"),
                                CategoryID = reader.IsDBNull("CategoryID") ? null : reader.GetInt32("CategoryID"),
                                ItemTradeStatus = reader.GetBoolean("ItemTradeStatus"),
                                DatePosted = reader.GetDateTime("DatePosted")
                            };
                            PostedBy = reader.GetString("Username"); // Fetch the username
                        }
                    }
                }
            }
        }
    }
}
