using InvoiceApp.Models;

namespace InvoiceApp.Services
{
	public interface IInvoiceService
	{
		Invoice GenerateInvoice(string purchaseFilePath, string priceListFilePath );
	}
}