using NUnit.Framework;
using WorldBuilder.Helpers;

namespace Tests
{
	[TestFixture]
	public class SectorHelperTests
	{
		[Test]
		[TestCase(0x00, 0x00, Result = 0x00000000)]
		[TestCase(0x01, 0x01, Result = 0x04000001)]
		[TestCase(0x04, 0x04, Result = 0x10000004)]
		[TestCase(0x08, 0x08, Result = 0x20000008)]
		[TestCase(0x10, 0x10, Result = 0x40000010)]
		[TestCase(0x20, 0x20, Result = 0x80000020)]
		[TestCase(0x3f, 0xff, Result = 0xfc0000ff)]
		public uint GetSecNameFromXY(int x, int y)
		{
			return Helper.SEC_GetSecNameFromXY(x, y);
		}
	
		[Test]
		[TestCase(0x0000, 0x0000, Result = 0x00000000)]
		[TestCase(0x0001, 0x0001, Result = 0x00000000)]
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