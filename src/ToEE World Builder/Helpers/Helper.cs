using System.IO;

namespace WorldBuilder.Helpers
{
	public static class Helper
	{
		/// <summary>
		///     Write an extended complement to 2
		/// </summary>
		public static void WriteComp2Ex(this BinaryWriter writer, uint bitCount)
		{
			uint dwordCount = bitCount >> 5;
			var highDwordBitCount = (int)(bitCount & 0x1F);
			writer.Write(dwordCount + 1);
			for (var i = 0; i < dwordCount; i++)
				writer.Write(0xffffffff);
			var highDword = (uint)(0xffffffffL >> (32 - highDwordBitCount)); //no, you can't just 0xffffffff >> (32 - highDwordBitCount);
			writer.Write(highDword);
		}

		/// <summary>
		///     Hash function - HashPJW. Returns a 32-bit uint value from a string.
		/// </summary>
		public static uint PjwHash(string ptr)
		{
			uint val = 0;
			foreach (char c in ptr)
			{
				val = (val << 4) + c;
				uint tmp = val & 0xf0000000;
				if (tmp == 0) continue;

				val = val ^ (tmp >> 24) ^ tmp;
			}
			return val;
		}
	}
}