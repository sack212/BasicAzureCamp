# Web Demos

## Demo 1 - Hello Worlds

This demo shows all of the very many ways you can run code (OOTB) by default in Azure Websites.

### Prerequisites

1. Go to http://portal.azure.com and provision a new free web site.
1. Open File Explorer and copy and paste the ftp host name into the adress bar. You will be prompted to sing in. The ftp user name is also found in the portal ({websitename}\{username}). The password can be set by you in the portal.
1. Navigate to the folder site/wwwroot/. There should be one .html file in this folder corresponding to the default Website page for an empty slot.
1. Open another File Explorer and place them next to each other on screen. In this second File Explorer navigate to the Presentation\Web\Demo1 - Hello All Worlds\source\HelloAllWorlds folder in the DevCamp material.
1. Below in Demo 1 you can now copy all of the files from File Explorer to File Explorer -> from your local disk to the Cloud Website simply by selecting all the files and dropping them on the website.

(An alternative here is to use the FTP client of your choosing but the effect is the same.)

### Demo

1. In the Azure Preview Portal, create a new Azure Website. 
1. Expand the site, scroll to Configuration and click on Settings. Show that .NET, PHP, Python and Java are all shown.
1. "I've already created another site and connected using an FTP client." Show the Prerequisite web site. If you like you can even edit the .html page on the site to prove that it is indeed the live site!
1. Show the two File Explorer windows from the Prerequisites and explain that one is local disk while the other is the FTP Connection to the live Website.
1. Copy the contents of the source directory into the /site/wwwroot.
1. Browse to the site and click through the index page to the samples running on the various platforms.

## Demo 2 - Redis Cache Demo

This demo shows using Redis Cache to make 

> Setup for this demo takes up to 3 hours for the CacheFill project to run.

### Prerequisites

1. Create 2 Redis cache services on Azure
1. Ensure redis cache services have enabled "NON-SSL PORT" - 6379 . This feature is disabled by default.
1. Add each Redis Cache Server connection details to:

	* CustomerQuery web.config
	* CacheFill app.config

1. Add Azure Storage connection string to:

	* CustomerQuery web.config
	* CacheFill app.config

1. Run CacheFill and follow the  instructions!

### Demo

1. Run the application.
1. Check the "Directly Search Table" checkbox.
1. Type a capital letter in the search field and click search. While the search is running (takes roughly 25 seconds) explain that the application is querying against 1 million un-indexed rows in table storage.
1. Uncheck the "Directly Search Table" checkbox and run the search again. Search completes in under 2 seconds because it's querying against an indexed Redis cache.
