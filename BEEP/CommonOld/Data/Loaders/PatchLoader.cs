using System;
using System.IO;
using System.Reflection;

namespace Common.Data.Loaders
{
	public class PatchLoader
	{
		public string FilePath;

		public PatchLoader (string relativePath)
		{

			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			path = Path.GetDirectoryName(path);

			FilePath = path + relativePath;
		}

		public byte[] GetBytes()
		{
			return File.ReadAllBytes (FilePath);
		}
	}
}

