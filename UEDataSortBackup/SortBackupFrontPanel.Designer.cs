namespace UEDataSortBackup
{
    partial class SortBackupFrontPanel
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
            this.startUEButton = new System.Windows.Forms.Button();
            this.startSortBackupButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.syncProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.recentBackupOutput = new System.Windows.Forms.TextBox();
            this.scheduledBackupOutput = new System.Windows.Forms.TextBox();
            this.requiredBackupOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.syncCounter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startUEButton
            // 
            this.startUEButton.Location = new System.Drawing.Point(12, 305);
            this.startUEButton.Name = "startUEButton";
            this.startUEButton.Size = new System.Drawing.Size(100, 23);
            this.startUEButton.TabIndex = 0;
            this.startUEButton.Text = "Start UE Software";
            this.startUEButton.UseVisualStyleBackColor = true;
            // 
            // startSortBackupButton
            // 
            this.startSortBackupButton.Location = new System.Drawing.Point(118, 305);
            this.startSortBackupButton.Name = "startSortBackupButton";
            this.startSortBackupButton.Size = new System.Drawing.Size(100, 23);
            this.startSortBackupButton.TabIndex = 1;
            this.startSortBackupButton.Text = "Run Backup Software";
            this.startSortBackupButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(224, 305);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // syncProgressBar
            // 
            this.syncProgressBar.Location = new System.Drawing.Point(12, 243);
            this.syncProgressBar.Name = "syncProgressBar";
            this.syncProgressBar.Size = new System.Drawing.Size(312, 23);
            this.syncProgressBar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Most Recent Backup";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Next Scheduled Backup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Next Required Backup";
            // 
            // recentBackupOutput
            // 
            this.recentBackupOutput.Location = new System.Drawing.Point(168, 119);
            this.recentBackupOutput.Name = "recentBackupOutput";
            this.recentBackupOutput.ReadOnly = true;
            this.recentBackupOutput.Size = new System.Drawing.Size(138, 20);
            this.recentBackupOutput.TabIndex = 7;
            // 
            // scheduledBackupOutput
            // 
            this.scheduledBackupOutput.Location = new System.Drawing.Point(168, 146);
            this.scheduledBackupOutput.Name = "scheduledBackupOutput";
            this.scheduledBackupOutput.ReadOnly = true;
            this.scheduledBackupOutput.Size = new System.Drawing.Size(138, 20);
            this.scheduledBackupOutput.TabIndex = 8;
            // 
            // requiredBackupOutput
            // 
            this.requiredBackupOutput.Location = new System.Drawing.Point(168, 173);
            this.requiredBackupOutput.Name = "requiredBackupOutput";
            this.requiredBackupOutput.ReadOnly = true;
            this.requiredBackupOutput.Size = new System.Drawing.Size(138, 20);
            this.requiredBackupOutput.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "INSERT LOGO/TEXT";
            // 
            // syncCounter
            // 
            this.syncCounter.Location = new System.Drawing.Point(12, 217);
            this.syncCounter.Name = "syncCounter";
            this.syncCounter.ReadOnly = true;
            this.syncCounter.Size = new System.Drawing.Size(138, 20);
            this.syncCounter.TabIndex = 11;
            // 
            // SortBackupFrontPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 343);
            this.Controls.Add(this.syncCounter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.requiredBackupOutput);
            this.Controls.Add(this.scheduledBackupOutput);
            this.Controls.Add(this.recentBackupOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.syncProgressBar);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.startSortBackupButton);
            this.Controls.Add(this.startUEButton);
            this.Name = "SortBackupFrontPanel";
            this.Text = "CTS Backup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startUEButton;
        private System.Windows.Forms.Button startSortBackupButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ProgressBar syncProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox recentBackupOutput;
        private System.Windows.Forms.TextBox scheduledBackupOutput;
        private System.Windows.Forms.TextBox requiredBackupOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox syncCounter;
    }
}