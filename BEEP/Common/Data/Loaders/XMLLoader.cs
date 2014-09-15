using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Common.Logging;
using System.Xml.Serialization;

namespace Common.Data.Loaders
{


	public class XMLLoader<T> where T : BasicData
	{

		Logger Log = LogManager.Create("XMLLoader");

		string FilePath;

		public XMLLoader (string relativePath)
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			path = Path.GetDirectoryName(path);

			FilePath = path + relativePath;


		}

		public void LoadIntoDataStore(DataStore store)
		{

			using (var stream = File.OpenRead (FilePath)) {
				XmlSerializer ser = new XmlSerializer(typeof(List<T>));

				List<T> result = ser.Deserialize (stream) as List<T>;

				foreach (T data in result) {
					store.AddData (data);
				}
			}


		}

	}
}

