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
            this.tbSettings = new System.Windows.Forms.TabPage();
            this.panSettings = new System.Windows.Forms.Panel();
            this.gbMachines = new System.Windows.Forms.GroupBox();
            this.gbMachinesList = new System.Windows.Forms.GroupBox();
            this.dgwMachinesList = new System.Windows.Forms.DataGridView();
            this.gbAddNewMachine = new System.Windows.Forms.GroupBox();
            this.nudTransportSpeed = new System.Windows.Forms.NumericUpDown();
            this.cbTurningRadiusUnit = new System.Windows.Forms.ComboBox();
            this.lbTurningRadius = new System.Windows.Forms.Label();
            this.nudTurningRadius = new System.Windows.Forms.NumericUpDown();
            this.cbTransportSpeedUnit = new System.Windows.Forms.ComboBox();
            this.lbTransportSpeed = new System.Windows.Forms.Label();
            this.cbVolumeUnit = new System.Windows.Forms.ComboBox();
            this.lbVolume = new System.Windows.Forms.Label();
            this.nudVolume = new System.Windows.Forms.NumericUpDown();
            this.btAddMachine = new System.Windows.Forms.Button();
            this.cbWorkingSpeedUnit = new System.Windows.Forms.ComboBox();
            this.lbWorkingSpeed = new System.Windows.Forms.Label();
            this.nudWorkingSpeed = new System.Windows.Forms.NumericUpDown();
            this.cbWorkingWidthUnits = new System.Windows.Forms.ComboBox();
            this.lbWorkingWidth = new System.Windows.Forms.Label();
            this.nudWorkingWidth = new System.Windows.Forms.NumericUpDown();
            this.rbPrimary = new System.Windows.Forms.RadioButton();
            this.rbSecondary = new System.Windows.Forms.RadioButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbLog = new System.Windows.Forms.TabPage();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.rtbMachineStatistics = new System.Windows.Forms.TabPage();
            this.rtbMachineStatisticsText = new System.Windows.Forms.RichTextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.tcBottom.SuspendLayout();
            this.tbSettings.SuspendLayout();
            this.panSettings.SuspendLayout();
            this.gbMachines.SuspendLayout();
            this.gbMachinesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMachinesList)).BeginInit();
            this.gbAddNewMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransportSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurningRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkingSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkingWidth)).BeginInit();
            this.tbLog.SuspendLayout();
            this.rtbMachineStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcBottom
            // 
            this.tcBottom.Controls.Add(this.tbSettings);
            this.tcBottom.Controls.Add(this.tbLog);
            this.tcBottom.Controls.Add(this.rtbMachineStatistics);
            this.tcBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcBottom.Location = new System.Drawing.Point(0, 0);
            this.tcBottom.Name = "tcBottom";
            this.tcBottom.SelectedIndex = 0;
            this.tcBottom.Size = new System.Drawing.Size(1418, 788);
            this.tcBottom.TabIndex = 0;
            // 
            // tbSettings
            // 
            this.tbSettings.Controls.Add(this.panSettings);
            this.tbSettings.Location = new System.Drawing.Point(4, 25);
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbSettings.Size = new System.Drawing.Size(1410, 759);
            this.tbSettings.TabIndex = 2;
            this.tbSettings.Text = "Settings";
            this.tbSettings.UseVisualStyleBackColor = true;
            // 
            // panSettings
            // 
            this.panSettings.Controls.Add(this.gbMachines);
            this.panSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSettings.Location = new System.Drawing.Point(3, 3);
            this.panSettings.Name = "panSettings";
            this.panSettings.Size = new System.Drawing.Size(1404, 753);
            this.panSettings.TabIndex = 0;
            // 
            // gbMachines
            // 
            this.gbMachines.Controls.Add(this.gbMachinesList);
            this.gbMachines.Controls.Add(this.gbAddNewMachine);
            this.gbMachines.Location = new System.Drawing.Point(5, 3);
            this.gbMachines.Name = "gbMachines";
            this.gbMachines.Size = new System.Drawing.Size(653, 654);
            this.gbMachines.TabIndex = 0;
            this.gbMachines.TabStop = false;
            this.gbMachines.Text = "Machines";
            // 
            // gbMachinesList
            // 
            this.gbMachinesList.Controls.Add(this.dgwMachinesList);
            this.gbMachinesList.Location = new System.Drawing.Point(6, 258);
            this.gbMachinesList.Name = "gbMachinesList";
            this.gbMachinesList.Size = new System.Drawing.Size(641, 390);
            this.gbMachinesList.TabIndex = 3;
            this.gbMachinesList.TabStop = false;
            this.gbMachinesList.Text = "Machines list";
            // 
            // dgwMachinesList
            // 
            this.dgwMachinesList.AllowUserToAddRows = false;
            this.dgwMachinesList.AllowUserToDeleteRows = false;
            this.dgwMachinesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMachinesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgwMachinesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwMachinesList.Location = new System.Drawing.Point(3, 18);
            this.dgwMachinesList.Name = "dgwMachinesList";
            this.dgwMachinesList.ReadOnly = true;
            this.dgwMachinesList.RowTemplate.Height = 24;
            this.dgwMachinesList.Size = new System.Drawing.Size(635, 369);
            this.dgwMachinesList.TabIndex = 0;
            // 
            // gbAddNewMachine
            // 
            this.gbAddNewMachine.Controls.Add(this.nudTransportSpeed);
            this.gbAddNewMachine.Controls.Add(this.cbTurningRadiusUnit);
            this.gbAddNewMachine.Controls.Add(this.lbTurningRadius);
            this.gbAddNewMachine.Controls.Add(this.nudTurningRadius);
            this.gbAddNewMachine.Controls.Add(this.cbTransportSpeedUnit);
            this.gbAddNewMachine.Controls.Add(this.lbTransportSpeed);
            this.gbAddNewMachine.Controls.Add(this.cbVolumeUnit);
            this.gbAddNewMachine.Controls.Add(this.lbVolume);
            this.gbAddNewMachine.Controls.Add(this.nudVolume);
            this.gbAddNewMachine.Controls.Add(this.btAddMachine);
            this.gbAddNewMachine.Controls.Add(this.cbWorkingSpeedUnit);
            this.gbAddNewMachine.Controls.Add(this.lbWorkingSpeed);
            this.gbAddNewMachine.Controls.Add(this.nudWorkingSpeed);
            this.gbAddNewMachine.Controls.Add(this.cbWorkingWidthUnits);
            this.gbAddNewMachine.Controls.Add(this.lbWorkingWidth);
            this.gbAddNewMachine.Controls.Add(this.nudWorkingWidth);
            this.gbAddNewMachine.Controls.Add(this.rbPrimary);
            this.gbAddNewMachine.Controls.Add(this.rbSecondary);
            this.gbAddNewMachine.Location = new System.Drawing.Point(6, 21);
            this.gbAddNewMachine.Name = "gbAddNewMachine";
            this.gbAddNewMachine.Size = new System.Drawing.Size(641, 222);
            this.gbAddNewMachine.TabIndex = 2;
            this.gbAddNewMachine.TabStop = false;
            this.gbAddNewMachine.Text = "Add new";
            // 
            // nudTransportSpeed
            // 
            this.nudTransportSpeed.DecimalPlaces = 1;
            this.nudTransportSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTransportSpeed.Location = new System.Drawing.Point(156, 116);
            this.nudTransportSpeed.Name = "nudTransportSpeed";
            this.nudTransportSpeed.Size = new System.Drawing.Size(120, 22);
            this.nudTransportSpeed.TabIndex = 17;
            this.nudTransportSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbTurningRadiusUnit
            // 
            this.cbTurningRadiusUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTurningRadiusUnit.FormattingEnabled = true;
            this.cbTurningRadiusUnit.Items.AddRange(new object[] {
            "m",
            "cm",
            "mm"});
            this.cbTurningRadiusUnit.Location = new System.Drawing.Point(293, 148);
            this.cbTurningRadiusUnit.Name = "cbTurningRadiusUnit";
            this.cbTurningRadiusUnit.Size = new System.Drawing.Size(83, 24);
            this.cbTurningRadiusUnit.TabIndex = 16;
            // 
            // lbTurningRadius
            // 
            this.lbTurningRadius.AutoSize = true;
            this.lbTurningRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTurningRadius.Location = new System.Drawing.Point(6, 147);
            this.lbTurningRadius.Name = "lbTurningRadius";
            this.lbTurningRadius.Size = new System.Drawing.Size(121, 20);
            this.lbTurningRadius.TabIndex = 15;
            this.lbTurningRadius.Text = "Turning radius:";
            // 
            // nudTurningRadius
            // 
            this.nudTurningRadius.DecimalPlaces = 1;
            this.nudTurningRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTurningRadius.Location = new System.Drawing.Point(156, 148);
            this.nudTurningRadius.Name = "nudTurningRadius";
            this.nudTurningRadius.Size = new System.Drawing.Size(120, 22);
            this.nudTurningRadius.TabIndex = 14;
            this.nudTurningRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbTransportSpeedUnit
            // 
            this.cbTransportSpeedUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransportSpeedUnit.FormattingEnabled = true;
            this.cbTransportSpeedUnit.Items.AddRange(new object[] {
            "m/s",
            "km/h"});
            this.cbTransportSpeedUnit.Location = new System.Drawing.Point(293, 118);
            this.cbTransportSpeedUnit.Name = "cbTransportSpeedUnit";
            this.cbTransportSpeedUnit.Size = new System.Drawing.Size(83, 24);
            this.cbTransportSpeedUnit.TabIndex = 13;
            // 
            // lbTransportSpeed
            // 
            this.lbTransportSpeed.AutoSize = true;
            this.lbTransportSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTransportSpeed.Location = new System.Drawing.Point(6, 117);
            this.lbTransportSpeed.Name = "lbTransportSpeed";
            this.lbTransportSpeed.Size = new System.Drawing.Size(136, 20);
            this.lbTransportSpeed.TabIndex = 12;
            this.lbTransportSpeed.Text = "Transport speed:";
            // 
            // cbVolumeUnit
            // 
            this.cbVolumeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVolumeUnit.FormattingEnabled = true;
            this.cbVolumeUnit.Items.AddRange(new object[] {
            "l"});
            this.cbVolumeUnit.Location = new System.Drawing.Point(293, 178);
            this.cbVolumeUnit.Name = "cbVolumeUnit";
            this.cbVolumeUnit.Size = new System.Drawing.Size(83, 24);
            this.cbVolumeUnit.TabIndex = 10;
            // 
            // lbVolume
            // 
            this.lbVolume.AutoSize = true;
            this.lbVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVolume.Location = new System.Drawing.Point(6, 177);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(70, 20);
            this.lbVolume.TabIndex = 9;
            this.lbVolume.Text = "Volume:";
            // 
            // nudVolume
            // 
            this.nudVolume.Location = new System.Drawing.Point(156, 178);
            this.nudVolume.Name = "nudVolume";
            this.nudVolume.Size = new System.Drawing.Size(120, 22);
            this.nudVolume.TabIndex = 8;
            this.nudVolume.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btAddMachine
            // 
            this.btAddMachine.Location = new System.Drawing.Point(519, 167);
            this.btAddMachine.Name = "btAddMachine";
            this.btAddMachine.Size = new System.Drawing.Size(116, 42);
            this.btAddMachine.TabIndex = 1;
            this.btAddMachine.Text = "Add machine";
            this.btAddMachine.UseVisualStyleBackColor = true;
            this.btAddMachine.Click += new System.EventHandler(this.btAddMachine_Click);
            // 
            // cbWorkingSpeedUnit
            // 
            this.cbWorkingSpeedUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkingSpeedUnit.FormattingEnabled = true;
            this.cbWorkingSpeedUnit.Items.AddRange(new object[] {
            "m/s",
            "km/h"});
            this.cbWorkingSpeedUnit.Location = new System.Drawing.Point(293, 88);
            this.cbWorkingSpeedUnit.Name = "cbWorkingSpeedUnit";
            this.cbWorkingSpeedUnit.Size = new System.Drawing.Size(83, 24);
            this.cbWorkingSpeedUnit.TabIndex = 7;
            // 
            // lbWorkingSpeed
            // 
            this.lbWorkingSpeed.AutoSize = true;
            this.lbWorkingSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWorkingSpeed.Location = new System.Drawing.Point(6, 87);
            this.lbWorkingSpeed.Name = "lbWorkingSpeed";
            this.lbWorkingSpeed.Size = new System.Drawing.Size(125, 20);
            this.lbWorkingSpeed.TabIndex = 6;
            this.lbWorkingSpeed.Text = "Working speed:";
            // 
            // nudWorkingSpeed
            // 
            this.nudWorkingSpeed.DecimalPlaces = 1;
            this.nudWorkingSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWorkingSpeed.Location = new System.Drawing.Point(156, 88);
            this.nudWorkingSpeed.Name = "nudWorkingSpeed";
            this.nudWorkingSpeed.Size = new System.Drawing.Size(120, 22);
            this.nudWorkingSpeed.TabIndex = 5;
            this.nudWorkingSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbWorkingWidthUnits
            // 
            this.cbWorkingWidthUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkingWidthUnits.FormattingEnabled = true;
            this.cbWorkingWidthUnits.Items.AddRange(new object[] {
            "m",
            "cm",
            "mm"});
            this.cbWorkingWidthUnits.Location = new System.Drawing.Point(293, 58);
            this.cbWorkingWidthUnits.Name = "cbWorkingWidthUnits";
            this.cbWorkingWidthUnits.Size = new System.Drawing.Size(83, 24);
            this.cbWorkingWidthUnits.TabIndex = 4;
            // 
            // lbWorkingWidth
            // 
            this.lbWorkingWidth.AutoSize = true;
            this.lbWorkingWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWorkingWidth.Location = new System.Drawing.Point(6, 58);
            this.lbWorkingWidth.Name = "lbWorkingWidth";
            this.lbWorkingWidth.Size = new System.Drawing.Size(119, 20);
            this.lbWorkingWidth.TabIndex = 3;
            this.lbWorkingWidth.Text = "Working width:";
            // 
            // nudWorkingWidth
            // 
            this.nudWorkingWidth.DecimalPlaces = 1;
            this.nudWorkingWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWorkingWidth.Location = new System.Drawing.Point(156, 58);
            this.nudWorkingWidth.Name = "nudWorkingWidth";
            this.nudWorkingWidth.Size = new System.Drawing.Size(120, 22);
            this.nudWorkingWidth.TabIndex = 2;
            this.nudWorkingWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbPrimary
            // 
            this.rbPrimary.AutoSize = true;
            this.rbPrimary.Checked = true;
            this.rbPrimary.Location = new System.Drawing.Point(18, 21);
            this.rbPrimary.Name = "rbPrimary";
            this.rbPrimary.Size = new System.Drawing.Size(76, 21);
            this.rbPrimary.TabIndex = 0;
            this.rbPrimary.TabStop = true;
            this.rbPrimary.Text = "primary";
            this.rbPrimary.UseVisualStyleBackColor = true;
            // 
            // rbSecondary
            // 
            this.rbSecondary.AutoSize = true;
            this.rbSecondary.Location = new System.Drawing.Point(109, 21);
            this.rbSecondary.Name = "rbSecondary";
            this.rbSecondary.Size = new System.Drawing.Size(95, 21);
            this.rbSecondary.TabIndex = 1;
            this.rbSecondary.Text = "secondary";
            this.rbSecondary.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
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
            // rtbMachineStatisticsText
            // 
            this.rtbMachineStatisticsText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMachineStatisticsText.Location = new System.Drawing.Point(3, 3);
            this.rtbMachineStatisticsText.Name = "rtbMachineStatisticsText";
            this.rtbMachineStatisticsText.Size = new System.Drawing.Size(1404, 753);
            this.rtbMachineStatisticsText.TabIndex = 0;
            this.rtbMachineStatisticsText.Text = "";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(1265, 790);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(141, 34);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start coverage";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
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
            this.tbSettings.ResumeLayout(false);
            this.panSettings.ResumeLayout(false);
            this.gbMachines.ResumeLayout(false);
            this.gbMachinesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMachinesList)).EndInit();
            this.gbAddNewMachine.ResumeLayout(false);
            this.gbAddNewMachine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTransportSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTurningRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkingSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkingWidth)).EndInit();
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
        private System.Windows.Forms.TabPage tbSettings;
        private System.Windows.Forms.Panel panSettings;
        private System.Windows.Forms.GroupBox gbMachines;
        private System.Windows.Forms.GroupBox gbAddNewMachine;
        private System.Windows.Forms.ComboBox cbWorkingSpeedUnit;
        private System.Windows.Forms.Label lbWorkingSpeed;
        private System.Windows.Forms.NumericUpDown nudWorkingSpeed;
        private System.Windows.Forms.ComboBox cbWorkingWidthUnits;
        private System.Windows.Forms.Label lbWorkingWidth;
        private System.Windows.Forms.NumericUpDown nudWorkingWidth;
        private System.Windows.Forms.RadioButton rbPrimary;
        private System.Windows.Forms.RadioButton rbSecondary;
        private System.Windows.Forms.GroupBox gbMachinesList;
        private System.Windows.Forms.DataGridView dgwMachinesList;
        private System.Windows.Forms.Button btAddMachine;
        private System.Windows.Forms.ComboBox cbVolumeUnit;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.NumericUpDown nudVolume;
        private System.Windows.Forms.NumericUpDown nudTransportSpeed;
        private System.Windows.Forms.ComboBox cbTurningRadiusUnit;
        private System.Windows.Forms.Label lbTurningRadius;
        private System.Windows.Forms.NumericUpDown nudTurningRadius;
        private System.Windows.Forms.ComboBox cbTransportSpeedUnit;
        private System.Windows.Forms.Label lbTransportSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}

