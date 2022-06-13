using System.Collections.Generic;

namespace ChannelEngine_Sheldon.BusinessLogic.Models
{
    public class Top5ViewModel
    {
        public string Description { get; set; }
        public string Gtin { get; set; }
        public long Quantity { get; set; }
        public string MerchantProductNo { get; set; }
        public long StockLocationId { get; set; }

    }

    public class GroupedProductsViewModel
    {
        public List<Top5ViewModel> groupedProducts { get; set; }
    }
}
