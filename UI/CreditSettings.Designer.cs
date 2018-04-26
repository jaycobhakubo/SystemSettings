namespace GTI.Modules.SystemSettings.UI
{
	partial class CreditSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxCreditWin = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numMinWinAmount = new GTI.Controls.TextBoxNumeric();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPurgeExtra = new System.Windows.Forms.Label();
            this.numMaxInactivityAge = new System.Windows.Forms.NumericUpDown();
            this.lblPurgeMaxInactivity = new System.Windows.Forms.Label();
            this.numMinPurgeAmt = new System.Windows.Forms.NumericUpDown();
            this.lblMinPurgeAmt = new System.Windows.Forms.Label();
            this.chkPurgeCredits = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCreditWin)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxInactivityAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPurgeAmt)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageNormal")));
            this.btnReset.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnReset.ImagePressed")));
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
            this.btnSave.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageNormal")));
            this.btnSave.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSave.ImagePressed")));
            this.btnSave.Name = "btnSave";
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numMaxCreditWin
            // 
            this.numMaxCreditWin.DecimalPlaces = 2;
            resources.ApplyResources(this.numMaxCreditWin, "numMaxCreditWin");
            this.numMaxCreditWin.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMaxCreditWin.Name = "numMaxCreditWin";
            this.numMaxCreditWin.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numMinWinAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPurgeExtra);
            this.groupBox1.Controls.Add(this.numMaxInactivityAge);
            this.groupBox1.Controls.Add(this.lblPurgeMaxInactivity);
            this.groupBox1.Controls.Add(this.numMinPurgeAmt);
            this.groupBox1.Controls.Add(this.lblMinPurgeAmt);
            this.groupBox1.Controls.Add(this.chkPurgeCredits);
            this.groupBox1.Controls.Add(this.numMaxCreditWin);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // numMinWinAmount
            // 
            resources.ApplyResources(this.numMinWinAmount, "numMinWinAmount");
            this.numMinWinAmount.Mask = GTI.Controls.TextBoxNumeric.TextBoxType.Decimal;
            this.numMinWinAmount.Name = "numMinWinAmount";
            this.numMinWinAmount.Precision = 2;
            this.numMinWinAmount.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblPurgeExtra
            // 
            resources.ApplyResources(this.lblPurgeExtra, "lblPurgeExtra");
            this.lblPurgeExtra.Name = "lblPurgeExtra";
            // 
            // numMaxInactivityAge
            // 
            resources.ApplyResources(this.numMaxInactivityAge, "numMaxInactivityAge");
            this.numMaxInactivityAge.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numMaxInactivityAge.Name = "numMaxInactivityAge";
            this.numMaxInactivityAge.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblPurgeMaxInactivity
            // 
            resources.ApplyResources(this.lblPurgeMaxInactivity, "lblPurgeMaxInactivity");
            this.lblPurgeMaxInactivity.Name = "lblPurgeMaxInactivity";
            // 
            // numMinPurgeAmt
            // 
            this.numMinPurgeAmt.DecimalPlaces = 2;
            resources.ApplyResources(this.numMinPurgeAmt, "numMinPurgeAmt");
            this.numMinPurgeAmt.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numMinPurgeAmt.Name = "numMinPurgeAmt";
            this.numMinPurgeAmt.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblMinPurgeAmt
            // 
            resources.ApplyResources(this.lblMinPurgeAmt, "lblMinPurgeAmt");
            this.lblMinPurgeAmt.Name = "lblMinPurgeAmt";
            // 
            // chkPurgeCredits
            // 
            resources.ApplyResources(this.chkPurgeCredits, "chkPurgeCredits");
            this.chkPurgeCredits.Name = "chkPurgeCredits";
            this.chkPurgeCredits.UseVisualStyleBackColor = true;
            this.chkPurgeCredits.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // CreditSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "CreditSettings";
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCreditWin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxInactivityAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinPurgeAmt)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numMaxCreditWin;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblMinPurgeAmt;
		private System.Windows.Forms.CheckBox chkPurgeCredits;
		private System.Windows.Forms.NumericUpDown numMinPurgeAmt;
		private System.Windows.Forms.Label lblPurgeExtra;
		private System.Windows.Forms.NumericUpDown numMaxInactivityAge;
		private System.Windows.Forms.Label lblPurgeMaxInactivity;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controls.TextBoxNumeric numMinWinAmount;
	}
}
