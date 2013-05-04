namespace WorldBuilder
{
	/// <summary>
	///     A basic path node (goals are linked externally through a hash table)
	/// </summary>
	public struct PathNode
	{
		public readonly uint Id;
		public readonly float OffsetX;
		public readonly float OffsetY;
		public readonly uint X;
		public readonly uint Y;

		public PathNode(uint id, uint x, uint y, float offsetX, float offsetY) : this()
		{
			Id = id;
			X = x;
			Y = y;
			OffsetX = offsetX;
			OffsetY = offsetY;
		}
	}
}