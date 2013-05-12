using System;
using System.Collections;
using System.IO;

namespace WorldBuilder.Helpers
{
	public static class SecHelper
	{
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
			string sectorNameX = Int32.Parse(sectorName).ToString("x8");
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
			uint sectorId = UInt32.Parse(sectorName);
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
	}
}