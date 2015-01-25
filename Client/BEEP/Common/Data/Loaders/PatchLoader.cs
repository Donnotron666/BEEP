using System;
using System.IO;
using System.Reflection;
using System.Text;
using Common.Core.SysEx;

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


		public SysExStream GetBytes()
		{
			var bytes = File.ReadAllBytes (FilePath);
			SysExStream ret = new SysExStream(bytes);
			return ret;
		}
	}
}

