
namespace CKPaint
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.settingsLabel = new System.Windows.Forms.Label();
            this.stationLabel = new System.Windows.Forms.Label();
            this.settingsDescriptionLabel = new System.Windows.Forms.Label();
            this.printerLabel = new System.Windows.Forms.Label();
            this.printerTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.plantLabel = new System.Windows.Forms.Label();
            this.plantComboBox = new System.Windows.Forms.ComboBox();
            this.siteLabel = new System.Windows.Forms.Label();
            this.siteTextBox = new System.Windows.Forms.TextBox();
            this.stationComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.plcLabel = new System.Windows.Forms.Label();
            this.plcTextBox = new System.Windows.Forms.TextBox();
            this.tagLabel = new System.Windows.Forms.Label();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.tagValueReadLabel = new System.Windows.Forms.Label();
            this.tagValueReadTextBox = new System.Windows.Forms.TextBox();
            this.readButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.tagValueWriteTextBox = new System.Windows.Forms.TextBox();
            this.tagValueWriteLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // settingsLabel
            // 
            this.settingsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.ForeColor = System.Drawing.Color.White;
            this.settingsLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.settingsLabel.Location = new System.Drawing.Point(0, 0);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(609, 25);
            this.settingsLabel.TabIndex = 3;
            this.settingsLabel.Text = "Settings Window";
            this.settingsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // stationLabel
            // 
            this.stationLabel.AutoSize = true;
            this.stationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationLabel.ForeColor = System.Drawing.Color.White;
            this.stationLabel.Location = new System.Drawing.Point(145, 121);
            this.stationLabel.Name = "stationLabel";
            this.stationLabel.Size = new System.Drawing.Size(93, 25);
            this.stationLabel.TabIndex = 11;
            this.stationLabel.Text = "Station:";
            // 
            // settingsDescriptionLabel
            // 
            this.settingsDescriptionLabel.AutoSize = true;
            this.settingsDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsDescriptionLabel.ForeColor = System.Drawing.Color.White;
            this.settingsDescriptionLabel.Location = new System.Drawing.Point(129, 60);
            this.settingsDescriptionLabel.Name = "settingsDescriptionLabel";
            this.settingsDescriptionLabel.Size = new System.Drawing.Size(329, 48);
            this.settingsDescriptionLabel.TabIndex = 9;
            this.settingsDescriptionLabel.Text = "Please select or edit the following \r\nsettings for the application.";
            // 
            // printerLabel
            // 
            this.printerLabel.AutoSize = true;
            this.printerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerLabel.ForeColor = System.Drawing.Color.White;
            this.printerLabel.Location = new System.Drawing.Point(145, 184);
            this.printerLabel.Name = "printerLabel";
            this.printerLabel.Size = new System.Drawing.Size(89, 25);
            this.printerLabel.TabIndex = 13;
            this.printerLabel.Text = "Printer:";
            // 
            // printerTextBox
            // 
            this.printerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printerTextBox.Location = new System.Drawing.Point(150, 212);
            this.printerTextBox.Name = "printerTextBox";
            this.printerTextBox.Size = new System.Drawing.Size(263, 29);
            this.printerTextBox.TabIndex = 12;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Tomato;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(341, 658);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(159, 44);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(75, 658);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(159, 44);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // plantLabel
            // 
            this.plantLabel.AutoSize = true;
            this.plantLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plantLabel.ForeColor = System.Drawing.Color.White;
            this.plantLabel.Location = new System.Drawing.Point(145, 248);
            this.plantLabel.Name = "plantLabel";
            this.plantLabel.Size = new System.Drawing.Size(73, 25);
            this.plantLabel.TabIndex = 17;
            this.plantLabel.Text = "Plant:";
            // 
            // plantComboBox
            // 
            this.plantComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.plantComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.plantComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plantComboBox.Items.AddRange(new object[] {
            "BV",
            "MP",
            "GP"});
            this.plantComboBox.Location = new System.Drawing.Point(150, 276);
            this.plantComboBox.Name = "plantComboBox";
            this.plantComboBox.Size = new System.Drawing.Size(263, 32);
            this.plantComboBox.TabIndex = 18;
            this.plantComboBox.SelectedIndexChanged += new System.EventHandler(this.plantComboBox_SelectedIndexChanged);
            // 
            // siteLabel
            // 
            this.siteLabel.AutoSize = true;
            this.siteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siteLabel.ForeColor = System.Drawing.Color.White;
            this.siteLabel.Location = new System.Drawing.Point(145, 314);
            this.siteLabel.Name = "siteLabel";
            this.siteLabel.Size = new System.Drawing.Size(60, 25);
            this.siteLabel.TabIndex = 20;
            this.siteLabel.Text = "Site:";
            // 
            // siteTextBox
            // 
            this.siteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siteTextBox.Location = new System.Drawing.Point(150, 342);
            this.siteTextBox.Name = "siteTextBox";
            this.siteTextBox.ReadOnly = true;
            this.siteTextBox.Size = new System.Drawing.Size(263, 29);
            this.siteTextBox.TabIndex = 19;
            // 
            // stationComboBox
            // 
            this.stationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stationComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stationComboBox.FormattingEnabled = true;
            this.stationComboBox.Items.AddRange(new object[] {
            "MAINLINE",
            "SPOVEN 1",
            "SPOVEN 2",
            "SPOVEN 3",
            "QA",
            "USER"});
            this.stationComboBox.Location = new System.Drawing.Point(150, 149);
            this.stationComboBox.Name = "stationComboBox";
            this.stationComboBox.Size = new System.Drawing.Size(263, 32);
            this.stationComboBox.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(145, 584);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(150, 612);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(263, 29);
            this.passwordTextBox.TabIndex = 22;
            // 
            // plcLabel
            // 
            this.plcLabel.AutoSize = true;
            this.plcLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plcLabel.ForeColor = System.Drawing.Color.White;
            this.plcLabel.Location = new System.Drawing.Point(145, 380);
            this.plcLabel.Name = "plcLabel";
            this.plcLabel.Size = new System.Drawing.Size(245, 25);
            this.plcLabel.TabIndex = 25;
            this.plcLabel.Text = "Paint PLC IP Address:";
            // 
            // plcTextBox
            // 
            this.plcTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plcTextBox.Location = new System.Drawing.Point(150, 408);
            this.plcTextBox.Name = "plcTextBox";
            this.plcTextBox.Size = new System.Drawing.Size(263, 29);
            this.plcTextBox.TabIndex = 24;
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagLabel.ForeColor = System.Drawing.Color.White;
            this.tagLabel.Location = new System.Drawing.Point(145, 449);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(171, 25);
            this.tagLabel.TabIndex = 27;
            this.tagLabel.Text = "Paint PLC Tag:";
            // 
            // tagTextBox
            // 
            this.tagTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagTextBox.Location = new System.Drawing.Point(150, 477);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(263, 29);
            this.tagTextBox.TabIndex = 26;
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.BackColor = System.Drawing.Color.Yellow;
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.ForeColor = System.Drawing.Color.Black;
            this.connectButton.Location = new System.Drawing.Point(421, 406);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(159, 32);
            this.connectButton.TabIndex = 28;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // tagValueReadLabel
            // 
            this.tagValueReadLabel.AutoSize = true;
            this.tagValueReadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagValueReadLabel.ForeColor = System.Drawing.Color.White;
            this.tagValueReadLabel.Location = new System.Drawing.Point(414, 449);
            this.tagValueReadLabel.Name = "tagValueReadLabel";
            this.tagValueReadLabel.Size = new System.Drawing.Size(188, 25);
            this.tagValueReadLabel.TabIndex = 29;
            this.tagValueReadLabel.Text = "Tag Value Read:";
            // 
            // tagValueReadTextBox
            // 
            this.tagValueReadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagValueReadTextBox.Location = new System.Drawing.Point(419, 477);
            this.tagValueReadTextBox.Name = "tagValueReadTextBox";
            this.tagValueReadTextBox.ReadOnly = true;
            this.tagValueReadTextBox.Size = new System.Drawing.Size(153, 29);
            this.tagValueReadTextBox.TabIndex = 30;
            // 
            // readButton
            // 
            this.readButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readButton.BackColor = System.Drawing.Color.Yellow;
            this.readButton.Enabled = false;
            this.readButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readButton.ForeColor = System.Drawing.Color.Black;
            this.readButton.Location = new System.Drawing.Point(419, 511);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(130, 32);
            this.readButton.TabIndex = 31;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.readButtton_Click);
            // 
            // writeButton
            // 
            this.writeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.writeButton.BackColor = System.Drawing.Color.Yellow;
            this.writeButton.Enabled = false;
            this.writeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeButton.ForeColor = System.Drawing.Color.Black;
            this.writeButton.Location = new System.Drawing.Point(419, 609);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(130, 32);
            this.writeButton.TabIndex = 34;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = false;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // tagValueWriteTextBox
            // 
            this.tagValueWriteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagValueWriteTextBox.Location = new System.Drawing.Point(419, 575);
            this.tagValueWriteTextBox.Name = "tagValueWriteTextBox";
            this.tagValueWriteTextBox.Size = new System.Drawing.Size(153, 29);
            this.tagValueWriteTextBox.TabIndex = 33;
            this.tagValueWriteTextBox.TextChanged += new System.EventHandler(this.tagValueWriteTextBox_TextChanged);
            // 
            // tagValueWriteLabel
            // 
            this.tagValueWriteLabel.AutoSize = true;
            this.tagValueWriteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagValueWriteLabel.ForeColor = System.Drawing.Color.White;
            this.tagValueWriteLabel.Location = new System.Drawing.Point(414, 547);
            this.tagValueWriteLabel.Name = "tagValueWriteLabel";
            this.tagValueWriteLabel.Size = new System.Drawing.Size(188, 25);
            this.tagValueWriteLabel.TabIndex = 32;
            this.tagValueWriteLabel.Text = "Tag Value Write:";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(609, 714);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.tagValueWriteTextBox);
            this.Controls.Add(this.tagValueWriteLabel);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.tagValueReadTextBox);
            this.Controls.Add(this.tagValueReadLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.tagTextBox);
            this.Controls.Add(this.plcLabel);
            this.Controls.Add(this.plcTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.stationComboBox);
            this.Controls.Add(this.siteLabel);
            this.Controls.Add(this.siteTextBox);
            this.Controls.Add(this.plantComboBox);
            this.Controls.Add(this.plantLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.printerLabel);
            this.Controls.Add(this.printerTextBox);
            this.Controls.Add(this.stationLabel);
            this.Controls.Add(this.settingsDescriptionLabel);
            this.Controls.Add(this.settingsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CK Paint - Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label stationLabel;
        private System.Windows.Forms.Label settingsDescriptionLabel;
        private System.Windows.Forms.Label printerLabel;
        private System.Windows.Forms.TextBox printerTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label plantLabel;
        private System.Windows.Forms.ComboBox plantComboBox;
        private System.Windows.Forms.Label siteLabel;
        private System.Windows.Forms.TextBox siteTextBox;
        private System.Windows.Forms.ComboBox stationComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label plcLabel;
        private System.Windows.Forms.TextBox plcTextBox;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label tagValueReadLabel;
        private System.Windows.Forms.TextBox tagValueReadTextBox;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.TextBox tagValueWriteTextBox;
        private System.Windows.Forms.Label tagValueWriteLabel;
    }
}