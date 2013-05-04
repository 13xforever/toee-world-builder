using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder
{
	public partial class PathNodeGen : Form
	{
		public PathNodeGen()
		{
			InitializeComponent();
		}

		private void btnOpenPND_Click(object sender, EventArgs e)
		{
			if (OpenPND.ShowDialog() == DialogResult.OK)
			{
				PNDHelper.CURRENT_TOP_ID = 0;
				lstNodes.Items.Clear();
				lstLinks.Items.Clear();
				PNDHelper.PathNodes.Clear();
				PNDHelper.PathNodeGoals.Clear();

				var br = new BinaryReader(new FileStream(OpenPND.FileName, FileMode.Open));
				uint num_nodes = br.ReadUInt32(); // get the # of nodes

				for (int i = 0; i < num_nodes; i++)
				{
					// Parse each node
					var p = new PNDHelper.PathNode();
					p.ID = br.ReadUInt32();
					p.X = br.ReadUInt32();
					p.Y = br.ReadUInt32();
					p.OfsX = br.ReadSingle();
					p.OfsY = br.ReadSingle();

					// Add to the list and to the hashtable
					PNDHelper.PathNodes.Add(p.ID, p);
					lstNodes.Items.Add("ID #" + p.ID.ToString() + ": (" + p.X.ToString() + ", " + p.Y.ToString() + ")");

					// Check if we need to modify the max ID available
					if (p.ID > PNDHelper.CURRENT_TOP_ID)
						PNDHelper.CURRENT_TOP_ID = p.ID;

					uint num_goals = br.ReadUInt32();
					string goals = "";
					for (int j = 0; j < num_goals; j++)
					{
						// Process each goal
						goals += br.ReadUInt32().ToString() + "::";
					}
					PNDHelper.PathNodeGoals.Add(p.ID, goals);
				}
				br.Close();
				PNDHelper.CURRENT_TOP_ID++; // increase to set to a new possible value

				PNDHelper.PND_HAS_CHANGED = false;
				PNDHelper.PND_MODE_ACTIVE = true;
				SetInterfaceState(true);
			}
		}

		private void btnSavePND_Click(object sender, EventArgs e)
		{
			if (!PNDHelper.PND_MODE_ACTIVE)
			{
				MessageBox.Show("No path nodes to save!", "Nothing to do", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (PNDHelper.PND_HAS_CHANGED)
			{
				if (
					MessageBox.Show(
						"Warning: The path nodes have changed since the last time they were saved. It means that certain links may have been invalidated or become unusable. It is recommended that you click the \"Generate\" button before saving the path nodes, otherwise you may experience strange behavior or CTDs in the game. Are you sure you want to save the path node data without generating node links (not recommended)?",
						"Please confirm precarious operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

			SavePND.FileName = "pathnode.pnd";
			if (SavePND.ShowDialog() == DialogResult.OK)
			{
				// TODO: save back the path nodes here
				var bw = new BinaryWriter(new FileStream(SavePND.FileName, FileMode.Create));
				bw.Write((uint) PNDHelper.PathNodes.Count); // # of path nodes

				var NodeStack = new Stack(PNDHelper.PathNodes.Keys);
				IEnumerator WalkNodes = NodeStack.GetEnumerator();

				while (WalkNodes.MoveNext())
				{
					var p = (PNDHelper.PathNode) PNDHelper.PathNodes[uint.Parse(WalkNodes.Current.ToString())];
					bw.Write(p.ID);
					bw.Write(p.X);
					bw.Write(p.Y);
					bw.Write(p.OfsX);
					bw.Write(p.OfsY);

					// Write out the number of goals and the list of goals
					// (neighboring destinations)
					string[] goals = str_to_array(PNDHelper.PathNodeGoals[p.ID].ToString());
					bw.Write(goals.GetUpperBound(0));
					foreach (string goal in goals)
					{
						if (goal != "")
							bw.Write(uint.Parse(goal));
					}
				}
				bw.Close();
				MessageBox.Show("Path Node Data Saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnNewPND_Click(object sender, EventArgs e)
		{
			if (PNDHelper.PND_MODE_ACTIVE)
			{
				if (MessageBox.Show("Are you sure you want to create a new path node data file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

			PNDHelper.CURRENT_TOP_ID = 0;
			lstNodes.Items.Clear();
			lstLinks.Items.Clear();
			PNDHelper.PathNodes.Clear();
			PNDHelper.PathNodeGoals.Clear();
			PNDHelper.PND_HAS_CHANGED = false;
			PNDHelper.PND_MODE_ACTIVE = true;
			SetInterfaceState(true);
		}

		// Modify the PND generator interface state
		private void SetInterfaceState(bool state)
		{
			btnGeneratePND.Enabled = state;
			btnSavePND.Enabled = state;
			btnAddNode.Enabled = state;
			btnDelNode.Enabled = state;
			btnGotoPND.Enabled = state;
			NodeX.Enabled = state;
			NodeY.Enabled = state;
			NodeOfsX.Enabled = state;
			NodeOfsY.Enabled = state;
		}

		// Get an ID number of a path node from the string tag in the node list
		private uint GetID(string id_tag)
		{
			return uint.Parse(id_tag.Split('#')[1].Split(':')[0]);
		}

		// Split the goals into individual strings
		public static string[] str_to_array(string data)
		{
			string[] arr = null;

			try
			{
				arr = Regex.Split(data, "::");
			}
			catch (ArgumentException)
			{
			}

			return arr;
		}

		private void lstNodes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstNodes.SelectedIndex == -1)
				return;

			uint ID = GetID(lstNodes.Items[lstNodes.SelectedIndex].ToString());
			var p = (PNDHelper.PathNode) PNDHelper.PathNodes[ID];
			NodeX.Text = p.X.ToString();
			NodeY.Text = p.Y.ToString();
			NodeOfsX.Text = p.OfsX.ToString();
			NodeOfsY.Text = p.OfsY.ToString();

			lstLinks.Items.Clear();
			string[] goals = str_to_array(PNDHelper.PathNodeGoals[ID].ToString());
			foreach (string goal in goals)
			{
				if (goal.Trim() != "")
				{
					try
					{
						var dest = (PNDHelper.PathNode) PNDHelper.PathNodes[uint.Parse(goal)];
						lstLinks.Items.Add("ID #" + dest.ID.ToString() + ": (" + dest.X.ToString() + ", " + dest.Y.ToString() + ")");
					}
					catch (Exception)
					{
						// Invalidated link
						MessageBox.Show("One of the links to this node has been invalidated (possibly deleted). You must click \"Generate\" to generate the path node links again.", "Invalid link found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						lstLinks.Items.Add("ID #??: UNRESOLVED, PLEASE CLICK \"GENERATE\"");
					}
				}
			}
		}

		private void btnGotoPND_Click(object sender, EventArgs e)
		{
			if (lstLinks.SelectedIndex == -1)
				return;

			if (lstLinks.Items[lstLinks.SelectedIndex].ToString() == "ID #??: UNRESOLVED, PLEASE CLICK \"GENERATE\"")
			{
				MessageBox.Show("This link cannot be resolved (its destination was possibly removed). Please click the \"Generate\" button to generate the path node links.", "Unresolved Link", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			lstNodes.SelectedIndex = lstNodes.Items.IndexOf(lstLinks.Items[lstLinks.SelectedIndex].ToString());
			lstNodes.Focus();
		}

		private void btnDelNode_Click(object sender, EventArgs e)
		{
			// Deleting a path node must update the PND_HAS_CHANGED flag
			if (lstNodes.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this node?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			lstLinks.Items.Clear();
			PNDHelper.PND_HAS_CHANGED = true;
			uint ID = GetID(lstNodes.Items[lstNodes.SelectedIndex].ToString());
			PNDHelper.PathNodes.Remove(ID);
			PNDHelper.PathNodeGoals.Remove(ID);
			lstNodes.Items.RemoveAt(lstNodes.SelectedIndex);
		}

		private void btnAddNode_Click(object sender, EventArgs e)
		{
			// Adding a path node must update the PND_HAS_CHANGED flag
			IEnumerator PathKey = PNDHelper.PathNodes.Keys.GetEnumerator();
			while (PathKey.MoveNext())
			{
				var p = (PNDHelper.PathNode) PNDHelper.PathNodes[uint.Parse(PathKey.Current.ToString())];
				if (p.X == uint.Parse(NodeX.Text) && p.Y == uint.Parse(NodeY.Text))
				{
					MessageBox.Show("Error: A path node with the given (X,Y) coordinates already exists! [#" + p.ID.ToString() + "]", "A Node Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			PNDHelper.PND_HAS_CHANGED = true;
			var p1 = new PNDHelper.PathNode();
			p1.ID = PNDHelper.CURRENT_TOP_ID;
			p1.X = uint.Parse(NodeX.Text);
			p1.Y = uint.Parse(NodeY.Text);
			try
			{
				p1.OfsX = float.Parse(NodeOfsX.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("Offset X didn't have a valid floating point value. It was reset to 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				p1.OfsX = 0;
			}
			try
			{
				p1.OfsY = float.Parse(NodeOfsY.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("Offset Y didn't have a valid floating point value. It was reset to 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				p1.OfsY = 0;
			}
			PNDHelper.PathNodes.Add(p1.ID, p1);
			PNDHelper.PathNodeGoals.Add(p1.ID, ""); // empty set of links
			lstNodes.Items.Add("ID #" + p1.ID.ToString() + ": (" + p1.X.ToString() + ", " + p1.Y.ToString() + ")");
			lstNodes.SelectedIndex = lstNodes.Items.Count - 1;
			PNDHelper.CURRENT_TOP_ID++;
		}

		private void btnGeneratePND_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show(
					"NOTE: Using the 'Generate' button will create all possible path links between the nodes. This will allow the game engine to move the characters along the given paths. It is a required step to do after a path node is added, removed, or modified in any way. Generating path node links may take some time to complete. Do you want to generate path node links now?",
					"Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			PNDHelper.PathNodeGoals.Clear(); // clear the old list

			var NodeStack = new Stack(PNDHelper.PathNodes.Keys);
			IEnumerator p = NodeStack.GetEnumerator();
			var NodeStackDest = new Stack(PNDHelper.PathNodes.Keys);
			IEnumerator destination = NodeStackDest.GetEnumerator();

			var pd_Source = new PNDHelper.PathNode();
			var pd_Dest = new PNDHelper.PathNode();
			string goal_list = "";

			while (p.MoveNext()) /* first walkover: source nodes */
			{
				pd_Source = (PNDHelper.PathNode) PNDHelper.PathNodes[uint.Parse(p.Current.ToString())];
				goal_list = "";

				while (destination.MoveNext()) /* second walkover: destinations */
				{
					pd_Dest = (PNDHelper.PathNode) PNDHelper.PathNodes[uint.Parse(destination.Current.ToString())];
					if (pd_Source.ID != pd_Dest.ID) /* can't back-link to itself */
					{
						if (PNDHelper.IsNeighboring(PNDHelper.GetPathLength(pd_Source.X, pd_Source.Y, pd_Dest.X, pd_Dest.Y)))
							goal_list += pd_Dest.ID.ToString() + "::";
					}
				}
				destination.Reset();
				PNDHelper.PathNodeGoals.Add(pd_Source.ID, goal_list);
			}

			PNDHelper.PND_HAS_CHANGED = false;
			MessageBox.Show("Node links generated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void experimentalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PNDHelper.MAX_PATH_LENGTH = 7.0F;
			experimentalToolStripMenuItem.Checked = true;
			menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem2_Click(object sender, EventArgs e)
		{
			experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 19.0F;
			menuItem2.Checked = true;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem3_Click(object sender, EventArgs e)
		{
			experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 20.0F;
			menuItem2.Checked = false;
			menuItem3.Checked = true;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem4_Click(object sender, EventArgs e)
		{
			experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 21.0F;
			menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = true;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem5_Click(object sender, EventArgs e)
		{
			experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 22.0F;
			menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = true;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem6_Click(object sender, EventArgs e)
		{
			experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 23.0F;
			menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = true;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem7_Click(object sender, EventArgs e)
		{
			experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 24.0F;
			menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = true;
			menuItem8.Checked = false;
		}

		private void menuItem8_Click(object sender, EventArgs e)
		{
			experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 25.0F;
			menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = true;
		}

		private void menuItem10_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Tolerance defines the maximum distance between two path nodes for a link to be generated. The bigger this value is, the more links will be generated between neighboring nodes in a wider radius. Technically speaking, setting the lower value of 'Tolerance' will result in very few links being generated because of the strict requirement for a distance between path nodes (19-21 tiles). The default value (22 tiles) assumes the standard distance between path nodes in ToEE (20 tiles) and takes extra 2 tile radius into consideration to generate a few alternative links, if possible. Bigger values (23-25) will result in many overlapping links and may technically cause 'dead links' to appear (links that exist but that can't be parsed by the game because they are very far away from each other, e.g. 23-25 tiles away).\n\nNormally there is no need to modify the default tolerance value (22). However, if you feel that the pathfinding on your map is somewhat weird but you are confident that you are doing everything alright, you can try setting more rigid or lax values of the tolerance and see if that helps.",
				"About Tolerance Option...", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void autoPathnodeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var pWnd = new PathNodeAutoGen();
			if (pWnd.ShowDialog() == DialogResult.OK)
			{
				if (pWnd.r_Step == -1)
					return;

				// New PND file
				PNDHelper.CURRENT_TOP_ID = 0;
				lstNodes.Items.Clear();
				lstLinks.Items.Clear();
				PNDHelper.PathNodes.Clear();
				PNDHelper.PathNodeGoals.Clear();
				PNDHelper.PND_HAS_CHANGED = false;
				PNDHelper.PND_MODE_ACTIVE = true;
				SetInterfaceState(true);

				int blocked_so_far = 0;
				int pnd_on_subgrid = 0;
				bool exists = false;

				// Generate automated path nodes
				for (int x = pWnd.r_FX; x <= pWnd.r_TX; x += pWnd.r_Step)
					for (int y = pWnd.r_FY; y <= pWnd.r_TY; y += pWnd.r_Step)
					{
						bool blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, x, y);

						if (exists && !blocked)
						{
							NodeX.Text = x.ToString();
							NodeY.Text = y.ToString();
							NodeOfsX.Text = "0";
							NodeOfsY.Text = "0";
							btnAddNode_Click(sender, e);
						}
						else
						{
							// the tile is blocked, so try laying pathnodes around the smaller grid
							int new_x = 0, new_y = 0;
							bool fr = false;

							new_x = x + 3;
							new_y = y;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								fr = true;
								pnd_on_subgrid++;
							}

							new_x = x;
							new_y = y + 3;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								pnd_on_subgrid++;
								fr = true;
							}

							new_x = x;
							new_y = y - 3;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								pnd_on_subgrid++;
								fr = true;
							}

							new_x = x - 3;
							new_y = y;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								pnd_on_subgrid++;
								fr = true;
							}

							new_x = x + 3;
							new_y = y + 3;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								pnd_on_subgrid++;
								fr = true;
							}

							new_x = x - 3;
							new_y = y - 3;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								pnd_on_subgrid++;
								fr = true;
							}

							new_x = x + 3;
							new_y = y - 3;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								pnd_on_subgrid++;
								fr = true;
							}

							new_x = x - 3;
							new_y = y + 3;
							blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
							if (exists && !blocked && !fr)
							{
								NodeX.Text = new_x.ToString();
								NodeY.Text = new_y.ToString();
								NodeOfsX.Text = "0";
								NodeOfsY.Text = "0";
								btnAddNode_Click(sender, e);
								pnd_on_subgrid++;
								fr = true;
							}
						}
					}
				MessageBox.Show("Automated generation complete.\n\nBlocked tiles ignored: " + blocked_so_far.ToString() + "\nNodes laid on subgrid: " + pnd_on_subgrid.ToString());
			}
		}

		private static bool GetBlockedXY(ref int blocked_so_far, ref int pnd_on_subgrid, ref bool exists, int x, int y)
		{
			string sector = Helper.SEC_GetSectorCorrespondence(x, y).ToString();
			string sectfile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors\\" + sector + ".sec";
			int max_x = 0;
			int max_y = 0;
			int min_x = 0;
			int min_y = 0;
			bool blocked = false;

			// check if this sector tile is taken first
			if (File.Exists(sectfile))
			{
				exists = true;
				var r_sec = new BinaryReader(new FileStream(sectfile, FileMode.Open));
				Helper.Sec_GetMinMax(sector, ref min_y, ref max_y, ref min_x, ref max_x);

				int int_x = x - min_x;
				int int_y = y - min_y;
				int skipdist = (int_y*64 + int_x)*16;

				uint num_lights = r_sec.ReadUInt32();
				for (int i = 0; i < num_lights; i++)
					LightEditorEx.LoadLightFromSEC(r_sec);

				r_sec.BaseStream.Seek(skipdist, SeekOrigin.Current);

				if (r_sec.ReadUInt64() > 32)
				{
					blocked = true;
					blocked_so_far++;
				}
				else
				{
					blocked = false;
				}

				r_sec.Close();
			}
			else
			{
				exists = false;
			}
			return blocked;
		}

		private void tmrPND_Tick(object sender, EventArgs e)
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
						case "PNDLOC": // location -> created path node
							if (btnAddNode.Enabled)
							{
								File.Delete(Helper.InteropPath);
								NodeX.Text = wbl_data_arr[1];
								NodeY.Text = wbl_data_arr[2];
								btnAddNode_Click(null, null);
								return;
							}
							else
							{
								File.Delete(Helper.InteropPath);
								MessageBox.Show("Please create a path node file first! (e.g. click 'New' or 'Open')", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}
							//break;
						default:
							DATA_PASS_ON = true;
							break;
					}

					if (!DATA_PASS_ON)
						File.Delete(Helper.InteropPath);
				}
			}
		}

		private void PathNodeGen_Load(object sender, EventArgs e)
		{
			tmrPND.Enabled = true;
		}
	}
}