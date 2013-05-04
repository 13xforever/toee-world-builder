namespace ToEE_World_Builder
{
    partial class PathNodeAutoGen
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtStepping = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generate Path Nodes From: X=";
            // 
            // FX
            // 
            this.FX.Location = new System.Drawing.Point(164, 6);
            this.FX.Name = "FX";
            this.FX.Size = new System.Drawing.Size(45, 20);
            this.FX.TabIndex = 1;
            this.FX.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y=";
            // 
            // FY
            // 
            this.FY.Location = new System.Drawing.Point(232, 6);
            this.FY.Name = "FY";
            this.FY.Size = new System.Drawing.Size(45, 20);
            this.FY.TabIndex = 3;
            this.FY.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To:     X=";
            // 
            // TY
            // 
            this.TY.Location = new System.Drawing.Point(232, 32);
            this.TY.Name = "TY";
            this.TY.Size = new System.Drawing.Size(45, 20);
            this.TY.TabIndex = 7;
            this.TY.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y=";
            // 
            // TX
            // 
            this.TX.Location = new System.Drawing.Point(164, 32);
            this.TX.Name = "TX";
            this.TX.Size = new System.Drawing.Size(45, 20);
            this.TX.TabIndex = 5;
            this.TX.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stepping:";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(-2, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(298, 1);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(68, 101);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "Generate";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(149, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtStepping
            // 
            this.txtStepping.Location = new System.Drawing.Point(67, 67);
            this.txtStepping.Name = "txtStepping";
            this.txtStepping.Size = new System.Drawing.Size(50, 20);
            this.txtStepping.TabIndex = 15;
            this.txtStepping.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "tiles (default 10, 5 min, 20 max)";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(12, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(268, 74);
            this.label8.TabIndex = 17;
            this.label8.Text = resources.GetString("label8.Text");
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PathNodeAutoGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 212);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtStepping);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FX);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PathNodeAutoGen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automated Path Node Generation";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtStepping;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}