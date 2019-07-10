using System;
using System.IO;
using System.Xml.Serialization;
using InvoiceApp.Interfaces;

namespace InvoiceApp.Services
{
	public class XmlService : IXmlService
	{
		public T SerializeFile<T>(string path) where T : new()
		{
			try
			{
				var reader = new XmlSerializer(typeof(T));
				using (var file = new StreamReader(path))
				{
					return (T)reader.Deserialize(file);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return new T();
			}
		}

		public bool CreateXmlFile<T>(T obj, string fileName)
		{
			try
			{
				var writer = new XmlSerializer(typeof(T));

				var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\{fileName}.xml";
				using (var file = File.Create(path))
				{
					writer.Serialize(file, obj);
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
