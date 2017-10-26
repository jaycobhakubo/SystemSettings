namespace GTI.Modules.SystemSettings.UI
{
    partial class ProtocolAdapterSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolAdapterSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtprimarySendFreq = new System.Windows.Forms.NumericUpDown();
            this.cbobxprimaryCommPort = new System.Windows.Forms.ComboBox();
            this.cbobxprimaryStreamSubIdx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkprimaryAdapterEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtsecondarySendFreq = new System.Windows.Forms.NumericUpDown();
            this.cbobxsecondaryCommPort = new System.Windows.Forms.ComboBox();
            this.cbobxsecondaryStreamSubIdx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chksecondaryAdapterEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txttertiarySendFreq = new System.Windows.Forms.NumericUpDown();
            this.cbobxtertiaryCommPort = new System.Windows.Forms.ComboBox();
            this.cbobxtertiaryStreamSubIdx = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chktertiaryAdapterEnabled = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtprimarySendFreq)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsecondarySendFreq)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttertiarySendFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientPanel;
            this.groupBox1.Controls.Add(this.tabControl1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientPanel;
            this.tabPage1.Controls.Add(this.txtprimarySendFreq);
            this.tabPage1.Controls.Add(this.cbobxprimaryCommPort);
            this.tabPage1.Controls.Add(this.cbobxprimaryStreamSubIdx);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkprimaryAdapterEnabled);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // txtprimarySendFreq
            // 
            resources.ApplyResources(this.txtprimarySendFreq, "txtprimarySendFreq");
            this.txtprimarySendFreq.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtprimarySendFreq.Name = "txtprimarySendFreq";
            this.txtprimarySendFreq.ValueChanged += new System.EventHandler(this.numericUpDowns_ValueChanged);
            this.txtprimarySendFreq.LostFocus += new System.EventHandler(this.numericUpDowns_CheckEmpty);
            // 
            // cbobxprimaryCommPort
            // 
            resources.ApplyResources(this.cbobxprimaryCommPort, "cbobxprimaryCommPort");
            this.cbobxprimaryCommPort.FormattingEnabled = true;
            this.cbobxprimaryCommPort.Name = "cbobxprimaryCommPort";
            this.cbobxprimaryCommPort.SelectedIndexChanged += new System.EventHandler(this.CommPortIdx_SelectedIndexChanged);
            // 
            // cbobxprimaryStreamSubIdx
            // 
            resources.ApplyResources(this.cbobxprimaryStreamSubIdx, "cbobxprimaryStreamSubIdx");
            this.cbobxprimaryStreamSubIdx.FormattingEnabled = true;
            this.cbobxprimaryStreamSubIdx.Name = "cbobxprimaryStreamSubIdx";
            this.cbobxprimaryStreamSubIdx.SelectedIndexChanged += new System.EventHandler(this.StreamSubIdx_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // chkprimaryAdapterEnabled
            // 
            resources.ApplyResources(this.chkprimaryAdapterEnabled, "chkprimaryAdapterEnabled");
            this.chkprimaryAdapterEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chkprimaryAdapterEnabled.Name = "chkprimaryAdapterEnabled";
            this.chkprimaryAdapterEnabled.UseVisualStyleBackColor = false;
            this.chkprimaryAdapterEnabled.CheckedChanged += new System.EventHandler(this.chkprimaryAdapterEnabled_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientPanel;
            this.tabPage2.Controls.Add(this.txtsecondarySendFreq);
            this.tabPage2.Controls.Add(this.cbobxsecondaryCommPort);
            this.tabPage2.Controls.Add(this.cbobxsecondaryStreamSubIdx);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.chksecondaryAdapterEnabled);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // txtsecondarySendFreq
            // 
            resources.ApplyResources(this.txtsecondarySendFreq, "txtsecondarySendFreq");
            this.txtsecondarySendFreq.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtsecondarySendFreq.Name = "txtsecondarySendFreq";
            this.txtsecondarySendFreq.ValueChanged += new System.EventHandler(this.numericUpDowns_ValueChanged);
            this.txtsecondarySendFreq.LostFocus += new System.EventHandler(this.numericUpDowns_CheckEmpty);
            // 
            // cbobxsecondaryCommPort
            // 
            resources.ApplyResources(this.cbobxsecondaryCommPort, "cbobxsecondaryCommPort");
            this.cbobxsecondaryCommPort.FormattingEnabled = true;
            this.cbobxsecondaryCommPort.Name = "cbobxsecondaryCommPort";
            this.cbobxsecondaryCommPort.SelectedIndexChanged += new System.EventHandler(this.CommPortIdx_SelectedIndexChanged);
            // 
            // cbobxsecondaryStreamSubIdx
            // 
            resources.ApplyResources(this.cbobxsecondaryStreamSubIdx, "cbobxsecondaryStreamSubIdx");
            this.cbobxsecondaryStreamSubIdx.FormattingEnabled = true;
            this.cbobxsecondaryStreamSubIdx.Name = "cbobxsecondaryStreamSubIdx";
            this.cbobxsecondaryStreamSubIdx.SelectedIndexChanged += new System.EventHandler(this.StreamSubIdx_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // chksecondaryAdapterEnabled
            // 
            resources.ApplyResources(this.chksecondaryAdapterEnabled, "chksecondaryAdapterEnabled");
            this.chksecondaryAdapterEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chksecondaryAdapterEnabled.Name = "chksecondaryAdapterEnabled";
            this.chksecondaryAdapterEnabled.UseVisualStyleBackColor = false;
            this.chksecondaryAdapterEnabled.CheckedChanged += new System.EventHandler(this.chksecondaryAdapterEnabled_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.BackgroundImage = global::GTI.Modules.SystemSettings.Properties.Resources.GradientPanel;
            this.tabPage3.Controls.Add(this.txttertiarySendFreq);
            this.tabPage3.Controls.Add(this.cbobxtertiaryCommPort);
            this.tabPage3.Controls.Add(this.cbobxtertiaryStreamSubIdx);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.chktertiaryAdapterEnabled);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            // 
            // txttertiarySendFreq
            // 
            resources.ApplyResources(this.txttertiarySendFreq, "txttertiarySendFreq");
            this.txttertiarySendFreq.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txttertiarySendFreq.Name = "txttertiarySendFreq";
            this.txttertiarySendFreq.ValueChanged += new System.EventHandler(this.numericUpDowns_ValueChanged);
            this.txttertiarySendFreq.LostFocus += new System.EventHandler(this.numericUpDowns_CheckEmpty);
            // 
            // cbobxtertiaryCommPort
            // 
            resources.ApplyResources(this.cbobxtertiaryCommPort, "cbobxtertiaryCommPort");
            this.cbobxtertiaryCommPort.FormattingEnabled = true;
            this.cbobxtertiaryCommPort.Name = "cbobxtertiaryCommPort";
            this.cbobxtertiaryCommPort.SelectedIndexChanged += new System.EventHandler(this.CommPortIdx_SelectedIndexChanged);
            // 
            // cbobxtertiaryStreamSubIdx
            // 
            resources.ApplyResources(this.cbobxtertiaryStreamSubIdx, "cbobxtertiaryStreamSubIdx");
            this.cbobxtertiaryStreamSubIdx.FormattingEnabled = true;
            this.cbobxtertiaryStreamSubIdx.Name = "cbobxtertiaryStreamSubIdx";
            this.cbobxtertiaryStreamSubIdx.SelectedIndexChanged += new System.EventHandler(this.StreamSubIdx_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Name = "label9";
            // 
            // chktertiaryAdapterEnabled
            // 
            resources.ApplyResources(this.chktertiaryAdapterEnabled, "chktertiaryAdapterEnabled");
            this.chktertiaryAdapterEnabled.BackColor = System.Drawing.Color.Transparent;
            this.chktertiaryAdapterEnabled.Name = "chktertiaryAdapterEnabled";
            this.chktertiaryAdapterEnabled.UseVisualStyleBackColor = false;
            this.chktertiaryAdapterEnabled.CheckedChanged += new System.EventHandler(this.chktertiaryAdapterEnabled_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.Name = "btnReset";
            this.btnReset.RepeatRate = 150;
            this.btnReset.RepeatWhenHeldFor = 750;
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.Name = "btnSave";
            this.btnSave.RepeatRate = 150;
            this.btnSave.RepeatWhenHeldFor = 750;
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ProtocolAdapterSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "ProtocolAdapterSettings";
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtprimarySendFreq)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtsecondarySendFreq)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttertiarySendFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.ImageButton btnReset;
        private Controls.ImageButton btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkprimaryAdapterEnabled;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbobxprimaryStreamSubIdx;
        private System.Windows.Forms.ComboBox cbobxprimaryCommPort;
        private System.Windows.Forms.ComboBox cbobxsecondaryCommPort;
        private System.Windows.Forms.ComboBox cbobxsecondaryStreamSubIdx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chksecondaryAdapterEnabled;
        private System.Windows.Forms.ComboBox cbobxtertiaryCommPort;
        private System.Windows.Forms.ComboBox cbobxtertiaryStreamSubIdx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chktertiaryAdapterEnabled;
        private System.Windows.Forms.NumericUpDown txtprimarySendFreq;
        private System.Windows.Forms.NumericUpDown txtsecondarySendFreq;
        private System.Windows.Forms.NumericUpDown txttertiarySendFreq;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
