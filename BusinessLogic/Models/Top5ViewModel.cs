using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    public class HomeViewModel
    {
        public List<Top5ViewModel> groupedProducts { get; set; }
    }
}
