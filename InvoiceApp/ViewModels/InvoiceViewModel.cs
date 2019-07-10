using InvoiceApp.Models;

namespace InvoiceApp.ViewModels
{
	public class InvoiceViewModel : BaseViewJModel
	{
		private Invoice invoice;


		public InvoiceViewModel(Invoice invoice)
		{
			this.invoice = invoice;
		}

		public Invoice Invoice
		{
			get => invoice;
			set
			{
				invoice = value;
				OnPropertyChanged("Invoice");
			}
		}
	}
}
