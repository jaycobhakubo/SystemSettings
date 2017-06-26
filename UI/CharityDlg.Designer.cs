namespace GTI.Modules.SystemSettings.UI
{
	partial class CharityDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharityDlg));
            this.btnCancel = new GTI.Controls.ImageButton();
            this.btnOK = new GTI.Controls.ImageButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.charityInformationGroupBox = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.charityInformationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageNormal")));
            this.btnCancel.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImagePressed")));
            this.btnCancel.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.Leave += new System.EventHandler(this.btnCancel_Leave);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnOK.ImageNormal")));
            this.btnOK.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnOK.ImagePressed")));
            this.btnOK.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtName
            // 
            this.txtName.CausesValidation = false;
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtPhone
            // 
            this.txtPhone.CausesValidation = false;
            resources.ApplyResources(this.txtPhone, "txtPhone");
            this.txtPhone.Name = "txtPhone";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtContact
            // 
            this.txtContact.CausesValidation = false;
            resources.ApplyResources(this.txtContact, "txtContact");
            this.txtContact.Name = "txtContact";
            // 
            // chkIsActive
            // 
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chkIsActive, "chkIsActive");
            this.chkIsActive.ForeColor = System.Drawing.Color.Black;
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.UseVisualStyleBackColor = false;
            // 
            // txtLicense
            // 
            this.txtLicense.CausesValidation = false;
            resources.ApplyResources(this.txtLicense, "txtLicense");
            this.txtLicense.Name = "txtLicense";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // charityInformationGroupBox
            // 
            this.charityInformationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.charityInformationGroupBox.Controls.Add(this.label9);
            this.charityInformationGroupBox.Controls.Add(this.label8);
            this.charityInformationGroupBox.Controls.Add(this.txtZip);
            this.charityInformationGroupBox.Controls.Add(this.txtState);
            this.charityInformationGroupBox.Controls.Add(this.txtCountry);
            this.charityInformationGroupBox.Controls.Add(this.txtAddress1);
            this.charityInformationGroupBox.Controls.Add(this.label5);
            this.charityInformationGroupBox.Controls.Add(this.txtCity);
            this.charityInformationGroupBox.Controls.Add(this.label7);
            this.charityInformationGroupBox.Controls.Add(this.txtAddress2);
            this.charityInformationGroupBox.Controls.Add(this.label10);
            this.charityInformationGroupBox.Controls.Add(this.label6);
            this.charityInformationGroupBox.Controls.Add(this.label12);
            this.charityInformationGroupBox.Controls.Add(this.txtTaxId);
            this.charityInformationGroupBox.Controls.Add(this.label11);
            this.charityInformationGroupBox.Controls.Add(this.txtLicense);
            this.charityInformationGroupBox.Controls.Add(this.txtContact);
            this.charityInformationGroupBox.Controls.Add(this.label4);
            this.charityInformationGroupBox.Controls.Add(this.label3);
            this.charityInformationGroupBox.Controls.Add(this.txtPhone);
            this.charityInformationGroupBox.Controls.Add(this.label1);
            this.charityInformationGroupBox.Controls.Add(this.txtName);
            resources.ApplyResources(this.charityInformationGroupBox, "charityInformationGroupBox");
            this.charityInformationGroupBox.ForeColor = System.Drawing.Color.Black;
            this.charityInformationGroupBox.Name = "charityInformationGroupBox";
            this.charityInformationGroupBox.TabStop = false;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtTaxId
            // 
            this.txtTaxId.CausesValidation = false;
            resources.ApplyResources(this.txtTaxId, "txtTaxId");
            this.txtTaxId.Name = "txtTaxId";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtState
            // 
            resources.ApplyResources(this.txtState, "txtState");
            this.txtState.Name = "txtState";
            // 
            // txtCountry
            // 
            this.txtCountry.CausesValidation = false;
            resources.ApplyResources(this.txtCountry, "txtCountry");
            this.txtCountry.Name = "txtCountry";
            // 
            // txtAddress1
            // 
            resources.ApplyResources(this.txtAddress1, "txtAddress1");
            this.txtAddress1.Name = "txtAddress1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtCity
            // 
            resources.ApplyResources(this.txtCity, "txtCity");
            this.txtCity.Name = "txtCity";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtAddress2
            // 
            resources.ApplyResources(this.txtAddress2, "txtAddress2");
            this.txtAddress2.Name = "txtAddress2";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtZip
            // 
            resources.ApplyResources(this.txtZip, "txtZip");
            this.txtZip.Name = "txtZip";
            // 
            // CharityDlg
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.charityInformationGroupBox);
            this.Controls.Add(this.chkIsActive);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharityDlg";
            this.ShowInTaskbar = false;
            this.charityInformationGroupBox.ResumeLayout(false);
            this.charityInformationGroupBox.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private GTI.Controls.ImageButton btnCancel;
		private GTI.Controls.ImageButton btnOK;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox charityInformationGroupBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTaxId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
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