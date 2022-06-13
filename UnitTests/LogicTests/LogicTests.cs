using System.Collections.Generic;
using System.Linq;
using ChannelEngine_Sheldon.BusinessLogic.Implimentation;
using ChannelEngine_Sheldon.BusinessLogic.Models.AppSettings;
using Microsoft.Extensions.Options;
using Xunit;
using ChannelEngine_Sheldon.BusinessLogic.Models;
using AutoFixture;
using AutoFixture.Kernel;

namespace UnitTests.LogicTests
{


    public class LogicTests
    {
        //Initialise Configurations 
        public static AppSettings _appSettings = new AppSettings()
        {
            AuthKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322",
            OrderAPI = "https://api-dev.channelengine.net/api/v2/orders?statuses=IN_PROGRESS&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322",
            StockAPI = "https://api-dev.channelengine.net/api/v2/offer/stock?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322"
        };

        public static IOptions<AppSettings> options = Options.Create(_appSettings);
        Orders _orders = new Orders(options);

        [Fact]
        public void Test_Top5Returns5ProductsOnly()
        {
            var allProducts = new GroupedProductsViewModel();

            //use AutoFixture to populate model
            var fixture = new Fixture();
            fixture.RepeatCount = 10; //Set this to 10 so we can see if it returns 5.
            
            new AutoPropertiesCommand().Execute(allProducts, new SpecimenContext(fixture));

            var response = _orders.GetTop5Products(allProducts);

            //Test if only 5 are returned from the initial set of 10 above
            Assert.Equal(5, response.Count);
        }
        [Fact]
        public void Test_Top5OrderedByHighestQuantitySummedDescending()
        {
            var allProducts = new GroupedProductsViewModel();
            var model = new List<Top5ViewModel>();

            var Order1 = new Top5ViewModel() { Description = "Tshirt Green", Gtin = "G-123456", MerchantProductNo = "1111", Quantity = 5, StockLocationId = 2};
            var Order2 = new Top5ViewModel() { Description = "Tshirt Green", Gtin = "G-123456", MerchantProductNo = "1111", Quantity = 6, StockLocationId = 2 };
            var Order3 = new Top5ViewModel() { Description = "Tshirt Blue", Gtin = "B-123456", MerchantProductNo = "2222", Quantity = 7, StockLocationId = 2 };
            var Order4 = new Top5ViewModel() { Description = "Tshirt Black", Gtin = "Bl-123456", MerchantProductNo = "3333", Quantity = 8, StockLocationId = 2 };
            var Order5 = new Top5ViewModel() { Description = "Tshirt Red", Gtin = "R-123456", MerchantProductNo = "4444", Quantity = 9, StockLocationId = 2 };

            model.Add(Order1);
            model.Add(Order2);
            model.Add(Order3);
            model.Add(Order4);
            model.Add(Order5);

            allProducts.groupedProducts = model;

            var response = _orders.GetTop5Products(allProducts);

            var topOrderQuantity = response[0].Quantity;

            //Test here if the quantity of the 2 Green shirts above has been grouped and summed. The highest should be on top with a sum of 11 units (5 + 6).
            Assert.Equal(11, topOrderQuantity);
        }

        [Fact]
        public void Test_Top5GroupedAndOnlyReturn3Products()
        {
            var allProducts = new GroupedProductsViewModel();
            var model = new List<Top5ViewModel>();

            var Order1 = new Top5ViewModel() { Description = "Tshirt Green", Gtin = "G-123456", MerchantProductNo = "1111", Quantity = 5, StockLocationId = 2 };
            var Order2 = new Top5ViewModel() { Description = "Tshirt Green", Gtin = "G-123456", MerchantProductNo = "1111", Quantity = 6, StockLocationId = 2 };
            var Order3 = new Top5ViewModel() { Description = "Tshirt Blue", Gtin = "B-123456", MerchantProductNo = "2222", Quantity = 7, StockLocationId = 2 };
            var Order4 = new Top5ViewModel() { Description = "Tshirt Blue", Gtin = "B-123456", MerchantProductNo = "2222", Quantity = 8, StockLocationId = 2 };
            var Order5 = new Top5ViewModel() { Description = "Tshirt Red", Gtin = "R-123456", MerchantProductNo = "4444", Quantity = 9, StockLocationId = 2 };

            model.Add(Order1);
            model.Add(Order2);
            model.Add(Order3);
            model.Add(Order4);
            model.Add(Order5);

            allProducts.groupedProducts = model;

            var response = _orders.GetTop5Products(allProducts);

            var totalNumberProducts = response.Count();

            //There are only 3 distinct products here so we expect only 3 responses to be returned 
            Assert.Equal(3, totalNumberProducts);

        }

    }
}
