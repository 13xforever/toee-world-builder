using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class PathNodeGen : Form
	{
		public PathNodeGen()
		{
			InitializeComponent();
			controls = new Control[] { btnGeneratePND, btnSavePND, btnAddNode, btnDelNode, btnGotoPND, NodeX, NodeY, NodeOfsX, NodeOfsY };
			vicinitySwitch = new[]
								{
									Tuple.Create(experimentalToolStripMenuItem, 7d),
									Tuple.Create(menuItem2, 19d),
									Tuple.Create(menuItem3, 20d),
									Tuple.Create(menuItem4, 21d),
									Tuple.Create(menuItem5, 22d),
									Tuple.Create(menuItem6, 23d),
									Tuple.Create(menuItem7, 24d),
									Tuple.Create(menuItem8, 25d),
								};
			nodeCollection = new PathNodeCollection(nodeCollection);
		}

		private readonly Control[] controls;
		private PathNodeCollection nodeCollection;

		private void OnOpenPndFileClick(object sender, EventArgs e)
		{
			if (OpenPND.ShowDialog() != DialogResult.OK) return;

			var newCollection = PathNodeCollection.Read(OpenPND.FileName);
			newCollection.NeighbourhoodVicinity = nodeCollection.NeighbourhoodVicinity;
			foreach (var node in nodeCollection.Values)
				lstNodes.Items.Add(node); //todo: check that it renders properly
			EnableInterface(true);
		}

		private void OnSavePndFileClick(object sender, EventArgs e)
		{
			if (nodeCollection == null)
			{
				MessageBox.Show("No path nodes to save!", "Nothing to do", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (nodeCollection.IsDirty)
			{
				if (MessageBox.Show("Warning: The path nodes have changed since the last time they were saved. " +
									"It means that certain links may have been invalidated or become unusable. " +
									"It is recommended that you click the \"Generate\" button before saving the path nodes, " +
									"otherwise you may experience strange behavior or CTDs in the game. " +
									"Are you sure you want to save the path node data without generating node links (not recommended)?",
									"Please confirm precarious operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

			SavePND.FileName = "pathnode.pnd";
			if (SavePND.ShowDialog() != DialogResult.OK) return;

			nodeCollection.Save(SavePND.FileName);
			MessageBox.Show("Path Node Data Saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void OnNewPndFileClick(object sender, EventArgs e)
		{
			if (nodeCollection == null) return;

			if (MessageBox.Show("Are you sure you want to create a new path node data file?",
								"Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			nodeCollection = new PathNodeCollection(nodeCollection);
			EnableInterface(true);
		}

		/// <summary>
		/// Modify the PND generator interface state
		/// </summary>
 		private void EnableInterface(bool enabled)
		{
			foreach (var control in controls)
				control.Enabled = enabled;
		}

		private void DisplayNode(long x, long y, double offsetX, double offsetY)
		{
			NodeX.Text = x.ToString();
			NodeY.Text = y.ToString();
			NodeOfsX.Text = offsetX.ToString();
			NodeOfsY.Text = offsetY.ToString();
		}

		private void DisplayNode(PathNode node)
		{
			DisplayNode(node.X, node.Y, node.OffsetX, node.OffsetY);
		}

		private void OnSelectedNodeChanged(object sender, EventArgs e)
		{
			if (lstNodes.SelectedIndex == -1)
				return;

			var node = (PathNode)lstNodes.Items[lstNodes.SelectedIndex];
			DisplayNode(node);
			lstLinks.Items.Clear();
			foreach (var goal in nodeCollection.GetGoalsFor(node.Id))
				lstLinks.Items.Add(nodeCollection[goal]);
		}

		private void OnJumpToNodeClick(object sender, EventArgs e)
		{
			if (lstLinks.SelectedIndex == -1)
				return;

			//todo: fix this logic of node inconsistency handling; this shouldn't happen if at all possible
			if (lstLinks.Items[lstLinks.SelectedIndex] == null)
			{
				MessageBox.Show("This link cannot be resolved (its destination was possibly removed). Please click the \"Generate\" button to generate the path node links.", "Unresolved Link", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			lstNodes.SelectedIndex = lstNodes.Items.IndexOf(lstLinks.Items[lstLinks.SelectedIndex]);
			lstNodes.Focus();
		}

		private void OnDeleteNodeClick(object sender, EventArgs e)
		{
			// Deleting a path node must update the IsDirty flag
			if (lstNodes.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this node?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			lstLinks.Items.Clear();
			var node = (PathNode)lstNodes.Items[lstNodes.SelectedIndex];
			nodeCollection.Remove(node);
			lstNodes.Items.RemoveAt(lstNodes.SelectedIndex);
		}

		private void OnAddNodeClick(object sender, EventArgs e)
		{
			uint newX, newY;
			bool errors = false;
			var errorMessage = new StringBuilder();

			if (!uint.TryParse(NodeX.Text, out newX))
			{
				errorMessage.AppendLine("X is not a valid integer value.");
				errors = true;
			}
			if (!uint.TryParse(NodeY.Text, out newY))
			{
				errorMessage.AppendLine("Y is not a valid integer value.");
				errors = true;
			}

			if (!errors)
			{
				var existingNode = nodeCollection.Values.FirstOrDefault(n => n.X == newX && n.Y == newY);
				if (existingNode != null)
				{
					errorMessage.AppendFormat("Error: A path node with the given (X,Y) coordinates already exists! [#{0}]", existingNode.Id).AppendLine();
					errors = true;
				}
			}

			float newOffsetX, newOffsetY;
			if (!float.TryParse(NodeOfsX.Text, out newOffsetX))
			{
				errorMessage.AppendLine("Offset X is not a valid floating point value.");
				errors = true;
			}
			if (!float.TryParse(NodeOfsY.Text, out newOffsetY))
			{
				errorMessage.AppendLine("Offset Y is not a valid floating point value.");
				errors = true;
			}
			if (errors)
			{
				MessageBox.Show(errorMessage.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			var newNode = new PathNode(nodeCollection.TopId + 1, newX, newY, newOffsetX, newOffsetY);
			nodeCollection.Add(newNode);
			lstNodes.Items.Add(newNode);
			lstNodes.SelectedIndex = lstNodes.Items.Count - 1;
		}

		private void OnRegenerateLinksClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("NOTE: Using the 'Generate' button will create all possible path links between the nodes. " +
								"This will allow the game engine to move the characters along the given paths. " +
								"It is only required step to do after a path node was modified or Tolerance was changed. " +
								"Generating path node links may take some time to complete. " +
								"Do you want to generate path node links now?",
								"Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;
			MessageBox.Show("Node links generated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private readonly Tuple<ToolStripMenuItem, double>[] vicinitySwitch;

		private void OnChangeToleranceClick(object sender, EventArgs e)
		{
			foreach (var tuple in vicinitySwitch)
				if (tuple.Item1 == sender)
				{
					if (tuple.Item1.Checked) continue;

					nodeCollection.NeighbourhoodVicinity = tuple.Item2;
					tuple.Item1.Checked = true;
				}
				else
					tuple.Item1.Checked = false;
		}

		private void OnToleranceHelpClick(object sender, EventArgs e)
		{
			MessageBox.Show("Tolerance defines the maximum distance between two path nodes for a link to be generated. " +
							"The bigger this value is, the more links will be generated between neighboring nodes in a wider radius. " +
							"Technically speaking, setting the lower value of 'Tolerance' will result " +
							"in very few links being generated because of the strict requirement " +
							"for a distance between path nodes (19-21 tiles). " +
							"The default value (22 tiles) assumes the standard distance between path nodes in ToEE (20 tiles) " +
							"and takes extra 2 tile radius into consideration to generate a few alternative links, if possible. " +
							"Bigger values (23-25) will result in many overlapping links and may technically cause 'dead links' to appear " +
							"(links that exist but that can't be parsed by the game because they are very far away from each other, " +
							"e.g. 23-25 tiles away).\n" +
							"\n" +
							"Normally there is no need to modify the default tolerance value (22). " +
							"However, if you feel that the pathfinding on your map is somewhat weird, " +
							"but you are confident that you are doing everything right, " +
							"you can try setting more rigid or lax values of the tolerance and see if that helps.",
							"About Tolerance Option...", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void OnAutogeneratePathClick(object sender, EventArgs e)
		{

			//todo: clean up after converting return values to uint?
			var autoGenDlg = new PathNodeAutoGen();
			if (autoGenDlg.ShowDialog() != DialogResult.OK || autoGenDlg.r_Step == -1) return;

			// New PND file
			nodeCollection = new PathNodeCollection(nodeCollection);
			EnableInterface(true);

			// Generate automated path nodes
			for (var x = autoGenDlg.r_FX; x <= autoGenDlg.r_TX; x += autoGenDlg.r_Step)
				for (var y = autoGenDlg.r_FY; y <= autoGenDlg.r_TY; y += autoGenDlg.r_Step)
					if (IsAvailableTile(x, y))
					{
						DisplayNode(x, y, 0f, 0f);
						OnAddNodeClick(sender, e);
					}
					else
					{
						// the tile is blocked, so try laying pathnodes around the smaller grid
						var tile = new[]
										{
											Tuple.Create(x + 3, y),
											Tuple.Create(x, y + 3),
											Tuple.Create(x, y - 3),
											Tuple.Create(x - 3, y),
											Tuple.Create(x + 3, y + 3),
											Tuple.Create(x - 3, y - 3),
											Tuple.Create(x + 3, y - 3),
											Tuple.Create(x - 3, y + 3),
										}.FirstOrDefault(n => IsAvailableTile(n.Item1, n.Item2));
						if (tile != null)
						{
							DisplayNode(tile.Item1, tile.Item2, 0f, 0f);
							OnAddNodeClick(sender, e);
						}
					}
			MessageBox.Show("Automated generation complete."); //todo: there were some numbers here
		}

		private static bool IsAvailableTile(int x, int y)
		{
			string sector = Helper.SEC_GetSectorCorrespondence(x, y).ToString();
			string sectfile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors\\" + sector + ".sec";
			if (!File.Exists(sectfile)) return false; // check if this sector tile is taken first

			using (var r_sec = new BinaryReader(new FileStream(sectfile, FileMode.Open)))
			{
				int max_x = 0, max_y = 0, min_x = 0, min_y = 0;
				Helper.Sec_GetMinMax(sector, ref min_y, ref max_y, ref min_x, ref max_x);
				int int_x = x - min_x;
				int int_y = y - min_y;
				int skipdist = (int_y*64 + int_x)*16;
				uint num_lights = r_sec.ReadUInt32();
				for (int i = 0; i < num_lights; i++)
					LightEditorEx.LoadLightFromSEC(r_sec);
				r_sec.BaseStream.Seek(skipdist, SeekOrigin.Current);
				return r_sec.ReadUInt64() <= 32;
			}
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
								OnAddNodeClick(null, null);
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