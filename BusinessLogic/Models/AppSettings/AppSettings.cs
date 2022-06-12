using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine_Sheldon.BusinessLogic.Models.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public string AuthKey { get; set; }
        public string OrderAPI { get; set; }
        public string StockAPI { get; set; }

    }
}
