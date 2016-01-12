# IaaS Demos

## Demo 1 - Provisioning a VM

1. Open Azure portal and click the **NEW** button at the upper-left corner.
2. Click on **See All** in New section. Select **Compute** in Marketplace. Navigate to Recommended resources in Compute section.
3. open the **Windows Server** category.
4. Scroll down the view and show images of different types.
5. Click on **Windows Server 2012 R2 Datacenter**, and select deplpoyment model as **Resource Manager** then click the **Create** button in the overview blade. For non-Microsoft focused audience, consider searching any Linux image in the search box instead.
6. Fill in the **Basics**, **Size**, **Settings** form and click on the **OK** button in the **Summary** section to provision the VM. Explain this will take a few minutes.
7. Open the already provisioned VM.
8. Scroll down the blade to show various of information available on the blade.
9. Click on the **Extensions** tile. 
10. On the Extensions blade, click on the **ADD** icon to bring up the extension list. Introduce that VM extensions are installable components to customize VM instances. 
11. Switch to slides to continue with VM extension introduction.

## Demo 2 - VM Extension 

1.	In Azure PowerShell, issue command: **Get-AzureVMAvailableExtension | Format-Table -Property ExtensionName, Publisher**
2.	The above cmdlet lists existing extensions. Next we’ll see how we can inject an extension to a running VM instance. In the last demo you’ve seen that you can achieve this using Azure Management Portal. Here we’ll do it using PowerShell. In this case, we’ll install Custom Script Extension to an existing Windows Server 2012 VM.
3.	Issue the following cmdlets to get a reference to the virtual machine instance:
      **$serviceName = “[cloud service that hosts the VM]”**
      **$vmName = “[name of the VM]”**
      **$vm = Get-AzureVM -ServiceName $serviceName -Name $vmName**
4.	Next, issue command **Get-AzureVMExtension -VM $vm**. This lists VM extensions that are currently installed on the VM.
5.	Use the following cmdlet to enable Custom Script Extension, and instruct it to download and execute the helloworld.ps1 (this takes about 20-30 seconds):
**Set-AzureVMCustomScriptExtension -ContainerName scripts -StorageAccountName '[your storage account name]' -VM $vm -FileName ‘helloworld.ps1' -Run ‘helloworld.ps1' | Update-AzureVM -Verbose**
6. Next, we’ll retrieve and display the script execution result:
**$status = Get-AzureVM -ServiceName $serviceName -Name $vmName**
**$result = $status.ResourceExtensionStatusList.ExtensionSettingStatus.SubStatusList | Select Name, @{"Label"="Message";Expression = {$_.FormattedMessage.Message }}** 
**$result |fl**
(see screenshots in hidden slides for references)

([see this blog post](http://azure.microsoft.com/blog/2014/07/15/automating-sql-server-vm-configuration-using-custom-script-extension/) for more details on Custom Script Extension)

### Prerequisites

- Azure PowerShell v0.8 or higher has been installed and configured.
-	Desired Azure subscription has already been selected. 
-	A storage account has been provisioned under the same Azure subscription.
-	A **scripts** container has been created under the storage account with public read access.
-	A **helloworld.ps1** PowerShell script has been uploaded to the container. The content of the script is a single line: **write-output “Hello World!”**
-	PowerShell environment has been set with large font for easy reading.
-	A Windows Server 2012 VM has been provisioned.
