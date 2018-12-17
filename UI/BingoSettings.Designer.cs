namespace GTI.Modules.SystemSettings.UI
{
	partial class BingoSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BingoSettings));
            this.m_labelMaxCardLimit = new System.Windows.Forms.Label();
            this.m_MaxBetValueLabel = new System.Windows.Forms.Label();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbHeadcountMethod = new System.Windows.Forms.ComboBox();
            this.lblHeadcountMethod = new System.Windows.Forms.Label();
            this.quickDrawGB = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.quickDrawElecPermLbl = new System.Windows.Forms.Label();
            this.quickDrawCardsExpireLbl2 = new System.Windows.Forms.Label();
            this.quickDrawCardsExpireNUD = new System.Windows.Forms.NumericUpDown();
            this.quickDrawCardsExpireLbl1 = new System.Windows.Forms.Label();
            this.quickDrawElecPermFileCombo = new System.Windows.Forms.ComboBox();
            this.chkSequentialGames = new System.Windows.Forms.CheckBox();
            this.txtVoidLockGames = new System.Windows.Forms.TextBox();
            this.lblVoidLock = new System.Windows.Forms.Label();
            this.m_chkForcePackToPlayer = new System.Windows.Forms.CheckBox();
            this.lblCBBGamePost = new System.Windows.Forms.Label();
            this.lblCBBGame = new System.Windows.Forms.Label();
            this.txtLockCBBGames = new System.Windows.Forms.TextBox();
            this.numMaxBet = new System.Windows.Forms.NumericUpDown();
            this.chkConsecutiveCards = new System.Windows.Forms.CheckBox();
            this.chkSameCard = new System.Windows.Forms.CheckBox();
            this.numMaxCardLimit = new System.Windows.Forms.NumericUpDown();
            this.groupBox5.SuspendLayout();
            this.quickDrawGB.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quickDrawCardsExpireNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCardLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // m_labelMaxCardLimit
            // 
            resources.ApplyResources(this.m_labelMaxCardLimit, "m_labelMaxCardLimit");
            this.m_labelMaxCardLimit.ForeColor = System.Drawing.Color.Black;
            this.m_labelMaxCardLimit.Name = "m_labelMaxCardLimit";
            // 
            // m_MaxBetValueLabel
            // 
            resources.ApplyResources(this.m_MaxBetValueLabel, "m_MaxBetValueLabel");
            this.m_MaxBetValueLabel.Name = "m_MaxBetValueLabel";
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
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.cbHeadcountMethod);
            this.groupBox5.Controls.Add(this.lblHeadcountMethod);
            this.groupBox5.Controls.Add(this.quickDrawGB);
            this.groupBox5.Controls.Add(this.chkSequentialGames);
            this.groupBox5.Controls.Add(this.txtVoidLockGames);
            this.groupBox5.Controls.Add(this.lblVoidLock);
            this.groupBox5.Controls.Add(this.m_chkForcePackToPlayer);
            this.groupBox5.Controls.Add(this.lblCBBGamePost);
            this.groupBox5.Controls.Add(this.lblCBBGame);
            this.groupBox5.Controls.Add(this.txtLockCBBGames);
            this.groupBox5.Controls.Add(this.numMaxBet);
            this.groupBox5.Controls.Add(this.m_MaxBetValueLabel);
            this.groupBox5.Controls.Add(this.chkConsecutiveCards);
            this.groupBox5.Controls.Add(this.chkSameCard);
            this.groupBox5.Controls.Add(this.numMaxCardLimit);
            this.groupBox5.Controls.Add(this.m_labelMaxCardLimit);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // cbHeadcountMethod
            // 
            this.cbHeadcountMethod.FormattingEnabled = true;
            this.cbHeadcountMethod.Items.AddRange(new object[] {
            resources.GetString("cbHeadcountMethod.Items"),
            resources.GetString("cbHeadcountMethod.Items1"),
            resources.GetString("cbHeadcountMethod.Items2")});
            resources.ApplyResources(this.cbHeadcountMethod, "cbHeadcountMethod");
            this.cbHeadcountMethod.Name = "cbHeadcountMethod";
            this.cbHeadcountMethod.SelectedIndexChanged += new System.EventHandler(this.OnModified);
            // 
            // lblHeadcountMethod
            // 
            this.lblHeadcountMethod.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.lblHeadcountMethod, "lblHeadcountMethod");
            this.lblHeadcountMethod.Name = "lblHeadcountMethod";
            // 
            // quickDrawGB
            // 
            this.quickDrawGB.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.quickDrawGB, "quickDrawGB");
            this.quickDrawGB.Name = "quickDrawGB";
            this.quickDrawGB.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.quickDrawElecPermLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.quickDrawCardsExpireLbl2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.quickDrawCardsExpireNUD, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.quickDrawCardsExpireLbl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.quickDrawElecPermFileCombo, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // quickDrawElecPermLbl
            // 
            resources.ApplyResources(this.quickDrawElecPermLbl, "quickDrawElecPermLbl");
            this.quickDrawElecPermLbl.Name = "quickDrawElecPermLbl";
            // 
            // quickDrawCardsExpireLbl2
            // 
            resources.ApplyResources(this.quickDrawCardsExpireLbl2, "quickDrawCardsExpireLbl2");
            this.quickDrawCardsExpireLbl2.Name = "quickDrawCardsExpireLbl2";
            // 
            // quickDrawCardsExpireNUD
            // 
            resources.ApplyResources(this.quickDrawCardsExpireNUD, "quickDrawCardsExpireNUD");
            this.quickDrawCardsExpireNUD.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.quickDrawCardsExpireNUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.quickDrawCardsExpireNUD.Name = "quickDrawCardsExpireNUD";
            this.quickDrawCardsExpireNUD.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.quickDrawCardsExpireNUD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quickDrawCardsExpireNUD_KeyPress);
            this.quickDrawCardsExpireNUD.Leave += new System.EventHandler(this.quickDrawCardsExpireNUD_Leave);
            // 
            // quickDrawCardsExpireLbl1
            // 
            resources.ApplyResources(this.quickDrawCardsExpireLbl1, "quickDrawCardsExpireLbl1");
            this.quickDrawCardsExpireLbl1.Name = "quickDrawCardsExpireLbl1";
            // 
            // quickDrawElecPermFileCombo
            // 
            resources.ApplyResources(this.quickDrawElecPermFileCombo, "quickDrawElecPermFileCombo");
            this.tableLayoutPanel1.SetColumnSpan(this.quickDrawElecPermFileCombo, 2);
            this.quickDrawElecPermFileCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quickDrawElecPermFileCombo.FormattingEnabled = true;
            this.quickDrawElecPermFileCombo.Name = "quickDrawElecPermFileCombo";
            // 
            // chkSequentialGames
            // 
            resources.ApplyResources(this.chkSequentialGames, "chkSequentialGames");
            this.chkSequentialGames.Name = "chkSequentialGames";
            this.chkSequentialGames.UseVisualStyleBackColor = true;
            this.chkSequentialGames.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // txtVoidLockGames
            // 
            resources.ApplyResources(this.txtVoidLockGames, "txtVoidLockGames");
            this.txtVoidLockGames.Name = "txtVoidLockGames";
            this.txtVoidLockGames.TextChanged += new System.EventHandler(this.OnModified);
            this.txtVoidLockGames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLockCBBGames_KeyPress);
            // 
            // lblVoidLock
            // 
            resources.ApplyResources(this.lblVoidLock, "lblVoidLock");
            this.lblVoidLock.Name = "lblVoidLock";
            // 
            // m_chkForcePackToPlayer
            // 
            resources.ApplyResources(this.m_chkForcePackToPlayer, "m_chkForcePackToPlayer");
            this.m_chkForcePackToPlayer.Name = "m_chkForcePackToPlayer";
            this.m_chkForcePackToPlayer.UseVisualStyleBackColor = true;
            this.m_chkForcePackToPlayer.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // lblCBBGamePost
            // 
            resources.ApplyResources(this.lblCBBGamePost, "lblCBBGamePost");
            this.lblCBBGamePost.Name = "lblCBBGamePost";
            // 
            // lblCBBGame
            // 
            resources.ApplyResources(this.lblCBBGame, "lblCBBGame");
            this.lblCBBGame.Name = "lblCBBGame";
            // 
            // txtLockCBBGames
            // 
            resources.ApplyResources(this.txtLockCBBGames, "txtLockCBBGames");
            this.txtLockCBBGames.Name = "txtLockCBBGames";
            this.txtLockCBBGames.TextChanged += new System.EventHandler(this.OnModified);
            this.txtLockCBBGames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLockCBBGames_KeyPress);
            // 
            // numMaxBet
            // 
            this.numMaxBet.DecimalPlaces = 2;
            resources.ApplyResources(this.numMaxBet, "numMaxBet");
            this.numMaxBet.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxBet.Name = "numMaxBet";
            this.numMaxBet.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // chkConsecutiveCards
            // 
            resources.ApplyResources(this.chkConsecutiveCards, "chkConsecutiveCards");
            this.chkConsecutiveCards.Name = "chkConsecutiveCards";
            this.chkConsecutiveCards.UseVisualStyleBackColor = true;
            this.chkConsecutiveCards.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkSameCard
            // 
            resources.ApplyResources(this.chkSameCard, "chkSameCard");
            this.chkSameCard.Name = "chkSameCard";
            this.chkSameCard.UseVisualStyleBackColor = true;
            this.chkSameCard.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // numMaxCardLimit
            // 
            resources.ApplyResources(this.numMaxCardLimit, "numMaxCardLimit");
            this.numMaxCardLimit.ForeColor = System.Drawing.Color.Black;
            this.numMaxCardLimit.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numMaxCardLimit.Name = "numMaxCardLimit";
            this.numMaxCardLimit.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // BingoSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "BingoSettings";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.quickDrawGB.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quickDrawCardsExpireNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxBet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxCardLimit)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown numMaxCardLimit;
		private System.Windows.Forms.CheckBox chkConsecutiveCards;
        private System.Windows.Forms.CheckBox chkSameCard;
        private System.Windows.Forms.TextBox txtLockCBBGames;
        private System.Windows.Forms.Label lblCBBGamePost;
        private System.Windows.Forms.Label lblCBBGame;
        private System.Windows.Forms.Label m_MaxBetValueLabel;
        private System.Windows.Forms.NumericUpDown numMaxBet;
        private System.Windows.Forms.Label m_labelMaxCardLimit;
        private System.Windows.Forms.CheckBox m_chkForcePackToPlayer;
        private System.Windows.Forms.TextBox txtVoidLockGames;
        private System.Windows.Forms.Label lblVoidLock;
        private System.Windows.Forms.CheckBox chkSequentialGames;
        private System.Windows.Forms.GroupBox quickDrawGB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label quickDrawElecPermLbl;
        private System.Windows.Forms.Label quickDrawCardsExpireLbl2;
        private System.Windows.Forms.NumericUpDown quickDrawCardsExpireNUD;
        private System.Windows.Forms.Label quickDrawCardsExpireLbl1;
        private System.Windows.Forms.ComboBox quickDrawElecPermFileCombo;
        private System.Windows.Forms.ComboBox cbHeadcountMethod;
        private System.Windows.Forms.Label lblHeadcountMethod;
	}
}
