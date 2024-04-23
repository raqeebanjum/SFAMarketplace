namespace SFAMarketplaceWEB.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        public int? UserID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemPhotoURL1 { get; set; }
        public string ItemPhotoURL2 { get; set; }
        public string ItemPhotoURL3 { get; set; }
        public decimal ItemPrice { get; set; }
        public int? CategoryID { get; set; }
        public bool ItemTradeStatus { get; set; }
        public DateTime DatePosted { get; set; }

    }
}
