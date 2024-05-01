using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Data;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    public class ViewServiceModel : PageModel
    {
        public Service Service { get; set; }
        public string PostedBy { get; set; }

        public void OnGet(int serviceId)
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString())) 
            {
                string cmdText = @" 
                    SELECT i.*, u.Username
                    FROM Service i
                    JOIN Users u ON i.UserID = u.UserID
                    WHERE i.ServiceID = @ServiceId";

                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@ServiceId", serviceId);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Service = new Service
                            {
                                ServiceID = reader.GetInt32("ItemID"),
                                UserID = reader.IsDBNull("UserID") ? null : reader.GetInt32("UserID"),
                                ServiceName = reader.GetString("ServiceName"),
                                ServiceDescription = reader.GetString("ServiceDescription"),
                                ServiceRate = reader.GetDecimal("ServiceRate"),
                                DatePosted = reader.GetDateTime("DatePoster")
                            };
                            PostedBy = reader.GetString("Username");
                        }
                    }
                }
            }

        }
    }
}
