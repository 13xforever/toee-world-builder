﻿using System.Windows.Forms;

namespace WorldBuilder.Forms
{
	public partial class PathNodeGen
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.NET2Menu = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.toleranceMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItem10 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoPathnodeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
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
			this.btnOpenPND.Click += new System.EventHandler(this.OnOpenPndFileClick);
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
			this.btnSavePND.Click += new System.EventHandler(this.OnSavePndFileClick);
			// 
			// btnNewPND
			// 
			this.btnNewPND.Location = new System.Drawing.Point(120, 472);
			this.btnNewPND.Name = "btnNewPND";
			this.btnNewPND.Size = new System.Drawing.Size(75, 23);
			this.btnNewPND.TabIndex = 2;
			this.btnNewPND.Text = "New";
			this.btnNewPND.Click += new System.EventHandler(this.OnNewPndFileClick);
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
			this.btnGeneratePND.Click += new System.EventHandler(this.OnRegenerateLinksClick);
			// 
			// lstNodes
			// 
			this.lstNodes.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lstNodes.ItemHeight = 16;
			this.lstNodes.Location = new System.Drawing.Point(8, 40);
			this.lstNodes.Name = "lstNodes";
			this.lstNodes.Size = new System.Drawing.Size(304, 372);
			this.lstNodes.TabIndex = 6;
			this.lstNodes.SelectedIndexChanged += new System.EventHandler(this.OnSelectedNodeChanged);
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
			this.btnAddNode.Click += new System.EventHandler(this.OnAddNodeClick);
			// 
			// btnDelNode
			// 
			this.btnDelNode.Enabled = false;
			this.btnDelNode.Location = new System.Drawing.Point(160, 440);
			this.btnDelNode.Name = "btnDelNode";
			this.btnDelNode.Size = new System.Drawing.Size(75, 23);
			this.btnDelNode.TabIndex = 18;
			this.btnDelNode.Text = "Delete Node";
			this.btnDelNode.Click += new System.EventHandler(this.OnDeleteNodeClick);
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
			this.btnGotoPND.Click += new System.EventHandler(this.OnJumpToNodeClick);
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
            this.toleranceMenuItem1,
            this.toleranceMenuItem2,
            this.toleranceMenuItem3,
            this.toleranceMenuItem4,
            this.toleranceMenuItem5,
            this.toleranceMenuItem6,
            this.toleranceMenuItem7,
            this.toleranceMenuItem8,
            this.toolStripMenuItem1,
            this.menuItem10});
			this.NET2Menu.Name = "NET2Menu";
			this.NET2Menu.Size = new System.Drawing.Size(71, 20);
			this.NET2Menu.Text = "Tolerance";
			// 
			// toleranceMenuItem1
			// 
			this.toleranceMenuItem1.Name = "toleranceMenuItem1";
			this.toleranceMenuItem1.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem1.Text = "7 (Experimental)";
			this.toleranceMenuItem1.Visible = false;
			this.toleranceMenuItem1.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// toleranceMenuItem2
			// 
			this.toleranceMenuItem2.Name = "toleranceMenuItem2";
			this.toleranceMenuItem2.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem2.Text = "19 (Rigid)";
			this.toleranceMenuItem2.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// toleranceMenuItem3
			// 
			this.toleranceMenuItem3.Name = "toleranceMenuItem3";
			this.toleranceMenuItem3.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem3.Text = "20";
			this.toleranceMenuItem3.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// toleranceMenuItem4
			// 
			this.toleranceMenuItem4.Name = "toleranceMenuItem4";
			this.toleranceMenuItem4.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem4.Text = "21";
			this.toleranceMenuItem4.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// toleranceMenuItem5
			// 
			this.toleranceMenuItem5.Checked = true;
			this.toleranceMenuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toleranceMenuItem5.Name = "toleranceMenuItem5";
			this.toleranceMenuItem5.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem5.Text = "22 (Recommended)";
			this.toleranceMenuItem5.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// toleranceMenuItem6
			// 
			this.toleranceMenuItem6.Name = "toleranceMenuItem6";
			this.toleranceMenuItem6.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem6.Text = "23";
			this.toleranceMenuItem6.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// toleranceMenuItem7
			// 
			this.toleranceMenuItem7.Name = "toleranceMenuItem7";
			this.toleranceMenuItem7.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem7.Text = "24";
			this.toleranceMenuItem7.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// toleranceMenuItem8
			// 
			this.toleranceMenuItem8.Name = "toleranceMenuItem8";
			this.toleranceMenuItem8.Size = new System.Drawing.Size(178, 22);
			this.toleranceMenuItem8.Text = "25 (Lax)";
			this.toleranceMenuItem8.Click += new System.EventHandler(this.OnChangeToleranceClick);
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
			this.menuItem10.Click += new System.EventHandler(this.OnToleranceHelpClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoPathnodeGeneratorToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// autoPathnodeGeneratorToolStripMenuItem
			// 
			this.autoPathnodeGeneratorToolStripMenuItem.Name = "autoPathnodeGeneratorToolStripMenuItem";
			this.autoPathnodeGeneratorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.autoPathnodeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
			this.autoPathnodeGeneratorToolStripMenuItem.Text = "Auto Path Node Generation...";
			this.autoPathnodeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.OnAutogeneratePathClick);
			// 
			// timer
			// 
			this.timer.Interval = 1;
			this.timer.Tick += new System.EventHandler(this.OnTimerTick);
			// 
			// PathNodeGen
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(634, 506);
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
			this.Name = "PathNodeGen";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Path Node Editor/Generator";
			this.Load += new System.EventHandler(this.OnLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.Button btnOpenPND;
		private System.Windows.Forms.OpenFileDialog OpenPND;
		private System.Windows.Forms.SaveFileDialog SavePND;
		private System.Windows.Forms.Button btnSavePND;
		private System.Windows.Forms.Button btnNewPND;
		private System.Windows.Forms.Button btnQuitPND;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGeneratePND;
		private System.Windows.Forms.ListBox lstNodes;
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
		private MenuStrip menuStrip1;
		private ToolStripMenuItem NET2Menu;
		private ToolStripMenuItem toleranceMenuItem2;
		private ToolStripMenuItem toleranceMenuItem3;
		private ToolStripMenuItem toleranceMenuItem4;
		private ToolStripMenuItem toleranceMenuItem5;
		private ToolStripMenuItem toleranceMenuItem6;
		private ToolStripMenuItem toleranceMenuItem7;
		private ToolStripMenuItem toleranceMenuItem8;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripMenuItem menuItem10;
		private ToolStripMenuItem toolsToolStripMenuItem;
		private ToolStripMenuItem autoPathnodeGeneratorToolStripMenuItem;
		private Timer timer;
		private ToolStripMenuItem toleranceMenuItem1;
	}
}
