namespace InvoiceApp.Interfaces
{
	public interface IXmlService
	{
		(bool, T) SerializeFile<T>(string path) where T : new();
		bool CreateXmlFile<T>(T obj, string fileName);
	}
}