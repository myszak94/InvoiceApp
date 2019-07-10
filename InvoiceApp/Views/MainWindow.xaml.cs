using System.Windows;
using InvoiceApp.Services;
using InvoiceApp.ViewModels;


namespace InvoiceApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var xmlService = new XmlService();

			DataContext = new MainViewModel(new InvoiceService(xmlService), xmlService);
		}
	}
}
