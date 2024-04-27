using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using SFAMarketplaceWEB.Helpers;
using SFAMarketplaceWEB.Model;


namespace SFAMarketplaceWEB.Pages.Account.Menus
{
    [Authorize]
    [BindProperties]
    public class EditServiceModel : PageModel
    {
        public Service Service { get; set; } = new Service();
        

        public void OnGet(int id)
        {
            PopulateService(id);
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = @"
                    UPDATE Service
                    SET ServiceName = @ServiceName,
                        ServiceDescription = @ServiceDescription,
                        ServiceRate = @ServiceRate,
                        DatePosted = @DatePosted
                    WHERE ServiceId = @serviceId";

                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceName", Service.ServiceName);
                        cmd.Parameters.AddWithValue("@ServiceDescription", Service.ServiceDescription);
                        cmd.Parameters.AddWithValue("@ItemPrice", Service.ServiceRate);
                        cmd.Parameters.AddWithValue("@DatePosted", DateTime.Now);
                        cmd.Parameters.AddWithValue("@serviceId", id);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToPage("/Account/Menus/PostedServices");
            }
            else
            {
                return Page();
            }
        }

        private void PopulateService(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = @"
            SELECT ServiceId, ServiceName, ServiceDescription, ServiceRate 
            FROM Service 
            WHERE ServiceId=@serviceid";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@serviceId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Service.ServiceID = id;
                    Service.ServiceName = reader.GetString(reader.GetOrdinal("ServiceName"));
                    Service.ServiceDescription = reader.GetString(reader.GetOrdinal("ServiceDescription"));
                    Service.ServiceRate = reader.GetDecimal(reader.GetOrdinal("ServiceRate"));
                    
                }
            }
        }
    }
}
