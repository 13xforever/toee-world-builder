using System.Windows.Forms;

namespace WorldBuilder.Forms
{
	/// <summary>
	/// Summary description for AboutForm.
	/// </summary>
	public partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.ToEE = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ToEE)).BeginInit();
			this.SuspendLayout();
			// 
			// ToEE
			// 
			this.ToEE.Image = ((System.Drawing.Image)(resources.GetObject("ToEE.Image")));
			this.ToEE.Location = new System.Drawing.Point(0, 0);
			this.ToEE.Name = "ToEE";
			this.ToEE.Size = new System.Drawing.Size(400, 176);
			this.ToEE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ToEE.TabIndex = 1;
			this.ToEE.TabStop = false;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Black;
			this.label1.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
			this.label1.Location = new System.Drawing.Point(0, 175);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(400, 40);
			this.label1.TabIndex = 2;
			this.label1.Text = "World Builder vX.Y.Z (ABCDEF0)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.Azure;
			this.label2.Location = new System.Drawing.Point(0, 224);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(400, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "CREATED BY";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.Ivory;
			this.label3.Location = new System.Drawing.Point(0, 240);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(400, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Michael Kamensky (Agetian) - coding, research";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.Ivory;
			this.label4.Location = new System.Drawing.Point(0, 256);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(400, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Joshua Delahunty (Dulcaoin) - research";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(156, 521);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(92, 24);
			this.button1.TabIndex = 6;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// label5
			// 
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.Ivory;
			this.label5.Location = new System.Drawing.Point(0, 548);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(400, 22);
			this.label5.TabIndex = 7;
			this.label5.Text = "© 2005 - 2013 Circle of Eight";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// label6
			// 
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.Azure;
			this.label6.Location = new System.Drawing.Point(0, 352);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(400, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "THANKS FOR BETA-TESTING TO";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.ForeColor = System.Drawing.Color.Ivory;
			this.label7.Location = new System.Drawing.Point(0, 368);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(400, 23);
			this.label7.TabIndex = 9;
			this.label7.Text = "Allyx, Morpheus, Shiningted, Sapricon, Rufnredde";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.ForeColor = System.Drawing.Color.Azure;
			this.label8.Location = new System.Drawing.Point(0, 437);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(400, 32);
			this.label8.TabIndex = 10;
			this.label8.Text = "THANKS FOR INSPIRATION TO";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.ForeColor = System.Drawing.Color.Ivory;
			this.label9.Location = new System.Drawing.Point(0, 453);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(400, 23);
			this.label9.TabIndex = 11;
			this.label9.Text = "Livonya";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.ForeColor = System.Drawing.Color.Azure;
			this.label10.Location = new System.Drawing.Point(0, 288);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(400, 40);
			this.label10.TabIndex = 12;
			this.label10.Text = "VERY SPECIAL THANKS FOR ANSWERING MY QUESTIONS TO";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.ForeColor = System.Drawing.Color.Ivory;
			this.label11.Location = new System.Drawing.Point(0, 320);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(400, 23);
			this.label11.TabIndex = 13;
			this.label11.Text = "Steve Moret";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.ForeColor = System.Drawing.Color.Azure;
			this.label12.Location = new System.Drawing.Point(0, 476);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(400, 32);
			this.label12.TabIndex = 14;
			this.label12.Text = "TOEE TOOLSET PROJECT IS DEDICATED TO";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label13
			// 
			this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.ForeColor = System.Drawing.Color.Ivory;
			this.label13.Location = new System.Drawing.Point(0, 491);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(400, 23);
			this.label13.TabIndex = 15;
			this.label13.Text = "Gadget Hackwrench";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.ForeColor = System.Drawing.Color.Azure;
			this.label14.Location = new System.Drawing.Point(3, 395);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(400, 23);
			this.label14.TabIndex = 16;
			this.label14.Text = "CODE CONTRIBUTIONS BY";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label15.ForeColor = System.Drawing.Color.Ivory;
			this.label15.Location = new System.Drawing.Point(0, 411);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(400, 23);
			this.label15.TabIndex = 17;
			this.label15.Text = "Sitra Achara, 13xforever";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(401, 573);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ToEE);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About Temple of Elemental Evil World Builder";
			((System.ComponentModel.ISupportInitialize)(this.ToEE)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private System.Windows.Forms.PictureBox ToEE;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private Label label12;
		private Label label13;
		private Label label14;
		private Label label15;
	}
}
