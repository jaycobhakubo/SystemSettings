namespace GTI.Modules.SystemSettings.UI
{
	partial class RaffleSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaffleSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numMonetaryRaffleDuration = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDisplayPlayerImage = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRunFromLocation = new System.Windows.Forms.ComboBox();
            this.numRaffleDuration = new System.Windows.Forms.NumericUpDown();
            this.lblRaffleDuration = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDisplayedText = new System.Windows.Forms.ComboBox();
            this.chkEnterRaffle = new System.Windows.Forms.CheckBox();
            this.chkRemoveWinner = new System.Windows.Forms.CheckBox();
            this.numPlayersNeededForRaffle = new System.Windows.Forms.NumericUpDown();
            this.lblMinimumPlayers = new System.Windows.Forms.Label();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryRaffleDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaffleDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayersNeededForRaffle)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numMonetaryRaffleDuration);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkDisplayPlayerImage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboRunFromLocation);
            this.groupBox1.Controls.Add(this.numRaffleDuration);
            this.groupBox1.Controls.Add(this.lblRaffleDuration);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboDisplayedText);
            this.groupBox1.Controls.Add(this.chkEnterRaffle);
            this.groupBox1.Controls.Add(this.chkRemoveWinner);
            this.groupBox1.Controls.Add(this.numPlayersNeededForRaffle);
            this.groupBox1.Controls.Add(this.lblMinimumPlayers);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // numMonetaryRaffleDuration
            // 
            resources.ApplyResources(this.numMonetaryRaffleDuration, "numMonetaryRaffleDuration");
            this.numMonetaryRaffleDuration.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numMonetaryRaffleDuration.Name = "numMonetaryRaffleDuration";
            this.numMonetaryRaffleDuration.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // chkDisplayPlayerImage
            // 
            resources.ApplyResources(this.chkDisplayPlayerImage, "chkDisplayPlayerImage");
            this.chkDisplayPlayerImage.Name = "chkDisplayPlayerImage";
            this.chkDisplayPlayerImage.UseVisualStyleBackColor = true;
            this.chkDisplayPlayerImage.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cboRunFromLocation
            // 
            this.cboRunFromLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboRunFromLocation, "cboRunFromLocation");
            this.cboRunFromLocation.FormattingEnabled = true;
            this.cboRunFromLocation.Items.AddRange(new object[] {
            resources.GetString("cboRunFromLocation.Items"),
            resources.GetString("cboRunFromLocation.Items1")});
            this.cboRunFromLocation.Name = "cboRunFromLocation";
            this.cboRunFromLocation.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // numRaffleDuration
            // 
            resources.ApplyResources(this.numRaffleDuration, "numRaffleDuration");
            this.numRaffleDuration.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numRaffleDuration.Name = "numRaffleDuration";
            this.numRaffleDuration.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblRaffleDuration
            // 
            this.lblRaffleDuration.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblRaffleDuration, "lblRaffleDuration");
            this.lblRaffleDuration.Name = "lblRaffleDuration";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cboDisplayedText
            // 
            this.cboDisplayedText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboDisplayedText, "cboDisplayedText");
            this.cboDisplayedText.FormattingEnabled = true;
            this.cboDisplayedText.Items.AddRange(new object[] {
            resources.GetString("cboDisplayedText.Items"),
            resources.GetString("cboDisplayedText.Items1")});
            this.cboDisplayedText.Name = "cboDisplayedText";
            this.cboDisplayedText.SelectedIndexChanged += new System.EventHandler(this.cboDisplayedText_SelectedIndexChanged);
            // 
            // chkEnterRaffle
            // 
            resources.ApplyResources(this.chkEnterRaffle, "chkEnterRaffle");
            this.chkEnterRaffle.Name = "chkEnterRaffle";
            this.chkEnterRaffle.UseVisualStyleBackColor = true;
            this.chkEnterRaffle.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkRemoveWinner
            // 
            resources.ApplyResources(this.chkRemoveWinner, "chkRemoveWinner");
            this.chkRemoveWinner.Name = "chkRemoveWinner";
            this.chkRemoveWinner.UseVisualStyleBackColor = true;
            this.chkRemoveWinner.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // numPlayersNeededForRaffle
            // 
            resources.ApplyResources(this.numPlayersNeededForRaffle, "numPlayersNeededForRaffle");
            this.numPlayersNeededForRaffle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayersNeededForRaffle.Name = "numPlayersNeededForRaffle";
            this.numPlayersNeededForRaffle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayersNeededForRaffle.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // lblMinimumPlayers
            // 
            resources.ApplyResources(this.lblMinimumPlayers, "lblMinimumPlayers");
            this.lblMinimumPlayers.Name = "lblMinimumPlayers";
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
            // RaffleSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "RaffleSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryRaffleDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRaffleDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayersNeededForRaffle)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numPlayersNeededForRaffle;
		private System.Windows.Forms.Label lblMinimumPlayers;
		private System.Windows.Forms.CheckBox chkRemoveWinner;
        private System.Windows.Forms.CheckBox chkEnterRaffle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDisplayedText;
        private System.Windows.Forms.NumericUpDown numRaffleDuration;
        private System.Windows.Forms.Label lblRaffleDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRunFromLocation;
        private System.Windows.Forms.CheckBox chkDisplayPlayerImage;
        private System.Windows.Forms.NumericUpDown numMonetaryRaffleDuration;
        private System.Windows.Forms.Label label3;
	}
}
