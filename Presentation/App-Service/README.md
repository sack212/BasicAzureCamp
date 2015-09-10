# Web Demos

## Demo 1 - Creating a Web App

This is a quick demo showing how quickly you can create a new Web App in the portal. Feel free to change alter this first demo.

1. Browse to [Preview Portal](https://portal.azure.com)
1. Click New / Web + Mobile / Web App.
1. Enter a unique name in the URL field and click the Create button.
1. While the site is being created, explain that Azure is provisioning a new Web App for you with supporting services, monitoring, support for continuous deployment, etc.

 > Note: This generally takes 30 - 60 seconds. During this time, you can ask them how long it would take their IT department or hosting provider to provision a new site for them. This us usually enough time for the new Web App to be created.

1. When the site comes up, scroll through the various tiles (Monitoring, Usage, Operations, Deployment, Networking) explaining that these are all live and have been provisioned with the Web App.
1. Click on the Browse button. When the default landing page loads, point out that the page illustrates the different options for publishing to the new site, including Git, FTP, Visual Studio, etc.
1.  Back in the portal, Expand the Essentials panel, click on All Settings and click on Settings. Show that .NET, PHP, Python and Java are all shown.

## Demo 2 - WebJobs

This sample demonstrates creating a WebJob and performing operations with Microsoft Azure WebJobs SDK. The two functions in this example split strings into words (CountAndSplitInWords) and in characters (CharFrequency) and computes their frequencies. The results are stored in Azure Storage Tables.

1. Go to http://portal.azure.com and provision a new free Web App.  

 > Note: You can use the Web App you provisioned in the first demo here.

1. Open File Explorer and navigate to the Presentation\Web\Demo3 - Web Jobs\source\WebJobs folder in the DevCamp material.
1. Open the project in Visual Studio, enable restore packages from nuget and compile (to download all the packages required inside bin directory)
1. Enter a storage account name and key as instructed in App.config.
1. Right-click project, select " Publish as Azure WebJob.." and then select "run on-demand" from the dropdown.
1. Set a connection string named AzureWebJobsDashboard in the Web App configuration in the preview portal by using the following format.  

 > DefaultEndpointsProtocol=https;AccountName=NAME;AccountKey=KEY

1. Find the WebJob under the Web App node in Server Explorer, right-click and select run.
1. Find the storage account in Server Explorer and show the results in queue(textinput) and table(words).
1. Show how to run the WebJob from the Wep App's WebJob setting blade in the portal. Show the log of successful runs.

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










# Azure App Service
Demo Script
## Prerequisites
1. Azure subscription – we will be spinning up an S1 Web App. Although they are relatively inexpensive, make sure you have enough spend in your account to complete the walkthrough.
1. VSO account – we will be using less than 10 build minutes, but you should make sure you have enough spend in your account to accommodate this.
1. Visual Studio Enterprise 2015
## Setup
The following steps must be completed prior to running through the following walkthrough.
### Setup SQL Database
1. In Internet Explorer or Edge, navigate to the Azure Preview Portal and sign in.
2. Click New / Data + Storage / SQL Database.
3. In the SQL Database blade, in the Name text box, enter a name for your database (e.g. MercuryJeffDb.Dev).
4. Click the Server option.

> If you don’t already have a server, you’ll need to create one. If you already have one, feel free to use it and skip the next steps.

5. In the Server blade, click the Create a new server option.
6. In the New server blade, in the Server name text box, enter a unique name (e.g. demosqlscus).
7. Enter your credentials.
8. Select the Location option.
9. In the Location blade, select the same location as the Web App you created previously.
10. In the New server blade, click the OK button.
11. Select the Resource Group option.
12. In the Resource group blade, select the Resource Group you created previously.
13. Click the Create button.
### Download Mercury Health Source Code

> The Mercury Health application source code is available in my VSO instance at https://jeffwork.visualstudio.com.

> If you need permissions to this source code in VSO, email me at jfattic@microsoft.com

### Setup Azure Subscription in VSO
In Internet Explorer or Edge, navigate to your VSO instance (e.g. https://jeffwork.visualstudio.com)
Navigate to your Team Project associated with the Mercury Health source code.
In the upper-right of the page, click the Administer Account (gear icon) button.
Click the Services tab.
In the left-hand navigation pane, click the New Service Endpoint button, and select Azure.
At the bottom-right of the ADD AZURE SUBSCRIPTION dialog box, click the publishsettings xml file hyperlink.
Download your publish settings file and open it in any text editor.
Back in ADD AZURE SUBSCRIPTION dialog box, in the Subscription id text box, paste the Subscription ID from your publishsettings file.
In the Subscription name text box, paste the name of your subscription from your publishsettings file.
In the Subscription certificate text box, paste the long certificate key (just the value between the quotes.
Click the OK button.
Close the browser tab.
### Setup Build Definition

> This walkthrough assumes your VSO Team Project is using TFVC rather than Git. If you want to use Git, you will have to modify the steps as necessary.

In Internet Explorer or Edge, navigate to your VSO instance (e.g. https://jeffwork.visualstudio.com)
Navigate to your Team Project associated with the Mercury Health source code.
From the main menu, click the BUILD menu item.
In the left-hand navigation pane, click the Actions button (green plus sign).
In the DEFINITION TEMPLATES dialog, select the Visual Studio option.
Click the OK button.

> This template sets up the standard build steps: compiling, running unit tests, indexing symbols, and publishing the build output.

Select the Visual Studio Build step.
Next to the Solution text box, click the ellipsis button, and navigate to the MercuryHealth solution file.
In the MSBuild Arguments text box, enter the following: /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:SkipInvalidConfigurations=true /p:OutDir=”$(build.stagingDirectory)”

Select the Visual Studio Test step.

> This step is where we would tell the build engine where to find our tests and which ones to run. At this point, our app isn’t deployed anywhere, so we just want to run our unit tests.

Select the Index Sources & Publish Symbols step.

> When it comes to debugging versions of your application, it can be very advantageous to have indexed source files and then publishing versions of your symbol files to a symbol server location.

Select the Publish Build Artifacts step.

In the Copy Root text box, enter the following: $(Build.StagingDirectory)

In the Contents text box, replace the text with **\*
Click the Add build step… button.

> One of the most exciting aspects of the new build system is the ability to extend it to build, test, and deploy any kind of app on any platform. As you can see, we can add steps to build and sign Android apps, run Grunt tasks, or even build iOS apps on a Mac!

Select the Azure Web App Deployment task.
Click the Close button.
In the Azure Subscription drop down list, select your Azure subscription.
In the Web App Name text box, enter the name of the Web App you created previously.
In the Web App Location text box, enter the location of the Web App you created previously.
In the Slot text box, enter the name of the deployment slot you created previously (dev).
In the Web Deploy Package text box, enter the following: $(Build.StagingDirectory)\**\MercuryHealth.Web.zip
In the menu, click the Repository menu item.
Under the Mappings heading, at the end of the first row, click the ellipsis button, and navigate to the MercuryHealth solution folder.
Remove the second row cloaking the Drops folder.
In the menu, click the Triggers menu item.
Check the box labeled Continuous Integration (CI).
Under the Filters heading, at the end of the first row, click the ellipsis button, and navigate to the MercuryHealth solution folder.
In the toolbar, click the Save button.
## Walkthrough
### Using Azure Portal to Create a Web App (5 minutes)

> This first demo is intended to show how quickly you can create a new Web App in the portal.

In Internet Explorer or Edge, navigate to the Azure Preview Portal and sign in.
Click New / Web + Mobile / Web App.
In the Web App blade, in the App Name text box, enter a unique name.
Use a unique name like ‘MercuryJeff’ or something and take note of the App Name you use because you will need later in the demonstration.
Under the Resource Group option, click the Or Create New hyperlink.
In Azure, you can logically group your application and infrastructure resources into Resource Groups.
In the Resource Group text box, enter any descriptive name (e.g. MercuryHealth).

> Finally, we just need to create or select an App Service Plan. These plans are used to determine the sizing options, features, and, of course, pricing model for our Web Apps.

Click the App Service Plan option and click the Create New button.
In the App Service plan blade, in the App Service plan text box, enter a name (e.g. SCUS_S1)
The most defining property of an App Service plan is the Pricing tier. We want to select an S1 Standard tier so we can check out some of the cool features like Deployment Slots and Auto Scale.
Click the Pricing tier option and select the S1 Standard tier.
In the upper-right of the Choose your pricing tier blade, click the View all hyperlink.
As you can see, there are a lot of options for pricing tiers and prices show are estimates for a month.
Click the Select button.
Click the OK button.
Click the Create button.

> While the site is being created, Azure is provisioning a new Web App for you with supporting services, monitoring, support for continuous deployment, etc.

> This generally takes 30 - 60 seconds. How long it would take your IT department or hosting provider to provision a new site for you?

> You don’t have to wait for the process to finish. You can move on and the site will be ready before we need it.

### Unit Testing (10 minutes)

> Let’s look at an existing ASP.NET application that needs some work. At this point, we are early in the development of a web application that customers can use to track their diet, exercises, and physical measurements.

> We’ve had a lot of regression bugs crop up in our demos to stakeholders, so we’ve been tasked with adding some unit tests.
Open Visual Studio and the MercuryHealth solution from source control.

1. In Solution Explorer, expand the MercuryHealth.Models project, and double-click the MyMetricsViewModel.cs file.

> The CalculateBmr method isn’t especially complicated at first glance, but it’s using some polymorphism to call into the desired derived type and calculate the number of calories a person burns by just doing nothing all day.

2. Right-click within the CalculateBmr method, and select Run IntelliTest.

> In the IntelliTest Exploration Results pane, each of these rows corresponds to a unit test that Visual Studio generated as it explored the logic branches in our code. While this looks like a decent set of tests, we actually have some warnings that we need to look into.

3. In the IntelliTest Exploration Results toolbar, click Warnings button.

> As you can see, we have a bunch of boundary warnings indicating that IntelliTest was timing out as it explored our code. The first warning, about the DateTime, is our problem. Code depending on DateTime.Now is problematic when we unit test because the results may not be consistent between test runs – which is exactly what’s happening here. This is where mocking frameworks come into play.

> First, let’s switch back to our tests and save them in a unit test project.

4. Click the Warnings button.
5. Click the Save button.
6. Clicking Save tells Visual Studio to emit those rows of tests into unit tests.
7. In Solution Explorer, select the MyMetricsViewModelTest.cs file.

> This generated code is what we call a Parameterized Unit Test. It’s simply how our other unit tests will call our method under test. As you recall, we need to mock out DateTime in order for us to unit test here.

8. In Solution Explorer, under the MercuryHealth.Models.Tests project, expand the References node.
9. Right-click the reference to MercuryHealth.Models, and select Add Fakes Assembly.
10. In the CalculateBmr method, add the following lines of code highlighted in green:
using (Microsoft.QualityTools.Testing.Fakes.ShimsContext.Create())
{
    Fakes.ShimMemberProfile.AllInstances.CalculateAgeDateTime = (self, birthdate) => 25;

    double result = target.CalculateBmr(calculatorOption, profile);
    return result;
    // TODO: add assertions to method MyMetricsViewModelTest.CalculateBmr(MyMetricsViewModel, BmrCalculatorOption, MemberProfile)
}
11. Open MyMetricsViewModel.cs file.
12. Right-click within the CalculateBmr method, and select Run IntelliTest.

> We still get a single warning that you can Suppress if you want, but it’s an inconsequential warning that will be removed by a future product update.

> We still have several failing unit tests due to null reference and argument exceptions. To save time, we’ll select each of these and click the Allow button which tells IntelliTest that these are expected exception if someone passes in a null profile or an invalid gender value. We’ll then re-run IntelliTest one last time.

13. Hold down the Ctrl key and select each of the failing tests.
14. In the toolbar, click the Allow button.
### Add Monitoring (5 minutes)
1. Right-click MercuryHealth.Web project and select Add Application Insights Telemetry… from the context menu.
2. Click the Configure settings… button.
3. In the Resource Group combo box, enter MercuryHealth.Web.Insights
In the Application Insights Resource combo box, enter MercuryHealth.Web.Dev
Click the OK button.
Click the Add button.
Open the Cloud Explorer pane.
Expand the Web Apps node, right-click the Web App you created previously, and select Open in Portal.
If the blade for the Web App you created previously isn’t visible, you need to click the Browse All button and locate it.

> Our Web App is ready to go. This column of information in the portal can be used to monitor and manage your application. Note that we have a tile for Monitoring requests and errors, we can set alerts and so much more.

> We’ve already added the App Insights to our application and that will get us most of the data we need, but let’s also add the agent in and get as many data points as we can!

In the toolbar, click the Tools button.
In the Tools blade, click Extensions.
In the Installed web app extensions blade, in the toolbar, click the Add button.
In the Add web app extension blade, click the Choose Extension option.
In the Choose web app extension, select Application Insights.
In the Accept legal terms blade, click the OK button.
In the Add web app extensions blade, click the OK button.
### Set Auto-Scale (2 minutes)
1. Click the tile labeled Scale.
2. In the Scale setting blade, in the Scale by drop down list, select CPU Percentage.
3. Leave the Instances slider set to 1.
4. Set the Target range slider to 3.
5. In the toolbar, click the Save button.
### Create Deployment Slot (2 minutes)
1. Return to your Web App’s blade.
2. Click the tile labeled Deployment slots.
3. In the Deployment slots blade, in the toolbar, click the Add Slot button.
4. In the Add a slot blade, in the Name text box, enter dev
5. Click the OK button.
### Set Application Settings (2 minutes)
1. In the Deployment slots blade, click the Deployment Slot you just created.
2. In the Web App blade for your new deployment slot, in the toolbar, click the Settings button.
3. In the Settings blade, click Application settings.
4. In the Application settings blade, under Connection strings section, click the Show connection strings button.
5. In the first text box, enter DefaultConnection
6. In the second text box, paste the connection string to your SQL Database.
7. In the drop down list, select SQL Database.
8. Check the box labeled Slot setting.
9. In the toolbar, click the Save button.
### Check In (1 minutes)

> Let’s check in our changes. Our check-in is wired up for Continuous Integration, so we will automatically kick off a build.

1. Back in Visual Studio, in Solution Explorer, right-click the solution, and select Check In…
2. In the Team Explorer pane, click the Check In button.
### Build (1 minutes)

> Let’s zip over to our build and see how things are going

1. In the Team Explorer pane, in the toolbar, click the Home button.
2. Click the Builds button.
3. Under My Builds, double-click the first build.
### Deploy (1 minute)

> The automated builds are great at compiling code, running unit tests, and packaging up an application. I would prefer to deploy and configure my applications from Release Management, but this is a simple demo. Here, you can see our build will actually deploy to an Azure Web App.

### Test (1 minute)

> We could add steps to our build that would run automated functional tests, load tests, etc.

### Track Down Issue (10 minutes)

> Let’s add an apple to our nutrition log so we can verify it works.

1. Back in the Preview portal, be sure you are looking at the blade for your Web App’s Deployment Slot.
2. Click the URL to navigate to your web app.
3. In the navigation menu, click the Nutrition menu item.
4. Click the Create New hyperlink.
5. In the Quantity text box, enter 1
6. In the Description text box, enter Apple
7. In the MealTime text box, enter today’s date (e.g. 8/25/2105)
8. In the Calories text box, enter 1
9. In the ProteinInGrams text box, enter 1
10. In the FatInGrams text box, enter 1
11. In the CarbohydratesInGrams text box, enter 1
12. In the SodiumInGramstext box, enter 1
13. Click the Create button.

> Let’s put some more data in. We’ll just add another apple to keep it easy.

14. Click the Create New hyperlink.
15. In the Quantity text box, enter 1
16. In the Description text box, enter Apple
17. In the MealTime text box, enter today’s date (e.g. 8/25/2105)
18. In the Calories text box, enter 1
19. In the ProteinInGrams text box, enter 1
20. In the FatInGrams text box, enter 1
21. In the CarbohydratesInGrams text box, enter 1
22. In the SodiumInGramstext box, enter 1
23. Click the Create button.

> Hmmm… We expected to see two entries for Apple, but we don’t. There were no obvious errors, but we didn’t set up Application Insights for nothing, so let’s go see if it can help us.

24. Back in the Preview portal, in the left-hand navigation pane, click the BROWSE ALL button.
25. In the Browse blade, click Application Insights.
26. In the Application Insights blade, click the Application Insights instance.

[PROBLEM: For some reason, the exception isn’t showing up in App Insights like I was expecting it to.]

> Let’s try to reproduce this ourselves in Visual Studio locally.

Back in Visual Studio, click F5 to debug the application.
In the navigation menu, click the Nutrition menu item.
Click the Create New hyperlink.
In the Quantity text box, enter 1
In the Description text box, enter Apple
In the MealTime text box, enter today’s date (e.g. 8/25/2105)
Click the Create button.
Click the Create New hyperlink.
In the Quantity text box, enter 1
In the Description text box, enter Apple
In the MealTime text box, enter today’s date (e.g. 8/25/2105)
Click the Create button.
In the Visual Studio toolbar, click the Break All button (pause button).
In the Diagnostics Tools pane, click the red Exception event.
In the Events tab, click the Activate Historical Debugging hyperlink.
This takes us right to the offending line of code where we can see someone is logging any exceptions, but they aren’t reflecting anything back to the user.
Hopefully, you’ve seen how we can decide on our fix for this issue, check in the code and get it built, tested, and deployed in just a couple more minutes.

