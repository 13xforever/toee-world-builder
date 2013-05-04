// ToEE World Builder .NET2 version 2.0.0 Open-Source Edition
// Copyright (C) 2005-2006    Michael Kamensky, all rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace ToEE_World_Builder
{
	/// <summary>
	/// Summary description for OpenSEC.
	/// </summary>
	public class OpenSEC : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox SEC_LIST;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string FileToOpen = "";

		public OpenSEC()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.SEC_LIST = new System.Windows.Forms.ListBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SEC_LIST
			// 
			this.SEC_LIST.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.SEC_LIST.ItemHeight = 15;
			this.SEC_LIST.Location = new System.Drawing.Point(8, 8);
			this.SEC_LIST.Name = "SEC_LIST";
			this.SEC_LIST.Size = new System.Drawing.Size(744, 484);
			this.SEC_LIST.TabIndex = 0;
			this.SEC_LIST.SelectedIndexChanged += new System.EventHandler(this.SEC_LIST_SelectedIndexChanged);
			// 
			// btnOpen
			// 
			this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOpen.Enabled = false;
			this.btnOpen.Location = new System.Drawing.Point(272, 512);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(104, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(384, 512);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// OpenSEC
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(762, 551);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.SEC_LIST);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OpenSEC";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Open/Inspect Sector Files";
			this.Load += new System.EventHandler(this.OpenSEC_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void OpenSEC_Load(object sender, System.EventArgs e)
		{
			if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\Sectors"))
			{
				MessageBox.Show("Critical Error 003: installation of ToEE World Editor may be corrupt. Please reinstall.",
					"Critical Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				this.Close();
			}

			string[] secs = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath)+"\\Sectors","*.sec");

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

				SEC_LIST.Items.Add(Path.GetFileNameWithoutExtension(sec).PadRight(20,' ')+"\t"+"(SX = "+X+"; SY = "+Y+")"+"\t\t"+"Coordinates from ("+mX+"; "+mY+") to ("+MX+"; "+MY+")");
			}
		}

		private void SEC_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SEC_LIST.SelectedIndex != -1)
				btnOpen.Enabled = true;
			else
				btnOpen.Enabled = false;
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			FileToOpen = SEC_LIST.Items[SEC_LIST.SelectedIndex].ToString().Split(' ')[0];
		}
	}
}
