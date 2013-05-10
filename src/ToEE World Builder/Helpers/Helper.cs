using System;
using System.Collections;
using System.IO;

namespace WorldBuilder.Helpers
{
	public class Helper
	{
		#region MOB helpers

		public static string LastOpenedMOB = ""; // v1.7.5s1: For Cerulean the Blue: a string of last opened MOB file
		public static string InteropPath = "C:\\wb200_il.lri"; // interoperability support for v2.0.0
		public static Hashtable Proto_By_ID = new Hashtable();
		public static string SectorName = "NOT_DETECTED";
		public static bool EmbedMode = false;

		public static void MOB_GenerateGUID(out string s_GUID, out byte[] GUID)
		{
			var r = new Random();
			var generator = new byte[16];
			GUID = new byte[24];

			s_GUID = "G_";
			GUID[0] = 0x02;
			GUID[1] = 0x00;
			GUID[2] = 0x00;
			GUID[3] = 0x00;
			GUID[4] = 0x00;
			GUID[5] = 0x00;
			GUID[6] = 0x00;
			GUID[7] = 0x00;

			r.NextBytes(generator);

			GUID[11] = generator[0];
			GUID[10] = generator[1];
			GUID[9] = generator[2];
			GUID[8] = generator[3];
			GUID[13] = generator[4];
			GUID[12] = generator[5];
			GUID[15] = generator[6];
			GUID[14] = generator[7];

			for (int j = 16; j < 24; j++)
				GUID[j] = generator[j - 8];

			for (int k = 0; k < 16; k++)
			{
				string s_Elem = generator[k].ToString("X");
				if (s_Elem.Length == 1)
					s_Elem = "0" + s_Elem;

				if (k == 3 || k == 5 || k == 7 || k == 9)
					s_GUID += s_Elem + "_";
				else
					s_GUID += s_Elem;
			}

			return;
		}

		public static byte MOB_BitmapBlockToByte(string BitmapBlock)
		{
			string BitmapReal = "";

			for (int i = 7; i >= 0; i--)
				BitmapReal += BitmapBlock[i];

			return Convert.ToByte(BitmapReal, 2);
		}

		public static ArrayList MOB_BitmapToBytes(string Bitmap)
		{
			var bytes = new ArrayList();

			for (int i = 0; i < Bitmap.Length; i += 8)
			{
				string element = Bitmap.Substring(i, 8);
				bytes.Add(MOB_BitmapBlockToByte(element));
			}

			return bytes;
		}

		public static Int16 MOB_GetNumberOfProperties(string Bitmap)
		{
			Int16 no_props = 0;

			for (int i = 0; i < Bitmap.Length; i++)
			{
				if (Bitmap[i] == '1')
					no_props++;
			}

			return no_props;
		}

		public static byte[] MOB_ReturnHeader(Int16 Proto_ID)
		{
			var header = new byte[28];
			header[0x00] = 0x77;
			header[0x04] = 0x01;

			var PROTO_HIGH = (byte) Proto_ID;
			var PROTO_LOW = (byte) (Proto_ID >> 8);

			header[0x0C] = PROTO_HIGH;
			header[0x0D] = PROTO_LOW;

			return header;
		}

		[Obsolete("This function might have become deprecated since v1.7.x")]
		public static byte[] MOB_ReturnHeader(Int16 Proto_ID, bool MarkAsCompatible)
		{
			var header = new byte[28];
			header[0x00] = 0x77;
			header[0x04] = 0x01;

			var PROTO_HIGH = (byte) Proto_ID;
			var PROTO_LOW = (byte) (Proto_ID >> 8);

			header[0x0C] = PROTO_HIGH;
			header[0x0D] = PROTO_LOW;

			// This is used to mark MOB files as 100% compatible with the
			// ToEE World Builder. Files that are marked this way can be
			// safely loaded and saved by the World Builder. Files that
			// don't have this mark can only be inspected, but not loaded/saved.
			// This solution is temporary until all the properties are
			// figured out and saving/loading routines for them are written.
			// R1.3: Marking disabled until further investigation (set to 0x00),
			//       but the 32-bit 0x00 still serves as a compatibility system.
			if (MarkAsCompatible)
			{
				header[0x06] = 0x00;
				header[0x07] = 0x00;
				header[0x08] = 0x00;
				header[0x09] = 0x00;
			}

			return header;
		}

		public static byte[] MOB_ReturnHeader(Int16 Proto_ID, bool DONT_USE_DEPRECATED, bool GenerateObjID)
		{
			var header = new byte[28];
			header[0x00] = 0x77;
			header[0x04] = 0x01;

			var PROTO_HIGH = (byte) Proto_ID;
			var PROTO_LOW = (byte) (Proto_ID >> 8);

			header[0x0C] = PROTO_HIGH;
			header[0x0D] = PROTO_LOW;

			if (GenerateObjID)
				header = MOB_GenerateObjID(header);

			return header;
		}

