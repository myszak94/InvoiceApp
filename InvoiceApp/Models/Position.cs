namespace InvoiceApp.Models
{
	public class Position
	{
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int OredrNumber { get; set; }
		public int Count { get; set; }
		public decimal Sum => Count * Product.BruttoPrice;
	}
}
