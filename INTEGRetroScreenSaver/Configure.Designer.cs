namespace INTEGRetroScreenSaver
{
    partial class Configure
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
            this.btnAbout = new System.Windows.Forms.Button();
            this.gbInternals = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.txtSteps = new System.Windows.Forms.TextBox();
            this.lblSteps = new System.Windows.Forms.Label();
            this.lblMoveInterval2 = new System.Windows.Forms.Label();
            this.txtMoveInterval = new System.Windows.Forms.TextBox();
            this.lblMoveInterval1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSavePreferences = new System.Windows.Forms.Button();
            this.gbTrolls = new System.Windows.Forms.GroupBox();
            this.btnDeleteTroll = new System.Windows.Forms.Button();
            this.btnNewTroll = new System.Windows.Forms.Button();
            this.btnChangeTrollName = new System.Windows.Forms.Button();
            this.btnColour3 = new System.Windows.Forms.Button();
            this.btnColour2 = new System.Windows.Forms.Button();
            this.btnColour1 = new System.Windows.Forms.Button();
            this.txtTrollName = new System.Windows.Forms.TextBox();
            this.lblTrollName = new System.Windows.Forms.Label();
            this.listTrolls = new System.Windows.Forms.ListBox();
            this.gbInternals.SuspendLayout();
            this.gbTrolls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(12, 303);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(89, 23);
            this.btnAbout.TabIndex = 0;
            this.btnAbout.Text = "About INTEG...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // gbInternals
            // 
            this.gbInternals.Controls.Add(this.btnPreview);
            this.gbInternals.Controls.Add(this.txtSteps);
            this.gbInternals.Controls.Add(this.lblSteps);
            this.gbInternals.Controls.Add(this.lblMoveInterval2);
            this.gbInternals.Controls.Add(this.txtMoveInterval);
            this.gbInternals.Controls.Add(this.lblMoveInterval1);
            this.gbInternals.Location = new System.Drawing.Point(12, 12);
            this.gbInternals.Name = "gbInternals";
            this.gbInternals.Size = new System.Drawing.Size(375, 100);
            this.gbInternals.TabIndex = 1;
            this.gbInternals.TabStop = false;
            this.gbInternals.Text = "Internals";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(277, 67);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(91, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(213, 49);
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.Size = new System.Drawing.Size(44, 20);
            this.txtSteps.TabIndex = 4;
            this.txtSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Location = new System.Drawing.Point(26, 52);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(181, 13);
            this.lblSteps.TabIndex = 3;
            this.lblSteps.Text = "No. of Steps before direction change";
            // 
            // lblMoveInterval2
            // 
            this.lblMoveInterval2.AutoSize = true;
            this.lblMoveInterval2.Location = new System.Drawing.Point(263, 28);
            this.lblMoveInterval2.Name = "lblMoveInterval2";
            this.lblMoveInterval2.Size = new System.Drawing.Size(20, 13);
            this.lblMoveInterval2.TabIndex = 2;
            this.lblMoveInterval2.Text = "ms";
            // 
            // txtMoveInterval
            // 
            this.txtMoveInterval.Location = new System.Drawing.Point(213, 24);
            this.txtMoveInterval.Name = "txtMoveInterval";
            this.txtMoveInterval.Size = new System.Drawing.Size(44, 20);
            this.txtMoveInterval.TabIndex = 1;
            this.txtMoveInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMoveInterval1
            // 
            this.lblMoveInterval1.AutoSize = true;
            this.lblMoveInterval1.Location = new System.Drawing.Point(106, 28);
            this.lblMoveInterval1.Name = "lblMoveInterval1";
            this.lblMoveInterval1.Size = new System.Drawing.Size(101, 13);
            this.lblMoveInterval1.TabIndex = 0;
            this.lblMoveInterval1.Text = "Move Timer Interval";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(108, 303);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(111, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset to Defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSavePreferences
            // 
            this.btnSavePreferences.Location = new System.Drawing.Point(225, 303);
            this.btnSavePreferences.Name = "btnSavePreferences";
            this.btnSavePreferences.Size = new System.Drawing.Size(162, 23);
            this.btnSavePreferences.TabIndex = 3;
            this.btnSavePreferences.Text = "&Save Preferences";
            this.btnSavePreferences.UseVisualStyleBackColor = true;
            this.btnSavePreferences.Click += new System.EventHandler(this.btnSavePreferences_Click);
            // 
            // gbTrolls
            // 
            this.gbTrolls.Controls.Add(this.btnDeleteTroll);
            this.gbTrolls.Controls.Add(this.btnNewTroll);
            this.gbTrolls.Controls.Add(this.btnChangeTrollName);
            this.gbTrolls.Controls.Add(this.btnColour3);
            this.gbTrolls.Controls.Add(this.btnColour2);
            this.gbTrolls.Controls.Add(this.btnColour1);
            this.gbTrolls.Controls.Add(this.txtTrollName);
            this.gbTrolls.Controls.Add(this.lblTrollName);
            this.gbTrolls.Controls.Add(this.listTrolls);
            this.gbTrolls.Location = new System.Drawing.Point(12, 124);
            this.gbTrolls.Name = "gbTrolls";
            this.gbTrolls.Size = new System.Drawing.Size(375, 163);
            this.gbTrolls.TabIndex = 4;
            this.gbTrolls.TabStop = false;
            this.gbTrolls.Text = "Trolls";
            // 
            // btnDeleteTroll
            // 
            this.btnDeleteTroll.Location = new System.Drawing.Point(109, 131);
            this.btnDeleteTroll.Name = "btnDeleteTroll";
            this.btnDeleteTroll.Size = new System.Drawing.Size(75, 22);
            this.btnDeleteTroll.TabIndex = 8;
            this.btnDeleteTroll.Text = "Delete Troll";
            this.btnDeleteTroll.UseVisualStyleBackColor = true;
            this.btnDeleteTroll.Click += new System.EventHandler(this.btnDeleteTroll_Click);
            // 
            // btnNewTroll
            // 
            this.btnNewTroll.Location = new System.Drawing.Point(14, 131);
            this.btnNewTroll.Name = "btnNewTroll";
            this.btnNewTroll.Size = new System.Drawing.Size(75, 21);
            this.btnNewTroll.TabIndex = 7;
            this.btnNewTroll.Text = "&New Troll";
            this.btnNewTroll.UseVisualStyleBackColor = true;
            this.btnNewTroll.Click += new System.EventHandler(this.btnNewTroll_Click);
            // 
            // btnChangeTrollName
            // 
            this.btnChangeTrollName.Location = new System.Drawing.Point(216, 62);
            this.btnChangeTrollName.Name = "btnChangeTrollName";
            this.btnChangeTrollName.Size = new System.Drawing.Size(150, 23);
            this.btnChangeTrollName.TabIndex = 6;
            this.btnChangeTrollName.Text = "Save Name Change";
            this.btnChangeTrollName.UseVisualStyleBackColor = true;
            this.btnChangeTrollName.Click += new System.EventHandler(this.btnChangeTrollName_Click);
            // 
            // btnColour3
            // 
            this.btnColour3.Location = new System.Drawing.Point(294, 131);
            this.btnColour3.Name = "btnColour3";
            this.btnColour3.Size = new System.Drawing.Size(75, 22);
            this.btnColour3.TabIndex = 5;
            this.btnColour3.Text = "Colour #3";
            this.btnColour3.UseVisualStyleBackColor = true;
            this.btnColour3.Click += new System.EventHandler(this.btnColour3_Click);
            // 
            // btnColour2
            // 
            this.btnColour2.Location = new System.Drawing.Point(216, 131);
            this.btnColour2.Name = "btnColour2";
            this.btnColour2.Size = new System.Drawing.Size(75, 22);
            this.btnColour2.TabIndex = 4;
            this.btnColour2.Text = "Colour #2";
            this.btnColour2.UseVisualStyleBackColor = true;
            this.btnColour2.Click += new System.EventHandler(this.btnColour2_Click);
            // 
            // btnColour1
            // 
            this.btnColour1.Location = new System.Drawing.Point(294, 103);
            this.btnColour1.Name = "btnColour1";
            this.btnColour1.Size = new System.Drawing.Size(75, 22);
            this.btnColour1.TabIndex = 3;
            this.btnColour1.Text = "Colour #1";
            this.btnColour1.UseVisualStyleBackColor = true;
            this.btnColour1.Click += new System.EventHandler(this.btnColour1_Click);
            // 
            // txtTrollName
            // 
            this.txtTrollName.Location = new System.Drawing.Point(216, 35);
            this.txtTrollName.Name = "txtTrollName";
            this.txtTrollName.Size = new System.Drawing.Size(150, 20);
            this.txtTrollName.TabIndex = 2;
            // 
            // lblTrollName
            // 
            this.lblTrollName.AutoSize = true;
            this.lblTrollName.Location = new System.Drawing.Point(213, 19);
            this.lblTrollName.Name = "lblTrollName";
            this.lblTrollName.Size = new System.Drawing.Size(88, 13);
            this.lblTrollName.TabIndex = 1;
            this.lblTrollName.Text = "Edit Troll Name...";
            // 
            // listTrolls
            // 
            this.listTrolls.FormattingEnabled = true;
            this.listTrolls.Location = new System.Drawing.Point(6, 19);
            this.listTrolls.Name = "listTrolls";
            this.listTrolls.Size = new System.Drawing.Size(201, 108);
            this.listTrolls.TabIndex = 0;
            this.listTrolls.SelectedIndexChanged += new System.EventHandler(this.listTrolls_SelectedIndexChanged);
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 338);
            this.Controls.Add(this.gbTrolls);
            this.Controls.Add(this.btnSavePreferences);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.gbInternals);
            this.Controls.Add(this.btnAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Configure";
            this.Text = "Configure INTEG Retro Screen Saver...";
            this.gbInternals.ResumeLayout(false);
            this.gbInternals.PerformLayout();
            this.gbTrolls.ResumeLayout(false);
            this.gbTrolls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.GroupBox gbInternals;
        private System.Windows.Forms.Label lblMoveInterval2;
        private System.Windows.Forms.TextBox txtMoveInterval;
        private System.Windows.Forms.Label lblMoveInterval1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSteps;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.Button btnSavePreferences;
        private System.Windows.Forms.GroupBox gbTrolls;
        private System.Windows.Forms.ListBox listTrolls;
        private System.Windows.Forms.TextBox txtTrollName;
        private System.Windows.Forms.Label lblTrollName;
        private System.Windows.Forms.Button btnColour3;
        private System.Windows.Forms.Button btnColour2;
        private System.Windows.Forms.Button btnColour1;
        private System.Windows.Forms.Button btnChangeTrollName;
        private System.Windows.Forms.Button btnNewTroll;
        private System.Windows.Forms.Button btnDeleteTroll;
        private System.Windows.Forms.Button btnPreview;
    }
}