using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WorldBuilder.Forms
{
    partial class CreatePartsysHID
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CreatePartsysHID));
            this.label1 = new Label();
            this.PartsysName = new TextBox();
            this.label2 = new Label();
            this.btnCreate = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.FlatStyle = FlatStyle.System;
            this.label1.Location = new Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(434, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // PartsysName
            // 
            this.PartsysName.Location = new Point(177, 77);
            this.PartsysName.Name = "PartsysName";
            this.PartsysName.Size = new Size(261, 20);
            this.PartsysName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new Size(164, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "PARTICLE SYSTEM NAME:";
            // 
            // btnCreate
            // 
            this.btnCreate.DialogResult = DialogResult.OK;
            this.btnCreate.Location = new Point(147, 107);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new EventHandler(this.OnCreateClick);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(228, 107);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CreatePartsysHID
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(450, 142);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PartsysName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "CreatePartsysHID";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Creating a Particle System Hash ID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox PartsysName;
        private Label label2;
        private Button btnCreate;
        private Button btnCancel;
    }
}