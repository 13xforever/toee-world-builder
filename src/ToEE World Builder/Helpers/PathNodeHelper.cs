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
		public static readonly Dictionary<uint, PathNode> PathNodes = new Dictionary<uint,PathNode>(); // All loaded path nodes
		public static readonly Dictionary<uint, string> PathNodeGoals = new Dictionary<uint, string>(); // Corresponding neighboring node IDs

		public static PathNode ReadPathNode(this BinaryReader br)
		{
			return new PathNode(br.ReadUInt32(), br.ReadUInt32(), br.ReadUInt32(), br.ReadSingle(), br.ReadSingle());
		}
	}
}