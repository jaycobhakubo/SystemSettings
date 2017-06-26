namespace GTI.Modules.SystemSettings.UI
{
	partial class KioskSettings2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KioskSettings2));
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnGetImage = new GTI.Controls.ImageButton();
            this.cboPhotoType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new GTI.Controls.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
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
            // pbImage
            // 
            resources.ApplyResources(this.pbImage, "pbImage");
            this.pbImage.Name = "pbImage";
            this.pbImage.TabStop = false;
            // 
            // btnGetImage
            // 
            this.btnGetImage.BackColor = System.Drawing.Color.Transparent;
            this.btnGetImage.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnGetImage, "btnGetImage");
            this.btnGetImage.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnGetImage.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnGetImage.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnGetImage.Name = "btnGetImage";
            this.btnGetImage.UseVisualStyleBackColor = false;
            this.btnGetImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // cboPhotoType
            // 
            this.cboPhotoType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhotoType.FormattingEnabled = true;
            resources.ApplyResources(this.cboPhotoType, "cboPhotoType");
            this.cboPhotoType.Name = "cboPhotoType";
            this.cboPhotoType.SelectedIndexChanged += new System.EventHandler(this.cboPhotoType_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnDelete.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnDelete.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.Leave += new System.EventHandler(this.btnDelete_Leave);
            // 
            // KioskSettings2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPhotoType);
            this.Controls.Add(this.btnGetImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "KioskSettings2";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private GTI.Controls.ImageButton btnReset;
        private GTI.Controls.ImageButton btnSave;
        private System.Windows.Forms.PictureBox pbImage;
        private GTI.Controls.ImageButton btnGetImage;
        private System.Windows.Forms.ComboBox cboPhotoType;
        private System.Windows.Forms.Label label1;
        private GTI.Controls.ImageButton btnDelete;
	}
}
