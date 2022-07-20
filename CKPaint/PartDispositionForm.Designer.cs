
namespace CKPaint
{
    partial class PartDispositionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartDispositionForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.disposePartButton = new System.Windows.Forms.Button();
            this.InspectorTxtBox = new System.Windows.Forms.TextBox();
            this.inspectorTitle = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.WOIDTxtBox = new System.Windows.Forms.TextBox();
            this.WOIDTitle = new System.Windows.Forms.Label();
            this.defectCombo = new System.Windows.Forms.ComboBox();
            this.dispositionCombo = new System.Windows.Forms.ComboBox();
            this.dpuNumBox = new System.Windows.Forms.NumericUpDown();
            this.dpuTitle = new System.Windows.Forms.Label();
            this.dispositionLabel = new System.Windows.Forms.Label();
            this.defectTitle = new System.Windows.Forms.Label();
            this.warningPanel = new System.Windows.Forms.Panel();
            this.warningLogo = new System.Windows.Forms.PictureBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.processComboBox = new System.Windows.Forms.ComboBox();
            this.processLabel = new System.Windows.Forms.Label();
            this.baseLabel = new System.Windows.Forms.Label();
            this.clearLabel = new System.Windows.Forms.Label();
            this.adproLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dpuNumBox)).BeginInit();
            this.warningPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.Color.Tomato;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(415, 512);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(134, 44);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // disposePartButton
            // 
            this.disposePartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.disposePartButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.disposePartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disposePartButton.ForeColor = System.Drawing.Color.White;
            this.disposePartButton.Location = new System.Drawing.Point(12, 512);
            this.disposePartButton.Name = "disposePartButton";
            this.disposePartButton.Size = new System.Drawing.Size(134, 44);
            this.disposePartButton.TabIndex = 6;
            this.disposePartButton.Text = "Dipose Part";
            this.disposePartButton.UseVisualStyleBackColor = false;
            this.disposePartButton.Click += new System.EventHandler(this.disposePartButton_Click);
            // 
            // InspectorTxtBox
            // 
            this.InspectorTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InspectorTxtBox.Location = new System.Drawing.Point(200, 229);
            this.InspectorTxtBox.Name = "InspectorTxtBox";
            this.InspectorTxtBox.ReadOnly = true;
            this.InspectorTxtBox.Size = new System.Drawing.Size(227, 31);
            this.InspectorTxtBox.TabIndex = 2;
            this.InspectorTxtBox.TextChanged += new System.EventHandler(this.InspectorTxtBox_TextChanged);
            // 
            // inspectorTitle
            // 
            this.inspectorTitle.AutoSize = true;
            this.inspectorTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inspectorTitle.ForeColor = System.Drawing.Color.White;
            this.inspectorTitle.Location = new System.Drawing.Point(99, 233);
            this.inspectorTitle.Name = "inspectorTitle";
            this.inspectorTitle.Size = new System.Drawing.Size(102, 24);
            this.inspectorTitle.TabIndex = 16;
            this.inspectorTitle.Text = "Inspector:";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(197, 223);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 15;
            // 
            // WOIDTxtBox
            // 
            this.WOIDTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WOIDTxtBox.Location = new System.Drawing.Point(200, 192);
            this.WOIDTxtBox.Name = "WOIDTxtBox";
            this.WOIDTxtBox.ReadOnly = true;
            this.WOIDTxtBox.Size = new System.Drawing.Size(227, 31);
            this.WOIDTxtBox.TabIndex = 1;
            // 
            // WOIDTitle
            // 
            this.WOIDTitle.AutoSize = true;
            this.WOIDTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WOIDTitle.ForeColor = System.Drawing.Color.White;
            this.WOIDTitle.Location = new System.Drawing.Point(85, 196);
            this.WOIDTitle.Name = "WOIDTitle";
            this.WOIDTitle.Size = new System.Drawing.Size(116, 24);
            this.WOIDTitle.TabIndex = 14;
            this.WOIDTitle.Text = "WOID (LH):";
            // 
            // defectCombo
            // 
            this.defectCombo.AutoCompleteCustomSource.AddRange(new string[] {
            "Dirt",
            "Sag Marks",
            "Touch Marks",
            "Solvent Pop",
            "Light Paint",
            "Pin Holes",
            "Fish Eyes",
            "Mottling",
            "Off Color",
            "Wrong Color",
            "Substrate Flaw",
            "Fibers",
            "Part Swap",
            "Wiper Marks",
            "Orange Peel",
            "Fell of Rack",
            "Paint Run",
            "Light Clear",
            "Others",
            "Adhesion Test Failure",
            "Clear Run",
            "Over Spray",
            "Hose Drag",
            "Damaged by Handling",
            "Peel Off",
            "Poor Finesse",
            "Oil",
            "Porosity",
            "Blister",
            "Scratch",
            "Stain",
            "Dent",
            "Sink",
            "Touch up"});
            this.defectCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defectCombo.Items.AddRange(new object[] {
            "Dirt",
            "Sag Marks",
            "Touch Marks",
            "Solvent Pop",
            "Light Paint",
            "Pin Holes",
            "Fish Eyes",
            "Mottling",
            "Off Color",
            "Wrong Color",
            "Substrate Flaw",
            "Fibers",
            "Part Swap",
            "Wiper Marks",
            "Orange Peel",
            "Fell of Rack",
            "Paint Run",
            "Light Clear",
            "Others",
            "Adhesion Test Failure",
            "Clear Run",
            "Over Spray",
            "Hose Drag",
            "Damaged by Handling",
            "Damaged at ILVS",
            "Peel Off",
            "Poor Finesse",
            "Oil",
            "Porosity",
            "Blister",
            "Scratch",
            "Stain",
            "Dent",
            "Sink",
            "Touch up",
            "Flash",
            "Contamination"});
            this.defectCombo.Location = new System.Drawing.Point(148, 358);
            this.defectCombo.Name = "defectCombo";
            this.defectCombo.Size = new System.Drawing.Size(136, 28);
            this.defectCombo.TabIndex = 3;
            this.defectCombo.SelectedIndexChanged += new System.EventHandler(this.defectCombo_SelectedIndexChanged);
            // 
            // dispositionCombo
            // 
            this.dispositionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dispositionCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispositionCombo.FormattingEnabled = true;
            this.dispositionCombo.Items.AddRange(new object[] {
            "Approved",
            "Finesse",
            "Rework",
            "Scrap"});
            this.dispositionCombo.Location = new System.Drawing.Point(148, 427);
            this.dispositionCombo.Name = "dispositionCombo";
            this.dispositionCombo.Size = new System.Drawing.Size(136, 28);
            this.dispositionCombo.TabIndex = 5;
            this.dispositionCombo.SelectedIndexChanged += new System.EventHandler(this.dispositionCombo_SelectedIndexChanged);
            // 
            // dpuNumBox
            // 
            this.dpuNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpuNumBox.Location = new System.Drawing.Point(148, 392);
            this.dpuNumBox.Name = "dpuNumBox";
            this.dpuNumBox.Size = new System.Drawing.Size(66, 29);
            this.dpuNumBox.TabIndex = 4;
            this.dpuNumBox.ValueChanged += new System.EventHandler(this.dpuNumBox_ValueChanged);
            // 
            // dpuTitle
            // 
            this.dpuTitle.AutoSize = true;
            this.dpuTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpuTitle.ForeColor = System.Drawing.Color.White;
            this.dpuTitle.Location = new System.Drawing.Point(73, 394);
            this.dpuTitle.Name = "dpuTitle";
            this.dpuTitle.Size = new System.Drawing.Size(72, 24);
            this.dpuTitle.TabIndex = 24;
            this.dpuTitle.Text = "DPU\'s:";
            // 
            // dispositionLabel
            // 
            this.dispositionLabel.AutoSize = true;
            this.dispositionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispositionLabel.ForeColor = System.Drawing.Color.White;
            this.dispositionLabel.Location = new System.Drawing.Point(27, 427);
            this.dispositionLabel.Name = "dispositionLabel";
            this.dispositionLabel.Size = new System.Drawing.Size(118, 24);
            this.dispositionLabel.TabIndex = 25;
            this.dispositionLabel.Text = "Disposition:";
            // 
            // defectTitle
            // 
            this.defectTitle.AutoSize = true;
            this.defectTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defectTitle.ForeColor = System.Drawing.Color.White;
            this.defectTitle.Location = new System.Drawing.Point(70, 358);
            this.defectTitle.Name = "defectTitle";
            this.defectTitle.Size = new System.Drawing.Size(75, 24);
            this.defectTitle.TabIndex = 23;
            this.defectTitle.Text = "Defect:";
            // 
            // warningPanel
            // 
            this.warningPanel.BackColor = System.Drawing.Color.Gold;
            this.warningPanel.Controls.Add(this.warningLogo);
            this.warningPanel.Location = new System.Drawing.Point(-1, -1);
            this.warningPanel.Name = "warningPanel";
            this.warningPanel.Size = new System.Drawing.Size(561, 117);
            this.warningPanel.TabIndex = 26;
            // 
            // warningLogo
            // 
            this.warningLogo.BackColor = System.Drawing.Color.Gold;
            this.warningLogo.Image = global::CKPaint.Properties.Resources.warning;
            this.warningLogo.Location = new System.Drawing.Point(257, 13);
            this.warningLogo.Name = "warningLogo";
            this.warningLogo.Size = new System.Drawing.Size(82, 78);
            this.warningLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.warningLogo.TabIndex = 0;
            this.warningLogo.TabStop = false;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.White;
            this.warningLabel.Location = new System.Drawing.Point(2, 119);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(558, 50);
            this.warningLabel.TabIndex = 27;
            this.warningLabel.Text = "Warning: Please verify all the information is correct \r\nfor the disposition on th" +
    "e selected part. ";
            // 
            // processComboBox
            // 
            this.processComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Dirt",
            "Sag Marks",
            "Touch Marks",
            "Solvent Pop",
            "Light Paint",
            "Pin Holes",
            "Fish Eyes",
            "Mottling",
            "Off Color",
            "Wrong Color",
            "Substrate Flaw",
            "Fibers",
            "Part Swap",
            "Wiper Marks",
            "Orange Peel",
            "Fell of Rack",
            "Paint Run",
            "Light Clear",
            "Others",
            "Adhesion Test Failure",
            "Clear Run",
            "Over Spray",
            "Hose Drag",
            "Damaged by Handling",
            "Peel Off",
            "Poor Finesse",
            "Oil",
            "Porosity",
            "Blister",
            "Scratch",
            "Stain",
            "Dent",
            "Sink",
            "Touch up"});
            this.processComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processComboBox.Items.AddRange(new object[] {
            "Manual",
            "Robot"});
            this.processComboBox.Location = new System.Drawing.Point(148, 324);
            this.processComboBox.Name = "processComboBox";
            this.processComboBox.Size = new System.Drawing.Size(136, 28);
            this.processComboBox.TabIndex = 28;
            this.processComboBox.SelectedIndexChanged += new System.EventHandler(this.processComboBox_SelectedIndexChanged);
            // 
            // processLabel
            // 
            this.processLabel.AutoSize = true;
            this.processLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processLabel.ForeColor = System.Drawing.Color.White;
            this.processLabel.Location = new System.Drawing.Point(16, 324);
            this.processLabel.Name = "processLabel";
            this.processLabel.Size = new System.Drawing.Size(133, 24);
            this.processLabel.TabIndex = 29;
            this.processLabel.Text = "Part Process:";
            // 
            // baseLabel
            // 
            this.baseLabel.AutoSize = true;
            this.baseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baseLabel.ForeColor = System.Drawing.Color.White;
            this.baseLabel.Location = new System.Drawing.Point(33, 63);
            this.baseLabel.Name = "baseLabel";
            this.baseLabel.Size = new System.Drawing.Size(62, 24);
            this.baseLabel.TabIndex = 31;
            this.baseLabel.Text = "Base:";
            // 
            // clearLabel
            // 
            this.clearLabel.AutoSize = true;
            this.clearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearLabel.ForeColor = System.Drawing.Color.White;
            this.clearLabel.Location = new System.Drawing.Point(30, 97);
            this.clearLabel.Name = "clearLabel";
            this.clearLabel.Size = new System.Drawing.Size(65, 24);
            this.clearLabel.TabIndex = 32;
            this.clearLabel.Text = "Clear:";
            // 
            // adproLabel
            // 
            this.adproLabel.AutoSize = true;
            this.adproLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adproLabel.ForeColor = System.Drawing.Color.White;
            this.adproLabel.Location = new System.Drawing.Point(22, 29);
            this.adproLabel.Name = "adproLabel";
            this.adproLabel.Size = new System.Drawing.Size(73, 24);
            this.adproLabel.TabIndex = 30;
            this.adproLabel.Text = "Adpro:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.adproLabel);
            this.groupBox1.Controls.Add(this.clearLabel);
            this.groupBox1.Controls.Add(this.baseLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(312, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 131);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Painters";
            // 
            // comboBox3
            // 
            this.comboBox3.AutoCompleteCustomSource.AddRange(new string[] {
            "Dirt",
            "Sag Marks",
            "Touch Marks",
            "Solvent Pop",
            "Light Paint",
            "Pin Holes",
            "Fish Eyes",
            "Mottling",
            "Off Color",
            "Wrong Color",
            "Substrate Flaw",
            "Fibers",
            "Part Swap",
            "Wiper Marks",
            "Orange Peel",
            "Fell of Rack",
            "Paint Run",
            "Light Clear",
            "Others",
            "Adhesion Test Failure",
            "Clear Run",
            "Over Spray",
            "Hose Drag",
            "Damaged by Handling",
            "Peel Off",
            "Poor Finesse",
            "Oil",
            "Porosity",
            "Blister",
            "Scratch",
            "Stain",
            "Dent",
            "Sink",
            "Touch up"});
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.Items.AddRange(new object[] {
            "Manual",
            "Robot"});
            this.comboBox3.Location = new System.Drawing.Point(90, 97);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(136, 28);
            this.comboBox3.TabIndex = 39;
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "Dirt",
            "Sag Marks",
            "Touch Marks",
            "Solvent Pop",
            "Light Paint",
            "Pin Holes",
            "Fish Eyes",
            "Mottling",
            "Off Color",
            "Wrong Color",
            "Substrate Flaw",
            "Fibers",
            "Part Swap",
            "Wiper Marks",
            "Orange Peel",
            "Fell of Rack",
            "Paint Run",
            "Light Clear",
            "Others",
            "Adhesion Test Failure",
            "Clear Run",
            "Over Spray",
            "Hose Drag",
            "Damaged by Handling",
            "Peel Off",
            "Poor Finesse",
            "Oil",
            "Porosity",
            "Blister",
            "Scratch",
            "Stain",
            "Dent",
            "Sink",
            "Touch up"});
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.Items.AddRange(new object[] {
            "Manual",
            "Robot"});
            this.comboBox2.Location = new System.Drawing.Point(90, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(136, 28);
            this.comboBox2.TabIndex = 38;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Dirt",
            "Sag Marks",
            "Touch Marks",
            "Solvent Pop",
            "Light Paint",
            "Pin Holes",
            "Fish Eyes",
            "Mottling",
            "Off Color",
            "Wrong Color",
            "Substrate Flaw",
            "Fibers",
            "Part Swap",
            "Wiper Marks",
            "Orange Peel",
            "Fell of Rack",
            "Paint Run",
            "Light Clear",
            "Others",
            "Adhesion Test Failure",
            "Clear Run",
            "Over Spray",
            "Hose Drag",
            "Damaged by Handling",
            "Peel Off",
            "Poor Finesse",
            "Oil",
            "Porosity",
            "Blister",
            "Scratch",
            "Stain",
            "Dent",
            "Sink",
            "Touch up"});
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.Items.AddRange(new object[] {
            "Manual",
            "Robot"});
            this.comboBox1.Location = new System.Drawing.Point(90, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 28);
            this.comboBox1.TabIndex = 37;
            // 
            // PartDispositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(561, 568);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.processComboBox);
            this.Controls.Add(this.processLabel);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.warningPanel);
            this.Controls.Add(this.defectCombo);
            this.Controls.Add(this.dispositionCombo);
            this.Controls.Add(this.dpuNumBox);
            this.Controls.Add(this.dpuTitle);
            this.Controls.Add(this.dispositionLabel);
            this.Controls.Add(this.defectTitle);
            this.Controls.Add(this.InspectorTxtBox);
            this.Controls.Add(this.inspectorTitle);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.WOIDTxtBox);
            this.Controls.Add(this.WOIDTitle);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.disposePartButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PartDispositionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLC Paint - Part Disposition Form";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PartDispositionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dpuNumBox)).EndInit();
            this.warningPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warningLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button disposePartButton;
        private System.Windows.Forms.TextBox InspectorTxtBox;
        private System.Windows.Forms.Label inspectorTitle;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox WOIDTxtBox;
        private System.Windows.Forms.Label WOIDTitle;
        private System.Windows.Forms.ComboBox defectCombo;
        private System.Windows.Forms.ComboBox dispositionCombo;
        private System.Windows.Forms.NumericUpDown dpuNumBox;
        private System.Windows.Forms.Label dpuTitle;
        private System.Windows.Forms.Label dispositionLabel;
        private System.Windows.Forms.Label defectTitle;
        private System.Windows.Forms.PictureBox warningLogo;
        private System.Windows.Forms.Panel warningPanel;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.ComboBox processComboBox;
        private System.Windows.Forms.Label processLabel;
        private System.Windows.Forms.Label baseLabel;
        private System.Windows.Forms.Label clearLabel;
        private System.Windows.Forms.Label adproLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}