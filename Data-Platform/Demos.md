<a name="title" />
# Microsoft Azure Storage Demos #

---
<a name="Overview" />
## Overview ##
This is a set of demos showing different data related services in the [Microsft Azure Platform](http://azure.microsoft.com/en-us/services/).

**Note:** This module does not cover the [Microsoft Azure Storage](http://azure.microsoft.com/en-us/services/storage/) Service. There is a whole separate module focusing only on Microsoft Azure [Data Storage](..\Data-Storage\Data-Storage.pptx).

<a id="goals" />
### Goals ###
In these demos, you will see how to:

1. Create a SQL Database Server and a SQL Database in the [Azure SQL Database Service](http://azure.microsoft.com/en-us/services/sql-database/).

<a name="setup" />
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Make sure you can sign into [Microsoft Azure Portal](http://portal.azure.com).
2. Make sure you have SSMS (SQL Server Management Studio) installed.
3. Open and run the database script to create a database called AdventureWorksProducts. This is a part of the database AdventureWorks which is one of the [Microsoft SQL Server Database Product Samples](http://msftdbprodsamples.codeplex.com). After running the script you should have the database created in the local server you selected.

<a name="Demo1" />
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

<a name="Demo2" />
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

9. From SSMS connect to a local SQL Server with a demo database.
10. For instance you can use Adventureworks demo database: http://msftdbprodsamples.codeplex.com.
11. What you will need to do in this case is deploy the Azure version of Adventureworks to an Azure Database. Export this database and
 Import the same on premise. Then you can use this on premise version to migrate back to Azure as a demo.
* If you encounter issues with compatibility you can consult the SQL Azure Migration Wizard on CodePlex http://sqlazuremw.codeplex.com/.
* The idea here is to use SSMS to simply fire off a compatible database migration from a SQL Server to Azure SQL Database.
* Right click on the database -> Tasks -> Deploy Database to ‘Windows’ Azure SQL Database.
* Go through the wizard and deploy.
* Using SSMS open up the database in Azure!

<a name="summary" />
## Summary ##

By completing these demos you should have understood how you can leverage Microsoft Azure Storage for your storage needs and access it from your code.