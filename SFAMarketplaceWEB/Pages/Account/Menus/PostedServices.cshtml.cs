using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System.Data;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{

    [Authorize]
    [BindProperties]
    public class PostedServicesModel : PageModel
    {
        private readonly ILogger<PostedServicesModel> _logger;
        public List<Service> services { get; set; } = new List<Service>();

        public PostedServicesModel(ILogger<PostedServicesModel> logger)
        {
            _logger = logger;
        }

        
        public void OnGet()
        {
            PopulateService();
        }

        private void PopulateService()
        {
            services.Clear();

            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
                SELECT ServiceName, ServiceDescription, ServiceRate, DatePosted, ServiceId, UserID
                FROM Services
                ORDER BY ServiceID";

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var service = new Service
                    {
                        ServiceID = reader.GetInt32("ServiceID"),
                        UserID = reader.IsDBNull(reader.GetOrdinal("UserID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("UserID")),
                        ServiceName = reader.GetString("ServiceName"),
                        ServiceDescription = reader.GetString("ServiceDescription"),
                        ServiceRate = reader.GetDecimal("ServiceRate"),
                        DatePosted = reader.GetDateTime("DatePosted")

                    };
                    services.Add(service);
                }

            }
        }
    }
}
