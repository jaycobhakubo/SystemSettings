namespace GTI.Modules.SystemSettings.UI
{
    partial class BlowerSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboScanner2Port = new System.Windows.Forms.ComboBox();
            this.cboScanner1Port = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkMixEnabled = new System.Windows.Forms.CheckBox();
            this.upDownFinishVoltPer = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.upDownStartVoltPer = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.upDownMixDuration = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.upDownDropDuration = new System.Windows.Forms.NumericUpDown();
            this.upDownAckTimeout = new System.Windows.Forms.NumericUpDown();
            this.upDownBallQty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownFinishVoltPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownStartVoltPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMixDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownDropDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAckTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBallQty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboScanner2Port);
            this.groupBox1.Controls.Add(this.cboScanner1Port);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.upDownDropDuration);
            this.groupBox1.Controls.Add(this.upDownAckTimeout);
            this.groupBox1.Controls.Add(this.upDownBallQty);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(17, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(728, 516);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blower Settings";
            // 
            // cboScanner2Port
            // 
            this.cboScanner2Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScanner2Port.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.cboScanner2Port.FormattingEnabled = true;
            this.cboScanner2Port.Location = new System.Drawing.Point(322, 164);
            this.cboScanner2Port.Name = "cboScanner2Port";
            this.cboScanner2Port.Size = new System.Drawing.Size(306, 30);
            this.cboScanner2Port.TabIndex = 12;
            // 
            // cboScanner1Port
            // 
            this.cboScanner1Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboScanner1Port.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.cboScanner1Port.FormattingEnabled = true;
            this.cboScanner1Port.Location = new System.Drawing.Point(322, 120);
            this.cboScanner1Port.Name = "cboScanner1Port";
            this.cboScanner1Port.Size = new System.Drawing.Size(306, 30);
            this.cboScanner1Port.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkMixEnabled);
            this.groupBox2.Controls.Add(this.upDownFinishVoltPer);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.upDownStartVoltPer);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.upDownMixDuration);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(34, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 209);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mix Settings";
            // 
            // chkMixEnabled
            // 
            this.chkMixEnabled.AutoSize = true;
            this.chkMixEnabled.Location = new System.Drawing.Point(13, 33);
            this.chkMixEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMixEnabled.Name = "chkMixEnabled";
            this.chkMixEnabled.Size = new System.Drawing.Size(177, 26);
            this.chkMixEnabled.TabIndex = 14;
            this.chkMixEnabled.Text = "Mix Method Enabled";
            this.chkMixEnabled.UseVisualStyleBackColor = true;
            this.chkMixEnabled.CheckedChanged += new System.EventHandler(this.chkMixEnabled_CheckedChanged);
            // 
            // upDownFinishVoltPer
            // 
            this.upDownFinishVoltPer.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.upDownFinishVoltPer.Location = new System.Drawing.Point(288, 156);
            this.upDownFinishVoltPer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upDownFinishVoltPer.Name = "upDownFinishVoltPer";
            this.upDownFinishVoltPer.Size = new System.Drawing.Size(300, 26);
            this.upDownFinishVoltPer.TabIndex = 17;
            this.upDownFinishVoltPer.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 72);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mix Method Duration (ms)";
            // 
            // upDownStartVoltPer
            // 
            this.upDownStartVoltPer.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.upDownStartVoltPer.Location = new System.Drawing.Point(288, 112);
            this.upDownStartVoltPer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upDownStartVoltPer.Name = "upDownStartVoltPer";
            this.upDownStartVoltPer.Size = new System.Drawing.Size(300, 26);
            this.upDownStartVoltPer.TabIndex = 16;
            this.upDownStartVoltPer.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mixer Start Voltage Percent";
            // 
            // upDownMixDuration
            // 
            this.upDownMixDuration.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.upDownMixDuration.Location = new System.Drawing.Point(288, 70);
            this.upDownMixDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upDownMixDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upDownMixDuration.Name = "upDownMixDuration";
            this.upDownMixDuration.Size = new System.Drawing.Size(300, 26);
            this.upDownMixDuration.TabIndex = 15;
            this.upDownMixDuration.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 158);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 22);
            this.label9.TabIndex = 8;
            this.label9.Text = "Mixer Finish Voltage Percent";
            // 
            // upDownDropDuration
            // 
            this.upDownDropDuration.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.upDownDropDuration.Location = new System.Drawing.Point(322, 208);
            this.upDownDropDuration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upDownDropDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upDownDropDuration.Name = "upDownDropDuration";
            this.upDownDropDuration.Size = new System.Drawing.Size(307, 26);
            this.upDownDropDuration.TabIndex = 13;
            this.upDownDropDuration.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // upDownAckTimeout
            // 
            this.upDownAckTimeout.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.upDownAckTimeout.Location = new System.Drawing.Point(322, 78);
            this.upDownAckTimeout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upDownAckTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.upDownAckTimeout.Name = "upDownAckTimeout";
            this.upDownAckTimeout.Size = new System.Drawing.Size(307, 26);
            this.upDownAckTimeout.TabIndex = 10;
            this.upDownAckTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // upDownBallQty
            // 
            this.upDownBallQty.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.upDownBallQty.Location = new System.Drawing.Point(321, 35);
            this.upDownBallQty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.upDownBallQty.Name = "upDownBallQty";
            this.upDownBallQty.Size = new System.Drawing.Size(307, 26);
            this.upDownBallQty.TabIndex = 9;
            this.upDownBallQty.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Drop Balls Duration (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Scanner 2 Comm Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Scanner 1 Comm Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ack Timeout (ms)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ball Quantity";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(395, 590);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnReset.Name = "btnReset";
            this.btnReset.RepeatRate = 150;
            this.btnReset.RepeatWhenHeldFor = 750;
            this.btnReset.Size = new System.Drawing.Size(121, 30);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(246, 590);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.RepeatRate = 150;
            this.btnSave.RepeatWhenHeldFor = 750;
            this.btnSave.Size = new System.Drawing.Size(121, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BlowerSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Name = "BlowerSettings";
            this.Size = new System.Drawing.Size(762, 644);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upDownFinishVoltPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownStartVoltPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMixDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownDropDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAckTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBallQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown upDownAckTimeout;
        private System.Windows.Forms.NumericUpDown upDownBallQty;
        private System.Windows.Forms.CheckBox chkMixEnabled;
        private System.Windows.Forms.NumericUpDown upDownDropDuration;
        private System.Windows.Forms.NumericUpDown upDownFinishVoltPer;
        private System.Windows.Forms.NumericUpDown upDownStartVoltPer;
        private System.Windows.Forms.NumericUpDown upDownMixDuration;
        private Controls.ImageButton btnReset;
        private Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboScanner2Port;
        private System.Windows.Forms.ComboBox cboScanner1Port;
    }
}
