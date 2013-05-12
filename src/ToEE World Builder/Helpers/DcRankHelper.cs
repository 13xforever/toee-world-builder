namespace WorldBuilder.Helpers
{
	public static class DcRankHelper
	{
		private const int DcBits = 0x0000007F;
		private const int DcPosition = 0;
		private const int RankBits = 0x00003F80;
		private const int RankPosition = 7;

		public static int GetDc(int target) { return (target & DcBits) >> DcPosition; }
		public static int GetRank(int target) { return (target & RankBits) >> RankPosition; }
		public static int MakeDc(int x, int dc) { return (x & ~DcBits) | (dc & (DcBits >> DcPosition)) << DcPosition; }
		public static int MakeRank(int x, int r) { return (x & ~RankBits) | (r & (RankBits >> RankPosition)) << RankPosition; }
	}
}