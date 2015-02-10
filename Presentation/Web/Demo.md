# Web Demos

## Demo 1 - Hello Worlds

1. In the Azure Preview Portal, create a new Azure Website. 
1. Expand the site, scroll to Configuration and click on Settings. Show that .NET, PHP, Python and Java are all shown.
1. "I've already created another site and connected using an FTP client."
1. Copy the contents of the source directory into the /site/wwwroot.
1. Browse to the site and click through the index page to the samples running on the various platforms.

## Demo 2 - Redis Cache Demo

> Setup for this demo takes up to 3 hours for the CacheFill project to run.

1. Run the application.
1. Check the "Directly Search Table" checkbox.
1. Type a capital letter in the search field and click search. While the search is running (takes roughly 25 seconds) explain that the application is querying against 1 million un-indexed rows in table storage.
1. Uncheck the "Directly Search Table" checkbox and run the search again. Search completes in under 2 seconds because it's querying against an indexed Redis cache.

### Prerequisites

1. Add Redis Cache Server connection details to:
	
	* CustomerQuery	
		* HomeController.cs
		* AutoCompleteController.cs
		* ProductAutoCompleteController.cs
	* CacheFill
		* Program.cs

2. Add Azure Storage connection string to:
	
	* CustomerQuery
		* HomeController.cs
	* CacheFill
		* Program.cs  