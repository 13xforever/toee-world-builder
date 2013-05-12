namespace WorldBuilder.Helpers
{
	public static class HsdHelper
	{
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
	}
}