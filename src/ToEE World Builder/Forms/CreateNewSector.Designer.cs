﻿namespace WorldBuilder.Forms
{
	public partial class CreateNewSector
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.rbObjCoords = new System.Windows.Forms.RadioButton();
			this.ObjX = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ObjY = new System.Windows.Forms.TextBox();
			this.rbSecCoords = new System.Windows.Forms.RadioButton();
			this.SecX = new System.Windows.Forms.TextBox();
			this.SecY = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(88, 80);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(168, 80);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			// 
			// rbObjCoords
			// 
			this.rbObjCoords.Checked = true;
			this.rbObjCoords.Location = new System.Drawing.Point(8, 8);
			this.rbObjCoords.Name = "rbObjCoords";
			this.rbObjCoords.Size = new System.Drawing.Size(208, 24);
			this.rbObjCoords.TabIndex = 2;
			this.rbObjCoords.TabStop = true;
			this.rbObjCoords.Text = "Create from Object Coordinates: X=";
			// 
			// ObjX
			// 
			this.ObjX.Location = new System.Drawing.Point(200, 12);
			this.ObjX.Name = "ObjX";
			this.ObjX.Size = new System.Drawing.Size(48, 20);
			this.ObjX.TabIndex = 3;
			this.ObjX.Text = "0";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(248, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Y=";
			// 
			// ObjY
			// 
			this.ObjY.Location = new System.Drawing.Point(272, 12);
			this.ObjY.Name = "ObjY";
			this.ObjY.Size = new System.Drawing.Size(48, 20);
			this.ObjY.TabIndex = 5;
			this.ObjY.Text = "0";
			// 
			// rbSecCoords
			// 
			this.rbSecCoords.Location = new System.Drawing.Point(8, 40);
			this.rbSecCoords.Name = "rbSecCoords";
			this.rbSecCoords.Size = new System.Drawing.Size(208, 24);
			this.rbSecCoords.TabIndex = 6;
			this.rbSecCoords.Text = "Create from Sector Coordinates: X=";
			// 
			// SecX
			// 
			this.SecX.Location = new System.Drawing.Point(200, 44);
			this.SecX.Name = "SecX";
			this.SecX.Size = new System.Drawing.Size(48, 20);
			this.SecX.TabIndex = 7;
			this.SecX.Text = "0";
			// 
			// SecY
			// 
			this.SecY.Location = new System.Drawing.Point(272, 44);
			this.SecY.Name = "SecY";
			this.SecY.Size = new System.Drawing.Size(48, 20);
			this.SecY.TabIndex = 9;
			this.SecY.Text = "0";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(248, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 8;
			this.label2.Text = "Y=";
			// 
			// CreateNewSector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(338, 111);
			this.Controls.Add(this.SecY);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SecX);
			this.Controls.Add(this.rbSecCoords);
			this.Controls.Add(this.ObjY);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ObjX);
			this.Controls.Add(this.rbObjCoords);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "CreateNewSector";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Create A New Sector";
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton rbObjCoords;
		private System.Windows.Forms.TextBox ObjX;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ObjY;
		private System.Windows.Forms.TextBox SecX;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rbSecCoords;
		private System.Windows.Forms.TextBox SecY;
	}
}
