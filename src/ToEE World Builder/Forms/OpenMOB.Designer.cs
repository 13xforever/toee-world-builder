using System.Windows.Forms;

namespace WorldBuilder.Forms
{
	public partial class OpenMOB
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
			this.btnDeleteMOB = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.mobProtoSearch = new System.Windows.Forms.TextBox();
			this.mobDescriptionSearch = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.mobGUIDSearch = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// MOB_LIST
			// 
			this.MOB_LIST.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MOB_LIST.ItemHeight = 15;
			this.MOB_LIST.Location = new System.Drawing.Point(8, 8);
			this.MOB_LIST.Name = "MOB_LIST";
			this.MOB_LIST.Size = new System.Drawing.Size(744, 499);
			this.MOB_LIST.TabIndex = 0;
			this.MOB_LIST.SelectedIndexChanged += new System.EventHandler(this.MOB_LIST_SelectedIndexChanged);
			// 
			// btnOpen
			// 
			this.btnOpen.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOpen.Enabled = false;
			this.btnOpen.Location = new System.Drawing.Point(219, 520);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(104, 23);
			this.btnOpen.TabIndex = 1;
			this.btnOpen.Text = "Open";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(439, 520);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// btnDeleteMOB
			// 
			this.btnDeleteMOB.Enabled = false;
			this.btnDeleteMOB.Location = new System.Drawing.Point(329, 520);
			this.btnDeleteMOB.Name = "btnDeleteMOB";
			this.btnDeleteMOB.Size = new System.Drawing.Size(104, 23);
			this.btnDeleteMOB.TabIndex = 3;
			this.btnDeleteMOB.Text = "Delete";
			this.btnDeleteMOB.Click += new System.EventHandler(this.btnDeleteMOB_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 560);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Filter By:";
			// 
			// mobProtoSearch
			// 
			this.mobProtoSearch.Location = new System.Drawing.Point(98, 580);
			this.mobProtoSearch.Name = "mobProtoSearch";
			this.mobProtoSearch.Size = new System.Drawing.Size(100, 20);
			this.mobProtoSearch.TabIndex = 5;
			this.mobProtoSearch.TextChanged += new System.EventHandler(this.mobProtoSearch_TextChanged);
			// 
			// mobDescriptionSearch
			// 
			this.mobDescriptionSearch.Location = new System.Drawing.Point(329, 580);
			this.mobDescriptionSearch.Name = "mobDescriptionSearch";
			this.mobDescriptionSearch.Size = new System.Drawing.Size(100, 20);
			this.mobDescriptionSearch.TabIndex = 6;
			this.mobDescriptionSearch.TextChanged += new System.EventHandler(this.mobDescriptionSearch_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(46, 584);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Proto ID";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(263, 583);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Description";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(518, 584);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "GUID";
			// 
			// mobGUIDSearch
			// 
			this.mobGUIDSearch.Location = new System.Drawing.Point(558, 580);
			this.mobGUIDSearch.Name = "mobGUIDSearch";
			this.mobGUIDSearch.Size = new System.Drawing.Size(100, 20);
			this.mobGUIDSearch.TabIndex = 9;
			this.mobGUIDSearch.TextChanged += new System.EventHandler(this.mobGUIDSearch_TextChanged);
			// 
			// OpenMOB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(762, 609);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.mobGUIDSearch);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.mobDescriptionSearch);
			this.Controls.Add(this.mobProtoSearch);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDeleteMOB);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.MOB_LIST);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "OpenMOB";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Open/Inspect Mobile Object Files";
			this.Load += new System.EventHandler(this.OpenMOB_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ListBox MOB_LIST;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnCancel;
		private Button btnDeleteMOB;
		private Label label1;
		private TextBox mobProtoSearch;
		private TextBox mobDescriptionSearch;
		private Label label2;
		private Label label3;
		private Label label4;
		private TextBox mobGUIDSearch;
	}
}
