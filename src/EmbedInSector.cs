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
	/// Summary description for EmbedInSector.
	/// </summary>
	public class EmbedInSector : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rbAutoDetect;
		private System.Windows.Forms.Label tAutoSector;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label tOpenSector;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOpenSectorToEmbed;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmbedInSector()
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.rbAutoDetect = new System.Windows.Forms.RadioButton();
			this.tAutoSector = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.btnOpenSectorToEmbed = new System.Windows.Forms.Button();
			this.tOpenSector = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(25, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "Static objects such as scenery, portals, doors, etc. must be embedded into sector" +
				"s to work correctly. Please choose the target sector.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(104, 192);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(184, 192);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// rbAutoDetect
			// 
			this.rbAutoDetect.Checked = true;
			this.rbAutoDetect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbAutoDetect.Location = new System.Drawing.Point(8, 64);
			this.rbAutoDetect.Name = "rbAutoDetect";
			this.rbAutoDetect.Size = new System.Drawing.Size(360, 24);
			this.rbAutoDetect.TabIndex = 3;
			this.rbAutoDetect.TabStop = true;
			this.rbAutoDetect.Text = "Auto-detect sector name from object coordinates (Recommended)";
			// 
			// tAutoSector
			// 
			this.tAutoSector.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.tAutoSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tAutoSector.Location = new System.Drawing.Point(24, 88);
			this.tAutoSector.Name = "tAutoSector";
			this.tAutoSector.Size = new System.Drawing.Size(344, 23);
			this.tAutoSector.TabIndex = 4;
			this.tAutoSector.Text = "FAILED TO DETECT";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 120);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(360, 24);
			this.radioButton1.TabIndex = 5;
			this.radioButton1.Text = "Open an existing sector file (Be careful when using this method!)";
			// 
			// btnOpenSectorToEmbed
			// 
			this.btnOpenSectorToEmbed.Location = new System.Drawing.Point(24, 144);
			this.btnOpenSectorToEmbed.Name = "btnOpenSectorToEmbed";
			this.btnOpenSectorToEmbed.Size = new System.Drawing.Size(32, 23);
			this.btnOpenSectorToEmbed.TabIndex = 6;
			this.btnOpenSectorToEmbed.Text = "...";
			this.btnOpenSectorToEmbed.Click += new System.EventHandler(this.btnOpenSectorToEmbed_Click);
			// 
			// tOpenSector
			// 
			this.tOpenSector.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.tOpenSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.tOpenSector.Location = new System.Drawing.Point(64, 148);
			this.tOpenSector.Name = "tOpenSector";
			this.tOpenSector.Size = new System.Drawing.Size(296, 20);
			this.tOpenSector.TabIndex = 7;
			this.tOpenSector.Text = "NO SECTOR FILE IS OPEN";
			// 
			// label2
			// 
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Location = new System.Drawing.Point(0, 184);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(376, 1);
			this.label2.TabIndex = 9;
			this.label2.Text = "label2";
			// 
			// EmbedInSector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(362, 223);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tOpenSector);
			this.Controls.Add(this.btnOpenSectorToEmbed);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.tAutoSector);
			this.Controls.Add(this.rbAutoDetect);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "EmbedInSector";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Embed Object In A Sector";
			this.Load += new System.EventHandler(this.EmbedInSector_Load);
			this.ResumeLayout(false);

		}
		#endregion

		// PUBLIC FIELDS THAT RETURN FINAL SECTOR FILE NAME AND DEL-GUID
		public string FileName = "";
		public bool DeleteGUID = false;

		private void EmbedInSector_Load(object sender, System.EventArgs e)
		{
			tAutoSector.Text = Helper.SectorName;

			if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\Sectors\\"+tAutoSector.Text))
				tAutoSector.Text += " (exists, object will be added)";
			else
				tAutoSector.Text += " (doesn't exist, will be created)";
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (rbAutoDetect.Checked)
			{
				// Use auto-detected name
				if (tAutoSector.Text.IndexOf(".sec") != -1)
				{
					FileName = Path.GetDirectoryName(Application.ExecutablePath)+"\\Sectors\\"+tAutoSector.Text.Split(' ')[0];
				}
				else
				{
					MessageBox.Show("The sector file name was not properly auto-detected! Please report it as a bug!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					FileName = "";
				}
			}
			else
			{
				// Opened sector
				if (tOpenSector.Text.IndexOf(".sec") != -1)
				{
					FileName = Path.GetDirectoryName(Application.ExecutablePath)+"\\Sectors\\"+tOpenSector.Text;
				}
				else
				{
					MessageBox.Show("You have specified the mode to open the sector file but didn't open the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					FileName = "";
				}
			}
		}

		private void btnOpenSectorToEmbed_Click(object sender, System.EventArgs e)
		{
			OpenSEC o = new OpenSEC();
			if (o.ShowDialog() == DialogResult.OK)
			{
				if (o.FileToOpen != "")
				{
					tOpenSector.Text = o.FileToOpen + ".sec";
				}
			}
		}
	}
}
