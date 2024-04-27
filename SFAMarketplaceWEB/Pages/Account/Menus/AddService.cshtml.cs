using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;
using System;

namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class AddServiceModel : PageModel
    {
        public Service NewService { get; set; } = new Service();

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                SaveServiceDetails();
                return RedirectToPage("PostedServices"); 
            }
            return Page(); 
        }

        private void SaveServiceDetails()
        {
            using (var conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
        INSERT INTO Services (UserID, ServiceName, ServiceDescription, ServiceRate, DatePosted)
        VALUES (@UserID, @ServiceName, @ServiceDescription, @ServiceRate, @DatePosted)";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@ServiceName", NewService.ServiceName);
                    cmd.Parameters.AddWithValue("@ServiceDescription", NewService.ServiceDescription);
                    cmd.Parameters.AddWithValue("@ServiceRate", NewService.ServiceRate);
                    cmd.Parameters.AddWithValue("@DatePosted", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