		public static int MOB_GetNumberofBitmapBlocks(MobTypes MobType)
		{
			int Num_Blocks = 4;

			switch (MobType)
			{
				case MobTypes.Portal:
					Num_Blocks = 4;
					break;
				case MobTypes.Container:
					Num_Blocks = 4;
					break;
				case MobTypes.Scenery:
					Num_Blocks = 5;
					break;
				case MobTypes.Projectile:
					Num_Blocks = 5;
					break;
				case MobTypes.Weapon:
					Num_Blocks = 7;
					break;
				case MobTypes.Ammo:
					Num_Blocks = 7;
					break;
				case MobTypes.Armor:
					Num_Blocks = 8;
					break;
				case MobTypes.Money:
					Num_Blocks = 8;
					break;
				case MobTypes.Food:
					Num_Blocks = 8;
					break;
				case MobTypes.Scroll:
					Num_Blocks = 8;
					break;
				case MobTypes.Key:
					Num_Blocks = 9;
					break;
				case MobTypes.Written:
					Num_Blocks = 9;
					break;
				case MobTypes.Generic:
					Num_Blocks = 9;
					break;
				case MobTypes.Pc:
					Num_Blocks = 11;
					break;
				case MobTypes.Npc:
					Num_Blocks = 13;
					break;
				case MobTypes.Trap:
					Num_Blocks = 13;
					break;
				case MobTypes.Bag:
					Num_Blocks = 9;
					break;
				default:
					throw new Exception("Unexpected Error 001: Undefined mobile type used to create a bitmap!");
			}

			return Num_Blocks;
		}

		public static string MOB_CreateBitmap(MobTypes MobType)
		{
			string Bitmap = "";
			int Num_Blocks = MOB_GetNumberofBitmapBlocks(MobType);

			for (int i = 0; i < Num_Blocks*32; i++)
				Bitmap += "0";

			return Bitmap;
		}

		public static string MOB_CreateBitmap(int NumberOfBlocks)
		{
			string Bitmap = "";

			for (int i = 0; i < NumberOfBlocks*32; i++)
				Bitmap += "0";

			return Bitmap;
		}

		public static string MOB_BytesToBitmap(ArrayList bytes)
		{
			string BMP = "";

			foreach (object b in bytes)
			{
				string _BMP = "";
				string _BMP2 = "";

				_BMP = Convert.ToString(Byte.Parse(b.ToString()), 2).PadLeft(8, '0');

				for (int i = 7; i >= 0; i--)
					_BMP2 += _BMP[i];

				BMP += _BMP2;
			}

			return BMP;
		}

		public static string MOB_BytesToBitmap(byte[] bytes)
		{
			string BMP = "";
			foreach (byte b in bytes)
			{
				string _BMP = Convert.ToString(b, 2).PadLeft(8, '0');
				string _BMP2 = "";

				for (int i = 7; i >= 0; i--)
					_BMP2 += _BMP[i];

				BMP += _BMP2;
			}

			return BMP;
		}

		public static TriState MOB_GetPropertyState(string Bitmap, int Property_ID)
		{
			if (Property_ID > Bitmap.Length - 1)
				return TriState.NotValid;

			if (Bitmap[Property_ID] == '1')
				return TriState.True;
			else
				return TriState.False;
		}

		/// <param name="Property_ID">
		///     Keep in mind that the count starts from 1, <b>not</b> from 0
		/// </param>
		public static string MOB_SetProperty(string Bitmap, int Property_ID)
		{
			if (Property_ID > Bitmap.Length - 1)
				return "NOT_VALID";

			Bitmap = Bitmap.Substring(0, Property_ID) + "1" + Bitmap.Substring(Property_ID + 1);

			return Bitmap;
		}

		public static string MOB_ClearProperty(string Bitmap, int Property_ID)
		{
			if (Property_ID > Bitmap.Length - 1)
				return "NOT_VALID";

			Bitmap = Bitmap.Substring(0, Property_ID) + "0" + Bitmap.Substring(Property_ID + 1);

			return Bitmap;
		}

		public static string MOB_ModifyProperty(string Bitmap, int Property_ID, bool Value)
		{
			if (Value)
				return MOB_SetProperty(Bitmap, Property_ID);
			else
				return MOB_ClearProperty(Bitmap, Property_ID);
		}

		/// <summary>
		///     A random mobile object proto ObjID generator, based on random
		///     number generation within known limits. This code will serve as a
		///     means of making the object more unique in the game memory space.
		/// </summary>
		public static byte[] MOB_GenerateObjID(byte[] header)
		{
			byte[] header_with_objid = header;
			var r = new Random();
			int objid_mod_1 = r.Next(0x00010101, 0x00FFFFFF);
			int objid_mod_2 = r.Next(0x00010101, 0x00FFFFFF);
			var objid_mod_pre = (short) r.Next(short.MinValue, short.MaxValue);
			var objid_fpart = (byte) r.Next(0, 255);
			var objid_fpart_ex = (byte) r.Next(0, 255);
			var objid_set_prefix = (byte) r.Next(0, 255);

			// set up predefined stuff
			header_with_objid[16] = 0x02;

			// fill bytes 8..11 with objid_mod_1, and 20..23/24..27 with
			// objid_mod_2
			header_with_objid[8] = (byte) objid_mod_1;
			header_with_objid[9] = (byte) (objid_mod_1 >> 8);
			header_with_objid[10] = (byte) (objid_mod_1 >> 16);
			header_with_objid[11] = (byte) (objid_mod_1 >> 24);

			if (objid_fpart > 127)
			{
				// 20..23
				header_with_objid[20] = (byte) objid_mod_2;
				header_with_objid[21] = (byte) (objid_mod_2 >> 8);
				header_with_objid[22] = (byte) (objid_mod_2 >> 16);
				header_with_objid[23] = (byte) (objid_mod_2 >> 24);

				if (objid_fpart_ex > 127)
				{
					header_with_objid[21] = header_with_objid[9];
					header_with_objid[22] = header_with_objid[10];
				}
			}
			else
			{
				// 24..27
				header_with_objid[24] = (byte) objid_mod_2;
				header_with_objid[25] = (byte) (objid_mod_2 >> 8);
				header_with_objid[26] = (byte) (objid_mod_2 >> 16);
				header_with_objid[27] = (byte) (objid_mod_2 >> 24);
			}

			// should we set the objid prefix?
			if (objid_set_prefix > 127)
			{
				header_with_objid[6] = (byte) objid_mod_pre;
				header_with_objid[7] = (byte) (objid_mod_pre >> 8);
			}

			return header_with_objid;
		}

