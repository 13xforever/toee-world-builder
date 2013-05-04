using System;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder
{
	public partial class CreatePartsysHID : Form
	{
		public string HID = "";

		public CreatePartsysHID()
		{
			InitializeComponent();
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			HID = Helper.HashID_Generate(PartsysName.Text).ToString();
		}
	}
}