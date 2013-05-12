using System.IO;

namespace WorldBuilder.Helpers
{
	public static class WaypointHelper
	{
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
			// ReSharper disable UseObjectOrCollectionInitializer
			var way = new WaypointInfo();
			// ReSharper restore UseObjectOrCollectionInitializer

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
			uint flags = 0;
			if (IsRotated)
				flags += 1;
			if (IsDelayed)
				flags += 2;
			if (IsAnimated)
				flags += 4;

			return new WaypointInfo {X = X, Y = Y, flags = flags, anim1 = a1, anim2 = a2, anim3 = a3, anim4 = a4, anim5 = a5, anim6 = a6, anim7 = a7, anim8 = a8, Rotation = ROT, delay = DELAY};
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
	}
}