		/// <summary>
		///     Sizeable array positioning function. Experimental.
		/// </summary>
		public static uint MOB_GenerateSARC(bool s_mode)
		{
			if (s_mode)
			{
				// we have to generate the SARC data

				uint sa_mem_index = 0;
				string sa_str = "";
				string[] sa_str_arr = null;

				var sr = new StreamReader("ToEE World Builder.sar");
				while ((sa_str = sr.ReadLine()) != "[END INTERNAL PATCH]")
				{
					if (sa_str.Trim() == "")
						continue;

					if (sa_str.Substring(0, 2) == "//") // comment
						continue;

					sa_str_arr = sa_str.Split('=');
					sa_mem_index = uint.Parse(sa_str_arr[1]);
				}
				sr.Close();

				// modify and write back
				uint sa_mem_indexA = sa_mem_index + (uint) (new Random().Next(5, 8));
				if (sa_mem_indexA > 0x1BFF) sa_mem_indexA = 0x1661;

				var sw = new StreamWriter("ToEE World Builder.sar");
				sw.WriteLine("// FOR THE SAKE OF YOUR OWN SANITY, DO **NOT** MODIFY THIS FILE!!!");
				sw.WriteLine("// MODIFYING THIS FILE CAN CAUSE FATAL ERRORS WHILE SAVING BACK MOBILE OBJECTS !");
				sw.WriteLine("");
				sw.WriteLine("SARC=" + sa_mem_indexA.ToString());
				sw.WriteLine("[END INTERNAL PATCH]");
				sw.Close();

				return sa_mem_index;
			}
			else
			{
				// no need to generate SARC, return a 32-bit zero
				return 0;
			}
		}

		#endregion

		#region GEN

		public static MobTypes GEN_GetMobileType(string MobileTypeString)
		{
			switch (MobileTypeString)
			{
				case "obj_t_portal":
					return MobTypes.Portal;
				case "obj_t_container":
					return MobTypes.Container;
				case "obj_t_scenery":
					return MobTypes.Scenery;
				case "obj_t_projectile":
					return MobTypes.Projectile;
				case "obj_t_weapon":
					return MobTypes.Weapon;
				case "obj_t_ammo":
					return MobTypes.Ammo;
				case "obj_t_armor":
					return MobTypes.Armor;
				case "obj_t_money":
					return MobTypes.Money;
				case "obj_t_food":
					return MobTypes.Food;
				case "obj_t_scroll":
					return MobTypes.Scroll;
				case "obj_t_key":
					return MobTypes.Key;
				case "obj_t_written":
					return MobTypes.Written;
				case "obj_t_generic":
					return MobTypes.Generic;
				case "obj_t_pc":
					return MobTypes.Pc;
				case "obj_t_npc":
					return MobTypes.Npc;
				case "obj_t_trap":
					return MobTypes.Trap;
				case "obj_t_bag":
					return MobTypes.Bag;
				default:
					throw new Exception("Unexpected Error 002: Illegal mobile type string was passed to GEN_GetMobileType(string)!");
			}
		}

		public static uint GEN_Bitmap_To_UInt32(string Bitmap)
		{
			uint BIT_INT = 0;
			uint BIT_FLAG = 0;

			for (int i = Bitmap.Length - 1; i >= 0; i--)
			{
				BIT_FLAG++;

				if (Bitmap[i] == '1')
					BIT_INT += (uint) Math.Pow(2, i);
			}

			return BIT_INT;
		}

		public static string GEN_UInt32_To_Bitmap(uint Flags)
		{
			string BITMAP = "";

			for (int i = 0; i < 4; i++)
			{
				var CURRENT_BYTE = (byte) (Flags >> (8*i));
				string _BMP = Convert.ToString(CURRENT_BYTE, 2).PadLeft(8, '0');
				string _BMP2 = "";

				for (int j = 7; j >= 0; j--)
					_BMP2 += _BMP[j];

				BITMAP += _BMP2;
			}

			return BITMAP;
		}

		/// <summary>
		///     a 64-bit version of <see cref="GEN_UInt32_To_Bitmap" />
		/// </summary>
		public static string GEN_UInt64_To_Bitmap(ulong Flags)
		{
			string BITMAP = "";

			for (int i = 0; i < 8; i++)
			{
				var CURRENT_BYTE = (byte) (Flags >> (8*i));
				string _BMP = Convert.ToString(CURRENT_BYTE, 2).PadLeft(8, '0');
				string _BMP2 = "";

				for (int j = 7; j >= 0; j--)
					_BMP2 += _BMP[j];

				BITMAP += _BMP2;
			}

			return BITMAP;
		}

