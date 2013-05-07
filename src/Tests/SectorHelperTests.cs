using NUnit.Framework;
using WorldBuilder.Helpers;

namespace Tests
{
	[TestFixture]
	public class SectorHelperTests
	{
		[Test]
		[TestCase(0x0004, 0x0004, Result = 0x00000000)]
		[TestCase(0x0008, 0x0008, Result = 0x00000000)]
		[TestCase(0x0010, 0x0010, Result = 0x00000000)]
		[TestCase(0x0020, 0x0020, Result = 0x00000000)]
		[TestCase(0x0040, 0x0040, Result = 0x04000001)]
		[TestCase(0x0080, 0x0080, Result = 0x08000002)]
		[TestCase(0x0fff, 0x3fff, Result = 0xfc0000ff)]
		public uint GetSectorCorrespondence(int x, int y)
		{
			return Helper.SEC_GetSectorCorrespondence(y, x);
		}
	}
}