using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WorldBuilder.Helpers;

namespace WorldBuilder
{
	public class PathNodeCollection
	{
		private readonly object theDoor = new object();
		private readonly Dictionary<uint, PathNode> nodes = new Dictionary<uint, PathNode>();
		private readonly Dictionary<uint, HashSet<uint>> goals = new Dictionary<uint, HashSet<uint>>(); //todo: does order matter?
		private readonly Dictionary<uint, HashSet<uint>> goalsBackLink = new Dictionary<uint, HashSet<uint>>();
		private double vicinity = 22d; // Tolerance for detecting neighboring nodes, in tiles (experimental, other possible values are 22.5 and 21.5)

		public PathNodeCollection(PathNodeCollection nodeCollection = null)
		{
			if (nodeCollection == null) return;
			vicinity = nodeCollection.vicinity;
		}

		public PathNode this[uint id]
		{
			get { return nodes[id]; }
			private set
			{
				nodes[id] = value;
				if (id > TopId) TopId = id;
				IsDirty = true;
			}
		}
		public PathNode this[uint x, uint y] { get { return nodes.Values.FirstOrDefault(n => n.X == x && n.Y == y); } }

		public bool IsDirty { get; private set; } // Require regeneration of nodes
		public uint TopId { get; private set; }
		public int Count { get { lock (theDoor) return nodes.Count; } }
		public IEnumerable<PathNode> SortedValues { get { lock (theDoor) return nodes.Values.OrderBy(n => n.Id); } }

		public double NeighbourhoodVicinity
		{
			get { return vicinity; }
			set
			{
				if (nodes.Count == 0 || vicinity == value) return;

				vicinity = value;
				IsDirty = true;
			}
		}

		public IEnumerable<uint> GetSortedGoalsFor(uint nodeId) { lock (theDoor) return goals[nodeId].OrderBy(key => key); }

		public bool Add(PathNode newNode)
		{
			lock (theDoor)
			{
				if (nodes.ContainsKey(newNode.Id)) return false;

				var newGoals = new HashSet<uint>();
				foreach (var neighbourId in nodes.Values.Where(neighbour => neighbour.IsNear(newNode, vicinity)).Select(neighbour => neighbour.Id))
				{
					newGoals.Add(neighbourId);
					AddBackLink(neighbourId, newNode.Id);
				}
				this[newNode.Id] = newNode;
				goals[newNode.Id] = newGoals;
			}
			return true;
		}

		public void Remove(PathNode node)
		{
			lock (theDoor)
			{
				nodes.Remove(node.Id);
				goals.Remove(node.Id);
				foreach (uint goalId in goalsBackLink[node.Id])
					goals[goalId].Remove(node.Id);
				goalsBackLink.Remove(node.Id);
			}
		}

		public static PathNodeCollection Read(string filename)
		{
			var result = new PathNodeCollection();
			using (var reader = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)))
			{
				uint nodeCount = reader.ReadUInt32();
				for (int i = 0; i < nodeCount; i++)
				{
					PathNode node = reader.ReadPathNode();
					result[node.Id] = node;
					uint goalsCount = reader.ReadUInt32();

					var goals = new HashSet<uint>();
					for (int j = 0; j < goalsCount; j++)
					{
						uint goalId = reader.ReadUInt32();
						if (goalId == node.Id) continue;

						goals.Add(goalId);
						result.AddBackLink(goalId, node.Id);
					}
					result.goals[node.Id] = goals;
				}
			}
			result.IsDirty = false;
			return result;
		}

		private bool AddBackLink(uint goalId, uint nodeId)
		{
			if (!goalsBackLink.ContainsKey(goalId))
				goalsBackLink[goalId] = new HashSet<uint>();
			return goalsBackLink[goalId].Add(nodeId);
		}

		public void Save(string filename)
		{
			lock(theDoor)
				using (var writer = new BinaryWriter(new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None)))
				{
					writer.Write((uint) Count);
					foreach (var id in nodes.Keys.OrderBy(key => key))
					{
						writer.WritePathNode(nodes[id]);
						writer.Write(goals[id].Count);
						foreach (var goal in goals[id].OrderBy(key => key))
							writer.Write(goal);
					}
				}
		}

		public void RegenerateLinks()
		{
			goals.Clear();
			goalsBackLink.Clear();
			foreach (var node in nodes.Values)
			{
				var newGoals = new HashSet<uint>();
				foreach (var neighbourId in nodes.Values.Where(neighbour => neighbour.IsNear(node, vicinity)).Select(neighbour => neighbour.Id))
				{
					newGoals.Add(neighbourId);
					AddBackLink(neighbourId, node.Id);
				}
				goals[node.Id] = newGoals;
			}
			IsDirty = false;
		}
	}
}