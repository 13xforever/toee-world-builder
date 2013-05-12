namespace WorldBuilder.Forms
{
	internal partial class PathNodeAutoGen
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathNodeAutoGen));
			this.label1 = new System.Windows.Forms.Label();
			this.FX = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.FY = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TY = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.TX = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.stepping = new System.Windows.Forms.TrackBar();
			this.steppingToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stepping)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "From: X =";
			// 
			// FX
			// 
			this.FX.Location = new System.Drawing.Point(85, 19);
			this.FX.Name = "FX";
			this.FX.Size = new System.Drawing.Size(60, 20);
			this.FX.TabIndex = 0;
			this.FX.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(151, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Y =";
			// 
			// FY
			// 
			this.FY.Location = new System.Drawing.Point(180, 19);
			this.FY.Name = "FY";
			this.FY.Size = new System.Drawing.Size(60, 20);
			this.FY.TabIndex = 1;
			this.FY.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(37, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "To: X =";
			// 
			// TY
			// 
			this.TY.Location = new System.Drawing.Point(180, 45);
			this.TY.Name = "TY";
			this.TY.Size = new System.Drawing.Size(60, 20);
			this.TY.TabIndex = 3;
			this.TY.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(151, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(23, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Y =";
			// 
			// TX
			// 
			this.TX.Location = new System.Drawing.Point(85, 45);
			this.TX.Name = "TX";
			this.TX.Size = new System.Drawing.Size(60, 20);
			this.TX.TabIndex = 2;
			this.TX.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 74);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Stepping:";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(67, 148);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "Generate";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(148, 148);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 185);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(268, 74);
			this.label8.TabIndex = 17;
			this.label8.Text = resources.GetString("label8.Text");
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.stepping);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.FX);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.FY);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TX);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.TY);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(267, 130);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Generate Path Nodes";
			// 
			// stepping
			// 
			this.stepping.Location = new System.Drawing.Point(85, 74);
			this.stepping.Maximum = 20;
			this.stepping.Minimum = 5;
			this.stepping.Name = "stepping";
			this.stepping.Size = new System.Drawing.Size(155, 45);
			this.stepping.TabIndex = 4;
			this.stepping.Value = 10;
			this.stepping.Scroll += new System.EventHandler(this.OnSteppingScroll);
			// 
			// steppingToolTip
			// 
			this.steppingToolTip.AutomaticDelay = 200;
			// 
			// PathNodeAutoGen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(291, 269);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PathNodeAutoGen";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Automated Path Node Generation";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stepping)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TX;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TrackBar stepping;
		private System.Windows.Forms.ToolTip steppingToolTip;
    }
}