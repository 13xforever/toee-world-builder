using System;
using NUnit.Framework;
using WorldBuilder;
using WorldBuilder.Helpers;

namespace Tests
{
	[TestFixture]
	public class GenHelperTests
	{
		[Test]
		public void ConvertBytesToStringGuid()
		{
			var guid = Guid.NewGuid();
			var guidBytes = new byte[24];
			guid.ToByteArray().CopyTo(guidBytes, 8);

			var expected = "G_" + guid.ToString("D").Replace('-', '_').ToUpper();
			Assert.That(GenHelper.ConvertBytesToStringGuid(guidBytes), Is.EqualTo(expected));
		}

		[Test]
		[TestCase(0xffffffff, Result = 0xff)]
		[TestCase(0x07f80000, Result = 0xff)] //00000|111 11111|000 00000000 00000000
		[TestCase(0x04080000, Result = 0x81)] //00000|100 00001|000 00000000 00000000
		[TestCase(0x0c0c0000, Result = 0x81)] //00001|100 00001|100 00000000 00000000
		[TestCase(0x08040000, Result = 0x00)] //00001|000 00000|100 00000000 00000000
		[TestCase(0x00000000, Result = 0x00)]
		public int GeneratorEncoderGet(long value)
		{
			return BitMasking.GenId.Get((int)value);
		}
	
		[Test]
		[TestCase(0xffffffff, 0xff, Result = 0xffffffff)]
		[TestCase(0x07f80000, 0xff, Result = 0x07f80000)] //00000|111 11111|000 00000000 00000000 ← 11111111 = 00000|111 11111|000 00000000 00000000
		[TestCase(0x07f80000, 0x00, Result = 0x00000000)] //00000|111 11111|000 00000000 00000000 ← 00000000 = 00000|000 00000|000 00000000 00000000
		[TestCase(0x04080000, 0x81, Result = 0x04080000)] //00000|100 00001|000 00000000 00000000 ← 10000001 = 00000|100 00001|000 00000000 00000000
		[TestCase(0x0c0c0000, 0x81, Result = 0x0c0c0000)] //00001|100 00001|100 00000000 00000000 ← 10000001 = 00001|100 00001|100 00000000 00000000
		[TestCase(0x08040000, 0x81, Result = 0x0c0c0000)] //00001|000 00000|100 00000000 00000000 ← 10000001 = 00001|100 00001|100 00000000 00000000
		[TestCase(0x00000000, 0x00, Result = 0x00000000)]
		[TestCase(0xaaaaaaaa, 0xaa, Result = 0xad52aaaa)] //10101|010 10101|010 10101010 10101010 ← 10101010 = 10101|101 01010|010 10101010 10101010
		[TestCase(0x55555555, 0x55, Result = 0x52ad5555)] //01010|101 01010|101 01010101 01010101 ← 01010101 = 01010|010 10101|101 01010101 01010101
		[TestCase(0xaaaaaaaa, 0xaaaaaaaa, Result = 0xad52aaaa)]
		[TestCase(0x55555555, 0x55555555, Result = 0x52ad5555)]
		public uint GeneratorEncoderSet(long value1, long value2)
		{
			return BitMasking.GenId.Set((uint)value1, (int)value2);
		}

		[Test]
		[TestCase("obj_t_portal", Result = MobType.obj_t_portal)]
		[TestCase("obj_t_food", Result = MobType.obj_t_food)]
		[TestCase("obj_t_bag", Result = MobType.obj_t_bag)]
		[TestCase(null, ExpectedException = typeof(ArgumentNullException))]
		[TestCase("", ExpectedException = typeof(ArgumentException))]
		[TestCase("sdfasfg", ExpectedException = typeof(ArgumentException))]
		public MobType GetMobileType(string s)
		{
			return GenHelper.GetMobileType(s);
		}

		[Test]
		[TestCase(null, Result = 0x00000000)]
		[TestCase("", Result = 0x00000000)]
		[TestCase("0", Result = 0x00000000)]
		[TestCase("1", Result = 0x00000001)]
		[TestCase("10", Result = 0x00000001)]
		[TestCase("01", Result = 0x00000002)]
		[TestCase("00000000000000000000000000000000", Result = 0x00000000)]
		[TestCase("00000000000000000000000000000001", Result = 0x80000000)]
		[TestCase("10000000000000000000000000000000", Result = 0x00000001)]
		[TestCase("11111111111111111111111111111111", Result = 0xffffffff)]
		[TestCase("000000000000000000000000000000001", ExpectedException = typeof(ArgumentException))]
		public uint BitmapToUInt32(string value)
		{
			return GenHelper.BitmapToUInt32(value);
		}

		[Test]
		[TestCase(0x00000000u, Result = "00000000000000000000000000000000")]
		[TestCase(0x80000000u, Result = "00000000000000000000000000000001")]
		[TestCase(0x00000001u, Result = "10000000000000000000000000000000")]
		[TestCase(0xffffffffu, Result = "11111111111111111111111111111111")]
		public string UInt32ToBitmap(uint value)
		{
			return GenHelper.UInt32ToBitmap(value);
		}

		[Test]
		[TestCase(0x0000000000000000u, Result = "0000000000000000000000000000000000000000000000000000000000000000")]
		[TestCase(0x8000000000000000u, Result = "0000000000000000000000000000000000000000000000000000000000000001")]
		[TestCase(0x0000000000000001u, Result = "1000000000000000000000000000000000000000000000000000000000000000")]
		[TestCase(0xffffffffffffffffu, Result = "1111111111111111111111111111111111111111111111111111111111111111")]
		public string UInt64ToBitmap(ulong value)
		{
			return GenHelper.UInt64ToBitmap(value);
		}
	}
}