using System;
using System.Collections;

/// <summary>
///     Path node helper class. Contains auxiliary functions to work with PND files.
/// </summary>
public static class PNDHelper
{
	public static bool PND_MODE_ACTIVE = false;
	public static bool PND_HAS_CHANGED = false; // Require regeneration of nodes
	public static uint CURRENT_TOP_ID = 0; // Current top ID of the node
	public static float MAX_PATH_LENGTH = 22.0F; // Tolerance for detecting neighboring nodes, in tiles (experimental, other possible values are 22.5F and 21.5F)
	public static Hashtable PathNodes = new Hashtable(); // All loaded path nodes
	public static Hashtable PathNodeGoals = new Hashtable(); // Corresponding neighboring node IDs

	/// <summary>
	///     Get the total distance (path length) from (x1,y1) to (x2,y2) in tiles
	/// </summary>
	public static float GetPathLength(uint x1, uint y1, uint x2, uint y2)
	{
		decimal lenX = Math.Abs((decimal) x2 - x1);
		decimal lenY = Math.Abs((decimal) y2 - y1);
		var lenH = (double) ((lenX*lenX) + (lenY*lenY));
		var Dist = (float) (Math.Sqrt(lenH));
		return Dist;
	}

	/// <summary>
	///     Detect whether the path node is within the needed radius to be considered
	///     a 'neighboring' path node (modify MAX_PATH_LENGTH to change the tolerance)
	/// </summary>
	public static bool IsNeighboring(float dist)
	{
		return dist <= MAX_PATH_LENGTH;
	}

	/// <summary>
	///     A basic path node (goals are linked externally through a hash table)
	/// </summary>
	public struct PathNode
	{
		public uint ID;
		public float OfsX;
		public float OfsY;
		public uint X;
		public uint Y;
	}
}