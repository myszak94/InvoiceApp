using InvoiceApp.Models;

namespace InvoiceApp.Interfaces
{
	public interface IInvoiceService
	{
		Invoice GenerateInvoice(string purchaseFilePath, string priceListFilePath);
	}
}