using System.Linq;

namespace WorldBuilder.Helpers
{
	public static class HsdHelper
	{
		public static byte[] Tiles { get; private set; }

		public static void Init()
		{
			Tiles = new byte[0x09000];
		}

		public static bool IsModified()
		{
			return Tiles.Any(t => t != 0x00);
		}

		public static int GetTileAddress(int x, int y)
		{
			if (x < 0 || x > 63 || y < 0 || y > 63)
				return -1;

			return ((y*64 + x)*9) + 1;
		}

		public static void ModifyProperty(int tilePtr, bool source, byte negativeHeight = 0x24)
		{
			Tiles[tilePtr] = source ? negativeHeight : (byte)0x00;
		}
	}
}