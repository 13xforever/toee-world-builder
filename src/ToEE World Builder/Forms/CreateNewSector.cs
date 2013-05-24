using System;
using System.IO;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class CreateNewSector : Form
	{
		private static readonly string SectorsPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "\\Sectors");
		public string FileToOpen = "";
		public int maxX = -1;
		public int maxY = -1;
		public int minX = -1;
		public int minY = -1;

		public CreateNewSector()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int CX, CY;
			if (rbObjCoords.Checked)
			{
				// Make sec name from object coordinates
				CX = int.Parse(ObjX.Text);
				CY = int.Parse(ObjY.Text);
				FileToOpen = SecHelper.GetSectorCorrespondence(CX, CY).ToString();
				SecHelper.GetMinMax(FileToOpen, out minY, out maxY, out minX, out maxX);
			}
			else
			{
				if (ulong.Parse(SecX.Text) > 31 || ulong.Parse(SecY.Text) > 31)
				{
					MessageBox.Show("Illegal value entered for sector coordinates! (Note: in ToEE the sector coordinates usually don't go past 15)",
									"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					FileToOpen = "";
					return;
				}

				CX = int.Parse(SecX.Text);
				CY = int.Parse(SecY.Text);
				FileToOpen = SecHelper.GetSecNameFromXY(CX, CY).ToString();
				SecHelper.GetMinMax(Path.GetFileNameWithoutExtension(FileToOpen), out minY, out maxY, out minX, out maxX);
			}

			if (File.Exists(Path.Combine(SectorsPath, FileToOpen + ".sec")))
			{
				if (MessageBox.Show("Warning: the sector file you specified already exists. It will be overwritten. Are you sure you want to continue?",
									"Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					FileToOpen = "";
			}
		}
	}
}