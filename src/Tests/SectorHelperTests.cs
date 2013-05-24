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
			return SecHelper.GetSecNameFromXY(x, y);
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
			return SecHelper.GetSectorCorrespondence(y, x);
		}
	
		[Test]
		[TestCase(         "0", 0x0000, 0x003f, 0x0000, 0x003f)] //0x00000000
		[TestCase(  "16777217", 0x0000, 0x003f, 0x0040, 0x007f)] //0x01000001
		[TestCase(  "33554434", 0x0000, 0x003f, 0x0080, 0x00bf)] //0x02000002
		[TestCase(  "67108868", 0x0040, 0x007f, 0x0100, 0x013f)] //0x04000004
		[TestCase( "134217736", 0x0080, 0x00bf, 0x0200, 0x023f)] //0x08000008
		[TestCase( "268435472", 0x0100, 0x013f, 0x0400, 0x043f)] //0x10000010
		[TestCase("4160749816", 0x0f80, 0x0fbf, 0x3e00, 0x3e3f)] //0xf80000f8
		[TestCase("4278190335", 0x0fc0, 0x0fff, 0x3fc0, 0x3fff)] //0xff0000ff
		public void GetMinMax(string sectorName, int minX, int maxX, int minY, int maxY)
		{
			int resMinX, resMinY, resMaxX, resMaxY;
			SecHelper.Sec_GetMinMax(sectorName, out resMinX, out resMaxX, out resMinY, out resMaxY);

			Assert.That(resMinX, Is.EqualTo(minX));
			Assert.That(resMinY, Is.EqualTo(minY));
			Assert.That(resMaxX, Is.EqualTo(maxX));
			Assert.That(resMaxY, Is.EqualTo(maxY));
		}

		[Test]
		[TestCase(         "0", 0x00, 0x00)] //0x00000000
		[TestCase(  "16777217", 0x00, 0x01)] //0x01000001
		[TestCase(  "33554434", 0x00, 0x02)] //0x02000002
		[TestCase(  "67108868", 0x01, 0x04)] //0x04000004
		[TestCase( "134217736", 0x02, 0x08)] //0x08000008
		[TestCase( "268435472", 0x04, 0x10)] //0x10000010
		[TestCase("4160749816", 0x3e, 0xf8)] //0xf80000f8
		[TestCase("4278190335", 0x3f, 0xff)] //0xff0000ff
		public void GetXY(string sectorName, int expectedX, int expectedY)
		{
			byte x, y;
			SecHelper.GetXY(sectorName, out x, out y);
			Assert.That(x, Is.EqualTo(expectedX));
			Assert.That(y, Is.EqualTo(expectedY));
		}
	}
}