using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WorldBuilder;

namespace Tests
{
	[TestFixture]
	public class ProtoHelperTests
	{
		private static readonly Encoding Utf8 = new UTF8Encoding(false);

		[Test, Explicit("Obsolete after refactoring")]
		public void GetColumnNames()
		{
			var defaultResult = ProtoHelper.GetColumnNames();
			var patchedResult = ProtoHelper.GetColumnNames(@"D:\Programs\ToEEWB\Source Code\required-files\ToEE World Builder.pfr");
			Assert.That(patchedResult, Is.EqualTo(defaultResult));
		}

		private static IEnumerable<string> GetListForExport(IEnumerable<string> defaultResult)
		{
			return defaultResult
				.Select(s => s.TrimEnd('\t').TrimEnd('|').TrimEnd(' '))
				.Where(s => !s.StartsWith("Unknown #"))
				.Select((s, i) => string.Format("{0,3}={1}", i, s));
		}
	}
}
