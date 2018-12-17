namespace GTI.Modules.SystemSettings.UI
{
	partial class MoneyCenterSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoneyCenterSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxMinPrizeWinAmount = new GTI.Controls.TextBoxNumeric();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numBankCloseSignatureLines = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPrintZeroAmount = new System.Windows.Forms.CheckBox();
            this.numBankCloseCopies = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numBankDropCopies = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numBankIssueCopies = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxFeeAmount = new GTI.Controls.TextBoxNumeric();
            this.textBoxMinimumPrizeAmount = new GTI.Controls.TextBoxNumeric();
            this.labelFeePercent = new System.Windows.Forms.Label();
            this.labelFeeType = new System.Windows.Forms.Label();
            this.radioButtonFeeFixed = new System.Windows.Forms.RadioButton();
            this.radioButtonFeePercent = new System.Windows.Forms.RadioButton();
            this.labelFeeAmount = new System.Windows.Forms.Label();
            this.labelMinimumPrizeAmount = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkMasterBankUsePreviousClose = new System.Windows.Forms.CheckBox();
            this.chkUsePreviousBankClosingAmount = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPayoutSignatureLinesCharactersLeft = new System.Windows.Forms.Label();
            this.lblPayoutSignatureLinesCharactersLeftTitle = new System.Windows.Forms.Label();
            this.txtPayoutSignatureLines = new System.Windows.Forms.TextBox();
            this.chkGetPlayerWithVerify = new System.Windows.Forms.CheckBox();
            this.chkPrintWordValue = new System.Windows.Forms.CheckBox();
            this.chkPrintWinnersAddress = new System.Windows.Forms.CheckBox();
            this.chkForcePlayerOnPayouts = new System.Windows.Forms.CheckBox();
            this.chkPrintAllPayoutWinners = new System.Windows.Forms.CheckBox();
            this.accrualGroupBox = new System.Windows.Forms.GroupBox();
            this.chkPrintAccrualIncrease = new System.Windows.Forms.CheckBox();
            this.chkPrintAccrualReseed = new System.Windows.Forms.CheckBox();
            this.chkPrintAccrualTransfer = new System.Windows.Forms.CheckBox();
            this.chkPrintAccrualReset = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBankCloseSignatureLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBankCloseCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBankDropCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBankIssueCopies)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.accrualGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.accrualGroupBox);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxMinPrizeWinAmount);
            this.groupBox6.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // textBoxMinPrizeWinAmount
            // 
            resources.ApplyResources(this.textBoxMinPrizeWinAmount, "textBoxMinPrizeWinAmount");
            this.textBoxMinPrizeWinAmount.Mask = GTI.Controls.TextBoxNumeric.TextBoxType.Decimal;
            this.textBoxMinPrizeWinAmount.Name = "textBoxMinPrizeWinAmount";
            this.textBoxMinPrizeWinAmount.Precision = 2;
            this.textBoxMinPrizeWinAmount.TextChanged += new System.EventHandler(this.textBoxMinPrizeWinAmount_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numBankCloseSignatureLines);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.chkPrintZeroAmount);
            this.groupBox2.Controls.Add(this.numBankCloseCopies);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.numBankDropCopies);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numBankIssueCopies);
            this.groupBox2.Controls.Add(this.label7);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // numBankCloseSignatureLines
            // 
            resources.ApplyResources(this.numBankCloseSignatureLines, "numBankCloseSignatureLines");
            this.numBankCloseSignatureLines.Name = "numBankCloseSignatureLines";
            this.numBankCloseSignatureLines.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBankCloseSignatureLines.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // chkPrintZeroAmount
            // 
            resources.ApplyResources(this.chkPrintZeroAmount, "chkPrintZeroAmount");
            this.chkPrintZeroAmount.Name = "chkPrintZeroAmount";
            this.chkPrintZeroAmount.UseVisualStyleBackColor = true;
            this.chkPrintZeroAmount.Click += new System.EventHandler(this.OnModified);
            // 
            // numBankCloseCopies
            // 
            resources.ApplyResources(this.numBankCloseCopies, "numBankCloseCopies");
            this.numBankCloseCopies.Name = "numBankCloseCopies";
            this.numBankCloseCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBankCloseCopies.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numBankDropCopies
            // 
            resources.ApplyResources(this.numBankDropCopies, "numBankDropCopies");
            this.numBankDropCopies.Name = "numBankDropCopies";
            this.numBankDropCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBankDropCopies.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numBankIssueCopies
            // 
            resources.ApplyResources(this.numBankIssueCopies, "numBankIssueCopies");
            this.numBankIssueCopies.Name = "numBankIssueCopies";
            this.numBankIssueCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBankIssueCopies.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxFeeAmount);
            this.groupBox5.Controls.Add(this.textBoxMinimumPrizeAmount);
            this.groupBox5.Controls.Add(this.labelFeePercent);
            this.groupBox5.Controls.Add(this.labelFeeType);
            this.groupBox5.Controls.Add(this.radioButtonFeeFixed);
            this.groupBox5.Controls.Add(this.radioButtonFeePercent);
            this.groupBox5.Controls.Add(this.labelFeeAmount);
            this.groupBox5.Controls.Add(this.labelMinimumPrizeAmount);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // textBoxFeeAmount
            // 
            resources.ApplyResources(this.textBoxFeeAmount, "textBoxFeeAmount");
            this.textBoxFeeAmount.Mask = GTI.Controls.TextBoxNumeric.TextBoxType.Decimal;
            this.textBoxFeeAmount.Name = "textBoxFeeAmount";
            this.textBoxFeeAmount.Precision = 2;
            this.textBoxFeeAmount.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // textBoxMinimumPrizeAmount
            // 
            resources.ApplyResources(this.textBoxMinimumPrizeAmount, "textBoxMinimumPrizeAmount");
            this.textBoxMinimumPrizeAmount.Mask = GTI.Controls.TextBoxNumeric.TextBoxType.Decimal;
            this.textBoxMinimumPrizeAmount.Name = "textBoxMinimumPrizeAmount";
            this.textBoxMinimumPrizeAmount.Precision = 2;
            this.textBoxMinimumPrizeAmount.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // labelFeePercent
            // 
            resources.ApplyResources(this.labelFeePercent, "labelFeePercent");
            this.labelFeePercent.Name = "labelFeePercent";
            // 
            // labelFeeType
            // 
            resources.ApplyResources(this.labelFeeType, "labelFeeType");
            this.labelFeeType.Name = "labelFeeType";
            // 
            // radioButtonFeeFixed
            // 
            resources.ApplyResources(this.radioButtonFeeFixed, "radioButtonFeeFixed");
            this.radioButtonFeeFixed.Name = "radioButtonFeeFixed";
            this.radioButtonFeeFixed.TabStop = true;
            this.radioButtonFeeFixed.UseVisualStyleBackColor = true;
            this.radioButtonFeeFixed.CheckedChanged += new System.EventHandler(this.radioButtonFeeFixed_CheckedChanged);
            this.radioButtonFeeFixed.Click += new System.EventHandler(this.OnModified);
            // 
            // radioButtonFeePercent
            // 
            resources.ApplyResources(this.radioButtonFeePercent, "radioButtonFeePercent");
            this.radioButtonFeePercent.Name = "radioButtonFeePercent";
            this.radioButtonFeePercent.TabStop = true;
            this.radioButtonFeePercent.UseVisualStyleBackColor = true;
            this.radioButtonFeePercent.CheckedChanged += new System.EventHandler(this.radioButtonFeePercent_CheckedChanged);
            this.radioButtonFeePercent.Click += new System.EventHandler(this.OnModified);
            // 
            // labelFeeAmount
            // 
            resources.ApplyResources(this.labelFeeAmount, "labelFeeAmount");
            this.labelFeeAmount.Name = "labelFeeAmount";
            // 
            // labelMinimumPrizeAmount
            // 
            resources.ApplyResources(this.labelMinimumPrizeAmount, "labelMinimumPrizeAmount");
            this.labelMinimumPrizeAmount.Name = "labelMinimumPrizeAmount";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkMasterBankUsePreviousClose);
            this.groupBox3.Controls.Add(this.chkUsePreviousBankClosingAmount);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkMasterBankUsePreviousClose
            // 
            resources.ApplyResources(this.chkMasterBankUsePreviousClose, "chkMasterBankUsePreviousClose");
            this.chkMasterBankUsePreviousClose.Name = "chkMasterBankUsePreviousClose";
            this.chkMasterBankUsePreviousClose.UseVisualStyleBackColor = true;
            this.chkMasterBankUsePreviousClose.Click += new System.EventHandler(this.OnModified);
            // 
            // chkUsePreviousBankClosingAmount
            // 
            resources.ApplyResources(this.chkUsePreviousBankClosingAmount, "chkUsePreviousBankClosingAmount");
            this.chkUsePreviousBankClosingAmount.Name = "chkUsePreviousBankClosingAmount";
            this.chkUsePreviousBankClosingAmount.UseVisualStyleBackColor = true;
            this.chkUsePreviousBankClosingAmount.CheckedChanged += new System.EventHandler(this.OnModified);
            this.chkUsePreviousBankClosingAmount.Click += new System.EventHandler(this.OnModified);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lblPayoutSignatureLinesCharactersLeft);
            this.groupBox4.Controls.Add(this.lblPayoutSignatureLinesCharactersLeftTitle);
            this.groupBox4.Controls.Add(this.txtPayoutSignatureLines);
            this.groupBox4.Controls.Add(this.chkGetPlayerWithVerify);
            this.groupBox4.Controls.Add(this.chkPrintWordValue);
            this.groupBox4.Controls.Add(this.chkPrintWinnersAddress);
            this.groupBox4.Controls.Add(this.chkForcePlayerOnPayouts);
            this.groupBox4.Controls.Add(this.chkPrintAllPayoutWinners);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblPayoutSignatureLinesCharactersLeft
            // 
            this.lblPayoutSignatureLinesCharactersLeft.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblPayoutSignatureLinesCharactersLeft, "lblPayoutSignatureLinesCharactersLeft");
            this.lblPayoutSignatureLinesCharactersLeft.ForeColor = System.Drawing.Color.Black;
            this.lblPayoutSignatureLinesCharactersLeft.Name = "lblPayoutSignatureLinesCharactersLeft";
            // 
            // lblPayoutSignatureLinesCharactersLeftTitle
            // 
            this.lblPayoutSignatureLinesCharactersLeftTitle.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblPayoutSignatureLinesCharactersLeftTitle, "lblPayoutSignatureLinesCharactersLeftTitle");
            this.lblPayoutSignatureLinesCharactersLeftTitle.ForeColor = System.Drawing.Color.Black;
            this.lblPayoutSignatureLinesCharactersLeftTitle.Name = "lblPayoutSignatureLinesCharactersLeftTitle";
            // 
            // txtPayoutSignatureLines
            // 
            this.txtPayoutSignatureLines.AcceptsReturn = true;
            resources.ApplyResources(this.txtPayoutSignatureLines, "txtPayoutSignatureLines");
            this.txtPayoutSignatureLines.Name = "txtPayoutSignatureLines";
            this.txtPayoutSignatureLines.TextChanged += new System.EventHandler(this.txtPayoutSignatureLines_TextChanged);
            this.txtPayoutSignatureLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPayoutSignatureLines_KeyDown);
            this.txtPayoutSignatureLines.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayoutSignatureLines_KeyPress);
            // 
            // chkGetPlayerWithVerify
            // 
            resources.ApplyResources(this.chkGetPlayerWithVerify, "chkGetPlayerWithVerify");
            this.chkGetPlayerWithVerify.Name = "chkGetPlayerWithVerify";
            this.chkGetPlayerWithVerify.UseVisualStyleBackColor = true;
            // 
            // chkPrintWordValue
            // 
            resources.ApplyResources(this.chkPrintWordValue, "chkPrintWordValue");
            this.chkPrintWordValue.BackColor = System.Drawing.Color.Transparent;
            this.chkPrintWordValue.Name = "chkPrintWordValue";
            this.chkPrintWordValue.UseVisualStyleBackColor = false;
            // 
            // chkPrintWinnersAddress
            // 
            resources.ApplyResources(this.chkPrintWinnersAddress, "chkPrintWinnersAddress");
            this.chkPrintWinnersAddress.Name = "chkPrintWinnersAddress";
            this.chkPrintWinnersAddress.UseVisualStyleBackColor = true;
            this.chkPrintWinnersAddress.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkForcePlayerOnPayouts
            // 
            resources.ApplyResources(this.chkForcePlayerOnPayouts, "chkForcePlayerOnPayouts");
            this.chkForcePlayerOnPayouts.Name = "chkForcePlayerOnPayouts";
            this.chkForcePlayerOnPayouts.UseVisualStyleBackColor = true;
            this.chkForcePlayerOnPayouts.Click += new System.EventHandler(this.OnModified);
            // 
            // chkPrintAllPayoutWinners
            // 
            resources.ApplyResources(this.chkPrintAllPayoutWinners, "chkPrintAllPayoutWinners");
            this.chkPrintAllPayoutWinners.Name = "chkPrintAllPayoutWinners";
            this.chkPrintAllPayoutWinners.UseVisualStyleBackColor = true;
            this.chkPrintAllPayoutWinners.Click += new System.EventHandler(this.OnModified);
            // 
            // accrualGroupBox
            // 
            this.accrualGroupBox.Controls.Add(this.chkPrintAccrualIncrease);
            this.accrualGroupBox.Controls.Add(this.chkPrintAccrualReseed);
            this.accrualGroupBox.Controls.Add(this.chkPrintAccrualTransfer);
            this.accrualGroupBox.Controls.Add(this.chkPrintAccrualReset);
            resources.ApplyResources(this.accrualGroupBox, "accrualGroupBox");
            this.accrualGroupBox.Name = "accrualGroupBox";
            this.accrualGroupBox.TabStop = false;
            // 
            // chkPrintAccrualIncrease
            // 
            resources.ApplyResources(this.chkPrintAccrualIncrease, "chkPrintAccrualIncrease");
            this.chkPrintAccrualIncrease.Name = "chkPrintAccrualIncrease";
            this.chkPrintAccrualIncrease.UseVisualStyleBackColor = true;
            this.chkPrintAccrualIncrease.Click += new System.EventHandler(this.OnModified);
            // 
            // chkPrintAccrualReseed
            // 
            resources.ApplyResources(this.chkPrintAccrualReseed, "chkPrintAccrualReseed");
            this.chkPrintAccrualReseed.Name = "chkPrintAccrualReseed";
            this.chkPrintAccrualReseed.UseVisualStyleBackColor = true;
            this.chkPrintAccrualReseed.Click += new System.EventHandler(this.OnModified);
            // 
            // chkPrintAccrualTransfer
            // 
            resources.ApplyResources(this.chkPrintAccrualTransfer, "chkPrintAccrualTransfer");
            this.chkPrintAccrualTransfer.Name = "chkPrintAccrualTransfer";
            this.chkPrintAccrualTransfer.UseVisualStyleBackColor = true;
            this.chkPrintAccrualTransfer.Click += new System.EventHandler(this.OnModified);
            // 
            // chkPrintAccrualReset
            // 
            resources.ApplyResources(this.chkPrintAccrualReset, "chkPrintAccrualReset");
            this.chkPrintAccrualReset.Name = "chkPrintAccrualReset";
            this.chkPrintAccrualReset.UseVisualStyleBackColor = true;
            this.chkPrintAccrualReset.Click += new System.EventHandler(this.OnModified);
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
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // MoneyCenterSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "MoneyCenterSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBankCloseSignatureLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBankCloseCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBankDropCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBankIssueCopies)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.accrualGroupBox.ResumeLayout(false);
            this.accrualGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkUsePreviousBankClosingAmount;
        private System.Windows.Forms.CheckBox chkMasterBankUsePreviousClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox accrualGroupBox;
        private System.Windows.Forms.CheckBox chkPrintAccrualIncrease;
        private System.Windows.Forms.CheckBox chkPrintAccrualReseed;
        private System.Windows.Forms.CheckBox chkPrintAccrualTransfer;
        private System.Windows.Forms.CheckBox chkPrintAccrualReset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkPrintAllPayoutWinners;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labelMinimumPrizeAmount;
        private System.Windows.Forms.RadioButton radioButtonFeeFixed;
        private System.Windows.Forms.RadioButton radioButtonFeePercent;
        private System.Windows.Forms.Label labelFeeAmount;
        private System.Windows.Forms.Label labelFeeType;
        private System.Windows.Forms.Label labelFeePercent;
        private System.Windows.Forms.ErrorProvider m_errorProvider;
        private System.Windows.Forms.CheckBox chkForcePlayerOnPayouts;
        private Controls.TextBoxNumeric textBoxMinimumPrizeAmount;
        private Controls.TextBoxNumeric textBoxFeeAmount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkPrintZeroAmount;
        private System.Windows.Forms.NumericUpDown numBankCloseCopies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBankDropCopies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numBankIssueCopies;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPrintWinnersAddress;
        private System.Windows.Forms.GroupBox groupBox6;
        private Controls.TextBoxNumeric textBoxMinPrizeWinAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkPrintWordValue;
        private System.Windows.Forms.NumericUpDown numBankCloseSignatureLines;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkGetPlayerWithVerify;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPayoutSignatureLinesCharactersLeft;
        private System.Windows.Forms.Label lblPayoutSignatureLinesCharactersLeftTitle;
        private System.Windows.Forms.TextBox txtPayoutSignatureLines;
	}
}
