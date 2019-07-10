using InvoiceApp.Enums;

namespace InvoiceApp.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal NettoPrice { get; set; }
		public VatRate VatRate { get; set; }
		public decimal BruttoPrice => (1 + (int)VatRate / 100.0m) * NettoPrice;
	}
}
