using System;
using System.Windows.Forms;

namespace WorldBuilder
{
	public partial class PathNodeAutoGen : Form
	{
		public int r_FX = -1;
		public int r_FY = -1;
		public int r_Step = -1;
		public int r_TX = -1;
		public int r_TY = -1;

		public PathNodeAutoGen() { InitializeComponent(); }

		private void btnOK_Click(object sender, EventArgs e)
		{
			r_FX = int.Parse(FX.Text);
			r_FY = int.Parse(FY.Text);
			r_TX = int.Parse(TX.Text);
			r_TY = int.Parse(TY.Text);

			if ((r_TX < r_FX) || (r_TY < r_FY))
			{
				MessageBox.Show("An invalid coordinate box was specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			r_Step = int.Parse(txtStepping.Text);
		}
	}
}