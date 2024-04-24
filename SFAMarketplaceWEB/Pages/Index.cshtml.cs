using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace SFAMarketplaceWEB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Item> items { get; set; } = new List<Item>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PopulateItem();
        }

        private void PopulateItem()
        {
            items.Clear();

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
                SELECT ItemID, UserID, ItemName, ItemDescription, ItemPrice, ItemPhotoURL1, CategoryID, ItemTradeStatus, DatePosted
                FROM Item
                ORDER BY NEWID()";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
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
                        ItemPhotoURL1 = reader.IsDBNull(reader.GetOrdinal("ItemPhotoURL1")) ? null : reader.GetString(reader.GetOrdinal("ItemPhotoURL1")),
                        CategoryID = reader.IsDBNull(reader.GetOrdinal("CategoryID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CategoryID")),
                        ItemTradeStatus = reader.GetBoolean("ItemTradeStatus"),
                        DatePosted = reader.GetDateTime("DatePosted")
                    };
                    items.Add(item);
                }
            }
        }
    }
}