namespace SFAMarketplaceWEB.Model
{
    public class Wishlist
    {
        public int WishlistID { get; set; }
        public int UserID { get; set; }

        public int ItemID { get; set; }

        public virtual Item Item { get; set; }

    }
}
