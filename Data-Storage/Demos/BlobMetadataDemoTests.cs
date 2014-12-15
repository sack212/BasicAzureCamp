using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

// ReSharper disable ConvertToConstant.Local
// ReSharper disable RedundantAssignment

namespace Data_Storage_Demos
{
	[TestClass]
	public class BlobMetadataDemoTests
	{
		const string ContainerName = "democontainer";
		const string BlobName = "testblob.txt";

		[ClassInitialize]
		public static void ConnectToStorage(TestContext context)
		{
			var connectionString = ConfigurationManager.ConnectionStrings["Azure Storage Account Demo Primary"].ConnectionString;
			
			CloudStorageAccount cloudStorageAccount;
			
			if(!CloudStorageAccount.TryParse(connectionString, out cloudStorageAccount))
			{
				Assert.Fail("Expected connection string 'Azure Storage Account Demo Primary' to be a valid Azure Storage Connection String.");
			}
			
			var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

			var cloudBlobContainer = cloudBlobClient.GetContainerReference(ContainerName);

			// Note: This line of code does not always have to be executed when you 'know' the storage item exists.
			cloudBlobContainer.CreateIfNotExists();
			cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(BlobName);
		}

		const string SampleMetadataKey = "this_is_metadata";
		const string SampleMetadataValue = "This works fine!";
		const string SampleMetadataValue2 = "This contains Swedeish characters and must be encoded ÅÄÖ!";

		static CloudBlockBlob cloudBlockBlob;

		[TestMethod]
		public void UploadBlob()
		{
			cloudBlockBlob.DeleteIfExists();

			if (cloudBlockBlob.Metadata.ContainsKey(SampleMetadataKey))
			{
				cloudBlockBlob.Metadata.Remove(SampleMetadataKey);
			}

			var metadataValue = SampleMetadataValue;
			//var metadataValue = SampleMetadataValue2;
			//var metadataValue = SampleMetadataValue2.ToBase64String();
			cloudBlockBlob.Metadata.Add(new KeyValuePair<string, string>(SampleMetadataKey, metadataValue));

			cloudBlockBlob.UploadText(string.Empty);

			Assert.IsTrue(cloudBlockBlob.Exists());
		}

		[TestMethod]
		public void DownloadBlob()
		{
			var expectedMetadataValue = SampleMetadataValue;
			expectedMetadataValue = SampleMetadataValue2;

			Assert.IsTrue(cloudBlockBlob.Exists(), "Run the other test first to create the blob with metadata.");

			cloudBlockBlob.FetchAttributes();

			var metadatavalue = cloudBlockBlob.Metadata[SampleMetadataKey];
			//metadatavalue = metadatavalue.FromBase64String();

			Assert.AreEqual(expectedMetadataValue, metadatavalue);
		}
	}
}