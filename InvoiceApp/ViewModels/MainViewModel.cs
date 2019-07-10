using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;

namespace InvoiceApp.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public MainViewModel()
		{
			IsPriceListFileLoaded = false;
			IsPurchaseFileLoaded = false;
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
		private string purchaseFilePath;
		private string priceListFilePath;


		protected void OnPropertyChanged(string name)
		{
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(name));
		}


	}
}
