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
	/// Summary description for OpenMOB.
	/// </summary>
	public class OpenMOB : System.Windows.Forms.Form
	{
        public ArrayList mobListMemory = new ArrayList();
		private System.Windows.Forms.ListBox MOB_LIST;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Button btnDeleteMOB;
        private Label label1;
        private TextBox mobProtoSearch;
        private TextBox mobDescriptionSearch;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox mobGUIDSearch;

		public string FileToOpen = "";

		public OpenMOB()
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
            this.btnDeleteMOB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mobProtoSearch = new System.Windows.Forms.TextBox();
            this.mobDescriptionSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mobGUIDSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MOB_LIST
            // 
            this.MOB_LIST.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MOB_LIST.ItemHeight = 15;
            this.MOB_LIST.Location = new System.Drawing.Point(8, 8);
            this.MOB_LIST.Name = "MOB_LIST";
            this.MOB_LIST.Size = new System.Drawing.Size(744, 499);
            this.MOB_LIST.TabIndex = 0;
            this.MOB_LIST.SelectedIndexChanged += new System.EventHandler(this.MOB_LIST_SelectedIndexChanged);
            // 
            // btnOpen
            // 
            this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(219, 520);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(104, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(439, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // btnDeleteMOB
            // 
            this.btnDeleteMOB.Enabled = false;
            this.btnDeleteMOB.Location = new System.Drawing.Point(329, 520);
            this.btnDeleteMOB.Name = "btnDeleteMOB";
            this.btnDeleteMOB.Size = new System.Drawing.Size(104, 23);
            this.btnDeleteMOB.TabIndex = 3;
            this.btnDeleteMOB.Text = "Delete";
            this.btnDeleteMOB.Click += new System.EventHandler(this.btnDeleteMOB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 560);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter By:";
            // 
            // mobProtoSearch
            // 
            this.mobProtoSearch.Location = new System.Drawing.Point(98, 580);
            this.mobProtoSearch.Name = "mobProtoSearch";
            this.mobProtoSearch.Size = new System.Drawing.Size(100, 20);
            this.mobProtoSearch.TabIndex = 5;
            this.mobProtoSearch.TextChanged += new System.EventHandler(this.mobProtoSearch_TextChanged);
            // 
            // mobDescriptionSearch
            // 
            this.mobDescriptionSearch.Location = new System.Drawing.Point(329, 580);
            this.mobDescriptionSearch.Name = "mobDescriptionSearch";
            this.mobDescriptionSearch.Size = new System.Drawing.Size(100, 20);
            this.mobDescriptionSearch.TabIndex = 6;
            this.mobDescriptionSearch.TextChanged += new System.EventHandler(this.mobDescriptionSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Proto ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 583);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 584);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "GUID";
            // 
            // mobGUIDSearch
            // 
            this.mobGUIDSearch.Location = new System.Drawing.Point(558, 580);
            this.mobGUIDSearch.Name = "mobGUIDSearch";
            this.mobGUIDSearch.Size = new System.Drawing.Size(100, 20);
            this.mobGUIDSearch.TabIndex = 9;
            this.mobGUIDSearch.TextChanged += new System.EventHandler(this.mobGUIDSearch_TextChanged);
            // 
            // OpenMOB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(762, 609);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mobGUIDSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mobDescriptionSearch);
            this.Controls.Add(this.mobProtoSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteMOB);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.MOB_LIST);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OpenMOB";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open/Inspect Mobile Object Files";
            this.Load += new System.EventHandler(this.OpenMOB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
					MOB_LIST.Items.Add(Path.GetFileNameWithoutExtension(mob)+"\t"+COMPATIBLE+"\t"+"(X="+x_coord.ToString()+"; Y="+y_coord.ToString()+")\t\t"+Helper.Proto_By_ID[proto_id.ToString()].ToString()+"\t("+proto_id+")");
                    mobListMemory.Add(Path.GetFileNameWithoutExtension(mob)+"\t"+COMPATIBLE+"\t"+"(X="+x_coord.ToString()+"; Y="+y_coord.ToString()+")\t\t"+Helper.Proto_By_ID[proto_id.ToString()].ToString()+"\t("+proto_id+")");
				}
				catch (Exception)
				{
					MessageBox.Show("For some reason, the following file is corrupt and is beyond recovery:\n"+Path.GetFileNameWithoutExtension(mob)+".mob\n\nIt'd be better if you deleted this file.","Error Pre-Parsing Mobile Object",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

            // Restore last opened MOB position
            try
            {
                if (Helper.LastOpenedMOB != "")
                    MOB_LIST.SelectedItem = Helper.LastOpenedMOB;
            }
            catch (Exception)
            {
                Helper.LastOpenedMOB = "";
            }
		}

		private void MOB_LIST_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            if (MOB_LIST.SelectedIndex == -1 /* DEPRECATED: || (MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().IndexOf("(INCOMPATIBLE)") != -1 && !chkForce.Checked) */ )
            {
                btnOpen.Enabled = false;
                btnDeleteMOB.Enabled = false;
            }
            else
            {
                btnOpen.Enabled = true;
                btnDeleteMOB.Enabled = true;
            }
		}

		private void btnOpen_Click(object sender, System.EventArgs e)
		{
            Helper.LastOpenedMOB = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString();
			FileToOpen = MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0];
		}

		private void chkForce_CheckedChanged(object sender, System.EventArgs e)
		{
			btnOpen.Enabled = true;
		}

        private void btnDeleteMOB_Click(object sender, EventArgs e)
        {
            if (MOB_LIST.SelectedIndex == -1)
                return;

            if (MessageBox.Show("Are you sure you want to delete this mobile object?\n\nNOTE: This does not remove linked mobile objects (e.g. inventory). Please clean the inventories by hand first.", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            string FileToDel = Path.GetDirectoryName(Application.ExecutablePath)+"\\Mobiles\\"+MOB_LIST.Items[MOB_LIST.SelectedIndex].ToString().Split('\t')[0]+".mob";
            MOB_LIST.Items.Remove(MOB_LIST.Items[MOB_LIST.SelectedIndex]);
            File.Delete(FileToDel);
        }

        private void mobProtoSearch_TextChanged(object sender, EventArgs e)
        {

            MOB_LIST.Items.Clear();
            for (int i = 0; i < mobListMemory.Count; i++)
            {
                string mob_entry = mobListMemory[i].ToString();
                string mobGUIDField = mob_entry.Split('\t')[0];
                string mobProtoField = mob_entry.Split('\t')[5];
                string mobDescriptionField = mob_entry.Split('\t')[4];
                if (mobGUIDField.ToLower().Contains(mobGUIDSearch.Text.ToLower()) && mobProtoField.ToLower().Contains(mobProtoSearch.Text.ToLower()) && mobDescriptionField.ToLower().Contains(mobDescriptionSearch.Text.ToLower()))
                    MOB_LIST.Items.Add(mob_entry);
            }

        }

        private void mobDescriptionSearch_TextChanged(object sender, EventArgs e)
        {

            MOB_LIST.Items.Clear();
            for (int i = 0; i < mobListMemory.Count; i++)
            {
                string mob_entry = mobListMemory[i].ToString();
                string mobGUIDField = mob_entry.Split('\t')[0];
                string mobProtoField = mob_entry.Split('\t')[5];
                string mobDescriptionField = mob_entry.Split('\t')[4];
                if (mobGUIDField.ToLower().Contains(mobGUIDSearch.Text.ToLower()) && mobProtoField.ToLower().Contains(mobProtoSearch.Text.ToLower()) && mobDescriptionField.ToLower().Contains(mobDescriptionSearch.Text.ToLower()))
                    MOB_LIST.Items.Add(mob_entry);
            }

        }

        private void mobGUIDSearch_TextChanged(object sender, EventArgs e)
        {

            MOB_LIST.Items.Clear();
            for (int i = 0; i < mobListMemory.Count; i++)
            {
                string mob_entry = mobListMemory[i].ToString();
                string mobGUIDField = mob_entry.Split('\t')[0];
                string mobProtoField = mob_entry.Split('\t')[5];
                string mobDescriptionField = mob_entry.Split('\t')[4];
                if (mobGUIDField.ToLower().Contains(mobGUIDSearch.Text.ToLower()) && mobProtoField.ToLower().Contains(mobProtoSearch.Text.ToLower()) && mobDescriptionField.ToLower().Contains(mobDescriptionSearch.Text.ToLower()))
                    MOB_LIST.Items.Add(mob_entry);
            }

        }


	}
}
