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
    [Authorize] // Ensures only authorized users can access this page
    [BindProperties] // Enables automatic model binding from request data to the Item property
    public class EditItemModel : PageModel
    {
        public Item Item { get; set; } = new Item(); // Holds the item details being edited
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>(); // List for populating category dropdown

        // Handles GET request to load item details into the form for editing
        public void OnGet(int id)
        {
            PopulateItem(id); // Populate the form with item details from the database
            PopulateCategoryDDL(); // Populate the dropdown list with categories
        }

        // Handles the POST request when the form is submitted
        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString())) // Establish database connection
                {
                    // SQL command to update the item in the database
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
                        // Bind parameters to the command
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
                        cmd.ExecuteNonQuery(); // Execute the update command
                    }
                }
                return RedirectToPage("/Account/Menus/MyItems"); // Redirect to MyItems page on successful update
            }
            else
            {
                return Page(); // Return to the same page if the model is invalid
            }
        }

        // Handles the POST request to delete an item
        public IActionResult OnPostDelete(int itemId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                // SQL command to delete the item from the database
                string cmdText = "DELETE FROM Item WHERE ItemId = @itemId";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@itemId", itemId); // Bind the item ID to the command

                    conn.Open();
                    cmd.ExecuteNonQuery(); // Execute the delete command
                }
            }

            return RedirectToPage("/Account/Menus/PostedItems"); // Redirect to the PostedItems page after deletion
        }

        // Populates the Categories list from the database
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

        // Fetches item details from the database and loads them into the Item property
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
