namespace InvoiceApp.Interfaces
{
	public interface IXmlService
	{
		T SerializeFile<T>(string path);
	}
}