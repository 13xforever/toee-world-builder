using System;
using System.Windows.Forms;

namespace WorldBuilder
{
	public partial class InputMOBGUID : Form
	{
		public bool ERROR = false;
		public string GUID;
		public byte[] GUID_BYTES = new byte[24];

		public InputMOBGUID()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			try
			{
				GUID = txtGUID.Text;
			}
			catch (Exception)
			{
				ERROR = true;
			}
		}
	}
}