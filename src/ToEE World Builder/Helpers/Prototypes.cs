using System.IO;

namespace WorldBuilder.Helpers
{
	public static class Prototypes
	{
		private static readonly string[] ProtoList = new string[334];

		public static string[] GetColumnNames(string protoPatchPath = "ToEE World Builder.pfr")
		{
			if (!string.IsNullOrEmpty(ProtoList[0]))
				return ProtoList;

			lock (ProtoList)
			{
				if (!string.IsNullOrEmpty(ProtoList[0]))
					return ProtoList;

				//read default list from resources
				using (var stream = MiscHelper.GetResourceStreamThatEndsWith(".pfr"))
					if (stream != null)
						using (var reader = new StreamReader(stream))
							ReadPatchList(reader, ProtoList);

				//read patch if needed
				if (File.Exists(protoPatchPath))
					using (var reader = new StreamReader(protoPatchPath))
						ReadPatchList(reader, ProtoList, "[END PROTO FIELD PATCH]");

				//format and fix any holes with default names
				for (int i = 0; i < ProtoList.Length; i++)
					if (string.IsNullOrEmpty(ProtoList[i]))
						ProtoList[i] = ("Unknown #" + (i + 1).ToString().PadRight(20, ' ') + "|\t");
					else
						ProtoList[i] = ProtoList[i].PadRight(29, ' ') + "|\t";
				return ProtoList;
			}
		}

		private static void ReadPatchList(StreamReader reader, string[] list, string endOfListMarker = null)
		{
			while (!reader.EndOfStream)
			{
				var protoPatchName = reader.ReadLine();
				if (protoPatchName == endOfListMarker || protoPatchName == null) break;

				protoPatchName = protoPatchName.Trim();
				if (protoPatchName.Length == 0 || protoPatchName.Substring(0, 2) == "//") continue;

				var protoPatchNameArr = protoPatchName.Split('=');
				int idx;
				if (!int.TryParse(protoPatchNameArr[0], out idx) || idx >= list.Length) continue;

				list[idx] = protoPatchNameArr[1];
			}
		}
	}
}