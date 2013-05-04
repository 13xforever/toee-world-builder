using System;
using System.Windows.Forms;

namespace WorldBuilder
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
				Sec1.Text = Helper.SEC_GetSectorCorrespondence(int.Parse(ObjX.Text), int.Parse(ObjY.Text)).ToString() + ".sec";
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
				int _fromX = Int32.Parse(fromX.Text);
				int _fromY = Int32.Parse(fromY.Text);
				int _toX = Int32.Parse(toX.Text);
				int _toY = Int32.Parse(toY.Text);
				int SX = 0;
				int SY = 0;
				string secname = "";

				for (int X = _fromX; X <= _toX; X++)
				{
					for (int Y = _fromY; Y <= _toY; Y++)
					{
						secname = Helper.SEC_GetSectorCorrespondence(X, Y).ToString();
						Helper.SEC_GetXY(secname, ref SX, ref SY);
						if (!(lstSecs.Items.Contains(secname + ".sec (Sector coords: X=" + SX + ", Y=" + SY + ")")))
							lstSecs.Items.Add(secname + ".sec (Sector coords: X=" + SX + ", Y=" + SY + ")");
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