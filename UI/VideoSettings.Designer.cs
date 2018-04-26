namespace GTI.Modules.SystemSettings.UI
{
	partial class VideoSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numColorDepth = new System.Windows.Forms.NumericUpDown();
            this.numRefreshRate = new System.Windows.Forms.NumericUpDown();
            this.numScreenHeight = new System.Windows.Forms.NumericUpDown();
            this.numScreenWidth = new System.Windows.Forms.NumericUpDown();
            this.numVideoAdapterId = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseHardwareAccel = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColorDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoAdapterId)).BeginInit();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numColorDepth);
            this.groupBox1.Controls.Add(this.numRefreshRate);
            this.groupBox1.Controls.Add(this.numScreenHeight);
            this.groupBox1.Controls.Add(this.numScreenWidth);
            this.groupBox1.Controls.Add(this.numVideoAdapterId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkUseHardwareAccel);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // numColorDepth
            // 
            this.numColorDepth.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            resources.ApplyResources(this.numColorDepth, "numColorDepth");
            this.numColorDepth.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numColorDepth.Name = "numColorDepth";
            this.numColorDepth.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // numRefreshRate
            // 
            resources.ApplyResources(this.numRefreshRate, "numRefreshRate");
            this.numRefreshRate.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numRefreshRate.Name = "numRefreshRate";
            this.numRefreshRate.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // numScreenHeight
            // 
            resources.ApplyResources(this.numScreenHeight, "numScreenHeight");
            this.numScreenHeight.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numScreenHeight.Name = "numScreenHeight";
            this.numScreenHeight.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // numScreenWidth
            // 
            resources.ApplyResources(this.numScreenWidth, "numScreenWidth");
            this.numScreenWidth.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numScreenWidth.Name = "numScreenWidth";
            this.numScreenWidth.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // numVideoAdapterId
            // 
            this.numVideoAdapterId.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            resources.ApplyResources(this.numVideoAdapterId, "numVideoAdapterId");
            this.numVideoAdapterId.Name = "numVideoAdapterId";
            this.numVideoAdapterId.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
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
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Name = "label1";
            // 
            // chkUseHardwareAccel
            // 
            resources.ApplyResources(this.chkUseHardwareAccel, "chkUseHardwareAccel");
            this.chkUseHardwareAccel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkUseHardwareAccel.Name = "chkUseHardwareAccel";
            this.chkUseHardwareAccel.UseVisualStyleBackColor = false;
            this.chkUseHardwareAccel.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // VideoSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "VideoSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numColorDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoAdapterId)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkUseHardwareAccel;
		private System.Windows.Forms.NumericUpDown numColorDepth;
		private System.Windows.Forms.NumericUpDown numRefreshRate;
		private System.Windows.Forms.NumericUpDown numScreenHeight;
		private System.Windows.Forms.NumericUpDown numScreenWidth;
		private System.Windows.Forms.NumericUpDown numVideoAdapterId;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
