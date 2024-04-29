using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Model
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int SellerID { get; set; }

        public int BuyerID { get; set; }

        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime TransactionDate { get; set; }

        public string ReviewerName { get; set; }
    }
}
