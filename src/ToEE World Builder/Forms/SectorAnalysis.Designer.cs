using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WorldBuilder
{
	public partial class SectorAnalysis
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SectorAnalysis));
			this.viewport = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CurPosXY = new System.Windows.Forms.Label();
			this.btnRefreshSAViewPort = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.chkPaintMode = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label14 = new System.Windows.Forms.Label();
			this.chkRememberForObject = new System.Windows.Forms.RadioButton();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.btnQuick1 = new System.Windows.Forms.Button();
			this.btnQuick2 = new System.Windows.Forms.Button();
			this.btnQuick3 = new System.Windows.Forms.Button();
			this.btnQuick4 = new System.Windows.Forms.Button();
			this.btnTotalRefreshSA = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.btnAddExtend = new System.Windows.Forms.Button();
			this.label26 = new System.Windows.Forms.Label();
			this.btnAddEnd = new System.Windows.Forms.Button();
			this.btnAddBase = new System.Windows.Forms.Button();
			this.btnAddArchway = new System.Windows.Forms.Button();
			this.btnCancelSVB = new System.Windows.Forms.Button();
			this.label27 = new System.Windows.Forms.Label();
			this.cmbTileSound = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.viewport)).BeginInit();
			this.SuspendLayout();
			// 
			// viewport
			// 
			this.viewport.BackColor = System.Drawing.Color.White;
			this.viewport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.viewport.Location = new System.Drawing.Point(8, 16);
			this.viewport.Name = "viewport";
			this.viewport.Size = new System.Drawing.Size(642, 642);
			this.viewport.TabIndex = 0;
			this.viewport.TabStop = false;
			this.viewport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewport_MouseDown);
			this.viewport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.viewport_MouseMove);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Current Cursor Position:";
			// 
			// CurPosXY
			// 
			this.CurPosXY.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.CurPosXY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CurPosXY.Location = new System.Drawing.Point(128, 0);
			this.CurPosXY.Name = "CurPosXY";
			this.CurPosXY.Size = new System.Drawing.Size(128, 16);
			this.CurPosXY.TabIndex = 2;
			this.CurPosXY.Text = "X=0, Y=0";
			// 
			// btnRefreshSAViewPort
			// 
			this.btnRefreshSAViewPort.Location = new System.Drawing.Point(8, 664);
			this.btnRefreshSAViewPort.Name = "btnRefreshSAViewPort";
			this.btnRefreshSAViewPort.Size = new System.Drawing.Size(104, 23);
			this.btnRefreshSAViewPort.TabIndex = 3;
			this.btnRefreshSAViewPort.Text = "Draw / Refresh";
			this.btnRefreshSAViewPort.Click += new System.EventHandler(this.btnRefreshSAViewPort_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(118, 664);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "Legend:";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.RoyalBlue;
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Location = new System.Drawing.Point(172, 666);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(8, 8);
			this.label3.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(188, 664);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "- Impassable";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(282, 664);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(216, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "- Impassable, Can Fly Over (No Shadows)";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.DarkCyan;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.Location = new System.Drawing.Point(266, 666);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(8, 8);
			this.label6.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(544, 664);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(166, 19);
			this.label7.TabIndex = 10;
			this.label7.Text = "- SVB Bits 1 (EXTEND) are set";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Sienna;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.Location = new System.Drawing.Point(528, 666);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(8, 8);
			this.label8.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(188, 682);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(312, 16);
			this.label9.TabIndex = 12;
			this.label9.Text = "- Impassable, Fly Over, Provides Cover";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.LimeGreen;
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label10.Location = new System.Drawing.Point(172, 684);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(8, 8);
			this.label10.TabIndex = 11;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(432, 681);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 16);
			this.label11.TabIndex = 14;
			this.label11.Text = "- Water";
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.PowderBlue;
			this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label12.Location = new System.Drawing.Point(416, 684);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(8, 8);
			this.label12.TabIndex = 13;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(656, 88);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(280, 40);
			this.label13.TabIndex = 16;
			this.label13.Text = "(if Paint Mode is set, clicking on a tile will paint it with the current properti" +
				"es set in the Sector Editor), newly painted tiles will be painted dark gray)";
			// 
			// chkPaintMode
			// 
			this.chkPaintMode.Location = new System.Drawing.Point(656, 64);
			this.chkPaintMode.Name = "chkPaintMode";
			this.chkPaintMode.Size = new System.Drawing.Size(104, 24);
			this.chkPaintMode.TabIndex = 17;
			this.chkPaintMode.Text = "Paint Mode";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(656, 16);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(104, 24);
			this.radioButton1.TabIndex = 18;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Normal Mode";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(656, 40);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(280, 16);
			this.label14.TabIndex = 19;
			this.label14.Text = "(if normal mode is set, you can\'t paint tiles)";
			// 
			// chkRememberForObject
			// 
			this.chkRememberForObject.Location = new System.Drawing.Point(656, 136);
			this.chkRememberForObject.Name = "chkRememberForObject";
			this.chkRememberForObject.Size = new System.Drawing.Size(168, 24);
			this.chkRememberForObject.TabIndex = 21;
			this.chkRememberForObject.Text = "Remember For Object Mode";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(656, 160);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(256, 40);
			this.label15.TabIndex = 20;
			this.label15.Text = "(if Remember for Object mode is set, clicking on a tile will copy the coordinates" +
				" into the Object X and Y coordinates of the Object Editor)";
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label16.Location = new System.Drawing.Point(656, 200);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(256, 23);
			this.label16.TabIndex = 22;
			this.label16.Text = "Quick Paint Options:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnQuick1
			// 
			this.btnQuick1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuick1.Location = new System.Drawing.Point(688, 226);
			this.btnQuick1.Name = "btnQuick1";
			this.btnQuick1.Size = new System.Drawing.Size(200, 23);
			this.btnQuick1.TabIndex = 23;
			this.btnQuick1.Text = "Fully Passable";
			this.btnQuick1.Click += new System.EventHandler(this.btnQuick1_Click);
			// 
			// btnQuick2
			// 
			this.btnQuick2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuick2.Location = new System.Drawing.Point(688, 255);
			this.btnQuick2.Name = "btnQuick2";
			this.btnQuick2.Size = new System.Drawing.Size(200, 23);
			this.btnQuick2.TabIndex = 24;
			this.btnQuick2.Text = "Fully Impassable";
			this.btnQuick2.Click += new System.EventHandler(this.btnQuick2_Click);
			// 
			// btnQuick3
			// 
			this.btnQuick3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuick3.Location = new System.Drawing.Point(688, 284);
			this.btnQuick3.Name = "btnQuick3";
			this.btnQuick3.Size = new System.Drawing.Size(200, 23);
			this.btnQuick3.TabIndex = 25;
			this.btnQuick3.Text = "Fully Impassable (Fly Over)";
			this.btnQuick3.Click += new System.EventHandler(this.btnQuick3_Click);
			// 
			// btnQuick4
			// 
			this.btnQuick4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuick4.Location = new System.Drawing.Point(688, 313);
			this.btnQuick4.Name = "btnQuick4";
			this.btnQuick4.Size = new System.Drawing.Size(200, 23);
			this.btnQuick4.TabIndex = 26;
			this.btnQuick4.Text = "Fully Impassable (Fly Over/Cover)";
			this.btnQuick4.Click += new System.EventHandler(this.btnQuick4_Click);
			// 
			// btnTotalRefreshSA
			// 
			this.btnTotalRefreshSA.Location = new System.Drawing.Point(688, 635);
			this.btnTotalRefreshSA.Name = "btnTotalRefreshSA";
			this.btnTotalRefreshSA.Size = new System.Drawing.Size(200, 23);
			this.btnTotalRefreshSA.TabIndex = 29;
			this.btnTotalRefreshSA.Text = "Total Refresh";
			this.btnTotalRefreshSA.Click += new System.EventHandler(this.btnTotalRefreshSA_Click);
			// 
			// label17
			// 
			this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label17.Location = new System.Drawing.Point(656, 507);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(256, 1);
			this.label17.TabIndex = 30;
			this.label17.Text = "label17";
			// 
			// label18
			// 
			this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label18.Location = new System.Drawing.Point(656, 531);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(256, 104);
			this.label18.TabIndex = 31;
			this.label18.Text = resources.GetString("label18.Text");
			// 
			// label19
			// 
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label19.Location = new System.Drawing.Point(656, 515);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 16);
			this.label19.TabIndex = 32;
			this.label19.Text = "NOTE:";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(542, 682);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(166, 19);
			this.label20.TabIndex = 34;
			this.label20.Text = "- SVB Bits 2 (END) are set";
			// 
			// label21
			// 
			this.label21.BackColor = System.Drawing.Color.DarkGoldenrod;
			this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label21.Location = new System.Drawing.Point(528, 684);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(8, 8);
			this.label21.TabIndex = 33;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(730, 680);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(182, 19);
			this.label22.TabIndex = 36;
			this.label22.Text = "- SVB Bits 4 (ARCHWAY) are set";
			// 
			// label23
			// 
			this.label23.BackColor = System.Drawing.Color.Tomato;
			this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label23.Location = new System.Drawing.Point(716, 682);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(8, 8);
			this.label23.TabIndex = 35;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(732, 661);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(166, 19);
			this.label24.TabIndex = 38;
			this.label24.Text = "- SVB Bits 3 (BASE) are set";
			// 
			// label25
			// 
			this.label25.BackColor = System.Drawing.Color.DarkGray;
			this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label25.Location = new System.Drawing.Point(716, 663);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(8, 8);
			this.label25.TabIndex = 37;
			// 
			// btnAddExtend
			// 
			this.btnAddExtend.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddExtend.Location = new System.Drawing.Point(659, 446);
			this.btnAddExtend.Name = "btnAddExtend";
			this.btnAddExtend.Size = new System.Drawing.Size(79, 23);
			this.btnAddExtend.TabIndex = 39;
			this.btnAddExtend.Text = "+ Extend +";
			this.btnAddExtend.Click += new System.EventHandler(this.btnAddExtend_Click);
			// 
			// label26
			// 
			this.label26.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label26.Location = new System.Drawing.Point(656, 408);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(256, 35);
			this.label26.TabIndex = 40;
			this.label26.Text = "Sector Visibility Blocking (will be painted over existing tile data):";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAddEnd
			// 
			this.btnAddEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddEnd.Location = new System.Drawing.Point(744, 446);
			this.btnAddEnd.Name = "btnAddEnd";
			this.btnAddEnd.Size = new System.Drawing.Size(79, 23);
			this.btnAddEnd.TabIndex = 41;
			this.btnAddEnd.Text = "+ End +";
			this.btnAddEnd.Click += new System.EventHandler(this.btnAddEnd_Click);
			// 
			// btnAddBase
			// 
			this.btnAddBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddBase.Location = new System.Drawing.Point(659, 475);
			this.btnAddBase.Name = "btnAddBase";
			this.btnAddBase.Size = new System.Drawing.Size(79, 23);
			this.btnAddBase.TabIndex = 42;
			this.btnAddBase.Text = "+ Base +";
			this.btnAddBase.Click += new System.EventHandler(this.btnAddBase_Click);
			// 
			// btnAddArchway
			// 
			this.btnAddArchway.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddArchway.Location = new System.Drawing.Point(744, 475);
			this.btnAddArchway.Name = "btnAddArchway";
			this.btnAddArchway.Size = new System.Drawing.Size(79, 23);
			this.btnAddArchway.TabIndex = 43;
			this.btnAddArchway.Text = "+ Archway +";
			this.btnAddArchway.Click += new System.EventHandler(this.btnAddArchway_Click);
			// 
			// btnCancelSVB
			// 
			this.btnCancelSVB.Location = new System.Drawing.Point(829, 446);
			this.btnCancelSVB.Name = "btnCancelSVB";
			this.btnCancelSVB.Size = new System.Drawing.Size(75, 52);
			this.btnCancelSVB.TabIndex = 44;
			this.btnCancelSVB.Text = "Cancel all SVB overlays";
			this.btnCancelSVB.UseVisualStyleBackColor = true;
			this.btnCancelSVB.Click += new System.EventHandler(this.btnCancelSVB_Click);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(656, 353);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(85, 13);
			this.label27.TabIndex = 45;
			this.label27.Text = "Footstep Sound:";
			// 
			// cmbTileSound
			// 
			this.cmbTileSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTileSound.Items.AddRange(new object[] {
            "00 - Reserved (Unused)",
            "01 - Reserved (Unused)",
            "02 - Dirt",
            "03 - Grass",
            "04 - Water",
            "05 - Deep Water (no sound?)",
            "06 - Ice",
            "07 - Fire (no sound?)",
            "08 - Wood",
            "09 - Stone",
            "10 - Metal",
            "11 - Marsh",
            "12 - Unused?",
            "13 - Unused?",
            "14 - Unused?",
            "15 - Unused?"});
			this.cmbTileSound.Location = new System.Drawing.Point(744, 350);
			this.cmbTileSound.Name = "cmbTileSound";
			this.cmbTileSound.Size = new System.Drawing.Size(163, 21);
			this.cmbTileSound.TabIndex = 46;
			// 
			// SectorAnalysis
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(914, 704);
			this.Controls.Add(this.cmbTileSound);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.btnCancelSVB);
			this.Controls.Add(this.btnAddArchway);
			this.Controls.Add(this.btnAddBase);
			this.Controls.Add(this.btnAddEnd);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.btnAddExtend);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.btnTotalRefreshSA);
			this.Controls.Add(this.btnQuick4);
			this.Controls.Add(this.btnQuick3);
			this.Controls.Add(this.btnQuick2);
			this.Controls.Add(this.btnQuick1);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.chkRememberForObject);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.chkPaintMode);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnRefreshSAViewPort);
			this.Controls.Add(this.CurPosXY);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.viewport);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SectorAnalysis";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sector Analyzer / Painter";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.SectorAnalysis_Paint);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.SectorAnalysis_Closing);
			this.Load += new System.EventHandler(this.SectorAnalysis_Load);
			((System.ComponentModel.ISupportInitialize)(this.viewport)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRefreshSAViewPort;
		private System.Windows.Forms.PictureBox viewport;
		private System.Windows.Forms.Label CurPosXY;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.RadioButton chkPaintMode;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.RadioButton chkRememberForObject;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button btnQuick1;
		private System.Windows.Forms.Button btnQuick2;
		private System.Windows.Forms.Button btnQuick3;
		private System.Windows.Forms.Button btnQuick4;
		private System.Windows.Forms.Button btnTotalRefreshSA;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private Label label20;
		private Label label21;
		private Label label22;
		private Label label23;
		private Label label24;
		private Label label25;
		private Button btnAddExtend;
		private Label label26;
		private Button btnAddEnd;
		private Button btnAddBase;
		private Button btnAddArchway;
		private Button btnCancelSVB;
		private Label label27;
		private ComboBox cmbTileSound;
	}
}
