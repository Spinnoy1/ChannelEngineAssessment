using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BusinessLogic.Models
{
    public class StockResponseModel
    {

        [JsonProperty("Content")]
        public Content Content { get; set; }

        [JsonProperty("StatusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("RequestId")]
        public string RequestId { get; set; }

        [JsonProperty("LogId")]
        public string LogId { get; set; }

        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("ValidationErrors")]
        public Content ValidationErrors { get; set; }
    }

    public partial class Content
    {
        [JsonProperty("additionalProp1")]
        public string[] AdditionalProp1 { get; set; }

        [JsonProperty("additionalProp2")]
        public string[] AdditionalProp2 { get; set; }

        [JsonProperty("additionalProp3")]
        public string[] AdditionalProp3 { get; set; }
    }

}
