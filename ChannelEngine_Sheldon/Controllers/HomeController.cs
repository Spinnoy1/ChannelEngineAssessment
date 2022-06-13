using ChannelEngine_Sheldon.BusinessLogic.Contracts;
using ChannelEngine_Sheldon.BusinessLogic.Models;
using ChannelEngine_Sheldon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChannelEngine_Sheldon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOrders _order;

        private readonly IStock _stock;

        public HomeController(ILogger<HomeController> logger, IOrders order, IStock stock)
        {
            _logger = logger;
            _order = order;
            _stock = stock;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var orderList = await this._order.GetOrders();
                
                GroupedProductsViewModel gp = new GroupedProductsViewModel();
                gp.groupedProducts = orderList;
                
                return View(gp);
            }
            catch
            {
                _logger.LogError("There was an error getting Orders");
                return View("Error");
            }
        }

        
        public async Task<IActionResult> UpdateStock(string MerchantProductNo, long StockLocationId, int StockLevel)
        {
            try
            {
                var stockResponse = await this._stock.PutStock(MerchantProductNo, StockLevel, StockLocationId);

                if (stockResponse.Success)
                {
                    ViewBag.SuccessMessage = "Stock for Product " +MerchantProductNo+ " updated to " +StockLevel+ " successfully";
                    return View();
                }
            }

            catch 
            {
                _logger.LogError("There was an error getting Orders");
                return View("Error");
            }

            return null;
        
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
