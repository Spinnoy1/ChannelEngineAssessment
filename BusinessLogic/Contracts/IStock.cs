using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine_Sheldon.BusinessLogic.Contracts
{
    public interface IStock
    {
        Task<StockResponseModel> PutStock(string id, int stock, long location);
    }
}