		public static ulong GEN_GetComp2(int number)
		{
			return (ulong) (Math.Pow(2, number) - 1);
		}

		public static string GEN_ConvertBytesToStringGUID(byte[] GUID_bytes)
		{
			string s_GUID = "G_";

			s_GUID += GUID_bytes[11].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[10].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[9].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[8].ToString("X").PadLeft(2, '0');
			s_GUID += "_";
			s_GUID += GUID_bytes[13].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[12].ToString("X").PadLeft(2, '0');
			s_GUID += "_";
			s_GUID += GUID_bytes[15].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[14].ToString("X").PadLeft(2, '0');
			s_GUID += "_";
			s_GUID += GUID_bytes[16].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[17].ToString("X").PadLeft(2, '0');
			s_GUID += "_";
			s_GUID += GUID_bytes[18].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[19].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[20].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[21].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[22].ToString("X").PadLeft(2, '0');
			s_GUID += GUID_bytes[23].ToString("X").PadLeft(2, '0');
			return s_GUID;
		}

		/// <summary>
		///     Convert an uint flag value into a set of bytes
		///     (for sector wall flag setup routine)
		/// </summary>
		public static byte[] GEN_ConvertFlagsToByteArray(uint flags)
		{
			var bytes = new byte[4];

			bytes[0] = (byte) flags;
			bytes[1] = (byte) (flags >> 8);
			bytes[2] = (byte) (flags >> 16);
			bytes[3] = (byte) (flags >> 24);

			return bytes;
		}

		#endregion

		/// <summary>
		///     Write an extended complement to 2
		/// </summary>
		public static void GetComp2Ex(BinaryWriter w_mob, uint no_entries)
		{
			uint ex_fillers = no_entries/32;
			uint c_highest = no_entries%32;

			w_mob.Write(ex_fillers + 1);

			for (int i = 0; i < ex_fillers; i++)
				w_mob.Write(0xFFFFFFFF);

			uint final_mod = (uint) Math.Pow(2, c_highest) - 1;
			w_mob.Write(final_mod);
		}

		/// <summary>
		///     Gen a size of an extended complement to 2
		/// </summary>
		public static uint GetSizeofComp2Ex(uint no_entries)
		{
			return (no_entries/32) + 1;
		}

		/// <summary>
		///     Hash function - HashPJW. Returns a 32-bit uint value from a string.
		/// </summary>
		public static uint hashpjw(string ptr)
		{
			uint val = 0;

			for (int i = 0; i < ptr.Length; i++)
			{
				uint tmp;
				val = (val << 4) + ptr[i];

				tmp = (val & 0xf0000000);
				if (tmp != 0)
				{
					val = val ^ (tmp >> 24);
					val = val ^ tmp;
				}
			}
			return val;
		}

		/// <summary>
		///     ElfHash - another hashing function. Used for lights.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static uint HashID_Generate(string str)
		{
			uint h = 0, g;
			for (int i = 0; i < str.Length; i++)
			{
				uint cur = str[i];
				if (cur >= 'a' && cur <= 'z') cur -= ('a' - 'A');
				h = (h << 4) + cur;
				g = h & 0xF0000000;
				if (g != 0)
					h ^= g >> 24;
				h &= ~g;
			}
			return h;
		}

		#region DC/rank functions

		public static int DC_BITS = 0x0000007F;
		public static int DC_POS = 0;
		public static int RANK_BITS = 0x00003F80;
		public static int RANK_POS = 7;

		public static int GET_DC(int target)
		{
			return (((target) & DC_BITS) >> DC_POS);
		}

		public static int GET_RANK(int target)
		{
			return (((target) & RANK_BITS) >> RANK_POS);
		}

		public static int MAKE_DC(int x, int dc)
		{
			return (((x) & ~DC_BITS) | (((dc) & (DC_BITS >> DC_POS))) << DC_POS);
		}

		public static int MAKE_RANK(int x, int r)
		{
			return (((x) & ~RANK_BITS) | (((r) & (RANK_BITS >> RANK_POS))) << RANK_POS);
		}

		#endregion

		#region Generator functions

		public static int GENERATOR_BITS = 0x07F80000;
		public static int GENERATOR_POS = 19;
		public static int SPAWNMAX_BITS = 0x0007C000;
		public static int SPAWNMAX_POS = 14;
		public static int TOTAL_BITS = 0x00003F80;
		public static int TOTAL_POS = 7;
		public static int NPCGEN_BITS = 0x00E00000;
		public static int NPCGEN_POS = 21;

		public static int GET_GENID(int target)
		{
			return (((target) & GENERATOR_BITS) >> GENERATOR_POS);
		}

		public static int GET_SPAWNMAX(int target)
		{
			return (((target) & SPAWNMAX_BITS) >> SPAWNMAX_POS);
		}

		public static int GET_TOTAL(int target)
		{
			return (((target) & TOTAL_BITS) >> TOTAL_POS);
		}

