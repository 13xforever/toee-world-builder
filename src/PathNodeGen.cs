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
using System.Text.RegularExpressions;

namespace ToEE_World_Builder
{
	/// <summary>
	/// Summary description for PathNodeGen.
	/// </summary>
	public class PathNodeGen : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOpenPND;
		private System.Windows.Forms.OpenFileDialog OpenPND;
		private System.Windows.Forms.SaveFileDialog SavePND;
		private System.Windows.Forms.Button btnSavePND;
		private System.Windows.Forms.Button btnNewPND;
		private System.Windows.Forms.Button btnQuitPND;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGeneratePND;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lstNodes;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox NodeX;
		private System.Windows.Forms.TextBox NodeY;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox NodeOfsX;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox NodeOfsY;
		private System.Windows.Forms.Button btnAddNode;
		private System.Windows.Forms.Button btnDelNode;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox lstLinks;
		private System.Windows.Forms.Button btnGotoPND;
		private System.Windows.Forms.MainMenu mnuPathTolerance;
		private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2a;
		private System.Windows.Forms.MenuItem menuItem3a;
		private System.Windows.Forms.MenuItem menuItem4a;
		private System.Windows.Forms.MenuItem menuItem5a;
		private System.Windows.Forms.MenuItem menuItem6a;
		private System.Windows.Forms.MenuItem menuItem7a;
		private System.Windows.Forms.MenuItem menuItem8a;
		private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem10a;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem NET2Menu;
        private ToolStripMenuItem menuItem2;
        private ToolStripMenuItem menuItem3;
        private ToolStripMenuItem menuItem4;
        private ToolStripMenuItem menuItem5;
        private ToolStripMenuItem menuItem6;
        private ToolStripMenuItem menuItem7;
        private ToolStripMenuItem menuItem8;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem menuItem10;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem autoPathnodeGeneratorToolStripMenuItem;
        private Timer tmrPND;
        private ToolStripMenuItem experimentalToolStripMenuItem;
        private IContainer components;

