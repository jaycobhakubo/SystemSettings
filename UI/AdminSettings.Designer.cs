namespace GTI.Modules.SystemSettings.UI
{
	partial class AdminSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtEndOfDay = new System.Windows.Forms.DateTimePicker();
            this.txtServerRoot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtServerInstallDrive = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDbPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDbUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAllowAnonymousPlay = new System.Windows.Forms.CheckBox();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtEndOfDay);
            this.groupBox1.Controls.Add(this.txtServerRoot);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtServerInstallDrive);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDbPwd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDbUser);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDbName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDbServer);
            this.groupBox1.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dtEndOfDay
            // 
            resources.ApplyResources(this.dtEndOfDay, "dtEndOfDay");
            this.dtEndOfDay.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtEndOfDay.Name = "dtEndOfDay";
            this.dtEndOfDay.ShowUpDown = true;
            this.dtEndOfDay.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtServerRoot
            // 
            resources.ApplyResources(this.txtServerRoot, "txtServerRoot");
            this.txtServerRoot.Name = "txtServerRoot";
            this.txtServerRoot.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtServerInstallDrive
            // 
            resources.ApplyResources(this.txtServerInstallDrive, "txtServerInstallDrive");
            this.txtServerInstallDrive.Name = "txtServerInstallDrive";
            this.txtServerInstallDrive.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtDbPwd
            // 
            resources.ApplyResources(this.txtDbPwd, "txtDbPwd");
            this.txtDbPwd.Name = "txtDbPwd";
            this.txtDbPwd.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtDbUser
            // 
            resources.ApplyResources(this.txtDbUser, "txtDbUser");
            this.txtDbUser.Name = "txtDbUser";
            this.txtDbUser.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtDbName
            // 
            resources.ApplyResources(this.txtDbName, "txtDbName");
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtDbServer
            // 
            resources.ApplyResources(this.txtDbServer, "txtDbServer");
            this.txtDbServer.Name = "txtDbServer";
            this.txtDbServer.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkAllowAnonymousPlay
            // 
            resources.ApplyResources(this.chkAllowAnonymousPlay, "chkAllowAnonymousPlay");
            this.chkAllowAnonymousPlay.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkAllowAnonymousPlay.Name = "chkAllowAnonymousPlay";
            this.chkAllowAnonymousPlay.UseVisualStyleBackColor = false;
            this.chkAllowAnonymousPlay.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnReset.Name = "btnReset";
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
            this.btnSave.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AdminSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chkAllowAnonymousPlay);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "AdminSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.TextBox txtDbServer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDbPwd;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDbUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDbName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtServerRoot;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtServerInstallDrive;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtEndOfDay;
		private System.Windows.Forms.CheckBox chkAllowAnonymousPlay;
	}
}
