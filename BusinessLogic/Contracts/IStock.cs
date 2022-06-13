using BusinessLogic.Models;
using System.Threading.Tasks;

namespace ChannelEngine_Sheldon.BusinessLogic.Contracts
{
    public interface IStock
    {
        Task<StockResponseModel> PutStock(string id, int stock, long location, string consoleAppSettings = null);
    }
}
