using ChannelEngine_Sheldon.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine_Sheldon.BusinessLogic.Contracts
{
    public interface IOrders
    {
        Task<List<Top5ViewModel>> GetOrders(string status, string consoleAppSettings = null);
    }
}