		public static int GET_NPCGEN(int target)
		{
			return (((target) & NPCGEN_BITS) >> NPCGEN_POS);
		}

		public static int MAKE_GENID(int x, int gid)
		{
			return (((x) & ~GENERATOR_BITS) | (((gid) & (GENERATOR_BITS >> GENERATOR_POS))) << GENERATOR_POS);
		}

		public static int MAKE_SPAWNMAX(int x, int max)
		{
			return (((x) & ~SPAWNMAX_BITS) | (((max) & (SPAWNMAX_BITS >> SPAWNMAX_POS))) << SPAWNMAX_POS);
		}

		public static int MAKE_TOTAL(int x, int tot)
		{
			return (((x) & ~TOTAL_BITS) | (((tot) & (TOTAL_BITS >> TOTAL_POS))) << TOTAL_POS);
		}

		public static int MAKE_NPCGEN(int x, int ngen)
		{
			return (((x) & ~NPCGEN_BITS) | (((ngen) & (NPCGEN_BITS >> NPCGEN_POS))) << NPCGEN_POS);
		}

		#endregion

		#region SECTOR HELPER ROUTINES

		public static ArrayList SectorTiles = new ArrayList(); // Sector data
		public static ArrayList SectorLights = new ArrayList();
		public static ArrayList SectorObjects = new ArrayList();
		public static ArrayList SectorLightsChunk = new ArrayList();

		public static uint SEC_GetSecNameFromXY(int secX, int secY)
		{
			if (secX > 0x3f) throw new ArgumentOutOfRangeException("secX", "SecX should be in range [0..0x3f]");
			if (secY > 0xff) throw new ArgumentOutOfRangeException("secY", "SecY should be in range [0..0xFF]");

			int x = secX << 26;
			int y = secY;
			return (uint)(x | y);
		}

		public static uint SEC_GetSectorCorrespondence(int worldX, int worldY) //todo: why in this order?
		{
			if (worldX > 0x3FFF) throw new ArgumentOutOfRangeException("worldX", "World Y should be in range [0..0x3FFF]");
			if (worldY > 0x0FFF) throw new ArgumentOutOfRangeException("worldY", "World X should be in range [0..0x0FFF]");

			int secX = (int)((worldY << 20) & 0xfc000000); // (worldY/64)*4 and then << 24;
			int secY = worldX >> 6; // worldX/64;
			return (uint)(secX | secY);
		}

		public static void SEC_CreateEmptySectorFile(BinaryWriter w_sec)
		{
			w_sec.Write(0); // No lights

			for (int i = 0; i < 4096; i++)
			{
				w_sec.Write((ulong) 2); // Sector tile data
				w_sec.Write((ulong) 0);
			}

			w_sec.Write(1);
			w_sec.Write((short) 4);
			w_sec.Write((byte) 0xAA);

			for (int j = 0; j < 45; j++)
				w_sec.Write((byte) 0);
		}

		public static void SEC_GetXY(string sectorName, out int x, out int y)
		{
			string sectorNameX = int.Parse(sectorName).ToString("x8");
			string sectorX = sectorNameX.Substring(0, 2);
			string sectorY = sectorNameX.Substring(6, 2);

			x = Convert.ToInt32(sectorX, 16)/4;
			y = Convert.ToInt32(sectorY, 16);
		}

		/// <summary>
		///     NOTE: in fact, minX and minY are reversed here... as well as maxX and maxY... sorry
		/// </summary>
		public static void Sec_GetMinMax(string sectorName, out int minX, out int maxX, out int minY, out int maxY)
		{
			//todo: fix minX/minY & maxX/maxY?
			uint sectorId = uint.Parse(sectorName);
			int secX = (int)((sectorId & 0xfc000000) >> 20);
			int secY = (int)((sectorId & 0xff) << 6);

			minX = secX;
			maxX = secX+63;
			minY = secY;
			maxY = secY+63;
		}

		public static void SEC_CreateNewData()
		{
			// Modifies sector data variables
			SectorLights = new ArrayList();
			SectorTiles = new ArrayList();
			SectorObjects = new ArrayList();
			SectorLightsChunk = new ArrayList();

			var tiledata = new byte[16];
			tiledata[0] = 0x02;

			for (int j = 1; j < 16; j++)
				tiledata[j] = 0x00;

			for (int i = 0; i < 4096; i++)
			{
				SectorTiles.Add(tiledata);
			}

			for (int k = 0; k < 4; k++)
				SectorObjects.Add((byte) 0x00);
		}

		public static void SEC_WriteUnknownEmptyAreas(BinaryWriter w_sec)
		{
			w_sec.Write(1);
			w_sec.Write((short) 4);
			w_sec.Write((byte) 0xAA);

			for (int j = 0; j < 41; j++)
				w_sec.Write((byte) 0);
		}

		public static void SEC_SetTileData(int X, int Y, byte[] tiledata)
		{
			if (X < 0 || X > 63 || Y < 0 || Y > 63)
				return;

			//todo: FIXME: Tile position in an array of tiles?
			int target = Y*64 + X;

			SectorTiles[target] = tiledata;
		}

