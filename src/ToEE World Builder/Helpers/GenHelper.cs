using System;
using System.Linq;
using System.Text;

namespace WorldBuilder.Helpers
{
	public static class GenHelper
	{
		public static MobTypes GetMobileType(string MobileTypeString)
		{
			switch (MobileTypeString)
			{
				case "obj_t_portal"		: return MobTypes.Portal;
				case "obj_t_container"	: return MobTypes.Container;
				case "obj_t_scenery"	: return MobTypes.Scenery;
				case "obj_t_projectile"	: return MobTypes.Projectile;
				case "obj_t_weapon"		: return MobTypes.Weapon;
				case "obj_t_ammo"		: return MobTypes.Ammo;
				case "obj_t_armor"		: return MobTypes.Armor;
				case "obj_t_money"		: return MobTypes.Money;
				case "obj_t_food"		: return MobTypes.Food;
				case "obj_t_scroll"		: return MobTypes.Scroll;
				case "obj_t_key"		: return MobTypes.Key;
				case "obj_t_written"	: return MobTypes.Written;
				case "obj_t_generic"	: return MobTypes.Generic;
				case "obj_t_pc"			: return MobTypes.Pc;
				case "obj_t_npc"		: return MobTypes.Npc;
				case "obj_t_trap"		: return MobTypes.Trap;
				case "obj_t_bag"		: return MobTypes.Bag;
				default					: throw new Exception("Unexpected Error 002: Illegal mobile type string was passed to GetMobileType(string)!");
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