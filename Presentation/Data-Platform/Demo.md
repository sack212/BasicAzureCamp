<a name="title"></a>
# Microsoft Azure Storage Demos #

---
<a name="Overview"></a>
## Overview ##
This is a set of demos showing different data related services in the [Microsft Azure Platform](http://azure.microsoft.com/en-us/services/).

**Note:** This module does not cover the [Microsoft Azure Storage](http://azure.microsoft.com/en-us/services/storage/) Service. There is a whole separate module focusing only on Microsoft Azure [Data Storage](..\Data-Storage\Data-Storage.pptx).

<a id="goals" />
### Goals ###
In these demos, you will see how to:

1. Create a SQL Database Server and a SQL Database in the [Azure SQL Database Service](http://azure.microsoft.com/en-us/services/sql-database/).

<a name="setup"></a>
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Make sure you can sign into [Microsoft Azure Portal](http://portal.azure.com).
2. Make sure you have SSMS (SQL Server Management Studio) installed.
3. Open and run the database script to create a database called AdventureWorksProducts. This is a part of the database AdventureWorks which is one of the [Microsoft SQL Server Database Product Samples](http://msftdbprodsamples.codeplex.com). After running the script you should have the database created in the local server you selected.

<a name="Demo1"></a>
## Demo 1) Creating A SQL Database Server and a SQL Database ##

In this dem you will use the new Azure Portal (Ibiza) to create a new database server.

1. Log into [http://portal.azure.com](http://portal.azure.com)
2. Click on “new +” in the bottom left corner and select SQL Database.
3. Enter Database name and select source -> Blank database.
4. Open up Pricing Tier and “Browse all pricing tiers”. Show the tiers and then select one. For instance “Basic”!
5. Click on Server and enter a name. Point out that the old (current) portal does not allow you to specify your own name for the server.
6. Enter the data you wish for server.
7. Click Create and let it create.
8. Show the database. Also click on properties and show the connection strings.

> **Speaking point:** In this way or with command-line tools like PowerShell and xplat-cli you can create and manage any number of databases in a matter of seconds. [Azure Command-line Tools](http://azure.microsoft.com/en-us/downloads/)

<a name="Demo2"></a>
## Demo 2) Connect from on premise and deploy your database ##

Using the same database server from before…

1. Back in the portal with the database from last demo, click on “Open in Visual Studio” and firewall. Show that it’s work in progress here.
2. Go to the old portal and configure firewall based on current IP. Reload this in the new portal and see the firewall rule there.
3. Click Open in Visual Studio and show the database from Visual Studio.
4. Open SSMS (SQL Server Management Studio) and the connect dialog. (Note: It’s probably a good idea to run at least SQL Server Developer Edition on your local machine.)
5. Back in the portal again reopen the connection strings. This is a good place to find the exact credentials to connect to  your database!
6. In the connection string for ADO.NET copy your server name from the Server property “Server=tcp:{your server name},1433” and paste as Server name in SSMS.
7. Copy the User Id from the connection string “Username@Servername” and paste as Login in SSMS.
8. Type the password and connect.

> **Speaking point:** It is pretty much the same experience as before only now the databases are in the Cloud!

9. From SSMS connect to a local SQL Server with the demo database.
10. For instance you can use Adventureworks demo database: http://msftdbprodsamples.codeplex.com.
11. Right click on the database and choose Tasks -> "Deploy Database to Windows Azure SQL Database...". This is a very short wizard which will deploy the whole thing to Azure!

> **Speaking point:** The tool [SQL Azure Migration Wizard](http://sqlazuremw.codeplex.com) is an amazing tool to analyze databases for compatibility with Azure!

12. Using SSMS open up the database in Azure!

<a name="Demo3"></a>
## Demo 3) DAC Deployment From SQL Server Management Studio ##

Use SSMS to deploy DAC pack to previously provisioned database server.

**Preparation:**

   * In SSMS right-click your database and choose -> Tasks -> Extract data-tier application.
   * Follow the wizard to export your .dacpac.

Demo:

1. In SSMS connect to your SQL Database Server in Azure.
2. Right click “Databases” -> “Deploy data-tier Application…”.
3. Follow the wizard and select your .dacpac.
4. Deploy the database.

You now have a database in Azure but no data deployed to it. In order to do that instead use a .bacpac

<a name="Demo4"></a>
## Demo 4) Standing up a SQL Server in Azure using Marketplace ##

1. Use [http://portal.azure.com](http://portal.azure.com)
2. Enter Marketplace.
3. Select Data -> SQL Server -> Any SQL VM you like. For example “SQL Server 2012 SP2 on Windows Server 2012”. Click create.
4. Show Pricing tier (including all pricing tiers) and other creation options and settings.
5. Deploy it!

(Don’t forget to delete it or at least stop it later to reduce cost on your Azure account.)

> **Speaking point:** There are other fully supported options for SQL Storage in Azure, including Oracle and MySQL. These can all be viewed in the Marketplace.

<a name="Demo5"></a>
## Demo 5) View Document DB in the Preview Management Portal and create data using code ##

1. Use [http://portal.azure.com](http://portal.azure.com)
2. Create a new DocumentDB and view it.
3. Show Keys, Scale and Configuration.
4. Open up the Developer Tools:
    * Document Explorer
    * Query Explorer
5. In the Visual Studio demo solution open the class DocumentDBDemoTests and run the unit tests there sequentially while explaining what happens. Some of the tests fetch data from our SQL database Adventure Works which we have used previously. You might want to pull that data from your on premise SQL Server instance rather than from the SQL Database version which will be faster.
    * CreateDatabaseAndCollection() - Creates a database and a collection. There is console output which can be commented.
    * CreateData_Sequentially() - Get 504 documents and start creating them sequentially. This will take a long time! So after a brief time stop execution and explain that this takes too long to do sequentially. Go back to the portal and view these documents.
    * CreateStoredProcedure() - Create a stored procedure in the collection for bulk insertions.
    * DeleteAllDocuments() - Delete the previously created documents again. (The proc does not support inser/replace or upsert only clean insert of items that are not pre-existing.)
    * BulkInsert() - Run bulk insertions of 50 docs at a time. Some times there is a throttle error (usually when inserting the last four doc because they come so quickly after the last 50 batch). This does not always happen though. If it does there will be a retry. Look at the console output.
    * QueryData() - Room to run any query you like. Can also be demoed in the portal Query explorer. Example SELECT * FROM c where c.Reviews != null.
    * DeleteDatabase() - Delete the data, collection and database.

<a name="Demo6"></a>
## Demo 6) Azure Search walk through ##

* There are slides in the deck which are a walk through of the basic features of Azure Search.
* Also show Azure Search in the portal: [http://portal.azure.com](http://portal.azure.com)
<a name="summary"></a>
## Summary ##

By completing these demos you have shown how you can leverage the Microsoft Azure Data Platform.