		public static byte[] SEC_MakeTileData(byte STEP_SOUND, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8, byte b9, byte b10, byte b11, byte b12, byte b13, byte b14, byte b15)
		{
			var tiledata = new byte[16];

			tiledata[0] = STEP_SOUND;
			tiledata[1] = b1;
			tiledata[2] = b2;
			tiledata[3] = b3;
			tiledata[4] = b4; /* +WALL FLAGS+ */
			tiledata[5] = b5;
			tiledata[6] = b6;
			tiledata[7] = b7; /* -WALL FLAGS- */
			tiledata[8] = b8;
			tiledata[9] = b9;
			tiledata[10] = b10;
			tiledata[11] = b11;
			tiledata[12] = b12;
			tiledata[13] = b13;
			tiledata[14] = b14;
			tiledata[15] = b15;

			return tiledata;
		}

		public static bool SEC_SetTileDataRange(int minX, int maxX, int minY, int maxY, byte[] tiledata) //todo: VERIFY: Double-check how well this works!
		{
			bool IS_VALID_RECT = true;

			if (minX < 0 || minX > 63 || maxX < 0 || maxX > 63 || minY < 0 || minY > 63 || maxY < 0 || maxY > 63)
			{
				IS_VALID_RECT = false;
				return IS_VALID_RECT;
			}

			for (int y = minY; y <= maxY; y++)
			{
				for (int x = minX; x <= maxX; x++)
				{
					SEC_SetTileData(x, y, tiledata);
				}
			}

			return IS_VALID_RECT;
		}

		#endregion

		#region SVB UTILITY ROUTINES

		// SVB Format: each SVB file is 18432 bytes long
		//             the total bitmap size in SVB is, thus, 147456 bits long
		//             (internal: it's exactly 4608 blocks)
		//             Y*64+X load order, 9 semi-tiles per tile, 4-bit semi-tiles
		public static string SVB_NewBitmap()
		{
			string SVB_BMP = "";

			for (int i = 0; i < 1152; i++)
				SVB_BMP += "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

			return SVB_BMP;
		}

		/// <summary>
		///     Return the location of the first bit belonging to the (X,Y) tile
		///     in a sector visibility block bitmap
		/// </summary>
		public static int SVB_GetTileAddress(int X, int Y)
		{
			if (X < 0 || X > 63 || Y < 0 || Y > 63)
				return -1;

			/* Updated (v1.7.5q): totally rewrote the SVB tile_loc to match the correct value
			 *                    Now tile_loc points to the upper left (UL) bit of the tile
			 *                    UL = 576*4*Y + 3*4*X
			 *                    UM = (576*4*Y + 3*4*X) + 4
			 *                    UR = (576*4*Y + 3*4*X) + 8
			 *                    ML = (576*4*Y + 3*4*X) + 192
			 *                    MM = (576*4*Y + 3*4*X) + 192 + 4
			 *                    MR = (576*4*Y + 3*4*X) + 192 + 8
			 *                    LL = (576*4*Y + 3*4*X) + 384
			 *                    LM = (576*4*Y + 3*4*X) + 384 + 4
			 *                    LR = (576*4*Y + 3*4*X) + 384 + 8
			 */
			int tile_loc = 2304*Y + 12*X;
			return tile_loc;
		}

		public static string SVB_SetPropertyLine(string Bitmap, string DestBitmap, int Property_ID)
		{
			if (Property_ID > Bitmap.Length - 36)
				return "NOT_VALID";

			Bitmap = Bitmap.Substring(0, Property_ID) + DestBitmap + Bitmap.Substring(Property_ID + 36);

			return Bitmap;
		}

		#endregion

		#region HSD-SPECIFIC ROUTINES

		public static byte[] HSD_Tiles;

		public static byte[] HSD_NewArray()
		{
			var HSD = new byte[36864];

			for (int i = 0; i < HSD.GetUpperBound(0); i++)
				HSD[i] = 0x00; // initialize

			return HSD;
		}

		public static bool HSD_CheckIsSaveNecessary()
		{
			for (int i = 0; i < HSD_Tiles.GetUpperBound(0); i++)
			{
				if (HSD_Tiles[i] != 0x00) // it's necessary to save
					return true;
			}

			return false;
		}

		public static int HSD_GetTileAddress(int X, int Y)
		{
			if (X < 0 || X > 63 || Y < 0 || Y > 63)
				return -1;

			int tile_loc = ((Y*64 + X)*9) + 1;
			return tile_loc;
		}

		public static void HSD_ModifyProperty(int tile_ptr, bool source)
		{
			if (source)
				HSD_Tiles[tile_ptr] = 0x24;
			else
				HSD_Tiles[tile_ptr] = 0x00;
		}

		public static void HSD_ModifyProperty(int tile_ptr, bool source, byte neg_height)
		{
			if (source)
				HSD_Tiles[tile_ptr] = neg_height;
			else
				HSD_Tiles[tile_ptr] = 0x00;
		}

		#endregion

		#region Obsolete SECTOR LIGHTS CODE

		// Light info. Must be exactly 108 bytes long.
		// * THIS CODE IS OUTDATED AND IS LEFT ONLY FOR COMPATIBILITY WITH OTHER FACILITIES *
		// * OF THE TOEEWB SECTOR EDITOR *

