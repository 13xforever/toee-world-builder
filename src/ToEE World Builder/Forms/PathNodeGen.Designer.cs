using System.Windows.Forms;

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
			this.menuItem2a.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem3a
			// 
			this.menuItem3a.Index = 1;
			this.menuItem3a.Text = "20";
			this.menuItem3a.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem4a
			// 
			this.menuItem4a.Index = 2;
			this.menuItem4a.Text = "21";
			this.menuItem4a.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem5a
			// 
			this.menuItem5a.Checked = true;
			this.menuItem5a.Index = 3;
			this.menuItem5a.Text = "22 (Default/Recommended)";
			this.menuItem5a.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem6a
			// 
			this.menuItem6a.Index = 4;
			this.menuItem6a.Text = "23";
			this.menuItem6a.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem7a
			// 
			this.menuItem7a.Index = 5;
			this.menuItem7a.Text = "24";
			this.menuItem7a.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem8a
			// 
			this.menuItem8a.Index = 6;
			this.menuItem8a.Text = "25 (Lax)";
			this.menuItem8a.Click += new System.EventHandler(this.OnChangeToleranceClick);
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
			this.menuItem10a.Click += new System.EventHandler(this.OnToleranceHelpClick);
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
			this.NET2Menu.Size = new System.Drawing.Size(71, 20);
			this.NET2Menu.Text = "Tolerance";
			// 
			// experimentalToolStripMenuItem
			// 
			this.experimentalToolStripMenuItem.Name = "experimentalToolStripMenuItem";
			this.experimentalToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.experimentalToolStripMenuItem.Text = "7 (Experimental)";
			this.experimentalToolStripMenuItem.Visible = false;
			this.experimentalToolStripMenuItem.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem2
			// 
			this.menuItem2.Name = "menuItem2";
			this.menuItem2.Size = new System.Drawing.Size(178, 22);
			this.menuItem2.Text = "19 (Rigid)";
			this.menuItem2.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem3
			// 
			this.menuItem3.Name = "menuItem3";
			this.menuItem3.Size = new System.Drawing.Size(178, 22);
			this.menuItem3.Text = "20";
			this.menuItem3.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem4
			// 
			this.menuItem4.Name = "menuItem4";
			this.menuItem4.Size = new System.Drawing.Size(178, 22);
			this.menuItem4.Text = "21";
			this.menuItem4.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem5
			// 
			this.menuItem5.Checked = true;
			this.menuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItem5.Name = "menuItem5";
			this.menuItem5.Size = new System.Drawing.Size(178, 22);
			this.menuItem5.Text = "22 (Recommended)";
			this.menuItem5.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem6
			// 
			this.menuItem6.Name = "menuItem6";
			this.menuItem6.Size = new System.Drawing.Size(178, 22);
			this.menuItem6.Text = "23";
			this.menuItem6.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem7
			// 
			this.menuItem7.Name = "menuItem7";
			this.menuItem7.Size = new System.Drawing.Size(178, 22);
			this.menuItem7.Text = "24";
			this.menuItem7.Click += new System.EventHandler(this.OnChangeToleranceClick);
			// 
			// menuItem8
			// 
			this.menuItem8.Name = "menuItem8";
			this.menuItem8.Size = new System.Drawing.Size(178, 22);
			this.menuItem8.Text = "25 (Lax)";
			this.menuItem8.Click += new System.EventHandler(this.OnChangeToleranceClick);
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
	}
}
