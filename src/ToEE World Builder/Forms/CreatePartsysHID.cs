using System;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class CreatePartsysHID : Form
	{
		public string HID = "";

		public CreatePartsysHID()
		{
			InitializeComponent();
		}

		private void OnCreateClick(object sender, EventArgs e)
		{
			HID = ElfHash(PartsysName.Text).ToString();
		}

		/// <summary>
		///     ElfHash - another hashing function. Used for lights.
		/// </summary>
		private static uint ElfHash(string str)
		{
			uint h = 0, g;
			foreach (char c in str)
			{
				uint cur = c;
				if (cur >= 'a' && cur <= 'z') cur -= ('a' - 'A');
				h = (h << 4) + cur;
				g = h & 0xF0000000;
				if (g != 0)
					h ^= g >> 24;
				h &= ~g;
			}
			return h;
		}
	}
}