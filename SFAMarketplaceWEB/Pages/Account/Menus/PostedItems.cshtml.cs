using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Collections.Generic;
using System.Data;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class PostedItemsModel : PageModel
    {
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<Item> items { get; set; } = new List<Item>();

        public int SelectedCategoryID { get; set; }

        public void OnGet()
        {
            PopulateCategoryDDL();
            if (Categories.Any()) // Check if there are any categories
            {
                SelectedCategoryID = int.Parse(Categories.First().Value); // Automatically select the first category
                PopulateItem(SelectedCategoryID); // Load items for the first category
            }
            else
            {
                // Handle the case where no categories are available
                items = new List<Item>(); // Ensure the items list is initialized to prevent errors
            }
        }

        public void OnPost()
        {
            PopulateCategoryDDL(); 
            PopulateItem(SelectedCategoryID);
        }



        private void PopulateItem(int? categoryId)
        {
            items.Clear();
            string currentUserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value; // Retrieve the current user's ID

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
SELECT ItemID, UserID, ItemName, ItemDescription, ItemPrice, ItemPhotoURL1, ItemPhotoURL2, ItemPhotoURL3, CategoryID, ItemTradeStatus, DatePosted
FROM Item
WHERE (CategoryID = @CategoryId OR @CategoryId IS NULL)
AND UserID != @CurrentUserID"; // Add a condition to exclude items posted by the current user

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@CurrentUserID", currentUserID); // Pass the current user's ID to the query
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var item = new Item
                    {
                        ItemID = reader.GetInt32("ItemID"),
                        UserID = reader.IsDBNull(reader.GetOrdinal("UserID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("UserID")),
                        ItemName = reader.GetString("ItemName"),
                        ItemDescription = reader.GetString("ItemDescription"),
                        ItemPrice = reader.GetDecimal("ItemPrice"),
                        ItemPhotoURL1 = reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL1")) ? null : reader.GetString(reader.GetOrdinal("ItemPhotoURL1")),
                        CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CategoryID")),
                        ItemTradeStatus = reader.GetBoolean("ItemTradeStatus"),
                        DatePosted = reader.GetDateTime("DatePosted")
                    };
                    items.Add(item);
                }
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
    }
}
