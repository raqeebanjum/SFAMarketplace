using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using static System.Net.Mime.MediaTypeNames;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class EditItemModel : PageModel
    {
        public Item Item { get; set; } = new Item();
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public void OnGet(int id)
        {
            PopulateItem(id);
            PopulateCategoryDDL();
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = @"
                UPDATE Item 
                SET ItemName = @ItemName, 
                    ItemDescription = @ItemDescription, 
                    ItemPhotoURL1 = @ItemPhotoURL1, 
                    ItemPhotoURL2 = @ItemPhotoURL2, 
                    ItemPhotoURL3 = @ItemPhotoURL3, 
                    ItemPrice = @ItemPrice,
                    CategoryID = @CategoryID, 
                    ItemTradeStatus = @ItemTradeStatus, 
                    DatePosted = @DatePosted 
                WHERE ItemId = @itemId";

                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemName", Item.ItemName);
                        cmd.Parameters.AddWithValue("@ItemDescription", Item.ItemDescription);
                        cmd.Parameters.AddWithValue("@ItemPhotoURL1", string.IsNullOrEmpty(Item.ItemPhotoURL1) ? (object)DBNull.Value : Item.ItemPhotoURL1);
                        cmd.Parameters.AddWithValue("@ItemPhotoURL2", string.IsNullOrEmpty(Item.ItemPhotoURL2) ? (object)DBNull.Value : Item.ItemPhotoURL2);
                        cmd.Parameters.AddWithValue("@ItemPhotoURL3", string.IsNullOrEmpty(Item.ItemPhotoURL3) ? (object)DBNull.Value : Item.ItemPhotoURL3);
                        cmd.Parameters.AddWithValue("@ItemPrice", Item.ItemPrice);
                        cmd.Parameters.AddWithValue("@CategoryID", Item.CategoryID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ItemTradeStatus", Item.ItemTradeStatus);
                        cmd.Parameters.AddWithValue("@DatePosted", DateTime.Now); 
                        cmd.Parameters.AddWithValue("@itemId", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToPage("/Account/Menus/PostedItems");
            }
            else
            {
                return Page();
            }
        }



        private void PopulateCategoryDDL()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT CategoryId, CategoryName FROM Category ORDER BY CategoryName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categories.Add(new SelectListItem
                    {
                        Value = reader.GetInt32(0).ToString(),
                        Text = reader.GetString(1)
                    });
                }
            }
        }

        private void PopulateItem(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
            SELECT ItemId, ItemName, ItemDescription, ItemPhotoURL1, ItemPhotoURL2, ItemPhotoURL3, ItemPrice, CategoryId, ItemTradeStatus 
            FROM Item 
            WHERE ItemId=@itemid";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@itemId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Item.ItemID = id;
                    Item.ItemName = reader.GetString(reader.GetOrdinal("ItemName"));
                    Item.ItemDescription = reader.GetString(reader.GetOrdinal("ItemDescription"));
                    Item.ItemPhotoURL1 = !reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL1")) ? reader.GetString(reader.GetOrdinal("ItemPhotoURL1")) : null;
                    Item.ItemPhotoURL2 = !reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL2")) ? reader.GetString(reader.GetOrdinal("ItemPhotoURL2")) : null;
                    Item.ItemPhotoURL3 = !reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL3")) ? reader.GetString(reader.GetOrdinal("ItemPhotoURL3")) : null;
                    Item.ItemPrice = reader.GetDecimal(reader.GetOrdinal("ItemPrice"));
                    Item.CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CategoryID"));
                    Item.ItemTradeStatus = reader.GetBoolean(reader.GetOrdinal("ItemTradeStatus"));
                }
            }
        }
    }
}
