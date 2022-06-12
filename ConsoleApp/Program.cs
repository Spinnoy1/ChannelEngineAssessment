using ChannelEngine_Sheldon.BusinessLogic.Contracts;
using ChannelEngine_Sheldon.BusinessLogic.Implimentation;
using ChannelEngine_Sheldon.BusinessLogic.Models;
using ChannelEngine_Sheldon.BusinessLogic.Models.AppSettings;
using ConsoleTables;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("config.json", optional: false);

            IConfiguration config = builder.Build();

            var AppSettings = config.GetSection("AppSettings").Get<AppSettings>();

            GetOrders(AppSettings).GetAwaiter().GetResult();
        }

        public static async Task GetOrders(AppSettings _appSettings)
        {
            //Dependency Inject Orders
            var serviceProvider = new ServiceCollection()
           .AddTransient<IOrders, Orders>()
           .AddOptions()
           .BuildServiceProvider();

            var _orderAPIAppSettings = _appSettings.OrderAPI;
            var _stockAPIAppSettings = _appSettings.StockAPI;

            var _orders = serviceProvider.GetService<IOrders>();

            var orderList = await _orders.GetOrders("IN_PROGRESS", _orderAPIAppSettings);

            var vm = new HomeViewModel();

            vm.groupedProducts = new List<Top5ViewModel>();

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

                vm.groupedProducts.Add(product);
            }

            //build a table with ConsoleTable Nuget Package
            var table = new ConsoleTable("ProductId", "Description", "Quantity","GTIN");

            foreach (var i in vm.groupedProducts)
            {
                table.AddRow(i.MerchantProductNo, i.Description, i.Quantity, i.Gtin);
            }

            table.Write(Format.Alternative);

            Console.WriteLine("Please enter the ProductID you would like to change");
            string productID = Console.ReadLine();

            bool doesProductExists = vm.groupedProducts.Any(x => x.MerchantProductNo == productID);

            while (doesProductExists == false)
            {
                Console.WriteLine("Incorrect ProductID, please choose a ProductID from the list above");
                productID = Console.ReadLine();
                doesProductExists = vm.groupedProducts.Any(x => x.MerchantProductNo == productID);
            }

            Console.WriteLine("Please enter the units of stock you would like the Product updated to: ");
            string stockResult = Console.ReadLine();

            //Check if stock value is a number. Dont allow for more than 1000 units of stock to be updated. 
            int X;
            while (!Int32.TryParse(stockResult, out X))
            {
                Console.WriteLine("Stock Level must be a valid numnber, please enter a valid number:");
                stockResult = Console.ReadLine();
            }

            while (Convert.ToInt32(stockResult) > 1000)
            {
                Console.WriteLine("To add more than 1000 units of stock please contact your Administrator. Please enter a number below 1000:");
                stockResult = Console.ReadLine();

            }

            var stockLocationId = vm.groupedProducts.Where(x => x.MerchantProductNo == productID).FirstOrDefault().StockLocationId;
            try
            {
                await PutStock(productID, Convert.ToInt32(stockResult), stockLocationId);
            }
            catch
            {
                Console.WriteLine("Theer was an issue with the service, please try again later.");
                Console.ReadLine();
            }

        }

        public static async Task PutStock(string id, int stock, long location)
        {
            //Dependency Inject Stock 
            var serviceProvider = new ServiceCollection()
               .AddTransient<IStock, Stock>()
               .BuildServiceProvider();

            var _stock = serviceProvider.GetService<IStock>();

           var stockResponse = await _stock.PutStock(id, stock, location);

            if (stockResponse.Success)
            {
                Console.WriteLine("Product " + id + " Successfully updated to " + stock + " units");
            }
            else
            {
                Console.WriteLine("Product " + id + " failed to update with Status Code: " + stockResponse.StatusCode + " and reason "+ stockResponse.Message);
            }

        }

    }
}
