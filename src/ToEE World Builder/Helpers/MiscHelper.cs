using System.IO;
using System.Linq;
using System.Reflection;

namespace WorldBuilder.Helpers
{
	public static class MiscHelper
	{
		public static Stream GetResourceStreamThatEndsWith(string name)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var fullName = assembly.GetManifestResourceNames().FirstOrDefault(n => n.ToUpper().EndsWith(name.ToUpper()));
			return fullName.Return(assembly.GetManifestResourceStream);
		}
	}
}