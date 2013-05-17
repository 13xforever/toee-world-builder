using System.Linq;

namespace WorldBuilder
{
	public class Hsd
	{
		public readonly byte[] Tiles = new byte[0x0900];

		public bool IsModified { get { return Tiles.Any(t => t != 0x00); } }

		public static int GetTileAddress(int x, int y)
		{
			if (x < 0 || x > 63 || y < 0 || y > 63)
				return -1;

			return ((y*64 + x)*9) + 1;
		}

		public void SetTile(int tilePtr, bool source, byte negativeHeight = 0x24)
		{
			Tiles[tilePtr] = source ? negativeHeight : (byte)0x00;
		}
	}
}