using System;
using System.Collections.Generic;
using System.Linq;
namespace InvoiceApp.Models
{
	public class Invoice
	{
		public DateTime IssueDate { get; set; }
		public Purchaser Purchaser { get; set; }
		public Supplier Supplier { get; set; }
		public List<Position> Positions { get; set; }

		public decimal Summary => Positions.Sum(x => x.Sum);
	}
}
