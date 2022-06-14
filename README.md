# ChannelEngineAssessment

Created 4 Projects within my Solution

- WebUI -> For the web entry point.
- ConsoleApp -> For the console entry point.
- Business Logic -> Houses all the logic shared accross the above 2 projects
- Unit Tests -> Basic unit tests, testing the Top 5 Functionality.

The project was built  using VS 2019, with .Net 5.0.

It should run straight out of the box.

Installed various NuGet Packages.

I used Dependency Injection in the WEB and Console APP's to inject the dependencies of the Order and Stock classes in the Business Logic layer.

I stored the API's and Key in the Application.Json file in the WebUI project and I inject these values into my BL layer with the Configuration service.

I similarly inject the API details into my BL from the Console App.

Brief Overview

Note: It seems the Dev environment only has 4 unique products so I could not get the Top5, however functionality is there for if there are more products / orders in the Dev environment.

WEBUI
Front end  / Razor isnt my strongest point. I used basic bootstrap here to display the output of the Top 5 Products. 
The Order class is injected to my HomeController from BL which returns the Top 5.
In the View I have a text box to set the Stock Level and a button to update it.
I call the Stock class from the BL layer which sends the required fields to the stock service and returns a response. 

Console App
Order class injected.
Get top 5 Orders from Order class in BL.
Build a table using ConsoleTable NuGet Package
Here you can enter a ProductCode to select which product you would like to update
Then enter the amount of stock to update, which calls the Stock class in BL and publishes. 

Business Logic
I have an Order and Stock class here that does all the BL.
Order 
- Fetches all orders from Web Service that are IN_PROGRESS. I thin use LINQ to Group by ProductCode and GTIN, SUM the Quantity and Order by Quantity Descending. This is in its own method for ease of testing.
- Adds these Top5 into a model and returns this model for use in UI / Console.

Stock
-Takes in ProductCode, StockLocation and StockLevel and publishes this to the web service.
-Response is stored in the Response Model

UnitTests
For the Unit tests i used XUnit.
I tested the functionality of the Top 5 logic.
I tested that we receive only 5 from a batch of x
I tested that we receive these 5 ordered by highest Quantity and Grouped
I tested that, if we only have 3 distinct orders only return 3 and dont break.
I tested that, if we revceive no orders it doesnt break.
I tested that orders are returned in Desc Order by Qty.







