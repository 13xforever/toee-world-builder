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
	/// Summary description for LinkMOB.
	/// </summary>
	public class LinkMOB : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox MOB_LIST;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public byte[] LinkGUID = new byte[24];
		public string GUID = "";
		public string FullString = "";

		public LinkMOB()
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
			this.MOB_LIST = new System.Windows.Forms.ListBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// MOB_LIST
			// 
			this.MOB_LIST.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MOB_LIST.ItemHeight = 15;
			this.MOB_LIST.Location = new System.Drawing.Point(8, 8);
			this.MOB_LIST.Name = "MOB_LIST";
			this.MOB_LIST.Size = new System.Drawing.Size(744, 484);
			this.MOB_LIST.TabIndex = 0;
			this.MOB_LIST.SelectedIndexChanged += new System.EventHandler(this.MOB_LIST_SelectedIndexChanged);
			// 
			// btnOpen
			// 
			this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOpen.Enabled = false;
			this.btnOpen.Location = new System.Drawing.Point(272, 506);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(104, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Link";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(384, 506);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// LinkMOB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(762, 551);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.MOB_LIST);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "LinkMOB";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Link Mobile Object Files";
			this.Load += new System.EventHandler(this.OpenMOB_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void OpenMOB_Load(object sender, System.EventArgs e)
		{
			if (!Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\Mobiles"))
			{
				MessageBox.Show("Critical Error 003: installation of ToEE World Editor may be corrupt. Please reinstall.",
					"Critical Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				this.Close();
			}

			string[] mobs = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath)+"\\Mobiles","*.mob");

			foreach (string mob in mobs)
			{
				try
				{
					BinaryReader br = new BinaryReader(new FileStream(mob, FileMode.Open));
					br.BaseStream.Seek(0x06, SeekOrigin.Begin);
					UInt32 compat = br.ReadUInt32();
					br.BaseStream.Seek(0x0C, SeekOrigin.Begin);
					Int16 proto_id = br.ReadInt16();
					br.BaseStream.Seek(0x34, SeekOrigin.Begin);
					UInt32 type = br.ReadUInt32();
					br.BaseStream.Seek(0x3A, SeekOrigin.Begin);
					long BlocksToSkip = Helper.MOB_GetNumberofBitmapBlocks((MobTypes)type);
					br.BaseStream.Seek(BlocksToSkip * 4 + 1, SeekOrigin.Current);
					UInt32 x_coord = br.ReadUInt32();
					UInt32 y_coord = br.ReadUInt32();

					br.Close();

					string COMPATIBLE = "(MOB OBJECT)";
					MOB_LIST.Items.Add(Path.GetFileNameWithoutExtension(mob)+"\t"+COMPATIBLE+"\t"+"(X="+x_coord.ToString()+"; Y="+y_coord.ToString()+")\t\t"+Helper.Proto_By_ID[proto_id.ToString()].ToString());
				}
				catch (Exception)
				{
					MessageBox.Show("For some reason, the following file is corrupt and is beyond recovery:\n"+Path.GetFileNameWithoutExtension(mob)+".mob\n\nIt'd be better if you deleted this file.","Error Pre-Parsing Mobile Object",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
		}

		private void MOB_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (MOB_LIST.SelectedIndex == -1)
				btnOpen.Enabled = false;
			else
				btnOpen.Enabled = true;

			// Load up the GUID (important for linking)
			BinaryReader br = new BinaryReader(new FileStream("Mobiles\\"+MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0]+".mob", FileMode.Open));
			br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
			LinkGUID = br.ReadBytes(24);
			br.Close();
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
			GUID = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0];
			FullString = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString();
		}
	}
}
