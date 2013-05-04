using System;
using System.IO;
using System.Windows.Forms;

namespace WorldBuilder
{
	public partial class EmbedInSector : Form
	{
		// PUBLIC FIELDS THAT RETURN FINAL SECTOR FILE NAME AND DEL-GUID
		public bool DeleteGUID = false;
		public string FileName = "";

		public EmbedInSector()
		{
			InitializeComponent();
		}

		private void EmbedInSector_Load(object sender, EventArgs e)
		{
			tAutoSector.Text = Helper.SectorName;

			if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors\\" + tAutoSector.Text))
				tAutoSector.Text += " (exists, object will be added)";
			else
				tAutoSector.Text += " (doesn't exist, will be created)";
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (rbAutoDetect.Checked)
			{
				// Use auto-detected name
				if (tAutoSector.Text.IndexOf(".sec") != -1)
				{
					FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors\\" + tAutoSector.Text.Split(' ')[0];
				}
				else
				{
					MessageBox.Show("The sector file name was not properly auto-detected! Please report it as a bug!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					FileName = "";
				}
			}
			else
			{
				// Opened sector
				if (tOpenSector.Text.IndexOf(".sec") != -1)
				{
					FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors\\" + tOpenSector.Text;
				}
				else
				{
					MessageBox.Show("You have specified the mode to open the sector file but didn't open the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					FileName = "";
				}
			}
		}

		private void btnOpenSectorToEmbed_Click(object sender, EventArgs e)
		{
			var o = new OpenSEC();
			if (o.ShowDialog() == DialogResult.OK)
			{
				if (o.FileToOpen != "")
				{
					tOpenSector.Text = o.FileToOpen + ".sec";
				}
			}
		}
	}
}