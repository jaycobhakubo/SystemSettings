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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProtocolAdapterSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbobxprimaryCommPort = new System.Windows.Forms.ComboBox();
            this.txtprimarySendFreq = new System.Windows.Forms.TextBox();
            this.cbobxprimaryStreamSubIdx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkprimaryAdapterEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbobxsecondaryCommPort = new System.Windows.Forms.ComboBox();
            this.txtsecondarySendFreq = new System.Windows.Forms.TextBox();
            this.cbobxsecondaryStreamSubIdx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chksecondaryAdapterEnabled = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbobxtertiaryCommPort = new System.Windows.Forms.ComboBox();
            this.txttertiarySendFreq = new System.Windows.Forms.TextBox();
            this.cbobxtertiaryStreamSubIdx = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chktertiaryAdapterEnabled = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.tabPage1.Controls.Add(this.cbobxprimaryCommPort);
            this.tabPage1.Controls.Add(this.txtprimarySendFreq);
            this.tabPage1.Controls.Add(this.cbobxprimaryStreamSubIdx);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.chkprimaryAdapterEnabled);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbobxprimaryCommPort
            // 
            this.cbobxprimaryCommPort.FormattingEnabled = true;
            resources.ApplyResources(this.cbobxprimaryCommPort, "cbobxprimaryCommPort");
            this.cbobxprimaryCommPort.Name = "cbobxprimaryCommPort";
            // 
            // txtprimarySendFreq
            // 
            resources.ApplyResources(this.txtprimarySendFreq, "txtprimarySendFreq");
            this.txtprimarySendFreq.Name = "txtprimarySendFreq";
            // 
            // cbobxprimaryStreamSubIdx
            // 
            this.cbobxprimaryStreamSubIdx.FormattingEnabled = true;
            resources.ApplyResources(this.cbobxprimaryStreamSubIdx, "cbobxprimaryStreamSubIdx");
            this.cbobxprimaryStreamSubIdx.Name = "cbobxprimaryStreamSubIdx";
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
            // chkprimaryAdapterEnabled
            // 
            resources.ApplyResources(this.chkprimaryAdapterEnabled, "chkprimaryAdapterEnabled");
            this.chkprimaryAdapterEnabled.Name = "chkprimaryAdapterEnabled";
            this.chkprimaryAdapterEnabled.UseVisualStyleBackColor = true;
            this.chkprimaryAdapterEnabled.CheckedChanged += new System.EventHandler(chkprimaryAdapterEnabled_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cbobxsecondaryCommPort);
            this.tabPage2.Controls.Add(this.txtsecondarySendFreq);
            this.tabPage2.Controls.Add(this.cbobxsecondaryStreamSubIdx);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.chksecondaryAdapterEnabled);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbobxsecondaryCommPort
            // 
            this.cbobxsecondaryCommPort.FormattingEnabled = true;
            resources.ApplyResources(this.cbobxsecondaryCommPort, "cbobxsecondaryCommPort");
            this.cbobxsecondaryCommPort.Name = "cbobxsecondaryCommPort";
            // 
            // txtsecondarySendFreq
            // 
            resources.ApplyResources(this.txtsecondarySendFreq, "txtsecondarySendFreq");
            this.txtsecondarySendFreq.Name = "txtsecondarySendFreq";
            // 
            // cbobxsecondaryStreamSubIdx
            // 
            this.cbobxsecondaryStreamSubIdx.FormattingEnabled = true;
            resources.ApplyResources(this.cbobxsecondaryStreamSubIdx, "cbobxsecondaryStreamSubIdx");
            this.cbobxsecondaryStreamSubIdx.Name = "cbobxsecondaryStreamSubIdx";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // chksecondaryAdapterEnabled
            // 
            resources.ApplyResources(this.chksecondaryAdapterEnabled, "chksecondaryAdapterEnabled");
            this.chksecondaryAdapterEnabled.Name = "chksecondaryAdapterEnabled";
            this.chksecondaryAdapterEnabled.UseVisualStyleBackColor = true;
            this.chksecondaryAdapterEnabled.CheckedChanged += new System.EventHandler(chksecondaryAdapterEnabled_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbobxtertiaryCommPort);
            this.tabPage3.Controls.Add(this.txttertiarySendFreq);
            this.tabPage3.Controls.Add(this.cbobxtertiaryStreamSubIdx);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.chktertiaryAdapterEnabled);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbobxtertiaryCommPort
            // 
            this.cbobxtertiaryCommPort.FormattingEnabled = true;
            resources.ApplyResources(this.cbobxtertiaryCommPort, "cbobxtertiaryCommPort");
            this.cbobxtertiaryCommPort.Name = "cbobxtertiaryCommPort";
            // 
            // txttertiarySendFreq
            // 
            resources.ApplyResources(this.txttertiarySendFreq, "txttertiarySendFreq");
            this.txttertiarySendFreq.Name = "txttertiarySendFreq";
            // 
            // cbobxtertiaryStreamSubIdx
            // 
            this.cbobxtertiaryStreamSubIdx.FormattingEnabled = true;
            resources.ApplyResources(this.cbobxtertiaryStreamSubIdx, "cbobxtertiaryStreamSubIdx");
            this.cbobxtertiaryStreamSubIdx.Name = "cbobxtertiaryStreamSubIdx";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // chktertiaryAdapterEnabled
            // 
            resources.ApplyResources(this.chktertiaryAdapterEnabled, "chktertiaryAdapterEnabled");
            this.chktertiaryAdapterEnabled.Name = "chktertiaryAdapterEnabled";
            this.chktertiaryAdapterEnabled.UseVisualStyleBackColor = true;
            this.chktertiaryAdapterEnabled.CheckedChanged += new System.EventHandler(chktertiaryAdapterEnabled_CheckedChanged);
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
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(btnReset_Click);
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
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(btnSave_Click);
            // 
            // ProtocolAdapterSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TextBox txtprimarySendFreq;
        private System.Windows.Forms.ComboBox cbobxsecondaryCommPort;
        private System.Windows.Forms.TextBox txtsecondarySendFreq;
        private System.Windows.Forms.ComboBox cbobxsecondaryStreamSubIdx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chksecondaryAdapterEnabled;
        private System.Windows.Forms.ComboBox cbobxtertiaryCommPort;
        private System.Windows.Forms.TextBox txttertiarySendFreq;
        private System.Windows.Forms.ComboBox cbobxtertiaryStreamSubIdx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chktertiaryAdapterEnabled;
    }
}
