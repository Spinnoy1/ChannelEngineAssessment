using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BusinessLogic.Models
{
    public class StockModel
    {

        [JsonProperty("MerchantProductNo")]
        public string MerchantProductNo { get; set; }

        [JsonProperty("StockLocations")]
        public List<StockLocation> StockLocations { get; set; }
    }

    public class StockLocation
    {
        [JsonProperty("Stock")]
        public long Stock { get; set; }

        [JsonProperty("StockLocationId")]
        public long StockLocationId { get; set; }
    }


}
