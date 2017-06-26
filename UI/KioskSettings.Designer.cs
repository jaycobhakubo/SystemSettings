namespace GTI.Modules.SystemSettings.UI
{
	partial class KioskSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KioskSettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new GTI.Controls.ImageButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.titleMessgeGroupBox = new System.Windows.Forms.GroupBox();
            this.txtLine1 = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.numTimeout = new System.Windows.Forms.NumericUpDown();
            this.grpSwipe = new System.Windows.Forms.GroupBox();
            this.cboSwipeMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSwipeModeSpecifics2 = new System.Windows.Forms.Label();
            this.numSwipeModeSpecifics = new System.Windows.Forms.NumericUpDown();
            this.lblSwipeModeSpecifics1 = new System.Windows.Forms.Label();
            this.numPointsPerSwipe = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBillCoinAcceptor = new System.Windows.Forms.GroupBox();
            this.txtCoinAcceptor = new System.Windows.Forms.TextBox();
            this.txtBillAcceptor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFont = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.btnColor = new GTI.Controls.ImageButton();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.btnLineColor = new GTI.Controls.ImageButton();
            this.txtLineColor = new System.Windows.Forms.TextBox();
            this.titleMessgeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).BeginInit();
            this.grpSwipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSwipeModeSpecifics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsPerSwipe)).BeginInit();
            this.grpBillCoinAcceptor.SuspendLayout();
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
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Name = "label9";
            // 
            // titleMessgeGroupBox
            // 
            this.titleMessgeGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.titleMessgeGroupBox.Controls.Add(this.txtLine1);
            this.titleMessgeGroupBox.Controls.Add(this.txtTitle);
            this.titleMessgeGroupBox.Controls.Add(this.label3);
            this.titleMessgeGroupBox.Controls.Add(this.label7);
            resources.ApplyResources(this.titleMessgeGroupBox, "titleMessgeGroupBox");
            this.titleMessgeGroupBox.Name = "titleMessgeGroupBox";
            this.titleMessgeGroupBox.TabStop = false;
            // 
            // txtLine1
            // 
            resources.ApplyResources(this.txtLine1, "txtLine1");
            this.txtLine1.Name = "txtLine1";
            this.txtLine1.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.txtTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // numTimeout
            // 
            this.numTimeout.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.numTimeout, "numTimeout");
            this.numTimeout.Maximum = new decimal(new int[] {
            14400,
            0,
            0,
            0});
            this.numTimeout.Name = "numTimeout";
            this.numTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // grpSwipe
            // 
            this.grpSwipe.Controls.Add(this.cboSwipeMode);
            this.grpSwipe.Controls.Add(this.label5);
            this.grpSwipe.Controls.Add(this.lblSwipeModeSpecifics2);
            this.grpSwipe.Controls.Add(this.numSwipeModeSpecifics);
            this.grpSwipe.Controls.Add(this.lblSwipeModeSpecifics1);
            this.grpSwipe.Controls.Add(this.numPointsPerSwipe);
            this.grpSwipe.Controls.Add(this.label1);
            resources.ApplyResources(this.grpSwipe, "grpSwipe");
            this.grpSwipe.Name = "grpSwipe";
            this.grpSwipe.TabStop = false;
            // 
            // cboSwipeMode
            // 
            this.cboSwipeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboSwipeMode, "cboSwipeMode");
            this.cboSwipeMode.FormattingEnabled = true;
            this.cboSwipeMode.Items.AddRange(new object[] {
            resources.GetString("cboSwipeMode.Items"),
            resources.GetString("cboSwipeMode.Items1"),
            resources.GetString("cboSwipeMode.Items2"),
            resources.GetString("cboSwipeMode.Items3"),
            resources.GetString("cboSwipeMode.Items4")});
            this.cboSwipeMode.Name = "cboSwipeMode";
            this.cboSwipeMode.SelectedIndexChanged += new System.EventHandler(this.cboSwipeMode_SelectedIndexChanged);
            this.cboSwipeMode.SelectionChangeCommitted += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblSwipeModeSpecifics2
            // 
            resources.ApplyResources(this.lblSwipeModeSpecifics2, "lblSwipeModeSpecifics2");
            this.lblSwipeModeSpecifics2.Name = "lblSwipeModeSpecifics2";
            // 
            // numSwipeModeSpecifics
            // 
            resources.ApplyResources(this.numSwipeModeSpecifics, "numSwipeModeSpecifics");
            this.numSwipeModeSpecifics.Maximum = new decimal(new int[] {
            1439,
            0,
            0,
            0});
            this.numSwipeModeSpecifics.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSwipeModeSpecifics.Name = "numSwipeModeSpecifics";
            this.numSwipeModeSpecifics.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSwipeModeSpecifics.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblSwipeModeSpecifics1
            // 
            resources.ApplyResources(this.lblSwipeModeSpecifics1, "lblSwipeModeSpecifics1");
            this.lblSwipeModeSpecifics1.Name = "lblSwipeModeSpecifics1";
            // 
            // numPointsPerSwipe
            // 
            this.numPointsPerSwipe.BackColor = System.Drawing.Color.White;
            this.numPointsPerSwipe.DecimalPlaces = 2;
            resources.ApplyResources(this.numPointsPerSwipe, "numPointsPerSwipe");
            this.numPointsPerSwipe.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            131072});
            this.numPointsPerSwipe.Name = "numPointsPerSwipe";
            this.numPointsPerSwipe.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // grpBillCoinAcceptor
            // 
            this.grpBillCoinAcceptor.Controls.Add(this.txtCoinAcceptor);
            this.grpBillCoinAcceptor.Controls.Add(this.txtBillAcceptor);
            this.grpBillCoinAcceptor.Controls.Add(this.label4);
            this.grpBillCoinAcceptor.Controls.Add(this.label2);
            resources.ApplyResources(this.grpBillCoinAcceptor, "grpBillCoinAcceptor");
            this.grpBillCoinAcceptor.Name = "grpBillCoinAcceptor";
            this.grpBillCoinAcceptor.TabStop = false;
            // 
            // txtCoinAcceptor
            // 
            resources.ApplyResources(this.txtCoinAcceptor, "txtCoinAcceptor");
            this.txtCoinAcceptor.Name = "txtCoinAcceptor";
            this.txtCoinAcceptor.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtBillAcceptor
            // 
            resources.ApplyResources(this.txtBillAcceptor, "txtBillAcceptor");
            this.txtBillAcceptor.Name = "txtBillAcceptor";
            this.txtBillAcceptor.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cboFont
            // 
            this.cboFont.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cboFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFont.FormattingEnabled = true;
            resources.ApplyResources(this.cboFont, "cboFont");
            this.cboFont.Name = "cboFont";
            this.cboFont.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cboFont_DrawItem);
            this.cboFont.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.cboFont_MeasureItem);
            this.cboFont.SelectedIndexChanged += new System.EventHandler(this.cboFont_SelectedIndexChanged);
            this.cboFont.SelectedValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Transparent;
            this.btnColor.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnColor, "btnColor");
            this.btnColor.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnColor.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnColor.Name = "btnColor";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtColor
            // 
            resources.ApplyResources(this.txtColor, "txtColor");
            this.txtColor.Name = "txtColor";
            this.txtColor.TabStop = false;
            this.txtColor.Enter += new System.EventHandler(this.txtColor_Enter);
            this.txtColor.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // btnLineColor
            // 
            this.btnLineColor.BackColor = System.Drawing.Color.Transparent;
            this.btnLineColor.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnLineColor, "btnLineColor");
            this.btnLineColor.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnLineColor.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.Click += new System.EventHandler(this.btnLineColor_Click);
            // 
            // txtLineColor
            // 
            resources.ApplyResources(this.txtLineColor, "txtLineColor");
            this.txtLineColor.Name = "txtLineColor";
            this.txtLineColor.TabStop = false;
            this.txtLineColor.Enter += new System.EventHandler(this.txtLineColor_Enter);
            this.txtLineColor.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // KioskSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.txtLineColor);
            this.Controls.Add(this.btnLineColor);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboFont);
            this.Controls.Add(this.grpBillCoinAcceptor);
            this.Controls.Add(this.grpSwipe);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.titleMessgeGroupBox);
            this.Controls.Add(this.numTimeout);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "KioskSettings";
            this.titleMessgeGroupBox.ResumeLayout(false);
            this.titleMessgeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeout)).EndInit();
            this.grpSwipe.ResumeLayout(false);
            this.grpSwipe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSwipeModeSpecifics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsPerSwipe)).EndInit();
            this.grpBillCoinAcceptor.ResumeLayout(false);
            this.grpBillCoinAcceptor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
        private System.Windows.Forms.Label label7;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox titleMessgeGroupBox;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.NumericUpDown numTimeout;
        private System.Windows.Forms.GroupBox grpSwipe;
		private System.Windows.Forms.NumericUpDown numPointsPerSwipe;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblSwipeModeSpecifics1;
		private System.Windows.Forms.NumericUpDown numSwipeModeSpecifics;
		private System.Windows.Forms.Label lblSwipeModeSpecifics2;
		private System.Windows.Forms.ComboBox cboSwipeMode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpBillCoinAcceptor;
		private System.Windows.Forms.TextBox txtBillAcceptor;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCoinAcceptor;
        private System.Windows.Forms.ComboBox cboFont;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label8;
        private GTI.Controls.ImageButton btnColor;
        private System.Windows.Forms.TextBox txtColor;
        private GTI.Controls.ImageButton btnLineColor;
        private System.Windows.Forms.TextBox txtLineColor;
        private System.Windows.Forms.TextBox txtLine1;
	}
}
