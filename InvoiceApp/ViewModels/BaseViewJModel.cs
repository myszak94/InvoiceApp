using System.ComponentModel;
using System.Runtime.CompilerServices;
using InvoiceApp.Annotations;

namespace InvoiceApp.ViewModels
{
	public class BaseViewJModel : INotifyPropertyChanged
	{
		protected void OnPropertyChanged(string name)
		{
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
