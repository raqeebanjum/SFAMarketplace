using System;
using System.ComponentModel.DataAnnotations;

namespace SFAMarketplaceWEB.Model
{
    public class Item
    {
        public int ItemID { get; set; }
        public int? UserID { get; set; }  // nullable for now since authentication isn't being used
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public int? CategoryID { get; set; } 
        public bool ItemTradeStatus { get; set; }
        public DateTime DatePosted { get; set; }
    }


}
