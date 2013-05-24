using System;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class SectorLookup : Form
	{
		public SectorLookup()
		{
			InitializeComponent();
		}

		private void btnLookup1_Click(object sender, EventArgs e)
		{
			try
			{
				Sec1.Text = SecHelper.GetSectorCorrespondence(int.Parse(ObjX.Text), int.Parse(ObjY.Text)).ToString() + ".sec";
			}
			catch (Exception)
			{
				Sec1.Text = "UNDECIDED";
				MessageBox.Show("Error: illegal parameters passed as X and Y coordinates!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void btnLookup2_Click(object sender, EventArgs e)
		{
			try
			{
				lstSecs.Items.Clear();
				int _fromX = int.Parse(fromX.Text);
				int _fromY = int.Parse(fromY.Text);
				int _toX = int.Parse(toX.Text);
				int _toY = int.Parse(toY.Text);
				byte SX, SY;
				string secname = "";

				for (int X = _fromX; X <= _toX; X++)
				{
					for (int Y = _fromY; Y <= _toY; Y++)
					{
						secname = SecHelper.GetSectorCorrespondence(X, Y).ToString();
						SecHelper.GetXY(secname, out SX, out SY);
						var sectorId = string.Format("{0}.sec (Sector coords: X={1}, Y={2})", secname, SX, SY);
						if (!(lstSecs.Items.Contains(sectorId)))
							lstSecs.Items.Add(sectorId);
					}
				}
			}
			catch (Exception)
			{
				lstSecs.Items.Add("UNDECIDED");
				MessageBox.Show("Can't parse the X, Y parameters! Please check their validity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}