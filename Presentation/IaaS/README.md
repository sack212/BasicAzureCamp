# Azure IaaS
Demo Script
## Prerequisites
Azure subscription – You can use any type of Azure subscription (an MSDN subscription, a Pay-As-You-Go subscription, etc.)
VSO account – we will be using less than 10 build minutes, but you should make sure you have enough spending in your account to accommodate this. Sign up for a VSO account here.
Visual Studio Enterprise 2015
PowerShell Tools for Visual Studio 2015
Azure SDK – The Azure SDK for VS 2015 can be found here.
## Setup
### Setup local PowerShell environment
1. Open a PowerShell command prompt as an administrator.

> We need to first override the default Windows PowerShell execution policy.

2. Enter **Set-ExecutionPolicy –ExecutionPolicy RemoteSigned** and press the **Enter** key.
3. When prompted, enter **y** and press the **Enter** key.
Next, we’ll import the Azure module, and run the command to fetch our Azure subscription’s publish settings file. 
Enter Import-Module Azure and press the Enter key.
Enter **Get-AzurePublishSettingsFile** and press the **Enter** key.
Sign in using the credentials associated with the desired Azure subscription.
Save the publish settings file to **C:\Developer Files** and rename it to **MyPublishSettings.publishsettings**.
Enter **Import-AzurePublishSettingsFile –PublishSettingsFile “C:\Developer Files\MyPublishSettings.publishsettings”** and press the **Enter** key.

> You can run Get-AzureSubscription to confirm that this worked correctly.

## Walkthrough
### Create Virtual Machine (5 minutes)
In **Internet Explorer** or **Edge**, navigate to https://portal.azure.com.
In the left-hand navigation pane, click the **NEW** button.
In the **Create** blade, click **Compute**.
In the **Compute** blade, click **Marketplace**.

> As you can see, we have a huge array of options ranging from Windows Server to Ubuntu, from Chef Server to Oracle, and many more!

> We just want to create a standard IIS web server, so we’ll search for Windows servers.

In the **Compute** blade, in the search text box, enter 2012 datacenter
Select **Windows Server 2012 R2 Datacenter**.
In the **Windows Server 2012 R2 Datacenter** blade, in the **Select a deployment model** dropdown list, select **Resource Manager**.
Click the **Create** button.
In the **Basics** blade, in the Name text box, enter a unique name (e.g. JeffIaaSOneVm).
In the **User name** text box, enter the local administrator user name.
In the **Password** text box, enter a password for the local administrator account.
In the **Resource Group** text box, enter a name (e.g. JeffIaaSOneRg).
Click the **Location** option.

> One of the nicest things about Azure is the number of datacenters allow you to create resources close to your end users without having to build your own multi-million dollar datacenter.

In the **Location** blade, select **Central US**.
Click the **OK** button.
In the **Choose a size** blade, click the **View all** hyperlink.

> You can see there a wide range of size options. Maybe you want a shared core just for dev / test purposes or maybe you need a SQL server with 32 cores. Maybe IO is a bigger concern and you need a local SSD.

> Note the prices are listed with each option. These are undiscounted charges if you run the VM non-stop for an average month. You only pay for every minute that you have the machine up and running, so it will be much cheaper if you shut machines down outside of business hours for example.

> For this demo, we’ll just select a an A3 from the list.

Select **A3 Standard**.
Click the **Select** button.

> There are a lot more options for further configuring your machine. You can add it to a virtual network extending your datacenter or set it an availability set for redundancy.

Make note of the storage account name as we’ll need that later.
In the **Settings** blade, click the **OK** button.
In the **Summary** blade, click the **OK** button.

> This will only take a minute or two, but we’ll jump into Visual Studio and show you a bit more from a developer’s perspective.

### Create Web App (5 minutes)
1. Open **Visual Studio 2015**.
2. In the main menu, click **File | New | Project…**
3. In the **New Project** dialog, under the Installed pane, select **Visual C# | Web**.
4. In the middle pane, select **ASP.NET Web Application**.
5. In the right-hand pane, check the box labeled **Add Application Inisghts to Project**.
6. In the **Name** text box, enter a unique name (e.g. JeffIaaSOne).
In the **Location** text box, enter c:\DeleteMe
7. Uncheck the box labeled **Add to source control**.
8. Click the **OK** button.
9. In the **New ASP.NET Project** dialog, select the **MVC** template.
10. Check the box labeled **Host in the Cloud and select Virtual Machine (v2)** from the drop down list.
11. Click the **OK** button.
