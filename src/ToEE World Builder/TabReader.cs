using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
	/// <summary>
	/// A class that can be used to load and parse TAB files
	/// </summary>
	public static class TabReader
	{
		public static List<string> Read(string tabFilePath)
		{
			return File.ReadLines(tabFilePath, Encoding.UTF8).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
		}
	}
}