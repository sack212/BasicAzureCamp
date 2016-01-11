# Web Demos

> Note: These demos are verified with VS 2015 Community edition with Update 1 and Azure SDK for .Net 2.8.1

## Demo 1 - Creating a Web App

This is a quick demo showing how quickly you can create a new Web App in the portal. Feel free to change alter this first demo.

1. Browse to the [Azure Portal](https://portal.azure.com)

1. Click New / Web + Mobile / Web App.

1. Enter a unique name in the URL field and click the Create button.

1. While the site is being created, explain that Azure is provisioning a new Web App for you with supporting services, monitoring, support for continuous deployment, etc.

 > Note: This generally takes 30 - 60 seconds. During this time, you can ask them how long it would take their IT department or hosting provider to provision a new site for them. This is usually enough time for the new Web App to be created.

1. When the site comes up, scroll through the various features (Monitoring, Usage, Operations, Deployment, Networking) explaining that these are all live and have been provisioned with the Web App. You can click on the _settings_ option to bring up the _settings_ blade.
> Note: If these tiles are not visible, you can add them by clicking on 'Add tiles' button and add Deployment, Operations, Usage etc.

1. Click on the Browse button. When the default landing page loads, point out that the page illustrates the different options for publishing to the new site, including Git, FTP, Visual Studio, etc.

1.  Back in the portal, Under 'General' option select 'Application settings'. Show that .NET, PHP, Python and Java are all shown.

## Demo 2 - WebJobs

This sample demonstrates creating a WebJob and performing operations with Microsoft Azure WebJobs SDK. In this sample, the Program class starts the JobHost and creates the demo data. The Functions class contains methods that will be invoked when messages are placed on the queues and tables, based on the attributes in the method headers.

 1. Go to http://portal.azure.com and provision a new free Web App.  

 > Note: You can use the Web App you provisioned in the first demo here.

 2. In Visual Studio, go to File -> New -> Project and navigate to Visual C# -> Cloud -> QuickStarts -> Select "Azure WebJobs SDK: Tables"

 3. Select the name and location for the project and click "ok".

 4. Open the project in Visual Studio, and compile (to download all the packages required inside bin directory)

 5. Enter a storage account name and key as instructed in App.config.

 6. Right-click project, select " Publish as Azure WebJob.." and then select "run on-demand" from the dropdown.

 7. Select "Microsoft Azure App Service" and Click Next.

 8. Select the relevant subscription/ resource group and web app.

 9. Modify any details that you want here and click "Publish".

 10. Find the WebJob under the Web App node in Server Explorer, right-click and select run.
 
 11. Find the storage account in Server Explorer and show the results in queue(textinput) and table(words).

 12. Show how to run the WebJob from the Wep App's WebJob setting blade in the portal. Show the log of successful runs.

## Demo 3 - Creating an API App

This is a quick demo showing how quickly you can create a new API App using Visual Studio.

1. Create a new **ASP.NET Web Application** project using Visual Studio with the name **ProductsApp**

2. Select the **Azure API App (Preview)** project template

3. Add a Contact class to the project with the name **Product.cs**

4. Add the following code to the contact class:

		namespace ProductsApp.Models
		{
		    public class Product
		    {
		        public int Id { get; set; }
		        public string Name { get; set; }
		        public string Category { get; set; }
		        public decimal Price { get; set; }
		    }
		}

5. Delete the **ValuesController.cs** file in the **Controllers** folder.

6. Add a new Empty Controller to the Web API project using the Default Scaffolding and the name **ProductsController.cs**

7. Add the following code to the controller

		using ProductsApp.Models;
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Net;
		using System.Web.Http;

		namespace ProductsApp.Controllers
		{
		    public class ProductsController : ApiController
		    {
						List<Product> products = new List<Product>
		        {
		            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
		            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
		            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
		        };

		        public IEnumerable<Product> GetAllProducts()
		        {
		            return products;
		        }

		        public IHttpActionResult GetProduct(int id)
		        {
		            var product = products.FirstOrDefault((p) => p.Id == id);
		            if (product == null)
		            {
		                return NotFound();
		            }
		            return Ok(product);
		        }
		    }
		}

8. Deploy the application to a new API App instance in Azure

	> Ensure that the Access Level is set to **Available to Everyone**

9. Open **Internet Explorer** and navigate to **https://www.hurl.it/**

10. In the **Destination** textbox, add the URL for your API app with the relative url **/api/Products** appended to the end

	> Ensure that you use the https scheme. `https://[API App Name].azurewebsites.net/api/Products`

11. Click **Launch Request**

12. Leave the project in Visual Studio open for future demos

## Demo 4 - Basic Mobile App with Validation

1. Use quick start to create an empty Mobile App with SQL DB instance

2. Create a new data table

3. Go into insert script and add validation to check length of item.text field

		function insert(item, user, request) {

			if (item.text.length < 5) {
				request.respond(statusCodes.BAD_REQUEST, 'text should be 5 or more characters long');
			}
			else {
				request.execute();
			}
		}

4. Use HTTP tool (Fiddler, Postman, hurl.it) to validate the validation logic works on a POST request.

## Demo 4 - Basic Mobile App with Validation

Logic Apps allow developers to design workflows that start from a trigger and then execute a series of steps. Each step invokes an App Service API app whilst securely taking care of authentication and best practices, like checkpointing and durable execution.

If you want to automate any business process (e.g. find negative tweets and post to your internal slack channel or replicate new customer records from SQL, as they arrive, into your CRM system), Logic Apps makes integrating disparate data sources, from cloud to on-premises easy.

You can create a demo by utilizing "Twitter connector" and "Dropbox connector" from marketplace by following the instructions from this [logic app tutorial](https://azure.microsoft.com/en-us/documentation/articles/app-service-logic-create-a-logic-app/).
