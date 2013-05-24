using System.IO;
using System.Windows.Forms;
using WorldBuilder.Forms;

namespace WorldBuilder.Helpers
{
	/// <summary>
	///     Path node helper class. Contains auxiliary functions to work with PND files.
	/// </summary>
	public static class PathNodeHelper
	{
		private static readonly string SectorsPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Sectors");

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

		public static bool IsAvailableTile(int x, int y)
		{
			//todo: nasty mix of responsibility
			string sector = SecHelper.GetSectorCorrespondence(x, y).ToString();
			string sectfile = Path.Combine(SectorsPath, sector + ".sec");
			if (!File.Exists(sectfile)) return false; // check if this sector tile is taken first

			//todo: cache loaded files to skip them for consecutive calls
			using (var stream = new FileStream(sectfile, FileMode.Open))
			using (var reader = new BinaryReader(stream))
			{
				int maxX, maxY, minX, minY;
				SecHelper.GetMinMax(sector, out minY, out maxY, out minX, out maxX);
				uint lightsCount = reader.ReadUInt32();
				for (int i = 0; i < lightsCount; i++)
					LightEditorEx.LoadLightFromSEC(reader);
				var distX = x - minX;
				var distY = y - minY;
				var skipLength = (distY*64 + distX)*16;
				stream.Seek(skipLength, SeekOrigin.Current);
				return reader.ReadUInt64() <= 32;
			}
		}
	}
}