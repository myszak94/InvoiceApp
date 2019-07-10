using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using InvoiceApp.Enums;
using InvoiceApp.Interfaces;
using InvoiceApp.Models;
using InvoiceApp.Services;
using InvoiceApp.Views;
using Microsoft.Win32;

namespace InvoiceApp.ViewModels
{
	public class MainViewModel : BaseViewJModel
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
					//var purchase = new Purchase();
					//purchase.Purchaser = new Purchaser
					//{
					//	Name = "Apteka Zdrowie",
					//	Address = "Piotrowo 88, 61-138 Poznań"
					//};
					//purchase.Supplier = new Supplier()
					//{
					//	Name = "Magazyn centralny",
					//	Address = "ul. Słoneczna 50, 00-000 Warszawa"
					//};
					//purchase.Positions = new List<Position>
					//{
					//	new Position
					//	{
					//		ProductId = 17,
					//		OredrNumber = 1,
					//		Count = 1
					//	},

					//	new Position
					//	{
					//		ProductId = 21,
					//		OredrNumber = 2,
					//		Count = 2
					//	}
					//};
					
					//var priceList = new PriceList();
					//priceList.Products = new List<Product>
					//{
					//	new Product
					//	{
					//		Id = 1,
					//		NettoPrice = 10,
					//		VatRate = VatRate.Vat23
					//	},
					//	new Product
					//	{
					//		Id = 17,
					//		NettoPrice = 20,
					//		VatRate = VatRate.Vat23
					//	},
					//	new Product
					//	{
					//		Id = 21,
					//		NettoPrice = 30,
					//		VatRate = VatRate.Vat5
					//	}

					//};

					//xmlService.CreateXmlFile(purchase, "Purchase");
					//xmlService.CreateXmlFile(priceList, "PriceList");

					var invoiceView = new InvoiceView(new InvoiceViewModel());
					var invoice = invoiceService.GenerateInvoice(PurchaseFilePath, PriceListFilePath);
					var invoiceName = $"{invoice.IssueDate:yy-MM-dd}_{invoice.Purchaser.Name}";
					xmlService.CreateXmlFile(invoice, invoiceName);

					invoiceView.ShowDialog();
				});

				return generateInvoiceCommand;
			}
		}

		#endregion

		public event PropertyChangedEventHandler PropertyChanged;

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