		[Obsolete]
		public static void SaveLight(BinaryWriter buf, LightInfo light)
		{
			buf.Write(light.unknown1); // 4
			buf.Write(light.unknown2); // 8
			buf.Write(light.unknown3_ltype); // 12
			buf.Write(light.unknown4_flags); // 16
			buf.Write(light.red); // 17
			buf.Write(light.blue); // 18
			buf.Write(light.green); // 19
			buf.Write(light.unknown5); // 20
			buf.Write(light.unknown6); // 24
			buf.Write(light.loc_x); // 28
			buf.Write(light.loc_y); // 32
			buf.Write(light.ofs_x); // 36
			buf.Write(light.ofs_y); // 40
			buf.Write(light.ofs_z); // 44
			buf.Write(light.unknown7); // 48
			buf.Write(light.unknown8); // 52
			buf.Write(light.unknown9); // 56
			buf.Write(light.radius); // 60
			buf.Write(light.unknown10); // 64
			buf.Write(light.unknown11); // 68
			buf.Write(light.unknown12); // 72
			buf.Write(light.unknown13); // 76
			buf.Write(light.unknown14_start_angle); // 80
			buf.Write(light.unknown15_end_angle); // 84
			buf.Write(light.unknown16); // 88
			buf.Write(light.unknown17_facing_x); // 92
			buf.Write(light.unknown18_facing_y); // 96
			buf.Write(light.unknown19_facing_z); // 100
			buf.Write(light.unknown20_affects_color); // 104
			buf.Write(light.unknown21); // 108
		}

		[Obsolete]
		public static void LoadLight(BinaryReader buf, ref LightInfo light)
		{
			// ReSharper disable UseObjectOrCollectionInitializer
			light = new LightInfo();
			// ReSharper restore UseObjectOrCollectionInitializer

			light.unknown1 = buf.ReadUInt32();
			light.unknown2 = buf.ReadUInt32();
			light.unknown3_ltype = buf.ReadUInt32();
			light.unknown4_flags = buf.ReadUInt32();
			light.red = buf.ReadByte();
			light.blue = buf.ReadByte();
			light.green = buf.ReadByte();
			light.unknown5 = buf.ReadByte();
			light.unknown6 = buf.ReadUInt32();
			light.loc_x = buf.ReadUInt32();
			light.loc_y = buf.ReadUInt32();
			light.ofs_x = buf.ReadSingle();
			light.ofs_y = buf.ReadSingle();
			light.ofs_z = buf.ReadSingle();
			light.unknown7 = buf.ReadSingle();
			light.unknown8 = buf.ReadSingle();
			light.unknown9 = buf.ReadSingle();
			light.radius = buf.ReadSingle();
			light.unknown10 = buf.ReadSingle();
			light.unknown11 = buf.ReadUInt32();
			light.unknown12 = buf.ReadUInt32();
			light.unknown13 = buf.ReadUInt32();
			light.unknown14_start_angle = buf.ReadSingle();
			light.unknown15_end_angle = buf.ReadSingle();
			light.unknown16 = buf.ReadSingle();
			light.unknown17_facing_x = buf.ReadSingle();
			light.unknown18_facing_y = buf.ReadSingle();
			light.unknown19_facing_z = buf.ReadSingle();
			light.unknown20_affects_color = buf.ReadSingle();
			light.unknown21 = buf.ReadUInt32();
		}

		[Obsolete]
		public struct LightInfo
		{
			public byte blue; // 18
			public byte green; // 19
			public uint loc_x; // 28
			public uint loc_y; // 32
			public float ofs_x; // 36
			public float ofs_y; // 40
			public float ofs_z; // 44
			public float radius; // 60
			public byte red; // 17
			public int struct_errorlevel;
			public uint unknown1; // 4
			public float unknown10; // 64
			public uint unknown11; // 68
			public uint unknown12; // 72
			public uint unknown13; // 76
			public float unknown14_start_angle; // 80
			public float unknown15_end_angle; // 84
			public float unknown16; // 88
			public float unknown17_facing_x; // 92
			public float unknown18_facing_y; // 96
			public float unknown19_facing_z; // 100
			public uint unknown2; // 8
			public float unknown20_affects_color; // 104
			public uint unknown21; // 108
			public uint unknown3_ltype; // 12
			public uint unknown4_flags; // 16
			public byte unknown5; // 20
			public uint unknown6; // 24
			public float unknown7; // 48
			public float unknown8; // 52
			public float unknown9; // 56
			/* ERROR LEVEL */
		}

		#endregion

		#region WAYPOINT STRUCTURE

		public static void SaveWaypoint(BinaryWriter buf, WaypointInfo way)
		{
			buf.Write(way.flags);
			buf.Write(way.X);
			buf.Write(way.Y);
			buf.Write(way.Xofs);
			buf.Write(way.Yofs);
			buf.Write(way.Rotation);
			buf.Write(way.anim1);
			buf.Write(way.anim2);
			buf.Write(way.anim3);
			buf.Write(way.anim4);
			buf.Write(way.anim5);
			buf.Write(way.anim6);
			buf.Write(way.anim7);
			buf.Write(way.anim8);
			buf.Write(way.delay);
			buf.Write(way.z8);
			buf.Write(way.z9);
			buf.Write(way.z10);
			buf.Write(way.z11);
			buf.Write(way.z12);
			buf.Write(way.z13);
			buf.Write(way.z14);
		}

