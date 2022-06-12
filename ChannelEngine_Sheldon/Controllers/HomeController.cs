using ChannelEngine_Sheldon.BusinessLogic.Contracts;
using ChannelEngine_Sheldon.BusinessLogic.Models;
using ChannelEngine_Sheldon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                var orderList = await this._order.GetOrders("IN_PROGRESS"); // make enum

                var viewModel = new HomeViewModel();

                viewModel.groupedProducts = new List<Top5ViewModel>();

                foreach (var i in orderList)
                {
                    var product = new Top5ViewModel()
                    {
                        Description = i.Description,
                        Gtin = i.Gtin,
                        Quantity = i.Quantity,
                        MerchantProductNo = i.MerchantProductNo,
                        StockLocationId = i.StockLocation.Id
                    };

                    viewModel.groupedProducts.Add(product);
                }

                return View(viewModel);
            }
            catch
            {
                _logger.LogError("There was an error getting Orders");
                return View("Error");
            }
        }

        public async Task<IActionResult> UpdateStock(string MerchantProductNo, long StockLocationId)
        {
            try
            {
                var stockResponse = await this._stock.PutStock(MerchantProductNo, 25, StockLocationId);

                if (stockResponse.Success)
                {
                    ViewBag.SuccessMessage = "Stock Updated Successfully";
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
