namespace GTI.Modules.SystemSettings.UI
{
	partial class LocationSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationSettings));
            this.btnEdit = new GTI.Controls.ImageButton();
            this.btnAdd = new GTI.Controls.ImageButton();
            this.locationGroupBox = new System.Windows.Forms.GroupBox();
            this.lstLocations = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.locationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageNormal")));
            this.btnEdit.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImagePressed")));
            this.btnEdit.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnEdit.Name = "btnEdit";
            this.toolTip1.SetToolTip(this.btnEdit, resources.GetString("btnEdit.ToolTip"));
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageNormal")));
            this.btnAdd.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImagePressed")));
            this.btnAdd.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnAdd.Name = "btnAdd";
            this.toolTip1.SetToolTip(this.btnAdd, resources.GetString("btnAdd.ToolTip"));
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // locationGroupBox
            // 
            this.locationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.locationGroupBox.Controls.Add(this.btnEdit);
            this.locationGroupBox.Controls.Add(this.btnAdd);
            this.locationGroupBox.Controls.Add(this.lstLocations);
            resources.ApplyResources(this.locationGroupBox, "locationGroupBox");
            this.locationGroupBox.Name = "locationGroupBox";
            this.locationGroupBox.TabStop = false;
            // 
            // lstLocations
            // 
            this.lstLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            resources.ApplyResources(this.lstLocations, "lstLocations");
            this.lstLocations.FullRowSelect = true;
            this.lstLocations.GridLines = true;
            this.lstLocations.HideSelection = false;
            this.lstLocations.MultiSelect = false;
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.UseCompatibleStateImageBehavior = false;
            this.lstLocations.View = System.Windows.Forms.View.Details;
            this.lstLocations.DoubleClick += new System.EventHandler(this.lstLocations_DoubleClick);
            this.lstLocations.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstLocations_ColumnClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // LocationSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.locationGroupBox);
            this.DoubleBuffered = true;
            this.Name = "LocationSettings";
            resources.ApplyResources(this, "$this");
            this.locationGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private GTI.Controls.ImageButton btnEdit;
		private System.Windows.Forms.ToolTip toolTip1;
		private GTI.Controls.ImageButton btnAdd;
        private System.Windows.Forms.GroupBox locationGroupBox;
		private System.Windows.Forms.ListView lstLocations;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}
