using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder
{
	public partial class OpenMOB : Form
	{
		public string FileToOpen = "";
		public ArrayList mobListMemory = new ArrayList();

		public OpenMOB()
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
					long BlocksToSkip = Helper.MOB_GetNumberofBitmapBlocks((MobTypes) type);
					br.BaseStream.Seek(BlocksToSkip*4 + 1, SeekOrigin.Current);
					uint x_coord = br.ReadUInt32();
					uint y_coord = br.ReadUInt32();
					br.Close();

					string COMPATIBLE = "(MOB OBJECT)";
					MOB_LIST.Items.Add(Path.GetFileNameWithoutExtension(mob) + "\t" + COMPATIBLE + "\t" + "(X=" + x_coord.ToString() + "; Y=" + y_coord.ToString() + ")\t\t" + Helper.Proto_By_ID[proto_id.ToString()] + "\t(" + proto_id + ")");
					mobListMemory.Add(Path.GetFileNameWithoutExtension(mob) + "\t" + COMPATIBLE + "\t" + "(X=" + x_coord.ToString() + "; Y=" + y_coord.ToString() + ")\t\t" + Helper.Proto_By_ID[proto_id.ToString()] + "\t(" + proto_id + ")");
				}
				catch (Exception)
				{
					MessageBox.Show("For some reason, the following file is corrupt and is beyond recovery:\n" + Path.GetFileNameWithoutExtension(mob) + ".mob\n\nIt'd be better if you deleted this file.", "Error Pre-Parsing Mobile Object", MessageBoxButtons.OK,
									MessageBoxIcon.Warning);
				}
			}

			// Restore last opened MOB position
			try
			{
				if (Helper.LastOpenedMOB != "")
					MOB_LIST.SelectedItem = Helper.LastOpenedMOB;
			}
			catch (Exception)
			{
				Helper.LastOpenedMOB = "";
			}
		}

		private void MOB_LIST_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (MOB_LIST.SelectedIndex == -1 /* DEPRECATED: || (MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().IndexOf("(INCOMPATIBLE)") != -1 && !chkForce.Checked) */)
			{
				btnOpen.Enabled = false;
				btnDeleteMOB.Enabled = false;
			}
			else
			{
				btnOpen.Enabled = true;
				btnDeleteMOB.Enabled = true;
			}
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			Helper.LastOpenedMOB = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString();
			FileToOpen = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0];
		}

		private void chkForce_CheckedChanged(object sender, EventArgs e)
		{
			btnOpen.Enabled = true;
		}

		private void btnDeleteMOB_Click(object sender, EventArgs e)
		{
			if (MOB_LIST.SelectedIndex == -1)
				return;

			if (
				MessageBox.Show("Are you sure you want to delete this mobile object?\n\nNOTE: This does not remove linked mobile objects (e.g. inventory). Please clean the inventories by hand first.", "Please confirm operation", MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.No)
				return;

			string FileToDel = Path.GetDirectoryName(Application.ExecutablePath) + "\\Mobiles\\" + MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0] + ".mob";
			MOB_LIST.Items.Remove(MOB_LIST.Items[MOB_LIST.SelectedIndex]);
			File.Delete(FileToDel);
		}

		private void mobProtoSearch_TextChanged(object sender, EventArgs e)
		{
			MOB_LIST.Items.Clear();
			for (int i = 0; i < mobListMemory.Count; i++)
			{
				string mob_entry = mobListMemory[i].ToString();
				string mobGUIDField = mob_entry.Split('\t')[0];
				string mobProtoField = mob_entry.Split('\t')[5];
				string mobDescriptionField = mob_entry.Split('\t')[4];
				if (mobGUIDField.ToLower().Contains(mobGUIDSearch.Text.ToLower()) && mobProtoField.ToLower().Contains(mobProtoSearch.Text.ToLower()) && mobDescriptionField.ToLower().Contains(mobDescriptionSearch.Text.ToLower()))
					MOB_LIST.Items.Add(mob_entry);
			}
		}

		private void mobDescriptionSearch_TextChanged(object sender, EventArgs e)
		{
			MOB_LIST.Items.Clear();
			for (int i = 0; i < mobListMemory.Count; i++)
			{
				string mob_entry = mobListMemory[i].ToString();
				string mobGUIDField = mob_entry.Split('\t')[0];
				string mobProtoField = mob_entry.Split('\t')[5];
				string mobDescriptionField = mob_entry.Split('\t')[4];
				if (mobGUIDField.ToLower().Contains(mobGUIDSearch.Text.ToLower()) && mobProtoField.ToLower().Contains(mobProtoSearch.Text.ToLower()) && mobDescriptionField.ToLower().Contains(mobDescriptionSearch.Text.ToLower()))
					MOB_LIST.Items.Add(mob_entry);
			}
		}

		private void mobGUIDSearch_TextChanged(object sender, EventArgs e)
		{
			MOB_LIST.Items.Clear();
			for (int i = 0; i < mobListMemory.Count; i++)
			{
				string mob_entry = mobListMemory[i].ToString();
				string mobGUIDField = mob_entry.Split('\t')[0];
				string mobProtoField = mob_entry.Split('\t')[5];
				string mobDescriptionField = mob_entry.Split('\t')[4];
				if (mobGUIDField.ToLower().Contains(mobGUIDSearch.Text.ToLower()) && mobProtoField.ToLower().Contains(mobProtoSearch.Text.ToLower()) && mobDescriptionField.ToLower().Contains(mobDescriptionSearch.Text.ToLower()))
					MOB_LIST.Items.Add(mob_entry);
			}
		}
	}
}