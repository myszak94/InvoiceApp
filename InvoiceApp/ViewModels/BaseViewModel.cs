using System.ComponentModel;

namespace InvoiceApp.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		protected void OnPropertyChanged(string name)
		{
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
