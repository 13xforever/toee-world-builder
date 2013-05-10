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
		private readonly Dictionary<uint, HashSet<uint>> goals = new Dictionary<uint, HashSet<uint>>();

		public PathNode this[uint id]
		{
			get { return nodes[id]; }
			private set
			{
				nodes[id] = value;
				if (id > TopId) TopId = id;
			}
		}
		public PathNode this[uint x, uint y] { get { return nodes.Values.FirstOrDefault(n => n.X == x && n.Y == y); } }

		public uint TopId { get; private set; }
		public int Count { get { lock (theDoor) return nodes.Count; } }
		public IEnumerable<PathNode> SortedValues { get { lock (theDoor) return nodes.Values.OrderBy(n => n.Id); } }

		public IEnumerable<uint> GetSortedGoalsFor(uint nodeId) { lock (theDoor) return goals[nodeId].OrderBy(key => key); }

		private void AddGoal(uint nodeId1, uint nodeId2)
		{
			if (nodeId1 == nodeId2) return;

			if (!goals.ContainsKey(nodeId1)) goals[nodeId1] = new HashSet<uint>();
			if (!goals.ContainsKey(nodeId2)) goals[nodeId2] = new HashSet<uint>();
			goals[nodeId1].Add(nodeId2);
			goals[nodeId2].Add(nodeId1);
		}

		private void AddAllGoalsFor(PathNode node, double vicinity)
		{
			foreach (var neighbourId in nodes.Values.Where(neighbour => neighbour.IsNear(node, vicinity)).Select(neighbour => neighbour.Id))
				AddGoal(node.Id, neighbourId);
		}

		public void RegenerateLinks(double vicinity)
		{
			lock (theDoor)
			{
				goals.Clear();
				foreach (var node in nodes.Values)
					AddAllGoalsFor(node, vicinity);
			}
		}

		public bool Add(PathNode newNode, double vicinity)
		{
			lock (theDoor)
			{
				if (nodes.ContainsKey(newNode.Id)) return false;

				this[newNode.Id] = newNode;
				AddAllGoalsFor(newNode, vicinity);
			}
			return true;
		}

		public void Remove(PathNode node)
		{
			lock (theDoor)
			{
				foreach (uint goalId in goals[node.Id])
					goals[goalId].Remove(node.Id);
				goals.Remove(node.Id);
				nodes.Remove(node.Id);
			}
		}

		/// <summary>
		/// Generate automated path nodes
		/// </summary>
		public static PathNodeCollection AutoGenerate(int fromX, int toX, int fromY, int toY, int step, double vicinity)
		{
			var result = new PathNodeCollection();
			for (var x = fromX; x <= toX; x += step)
				for (var y = fromY; y <= toY; y += step)
				{
					var tile = new[]
									{
										Tuple.Create(x    , y    ),
										Tuple.Create(x + 3, y    ),
										Tuple.Create(x    , y + 3),
										Tuple.Create(x    , y - 3),
										Tuple.Create(x - 3, y    ),
										Tuple.Create(x + 3, y + 3),
										Tuple.Create(x - 3, y - 3),
										Tuple.Create(x + 3, y - 3),
										Tuple.Create(x - 3, y + 3),
									}
						.Where(t => t.Item1 >= 0 && t.Item1 <= 0x3ff && t.Item2 >= 0 && t.Item2 <= 0x0fff)
						.FirstOrDefault(n => PathNodeHelper.IsAvailableTile(n.Item1, n.Item2));
					if (tile != null)
						result.Add(new PathNode(result.TopId + 1, (uint) tile.Item1, (uint) tile.Item2, 0f, 0f), vicinity);
				}
			return result;
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
					for (int j = 0; j < goalsCount; j++)
					{
						uint goalId = reader.ReadUInt32();
						if (goalId == node.Id) continue;

						result.AddGoal(node.Id, goalId);
					}
				}
			}
			return result;
		}

		public void Save(string filename)
		{
			lock(theDoor)
				using (var writer = new BinaryWriter(new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None)))
				{
					writer.Write((uint) Count);
					foreach (var id in nodes.Keys.OrderByDescending(key => key))
					{
						writer.WritePathNode(nodes[id]);
						writer.Write(goals[id].Count);
						foreach (var goal in goals[id].OrderByDescending(key => key))
							writer.Write(goal);
					}
				}
		}

	}
}