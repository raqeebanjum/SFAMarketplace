using SFAMarketplaceWEB.Model;

public class Cart
{
    public int CartID { get; set; }
    public int UserID { get; set; }
    public List<ItemsInCart> Item { get; set; }
}
