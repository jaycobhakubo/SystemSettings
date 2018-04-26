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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlowerSettings));
            this.btnReset = new GTI.Controls.ImageButton();
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
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.Name = "btnReset";
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cboScanner2Port
            // 
            this.cboScanner2Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboScanner2Port, "cboScanner2Port");
            this.cboScanner2Port.FormattingEnabled = true;
            this.cboScanner2Port.Name = "cboScanner2Port";
            // 
            // cboScanner1Port
            // 
            this.cboScanner1Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboScanner1Port, "cboScanner1Port");
            this.cboScanner1Port.FormattingEnabled = true;
            this.cboScanner1Port.Name = "cboScanner1Port";
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
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // chkMixEnabled
            // 
            resources.ApplyResources(this.chkMixEnabled, "chkMixEnabled");
            this.chkMixEnabled.Name = "chkMixEnabled";
            this.chkMixEnabled.UseVisualStyleBackColor = true;
            this.chkMixEnabled.CheckedChanged += new System.EventHandler(this.chkMixEnabled_CheckedChanged);
            // 
            // upDownFinishVoltPer
            // 
            resources.ApplyResources(this.upDownFinishVoltPer, "upDownFinishVoltPer");
            this.upDownFinishVoltPer.Name = "upDownFinishVoltPer";
            this.upDownFinishVoltPer.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // upDownStartVoltPer
            // 
            resources.ApplyResources(this.upDownStartVoltPer, "upDownStartVoltPer");
            this.upDownStartVoltPer.Name = "upDownStartVoltPer";
            this.upDownStartVoltPer.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // upDownMixDuration
            // 
            resources.ApplyResources(this.upDownMixDuration, "upDownMixDuration");
            this.upDownMixDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upDownMixDuration.Name = "upDownMixDuration";
            this.upDownMixDuration.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // upDownDropDuration
            // 
            resources.ApplyResources(this.upDownDropDuration, "upDownDropDuration");
            this.upDownDropDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upDownDropDuration.Name = "upDownDropDuration";
            this.upDownDropDuration.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // upDownAckTimeout
            // 
            resources.ApplyResources(this.upDownAckTimeout, "upDownAckTimeout");
            this.upDownAckTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.upDownAckTimeout.Name = "upDownAckTimeout";
            this.upDownAckTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // upDownBallQty
            // 
            resources.ApplyResources(this.upDownBallQty, "upDownBallQty");
            this.upDownBallQty.Name = "upDownBallQty";
            this.upDownBallQty.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.Name = "btnSave";
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
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
            resources.ApplyResources(this, "$this");
            this.Name = "BlowerSettings";
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
