using NUnit.Framework;
using WorldBuilder.Helpers;

namespace Tests
{
	[TestFixture]
	public class SectorHelperTests
	{
		[Test]
		[TestCase(0x04, 0x04, Result = 0x00000000)]
		[TestCase(0x08, 0x08, Result = 0x00000000)]
		[TestCase(0x10, 0x10, Result = 0x00000000)]
		[TestCase(0x20, 0x20, Result = 0x00000000)]
		[TestCase(0x40, 0x40, Result = 0x04000001)]
		[TestCase(0x80, 0x80, Result = 0x08000002)]
		public uint GetSectorCorrespondence(int x, int y)
		{
			return Helper.SEC_GetSectorCorrespondence(y, x);
		}
	}
}