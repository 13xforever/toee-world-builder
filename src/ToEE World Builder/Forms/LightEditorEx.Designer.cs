namespace WorldBuilder
{
    partial class LightEditorEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightEditorEx));
            this.btnOpenSector = new System.Windows.Forms.Button();
            this.CurSector = new System.Windows.Forms.Label();
            this.btnSaveSector = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddLight = new System.Windows.Forms.Button();
            this.btnDeleteLight = new System.Windows.Forms.Button();
            this.btnUpdateLight = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CurLight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.PriLightType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateHash1 = new System.Windows.Forms.Button();
            this.btnSetColor1 = new System.Windows.Forms.Button();
            this.PriPartsysID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.PriPartsysHash = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.PriAngle = new System.Windows.Forms.TextBox();
            this.label00 = new System.Windows.Forms.Label();
            this.PriRange = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.PriDirZ = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.PriDirY = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.PriDirX = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.PriHeight = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PriOfsY = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PriOfsX = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PriY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PriX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PriBlue = new System.Windows.Forms.TextBox();
            this.PriGreen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PriRed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreateHash2 = new System.Windows.Forms.Button();
            this.btnSetColor2 = new System.Windows.Forms.Button();
            this.SecPartsysID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.SecPartsysHash = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.SecAngle = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.SecRange = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.SecDirZ = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.SecDirY = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.SecDirX = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SecBlue = new System.Windows.Forms.TextBox();
            this.SecGreen = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.SecRed = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.SecLightType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.FlagAnimated = new System.Windows.Forms.CheckBox();
            this.FlagViewControls = new System.Windows.Forms.CheckBox();
            this.FlagUsePrimaryLight = new System.Windows.Forms.CheckBox();
            this.FlagUsePriPartSys = new System.Windows.Forms.CheckBox();
            this.FlagUseSecondaryLight = new System.Windows.Forms.CheckBox();
            this.StateOff = new System.Windows.Forms.RadioButton();
            this.StateOn = new System.Windows.Forms.RadioButton();
            this.StateDestroyed = new System.Windows.Forms.RadioButton();
            this.StateLockedOn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tmrLGT = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CurLight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenSector
            // 
            this.btnOpenSector.Location = new System.Drawing.Point(217, 4);
            this.btnOpenSector.Name = "btnOpenSector";
            this.btnOpenSector.Size = new System.Drawing.Size(108, 23);
            this.btnOpenSector.TabIndex = 2;
            this.btnOpenSector.Text = "Open a sector";
            this.btnOpenSector.UseVisualStyleBackColor = true;
            this.btnOpenSector.Click += new System.EventHandler(this.btnOpenSector_Click);
            // 
            // CurSector
            // 
            this.CurSector.AutoSize = true;
            this.CurSector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CurSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurSector.Location = new System.Drawing.Point(78, 9);
            this.CurSector.Name = "CurSector";
            this.CurSector.Size = new System.Drawing.Size(133, 13);
            this.CurSector.TabIndex = 1;
            this.CurSector.Text = "NO SECTOR IS OPEN";
            // 
            // btnSaveSector
            // 
            this.btnSaveSector.Location = new System.Drawing.Point(331, 4);
            this.btnSaveSector.Name = "btnSaveSector";
            this.btnSaveSector.Size = new System.Drawing.Size(108, 23);
            this.btnSaveSector.TabIndex = 3;
            this.btnSaveSector.Text = "Save a sector";
            this.btnSaveSector.UseVisualStyleBackColor = true;
            this.btnSaveSector.Click += new System.EventHandler(this.btnSaveSector_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sector File:";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(-12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(665, 1);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(-12, 534);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(665, 1);
            this.label3.TabIndex = 12;
            this.label3.Text = "label3";
            // 
            // btnAddLight
            // 
            this.btnAddLight.Location = new System.Drawing.Point(102, 547);
            this.btnAddLight.Name = "btnAddLight";
            this.btnAddLight.Size = new System.Drawing.Size(108, 23);
            this.btnAddLight.TabIndex = 13;
            this.btnAddLight.Text = "Add A Light";
            this.btnAddLight.UseVisualStyleBackColor = true;
            this.btnAddLight.Click += new System.EventHandler(this.btnAddLight_Click);
            // 
            // btnDeleteLight
            // 
            this.btnDeleteLight.Location = new System.Drawing.Point(326, 547);
            this.btnDeleteLight.Name = "btnDeleteLight";
            this.btnDeleteLight.Size = new System.Drawing.Size(108, 23);
            this.btnDeleteLight.TabIndex = 15;
            this.btnDeleteLight.Text = "Delete A Light";
            this.btnDeleteLight.UseVisualStyleBackColor = true;
            this.btnDeleteLight.Click += new System.EventHandler(this.btnDeleteLight_Click);
            // 
            // btnUpdateLight
            // 
            this.btnUpdateLight.Location = new System.Drawing.Point(214, 547);
            this.btnUpdateLight.Name = "btnUpdateLight";
            this.btnUpdateLight.Size = new System.Drawing.Size(108, 23);
            this.btnUpdateLight.TabIndex = 14;
            this.btnUpdateLight.Text = "Update A Light";
            this.btnUpdateLight.UseVisualStyleBackColor = true;
            this.btnUpdateLight.Click += new System.EventHandler(this.btnUpdateLight_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Current Light:";
            // 
            // CurLight
            // 
            this.CurLight.Location = new System.Drawing.Point(92, 39);
            this.CurLight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CurLight.Name = "CurLight";
            this.CurLight.Size = new System.Drawing.Size(66, 20);
            this.CurLight.TabIndex = 6;
            this.CurLight.ValueChanged += new System.EventHandler(this.CurLight_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Light Type:";
            // 
            // PriLightType
            // 
            this.PriLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PriLightType.FormattingEnabled = true;
            this.PriLightType.Items.AddRange(new object[] {
            "None",
            "Point",
            "Directional",
            "Spot",
            "Ambient"});
            this.PriLightType.Location = new System.Drawing.Point(118, 13);
            this.PriLightType.Name = "PriLightType";
            this.PriLightType.Size = new System.Drawing.Size(96, 21);
            this.PriLightType.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateHash1);
            this.groupBox1.Controls.Add(this.btnSetColor1);
            this.groupBox1.Controls.Add(this.PriPartsysID);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.PriPartsysHash);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.PriAngle);
            this.groupBox1.Controls.Add(this.PriLightType);
            this.groupBox1.Controls.Add(this.label00);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.PriRange);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.PriDirZ);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.PriDirY);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.PriDirX);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.PriHeight);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.PriOfsY);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.PriOfsX);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.PriY);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.PriX);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.PriBlue);
            this.groupBox1.Controls.Add(this.PriGreen);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.PriRed);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 392);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Primary Light (Day)";
            // 
            // btnCreateHash1
            // 
            this.btnCreateHash1.Location = new System.Drawing.Point(216, 349);
            this.btnCreateHash1.Name = "btnCreateHash1";
            this.btnCreateHash1.Size = new System.Drawing.Size(75, 23);
            this.btnCreateHash1.TabIndex = 33;
            this.btnCreateHash1.Text = "Create...";
            this.btnCreateHash1.UseVisualStyleBackColor = true;
            this.btnCreateHash1.Click += new System.EventHandler(this.btnCreateHash1_Click);
            // 
            // btnSetColor1
            // 
            this.btnSetColor1.Location = new System.Drawing.Point(216, 39);
            this.btnSetColor1.Name = "btnSetColor1";
            this.btnSetColor1.Size = new System.Drawing.Size(37, 23);
            this.btnSetColor1.TabIndex = 32;
            this.btnSetColor1.Text = "...";
            this.btnSetColor1.UseVisualStyleBackColor = true;
            this.btnSetColor1.Click += new System.EventHandler(this.btnSetColor1_Click);
            // 
            // PriPartsysID
            // 
            this.PriPartsysID.Location = new System.Drawing.Point(127, 371);
            this.PriPartsysID.Name = "PriPartsysID";
            this.PriPartsysID.Size = new System.Drawing.Size(87, 20);
            this.PriPartsysID.TabIndex = 31;
            this.PriPartsysID.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 374);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Particle System ID:";
            // 
            // PriPartsysHash
            // 
            this.PriPartsysHash.Location = new System.Drawing.Point(127, 349);
            this.PriPartsysHash.Name = "PriPartsysHash";
            this.PriPartsysHash.Size = new System.Drawing.Size(87, 20);
            this.PriPartsysHash.TabIndex = 29;
            this.PriPartsysHash.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 352);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(124, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Particle System Hash ID:";
            // 
            // PriAngle
            // 
            this.PriAngle.Location = new System.Drawing.Point(126, 309);
            this.PriAngle.Name = "PriAngle";
            this.PriAngle.Size = new System.Drawing.Size(88, 20);
            this.PriAngle.TabIndex = 27;
            this.PriAngle.Text = "0";
            // 
            // label00
            // 
            this.label00.AutoSize = true;
            this.label00.Location = new System.Drawing.Point(5, 312);
            this.label00.Name = "label00";
            this.label00.Size = new System.Drawing.Size(106, 13);
            this.label00.TabIndex = 26;
            this.label00.Text = "Angle (floating point):";
            // 
            // PriRange
            // 
            this.PriRange.Location = new System.Drawing.Point(126, 287);
            this.PriRange.Name = "PriRange";
            this.PriRange.Size = new System.Drawing.Size(88, 20);
            this.PriRange.TabIndex = 25;
            this.PriRange.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 290);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Range (floating point):";
            // 
            // PriDirZ
            // 
            this.PriDirZ.Location = new System.Drawing.Point(126, 264);
            this.PriDirZ.Name = "PriDirZ";
            this.PriDirZ.Size = new System.Drawing.Size(88, 20);
            this.PriDirZ.TabIndex = 23;
            this.PriDirZ.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 267);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Direction Z (floating pt):";
            // 
            // PriDirY
            // 
            this.PriDirY.Location = new System.Drawing.Point(126, 242);
            this.PriDirY.Name = "PriDirY";
            this.PriDirY.Size = new System.Drawing.Size(88, 20);
            this.PriDirY.TabIndex = 21;
            this.PriDirY.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Direction Y (floating pt):";
            // 
            // PriDirX
            // 
            this.PriDirX.Location = new System.Drawing.Point(126, 220);
            this.PriDirX.Name = "PriDirX";
            this.PriDirX.Size = new System.Drawing.Size(88, 20);
            this.PriDirX.TabIndex = 19;
            this.PriDirX.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 223);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Direction X (floating pt):";
            // 
            // PriHeight
            // 
            this.PriHeight.Location = new System.Drawing.Point(126, 196);
            this.PriHeight.Name = "PriHeight";
            this.PriHeight.Size = new System.Drawing.Size(88, 20);
            this.PriHeight.TabIndex = 17;
            this.PriHeight.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Height (floating point):";
            // 
            // PriOfsY
            // 
            this.PriOfsY.Location = new System.Drawing.Point(126, 174);
            this.PriOfsY.Name = "PriOfsY";
            this.PriOfsY.Size = new System.Drawing.Size(88, 20);
            this.PriOfsY.TabIndex = 15;
            this.PriOfsY.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Y Offset (floating point):";
            // 
            // PriOfsX
            // 
            this.PriOfsX.Location = new System.Drawing.Point(126, 152);
            this.PriOfsX.Name = "PriOfsX";
            this.PriOfsX.Size = new System.Drawing.Size(88, 20);
            this.PriOfsX.TabIndex = 13;
            this.PriOfsX.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "X Offset (floating point):";
            // 
            // PriY
            // 
            this.PriY.Location = new System.Drawing.Point(126, 129);
            this.PriY.Name = "PriY";
            this.PriY.Size = new System.Drawing.Size(88, 20);
            this.PriY.TabIndex = 11;
            this.PriY.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Location Y:";
            // 
            // PriX
            // 
            this.PriX.Location = new System.Drawing.Point(126, 107);
            this.PriX.Name = "PriX";
            this.PriX.Size = new System.Drawing.Size(88, 20);
            this.PriX.TabIndex = 9;
            this.PriX.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Location X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Color: Blue (0..255):";
            // 
            // PriBlue
            // 
            this.PriBlue.Location = new System.Drawing.Point(126, 62);
            this.PriBlue.Name = "PriBlue";
            this.PriBlue.Size = new System.Drawing.Size(88, 20);
            this.PriBlue.TabIndex = 7;
            this.PriBlue.Text = "0";
            // 
            // PriGreen
            // 
            this.PriGreen.Location = new System.Drawing.Point(126, 84);
            this.PriGreen.Name = "PriGreen";
            this.PriGreen.Size = new System.Drawing.Size(88, 20);
            this.PriGreen.TabIndex = 5;
            this.PriGreen.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Color: Green (0..255):";
            // 
            // PriRed
            // 
            this.PriRed.Location = new System.Drawing.Point(126, 40);
            this.PriRed.Name = "PriRed";
            this.PriRed.Size = new System.Drawing.Size(88, 20);
            this.PriRed.TabIndex = 3;
            this.PriRed.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Color: Red (0..255):";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCreateHash2);
            this.groupBox2.Controls.Add(this.btnSetColor2);
            this.groupBox2.Controls.Add(this.SecPartsysID);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.SecPartsysHash);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.SecAngle);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.SecRange);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.SecDirZ);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.SecDirY);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.SecDirX);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.SecBlue);
            this.groupBox2.Controls.Add(this.SecGreen);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.SecRed);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.SecLightType);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(331, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 392);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Secondary Light (Night)";
            // 
            // btnCreateHash2
            // 
            this.btnCreateHash2.Location = new System.Drawing.Point(227, 349);
            this.btnCreateHash2.Name = "btnCreateHash2";
            this.btnCreateHash2.Size = new System.Drawing.Size(75, 23);
            this.btnCreateHash2.TabIndex = 34;
            this.btnCreateHash2.Text = "Create...";
            this.btnCreateHash2.UseVisualStyleBackColor = true;
            this.btnCreateHash2.Click += new System.EventHandler(this.btnCreateHash2_Click);
            // 
            // btnSetColor2
            // 
            this.btnSetColor2.Location = new System.Drawing.Point(227, 39);
            this.btnSetColor2.Name = "btnSetColor2";
            this.btnSetColor2.Size = new System.Drawing.Size(37, 23);
            this.btnSetColor2.TabIndex = 33;
            this.btnSetColor2.Text = "...";
            this.btnSetColor2.UseVisualStyleBackColor = true;
            this.btnSetColor2.Click += new System.EventHandler(this.btnSetColor2_Click);
            // 
            // SecPartsysID
            // 
            this.SecPartsysID.Location = new System.Drawing.Point(130, 371);
            this.SecPartsysID.Name = "SecPartsysID";
            this.SecPartsysID.Size = new System.Drawing.Size(95, 20);
            this.SecPartsysID.TabIndex = 21;
            this.SecPartsysID.Text = "0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 374);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 13);
            this.label29.TabIndex = 20;
            this.label29.Text = "Particle System ID:";
            // 
            // SecPartsysHash
            // 
            this.SecPartsysHash.Location = new System.Drawing.Point(130, 349);
            this.SecPartsysHash.Name = "SecPartsysHash";
            this.SecPartsysHash.Size = new System.Drawing.Size(95, 20);
            this.SecPartsysHash.TabIndex = 19;
            this.SecPartsysHash.Text = "0";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 352);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(124, 13);
            this.label30.TabIndex = 18;
            this.label30.Text = "Particle System Hash ID:";
            // 
            // SecAngle
            // 
            this.SecAngle.Location = new System.Drawing.Point(127, 196);
            this.SecAngle.Name = "SecAngle";
            this.SecAngle.Size = new System.Drawing.Size(98, 20);
            this.SecAngle.TabIndex = 17;
            this.SecAngle.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 199);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(106, 13);
            this.label27.TabIndex = 16;
            this.label27.Text = "Angle (floating point):";
            // 
            // SecRange
            // 
            this.SecRange.Location = new System.Drawing.Point(127, 174);
            this.SecRange.Name = "SecRange";
            this.SecRange.Size = new System.Drawing.Size(98, 20);
            this.SecRange.TabIndex = 15;
            this.SecRange.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 177);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(111, 13);
            this.label28.TabIndex = 14;
            this.label28.Text = "Range (floating point):";
            // 
            // SecDirZ
            // 
            this.SecDirZ.Location = new System.Drawing.Point(127, 151);
            this.SecDirZ.Name = "SecDirZ";
            this.SecDirZ.Size = new System.Drawing.Size(98, 20);
            this.SecDirZ.TabIndex = 13;
            this.SecDirZ.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 154);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(117, 13);
            this.label24.TabIndex = 12;
            this.label24.Text = "Direction Z (floating pt):";
            // 
            // SecDirY
            // 
            this.SecDirY.Location = new System.Drawing.Point(127, 129);
            this.SecDirY.Name = "SecDirY";
            this.SecDirY.Size = new System.Drawing.Size(98, 20);
            this.SecDirY.TabIndex = 11;
            this.SecDirY.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 132);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(117, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "Direction Y (floating pt):";
            // 
            // SecDirX
            // 
            this.SecDirX.Location = new System.Drawing.Point(127, 107);
            this.SecDirX.Name = "SecDirX";
            this.SecDirX.Size = new System.Drawing.Size(98, 20);
            this.SecDirX.TabIndex = 9;
            this.SecDirX.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 110);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(117, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "Direction X (floating pt):";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Color: Blue (0..255):";
            // 
            // SecBlue
            // 
            this.SecBlue.Location = new System.Drawing.Point(127, 62);
            this.SecBlue.Name = "SecBlue";
            this.SecBlue.Size = new System.Drawing.Size(98, 20);
            this.SecBlue.TabIndex = 7;
            this.SecBlue.Text = "0";
            // 
            // SecGreen
            // 
            this.SecGreen.Location = new System.Drawing.Point(127, 84);
            this.SecGreen.Name = "SecGreen";
            this.SecGreen.Size = new System.Drawing.Size(98, 20);
            this.SecGreen.TabIndex = 5;
            this.SecGreen.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 62);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(108, 13);
            this.label22.TabIndex = 4;
            this.label22.Text = "Color: Green (0..255):";
            // 
            // SecRed
            // 
            this.SecRed.Location = new System.Drawing.Point(127, 40);
            this.SecRed.Name = "SecRed";
            this.SecRed.Size = new System.Drawing.Size(98, 20);
            this.SecRed.TabIndex = 3;
            this.SecRed.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 40);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(99, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Color: Red (0..255):";
            // 
            // SecLightType
            // 
            this.SecLightType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SecLightType.FormattingEnabled = true;
            this.SecLightType.Items.AddRange(new object[] {
            "None",
            "Point",
            "Directional",
            "Spot",
            "Ambient"});
            this.SecLightType.Location = new System.Drawing.Point(118, 13);
            this.SecLightType.Name = "SecLightType";
            this.SecLightType.Size = new System.Drawing.Size(107, 21);
            this.SecLightType.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Light Type:";
            // 
            // FlagAnimated
            // 
            this.FlagAnimated.AutoSize = true;
            this.FlagAnimated.Location = new System.Drawing.Point(12, 19);
            this.FlagAnimated.Name = "FlagAnimated";
            this.FlagAnimated.Size = new System.Drawing.Size(70, 17);
            this.FlagAnimated.TabIndex = 0;
            this.FlagAnimated.Text = "Animated";
            this.FlagAnimated.UseVisualStyleBackColor = true;
            // 
            // FlagViewControls
            // 
            this.FlagViewControls.AutoSize = true;
            this.FlagViewControls.Location = new System.Drawing.Point(12, 42);
            this.FlagViewControls.Name = "FlagViewControls";
            this.FlagViewControls.Size = new System.Drawing.Size(90, 17);
            this.FlagViewControls.TabIndex = 1;
            this.FlagViewControls.Text = "View Controls";
            this.FlagViewControls.UseVisualStyleBackColor = true;
            // 
            // FlagUsePrimaryLight
            // 
            this.FlagUsePrimaryLight.AutoSize = true;
            this.FlagUsePrimaryLight.Checked = true;
            this.FlagUsePrimaryLight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FlagUsePrimaryLight.Location = new System.Drawing.Point(12, 65);
            this.FlagUsePrimaryLight.Name = "FlagUsePrimaryLight";
            this.FlagUsePrimaryLight.Size = new System.Drawing.Size(113, 17);
            this.FlagUsePrimaryLight.TabIndex = 2;
            this.FlagUsePrimaryLight.Text = "Uses Primary Light";
            this.FlagUsePrimaryLight.UseVisualStyleBackColor = true;
            // 
            // FlagUsePriPartSys
            // 
            this.FlagUsePriPartSys.AutoSize = true;
            this.FlagUsePriPartSys.Location = new System.Drawing.Point(128, 19);
            this.FlagUsePriPartSys.Name = "FlagUsePriPartSys";
            this.FlagUsePriPartSys.Size = new System.Drawing.Size(181, 17);
            this.FlagUsePriPartSys.TabIndex = 3;
            this.FlagUsePriPartSys.Text = "Primary Light has Particle System";
            this.FlagUsePriPartSys.UseVisualStyleBackColor = true;
            // 
            // FlagUseSecondaryLight
            // 
            this.FlagUseSecondaryLight.AutoSize = true;
            this.FlagUseSecondaryLight.Location = new System.Drawing.Point(128, 42);
            this.FlagUseSecondaryLight.Name = "FlagUseSecondaryLight";
            this.FlagUseSecondaryLight.Size = new System.Drawing.Size(130, 17);
            this.FlagUseSecondaryLight.TabIndex = 4;
            this.FlagUseSecondaryLight.Text = "Uses Secondary Light";
            this.FlagUseSecondaryLight.UseVisualStyleBackColor = true;
            // 
            // StateOff
            // 
            this.StateOff.AutoSize = true;
            this.StateOff.Checked = true;
            this.StateOff.Location = new System.Drawing.Point(7, 19);
            this.StateOff.Name = "StateOff";
            this.StateOff.Size = new System.Drawing.Size(120, 17);
            this.StateOff.TabIndex = 0;
            this.StateOff.TabStop = true;
            this.StateOff.Text = "Off (Recommended)";
            this.StateOff.UseVisualStyleBackColor = true;
            // 
            // StateOn
            // 
            this.StateOn.AutoSize = true;
            this.StateOn.Location = new System.Drawing.Point(7, 36);
            this.StateOn.Name = "StateOn";
            this.StateOn.Size = new System.Drawing.Size(39, 17);
            this.StateOn.TabIndex = 1;
            this.StateOn.Text = "On";
            this.StateOn.UseVisualStyleBackColor = true;
            // 
            // StateDestroyed
            // 
            this.StateDestroyed.AutoSize = true;
            this.StateDestroyed.Location = new System.Drawing.Point(7, 54);
            this.StateDestroyed.Name = "StateDestroyed";
            this.StateDestroyed.Size = new System.Drawing.Size(73, 17);
            this.StateDestroyed.TabIndex = 2;
            this.StateDestroyed.Text = "Destroyed";
            this.StateDestroyed.UseVisualStyleBackColor = true;
            // 
            // StateLockedOn
            // 
            this.StateLockedOn.AutoSize = true;
            this.StateLockedOn.Location = new System.Drawing.Point(7, 72);
            this.StateLockedOn.Name = "StateLockedOn";
            this.StateLockedOn.Size = new System.Drawing.Size(78, 17);
            this.StateLockedOn.TabIndex = 3;
            this.StateLockedOn.Text = "Locked On";
            this.StateLockedOn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.StateOff);
            this.groupBox3.Controls.Add(this.StateLockedOn);
            this.groupBox3.Controls.Add(this.StateOn);
            this.groupBox3.Controls.Add(this.StateDestroyed);
            this.groupBox3.Location = new System.Drawing.Point(169, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 98);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Light State";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FlagAnimated);
            this.groupBox4.Controls.Add(this.FlagUseSecondaryLight);
            this.groupBox4.Controls.Add(this.FlagViewControls);
            this.groupBox4.Controls.Add(this.FlagUsePriPartSys);
            this.groupBox4.Controls.Add(this.FlagUsePrimaryLight);
            this.groupBox4.Location = new System.Drawing.Point(331, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 100);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Flags";
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(438, 547);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(108, 23);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(445, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(108, 23);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Help...";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tmrLGT
            // 
            this.tmrLGT.Interval = 1;
            this.tmrLGT.Tick += new System.EventHandler(this.tmrLGT_Tick);
            // 
            // LightEditorEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 582);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CurLight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnUpdateLight);
            this.Controls.Add(this.btnDeleteLight);
            this.Controls.Add(this.btnAddLight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveSector);
            this.Controls.Add(this.CurSector);
            this.Controls.Add(this.btnOpenSector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LightEditorEx";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sector Light Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LightEditorEx_FormClosing);
            this.Load += new System.EventHandler(this.LightEditorEx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CurLight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSector;
        private System.Windows.Forms.Label CurSector;
        private System.Windows.Forms.Button btnSaveSector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddLight;
        private System.Windows.Forms.Button btnDeleteLight;
        private System.Windows.Forms.Button btnUpdateLight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CurLight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox PriLightType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox FlagAnimated;
        private System.Windows.Forms.CheckBox FlagViewControls;
        private System.Windows.Forms.CheckBox FlagUsePrimaryLight;
        private System.Windows.Forms.CheckBox FlagUsePriPartSys;
        private System.Windows.Forms.CheckBox FlagUseSecondaryLight;
        private System.Windows.Forms.RadioButton StateOff;
        private System.Windows.Forms.RadioButton StateOn;
        private System.Windows.Forms.RadioButton StateDestroyed;
        private System.Windows.Forms.RadioButton StateLockedOn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PriBlue;
        private System.Windows.Forms.TextBox PriGreen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PriRed;
        private System.Windows.Forms.TextBox PriY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PriX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PriOfsY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PriOfsX;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PriHeight;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox PriDirZ;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox PriDirY;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox PriDirX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox PriPartsysID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox PriPartsysHash;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox PriAngle;
        private System.Windows.Forms.Label label00;
        private System.Windows.Forms.TextBox PriRange;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox SecLightType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox SecPartsysID;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox SecPartsysHash;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox SecAngle;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox SecRange;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox SecDirZ;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox SecDirY;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox SecDirX;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox SecBlue;
        private System.Windows.Forms.TextBox SecGreen;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox SecRed;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnSetColor1;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.Button btnSetColor2;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnCreateHash1;
        private System.Windows.Forms.Button btnCreateHash2;
        private System.Windows.Forms.Timer tmrLGT;
    }
}