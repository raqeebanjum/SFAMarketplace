using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Security.Claims;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class MyItemsModel : PageModel
    {
        public List<Item> myItems { get; set; } = new List<Item>();

        public void OnGet()
        {
            LoadUserItems();
        }

        private void LoadUserItems()
        {
            myItems.Clear();
            string currentUserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value; // Retrieve the current user's ID

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
                            myItems.Add(new Item
                            {
                                ItemID = reader.GetInt32(reader.GetOrdinal("ItemID")),
                                ItemName = reader.GetString(reader.GetOrdinal("ItemName")),
                                // Map other properties as needed
                            });
                        }
                    }
                }
            }
        }
    }
}
