using System.Collections.Generic;

namespace InvoiceApp.Models
{
	public class Purchase
	{
		public Purchaser Purchaser { get; set; }
		public Supplier Supplier { get; set; }
		public List<Position> Positions { get; set; }
	}
}
