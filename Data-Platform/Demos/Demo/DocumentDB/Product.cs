// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Data_Platform_Demos.DocumentDB
{
	public class Product
	{
		public string ProductId { get; set; }
		public string Name { get; set; }
		public string Line { get; set; }
		public Model Model { get; set; }
		public string Number { get; set; }
		public Review[] Reviews { get; set; }
		public Subcategory Subcategory { get; set; }
	}
}