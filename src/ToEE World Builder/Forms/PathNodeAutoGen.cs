using System;
using System.Text;
using System.Windows.Forms;

namespace WorldBuilder.Forms
{
	public partial class PathNodeAutoGen : Form
	{
		public int FromX;
		public int FromY;
		public int Step;
		public int ToX;
		public int ToY;

		public PathNodeAutoGen()
		{
			InitializeComponent();
			OnSteppingScroll(null, null);
		}

		private static void Swap<T>(ref T a, ref T b) where T : struct
		{
			var tmp = a;
			a = b;
			b = tmp;
		}

		private void OnSteppingScroll(object sender, EventArgs e)
		{
			steppingToolTip.SetToolTip(stepping, stepping.Value.ToString());
		}

		private void OnClosing(object sender, FormClosingEventArgs e)
		{
			var errorMsg = new StringBuilder();
			if (!int.TryParse(FX.Text, out FromX) || FromX < 0 || FromX > 0x3fff ||
				!int.TryParse(TX.Text, out ToX) || ToX < 0 || ToX > 0x3fff)
				errorMsg.AppendLine("At least one of the X values are not in a valid format. All numbers should be integer values in range [0-16383].");

			if (!int.TryParse(FY.Text, out FromY) || FromY < 0 || FromY > 0x0fff ||
				!int.TryParse(TY.Text, out ToY) || ToY < 0 || ToY > 0x0fff)
				errorMsg.AppendLine("At least one of the Y values are not in a valid format. All numbers should be integer values in range [0-4095].");

			if (errorMsg.Length > 0)
			{
				MessageBox.Show(errorMsg.ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;
			}

			if (ToX < FromX) Swap(ref ToX, ref FromX);
			if (ToY < FromY) Swap(ref ToY, ref FromY);
			Step = stepping.Value;
		}
	}
}