		public static WaypointInfo LoadWaypoint(BinaryReader buf)
		{
			var way = new WaypointInfo();

			way.flags = buf.ReadUInt32();
			way.X = buf.ReadUInt32();
			way.Y = buf.ReadUInt32();
			way.Xofs = buf.ReadSingle();
			way.Yofs = buf.ReadSingle();
			way.Rotation = buf.ReadSingle();
			way.anim1 = buf.ReadByte();
			way.anim2 = buf.ReadByte();
			way.anim3 = buf.ReadByte();
			way.anim4 = buf.ReadByte();
			way.anim5 = buf.ReadByte();
			way.anim6 = buf.ReadByte();
			way.anim7 = buf.ReadByte();
			way.anim8 = buf.ReadByte();
			way.delay = buf.ReadUInt32();
			way.z8 = buf.ReadUInt32();
			way.z9 = buf.ReadUInt32();
			way.z10 = buf.ReadUInt32();
			way.z11 = buf.ReadUInt32();
			way.z12 = buf.ReadUInt32();
			way.z13 = buf.ReadUInt32();
			way.z14 = buf.ReadUInt32();

			return way;
		}

		public static WaypointInfo CreateWaypoint(uint X, uint Y, byte a1, byte a2, byte a3, byte a4, byte a5, byte a6, byte a7, byte a8, float ROT, uint DELAY, bool IsAnimated, bool IsRotated, bool IsDelayed)
		{
			var way = new WaypointInfo();
			way.X = X;
			way.Y = Y;

			// set the flags
			way.flags = 0;
			if (IsRotated)
				way.flags += 1;
			if (IsDelayed)
				way.flags += 2;
			if (IsAnimated)
				way.flags += 4;

			way.anim1 = a1;
			way.anim2 = a2;
			way.anim3 = a3;
			way.anim4 = a4;
			way.anim5 = a5;
			way.anim6 = a6;
			way.anim7 = a7;
			way.anim8 = a8;

			way.Rotation = ROT;
			way.delay = DELAY;

			return way;
		}

		public struct WaypointInfo
		{
			public float Rotation; // 6
			public uint X; // 2
			public float Xofs; // 4
			public uint Y; // 3
			public float Yofs; // 5
			//public uint z5; // 7
			//public uint z6; // 8
			public byte anim1; // 8 animation indices per waypoint
			public byte anim2;
			public byte anim3;
			public byte anim4;
			public byte anim5;
			public byte anim6;
			public byte anim7;
			public byte anim8;
			public uint delay; // 9
			public uint flags; // FLAGS
			public uint z10; // 12
			public uint z11; // 13
			public uint z12; // 14
			public uint z13; // 15
			public uint z14; // 16
			public uint z8; // 10
			public uint z9; // 11
		}

		#endregion

		#region Light structures for the Extended Sector Light Editor

		public uint LGT_ANIMATED = 0x00000004;
		public uint LGT_EXTENDED_LIGHT = 0x00000010;
		public uint LGT_PARTICLE_SYSTEM = 0x00000020;
		public uint LGT_STATUS_1 = 0x00000001; // Light flags
		public uint LGT_STATUS_2 = 0x00000002;
		public uint LGT_VIEW_CONTROLS = 0x00000008;

		/// <summary>
		///     A basic 64-byte light. A structure that must be defined for all lights.
		/// </summary>
		public struct LightBasic
		{
			public float angle; // light angle
			public byte blue; // blue
			public Vector3 direction; // direction of the light
			public uint flags; // light flags
			public byte green; // green
			public ulong handle; // must always be 0x0?
			public float height; // offset Z (height)
			public float ofs_x; // offset X
			public float ofs_y; // offset Y
			public byte padding1; // padding area (has no effect)
			public uint padding2; // padding area (has no effect)
			public float range; // light range
			public byte red; // red
			public uint type; // light type
			public uint x; // coordinate X
			public uint y; // coordinate Y
		}

		/// <summary>
		///     Extended light structure. Incorporates both the primary and the secondary lights. 108 bytes long.
		///     It is recommended to use this structure in any case, and write back necessary parts of the light
		///     per the flags and type.
		/// </summary>
		public struct LightEx
		{
			public LightPrimary light_pri;
			public LightSecondary light_sec;
		}

		/// <summary>
		///     Primary light structure. Used for all light types and wraps a basic light. 72 bytes long.
		/// </summary>
		public struct LightPrimary
		{
			public LightBasic light1; // primary light
			public PartSys partsys1; // primary light particle system
		}

		/// <summary>
		///     Secondary light structure. Used only for certain light types.
		/// </summary>
		public struct LightSecondary
		{
			public float angle; // light angle
			public byte blue; // blue
			public Vector3 direction; // direction of the light
			public byte green; // green
			public byte padding1; // padding area (has no effect)
			public PartSys partsys2; // secondary light particle system
			public float range; // light range
			public byte red; // red
			public uint type; // light type
		}

		/// <summary>
		///     Particle system substructure.
		/// </summary>
		public struct PartSys
		{
			public uint hash_id; // hash ID for the particle system name
			public uint id; // ID of the particle system
		}

		/// <summary>
		///     A structure defining three a 3-dimensional (x,y,z) vector
		/// </summary>
		public struct Vector3
		{
			public float x;
			public float y;
			public float z;
		}

		#endregion
	}
}