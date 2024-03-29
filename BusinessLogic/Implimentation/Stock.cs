﻿using BusinessLogic.Models;
using ChannelEngine_Sheldon.BusinessLogic.Contracts;
using ChannelEngine_Sheldon.BusinessLogic.Models.AppSettings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine_Sheldon.BusinessLogic.Implimentation
{
    public class Stock : IStock
    {
        //Inject App settings to get API path
        private readonly AppSettings _appSettings;

        public Stock(IOptions<AppSettings> configuration)
        {
            _appSettings = configuration.Value;
        }

        public async Task<StockResponseModel> PutStock(string id, int stock, long location, string consoleAppSettings = null)
        {
            StockResponseModel model = new StockResponseModel();
            var response = new HttpResponseMessage();

            using (var httpClient = new HttpClient())
            {
                
                StockModel stockItem = new StockModel()
                {
                    MerchantProductNo = id,
                    StockLocations = new List<StockLocation>()
                };

                var stockLocations = new StockLocation() { 
                    Stock = stock, 
                    StockLocationId = location
                };


                stockItem.StockLocations.Add(stockLocations);

                var payload = new StockModel[1];
                payload[0] = stockItem;

                var jsonProduct = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                
                var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");

                if (consoleAppSettings == null)
                {
                    response = await httpClient.PutAsync(_appSettings.StockAPI, content);
                }
                else
                {
                    response = await httpClient.PutAsync(consoleAppSettings, content);
                }
              
                    var contents = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<StockResponseModel>(contents);
               
            }
            return model;
        }
    }
}
