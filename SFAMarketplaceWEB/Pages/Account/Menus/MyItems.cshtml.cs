// Import necessary namespaces
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Data;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    // Require authorization for access
    [Authorize]
    [BindProperties]
    public class MyItemsModel : PageModel
    {
        // Property to hold user's items
        public List<Item> myItems { get; set; } = new List<Item>();

        // Handler for HTTP GET requests
        public void OnGet()
        {
            // Load user's items
            LoadUserItems();
        }

        // Method to load user's items
        private void LoadUserItems()
        {
            // Clear existing items
            myItems.Clear();

            // Retrieve the current user's ID
            string currentUserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Retrieve user's items from the database
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT * FROM Item WHERE UserId = @UserId";
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", int.Parse(currentUserID));
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add each item to the list
                            myItems.Add(new Item
                            {
                                ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                ItemName = reader.GetString(reader.GetOrdinal("ItemName")),
                                ItemPrice = reader.GetDecimal("ItemPrice"),
                                ItemDescription = reader.GetString("ItemDescription"),
                                ItemPhotoURL1 = reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL1")) ? null : reader.GetString(reader.GetOrdinal("ItemPhotoURL1")),
                                CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                ItemTradeStatus = reader.GetBoolean("ItemTradeStatus"),
                                DatePosted = reader.GetDateTime("DatePosted")
                                // Map other properties as needed
                            });
                        }
                    }
                }
            }
        }
    }
}
