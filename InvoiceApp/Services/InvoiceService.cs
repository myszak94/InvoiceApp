using System;
using System.Linq;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;

namespace InvoiceApp.Services
{
	public class InvoiceService : IInvoiceService
	{
		private readonly IXmlService xmlService;

		public InvoiceService(IXmlService xmlService)
		{
			this.xmlService = xmlService;
		}

		public Invoice GenerateInvoice(Purchase purchase, PriceList priceList)
		{
			var invoice = new Invoice
			{
				IssueDate = DateTime.Now,
				Purchaser = purchase.Purchaser,
				Supplier = purchase.Supplier,
				Positions = purchase.Positions.OrderBy(x => x.OredrNumber).ToList()
			};

			if (invoice.Positions != null)
			{
				foreach (var invoicePosition in invoice.Positions)
				{
					invoicePosition.Product = priceList.Products.FirstOrDefault(x => x.Id == invoicePosition.ProductId);
				}
			}

			return invoice;
		}
	}
}
