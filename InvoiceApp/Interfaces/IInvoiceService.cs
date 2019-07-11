using InvoiceApp.Models;

namespace InvoiceApp.Interfaces
{
	public interface IInvoiceService
	{
		Invoice GenerateInvoice(Purchase purchase, PriceList priceList);
	}
}