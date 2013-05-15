using System;
using System.Linq;
using System.Text;

namespace WorldBuilder.Helpers
{
	public static class GenHelper
	{
		public static MobType GetMobileType(string mobileTypeString)
		{
			if (mobileTypeString == null) throw new ArgumentNullException("mobileTypeString");

			MobType result;
			if (MobType.TryParse(mobileTypeString, false, out result))
				return result;

			throw new ArgumentException("Unexpected Error 002: Illegal mobile type string was passed to GetMobileType(string)!");
		}

		public static uint BitmapToUInt32(string bitmap)
		{
			if (string.IsNullOrEmpty(bitmap)) return 0;
			if (bitmap.Length > 32) throw new ArgumentException("Bitmap should not exceed 32 bits.", "bitmap");

			uint result = 0;
			for (int i = bitmap.Length - 1; i >= 0; i--)
			{
				result <<= 1;
				if (bitmap[i] == '1')
					result |= 1;
			}
			return result;
		}

		public static string UInt32ToBitmap(uint flags)
		{
			var result = new StringBuilder();
			for (var i = 0; i < sizeof (uint)*8; i++)
			{
				result.Append(flags & 1);
				flags >>= 1;
			}
			return result.ToString();
		}

		/// <summary>
		///     a 64-bit version of <see cref="UInt32ToBitmap" />
		/// </summary>
		public static string UInt64ToBitmap(ulong flags)
		{
			var result = new StringBuilder();
			for (var i = 0; i < sizeof(ulong) * 8; i++)
			{
				result.Append(flags & 1);
				flags >>= 1;
			}
			return result.ToString();
		}

		public static string ConvertBytesToStringGuid(byte[] GUID_bytes)
		{
			//8-23?
			return new StringBuilder("G_")
				.Append(new Guid(GUID_bytes.Skip(8).ToArray()).ToString("D"))
				.Replace('-', '_')
				.ToString()
				.ToUpper(); //todo: is it necessary?
		}

		/// <summary>
		///     Convert an uint flag value into a set of bytes
		///     (for sector wall flag setup routine)
		/// </summary>
		public static byte[] ConvertFlagsToByteArray(uint flags)
		{
			var bytes = new byte[4];

			bytes[0] = (byte)flags;
			bytes[1] = (byte)(flags >> 8);
			bytes[2] = (byte)(flags >> 16);
			bytes[3] = (byte)(flags >> 24);

			return bytes;
		}
	}
}