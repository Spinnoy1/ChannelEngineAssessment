using ChannelEngine_Sheldon.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngine_Sheldon.BusinessLogic.Contracts
{
    public interface IOrders
    {
        Task<List<Top5ViewModel>> GetOrders(string consoleAppSettings = null);
    }
}
