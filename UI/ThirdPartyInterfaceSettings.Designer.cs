namespace GTI.Modules.SystemSettings.UI
{
    partial class ThirdPartyInterfaceSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThirdPartyInterfaceSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPlayerSyncMode = new System.Windows.Forms.Label();
            this.cbxPlayerSyncMode = new System.Windows.Forms.ComboBox();
            this.gbFNET = new System.Windows.Forms.GroupBox();
            this.cbPointsTransferAsDollarsForRedemptions = new System.Windows.Forms.CheckBox();
            this.cbPointsTransferAsDollarsForSales = new System.Windows.Forms.CheckBox();
            this.cbPointsTransferAsDollars = new System.Windows.Forms.CheckBox();
            this.cbPlayerInfoHasPoints = new System.Windows.Forms.CheckBox();
            this.gbPIN = new System.Windows.Forms.GroupBox();
            this.cbGetPINAtCardSwipe = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPINLength = new System.Windows.Forms.NumericUpDown();
            this.cbPINForVoidRedemption = new System.Windows.Forms.CheckBox();
            this.cbPINForVoidRating = new System.Windows.Forms.CheckBox();
            this.cbPINForPointInfo = new System.Windows.Forms.CheckBox();
            this.cbPINForRedemption = new System.Windows.Forms.CheckBox();
            this.cbPINForRating = new System.Windows.Forms.CheckBox();
            this.cbPINForPlayerInfo = new System.Windows.Forms.CheckBox();
            this.gbTimeout = new System.Windows.Forms.GroupBox();
            this.lblTimeout2 = new System.Windows.Forms.Label();
            this.rbIndependentTimeouts = new System.Windows.Forms.RadioButton();
            this.rbControlTimeout = new System.Windows.Forms.RadioButton();
            this.rbSlaveTimeout = new System.Windows.Forms.RadioButton();
            this.thirdPartyTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTimeout1 = new System.Windows.Forms.Label();
            this.gbOasis10 = new System.Windows.Forms.GroupBox();
            this.thirdPartyLocation = new System.Windows.Forms.TextBox();
            this.lblOasisLocation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbInterface = new System.Windows.Forms.ComboBox();
            this.gbRedeemed = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.thirdPartyRedeemPerPoints = new System.Windows.Forms.NumericUpDown();
            this.thirdPartyRedeemPennies = new System.Windows.Forms.NumericUpDown();
            this.lblPointsFor = new System.Windows.Forms.Label();
            this.gbEarned = new System.Windows.Forms.GroupBox();
            this.cbExternalRating = new System.Windows.Forms.CheckBox();
            this.lblSpent = new System.Windows.Forms.Label();
            this.lblEarn = new System.Windows.Forms.Label();
            this.lblDollarSignForSpent = new System.Windows.Forms.Label();
            this.thirdPartyEarnPerPennies = new System.Windows.Forms.NumericUpDown();
            this.thirdPartyEarnPoints = new System.Windows.Forms.NumericUpDown();
            this.lblPointsEarned = new System.Windows.Forms.Label();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1.SuspendLayout();
            this.gbFNET.SuspendLayout();
            this.gbPIN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPINLength)).BeginInit();
            this.gbTimeout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyTimeout)).BeginInit();
            this.gbOasis10.SuspendLayout();
            this.gbRedeemed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyRedeemPerPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyRedeemPennies)).BeginInit();
            this.gbEarned.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyEarnPerPennies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyEarnPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPlayerSyncMode);
            this.groupBox1.Controls.Add(this.cbxPlayerSyncMode);
            this.groupBox1.Controls.Add(this.gbFNET);
            this.groupBox1.Controls.Add(this.gbPIN);
            this.groupBox1.Controls.Add(this.gbTimeout);
            this.groupBox1.Controls.Add(this.gbOasis10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbInterface);
            this.groupBox1.Controls.Add(this.gbRedeemed);
            this.groupBox1.Controls.Add(this.gbEarned);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblPlayerSyncMode
            // 
            resources.ApplyResources(this.lblPlayerSyncMode, "lblPlayerSyncMode");
            this.lblPlayerSyncMode.Name = "lblPlayerSyncMode";
            // 
            // cbxPlayerSyncMode
            // 
            this.cbxPlayerSyncMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbxPlayerSyncMode, "cbxPlayerSyncMode");
            this.cbxPlayerSyncMode.FormattingEnabled = true;
            this.cbxPlayerSyncMode.Items.AddRange(new object[] {
            resources.GetString("cbxPlayerSyncMode.Items"),
            resources.GetString("cbxPlayerSyncMode.Items1"),
            resources.GetString("cbxPlayerSyncMode.Items2")});
            this.cbxPlayerSyncMode.Name = "cbxPlayerSyncMode";
            // 
            // gbFNET
            // 
            this.gbFNET.Controls.Add(this.cbPointsTransferAsDollarsForRedemptions);
            this.gbFNET.Controls.Add(this.cbPointsTransferAsDollarsForSales);
            this.gbFNET.Controls.Add(this.cbPointsTransferAsDollars);
            this.gbFNET.Controls.Add(this.cbPlayerInfoHasPoints);
            resources.ApplyResources(this.gbFNET, "gbFNET");
            this.gbFNET.Name = "gbFNET";
            this.gbFNET.TabStop = false;
            // 
            // cbPointsTransferAsDollarsForRedemptions
            // 
            resources.ApplyResources(this.cbPointsTransferAsDollarsForRedemptions, "cbPointsTransferAsDollarsForRedemptions");
            this.cbPointsTransferAsDollarsForRedemptions.BackColor = System.Drawing.Color.Transparent;
            this.cbPointsTransferAsDollarsForRedemptions.Name = "cbPointsTransferAsDollarsForRedemptions";
            this.cbPointsTransferAsDollarsForRedemptions.UseVisualStyleBackColor = false;
            this.cbPointsTransferAsDollarsForRedemptions.CheckedChanged += new System.EventHandler(this.cbPointsTransferAsDollarsForRedemptions_CheckedChanged);
            // 
            // cbPointsTransferAsDollarsForSales
            // 
            resources.ApplyResources(this.cbPointsTransferAsDollarsForSales, "cbPointsTransferAsDollarsForSales");
            this.cbPointsTransferAsDollarsForSales.BackColor = System.Drawing.Color.Transparent;
            this.cbPointsTransferAsDollarsForSales.Name = "cbPointsTransferAsDollarsForSales";
            this.cbPointsTransferAsDollarsForSales.UseVisualStyleBackColor = false;
            this.cbPointsTransferAsDollarsForSales.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPointsTransferAsDollars
            // 
            resources.ApplyResources(this.cbPointsTransferAsDollars, "cbPointsTransferAsDollars");
            this.cbPointsTransferAsDollars.BackColor = System.Drawing.Color.Transparent;
            this.cbPointsTransferAsDollars.Name = "cbPointsTransferAsDollars";
            this.cbPointsTransferAsDollars.UseVisualStyleBackColor = false;
            this.cbPointsTransferAsDollars.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPlayerInfoHasPoints
            // 
            resources.ApplyResources(this.cbPlayerInfoHasPoints, "cbPlayerInfoHasPoints");
            this.cbPlayerInfoHasPoints.BackColor = System.Drawing.Color.Transparent;
            this.cbPlayerInfoHasPoints.Name = "cbPlayerInfoHasPoints";
            this.cbPlayerInfoHasPoints.UseVisualStyleBackColor = false;
            this.cbPlayerInfoHasPoints.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // gbPIN
            // 
            this.gbPIN.Controls.Add(this.cbGetPINAtCardSwipe);
            this.gbPIN.Controls.Add(this.label1);
            this.gbPIN.Controls.Add(this.nudPINLength);
            this.gbPIN.Controls.Add(this.cbPINForVoidRedemption);
            this.gbPIN.Controls.Add(this.cbPINForVoidRating);
            this.gbPIN.Controls.Add(this.cbPINForPointInfo);
            this.gbPIN.Controls.Add(this.cbPINForRedemption);
            this.gbPIN.Controls.Add(this.cbPINForRating);
            this.gbPIN.Controls.Add(this.cbPINForPlayerInfo);
            resources.ApplyResources(this.gbPIN, "gbPIN");
            this.gbPIN.Name = "gbPIN";
            this.gbPIN.TabStop = false;
            // 
            // cbGetPINAtCardSwipe
            // 
            resources.ApplyResources(this.cbGetPINAtCardSwipe, "cbGetPINAtCardSwipe");
            this.cbGetPINAtCardSwipe.Name = "cbGetPINAtCardSwipe";
            this.cbGetPINAtCardSwipe.UseVisualStyleBackColor = true;
            this.cbGetPINAtCardSwipe.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // nudPINLength
            // 
            resources.ApplyResources(this.nudPINLength, "nudPINLength");
            this.nudPINLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPINLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPINLength.Name = "nudPINLength";
            this.nudPINLength.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudPINLength.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPINForVoidRedemption
            // 
            resources.ApplyResources(this.cbPINForVoidRedemption, "cbPINForVoidRedemption");
            this.cbPINForVoidRedemption.Name = "cbPINForVoidRedemption";
            this.cbPINForVoidRedemption.UseVisualStyleBackColor = true;
            this.cbPINForVoidRedemption.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPINForVoidRating
            // 
            resources.ApplyResources(this.cbPINForVoidRating, "cbPINForVoidRating");
            this.cbPINForVoidRating.Name = "cbPINForVoidRating";
            this.cbPINForVoidRating.UseVisualStyleBackColor = true;
            this.cbPINForVoidRating.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPINForPointInfo
            // 
            resources.ApplyResources(this.cbPINForPointInfo, "cbPINForPointInfo");
            this.cbPINForPointInfo.Name = "cbPINForPointInfo";
            this.cbPINForPointInfo.UseVisualStyleBackColor = true;
            this.cbPINForPointInfo.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPINForRedemption
            // 
            resources.ApplyResources(this.cbPINForRedemption, "cbPINForRedemption");
            this.cbPINForRedemption.Name = "cbPINForRedemption";
            this.cbPINForRedemption.UseVisualStyleBackColor = true;
            this.cbPINForRedemption.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPINForRating
            // 
            resources.ApplyResources(this.cbPINForRating, "cbPINForRating");
            this.cbPINForRating.Name = "cbPINForRating";
            this.cbPINForRating.UseVisualStyleBackColor = true;
            this.cbPINForRating.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // cbPINForPlayerInfo
            // 
            resources.ApplyResources(this.cbPINForPlayerInfo, "cbPINForPlayerInfo");
            this.cbPINForPlayerInfo.Name = "cbPINForPlayerInfo";
            this.cbPINForPlayerInfo.UseVisualStyleBackColor = true;
            this.cbPINForPlayerInfo.CheckedChanged += new System.EventHandler(this.cbPINForPlayerInfo_CheckedChanged);
            // 
            // gbTimeout
            // 
            this.gbTimeout.Controls.Add(this.lblTimeout2);
            this.gbTimeout.Controls.Add(this.rbIndependentTimeouts);
            this.gbTimeout.Controls.Add(this.rbControlTimeout);
            this.gbTimeout.Controls.Add(this.rbSlaveTimeout);
            this.gbTimeout.Controls.Add(this.thirdPartyTimeout);
            this.gbTimeout.Controls.Add(this.lblTimeout1);
            resources.ApplyResources(this.gbTimeout, "gbTimeout");
            this.gbTimeout.Name = "gbTimeout";
            this.gbTimeout.TabStop = false;
            // 
            // lblTimeout2
            // 
            resources.ApplyResources(this.lblTimeout2, "lblTimeout2");
            this.lblTimeout2.Name = "lblTimeout2";
            // 
            // rbIndependentTimeouts
            // 
            resources.ApplyResources(this.rbIndependentTimeouts, "rbIndependentTimeouts");
            this.rbIndependentTimeouts.Name = "rbIndependentTimeouts";
            this.rbIndependentTimeouts.UseVisualStyleBackColor = true;
            this.rbIndependentTimeouts.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // rbControlTimeout
            // 
            resources.ApplyResources(this.rbControlTimeout, "rbControlTimeout");
            this.rbControlTimeout.Checked = true;
            this.rbControlTimeout.Name = "rbControlTimeout";
            this.rbControlTimeout.TabStop = true;
            this.rbControlTimeout.UseVisualStyleBackColor = true;
            this.rbControlTimeout.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // rbSlaveTimeout
            // 
            resources.ApplyResources(this.rbSlaveTimeout, "rbSlaveTimeout");
            this.rbSlaveTimeout.Name = "rbSlaveTimeout";
            this.rbSlaveTimeout.UseVisualStyleBackColor = true;
            this.rbSlaveTimeout.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // thirdPartyTimeout
            // 
            resources.ApplyResources(this.thirdPartyTimeout, "thirdPartyTimeout");
            this.thirdPartyTimeout.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.thirdPartyTimeout.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.thirdPartyTimeout.Name = "thirdPartyTimeout";
            this.thirdPartyTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.thirdPartyTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblTimeout1
            // 
            resources.ApplyResources(this.lblTimeout1, "lblTimeout1");
            this.lblTimeout1.Name = "lblTimeout1";
            // 
            // gbOasis10
            // 
            this.gbOasis10.Controls.Add(this.thirdPartyLocation);
            this.gbOasis10.Controls.Add(this.lblOasisLocation);
            resources.ApplyResources(this.gbOasis10, "gbOasis10");
            this.gbOasis10.Name = "gbOasis10";
            this.gbOasis10.TabStop = false;
            // 
            // thirdPartyLocation
            // 
            resources.ApplyResources(this.thirdPartyLocation, "thirdPartyLocation");
            this.thirdPartyLocation.Name = "thirdPartyLocation";
            this.thirdPartyLocation.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // lblOasisLocation
            // 
            resources.ApplyResources(this.lblOasisLocation, "lblOasisLocation");
            this.lblOasisLocation.Name = "lblOasisLocation";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cbInterface
            // 
            this.cbInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbInterface, "cbInterface");
            this.cbInterface.FormattingEnabled = true;
            this.cbInterface.Name = "cbInterface";
            this.cbInterface.SelectedIndexChanged += new System.EventHandler(this.cbInterface_SelectedIndexChanged);
            // 
            // gbRedeemed
            // 
            this.gbRedeemed.Controls.Add(this.label9);
            this.gbRedeemed.Controls.Add(this.thirdPartyRedeemPerPoints);
            this.gbRedeemed.Controls.Add(this.thirdPartyRedeemPennies);
            this.gbRedeemed.Controls.Add(this.lblPointsFor);
            resources.ApplyResources(this.gbRedeemed, "gbRedeemed");
            this.gbRedeemed.Name = "gbRedeemed";
            this.gbRedeemed.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // thirdPartyRedeemPerPoints
            // 
            resources.ApplyResources(this.thirdPartyRedeemPerPoints, "thirdPartyRedeemPerPoints");
            this.thirdPartyRedeemPerPoints.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.thirdPartyRedeemPerPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thirdPartyRedeemPerPoints.Name = "thirdPartyRedeemPerPoints";
            this.thirdPartyRedeemPerPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thirdPartyRedeemPerPoints.ValueChanged += new System.EventHandler(this.thirdPartyRedeemPerPoints_ValueChanged);
            // 
            // thirdPartyRedeemPennies
            // 
            this.thirdPartyRedeemPennies.DecimalPlaces = 2;
            resources.ApplyResources(this.thirdPartyRedeemPennies, "thirdPartyRedeemPennies");
            this.thirdPartyRedeemPennies.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.thirdPartyRedeemPennies.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.thirdPartyRedeemPennies.Name = "thirdPartyRedeemPennies";
            this.thirdPartyRedeemPennies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thirdPartyRedeemPennies.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblPointsFor
            // 
            resources.ApplyResources(this.lblPointsFor, "lblPointsFor");
            this.lblPointsFor.Name = "lblPointsFor";
            this.lblPointsFor.UseMnemonic = false;
            // 
            // gbEarned
            // 
            this.gbEarned.Controls.Add(this.cbExternalRating);
            this.gbEarned.Controls.Add(this.lblSpent);
            this.gbEarned.Controls.Add(this.lblEarn);
            this.gbEarned.Controls.Add(this.lblDollarSignForSpent);
            this.gbEarned.Controls.Add(this.thirdPartyEarnPerPennies);
            this.gbEarned.Controls.Add(this.thirdPartyEarnPoints);
            this.gbEarned.Controls.Add(this.lblPointsEarned);
            resources.ApplyResources(this.gbEarned, "gbEarned");
            this.gbEarned.Name = "gbEarned";
            this.gbEarned.TabStop = false;
            // 
            // cbExternalRating
            // 
            resources.ApplyResources(this.cbExternalRating, "cbExternalRating");
            this.cbExternalRating.Name = "cbExternalRating";
            this.cbExternalRating.UseVisualStyleBackColor = true;
            this.cbExternalRating.CheckedChanged += new System.EventHandler(this.cbExternalRating_CheckedChanged);
            // 
            // lblSpent
            // 
            resources.ApplyResources(this.lblSpent, "lblSpent");
            this.lblSpent.Name = "lblSpent";
            // 
            // lblEarn
            // 
            resources.ApplyResources(this.lblEarn, "lblEarn");
            this.lblEarn.Name = "lblEarn";
            // 
            // lblDollarSignForSpent
            // 
            this.lblDollarSignForSpent.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblDollarSignForSpent, "lblDollarSignForSpent");
            this.lblDollarSignForSpent.Name = "lblDollarSignForSpent";
            // 
            // thirdPartyEarnPerPennies
            // 
            this.thirdPartyEarnPerPennies.DecimalPlaces = 2;
            resources.ApplyResources(this.thirdPartyEarnPerPennies, "thirdPartyEarnPerPennies");
            this.thirdPartyEarnPerPennies.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.thirdPartyEarnPerPennies.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.thirdPartyEarnPerPennies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.thirdPartyEarnPerPennies.Name = "thirdPartyEarnPerPennies";
            this.thirdPartyEarnPerPennies.Value = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.thirdPartyEarnPerPennies.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // thirdPartyEarnPoints
            // 
            resources.ApplyResources(this.thirdPartyEarnPoints, "thirdPartyEarnPoints");
            this.thirdPartyEarnPoints.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.thirdPartyEarnPoints.Name = "thirdPartyEarnPoints";
            this.thirdPartyEarnPoints.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thirdPartyEarnPoints.ValueChanged += new System.EventHandler(this.thirdPartyEarnPoints_ValueChanged);
            // 
            // lblPointsEarned
            // 
            resources.ApplyResources(this.lblPointsEarned, "lblPointsEarned");
            this.lblPointsEarned.Name = "lblPointsEarned";
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
            // ThirdPartyInterfaceSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "ThirdPartyInterfaceSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFNET.ResumeLayout(false);
            this.gbFNET.PerformLayout();
            this.gbPIN.ResumeLayout(false);
            this.gbPIN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPINLength)).EndInit();
            this.gbTimeout.ResumeLayout(false);
            this.gbTimeout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyTimeout)).EndInit();
            this.gbOasis10.ResumeLayout(false);
            this.gbOasis10.PerformLayout();
            this.gbRedeemed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyRedeemPerPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyRedeemPennies)).EndInit();
            this.gbEarned.ResumeLayout(false);
            this.gbEarned.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyEarnPerPennies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdPartyEarnPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTimeout1;
        private System.Windows.Forms.Label lblOasisLocation;
        private System.Windows.Forms.Label lblPointsEarned;
        private System.Windows.Forms.Label lblPointsFor;
        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;
        private System.Windows.Forms.NumericUpDown thirdPartyTimeout;
        private System.Windows.Forms.NumericUpDown thirdPartyRedeemPerPoints;
        private System.Windows.Forms.NumericUpDown thirdPartyRedeemPennies;
        private System.Windows.Forms.NumericUpDown thirdPartyEarnPerPennies;
        private System.Windows.Forms.NumericUpDown thirdPartyEarnPoints;
        private System.Windows.Forms.TextBox thirdPartyLocation;
        private System.Windows.Forms.GroupBox gbRedeemed;
        private System.Windows.Forms.GroupBox gbEarned;
        private System.Windows.Forms.Label lblDollarSignForSpent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEarn;
        private System.Windows.Forms.Label lblSpent;
        private System.Windows.Forms.ComboBox cbInterface;
        private System.Windows.Forms.GroupBox gbPIN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbPINForPointInfo;
        private System.Windows.Forms.CheckBox cbPINForRedemption;
        private System.Windows.Forms.CheckBox cbPINForRating;
        private System.Windows.Forms.CheckBox cbPINForPlayerInfo;
        private System.Windows.Forms.GroupBox gbTimeout;
        private System.Windows.Forms.Label lblTimeout2;
        private System.Windows.Forms.RadioButton rbIndependentTimeouts;
        private System.Windows.Forms.RadioButton rbControlTimeout;
        private System.Windows.Forms.RadioButton rbSlaveTimeout;
        private System.Windows.Forms.CheckBox cbPINForVoidRedemption;
        private System.Windows.Forms.CheckBox cbPINForVoidRating;
        private System.Windows.Forms.GroupBox gbOasis10;
        private System.Windows.Forms.CheckBox cbExternalRating;
        private System.Windows.Forms.CheckBox cbGetPINAtCardSwipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudPINLength;
        private System.Windows.Forms.GroupBox gbFNET;
        private System.Windows.Forms.CheckBox cbPointsTransferAsDollarsForRedemptions;
        private System.Windows.Forms.CheckBox cbPointsTransferAsDollarsForSales;
        private System.Windows.Forms.CheckBox cbPointsTransferAsDollars;
        private System.Windows.Forms.CheckBox cbPlayerInfoHasPoints;
        private System.Windows.Forms.Label lblPlayerSyncMode;
        private System.Windows.Forms.ComboBox cbxPlayerSyncMode;
    }
}
