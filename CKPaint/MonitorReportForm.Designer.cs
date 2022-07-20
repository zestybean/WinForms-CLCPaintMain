
namespace CKPaint
{
    partial class MonitorReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorReportForm));
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.fromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.generateButton = new System.Windows.Forms.Button();
            this.goToButton = new System.Windows.Forms.Button();
            this.reportBox = new System.Windows.Forms.GroupBox();
            this.monitorAllRadioBtn = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.partInlineHistoryReportBtn = new System.Windows.Forms.RadioButton();
            this.reworkOnFloorRadioBtn = new System.Windows.Forms.RadioButton();
            this.dispositionReportRadioBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.reportBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeStart.Location = new System.Drawing.Point(1132, 32);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(195, 22);
            this.dateTimeStart.TabIndex = 0;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeEnd.Location = new System.Drawing.Point(1132, 60);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(195, 22);
            this.dateTimeEnd.TabIndex = 1;
            // 
            // fromLabel
            // 
            this.fromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fromLabel.Location = new System.Drawing.Point(1082, 32);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(43, 16);
            this.fromLabel.TabIndex = 2;
            this.fromLabel.Text = "Start:";
            // 
            // ToLabel
            // 
            this.ToLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToLabel.AutoSize = true;
            this.ToLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ToLabel.Location = new System.Drawing.Point(1087, 60);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(38, 16);
            this.ToLabel.TabIndex = 3;
            this.ToLabel.Text = "End:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1315, 761);
            this.dataGridView1.TabIndex = 4;
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(936, 9);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(117, 73);
            this.generateButton.TabIndex = 5;
            this.generateButton.Text = "Generate Report";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // goToButton
            // 
            this.goToButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToButton.Location = new System.Drawing.Point(12, 9);
            this.goToButton.Name = "goToButton";
            this.goToButton.Size = new System.Drawing.Size(103, 73);
            this.goToButton.TabIndex = 7;
            this.goToButton.Text = "Report File\r\nShortcut";
            this.goToButton.UseVisualStyleBackColor = true;
            this.goToButton.Click += new System.EventHandler(this.goToButton_Click);
            // 
            // reportBox
            // 
            this.reportBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportBox.Controls.Add(this.monitorAllRadioBtn);
            this.reportBox.Controls.Add(this.radioButton1);
            this.reportBox.Controls.Add(this.radioButton2);
            this.reportBox.Controls.Add(this.radioButton3);
            this.reportBox.Controls.Add(this.partInlineHistoryReportBtn);
            this.reportBox.Controls.Add(this.reworkOnFloorRadioBtn);
            this.reportBox.Controls.Add(this.dispositionReportRadioBtn);
            this.reportBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reportBox.Location = new System.Drawing.Point(121, 9);
            this.reportBox.Name = "reportBox";
            this.reportBox.Size = new System.Drawing.Size(809, 73);
            this.reportBox.TabIndex = 8;
            this.reportBox.TabStop = false;
            this.reportBox.Text = "Report/Monitor Type";
            // 
            // monitorAllRadioBtn
            // 
            this.monitorAllRadioBtn.AutoSize = true;
            this.monitorAllRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitorAllRadioBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.monitorAllRadioBtn.Location = new System.Drawing.Point(161, 44);
            this.monitorAllRadioBtn.Name = "monitorAllRadioBtn";
            this.monitorAllRadioBtn.Size = new System.Drawing.Size(95, 20);
            this.monitorAllRadioBtn.TabIndex = 6;
            this.monitorAllRadioBtn.TabStop = true;
            this.monitorAllRadioBtn.Text = "Monitor (All)";
            this.monitorAllRadioBtn.UseVisualStyleBackColor = true;
            this.monitorAllRadioBtn.CheckedChanged += new System.EventHandler(this.monitorAllRadioBtn_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton1.Location = new System.Drawing.Point(421, 44);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(129, 20);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Spoven 1 Monitor";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton2.Location = new System.Drawing.Point(276, 44);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(122, 20);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Mainline Monitor";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButton3.Location = new System.Drawing.Point(573, 44);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(129, 20);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Spoven 3 Monitor";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // partInlineHistoryReportBtn
            // 
            this.partInlineHistoryReportBtn.AutoSize = true;
            this.partInlineHistoryReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partInlineHistoryReportBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.partInlineHistoryReportBtn.Location = new System.Drawing.Point(355, 15);
            this.partInlineHistoryReportBtn.Name = "partInlineHistoryReportBtn";
            this.partInlineHistoryReportBtn.Size = new System.Drawing.Size(166, 20);
            this.partInlineHistoryReportBtn.TabIndex = 2;
            this.partInlineHistoryReportBtn.TabStop = true;
            this.partInlineHistoryReportBtn.Text = "Inline History Report";
            this.partInlineHistoryReportBtn.UseVisualStyleBackColor = true;
            // 
            // reworkOnFloorRadioBtn
            // 
            this.reworkOnFloorRadioBtn.AutoSize = true;
            this.reworkOnFloorRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reworkOnFloorRadioBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.reworkOnFloorRadioBtn.Location = new System.Drawing.Point(161, 15);
            this.reworkOnFloorRadioBtn.Name = "reworkOnFloorRadioBtn";
            this.reworkOnFloorRadioBtn.Size = new System.Drawing.Size(187, 20);
            this.reworkOnFloorRadioBtn.TabIndex = 1;
            this.reworkOnFloorRadioBtn.TabStop = true;
            this.reworkOnFloorRadioBtn.Text = "Rework OnFloor Report";
            this.reworkOnFloorRadioBtn.UseVisualStyleBackColor = true;
            // 
            // dispositionReportRadioBtn
            // 
            this.dispositionReportRadioBtn.AutoSize = true;
            this.dispositionReportRadioBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispositionReportRadioBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dispositionReportRadioBtn.Location = new System.Drawing.Point(528, 15);
            this.dispositionReportRadioBtn.Name = "dispositionReportRadioBtn";
            this.dispositionReportRadioBtn.Size = new System.Drawing.Size(207, 20);
            this.dispositionReportRadioBtn.TabIndex = 0;
            this.dispositionReportRadioBtn.TabStop = true;
            this.dispositionReportRadioBtn.Text = "Disposition History Report";
            this.dispositionReportRadioBtn.UseVisualStyleBackColor = true;
            // 
            // MonitorReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1339, 861);
            this.Controls.Add(this.reportBox);
            this.Controls.Add(this.goToButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ToLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "MonitorReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonitorReportForm";
            this.Load += new System.EventHandler(this.MonitorReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.reportBox.ResumeLayout(false);
            this.reportBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button goToButton;
        private System.Windows.Forms.GroupBox reportBox;
        private System.Windows.Forms.RadioButton partInlineHistoryReportBtn;
        private System.Windows.Forms.RadioButton reworkOnFloorRadioBtn;
        private System.Windows.Forms.RadioButton dispositionReportRadioBtn;
        private System.Windows.Forms.RadioButton monitorAllRadioBtn;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}