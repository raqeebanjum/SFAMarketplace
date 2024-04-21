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
            Update Item SET UserID=@UserID, ItemName=@ItemName, ItemDescription=@ItemDescription, ItemPrice=@ItemPrice,
                            CategoryID=@CategoryID, ItemTradeStatus=@ItemTradeStatus, DatePosted=@DatePosted WHERE ItemId=@itemId";

                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", 1);  // Ensure the UserID is valid and exists in your database
                        cmd.Parameters.AddWithValue("@ItemName", Item.ItemName);
                        cmd.Parameters.AddWithValue("@ItemDescription", Item.ItemDescription);
                        cmd.Parameters.AddWithValue("@ItemPrice", Item.ItemPrice);
                        cmd.Parameters.AddWithValue("@CategoryID", Item.CategoryID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ItemTradeStatus", Item.ItemTradeStatus);
                        cmd.Parameters.AddWithValue("@DatePosted", DateTime.Now);
                        cmd.Parameters.AddWithValue("@itemId", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        return RedirectToPage("/Account/Menus/PostedItems");
                    }
                }
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
                string cmdText = "SELECT ItemId, ItemTradeStatus, ItemName, ItemDescription, ItemPrice, CategoryId FROM Item WHERE ItemId=@itemid";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@itemId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Item.ItemID = id;
                    Item.ItemTradeStatus = reader.GetBoolean(1);
                    Item.ItemName = reader.GetString(2);
                    Item.ItemDescription = reader.GetString(3);
                    Item.ItemPrice = reader.GetDecimal(4);
                    Item.CategoryID = reader.GetInt32(5);
                }
            }
        }
    }
}
