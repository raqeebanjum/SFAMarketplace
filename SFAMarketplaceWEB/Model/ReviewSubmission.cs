using System;
using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Model
{
    public class ReviewSubmission
    {
        [Required]
        public int SellerID { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Comment must not exceed 100 characters.")]
        public string Comment { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
