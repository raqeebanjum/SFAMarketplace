using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [BindProperties]
    public class AddItemModel : PageModel
    {
        public Item NewItem { get; set; } = new Item();
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public void OnGet()
        {
            PopulateCategoryDDL();
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                SaveItemDetails();
                return RedirectToPage("PostedItems");
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
        private void SaveItemDetails()
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
                INSERT INTO Item (UserID, ItemName, ItemDescription, ItemPrice, CategoryID, ItemTradeStatus, DatePosted)
                VALUES (@UserID, @ItemName, @ItemDescription, @ItemPrice, @CategoryID, @ItemTradeStatus, @DatePosted)";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    // setting UserID to be 1 for all items during testing
                    cmd.Parameters.AddWithValue("@UserID", 1);
                    cmd.Parameters.AddWithValue("@ItemName", NewItem.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", NewItem.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", NewItem.ItemPrice);
                    cmd.Parameters.AddWithValue("@CategoryID", NewItem.CategoryID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ItemTradeStatus", NewItem.ItemTradeStatus);
                    cmd.Parameters.AddWithValue("@DatePosted", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
