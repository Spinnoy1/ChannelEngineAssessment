using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [Fact]
        public void TestIfReturns5ProductsOnly()
        {
            AppSettings _appSettings = new AppSettings()
            {
                AuthKey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322",
                OrderAPI = "https://api-dev.channelengine.net/api/v2/orders?statuses=IN_PROGRESS&apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322",
                StockAPI = "https://api-dev.channelengine.net/api/v2/offer/stock?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322"
            };

            var options = Options.Create(_appSettings);
            var _orders = new Orders(options);

            var allProducts = new GroupedProductsViewModel();

            //use AutoFixture to populate model
            var fixture = new Fixture();
            fixture.RepeatCount = 10; //Set this to 10 so we can see if it returns 5.
            
            new AutoPropertiesCommand().Execute(allProducts, new SpecimenContext(fixture));

            var response = _orders.GetTop5Products(allProducts);

            Assert.Equal(5, response.Count);
        }

        public void TestGrouping()
        {
            var model = new List<Top5ViewModel>();

            Top5ViewModel vm = new Top5ViewModel()
            {
                Description = "",
                Gtin = "",
                MerchantProductNo = "",
                Quantity = 100,
                StockLocationId = 2
            };

            model.Add(vm);
        }

    }
}
