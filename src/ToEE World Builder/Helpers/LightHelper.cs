using System;
using System.IO;

namespace WorldBuilder.Helpers
{
	[Obsolete]
	public static class LightHelper
	{
		// Light info. Must be exactly 108 bytes long.
		// * THIS CODE IS OUTDATED AND IS LEFT ONLY FOR COMPATIBILITY WITH OTHER FACILITIES *
		// * OF THE TOEEWB SECTOR EDITOR *
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
	}
}