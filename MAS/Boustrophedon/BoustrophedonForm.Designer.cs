﻿namespace Boustrophedon.GUI
{
    partial class Boustrophedon
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
            this.tcBottom = new System.Windows.Forms.TabControl();
            this.tbLog = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.rtbMachineStatistics = new System.Windows.Forms.TabPage();
            this.btStart = new System.Windows.Forms.Button();
            this.rtbMachineStatisticsText = new System.Windows.Forms.RichTextBox();
            this.tcBottom.SuspendLayout();
            this.tbLog.SuspendLayout();
            this.rtbMachineStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcBottom
            // 
            this.tcBottom.Controls.Add(this.tbLog);
            this.tcBottom.Controls.Add(this.rtbMachineStatistics);
            this.tcBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcBottom.Location = new System.Drawing.Point(0, 41);
            this.tcBottom.Name = "tcBottom";
            this.tcBottom.SelectedIndex = 0;
            this.tcBottom.Size = new System.Drawing.Size(1418, 788);
            this.tcBottom.TabIndex = 0;
            // 
            // tbLog
            // 
            this.tbLog.Controls.Add(this.rtbLog);
            this.tbLog.Location = new System.Drawing.Point(4, 25);
            this.tbLog.Name = "tbLog";
            this.tbLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbLog.Size = new System.Drawing.Size(1410, 759);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "Log";
            this.tbLog.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(1404, 753);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // rtbMachineStatistics
            // 
            this.rtbMachineStatistics.Controls.Add(this.rtbMachineStatisticsText);
            this.rtbMachineStatistics.Location = new System.Drawing.Point(4, 25);
            this.rtbMachineStatistics.Name = "rtbMachineStatistics";
            this.rtbMachineStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.rtbMachineStatistics.Size = new System.Drawing.Size(1410, 759);
            this.rtbMachineStatistics.TabIndex = 1;
            this.rtbMachineStatistics.Text = "Machines Statistics";
            this.rtbMachineStatistics.UseVisualStyleBackColor = true;
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(7, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // rtbMachineStatisticsText
            // 
            this.rtbMachineStatisticsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMachineStatisticsText.Location = new System.Drawing.Point(3, 3);
            this.rtbMachineStatisticsText.Name = "rtbMachineStatisticsText";
            this.rtbMachineStatisticsText.Size = new System.Drawing.Size(1404, 753);
            this.rtbMachineStatisticsText.TabIndex = 0;
            this.rtbMachineStatisticsText.Text = "";
            // 
            // Boustrophedon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 829);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tcBottom);
            this.Name = "Boustrophedon";
            this.Text = "Boustrophedon_MAS";
            this.tcBottom.ResumeLayout(false);
            this.tbLog.ResumeLayout(false);
            this.rtbMachineStatistics.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcBottom;
        private System.Windows.Forms.TabPage tbLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TabPage rtbMachineStatistics;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.RichTextBox rtbMachineStatisticsText;
    }
}

