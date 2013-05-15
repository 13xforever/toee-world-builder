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

			switch (mobileTypeString)
			{
				case "obj_t_portal"		: return MobType.Portal;
				case "obj_t_container"	: return MobType.Container;
				case "obj_t_scenery"	: return MobType.Scenery;
				case "obj_t_projectile"	: return MobType.Projectile;
				case "obj_t_weapon"		: return MobType.Weapon;
				case "obj_t_ammo"		: return MobType.Ammo;
				case "obj_t_armor"		: return MobType.Armor;
				case "obj_t_money"		: return MobType.Money;
				case "obj_t_food"		: return MobType.Food;
				case "obj_t_scroll"		: return MobType.Scroll;
				case "obj_t_key"		: return MobType.Key;
				case "obj_t_written"	: return MobType.Written;
				case "obj_t_generic"	: return MobType.Generic;
				case "obj_t_pc"			: return MobType.Pc;
				case "obj_t_npc"		: return MobType.Npc;
				case "obj_t_trap"		: return MobType.Trap;
				case "obj_t_bag"		: return MobType.Bag;
				default					: throw new ArgumentException("Unexpected Error 002: Illegal mobile type string was passed to GetMobileType(string)!");
			}
		}

		public static uint BitmapToUInt32(string Bitmap)
		{
			uint BIT_INT = 0;
			uint BIT_FLAG = 0;

			for (int i = Bitmap.Length - 1; i >= 0; i--)
			{
				BIT_FLAG++;

				if (Bitmap[i] == '1')
					BIT_INT += (uint)Math.Pow(2, i);
			}

			return BIT_INT;
		}

		public static string UInt32ToBitmap(uint Flags)
		{
			string BITMAP = "";

			for (int i = 0; i < 4; i++)
			{
				var CURRENT_BYTE = (byte)(Flags >> (8*i));
				string _BMP = Convert.ToString(CURRENT_BYTE, 2).PadLeft(8, '0');
				string _BMP2 = "";

				for (int j = 7; j >= 0; j--)
					_BMP2 += _BMP[j];

				BITMAP += _BMP2;
			}

			return BITMAP;
		}

		/// <summary>
		///     a 64-bit version of <see cref="UInt32ToBitmap" />
		/// </summary>
		public static string UInt64ToBitmap(ulong Flags)
		{
			string BITMAP = "";
			for (int i = 0; i < 8; i++)
			{
				var CURRENT_BYTE = (byte)(Flags >> (8*i));
				string _BMP = Convert.ToString(CURRENT_BYTE, 2).PadLeft(8, '0');
				string _BMP2 = "";

				for (int j = 7; j >= 0; j--)
					_BMP2 += _BMP[j];

				BITMAP += _BMP2;
			}
			return BITMAP;
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