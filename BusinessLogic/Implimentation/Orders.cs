using ChannelEngine_Sheldon.BusinessLogic.Contracts;
using ChannelEngine_Sheldon.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Http;
using System.Text.Json;
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
   

        public async Task<List<Line>> GetOrders(string status, string consoleAppSettings = null)
        {

        var groupedOrders = new List<Line>();

            Welcome orderList = new Welcome();

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
                    orderList = JsonConvert.DeserializeObject<Welcome>(apiResponse);

                    List<Content> contents = new List<Content>();

                    groupedOrders = orderList.Content.GroupBy(g => new { g.Lines[0].Description, g.Lines[0].Gtin, g.Lines[0].MerchantProductNo, g.Lines[0].StockLocation.Id})
                        .Select(g => new Line
                        {
                            Gtin = g.Key.Gtin,
                            Description = g.Key.Description,
                            Quantity = g.Sum(c => c.Lines[0].Quantity),
                            MerchantProductNo = g.Key.MerchantProductNo,
                            StockLocation = new StockLocation { Id = g.Key.Id }
                        }).OrderByDescending(x => x.Quantity).Take(5).ToList();
                
            

            return groupedOrders;

        }
    }
}
