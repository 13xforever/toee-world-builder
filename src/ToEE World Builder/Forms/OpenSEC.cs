using System;
using System.IO;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class OpenSEC : Form
	{
		public string FileToOpen = "";
		private static readonly string sectorsPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "\\Sectors");

		public OpenSEC()
		{
			InitializeComponent();
		}

		private void OpenSEC_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(sectorsPath))
			{
				MessageBox.Show("Critical Error 003: installation of ToEE World Editor may be corrupt. Please reinstall.",
								"Critical Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				Close();
			}

			string[] secs = Directory.GetFiles(sectorsPath, "*.sec");

			int X, Y, mX, mY, MX, MY;
			foreach (string sec in secs)
			{
				Helper.SEC_GetXY(Path.GetFileNameWithoutExtension(sec), out X, out Y);
				Helper.Sec_GetMinMax(Path.GetFileNameWithoutExtension(sec), out mY, out MY, out mX, out MX);
				SEC_LIST.Items.Add(string.Format("{0,-20}\t(SX = {1}; SY = {2})\t\tCoordinates from ({3}; {4}) to ({5}; {6})", Path.GetFileNameWithoutExtension(sec), X, Y, mX, mY, MX, MY));
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