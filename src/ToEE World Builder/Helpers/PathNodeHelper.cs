using System;
using System.Collections.Generic;
using System.IO;

namespace WorldBuilder.Helpers
{
	/// <summary>
	///     Path node helper class. Contains auxiliary functions to work with PND files.
	/// </summary>
	public static class PathNodeHelper
	{
		public static bool PND_MODE_ACTIVE;
		public static bool PND_HAS_CHANGED; // Require regeneration of nodes
		public static uint CURRENT_TOP_ID; // Current top ID of the node
		public static double MAX_PATH_LENGTH = 22.0d; // Tolerance for detecting neighboring nodes, in tiles (experimental, other possible values are 22.5 and 21.5)
		public static readonly Dictionary<uint, PathNode> PathNodes = new Dictionary<uint,PathNode>(); // All loaded path nodes
		public static readonly Dictionary<uint, string> PathNodeGoals = new Dictionary<uint, string>(); // Corresponding neighboring node IDs

		/// <summary>
		///     Get the total distance (path length) from (x1,y1) to (x2,y2) in tiles
		/// </summary>
		public static double GetPathLength(uint x1, uint y1, uint x2, uint y2)
		{
			double lenX = Math.Abs((long) x2 - x1);
			double lenY = Math.Abs((long) y2 - y1);
			var lenH = lenX*lenX + lenY*lenY;
			return Math.Sqrt(lenH);
		}

		/// <summary>
		///     Detect whether the path node is within the needed radius to be considered
		///     a 'neighboring' path node (modify MAX_PATH_LENGTH to change the tolerance)
		/// </summary>
		public static bool IsNeighboring(double dist)
		{
			return dist <= MAX_PATH_LENGTH;
		}

		public static PathNode ReadPathNode(this BinaryReader br)
		{
			return new PathNode(br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32(), br.ReadSingle(), br.ReadSingle());
		}
	}
}