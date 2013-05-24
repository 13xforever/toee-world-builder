using System;
using System.Collections.Generic;
using System.IO;

namespace WorldBuilder.Helpers
{
	public static class SecHelper
	{
		public static List<byte[]> SectorTiles = new List<byte[]>(); // Sector data
		public static List<LightExHelper.LightEx> SectorLights = new List<LightExHelper.LightEx>();
		public static List<LightHelper.LightInfo> SectorLightsOld = new List<LightHelper.LightInfo>(); //todo: nuke this
		public static List<byte> SectorObjects = new List<byte>();
		public static List<byte[]> SectorLightsChunk = new List<byte[]>();

		public static uint GetSecNameFromXY(int secX, int secY)
		{
			if (secX > 0x3f) throw new ArgumentOutOfRangeException("secX", "SecX should be in range [0..0x3f]");
			if (secY > 0xff) throw new ArgumentOutOfRangeException("secY", "SecY should be in range [0..0xFF]");

			int x = secX << 26;
			int y = secY;
			return (uint)(x | y);
		}

		public static uint GetSectorCorrespondence(int worldX, int worldY)
		{
			if (worldX > 0x3FFF) throw new ArgumentOutOfRangeException("worldX", "World Y should be in range [0..0x3FFF]");
			if (worldY > 0x0FFF) throw new ArgumentOutOfRangeException("worldY", "World X should be in range [0..0x0FFF]");

			int secX = (int)((worldY << 20) & 0xfc000000); // (worldY/64)*4 and then << 24;
			int secY = worldX >> 6; // worldX/64;
			return (uint)(secX | secY);
		}

		public static void CreateEmptySectorFile(BinaryWriter writer)
		{
			writer.Write(0); // No lights
			for (int i = 0; i < 0x1000; i++)
			{
				writer.Write((ulong) 2); // Sector tile data
				writer.Write((ulong) 0);
			}
			writer.Write((int)1);
			writer.Write((short) 4);
			writer.Write((byte) 0xaa);
			for (int j = 0; j < 0x2d; j++)
				writer.Write((byte) 0);
		}

		public static void GetXY(string sectorName, out byte x, out byte y)
		{
			var sector = uint.Parse(sectorName);
			x = (byte)(sector >> 26);
			y = (byte)(sector);
		}

		/// <summary>
		///     NOTE: in fact, minX and minY are reversed here... as well as maxX and maxY... sorry
		/// </summary>
		public static void GetMinMax(string sectorName, out int minX, out int maxX, out int minY, out int maxY)
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

		public static void CreateNewData()
		{
			// Modifies sector data variables
			SectorLights = new List<LightExHelper.LightEx>();
			SectorTiles = new List<byte[]>();
			SectorObjects = new List<byte> {0x00, 0x00, 0x00, 0x00};
			SectorLightsChunk = new List<byte[]>();

			var tiledata = new byte[16];
			tiledata[0] = 0x02;

			for (int i = 0; i < 0x1000; i++)
				SectorTiles.Add(tiledata); //todo: filling with 4096 references to the same array? why bother?
		}

		public static void WriteUnknownEmptyAreas(BinaryWriter writer)
		{
			writer.Write((int)0x00000001);
			writer.Write((short) 0x0004);
			writer.Write((byte) 0xaa);
			for (int j = 0; j < 41; j++)
				writer.Write((byte) 0x00);
		}

		public static void SetTileData(int x, int y, byte[] tiledata)
		{
			if (x < 0 || x > 63 || y < 0 || y > 63)
				return;

			int target = y * 64 + x; //todo: FIXME: Tile position in an array of tiles?
			SectorTiles[target] = tiledata;
		}

		public static byte[] MakeTileData(byte stepSound, byte b1, byte b2, byte b3, //todo: better parameters handling
										byte b4, byte b5, byte b6, byte b7,
										byte b8, byte b9, byte b10, byte b11,
										byte b12, byte b13, byte b14, byte b15)
		{
			return new[]
						{
							stepSound, b1, b2, b3,
							b4, b5, b6, b7, // wall flags
							b8, b9, b10, b11,
							b12, b13, b14, b15
						};
		}

		public static bool SetTileDataRange(int minX, int maxX, int minY, int maxY, byte[] tiledata) //todo: VERIFY: Double-check how well this works!
		{
			if (minX < 0 || minX > 63 || maxX < 0 || maxX > 63 || minY < 0 || minY > 63 || maxY < 0 || maxY > 63)
				return false;

			for (int y = minY; y <= maxY; y++)
				for (int x = minX; x <= maxX; x++)
					SetTileData(x, y, tiledata);
			return true;
		}
	}
}