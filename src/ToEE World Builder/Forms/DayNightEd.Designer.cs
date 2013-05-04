namespace WorldBuilder
{
    partial class DayNightEd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayNightEd));
            this.label1 = new System.Windows.Forms.Label();
            this.lstMOBs = new System.Windows.Forms.ListBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DayOfsY = new System.Windows.Forms.TextBox();
            this.DayOfsX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DayMap = new System.Windows.Forms.TextBox();
            this.DayY = new System.Windows.Forms.TextBox();
            this.DayX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.NightOfsY = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.NightOfsX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NightMap = new System.Windows.Forms.TextBox();
            this.NightX = new System.Windows.Forms.TextBox();
            this.NightY = new System.Windows.Forms.TextBox();
            this.btnAddNXD = new System.Windows.Forms.Button();
            this.btnUpdateNXD = new System.Windows.Forms.Button();
            this.btnDeleteNXD = new System.Windows.Forms.Button();
            this.btnOpenNXD = new System.Windows.Forms.Button();
            this.btnSaveNXD = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.DefMap = new System.Windows.Forms.TextBox();
            this.tmrDNE = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lstMOBs
            // 
            this.lstMOBs.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMOBs.FormattingEnabled = true;
            this.lstMOBs.ItemHeight = 16;
            this.lstMOBs.Location = new System.Drawing.Point(15, 63);
            this.lstMOBs.Name = "lstMOBs";
            this.lstMOBs.Size = new System.Drawing.Size(354, 388);
            this.lstMOBs.TabIndex = 1;
            this.lstMOBs.SelectedIndexChanged += new System.EventHandler(this.lstMOBs_SelectedIndexChanged);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(340, 463);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DayOfsY);
            this.groupBox1.Controls.Add(this.DayOfsX);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.DayMap);
            this.groupBox1.Controls.Add(this.DayY);
            this.groupBox1.Controls.Add(this.DayX);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(376, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Day Parameters";
            // 
            // DayOfsY
            // 
            this.DayOfsY.Enabled = false;
            this.DayOfsY.Location = new System.Drawing.Point(136, 57);
            this.DayOfsY.Name = "DayOfsY";
            this.DayOfsY.Size = new System.Drawing.Size(58, 20);
            this.DayOfsY.TabIndex = 10;
            this.DayOfsY.Text = "0";
            // 
            // DayOfsX
            // 
            this.DayOfsX.Enabled = false;
            this.DayOfsX.Location = new System.Drawing.Point(136, 35);
            this.DayOfsX.Name = "DayOfsX";
            this.DayOfsX.Size = new System.Drawing.Size(58, 20);
            this.DayOfsX.TabIndex = 6;
            this.DayOfsX.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(104, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "(per MapList.mes)";
            // 
            // DayMap
            // 
            this.DayMap.Enabled = false;
            this.DayMap.Location = new System.Drawing.Point(52, 13);
            this.DayMap.Name = "DayMap";
            this.DayMap.Size = new System.Drawing.Size(50, 20);
            this.DayMap.TabIndex = 1;
            this.DayMap.Text = "0";
            // 
            // DayY
            // 
            this.DayY.Enabled = false;
            this.DayY.Location = new System.Drawing.Point(29, 57);
            this.DayY.Name = "DayY";
            this.DayY.Size = new System.Drawing.Size(40, 20);
            this.DayY.TabIndex = 8;
            this.DayY.Text = "0";
            // 
            // DayX
            // 
            this.DayX.Enabled = false;
            this.DayX.Location = new System.Drawing.Point(29, 35);
            this.DayX.Name = "DayX";
            this.DayX.Size = new System.Drawing.Size(40, 20);
            this.DayX.TabIndex = 4;
            this.DayX.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Y Offset:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "X Offset:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Map ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.NightOfsY);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.NightOfsX);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.NightMap);
            this.groupBox2.Controls.Add(this.NightX);
            this.groupBox2.Controls.Add(this.NightY);
            this.groupBox2.Location = new System.Drawing.Point(376, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Night Parameters";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Y:";
            // 
            // NightOfsY
            // 
            this.NightOfsY.Enabled = false;
            this.NightOfsY.Location = new System.Drawing.Point(136, 57);
            this.NightOfsY.Name = "NightOfsY";
            this.NightOfsY.Size = new System.Drawing.Size(58, 20);
            this.NightOfsY.TabIndex = 10;
            this.NightOfsY.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "X:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Map ID:";
            // 
            // NightOfsX
            // 
            this.NightOfsX.Enabled = false;
            this.NightOfsX.Location = new System.Drawing.Point(136, 35);
            this.NightOfsX.Name = "NightOfsX";
            this.NightOfsX.Size = new System.Drawing.Size(58, 20);
            this.NightOfsX.TabIndex = 6;
            this.NightOfsX.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(82, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "X Offset:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "(per MapList.mes)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(82, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Y Offset:";
            // 
            // NightMap
            // 
            this.NightMap.Enabled = false;
            this.NightMap.Location = new System.Drawing.Point(52, 13);
            this.NightMap.Name = "NightMap";
            this.NightMap.Size = new System.Drawing.Size(50, 20);
            this.NightMap.TabIndex = 1;
            this.NightMap.Text = "0";
            // 
            // NightX
            // 
            this.NightX.Enabled = false;
            this.NightX.Location = new System.Drawing.Point(29, 35);
            this.NightX.Name = "NightX";
            this.NightX.Size = new System.Drawing.Size(40, 20);
            this.NightX.TabIndex = 4;
            this.NightX.Text = "0";
            // 
            // NightY
            // 
            this.NightY.Enabled = false;
            this.NightY.Location = new System.Drawing.Point(29, 57);
            this.NightY.Name = "NightY";
            this.NightY.Size = new System.Drawing.Size(40, 20);
            this.NightY.TabIndex = 8;
            this.NightY.Text = "0";
            // 
            // btnAddNXD
            // 
            this.btnAddNXD.Enabled = false;
            this.btnAddNXD.Location = new System.Drawing.Point(378, 299);
            this.btnAddNXD.Name = "btnAddNXD";
            this.btnAddNXD.Size = new System.Drawing.Size(58, 23);
            this.btnAddNXD.TabIndex = 6;
            this.btnAddNXD.Text = "Add";
            this.btnAddNXD.UseVisualStyleBackColor = true;
            this.btnAddNXD.Click += new System.EventHandler(this.btnAddNXD_Click);
            // 
            // btnUpdateNXD
            // 
            this.btnUpdateNXD.Enabled = false;
            this.btnUpdateNXD.Location = new System.Drawing.Point(448, 299);
            this.btnUpdateNXD.Name = "btnUpdateNXD";
            this.btnUpdateNXD.Size = new System.Drawing.Size(58, 23);
            this.btnUpdateNXD.TabIndex = 7;
            this.btnUpdateNXD.Text = "Update";
            this.btnUpdateNXD.UseVisualStyleBackColor = true;
            this.btnUpdateNXD.Click += new System.EventHandler(this.btnUpdateNXD_Click);
            // 
            // btnDeleteNXD
            // 
            this.btnDeleteNXD.Enabled = false;
            this.btnDeleteNXD.Location = new System.Drawing.Point(518, 299);
            this.btnDeleteNXD.Name = "btnDeleteNXD";
            this.btnDeleteNXD.Size = new System.Drawing.Size(58, 23);
            this.btnDeleteNXD.TabIndex = 8;
            this.btnDeleteNXD.Text = "Delete";
            this.btnDeleteNXD.UseVisualStyleBackColor = true;
            this.btnDeleteNXD.Click += new System.EventHandler(this.btnDeleteNXD_Click);
            // 
            // btnOpenNXD
            // 
            this.btnOpenNXD.Location = new System.Drawing.Point(174, 463);
            this.btnOpenNXD.Name = "btnOpenNXD";
            this.btnOpenNXD.Size = new System.Drawing.Size(75, 23);
            this.btnOpenNXD.TabIndex = 9;
            this.btnOpenNXD.Text = "Open...";
            this.btnOpenNXD.UseVisualStyleBackColor = true;
            this.btnOpenNXD.Click += new System.EventHandler(this.btnOpenNXD_Click);
            // 
            // btnSaveNXD
            // 
            this.btnSaveNXD.Enabled = false;
            this.btnSaveNXD.Location = new System.Drawing.Point(257, 463);
            this.btnSaveNXD.Name = "btnSaveNXD";
            this.btnSaveNXD.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNXD.TabIndex = 10;
            this.btnSaveNXD.Text = "Save";
            this.btnSaveNXD.UseVisualStyleBackColor = true;
            this.btnSaveNXD.Click += new System.EventHandler(this.btnSaveNXD_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Day/Night Transitions (DAYNIGHT.NXD)|daynight.nxd";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(375, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Current (Default) Map ID:";
            // 
            // DefMap
            // 
            this.DefMap.Enabled = false;
            this.DefMap.Location = new System.Drawing.Point(506, 60);
            this.DefMap.Name = "DefMap";
            this.DefMap.Size = new System.Drawing.Size(50, 20);
            this.DefMap.TabIndex = 3;
            this.DefMap.Text = "0";
            // 
            // tmrDNE
            // 
            this.tmrDNE.Interval = 1;
            this.tmrDNE.Tick += new System.EventHandler(this.tmrDNE_Tick);
            // 
            // DayNightEd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 494);
            this.Controls.Add(this.DefMap);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnSaveNXD);
            this.Controls.Add(this.btnOpenNXD);
            this.Controls.Add(this.btnDeleteNXD);
            this.Controls.Add(this.btnUpdateNXD);
            this.Controls.Add(this.btnAddNXD);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lstMOBs);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DayNightEd";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Day/Night Transitions Editor";
            this.Load += new System.EventHandler(this.DayNightEd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMOBs;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddNXD;
        private System.Windows.Forms.Button btnUpdateNXD;
        private System.Windows.Forms.Button btnDeleteNXD;
        private System.Windows.Forms.Button btnOpenNXD;
        private System.Windows.Forms.Button btnSaveNXD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DayMap;
        private System.Windows.Forms.TextBox DayY;
        private System.Windows.Forms.TextBox DayX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox DayOfsY;
        private System.Windows.Forms.TextBox DayOfsX;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox NightOfsY;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox NightOfsX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NightMap;
        private System.Windows.Forms.TextBox NightX;
        private System.Windows.Forms.TextBox NightY;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox DefMap;
        private System.Windows.Forms.Timer tmrDNE;
    }
}