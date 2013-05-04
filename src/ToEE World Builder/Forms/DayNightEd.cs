using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder
{
	public partial class DayNightEd : Form
	{
		//private string MOB_GUID = "";
		private readonly ArrayList nxd_nodes = new ArrayList();
		private byte[] MOB_GUID_BYTES = new byte[24];
		private string nxd_file = "";

		public DayNightEd()
		{
			InitializeComponent();
		}

		private NXD LoadNode(BinaryReader br)
		{
			var node = new NXD();
			node.G_GUID = br.ReadBytes(24);
			node.cur_map_id = br.ReadUInt32();
			node.day_map_id = br.ReadUInt32();
			node.day_x = br.ReadUInt32();
			node.day_y = br.ReadUInt32();
			node.day_ofsx = br.ReadSingle();
			node.day_ofsy = br.ReadSingle();
			node.night_map_id = br.ReadUInt32();
			node.night_x = br.ReadUInt32();
			node.night_y = br.ReadUInt32();
			node.night_ofsx = br.ReadSingle();
			node.night_ofsy = br.ReadSingle();

			return node;
		}

		private void SaveNode(BinaryWriter bw, NXD node)
		{
			bw.Write(node.G_GUID, 0, 24);
			bw.Write(node.cur_map_id);
			bw.Write(node.day_map_id);
			bw.Write(node.day_x);
			bw.Write(node.day_y);
			bw.Write(node.day_ofsx);
			bw.Write(node.day_ofsy);
			bw.Write(node.night_map_id);
			bw.Write(node.night_x);
			bw.Write(node.night_y);
			bw.Write(node.night_ofsx);
			bw.Write(node.night_ofsy);
		}

		private void SaveAllNodes(BinaryWriter bw)
		{
			for (int i = 0; i < lstMOBs.Items.Count; i++)
				SaveNode(bw, (NXD) nxd_nodes[i]);
		}


		private void btnQuit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOpenNXD_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				nxd_nodes.Clear();
				lstMOBs.Items.Clear();

				nxd_file = openFileDialog1.FileName;
				btnAddNXD.Enabled = true;
				btnDeleteNXD.Enabled = true;
				btnUpdateNXD.Enabled = true;
				btnSaveNXD.Enabled = true;
				DefMap.Enabled = true;
				DayX.Enabled = true;
				DayY.Enabled = true;
				DayOfsX.Enabled = true;
				DayOfsY.Enabled = true;
				DayMap.Enabled = true;
				NightX.Enabled = true;
				NightY.Enabled = true;
				NightOfsX.Enabled = true;
				NightOfsY.Enabled = true;
				NightMap.Enabled = true;

				var br = new BinaryReader(new FileStream(nxd_file, FileMode.Open));
				while (br.BaseStream.Position != br.BaseStream.Length)
				{
					NXD node = LoadNode(br);
					nxd_nodes.Add(node);
					lstMOBs.Items.Add(Helper.GEN_ConvertBytesToStringGUID(node.G_GUID));
				}
			}
		}

		private void lstMOBs_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstMOBs.SelectedIndex == -1)
				return;

			var node = (NXD) nxd_nodes[lstMOBs.SelectedIndex];
			DefMap.Text = node.cur_map_id.ToString();
			DayMap.Text = node.day_map_id.ToString();
			DayX.Text = node.day_x.ToString();
			DayY.Text = node.day_y.ToString();
			DayOfsX.Text = node.day_ofsx.ToString();
			DayOfsY.Text = node.day_ofsy.ToString();

			NightMap.Text = node.night_map_id.ToString();
			NightX.Text = node.night_x.ToString();
			NightY.Text = node.night_y.ToString();
			NightOfsX.Text = node.night_ofsx.ToString();
			NightOfsY.Text = node.night_ofsy.ToString();
		}

		private void btnSaveNXD_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save the transitions file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var bw = new BinaryWriter(new FileStream(nxd_file, FileMode.Create));
			SaveAllNodes(bw);
			bw.Close();

			MessageBox.Show("Saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnUpdateNXD_Click(object sender, EventArgs e)
		{
			if (lstMOBs.SelectedIndex == -1)
				return;

			var node = (NXD) nxd_nodes[lstMOBs.SelectedIndex];
			node.cur_map_id = uint.Parse(DefMap.Text);
			node.day_map_id = uint.Parse(DayMap.Text);
			node.day_x = uint.Parse(DayX.Text);
			;
			node.day_y = uint.Parse(DayY.Text);
			node.day_ofsx = Single.Parse(DayOfsX.Text);
			node.day_ofsy = Single.Parse(DayOfsY.Text);
			;

			node.night_map_id = uint.Parse(NightMap.Text);
			node.night_x = uint.Parse(NightX.Text);
			;
			node.night_y = uint.Parse(NightY.Text);
			node.night_ofsx = Single.Parse(NightOfsX.Text);
			node.night_ofsy = Single.Parse(NightOfsY.Text);

			nxd_nodes[lstMOBs.SelectedIndex] = node;

			MessageBox.Show("Transition Entry Updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDeleteNXD_Click(object sender, EventArgs e)
		{
			if (lstMOBs.SelectedIndex == -1)
				return;
			if (MessageBox.Show("Are you sure you want to delete the current transition entry?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			nxd_nodes.RemoveAt(lstMOBs.SelectedIndex);
			lstMOBs.Items.RemoveAt(lstMOBs.SelectedIndex);

			MessageBox.Show("Transition Entry Deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnAddNXD_Click(object sender, EventArgs e)
		{
			var lm = new LinkMOB();
			if (lm.ShowDialog() == DialogResult.OK)
			{
				var node = new NXD();
				node.G_GUID = lm.LinkGUID;
				node.cur_map_id = uint.Parse(DefMap.Text);
				node.day_map_id = uint.Parse(DayMap.Text);
				node.day_x = uint.Parse(DayX.Text);
				;
				node.day_y = uint.Parse(DayY.Text);
				node.day_ofsx = Single.Parse(DayOfsX.Text);
				node.day_ofsy = Single.Parse(DayOfsY.Text);
				;

				node.night_map_id = uint.Parse(NightMap.Text);
				node.night_x = uint.Parse(NightX.Text);
				;
				node.night_y = uint.Parse(NightY.Text);
				node.night_ofsx = Single.Parse(NightOfsX.Text);
				node.night_ofsy = Single.Parse(NightOfsY.Text);

				nxd_nodes.Add(node);
				lstMOBs.Items.Add(lm.GUID);
				lstMOBs.SelectedIndex = lstMOBs.Items.Count - 1;

				MessageBox.Show("Transition Entry Added.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void tmrDNE_Tick(object sender, EventArgs e)
		{
			// v2.0.0: Interoperability with ToEE console support
			if (File.Exists(Helper.InteropPath))
			{
				string wbl_data = "";
				bool DATA_PASS_ON = false;
				try
				{
					var sr = new StreamReader(Helper.InteropPath);
					wbl_data = sr.ReadLine();
					sr.Close();
				}
				catch (Exception)
				{
				}
				if (wbl_data != "")
				{
					string[] wbl_data_arr = wbl_data.Split(' ');
					wbl_data = "";
					switch (wbl_data_arr[0])
					{
						case "DAYLOC": // location -> day node
							if (DayX.Enabled)
							{
								File.Delete(Helper.InteropPath);
								DayX.Text = wbl_data_arr[1];
								DayY.Text = wbl_data_arr[2];
								DayMap.Text = wbl_data_arr[3];
								return;
							}
							else
							{
								File.Delete(Helper.InteropPath);
								MessageBox.Show("Please open a transition file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}
						case "NGTLOC": // location -> night node
							if (NightX.Enabled)
							{
								File.Delete(Helper.InteropPath);
								NightX.Text = wbl_data_arr[1];
								NightY.Text = wbl_data_arr[2];
								NightMap.Text = wbl_data_arr[3];
								return;
							}
							else
							{
								File.Delete(Helper.InteropPath);
								MessageBox.Show("Please open a transition file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}
						default:
							DATA_PASS_ON = true;
							break;
					}

					if (!DATA_PASS_ON)
						File.Delete(Helper.InteropPath);
				}
			}
		}

		private void DayNightEd_Load(object sender, EventArgs e)
		{
			tmrDNE.Enabled = true;
		}

		private struct NXD // a transition node
		{
			public byte[] G_GUID; // must be 24 bytes long, 128-bit 0x02 + GUID
			public uint cur_map_id;
			public uint day_map_id;
			public float day_ofsx;
			public float day_ofsy;
			public uint day_x;
			public uint day_y;
			public uint night_map_id;
			public float night_ofsx;
			public float night_ofsy;
			public uint night_x;
			public uint night_y;
		}
	}
}