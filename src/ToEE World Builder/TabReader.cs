using System.Collections;
using System.IO;

namespace WorldBuilder
{
	/// <summary>
	/// A class that can be used to load and parse TAB files
	/// </summary>
	public class TabReader
	{
		public ArrayList Data = new ArrayList();

		public TabReader(string tab_file, FileMode mode)
		{
			using (var tabfile = new FileStream(tab_file, mode))
			using (var t_read = new StreamReader(tabfile))
			{

				string str = "";
				while ((str = t_read.ReadLine()) != null)
				{
					if (str.Trim() != "")
						if (str.Length > 1)
							Data.Add(str);
				}

				t_read.Close();
				tabfile.Close();
			}
		}
	}
}