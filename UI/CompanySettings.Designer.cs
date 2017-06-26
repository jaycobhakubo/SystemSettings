namespace GTI.Modules.SystemSettings.UI
{
	partial class CompanySettings
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
            System.Windows.Forms.Label ownerLabel;
            System.Windows.Forms.Label phoneLabel;
            System.Windows.Forms.Label companyNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanySettings));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ownerLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            companyNameLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ownerLabel
            // 
            ownerLabel.AutoSize = true;
            ownerLabel.BackColor = System.Drawing.Color.Transparent;
            ownerLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            ownerLabel.Location = new System.Drawing.Point(37, 197);
            ownerLabel.Name = "ownerLabel";
            ownerLabel.Size = new System.Drawing.Size(60, 22);
            ownerLabel.TabIndex = 5;
            ownerLabel.Text = "Owner";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.BackColor = System.Drawing.Color.Transparent;
            phoneLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            phoneLabel.Location = new System.Drawing.Point(37, 136);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(56, 22);
            phoneLabel.TabIndex = 3;
            phoneLabel.Text = "Phone";
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.BackColor = System.Drawing.Color.Transparent;
            companyNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            companyNameLabel.Location = new System.Drawing.Point(37, 71);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new System.Drawing.Size(127, 22);
            companyNameLabel.TabIndex = 1;
            companyNameLabel.Text = "Company Name";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageNormal")));
            this.btnReset.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnReset.ImagePressed")));
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(395, 590);
            this.btnReset.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageNormal")));
            this.btnSave.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSave.ImagePressed")));
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(246, 590);
            this.btnSave.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtOwner);
            this.groupBox1.Controls.Add(ownerLabel);
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(phoneLabel);
            this.groupBox1.Controls.Add(this.chkIsActive);
            this.groupBox1.Controls.Add(companyNameLabel);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(87, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(588, 258);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company General Information";
            // 
            // txtOwner
            // 
            this.txtOwner.AcceptsReturn = true;
            this.txtOwner.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtOwner.Location = new System.Drawing.Point(40, 221);
            this.txtOwner.MaxLength = 54;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(491, 26);
            this.txtOwner.TabIndex = 6;
            this.txtOwner.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtPhone.Location = new System.Drawing.Point(40, 160);
            this.txtPhone.MaxLength = 12;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(491, 26);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.TextChanged += new System.EventHandler(this.OnModified);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Enabled = false;
            this.chkIsActive.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkIsActive.Location = new System.Drawing.Point(40, 36);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(93, 26);
            this.chkIsActive.TabIndex = 0;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = false;
            this.chkIsActive.Visible = false;
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtName.Location = new System.Drawing.Point(40, 95);
            this.txtName.MaxLength = 59;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(491, 26);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtZip);
            this.groupBox2.Controls.Add(this.txtState);
            this.groupBox2.Controls.Add(this.txtCountry);
            this.groupBox2.Controls.Add(this.txtAddress1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCity);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtAddress2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(87, 303);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(588, 267);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Billing Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(395, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Zip";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(273, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "State";
            // 
            // txtZip
            // 
            this.txtZip.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtZip.Location = new System.Drawing.Point(399, 169);
            this.txtZip.MaxLength = 10;
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(132, 26);
            this.txtZip.TabIndex = 9;
            this.txtZip.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtState
            // 
            this.txtState.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtState.Location = new System.Drawing.Point(277, 169);
            this.txtState.MaxLength = 2;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(55, 26);
            this.txtState.TabIndex = 7;
            this.txtState.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtCountry
            // 
            this.txtCountry.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtCountry.Location = new System.Drawing.Point(40, 230);
            this.txtCountry.MaxLength = 32;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(491, 26);
            this.txtCountry.TabIndex = 11;
            this.txtCountry.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtAddress1.Location = new System.Drawing.Point(40, 49);
            this.txtAddress1.MaxLength = 56;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(491, 26);
            this.txtAddress1.TabIndex = 1;
            this.txtAddress1.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(37, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Address 1";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtCity.Location = new System.Drawing.Point(40, 169);
            this.txtCity.MaxLength = 22;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(185, 26);
            this.txtCity.TabIndex = 5;
            this.txtCity.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(37, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 22);
            this.label7.TabIndex = 4;
            this.label7.Text = "City";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.txtAddress2.Location = new System.Drawing.Point(40, 107);
            this.txtAddress2.MaxLength = 56;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(491, 26);
            this.txtAddress2.TabIndex = 3;
            this.txtAddress2.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(37, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 22);
            this.label10.TabIndex = 10;
            this.label10.Text = "Country";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(37, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "Address 2";
            // 
            // CompanySettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.Name = "CompanySettings";
            this.Size = new System.Drawing.Size(762, 644);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtOwner;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.CheckBox chkIsActive;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtZip;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.TextBox txtCountry;
		private System.Windows.Forms.TextBox txtAddress1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtAddress2;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label6;
	}
}
