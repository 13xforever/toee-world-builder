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

namespace ToEE_World_Builder
{
	/// <summary>
	/// Summary description for SectorLookup.
	/// </summary>
	public class SectorLookup : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ObjX;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox ObjY;
		private System.Windows.Forms.Button btnLookup1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label Sec1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox fromY;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox fromX;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox toY;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox toX;
		private System.Windows.Forms.Button btnLookup2;
		private System.Windows.Forms.ListBox lstSecs;
		private System.Windows.Forms.Label label10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SectorLookup()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SectorLookup));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ObjX = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ObjY = new System.Windows.Forms.TextBox();
			this.btnLookup1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.Sec1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.fromY = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.fromX = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.toY = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.toX = new System.Windows.Forms.TextBox();
			this.btnLookup2 = new System.Windows.Forms.Button();
			this.lstSecs = new System.Windows.Forms.ListBox();
			this.label10 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(552, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "1. I know the coordinates of an object, but I don\'t know what sector file it corr" +
				"esponds to.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "My object\'s coordinates are: X=";
			// 
			// ObjX
			// 
			this.ObjX.Location = new System.Drawing.Point(192, 32);
			this.ObjX.Name = "ObjX";
			this.ObjX.Size = new System.Drawing.Size(48, 20);
			this.ObjX.TabIndex = 2;
			this.ObjX.Text = "0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(248, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Y=";
			// 
			// ObjY
			// 
			this.ObjY.Location = new System.Drawing.Point(272, 32);
			this.ObjY.Name = "ObjY";
			this.ObjY.Size = new System.Drawing.Size(48, 20);
			this.ObjY.TabIndex = 4;
			this.ObjY.Text = "0";
			// 
			// btnLookup1
			// 
			this.btnLookup1.Location = new System.Drawing.Point(328, 32);
			this.btnLookup1.Name = "btnLookup1";
			this.btnLookup1.Size = new System.Drawing.Size(88, 24);
			this.btnLookup1.TabIndex = 5;
			this.btnLookup1.Text = "Look up";
			this.btnLookup1.Click += new System.EventHandler(this.btnLookup1_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(200, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "The sector file for your coordinates is:";
			// 
			// Sec1
			// 
			this.Sec1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Sec1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.Sec1.Location = new System.Drawing.Point(216, 64);
			this.Sec1.Name = "Sec1";
			this.Sec1.Size = new System.Drawing.Size(176, 23);
			this.Sec1.TabIndex = 7;
			this.Sec1.Text = "UNDECIDED";
			// 
			// label5
			// 
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.Location = new System.Drawing.Point(0, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(568, 1);
			this.label5.TabIndex = 8;
			this.label5.Text = "label5";
			// 
			// label6
			// 
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.label6.Location = new System.Drawing.Point(8, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(552, 32);
			this.label6.TabIndex = 9;
			this.label6.Text = "2. I have a huge object that goes across several sectors, but I\'m not sure which " +
				"sector files I must update to cover the whole object.";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(32, 160);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(232, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "My object covers a rectangular area from X=";
			// 
			// fromY
			// 
			this.fromY.Location = new System.Drawing.Point(328, 160);
			this.fromY.Name = "fromY";
			this.fromY.Size = new System.Drawing.Size(48, 20);
			this.fromY.TabIndex = 13;
			this.fromY.Text = "0";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(304, 160);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(24, 23);
			this.label8.TabIndex = 12;
			this.label8.Text = "Y=";
			// 
			// fromX
			// 
			this.fromX.Location = new System.Drawing.Point(248, 160);
			this.fromX.Name = "fromX";
			this.fromX.Size = new System.Drawing.Size(48, 20);
			this.fromX.TabIndex = 11;
			this.fromX.Text = "0";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(384, 160);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 23);
			this.label9.TabIndex = 14;
			this.label9.Text = "to  X=";
			// 
			// toY
			// 
			this.toY.Location = new System.Drawing.Point(496, 160);
			this.toY.Name = "toY";
			this.toY.Size = new System.Drawing.Size(48, 20);
			this.toY.TabIndex = 17;
			this.toY.Text = "0";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(472, 160);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(24, 23);
			this.label11.TabIndex = 16;
			this.label11.Text = "Y=";
			// 
			// toX
			// 
			this.toX.Location = new System.Drawing.Point(424, 160);
			this.toX.Name = "toX";
			this.toX.Size = new System.Drawing.Size(48, 20);
			this.toX.TabIndex = 15;
			this.toX.Text = "0";
			// 
			// btnLookup2
			// 
			this.btnLookup2.Location = new System.Drawing.Point(248, 184);
			this.btnLookup2.Name = "btnLookup2";
			this.btnLookup2.Size = new System.Drawing.Size(88, 24);
			this.btnLookup2.TabIndex = 18;
			this.btnLookup2.Text = "Look up";
			this.btnLookup2.Click += new System.EventHandler(this.btnLookup2_Click);
			// 
			// lstSecs
			// 
			this.lstSecs.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.lstSecs.ItemHeight = 15;
			this.lstSecs.Items.AddRange(new object[] {
														 "UNDECIDED"});
			this.lstSecs.Location = new System.Drawing.Point(160, 216);
			this.lstSecs.Name = "lstSecs";
			this.lstSecs.Size = new System.Drawing.Size(400, 184);
			this.lstSecs.TabIndex = 19;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(0, 216);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(160, 48);
			this.label10.TabIndex = 20;
			this.label10.Text = "It turns out that you must update the following sectors with your parameters:";
			// 
			// SectorLookup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(568, 408);
			this.Controls.Add(this.toY);
			this.Controls.Add(this.toX);
			this.Controls.Add(this.fromY);
			this.Controls.Add(this.fromX);
			this.Controls.Add(this.ObjY);
			this.Controls.Add(this.ObjX);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.lstSecs);
			this.Controls.Add(this.btnLookup2);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.Sec1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.btnLookup1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SectorLookup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sector Coordinate Lookup Tool";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnLookup1_Click(object sender, System.EventArgs e)
		{
			try
			{
				Sec1.Text = Helper.SEC_GetSectorCorrespondence(int.Parse(ObjX.Text), int.Parse(ObjY.Text)).ToString()+".sec";
			}
			catch (Exception)
			{
				Sec1.Text = "UNDECIDED";
				MessageBox.Show("Error: illegal parameters passed as X and Y coordinates!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void btnLookup2_Click(object sender, System.EventArgs e)
		{
			try
			{
				lstSecs.Items.Clear();
				int _fromX = Int32.Parse(fromX.Text);
				int _fromY = Int32.Parse(fromY.Text);
				int _toX = Int32.Parse(toX.Text);
				int _toY = Int32.Parse(toY.Text);
				int SX = 0;
				int SY = 0;
				string secname = "";

				for (int X=_fromX; X<=_toX; X++)
				{
					for (int Y=_fromY; Y<=_toY; Y++)
					{
						secname = Helper.SEC_GetSectorCorrespondence(X,Y).ToString();
						Helper.SEC_GetXY(secname, ref SX, ref SY);
						if (!(lstSecs.Items.Contains(secname+".sec (Sector coords: X="+SX+", Y="+SY+")")))
							lstSecs.Items.Add(secname+".sec (Sector coords: X="+SX+", Y="+SY+")");
					}
				}
			}
			catch (Exception)
			{
				lstSecs.Items.Add("UNDECIDED");
				MessageBox.Show("Can't parse the X, Y parameters! Please check their validity!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
	}
}