		public PathNodeGen()
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
            this.components = new System.ComponentModel.Container();
            this.btnOpenPND = new System.Windows.Forms.Button();
            this.OpenPND = new System.Windows.Forms.OpenFileDialog();
            this.SavePND = new System.Windows.Forms.SaveFileDialog();
            this.btnSavePND = new System.Windows.Forms.Button();
            this.btnNewPND = new System.Windows.Forms.Button();
            this.btnQuitPND = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGeneratePND = new System.Windows.Forms.Button();
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NodeX = new System.Windows.Forms.TextBox();
            this.NodeY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NodeOfsX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NodeOfsY = new System.Windows.Forms.TextBox();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.btnDelNode = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lstLinks = new System.Windows.Forms.ListBox();
            this.btnGotoPND = new System.Windows.Forms.Button();
            this.mnuPathTolerance = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2a = new System.Windows.Forms.MenuItem();
            this.menuItem3a = new System.Windows.Forms.MenuItem();
            this.menuItem4a = new System.Windows.Forms.MenuItem();
            this.menuItem5a = new System.Windows.Forms.MenuItem();
            this.menuItem6a = new System.Windows.Forms.MenuItem();
            this.menuItem7a = new System.Windows.Forms.MenuItem();
            this.menuItem8a = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10a = new System.Windows.Forms.MenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NET2Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoPathnodeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrPND = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenPND
            // 
            this.btnOpenPND.Location = new System.Drawing.Point(200, 472);
            this.btnOpenPND.Name = "btnOpenPND";
            this.btnOpenPND.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPND.TabIndex = 0;
            this.btnOpenPND.Text = "Open...";
            this.btnOpenPND.Click += new System.EventHandler(this.btnOpenPND_Click);
            // 
            // OpenPND
            // 
            this.OpenPND.Filter = "Path Nodes (pathnode.pnd)|pathnode.pnd";
            // 
            // SavePND
            // 
            this.SavePND.Filter = "Path Nodes (pathnode.pnd)|pathnode.pnd";
            // 
            // btnSavePND
            // 
            this.btnSavePND.Enabled = false;
            this.btnSavePND.Location = new System.Drawing.Point(280, 472);
            this.btnSavePND.Name = "btnSavePND";
            this.btnSavePND.Size = new System.Drawing.Size(75, 23);
            this.btnSavePND.TabIndex = 1;
            this.btnSavePND.Text = "Save...";
            this.btnSavePND.Click += new System.EventHandler(this.btnSavePND_Click);
            // 
            // btnNewPND
            // 
            this.btnNewPND.Location = new System.Drawing.Point(120, 472);
            this.btnNewPND.Name = "btnNewPND";
            this.btnNewPND.Size = new System.Drawing.Size(75, 23);
            this.btnNewPND.TabIndex = 2;
            this.btnNewPND.Text = "New";
            this.btnNewPND.Click += new System.EventHandler(this.btnNewPND_Click);
            // 
            // btnQuitPND
            // 
            this.btnQuitPND.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuitPND.Location = new System.Drawing.Point(440, 472);
            this.btnQuitPND.Name = "btnQuitPND";
            this.btnQuitPND.Size = new System.Drawing.Size(75, 23);
            this.btnQuitPND.TabIndex = 3;
            this.btnQuitPND.Text = "Exit";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path Nodes:";
            // 
            // btnGeneratePND
            // 
            this.btnGeneratePND.Enabled = false;
            this.btnGeneratePND.Location = new System.Drawing.Point(360, 472);
            this.btnGeneratePND.Name = "btnGeneratePND";
            this.btnGeneratePND.Size = new System.Drawing.Size(75, 23);
            this.btnGeneratePND.TabIndex = 5;
            this.btnGeneratePND.Text = "Generate";
            this.btnGeneratePND.Click += new System.EventHandler(this.btnGeneratePND_Click);
            // 
            // lstNodes
            // 
            this.lstNodes.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstNodes.ItemHeight = 16;
            this.lstNodes.Location = new System.Drawing.Point(8, 40);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.Size = new System.Drawing.Size(304, 372);
            this.lstNodes.TabIndex = 6;
            this.lstNodes.SelectedIndexChanged += new System.EventHandler(this.lstNodes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(0, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(640, 1);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(320, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 439);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 416);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "X:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(72, 416);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Y:";
            // 
            // NodeX
            // 
            this.NodeX.Enabled = false;
            this.NodeX.Location = new System.Drawing.Point(24, 416);
            this.NodeX.Name = "NodeX";
            this.NodeX.Size = new System.Drawing.Size(40, 20);
            this.NodeX.TabIndex = 11;
            this.NodeX.Text = "0";
            // 
            // NodeY
            // 
            this.NodeY.Enabled = false;
            this.NodeY.Location = new System.Drawing.Point(88, 416);
            this.NodeY.Name = "NodeY";
            this.NodeY.Size = new System.Drawing.Size(40, 20);
            this.NodeY.TabIndex = 12;
            this.NodeY.Text = "0";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(128, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "X Offset:";
            // 
            // NodeOfsX
            // 
            this.NodeOfsX.Enabled = false;
            this.NodeOfsX.Location = new System.Drawing.Point(176, 416);
            this.NodeOfsX.Name = "NodeOfsX";
            this.NodeOfsX.Size = new System.Drawing.Size(40, 20);
            this.NodeOfsX.TabIndex = 14;
            this.NodeOfsX.Text = "0";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(216, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "Y Offset:";
            // 
            // NodeOfsY
            // 
            this.NodeOfsY.Enabled = false;
            this.NodeOfsY.Location = new System.Drawing.Point(264, 416);
            this.NodeOfsY.Name = "NodeOfsY";
            this.NodeOfsY.Size = new System.Drawing.Size(40, 20);
            this.NodeOfsY.TabIndex = 16;
            this.NodeOfsY.Text = "0";
            // 
            // btnAddNode
            // 
            this.btnAddNode.Enabled = false;
            this.btnAddNode.Location = new System.Drawing.Point(80, 440);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(75, 23);
            this.btnAddNode.TabIndex = 17;
            this.btnAddNode.Text = "Add Node";
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // btnDelNode
            // 
            this.btnDelNode.Enabled = false;
            this.btnDelNode.Location = new System.Drawing.Point(160, 440);
            this.btnDelNode.Name = "btnDelNode";
            this.btnDelNode.Size = new System.Drawing.Size(75, 23);
            this.btnDelNode.TabIndex = 18;
            this.btnDelNode.Text = "Delete Node";
            this.btnDelNode.Click += new System.EventHandler(this.btnDelNode_Click);
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(328, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Current Generated Links for Selected Path Node:";
            // 
            // lstLinks
            // 
            this.lstLinks.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstLinks.ItemHeight = 16;
            this.lstLinks.Location = new System.Drawing.Point(328, 40);
            this.lstLinks.Name = "lstLinks";
            this.lstLinks.Size = new System.Drawing.Size(304, 372);
            this.lstLinks.TabIndex = 20;
            // 
            // btnGotoPND
            // 
            this.btnGotoPND.Enabled = false;
            this.btnGotoPND.Location = new System.Drawing.Point(424, 416);
            this.btnGotoPND.Name = "btnGotoPND";
            this.btnGotoPND.Size = new System.Drawing.Size(96, 23);
            this.btnGotoPND.TabIndex = 21;
            this.btnGotoPND.Text = "Go to this Node";
            this.btnGotoPND.Click += new System.EventHandler(this.btnGotoPND_Click);
            // 
            // mnuPathTolerance
            // 
            this.mnuPathTolerance.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2a,
            this.menuItem3a,
            this.menuItem4a,
            this.menuItem5a,
            this.menuItem6a,
            this.menuItem7a,
            this.menuItem8a,
            this.menuItem9,
            this.menuItem10a});
            this.menuItem1.Text = "Tolerance";
            this.menuItem1.Visible = false;
            // 
            // menuItem2a
            // 
            this.menuItem2a.Index = 0;
            this.menuItem2a.Text = "19 (Rigid)";
            this.menuItem2a.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3a
            // 
            this.menuItem3a.Index = 1;
            this.menuItem3a.Text = "20";
            this.menuItem3a.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4a
            // 
            this.menuItem4a.Index = 2;
            this.menuItem4a.Text = "21";
            this.menuItem4a.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5a
            // 
            this.menuItem5a.Checked = true;
            this.menuItem5a.Index = 3;
            this.menuItem5a.Text = "22 (Default/Recommended)";
            this.menuItem5a.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6a
            // 
            this.menuItem6a.Index = 4;
            this.menuItem6a.Text = "23";
            this.menuItem6a.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7a
            // 
            this.menuItem7a.Index = 5;
            this.menuItem7a.Text = "24";
            this.menuItem7a.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8a
            // 
            this.menuItem8a.Index = 6;
            this.menuItem8a.Text = "25 (Lax)";
            this.menuItem8a.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 7;
            this.menuItem9.Text = "-";
            // 
            // menuItem10a
            // 
            this.menuItem10a.Index = 8;
            this.menuItem10a.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuItem10a.Text = "What is Tolerance?";
            this.menuItem10a.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NET2Menu,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // NET2Menu
            // 
            this.NET2Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.experimentalToolStripMenuItem,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem8,
            this.toolStripMenuItem1,
            this.menuItem10});
            this.NET2Menu.Name = "NET2Menu";
            this.NET2Menu.Size = new System.Drawing.Size(66, 20);
            this.NET2Menu.Text = "Tolerance";
            // 
            // experimentalToolStripMenuItem
            // 
            this.experimentalToolStripMenuItem.Name = "experimentalToolStripMenuItem";
            this.experimentalToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.experimentalToolStripMenuItem.Text = "7 (Experimental)";
            this.experimentalToolStripMenuItem.Visible = false;
            this.experimentalToolStripMenuItem.Click += new System.EventHandler(this.experimentalToolStripMenuItem_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(178, 22);
            this.menuItem2.Text = "19 (Rigid)";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(178, 22);
            this.menuItem3.Text = "20";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(178, 22);
            this.menuItem4.Text = "21";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Checked = true;
            this.menuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItem5.Name = "menuItem5";
            this.menuItem5.Size = new System.Drawing.Size(178, 22);
            this.menuItem5.Text = "22 (Recommended)";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(178, 22);
            this.menuItem6.Text = "23";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Name = "menuItem7";
            this.menuItem7.Size = new System.Drawing.Size(178, 22);
            this.menuItem7.Text = "24";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Name = "menuItem8";
            this.menuItem8.Size = new System.Drawing.Size(178, 22);
            this.menuItem8.Text = "25 (Lax)";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(175, 6);
            // 
            // menuItem10
            // 
            this.menuItem10.Name = "menuItem10";
            this.menuItem10.Size = new System.Drawing.Size(178, 22);
            this.menuItem10.Text = "What is Tolerance?";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoPathnodeGeneratorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // autoPathnodeGeneratorToolStripMenuItem
            // 
            this.autoPathnodeGeneratorToolStripMenuItem.Name = "autoPathnodeGeneratorToolStripMenuItem";
            this.autoPathnodeGeneratorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.autoPathnodeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.autoPathnodeGeneratorToolStripMenuItem.Text = "Auto Path Node Generation...";
            this.autoPathnodeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.autoPathnodeGeneratorToolStripMenuItem_Click);
            // 
            // tmrPND
            // 
            this.tmrPND.Interval = 1;
            this.tmrPND.Tick += new System.EventHandler(this.tmrPND_Tick);
            // 
            // PathNodeGen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(634, 479);
            this.Controls.Add(this.btnGotoPND);
            this.Controls.Add(this.lstLinks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDelNode);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.NodeOfsY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NodeOfsX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NodeY);
            this.Controls.Add(this.NodeX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstNodes);
            this.Controls.Add(this.btnGeneratePND);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuitPND);
            this.Controls.Add(this.btnNewPND);
            this.Controls.Add(this.btnSavePND);
            this.Controls.Add(this.btnOpenPND);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Menu = this.mnuPathTolerance;
            this.Name = "PathNodeGen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Path Node Editor/Generator";
            this.Load += new System.EventHandler(this.PathNodeGen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOpenPND_Click(object sender, System.EventArgs e)
		{
			if (OpenPND.ShowDialog() == DialogResult.OK)
			{
				PNDHelper.CURRENT_TOP_ID = 0;
				lstNodes.Items.Clear();
				lstLinks.Items.Clear();
				PNDHelper.PathNodes.Clear();
				PNDHelper.PathNodeGoals.Clear();

				BinaryReader br = new BinaryReader(new FileStream(OpenPND.FileName, FileMode.Open));
				uint num_nodes = br.ReadUInt32(); // get the # of nodes
				
				for (int i=0; i<num_nodes; i++)
				{
					// Parse each node
					PNDHelper.PathNode p = new PNDHelper.PathNode();
					p.ID = br.ReadUInt32();
					p.X = br.ReadUInt32();
					p.Y = br.ReadUInt32();
					p.OfsX = br.ReadSingle();
					p.OfsY = br.ReadSingle();

					// Add to the list and to the hashtable
					PNDHelper.PathNodes.Add(p.ID, p);
					lstNodes.Items.Add("ID #"+p.ID.ToString()+": ("+p.X.ToString()+", "+p.Y.ToString()+")");

					// Check if we need to modify the max ID available
					if (p.ID > PNDHelper.CURRENT_TOP_ID)
						PNDHelper.CURRENT_TOP_ID = p.ID;

					uint num_goals = br.ReadUInt32();
					string goals = "";
					for (int j=0; j<num_goals; j++)
					{
						// Process each goal
						goals += br.ReadUInt32().ToString()+"::";
					}
					PNDHelper.PathNodeGoals.Add(p.ID, goals);
				}
				br.Close();
				PNDHelper.CURRENT_TOP_ID++; // increase to set to a new possible value

				PNDHelper.PND_HAS_CHANGED = false;
				PNDHelper.PND_MODE_ACTIVE = true;
				SetInterfaceState(true);
			}
		}

		private void btnSavePND_Click(object sender, System.EventArgs e)
		{
			if (!PNDHelper.PND_MODE_ACTIVE)
			{
				MessageBox.Show("No path nodes to save!","Nothing to do",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			if (PNDHelper.PND_HAS_CHANGED)
			{
				if (MessageBox.Show("Warning: The path nodes have changed since the last time they were saved. It means that certain links may have been invalidated or become unusable. It is recommended that you click the \"Generate\" button before saving the path nodes, otherwise you may experience strange behavior or CTDs in the game. Are you sure you want to save the path node data without generating node links (not recommended)?","Please confirm precarious operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					return;
			}
			
			SavePND.FileName = "pathnode.pnd";																																																																																																																												   
			if (SavePND.ShowDialog() == DialogResult.OK)
			{
				// TODO: save back the path nodes here
				BinaryWriter bw = new BinaryWriter(new FileStream(SavePND.FileName, FileMode.Create));
				bw.Write((uint)PNDHelper.PathNodes.Count); // # of path nodes

				Stack NodeStack = new Stack(PNDHelper.PathNodes.Keys);
				IEnumerator WalkNodes = NodeStack.GetEnumerator();

				while (WalkNodes.MoveNext())
				{
					PNDHelper.PathNode p = (PNDHelper.PathNode)PNDHelper.PathNodes[uint.Parse(WalkNodes.Current.ToString())];
					bw.Write(p.ID);
					bw.Write(p.X);
					bw.Write(p.Y);
					bw.Write(p.OfsX);
					bw.Write(p.OfsY);

					// Write out the number of goals and the list of goals
					// (neighboring destinations)
					string[] goals = str_to_array(PNDHelper.PathNodeGoals[p.ID].ToString());
					bw.Write(goals.GetUpperBound(0));
					foreach(string goal in goals)
					{
						if (goal != "")
							bw.Write(uint.Parse(goal));
					}
				}
				bw.Close();
				MessageBox.Show("Path Node Data Saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void btnNewPND_Click(object sender, System.EventArgs e)
		{
			if (PNDHelper.PND_MODE_ACTIVE)
			{
				if (MessageBox.Show("Are you sure you want to create a new path node data file?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					return;
			}

			PNDHelper.CURRENT_TOP_ID = 0;
			lstNodes.Items.Clear();
			lstLinks.Items.Clear();
			PNDHelper.PathNodes.Clear();
			PNDHelper.PathNodeGoals.Clear();
			PNDHelper.PND_HAS_CHANGED = false;
			PNDHelper.PND_MODE_ACTIVE = true;
			SetInterfaceState(true);
		}

		// Modify the PND generator interface state
		private void SetInterfaceState(bool state)
		{
			btnGeneratePND.Enabled = state;
			btnSavePND.Enabled = state;
			btnAddNode.Enabled = state;
			btnDelNode.Enabled = state;
			btnGotoPND.Enabled = state;
			NodeX.Enabled = state;
			NodeY.Enabled = state;
			NodeOfsX.Enabled = state;
			NodeOfsY.Enabled = state;
		}

		// Get an ID number of a path node from the string tag in the node list
		private uint GetID(string id_tag)
		{
			return uint.Parse(id_tag.Split('#')[1].Split(':')[0]);
		}

		// Split the goals into individual strings
		public static string[] str_to_array(string data)
		{
			string[] arr = null;

			try 
			{
				arr = Regex.Split(data, "::");
			} 
			catch (ArgumentException){}

			return arr;
		}

		private void lstNodes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstNodes.SelectedIndex == -1)
				return;

			uint ID = GetID(lstNodes.Items[lstNodes.SelectedIndex].ToString());
			PNDHelper.PathNode p = (PNDHelper.PathNode)PNDHelper.PathNodes[ID];
			NodeX.Text = p.X.ToString();
			NodeY.Text = p.Y.ToString();
			NodeOfsX.Text = p.OfsX.ToString();
			NodeOfsY.Text = p.OfsY.ToString();

			lstLinks.Items.Clear();
			string[] goals = str_to_array(PNDHelper.PathNodeGoals[ID].ToString());
			foreach(string goal in goals)
			{
				if (goal.Trim() != "")
				{
					try
					{
						PNDHelper.PathNode dest = (PNDHelper.PathNode)PNDHelper.PathNodes[uint.Parse(goal)];
						lstLinks.Items.Add("ID #"+dest.ID.ToString()+": ("+dest.X.ToString()+", "+dest.Y.ToString()+")");
					}
					catch (Exception)
					{
						// Invalidated link
						MessageBox.Show("One of the links to this node has been invalidated (possibly deleted). You must click \"Generate\" to generate the path node links again.","Invalid link found",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						lstLinks.Items.Add("ID #??: UNRESOLVED, PLEASE CLICK \"GENERATE\"");
					}
				}
			}
		}

		private void btnGotoPND_Click(object sender, System.EventArgs e)
		{
			if (lstLinks.SelectedIndex == -1)
				return;

			if (lstLinks.Items[lstLinks.SelectedIndex].ToString() == "ID #??: UNRESOLVED, PLEASE CLICK \"GENERATE\"")
			{
				MessageBox.Show("This link cannot be resolved (its destination was possibly removed). Please click the \"Generate\" button to generate the path node links.","Unresolved Link",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			lstNodes.SelectedIndex = lstNodes.Items.IndexOf(lstLinks.Items[lstLinks.SelectedIndex].ToString());
			lstNodes.Focus();
		}

		private void btnDelNode_Click(object sender, System.EventArgs e)
		{
			// Deleting a path node must update the PND_HAS_CHANGED flag
			if (lstNodes.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this node?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
				return;

			lstLinks.Items.Clear();
			PNDHelper.PND_HAS_CHANGED = true;
			uint ID = GetID(lstNodes.Items[lstNodes.SelectedIndex].ToString());
			PNDHelper.PathNodes.Remove(ID);
			PNDHelper.PathNodeGoals.Remove(ID);
			lstNodes.Items.RemoveAt(lstNodes.SelectedIndex);
		}

		private void btnAddNode_Click(object sender, System.EventArgs e)
		{
			// Adding a path node must update the PND_HAS_CHANGED flag
			IEnumerator PathKey = PNDHelper.PathNodes.Keys.GetEnumerator();
			while(PathKey.MoveNext())
			{
				PNDHelper.PathNode p = (PNDHelper.PathNode)PNDHelper.PathNodes[uint.Parse(PathKey.Current.ToString())];
				if (p.X == uint.Parse(NodeX.Text) && p.Y == uint.Parse(NodeY.Text))
				{
					MessageBox.Show("Error: A path node with the given (X,Y) coordinates already exists! [#"+p.ID.ToString()+"]","A Node Already Exists",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
			}

			PNDHelper.PND_HAS_CHANGED = true;
			PNDHelper.PathNode p1 = new PNDHelper.PathNode();
			p1.ID = PNDHelper.CURRENT_TOP_ID;
			p1.X = uint.Parse(NodeX.Text);
			p1.Y = uint.Parse(NodeY.Text);
			try
			{
				p1.OfsX = float.Parse(NodeOfsX.Text);
			}
			catch(Exception)
			{
				MessageBox.Show("Offset X didn't have a valid floating point value. It was reset to 0","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				p1.OfsX = 0;
			}
			try
			{
				p1.OfsY = float.Parse(NodeOfsY.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("Offset Y didn't have a valid floating point value. It was reset to 0","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				p1.OfsY = 0;
			}
			PNDHelper.PathNodes.Add(p1.ID, p1);
			PNDHelper.PathNodeGoals.Add(p1.ID, ""); // empty set of links
			lstNodes.Items.Add("ID #"+p1.ID.ToString()+": ("+p1.X.ToString()+", "+p1.Y.ToString()+")");
			lstNodes.SelectedIndex = lstNodes.Items.Count-1;
			PNDHelper.CURRENT_TOP_ID++;
		}

		private void btnGeneratePND_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("NOTE: Using the 'Generate' button will create all possible path links between the nodes. This will allow the game engine to move the characters along the given paths. It is a required step to do after a path node is added, removed, or modified in any way. Generating path node links may take some time to complete. Do you want to generate path node links now?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;

			PNDHelper.PathNodeGoals.Clear(); // clear the old list

			Stack NodeStack = new Stack(PNDHelper.PathNodes.Keys);
			IEnumerator p = NodeStack.GetEnumerator();
			Stack NodeStackDest = new Stack(PNDHelper.PathNodes.Keys);
			IEnumerator destination = NodeStackDest.GetEnumerator();

			PNDHelper.PathNode pd_Source = new PNDHelper.PathNode();
			PNDHelper.PathNode pd_Dest = new PNDHelper.PathNode();
			string goal_list = "";

			while(p.MoveNext()) /* first walkover: source nodes */
			{
				pd_Source = (PNDHelper.PathNode)PNDHelper.PathNodes[uint.Parse(p.Current.ToString())];
				goal_list = "";

				while(destination.MoveNext()) /* second walkover: destinations */
				{
					pd_Dest = (PNDHelper.PathNode)PNDHelper.PathNodes[uint.Parse(destination.Current.ToString())];
					if (pd_Source.ID != pd_Dest.ID) /* can't back-link to itself */
					{
						if (PNDHelper.IsNeighboring(PNDHelper.GetPathLength(pd_Source.X, pd_Source.Y, pd_Dest.X, pd_Dest.Y)))
							goal_list += pd_Dest.ID.ToString()+"::";
					}
				}
				destination.Reset();
				PNDHelper.PathNodeGoals.Add(pd_Source.ID, goal_list);
			}

			PNDHelper.PND_HAS_CHANGED = false;
			MessageBox.Show("Node links generated.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

        private void experimentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PNDHelper.MAX_PATH_LENGTH = 7.0F;
            experimentalToolStripMenuItem.Checked = true;
            menuItem2.Checked = false;
            menuItem3.Checked = false;
            menuItem4.Checked = false;
            menuItem5.Checked = false;
            menuItem6.Checked = false;
            menuItem7.Checked = false;
            menuItem8.Checked = false;
        }

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
            experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 19.0F;
		    menuItem2.Checked = true;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
            experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 20.0F;
            menuItem2.Checked = false;
			menuItem3.Checked = true;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
            experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 21.0F;
            menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = true;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;		
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
            experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 22.0F;
            menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = true;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = false;				
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
            experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 23.0F;
            menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = true;
			menuItem7.Checked = false;
			menuItem8.Checked = false;						
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
            experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 24.0F;
            menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = true;
			menuItem8.Checked = false;				
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
            experimentalToolStripMenuItem.Checked = false;
			PNDHelper.MAX_PATH_LENGTH = 25.0F;
			menuItem2.Checked = false;
			menuItem3.Checked = false;
			menuItem4.Checked = false;
			menuItem5.Checked = false;
			menuItem6.Checked = false;
			menuItem7.Checked = false;
			menuItem8.Checked = true;				
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Tolerance defines the maximum distance between two path nodes for a link to be generated. The bigger this value is, the more links will be generated between neighboring nodes in a wider radius. Technically speaking, setting the lower value of 'Tolerance' will result in very few links being generated because of the strict requirement for a distance between path nodes (19-21 tiles). The default value (22 tiles) assumes the standard distance between path nodes in ToEE (20 tiles) and takes extra 2 tile radius into consideration to generate a few alternative links, if possible. Bigger values (23-25) will result in many overlapping links and may technically cause 'dead links' to appear (links that exist but that can't be parsed by the game because they are very far away from each other, e.g. 23-25 tiles away).\n\nNormally there is no need to modify the default tolerance value (22). However, if you feel that the pathfinding on your map is somewhat weird but you are confident that you are doing everything alright, you can try setting more rigid or lax values of the tolerance and see if that helps.","About Tolerance Option...",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

        private void autoPathnodeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathNodeAutoGen pWnd = new PathNodeAutoGen();
            if (pWnd.ShowDialog() == DialogResult.OK)
            {
                if (pWnd.r_Step == -1)
                    return;

                // New PND file
                PNDHelper.CURRENT_TOP_ID = 0;
                lstNodes.Items.Clear();
                lstLinks.Items.Clear();
                PNDHelper.PathNodes.Clear();
                PNDHelper.PathNodeGoals.Clear();
                PNDHelper.PND_HAS_CHANGED = false;
                PNDHelper.PND_MODE_ACTIVE = true;
                SetInterfaceState(true);

                int blocked_so_far = 0;
                int pnd_on_subgrid = 0;
                bool exists = false;

                // Generate automated path nodes
                for (int x = pWnd.r_FX; x <= pWnd.r_TX; x += pWnd.r_Step)
                    for (int y = pWnd.r_FY; y <= pWnd.r_TY; y += pWnd.r_Step)
                    {
                        bool blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, x, y);

                        if (exists && !blocked)
                        {
                            NodeX.Text = x.ToString();
                            NodeY.Text = y.ToString();
                            NodeOfsX.Text = "0";
                            NodeOfsY.Text = "0";
                            btnAddNode_Click(sender, e);
                        }
                        else
                        {
                            // the tile is blocked, so try laying pathnodes around the smaller grid
                            int new_x = 0, new_y = 0;
                            bool fr = false;

                            new_x = x + 3;
                            new_y = y;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                fr = true;
                                pnd_on_subgrid++;
                            }

                            new_x = x;
                            new_y = y + 3;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                pnd_on_subgrid++;
                                fr = true;
                            }

                            new_x = x;
                            new_y = y - 3;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                pnd_on_subgrid++;
                                fr = true;
                            }

                            new_x = x - 3;
                            new_y = y;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                pnd_on_subgrid++;
                                fr = true;
                            }

                            new_x = x + 3;
                            new_y = y + 3;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                pnd_on_subgrid++;
                                fr = true;
                            }

                            new_x = x - 3;
                            new_y = y - 3;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                pnd_on_subgrid++;
                                fr = true;
                            }

                            new_x = x + 3;
                            new_y = y - 3;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                pnd_on_subgrid++;
                                fr = true;
                            }

                            new_x = x - 3;
                            new_y = y + 3;
                            blocked = GetBlockedXY(ref blocked_so_far, ref pnd_on_subgrid, ref exists, new_x, new_y);
                            if (exists && !blocked && !fr)
                            {
                                NodeX.Text = new_x.ToString();
                                NodeY.Text = new_y.ToString();
                                NodeOfsX.Text = "0";
                                NodeOfsY.Text = "0";
                                btnAddNode_Click(sender, e);
                                pnd_on_subgrid++;
                                fr = true;
                            }
                        }
                    }
                MessageBox.Show("Automated generation complete.\n\nBlocked tiles ignored: " + blocked_so_far.ToString()+"\nNodes laid on subgrid: " + pnd_on_subgrid.ToString());
            }

        }

        private static bool GetBlockedXY(ref int blocked_so_far, ref int pnd_on_subgrid, ref bool exists, int x, int y)
        {
            string sector = Helper.SEC_GetSectorCorrespondence(x, y).ToString();
            string sectfile = Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors\\" + sector + ".sec";
            int max_x = 0;
            int max_y = 0;
            int min_x = 0;
            int min_y = 0;
            bool blocked = false;

            // check if this sector tile is taken first
            if (File.Exists(sectfile))
            {
                exists = true;
                BinaryReader r_sec = new BinaryReader(new FileStream(sectfile, FileMode.Open));
                Helper.Sec_GetMinMax(sector, ref min_y, ref max_y, ref min_x, ref max_x);

                int int_x = x - min_x;
                int int_y = y - min_y;
                int skipdist = (int_y * 64 + int_x) * 16;

                uint num_lights = r_sec.ReadUInt32();
                for (int i = 0; i < num_lights; i++)
                    LightEditorEx.LoadLightFromSEC(r_sec);

                r_sec.BaseStream.Seek(skipdist, SeekOrigin.Current);

                if (r_sec.ReadUInt64() > 32)
                {
                    blocked = true;
                    blocked_so_far++;
                }
                else
                {
                    blocked = false;
                }

                r_sec.Close();
            }
            else
            {
                exists = false;
            }
            return blocked;
        }

        private void tmrPND_Tick(object sender, EventArgs e)
        {
            // v2.0.0: Interoperability with ToEE console support
            if (File.Exists(Helper.InteropPath))
            {
                string wbl_data = "";
                bool DATA_PASS_ON = false;
                try
                {
                    StreamReader sr = new StreamReader(Helper.InteropPath);
                    wbl_data = sr.ReadLine();
                    sr.Close();
                }
                catch (Exception) { }
                if (wbl_data != "")
                {
                    string[] wbl_data_arr = wbl_data.Split(' ');
                    wbl_data = "";
                    switch (wbl_data_arr[0])
                    {
                        case "PNDLOC": // location -> created path node
                            if (btnAddNode.Enabled)
                            {
                                File.Delete(Helper.InteropPath);
                                NodeX.Text = wbl_data_arr[1];
                                NodeY.Text = wbl_data_arr[2];
                                btnAddNode_Click(null, null);
                                return;
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create a path node file first! (e.g. click 'New' or 'Open')", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            //break;
                        default:
                            DATA_PASS_ON = true;
                            break;
                    }

                    if (!DATA_PASS_ON)
                        File.Delete(Helper.InteropPath);
                }
            }
        }

        private void PathNodeGen_Load(object sender, EventArgs e)
        {
            tmrPND.Enabled = true;
        }
    }
}
