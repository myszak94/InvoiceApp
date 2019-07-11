using System.Windows.Input;
using InvoiceApp.Interfaces;
using InvoiceApp.Services;
using InvoiceApp.Views;
using Microsoft.Win32;

namespace InvoiceApp.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private readonly IInvoiceService invoiceService;
		private readonly IXmlService xmlService;

		public MainViewModel(IInvoiceService invoiceService, IXmlService xmlService)
		{
			IsPriceListFileLoaded = false;
			IsPurchaseFileLoaded = false;

			this.invoiceService = invoiceService;
			this.xmlService = xmlService;
		}

		#region Commands

		public ICommand LoadPurchaseCommand
		{
			get
			{
				if (loadPurchaseCommand != null)
					return loadPurchaseCommand;

				loadPurchaseCommand = new DelegateCommand(o =>
				{
					var openFileDialog = new OpenFileDialog { Filter = XmlFilter };
					if (openFileDialog.ShowDialog() == true)
					{
						PurchaseFilePath = openFileDialog.FileName;
						IsPurchaseFileLoaded = true;
						OnPropertyChanged("AreFilesLoaded");
					}
				});

				return loadPurchaseCommand;
			}
		}

		public ICommand LoadPriceListCommand
		{
			get
			{
				if (loadPriceListCommand != null)
					return loadPriceListCommand;

				loadPriceListCommand = new DelegateCommand(o =>
				{
					var openFileDialog = new OpenFileDialog { Filter = XmlFilter };

					if (openFileDialog.ShowDialog() == true)
					{
						PriceListFilePath = openFileDialog.FileName;
						IsPriceListFileLoaded = true;
						OnPropertyChanged("AreFilesLoaded");
					}
				});

				return loadPriceListCommand;
			}
		}

		public ICommand GenerateInvoiceCommand
		{
			get
			{
				if (generateInvoiceCommand != null)
					return generateInvoiceCommand;

				generateInvoiceCommand = new DelegateCommand(o =>
				{
					var invoice = invoiceService.GenerateInvoice(PurchaseFilePath, PriceListFilePath);
					var invoiceView = new InvoiceView(new InvoiceViewModel(invoice));

					var invoiceName = $"{invoice.IssueDate:yy-MM-dd}_{invoice.Purchaser.Name}";
					xmlService.CreateXmlFile(invoice, invoiceName);

					invoiceView.ShowDialog();
				});

				return generateInvoiceCommand;
			}
		}

		#endregion

		public string PurchaseFilePath
		{
			get => purchaseFilePath;
			set
			{
				purchaseFilePath = value;
				OnPropertyChanged("PurchaseFilePath");
			}
		}

		public string PriceListFilePath
		{
			get => priceListFilePath;
			set
			{
				priceListFilePath = value;
				OnPropertyChanged("PriceListFilePath");
			}
		}

		public bool AreFilesLoaded => IsPurchaseFileLoaded && IsPriceListFileLoaded;

		private const string XmlFilter = "eXtensible Markup Language file|*.xml;";
		private bool IsPurchaseFileLoaded { get; set; }
		private bool IsPriceListFileLoaded { get; set; }
		private DelegateCommand loadPurchaseCommand;
		private DelegateCommand loadPriceListCommand;
		private DelegateCommand generateInvoiceCommand;
		private string purchaseFilePath;
		private string priceListFilePath;
	}
}
