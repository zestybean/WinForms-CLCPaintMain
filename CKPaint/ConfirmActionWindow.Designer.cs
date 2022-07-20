
namespace CKPaint
{
    partial class ConfirmActionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmActionWindow));
            this.warningPanel = new System.Windows.Forms.Panel();
            this.warningLogo = new System.Windows.Forms.PictureBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.jobNumberLbl = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.codeDescriptionLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.woidLbl = new System.Windows.Forms.Label();
            this.woidTxtLbl = new System.Windows.Forms.Label();
            this.partNumTxtLbl = new System.Windows.Forms.Label();
            this.woidRHTxtLbl = new System.Windows.Forms.Label();
            this.woidRHLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.partNumRHTxtLbl = new System.Windows.Forms.Label();
            this.instructionBox = new System.Windows.Forms.PictureBox();
            this.warningPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // warningPanel
            // 
            this.warningPanel.BackColor = System.Drawing.Color.Gold;
            this.warningPanel.Controls.Add(this.warningLogo);
            this.warningPanel.Location = new System.Drawing.Point(0, -2);
            this.warningPanel.Name = "warningPanel";
            this.warningPanel.Size = new System.Drawing.Size(513, 104);
            this.warningPanel.TabIndex = 1;
            // 
            // warningLogo
            // 
            this.warningLogo.BackColor = System.Drawing.Color.Gold;
            this.warningLogo.Image = global::CKPaint.Properties.Resources.warning;
            this.warningLogo.Location = new System.Drawing.Point(219, 14);
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
            this.warningLabel.Location = new System.Drawing.Point(4, 105);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(514, 50);
            this.warningLabel.TabIndex = 2;
            this.warningLabel.Text = "Warning: Please confirm the Part Number/WOID\r\nfor following action on the part. ";
            // 
            // jobNumberLbl
            // 
            this.jobNumberLbl.AutoSize = true;
            this.jobNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobNumberLbl.ForeColor = System.Drawing.Color.White;
            this.jobNumberLbl.Location = new System.Drawing.Point(39, 172);
            this.jobNumberLbl.Name = "jobNumberLbl";
            this.jobNumberLbl.Size = new System.Drawing.Size(157, 25);
            this.jobNumberLbl.TabIndex = 3;
            this.jobNumberLbl.Text = "Part Number: \r";
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.confirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(9, 533);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(134, 44);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "Print Label";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Tomato;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.White;
            this.cancelButton.Location = new System.Drawing.Point(372, 533);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(134, 44);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // codeDescriptionLabel
            // 
            this.codeDescriptionLabel.AutoSize = true;
            this.codeDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeDescriptionLabel.ForeColor = System.Drawing.Color.White;
            this.codeDescriptionLabel.Location = new System.Drawing.Point(72, 339);
            this.codeDescriptionLabel.Name = "codeDescriptionLabel";
            this.codeDescriptionLabel.Size = new System.Drawing.Size(384, 48);
            this.codeDescriptionLabel.TabIndex = 6;
            this.codeDescriptionLabel.Text = "This is an elevated action please enter\r\nthe password to override the procedure.";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(130, 441);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(263, 29);
            this.passwordTextBox.TabIndex = 7;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLabel.ForeColor = System.Drawing.Color.White;
            this.codeLabel.Location = new System.Drawing.Point(126, 414);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(106, 24);
            this.codeLabel.TabIndex = 8;
            this.codeLabel.Text = "Password:";
            // 
            // woidLbl
            // 
            this.woidLbl.AutoSize = true;
            this.woidLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.woidLbl.ForeColor = System.Drawing.Color.White;
            this.woidLbl.Location = new System.Drawing.Point(286, 172);
            this.woidLbl.Name = "woidLbl";
            this.woidLbl.Size = new System.Drawing.Size(79, 25);
            this.woidLbl.TabIndex = 9;
            this.woidLbl.Text = "WOID:";
            // 
            // woidTxtLbl
            // 
            this.woidTxtLbl.AutoSize = true;
            this.woidTxtLbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.woidTxtLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.woidTxtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.woidTxtLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.woidTxtLbl.Location = new System.Drawing.Point(328, 197);
            this.woidTxtLbl.Name = "woidTxtLbl";
            this.woidTxtLbl.Size = new System.Drawing.Size(99, 31);
            this.woidTxtLbl.TabIndex = 10;
            this.woidTxtLbl.Text = "000000";
            // 
            // partNumTxtLbl
            // 
            this.partNumTxtLbl.AutoSize = true;
            this.partNumTxtLbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.partNumTxtLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.partNumTxtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNumTxtLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.partNumTxtLbl.Location = new System.Drawing.Point(97, 197);
            this.partNumTxtLbl.Name = "partNumTxtLbl";
            this.partNumTxtLbl.Size = new System.Drawing.Size(99, 31);
            this.partNumTxtLbl.TabIndex = 11;
            this.partNumTxtLbl.Text = "000000";
            // 
            // woidRHTxtLbl
            // 
            this.woidRHTxtLbl.AutoSize = true;
            this.woidRHTxtLbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.woidRHTxtLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.woidRHTxtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.woidRHTxtLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.woidRHTxtLbl.Location = new System.Drawing.Point(328, 253);
            this.woidRHTxtLbl.Name = "woidRHTxtLbl";
            this.woidRHTxtLbl.Size = new System.Drawing.Size(99, 31);
            this.woidRHTxtLbl.TabIndex = 14;
            this.woidRHTxtLbl.Text = "000000";
            // 
            // woidRHLbl
            // 
            this.woidRHLbl.AutoSize = true;
            this.woidRHLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.woidRHLbl.ForeColor = System.Drawing.Color.White;
            this.woidRHLbl.Location = new System.Drawing.Point(287, 228);
            this.woidRHLbl.Name = "woidRHLbl";
            this.woidRHLbl.Size = new System.Drawing.Size(118, 25);
            this.woidRHLbl.TabIndex = 13;
            this.woidRHLbl.Text = "WOID RH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(39, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Part Number RH: \r";
            // 
            // partNumRHTxtLbl
            // 
            this.partNumRHTxtLbl.AutoSize = true;
            this.partNumRHTxtLbl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.partNumRHTxtLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.partNumRHTxtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partNumRHTxtLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.partNumRHTxtLbl.Location = new System.Drawing.Point(97, 253);
            this.partNumRHTxtLbl.Name = "partNumRHTxtLbl";
            this.partNumRHTxtLbl.Size = new System.Drawing.Size(99, 31);
            this.partNumRHTxtLbl.TabIndex = 17;
            this.partNumRHTxtLbl.Text = "000000";
            // 
            // instructionBox
            // 
            this.instructionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.instructionBox.Image = global::CKPaint.Properties.Resources.sample;
            this.instructionBox.Location = new System.Drawing.Point(9, 305);
            this.instructionBox.Name = "instructionBox";
            this.instructionBox.Size = new System.Drawing.Size(497, 213);
            this.instructionBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.instructionBox.TabIndex = 18;
            this.instructionBox.TabStop = false;
            // 
            // ConfirmActionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(513, 589);
            this.Controls.Add(this.partNumRHTxtLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.woidRHTxtLbl);
            this.Controls.Add(this.woidRHLbl);
            this.Controls.Add(this.partNumTxtLbl);
            this.Controls.Add(this.woidTxtLbl);
            this.Controls.Add(this.woidLbl);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.codeDescriptionLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.jobNumberLbl);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.warningPanel);
            this.Controls.Add(this.instructionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmActionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CK Paint - Confirm Action";
            this.Load += new System.EventHandler(this.ConfirmActionWindow_Load);
            this.warningPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.warningLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox warningLogo;
        private System.Windows.Forms.Panel warningPanel;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label jobNumberLbl;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label codeDescriptionLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.Label woidLbl;
        private System.Windows.Forms.Label woidTxtLbl;
        private System.Windows.Forms.Label partNumTxtLbl;
        private System.Windows.Forms.Label woidRHTxtLbl;
        private System.Windows.Forms.Label woidRHLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label partNumRHTxtLbl;
        private System.Windows.Forms.PictureBox instructionBox;
    }
}