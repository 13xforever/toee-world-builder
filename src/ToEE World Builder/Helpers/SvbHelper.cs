namespace WorldBuilder.Helpers
{
	public static class SvbHelper
	{
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
	}
}