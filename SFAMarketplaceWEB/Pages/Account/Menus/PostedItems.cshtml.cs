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

        }

        public void OnPost()
        {
            PopulateCategoryDDL(); 
            PopulateItem(SelectedCategoryID);
        }



        private void PopulateItem(int? categoryId)
        {
            items.Clear();

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
                SELECT ItemID, UserID, ItemName, ItemDescription, ItemPrice, CategoryID, ItemTradeStatus, DatePosted
                FROM Item
                WHERE CategoryID = @CategoryId OR @CategoryId IS NULL";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId ?? (object)DBNull.Value);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
               
                    var item = new Item
                    {
                        ItemID = reader.GetInt32("ItemID"),
                        UserID = reader.IsDBNull(reader.GetOrdinal("UserID")) ? 0 : reader.GetInt32(reader.GetOrdinal("UserID")),
                        ItemName = reader.GetString("ItemName"),
                        ItemDescription = reader.GetString("ItemDescription"),
                        ItemPrice = reader.GetDecimal("ItemPrice"),
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
