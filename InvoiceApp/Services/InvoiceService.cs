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

		public Invoice GenerateInvoice(string purchaseFilePath, string priceListFilePath)
		{
			var purchase = xmlService.SerializeFile<Purchase>(purchaseFilePath);
			var priceList = xmlService.SerializeFile<PriceList>(priceListFilePath);

			var invoice = new Invoice
			{
				IssueDate = DateTime.Now,
				Purchaser = purchase.Purchaser,
				Supplier = purchase.Supplier,
				Positions = purchase.Positions
			};

			foreach (var invoicePosition in invoice.Positions)
			{
				invoicePosition.Product = priceList.Products.FirstOrDefault(x => x.Id == invoicePosition.ProductId);
			}

			return invoice;
		}
	}
}
