using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace WorldBuilder.Helpers
{
	public static class MobHelper
	{
		public static string LastOpenedMob = ""; // v1.7.5s1: For Cerulean the Blue: a string of last opened MOB file
		public static string InteropPath = "C:\\wb200_il.lri"; // interoperability support for v2.0.0
		public static readonly Dictionary<short, string> ProtoById = new Dictionary<short, string>();
		public static string SectorName = "NOT_DETECTED";
		public static bool EmbedMode;

		public static void GenerateGuid(out string s_GUID, out byte[] GUID)
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

		public static byte BitmapBlockToByte(string BitmapBlock)
		{
			string BitmapReal = "";

			for (int i = 7; i >= 0; i--)
				BitmapReal += BitmapBlock[i];

			return Convert.ToByte(BitmapReal, 2);
		}

		public static ArrayList BitmapToBytes(string Bitmap)
		{
			var bytes = new ArrayList();

			for (int i = 0; i < Bitmap.Length; i += 8)
			{
				string element = Bitmap.Substring(i, 8);
				bytes.Add(BitmapBlockToByte(element));
			}

			return bytes;
		}

		public static Int16 GetNumberOfProperties(string Bitmap)
		{
			Int16 no_props = 0;

			for (int i = 0; i < Bitmap.Length; i++)
			{
				if (Bitmap[i] == '1')
					no_props++;
			}

			return no_props;
		}

		public static byte[] ReturnHeader(Int16 Proto_ID)
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
		public static byte[] ReturnHeader(Int16 Proto_ID, bool MarkAsCompatible)
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

		public static byte[] ReturnHeader(Int16 Proto_ID, bool DONT_USE_DEPRECATED, bool GenerateObjID)
		{
			var header = new byte[28];
			header[0x00] = 0x77;
			header[0x04] = 0x01;

			var PROTO_HIGH = (byte) Proto_ID;
			var PROTO_LOW = (byte) (Proto_ID >> 8);

			header[0x0C] = PROTO_HIGH;
			header[0x0D] = PROTO_LOW;

			if (GenerateObjID)
				header = GenerateObjId(header);

			return header;
		}

		public static int GetNumberofBitmapBlocks(MobType MobType)
		{
			int Num_Blocks = 4;

			switch (MobType)
			{
				case MobType.obj_t_portal:
					Num_Blocks = 4;
					break;
				case MobType.obj_t_container:
					Num_Blocks = 4;
					break;
				case MobType.obj_t_scenery:
					Num_Blocks = 5;
					break;
				case MobType.obj_t_projectile:
					Num_Blocks = 5;
					break;
				case MobType.obj_t_weapon:
					Num_Blocks = 7;
					break;
				case MobType.obj_t_ammo:
					Num_Blocks = 7;
					break;
				case MobType.obj_t_armor:
					Num_Blocks = 8;
					break;
				case MobType.obj_t_money:
					Num_Blocks = 8;
					break;
				case MobType.obj_t_food:
					Num_Blocks = 8;
					break;
				case MobType.obj_t_scroll:
					Num_Blocks = 8;
					break;
				case MobType.obj_t_key:
					Num_Blocks = 9;
					break;
				case MobType.obj_t_written:
					Num_Blocks = 9;
					break;
				case MobType.obj_t_generic:
					Num_Blocks = 9;
					break;
				case MobType.obj_t_pc:
					Num_Blocks = 11;
					break;
				case MobType.obj_t_npc:
					Num_Blocks = 13;
					break;
				case MobType.obj_t_trap:
					Num_Blocks = 13;
					break;
				case MobType.obj_t_bag:
					Num_Blocks = 9;
					break;
				default:
					throw new Exception("Unexpected Error 001: Undefined mobile type used to create a bitmap!");
			}

			return Num_Blocks;
		}

		public static string CreateBitmap(MobType MobType)
		{
			string Bitmap = "";
			int Num_Blocks = GetNumberofBitmapBlocks(MobType);

			for (int i = 0; i < Num_Blocks*32; i++)
				Bitmap += "0";

			return Bitmap;
		}

		public static string CreateBitmap(int NumberOfBlocks)
		{
			string Bitmap = "";

			for (int i = 0; i < NumberOfBlocks*32; i++)
				Bitmap += "0";

			return Bitmap;
		}

		public static string BytesToBitmap(ArrayList bytes)
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

		public static string BytesToBitmap(byte[] bytes)
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

		public static TriState GetPropertyState(string Bitmap, int Property_ID)
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
		public static string SetProperty(string Bitmap, int Property_ID)
		{
			if (Property_ID > Bitmap.Length - 1)
				return "NOT_VALID";

			Bitmap = Bitmap.Substring(0, Property_ID) + "1" + Bitmap.Substring(Property_ID + 1);

			return Bitmap;
		}

		public static string ClearProperty(string Bitmap, int Property_ID)
		{
			if (Property_ID > Bitmap.Length - 1)
				return "NOT_VALID";

			Bitmap = Bitmap.Substring(0, Property_ID) + "0" + Bitmap.Substring(Property_ID + 1);

			return Bitmap;
		}

		public static string ModifyProperty(string Bitmap, int Property_ID, bool Value)
		{
			if (Value)
				return SetProperty(Bitmap, Property_ID);
			else
				return ClearProperty(Bitmap, Property_ID);
		}

		/// <summary>
		///     A random mobile object proto ObjID generator, based on random
		///     number generation within known limits. This code will serve as a
		///     means of making the object more unique in the game memory space.
		/// </summary>
		public static byte[] GenerateObjId(byte[] header)
		{
			byte[] header_with_objid = header;
			var r = new Random();
			int objid_mod_1 = r.Next(0x00010101, 0x00FFFFFF);
			int objid_mod_2 = r.Next(0x00010101, 0x00FFFFFF);
			var objid_mod_pre = (short) r.Next(Int16.MinValue, Int16.MaxValue);
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
		public static uint GenerateSarc(bool s_mode)
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
	}
}