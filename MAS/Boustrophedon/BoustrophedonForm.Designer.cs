namespace Boustrophedon.GUI
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tcBottom.SuspendLayout();
            this.tbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcBottom
            // 
            this.tcBottom.Controls.Add(this.tbLog);
            this.tcBottom.Controls.Add(this.tabPage2);
            this.tcBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcBottom.Location = new System.Drawing.Point(0, 298);
            this.tcBottom.Name = "tcBottom";
            this.tcBottom.SelectedIndex = 0;
            this.tcBottom.Size = new System.Drawing.Size(1026, 282);
            this.tcBottom.TabIndex = 0;
            // 
            // tbLog
            // 
            this.tbLog.Controls.Add(this.rtbLog);
            this.tbLog.Location = new System.Drawing.Point(4, 25);
            this.tbLog.Name = "tbLog";
            this.tbLog.Padding = new System.Windows.Forms.Padding(3);
            this.tbLog.Size = new System.Drawing.Size(1018, 253);
            this.tbLog.TabIndex = 0;
            this.tbLog.Text = "Log";
            this.tbLog.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1018, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(3, 3);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(1012, 247);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // Boustrophedon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 580);
            this.Controls.Add(this.tcBottom);
            this.Name = "Boustrophedon";
            this.Text = "Form1";
            this.tcBottom.ResumeLayout(false);
            this.tbLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcBottom;
        private System.Windows.Forms.TabPage tbLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

