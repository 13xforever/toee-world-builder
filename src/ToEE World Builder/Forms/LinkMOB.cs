using System;
using System.IO;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class LinkMOB : Form
	{
		public string FullString = "";
		public string GUID = "";
		public byte[] LinkGUID = new byte[24];

		public LinkMOB()
		{
			InitializeComponent();
		}

		private void OpenMOB_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Mobiles"))
			{
				MessageBox.Show("Critical Error 003: installation of ToEE World Editor may be corrupt. Please reinstall.",
								"Critical Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				Close();
			}

			string[] mobs = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + "\\Mobiles", "*.mob");

			foreach (string mob in mobs)
			{
				try
				{
					var br = new BinaryReader(new FileStream(mob, FileMode.Open));
					br.BaseStream.Seek(0x06, SeekOrigin.Begin);
					uint compat = br.ReadUInt32();
					br.BaseStream.Seek(0x0C, SeekOrigin.Begin);
					Int16 proto_id = br.ReadInt16();
					br.BaseStream.Seek(0x34, SeekOrigin.Begin);
					uint type = br.ReadUInt32();
					br.BaseStream.Seek(0x3A, SeekOrigin.Begin);
					long BlocksToSkip = MobHelper.GetNumberofBitmapBlocks((MobType) type);
					br.BaseStream.Seek(BlocksToSkip*4 + 1, SeekOrigin.Current);
					uint x_coord = br.ReadUInt32();
					uint y_coord = br.ReadUInt32();

					br.Close();

					string COMPATIBLE = "(MOB OBJECT)";
					MOB_LIST.Items.Add(Path.GetFileNameWithoutExtension(mob) + "\t" + COMPATIBLE + "\t" + "(X=" + x_coord.ToString() + "; Y=" + y_coord.ToString() + ")\t\t" + MobHelper.ProtoById[proto_id.ToString()]);
				}
				catch (Exception)
				{
					MessageBox.Show("For some reason, the following file is corrupt and is beyond recovery:\n" + Path.GetFileNameWithoutExtension(mob) + ".mob\n\nIt'd be better if you deleted this file.", "Error Pre-Parsing Mobile Object", MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
				}
			}
		}

		private void MOB_LIST_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (MOB_LIST.SelectedIndex == -1)
				btnOpen.Enabled = false;
			else
				btnOpen.Enabled = true;

			// Load up the GUID (important for linking)
			var br = new BinaryReader(new FileStream("Mobiles\\" + MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0] + ".mob", FileMode.Open));
			br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
			LinkGUID = br.ReadBytes(24);
			br.Close();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			GUID = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0];
			FullString = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString();
		}
	}
}