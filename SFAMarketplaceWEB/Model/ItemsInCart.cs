namespace SFAMarketplaceWEB.Model
{
    public class ItemsInCart
    {
        public int CartItemID { get; set; }
        public int? CartID { get; set; }
        public int? ItemID { get; set; }
        public int? LocationID { get; set; }

        public virtual Item Item { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual TransactionLocation TransactionLocation { get; set; }
    }
}
