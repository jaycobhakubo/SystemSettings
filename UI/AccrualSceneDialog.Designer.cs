namespace GTI.Modules.SystemSettings.UI
{
    partial class AccrualSceneDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccrualSceneDialog));
            this.btnCancel = new GTI.Controls.ImageButton();
            this.btnOK = new GTI.Controls.ImageButton();
            this.labelDisplayText = new System.Windows.Forms.Label();
            this.listBoxAccrualScene = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewAccruals = new System.Windows.Forms.ListView();
            this.ButtonUp = new GTI.Controls.ImageButton();
            this.ButtonDown = new GTI.Controls.ImageButton();
            this.textBoxAccrualText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageNormal")));
            this.btnCancel.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImagePressed")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnOK.ImageNormal")));
            this.btnOK.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnOK.ImagePressed")));
            this.btnOK.Name = "btnOK";
            this.btnOK.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelDisplayText
            // 
            resources.ApplyResources(this.labelDisplayText, "labelDisplayText");
            this.labelDisplayText.BackColor = System.Drawing.Color.Transparent;
            this.labelDisplayText.Name = "labelDisplayText";
            // 
            // listBoxAccrualScene
            // 
            this.listBoxAccrualScene.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxAccrualScene, "listBoxAccrualScene");
            this.listBoxAccrualScene.Name = "listBoxAccrualScene";
            this.listBoxAccrualScene.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // listViewAccruals
            // 
            this.listViewAccruals.CheckBoxes = true;
            resources.ApplyResources(this.listViewAccruals, "listViewAccruals");
            this.listViewAccruals.Name = "listViewAccruals";
            this.listViewAccruals.UseCompatibleStateImageBehavior = false;
            this.listViewAccruals.View = System.Windows.Forms.View.List;
            this.listViewAccruals.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            // 
            // ButtonUp
            // 
            this.ButtonUp.BackColor = System.Drawing.Color.Transparent;
            this.ButtonUp.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ButtonUp, "ButtonUp");
            this.ButtonUp.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.ButtonUp.ImagePressed = ((System.Drawing.Image)(resources.GetObject("ButtonUp.ImagePressed")));
            this.ButtonUp.Name = "ButtonUp";
            this.ButtonUp.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.ButtonUp.UseVisualStyleBackColor = false;
            this.ButtonUp.Click += new System.EventHandler(this.ButtonUp_Click);
            // 
            // ButtonDown
            // 
            this.ButtonDown.BackColor = System.Drawing.Color.Transparent;
            this.ButtonDown.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.ButtonDown, "ButtonDown");
            this.ButtonDown.ImageNormal = ((System.Drawing.Image)(resources.GetObject("ButtonDown.ImageNormal")));
            this.ButtonDown.ImagePressed = ((System.Drawing.Image)(resources.GetObject("ButtonDown.ImagePressed")));
            this.ButtonDown.Name = "ButtonDown";
            this.ButtonDown.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.ButtonDown.UseVisualStyleBackColor = false;
            this.ButtonDown.Click += new System.EventHandler(this.ButtonDown_Click);
            // 
            // textBoxAccrualText
            // 
            this.textBoxAccrualText.CausesValidation = false;
            resources.ApplyResources(this.textBoxAccrualText, "textBoxAccrualText");
            this.textBoxAccrualText.Name = "textBoxAccrualText";
            this.textBoxAccrualText.TextChanged += new System.EventHandler(this.textBoxAccrualText_TextChanged);
            // 
            // AccrualSceneDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.ButtonDown);
            this.Controls.Add(this.ButtonUp);
            this.Controls.Add(this.listViewAccruals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAccrualScene);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelDisplayText);
            this.Controls.Add(this.textBoxAccrualText);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccrualSceneDialog";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private GTI.Controls.ImageButton btnCancel;
        private GTI.Controls.ImageButton btnOK;
        private System.Windows.Forms.Label labelDisplayText;
        private System.Windows.Forms.ListBox listBoxAccrualScene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewAccruals;
        private Controls.ImageButton ButtonUp;
        private Controls.ImageButton ButtonDown;
        private System.Windows.Forms.TextBox textBoxAccrualText;
	}
}