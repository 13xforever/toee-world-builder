using System;
using System.IO;

namespace WorldBuilder.Helpers
{
	/// <summary>
	///     Path node helper class. Contains auxiliary functions to work with PND files.
	/// </summary>
	public static class PathNodeHelper
	{
		public static PathNode ReadPathNode(this BinaryReader reader)
		{
			return new PathNode(reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadSingle(), reader.ReadSingle());
		}
	
		public static void WritePathNode(this BinaryWriter writer, PathNode node)
		{
			writer.Write(node.Id);
			writer.Write(node.X);
			writer.Write(node.Y);
			writer.Write(node.OffsetX);
			writer.Write(node.OffsetY);
		}
	}
}