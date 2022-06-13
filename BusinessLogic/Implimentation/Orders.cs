using ChannelEngine_Sheldon.BusinessLogic.Contracts;
using ChannelEngine_Sheldon.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using ChannelEngine_Sheldon.BusinessLogic.Models.AppSettings;
using Microsoft.Extensions.Options;

namespace ChannelEngine_Sheldon.BusinessLogic.Implimentation
{
    public class Orders : IOrders
    {
        //Inject API key and URL's from App settings 

        private readonly AppSettings _appSettings;

        public Orders(IOptions<AppSettings> configuration)
        {
            _appSettings = configuration.Value;
        }
   

        public async Task<List<Top5ViewModel>> GetOrders(string status, string consoleAppSettings = null)
        {

       // var groupedOrders = new List<Line>();

            FullOrder orderList = new FullOrder();

            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();

            // httpClient.DefaultRequestHeaders.Add("api-key",_appSettings.AuthKey);

            if (consoleAppSettings == null)
            {
                 response = await httpClient.GetAsync(_appSettings.OrderAPI);
            }
            else
            {
                 response = await httpClient.GetAsync(consoleAppSettings);
            }
                                 
            string apiResponse = await response.Content.ReadAsStringAsync();
            orderList = JsonConvert.DeserializeObject<FullOrder>(apiResponse);
            

            //Start Setting up products to be grouped / Top 5
            var groupModel = new GroupedProductsViewModel();

            groupModel.groupedProducts = new List<Top5ViewModel>();

            int count = orderList.Content.Count();

            foreach (var i in orderList.Content)
            {
            
                foreach (var l in i.Lines)
                { 
                    var product = new Top5ViewModel()
                    {
                        Description = l.Description,
                        Gtin = l.Gtin,
                        Quantity = l.Quantity,
                        MerchantProductNo = l.MerchantProductNo,
                        StockLocationId = l.StockLocation.Id
                    };

                    groupModel.groupedProducts.Add(product);
                }
            }
            var listOfOrders = GetTop5Products(groupModel);

            return listOfOrders;

        }

        public List<Top5ViewModel> GetTop5Products(GroupedProductsViewModel order)
        { 
            var groupedOrder = order.groupedProducts.GroupBy(g => new { g.Description, g.Gtin, g.MerchantProductNo, g.StockLocationId })
                        .Select(g => new Top5ViewModel
                        {
                            Gtin = g.Key.Gtin,
                            Description = g.Key.Description,
                            Quantity = g.Sum(c => c.Quantity),
                            MerchantProductNo = g.Key.MerchantProductNo,
                            StockLocationId =  g.Key.StockLocationId 
                        }).OrderByDescending(x => x.Quantity).Take(5).ToList();

            return groupedOrder;

        }
    }
}
