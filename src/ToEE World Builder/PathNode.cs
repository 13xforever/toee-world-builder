using System;

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

		public bool IsNear(PathNode otherNode, double vicinity)
		{
			double lenX = Math.Abs((long)X - otherNode.X);
			double lenY = Math.Abs((long)Y - otherNode.Y);
			var lenH = lenX * lenX + lenY * lenY;
			var dist = Math.Sqrt(lenH);
			return dist <= vicinity;
		}
	}
}