namespace WorldBuilder.Forms
{
    partial class ProtoSearch
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
            this.psCriterion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchProto = new System.Windows.Forms.Button();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.rbTargetProtos = new System.Windows.Forms.RadioButton();
            this.rbTargetObject = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.psNameSearch = new System.Windows.Forms.TextBox();
            this.psNameLabel = new System.Windows.Forms.Label();
            this.psStrategyLabel = new System.Windows.Forms.Label();
            this.psStrategySearch = new System.Windows.Forms.TextBox();
            this.psSpellSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.psScriptSearch = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.psScriptTypeDropDown = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.psFeatSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.psFactionSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.psPortraitSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.psProtoLabel = new System.Windows.Forms.Label();
            this.psProtoSearch = new System.Windows.Forms.TextBox();
            this.psDescriptionLabel = new System.Windows.Forms.Label();
            this.psDescriptionSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // psCriterion
            // 
            this.psCriterion.Location = new System.Drawing.Point(74, 232);
            this.psCriterion.Name = "psCriterion";
            this.psCriterion.Size = new System.Drawing.Size(287, 20);
            this.psCriterion.TabIndex = 0;
            //this.psCriterion.TextChanged += new System.EventHandler(this.psCriterion_TextChanged);
            this.psCriterion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.psCriterion_KeyDown);
            this.psCriterion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.psCriterion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search For:";
            //this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSearchProto
            // 
            this.btnSearchProto.Location = new System.Drawing.Point(367, 230);
            this.btnSearchProto.Name = "btnSearchProto";
            this.btnSearchProto.Size = new System.Drawing.Size(87, 23);
            this.btnSearchProto.TabIndex = 2;
            this.btnSearchProto.Text = "Search Now";
            this.btnSearchProto.UseVisualStyleBackColor = true;
            this.btnSearchProto.Click += new System.EventHandler(this.btnSearchProto_Click);
            // 
            // lstResult
            // 
            this.lstResult.FormattingEnabled = true;
            this.lstResult.Location = new System.Drawing.Point(12, 12);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(438, 186);
            this.lstResult.TabIndex = 3;
            this.lstResult.SelectedIndexChanged += new System.EventHandler(this.lstResult_SelectedIndexChanged);
            // 
            // rbTargetProtos
            // 
            this.rbTargetProtos.AutoSize = true;
            this.rbTargetProtos.Checked = true;
            this.rbTargetProtos.Location = new System.Drawing.Point(133, 209);
            this.rbTargetProtos.Name = "rbTargetProtos";
            this.rbTargetProtos.Size = new System.Drawing.Size(100, 17);
            this.rbTargetProtos.TabIndex = 4;
            this.rbTargetProtos.TabStop = true;
            this.rbTargetProtos.Text = "Prototype Editor";
            this.rbTargetProtos.UseVisualStyleBackColor = true;
            //this.rbTargetProtos.CheckedChanged += new System.EventHandler(this.rbTargetProtos_CheckedChanged);
            // 
            // rbTargetObject
            // 
            this.rbTargetObject.AutoSize = true;
            this.rbTargetObject.Location = new System.Drawing.Point(239, 209);
            this.rbTargetObject.Name = "rbTargetObject";
            this.rbTargetObject.Size = new System.Drawing.Size(86, 17);
            this.rbTargetObject.TabIndex = 5;
            this.rbTargetObject.TabStop = true;
            this.rbTargetObject.Text = "Object Editor";
            this.rbTargetObject.UseVisualStyleBackColor = true;
            //this.rbTargetObject.CheckedChanged += new System.EventHandler(this.rbTargetObject_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Send Search Result To:";
            //this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // psNameSearch
            // 
            this.psNameSearch.Location = new System.Drawing.Point(87, 309);
            this.psNameSearch.Name = "psNameSearch";
            this.psNameSearch.Size = new System.Drawing.Size(191, 20);
            this.psNameSearch.TabIndex = 8;
            this.psNameSearch.Visible = false;
            // 
            // psNameLabel
            // 
            this.psNameLabel.AutoSize = true;
            this.psNameLabel.Location = new System.Drawing.Point(9, 312);
            this.psNameLabel.Name = "psNameLabel";
            this.psNameLabel.Size = new System.Drawing.Size(49, 13);
            this.psNameLabel.TabIndex = 9;
            this.psNameLabel.Text = "Name ID";
            this.psNameLabel.Visible = false;
            //this.psNameLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // psStrategyLabel
            // 
            this.psStrategyLabel.AutoSize = true;
            this.psStrategyLabel.Location = new System.Drawing.Point(9, 339);
            this.psStrategyLabel.Name = "psStrategyLabel";
            this.psStrategyLabel.Size = new System.Drawing.Size(73, 13);
            this.psStrategyLabel.TabIndex = 10;
            this.psStrategyLabel.Text = "Strategy Type";
            this.psStrategyLabel.Visible = false;
            // 
            // psStrategySearch
            // 
            this.psStrategySearch.Location = new System.Drawing.Point(87, 336);
            this.psStrategySearch.Name = "psStrategySearch";
            this.psStrategySearch.Size = new System.Drawing.Size(100, 20);
            this.psStrategySearch.TabIndex = 11;
            this.psStrategySearch.Visible = false;
            // 
            // psSpellSearch
            // 
            this.psSpellSearch.Location = new System.Drawing.Point(87, 363);
            this.psSpellSearch.Name = "psSpellSearch";
            this.psSpellSearch.Size = new System.Drawing.Size(100, 20);
            this.psSpellSearch.TabIndex = 12;
            this.psSpellSearch.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Spell";
            this.label4.Visible = false;
            // 
            // psScriptSearch
            // 
            this.psScriptSearch.Location = new System.Drawing.Point(87, 390);
            this.psScriptSearch.Name = "psScriptSearch";
            this.psScriptSearch.Size = new System.Drawing.Size(100, 20);
            this.psScriptSearch.TabIndex = 14;
            this.psScriptSearch.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 393);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Script ID";
            this.label5.Visible = false;
            // 
            // psScriptTypeDropDown
            // 
            this.psScriptTypeDropDown.FormattingEnabled = true;
            this.psScriptTypeDropDown.Items.AddRange(new object[] {
            "any",
            "san_dying",
            "san_heartbeat",
            "san_first_heartbeat",
            "san_dialog",
            "san_enter_combat",
            "san_start_combat",
            "san_spell_cast",
            "san_exit_combat",
            "san_end_combat",
            "san_insert_item",
            "san_remove_item",
            "san_join",
            "san_disband",
            "san_new_map",
            "san_trap",
            "san_unlock_attempt"});
            this.psScriptTypeDropDown.Location = new System.Drawing.Point(274, 390);
            this.psScriptTypeDropDown.Name = "psScriptTypeDropDown";
            this.psScriptTypeDropDown.Size = new System.Drawing.Size(121, 21);
            this.psScriptTypeDropDown.TabIndex = 16;
            this.psScriptTypeDropDown.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Script Type";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Feat";
            this.label7.Visible = false;
            // 
            // psFeatSearch
            // 
            this.psFeatSearch.Location = new System.Drawing.Point(87, 417);
            this.psFeatSearch.Name = "psFeatSearch";
            this.psFeatSearch.Size = new System.Drawing.Size(100, 20);
            this.psFeatSearch.TabIndex = 19;
            this.psFeatSearch.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 447);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Faction(s)";
            this.label8.Visible = false;
            // 
            // psFactionSearch
            // 
            this.psFactionSearch.Location = new System.Drawing.Point(87, 444);
            this.psFactionSearch.Name = "psFactionSearch";
            this.psFactionSearch.Size = new System.Drawing.Size(100, 20);
            this.psFactionSearch.TabIndex = 21;
            this.psFactionSearch.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 474);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Portrait ID";
            this.label9.Visible = false;
            //this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // psPortraitSearch
            // 
            this.psPortraitSearch.Location = new System.Drawing.Point(87, 471);
            this.psPortraitSearch.Name = "psPortraitSearch";
            this.psPortraitSearch.Size = new System.Drawing.Size(100, 20);
            this.psPortraitSearch.TabIndex = 23;
            this.psPortraitSearch.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Advanced Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Advanced Search...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // psProtoLabel
            // 
            this.psProtoLabel.AutoSize = true;
            this.psProtoLabel.Location = new System.Drawing.Point(9, 285);
            this.psProtoLabel.Name = "psProtoLabel";
            this.psProtoLabel.Size = new System.Drawing.Size(46, 13);
            this.psProtoLabel.TabIndex = 27;
            this.psProtoLabel.Text = "Proto ID";
            this.psProtoLabel.Visible = false;
            this.psProtoLabel.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // psProtoSearch
            // 
            this.psProtoSearch.Location = new System.Drawing.Point(87, 282);
            this.psProtoSearch.Name = "psProtoSearch";
            this.psProtoSearch.Size = new System.Drawing.Size(191, 20);
            this.psProtoSearch.TabIndex = 26;
            this.psProtoSearch.Visible = false;
            this.psProtoSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // psDescriptionLabel
            // 
            this.psDescriptionLabel.AutoSize = true;
            this.psDescriptionLabel.Location = new System.Drawing.Point(9, 258);
            this.psDescriptionLabel.Name = "psDescriptionLabel";
            this.psDescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.psDescriptionLabel.TabIndex = 29;
            this.psDescriptionLabel.Text = "Description";
            this.psDescriptionLabel.Visible = false;
            // 
            // psDescriptionSearch
            // 
            this.psDescriptionSearch.Location = new System.Drawing.Point(87, 255);
            this.psDescriptionSearch.Name = "psDescriptionSearch";
            this.psDescriptionSearch.Size = new System.Drawing.Size(191, 20);
            this.psDescriptionSearch.TabIndex = 28;
            this.psDescriptionSearch.Visible = false;
            // 
            // ProtoSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 504);
            this.Controls.Add(this.psDescriptionLabel);
            this.Controls.Add(this.psDescriptionSearch);
            this.Controls.Add(this.psProtoLabel);
            this.Controls.Add(this.psProtoSearch);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.psPortraitSearch);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.psFactionSearch);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.psFeatSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.psScriptTypeDropDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.psScriptSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.psSpellSearch);
            this.Controls.Add(this.psStrategySearch);
            this.Controls.Add(this.psStrategyLabel);
            this.Controls.Add(this.psNameLabel);
            this.Controls.Add(this.psNameSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbTargetObject);
            this.Controls.Add(this.rbTargetProtos);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.btnSearchProto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.psCriterion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProtoSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prototype Search";
            this.Load += new System.EventHandler(this.ProtoSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox psCriterion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchProto;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.RadioButton rbTargetProtos;
        private System.Windows.Forms.RadioButton rbTargetObject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox psNameSearch;
        private System.Windows.Forms.Label psNameLabel;
        private System.Windows.Forms.Label psStrategyLabel;
        private System.Windows.Forms.TextBox psStrategySearch;
        private System.Windows.Forms.TextBox psSpellSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox psScriptSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox psScriptTypeDropDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox psFeatSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox psFactionSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox psPortraitSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label psProtoLabel;
        private System.Windows.Forms.TextBox psProtoSearch;
        private System.Windows.Forms.Label psDescriptionLabel;
        private System.Windows.Forms.TextBox psDescriptionSearch;
    }
}