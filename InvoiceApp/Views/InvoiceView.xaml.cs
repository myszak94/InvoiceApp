using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				var printDialog = new PrintDialog();
				if (printDialog.ShowDialog() == true)
				{
					printDialog.PrintVisual(Print, "faktura");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
