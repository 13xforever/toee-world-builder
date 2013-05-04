﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace WorldBuilder
{
	public partial class LinkMOB
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
			this.MOB_LIST = new System.Windows.Forms.ListBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// MOB_LIST
			// 
			this.MOB_LIST.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.MOB_LIST.ItemHeight = 15;
			this.MOB_LIST.Location = new System.Drawing.Point(8, 8);
			this.MOB_LIST.Name = "MOB_LIST";
			this.MOB_LIST.Size = new System.Drawing.Size(744, 484);
			this.MOB_LIST.TabIndex = 0;
			this.MOB_LIST.SelectedIndexChanged += new System.EventHandler(this.MOB_LIST_SelectedIndexChanged);
			// 
			// btnOpen
			// 
			this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOpen.Enabled = false;
			this.btnOpen.Location = new System.Drawing.Point(272, 506);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(104, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Link";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(384, 506);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// LinkMOB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(762, 551);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.MOB_LIST);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "LinkMOB";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Link Mobile Object Files";
			this.Load += new System.EventHandler(this.OpenMOB_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private System.Windows.Forms.ListBox MOB_LIST;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnCancel;
	}
}
