using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InvoiceApp.ViewModels;

namespace InvoiceApp.Views
{
	/// <summary>
	/// Interaction logic for InvoiceView.xaml
	/// </summary>
	public partial class InvoiceView : Window
	{
		public InvoiceView(InvoiceViewModel invoiceViewModel)
		{
			InitializeComponent();

			DataContext = invoiceViewModel;
		}
	}
}
