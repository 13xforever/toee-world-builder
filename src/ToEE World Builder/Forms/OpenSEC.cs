using System;
using System.IO;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder
{
	public partial class OpenSEC : Form
	{
		public string FileToOpen = "";

		public OpenSEC()
		{
			InitializeComponent();
		}

		private void OpenSEC_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors"))
			{
				MessageBox.Show("Critical Error 003: installation of ToEE World Editor may be corrupt. Please reinstall.",
								"Critical Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				Close();
			}

			string[] secs = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors", "*.sec");

			int X = -1;
			int Y = -1;
			int mX = -1;
			int mY = -1;
			int MX = -1;
			int MY = -1;

			foreach (string sec in secs)
			{
				Helper.SEC_GetXY(Path.GetFileNameWithoutExtension(sec), ref X, ref Y);
				Helper.Sec_GetMinMax(Path.GetFileNameWithoutExtension(sec), ref mY, ref MY, ref mX, ref MX);

				SEC_LIST.Items.Add(Path.GetFileNameWithoutExtension(sec).PadRight(20, ' ') + "\t" + "(SX = " + X + "; SY = " + Y + ")" + "\t\t" + "Coordinates from (" + mX + "; " + mY + ") to (" + MX + "; " + MY + ")");
			}
		}

		private void SEC_LIST_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SEC_LIST.SelectedIndex != -1)
				btnOpen.Enabled = true;
			else
				btnOpen.Enabled = false;
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			FileToOpen = SEC_LIST.Items[SEC_LIST.SelectedIndex].ToString().Split(' ')[0];
		}
	}
}