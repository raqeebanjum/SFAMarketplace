using System;
using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Model
{
    public class Service
    {
        public int ServiceID { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Service name is required.")]
        public string ServiceName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string ServiceDescription { get; set; }

        [Required(ErrorMessage = "Rate is required.")]
        public decimal ServiceRate { get; set; }

        public DateTime DatePosted { get; set; }
    }
}
