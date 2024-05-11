using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using Microsoft.AspNetCore.Authorization;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize] // Ensures only authorized users can access this page
    [BindProperties] // Automatically binds form inputs to properties
    public class AddItemModel : PageModel
    {
        public Item NewItem { get; set; } = new Item(); // Holds new item details
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>(); // Holds dropdown list for categories

        // Populate categories dropdown when the page is accessed
        public void OnGet()
        {
            PopulateCategoryDDL();
        }

        // Handles the post request when a new item is submitted
        public IActionResult OnPost()
        {
            // Validate that the item price is not negative
            if (NewItem.ItemPrice < 0)
            {
                ModelState.AddModelError("NewItem.ItemPrice", "Price cannot be negative.");
            }

            // Save item if model state is valid
            if (ModelState.IsValid)
            {
                SaveItemDetails();
                return RedirectToPage("PostedItems"); // Redirect to the PostedItems page on success
            }
            else
            {
                PopulateCategoryDDL(); // Repopulate dropdown list if there's an error
                return Page(); // Return to the current page
            }
        }

        // Populates the category dropdown list from the database
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

        // Saves the new item details to the database
        private void SaveItemDetails()
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
        INSERT INTO Item (UserID, ItemName, ItemDescription, ItemPrice, CategoryID, ItemTradeStatus, DatePosted, ItemPhotoURL1, ItemPhotoURL2, ItemPhotoURL3)
        VALUES (@UserID, @ItemName, @ItemDescription, @ItemPrice, @CategoryID, @ItemTradeStatus, @DatePosted, @ItemPhotoURL1, @ItemPhotoURL2, @ItemPhotoURL3)";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@ItemName", NewItem.ItemName);
                    cmd.Parameters.AddWithValue("@ItemDescription", NewItem.ItemDescription);
                    cmd.Parameters.AddWithValue("@ItemPrice", NewItem.ItemPrice);
                    cmd.Parameters.AddWithValue("@CategoryID", NewItem.CategoryID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ItemTradeStatus", NewItem.ItemTradeStatus);
                    cmd.Parameters.AddWithValue("@DatePosted", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ItemPhotoURL1", NewItem.ItemPhotoURL1 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ItemPhotoURL2", NewItem.ItemPhotoURL2 ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ItemPhotoURL3", NewItem.ItemPhotoURL3 ?? (object)DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
