using System;

namespace WorldBuilder
{
	public class PathNode
	{
		public readonly uint Id;
		public readonly float OffsetX;
		public readonly float OffsetY;
		public readonly uint X;
		public readonly uint Y;

		public PathNode(uint id, uint x, uint y, float offsetX, float offsetY)
		{
			Id = id;
			X = x;
			Y = y;
			OffsetX = offsetX;
			OffsetY = offsetY;
		}

		public bool IsNear(PathNode otherNode, double vicinity) //todo: research: why float?
		{
			if (otherNode == null) throw new ArgumentNullException("otherNode");
			if (otherNode.Id == Id) return false;

			double lenX = Math.Abs((long)X - otherNode.X);
			double lenY = Math.Abs((long)Y - otherNode.Y);
			var lenH = lenX * lenX + lenY * lenY;
			var dist = Math.Sqrt(lenH);
			return dist <= vicinity;
		}

		public override string ToString()
		{
			return string.Format("ID #{0}: ({1}, {2})", Id, X, Y);
		}
	}
}