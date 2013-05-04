// ToEE World Builder .NET2 version 2.0.0 Open-Source Edition
// Copyright (C) 2005-2006    Michael Kamensky, all rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

using System;
using System.Collections;

// Path node helper class. Contains auxiliary functions to work with PND files.
public class PNDHelper
{
	private PNDHelper(){} /* static methods only */

	public static bool PND_MODE_ACTIVE = false;
	public static bool PND_HAS_CHANGED = false; // Require regeneration of nodes
	public static uint CURRENT_TOP_ID = 0; // Current top ID of the node
	public static float MAX_PATH_LENGTH = 22.0F; // Tolerance for detecting neighboring nodes, in tiles
												// (experimental, other possible values are 22.5F and 21.5F)

	public static Hashtable PathNodes = new Hashtable(); // All loaded path nodes
	public static Hashtable PathNodeGoals = new Hashtable(); // Corresponding neighboring node IDs
	
	// A basic path node (goals are linked externally through a hash table)
	public struct PathNode
	{
		public uint ID;
		public uint X;
		public uint Y;
		public float OfsX;
		public float OfsY;
	}

	// Get the total distance (path length) from (x1,y1) to (x2,y2) in tiles
	public static float GetPathLength(uint x1, uint y1, uint x2, uint y2)
	{
		decimal lenX = Math.Abs((decimal)x2-x1);
		decimal lenY = Math.Abs((decimal)y2-y1);
		double lenH = (double)((lenX*lenX)+(lenY*lenY));
		
		float Dist = (float)(Math.Sqrt(lenH));
		return Dist;
	}

	// Detect whether the path node is within the needed radius to be considered
	// a 'neighboring' path node (modify MAX_PATH_LENGTH to change the tolerance)
	public static bool IsNeighboring(float dist)
	{
		if (dist <= MAX_PATH_LENGTH)
			return true;

		return false;
	}
}

