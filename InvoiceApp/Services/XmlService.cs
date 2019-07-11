using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using InvoiceApp.Interfaces;

namespace InvoiceApp.Services
{
	public class XmlService : IXmlService
	{
		public (bool, T) SerializeFile<T>(string path) where T : new()
		{
			try
			{
				var reader = new XmlSerializer(typeof(T));
				using (var file = new StreamReader(path))
				{
					return (true, (T)reader.Deserialize(file));
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return (false, new T());
			}
		}

		public bool CreateXmlFile<T>(T obj, string fileName)
		{
			try
			{
				var writer = new XmlSerializer(typeof(T));

				var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\{fileName}.xml";
				using (var sw = new StreamWriter(path, false, Encoding.UTF8))
				{
					writer.Serialize(sw, obj);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return false;
			}

			return true;
		}
	}
}
