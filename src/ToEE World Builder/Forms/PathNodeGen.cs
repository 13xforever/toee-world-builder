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
		private readonly Control[] controls;
		private readonly Tuple<ToolStripMenuItem, double>[] vicinitySwitch;
		private PathNodeCollection nodeCollection = new PathNodeCollection();
		private double vicinity = 22d; // Tolerance for detecting neighboring nodes, in tiles (experimental, other possible values are 22.5 and 21.5)
		private bool isDirty;
		private static readonly string SectorsPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Sectors");

		public PathNodeGen()
		{
			InitializeComponent();
			controls = new Control[] {btnGeneratePND, btnSavePND, btnAddNode, btnDelNode, btnGotoPND, NodeX, NodeY, NodeOfsX, NodeOfsY};
			vicinitySwitch = new[]
								{
									Tuple.Create(toleranceMenuItem1,  7d),
									Tuple.Create(toleranceMenuItem2, 19d),
									Tuple.Create(toleranceMenuItem3, 20d),
									Tuple.Create(toleranceMenuItem4, 21d),
									Tuple.Create(toleranceMenuItem5, 22d),
									Tuple.Create(toleranceMenuItem6, 23d),
									Tuple.Create(toleranceMenuItem7, 24d),
									Tuple.Create(toleranceMenuItem8, 25d),
								};
		}

		private void OnOpenPndFileClick(object sender, EventArgs e)
		{
			if (OpenPND.ShowDialog() != DialogResult.OK) return;

			lstNodes.Items.Clear();
			lstLinks.Items.Clear();
			nodeCollection = PathNodeCollection.Read(OpenPND.FileName);
			foreach (PathNode node in nodeCollection.SortedValues)
				lstNodes.Items.Add(node);
			EnableInterface(true);
		}

		private void OnSavePndFileClick(object sender, EventArgs e)
		{
			if (nodeCollection == null)
			{
				MessageBox.Show("No path nodes to save!", "Nothing to do", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (isDirty)
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

			lstNodes.Items.Clear();
			lstLinks.Items.Clear();
			nodeCollection = new PathNodeCollection();
			EnableInterface(true);
		}

		private void EnableInterface(bool enabled)
		{
			foreach (Control control in controls)
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
			foreach (uint goal in nodeCollection.GetSortedGoalsFor(node.Id))
				lstLinks.Items.Add(nodeCollection[goal]);
		}

		private void OnJumpToNodeClick(object sender, EventArgs e)
		{
			if (lstLinks.SelectedIndex == -1)
				return;

			lstNodes.SelectedIndex = lstNodes.Items.IndexOf(lstLinks.Items[lstLinks.SelectedIndex]);
			lstNodes.Focus();
		}

		private void OnDeleteNodeClick(object sender, EventArgs e)
		{
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
				PathNode existingNode = nodeCollection[newX, newY];
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
			nodeCollection.Add(newNode, vicinity);
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
			nodeCollection.RegenerateLinks(vicinity);
			OnSelectedNodeChanged(null, null);
			MessageBox.Show("Node links generated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void OnChangeToleranceClick(object sender, EventArgs e)
		{
			foreach (var tuple in vicinitySwitch)
				if (tuple.Item1 == sender)
				{
					if (tuple.Item1.Checked) continue;

					vicinity = tuple.Item2;
					isDirty = true;
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
			lstNodes.Items.Clear();
			lstLinks.Items.Clear();
			nodeCollection = new PathNodeCollection();
			EnableInterface(true);

			// Generate automated path nodes
			//todo: move to PathNodeCollection after dealing with IsAvailableTile as OnAddNodeClick is hot
			for (int x = autoGenDlg.r_FX; x <= autoGenDlg.r_TX; x += autoGenDlg.r_Step)
				for (int y = autoGenDlg.r_FY; y <= autoGenDlg.r_TY; y += autoGenDlg.r_Step)
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
			//todo: nasty mix of responsibility
			string sector = Helper.SEC_GetSectorCorrespondence(x, y).ToString();
			string sectfile = Path.Combine(SectorsPath, sector + ".sec");
			if (!File.Exists(sectfile)) return false; // check if this sector tile is taken first

			//todo: cache loaded files to skip them for consecutive calls
			using (var stream = new FileStream(sectfile, FileMode.Open))
			using (var reader = new BinaryReader(stream))
			{
				int maxX, maxY, minX, minY;
				Helper.Sec_GetMinMax(sector, out minY, out maxY, out minX, out maxX);
				uint lightsCount = reader.ReadUInt32();
				for (int i = 0; i < lightsCount; i++)
					LightEditorEx.LoadLightFromSEC(reader);
				int distX = x - minX;
				int distY = y - minY;
				int skipLength = (distY*64 + distX)*16;
				stream.Seek(skipLength, SeekOrigin.Current);
				return reader.ReadUInt64() <= 32;
			}
		}

		private void OnTimerTick(object sender, EventArgs e)
		{
			// v2.0.0: Interoperability with ToEE console support
			if (!File.Exists(Helper.InteropPath)) return;

			string worldBuilderLogData = null;
			try { worldBuilderLogData = File.ReadLines(Helper.InteropPath).FirstOrDefault(); } catch {}
			if (string.IsNullOrEmpty(worldBuilderLogData)) return;

			string[] logPart = worldBuilderLogData.Split(' ');
			switch (logPart[0])
			{
				case "PNDLOC": // location -> created path node
					if (btnAddNode.Enabled)
					{
						NodeX.Text = logPart[1];
						NodeY.Text = logPart[2];
						OnAddNodeClick(null, null);
					}
					else
						MessageBox.Show("Please create a path node file first! (e.g. click 'New' or 'Open')",
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					try { File.Delete(Helper.InteropPath); } catch {}
					return;
			}
		}

		private void OnLoad(object sender, EventArgs e)
		{
			timer.Enabled = true;
		}
	}
}