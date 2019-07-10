using InvoiceApp.Interfaces;

namespace InvoiceApp.Services
{
	public class XmlService: IXmlService
	{
		public T SerializeFile<T>(string path)
		{
			System.Xml.Serialization.XmlSerializer reader =
				new System.Xml.Serialization.XmlSerializer(typeof(T));
			System.IO.StreamReader file = new System.IO.StreamReader(path);
			T obj = (T)reader.Deserialize(file);
			file.Close();

			return obj;
		}
	}
}
