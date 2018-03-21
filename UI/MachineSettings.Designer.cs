namespace GTI.Modules.SystemSettings.UI
{
	partial class MachineSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineSettings));
            this.stationGroupBox = new System.Windows.Forms.GroupBox();
            this.lstStations = new System.Windows.Forms.ListView();
            this.identifierColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new GTI.Controls.ImageButton();
            this.btnEdit = new GTI.Controls.ImageButton();
            this.stationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // stationGroupBox
            // 
            this.stationGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.stationGroupBox.Controls.Add(this.lstStations);
            resources.ApplyResources(this.stationGroupBox, "stationGroupBox");
            this.stationGroupBox.Name = "stationGroupBox";
            this.stationGroupBox.TabStop = false;
            // 
            // lstStations
            // 
            this.lstStations.AutoArrange = false;
            this.lstStations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.identifierColumnHeader,
            this.deviceTypeColumnHeader,
            this.descriptionColumnHeader});
            resources.ApplyResources(this.lstStations, "lstStations");
            this.lstStations.FullRowSelect = true;
            this.lstStations.GridLines = true;
            this.lstStations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstStations.HideSelection = false;
            this.lstStations.Name = "lstStations";
            this.lstStations.UseCompatibleStateImageBehavior = false;
            this.lstStations.View = System.Windows.Forms.View.Details;
            this.lstStations.DoubleClick += new System.EventHandler(this.lstStations_DoubleClick);
            // 
            // identifierColumnHeader
            // 
            resources.ApplyResources(this.identifierColumnHeader, "identifierColumnHeader");
            // 
            // deviceTypeColumnHeader
            // 
            resources.ApplyResources(this.deviceTypeColumnHeader, "deviceTypeColumnHeader");
            // 
            // descriptionColumnHeader
            // 
            resources.ApplyResources(this.descriptionColumnHeader, "descriptionColumnHeader");
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Items.AddRange(new object[] {
            resources.GetString("cboFilter.Items"),
            resources.GetString("cboFilter.Items1"),
            resources.GetString("cboFilter.Items2"),
            resources.GetString("cboFilter.Items3"),
            resources.GetString("cboFilter.Items4"),
            resources.GetString("cboFilter.Items5"),
            resources.GetString("cboFilter.Items6"),
            resources.GetString("cboFilter.Items7"),
            resources.GetString("cboFilter.Items8"),
            resources.GetString("cboFilter.Items9"),
            resources.GetString("cboFilter.Items10"),
            resources.GetString("cboFilter.Items11"),
            resources.GetString("cboFilter.Items12"),
            resources.GetString("cboFilter.Items13"),
            resources.GetString("cboFilter.Items14"),
            resources.GetString("cboFilter.Items15"),
            resources.GetString("cboFilter.Items16"),
            resources.GetString("cboFilter.Items17"),
            resources.GetString("cboFilter.Items18"),
            resources.GetString("cboFilter.Items19"),
            resources.GetString("cboFilter.Items20"),
            resources.GetString("cboFilter.Items21"),
            resources.GetString("cboFilter.Items22"),
            resources.GetString("cboFilter.Items23")});
            resources.ApplyResources(this.cboFilter, "cboFilter");
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnRefresh.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RepeatRate = 150;
            this.btnRefresh.RepeatWhenHeldFor = 750;
            this.btnRefresh.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.Leave += new System.EventHandler(this.btnRefresh_Leave);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnEdit.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.RepeatRate = 150;
            this.btnEdit.RepeatWhenHeldFor = 750;
            this.btnEdit.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // MachineSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.stationGroupBox);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "MachineSettings";
            this.stationGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private GTI.Controls.ImageButton btnRefresh;
		private GTI.Controls.ImageButton btnEdit;
		private System.Windows.Forms.GroupBox stationGroupBox;
		private System.Windows.Forms.ListView lstStations;
		private System.Windows.Forms.ColumnHeader identifierColumnHeader;
		private System.Windows.Forms.ColumnHeader deviceTypeColumnHeader;
		private System.Windows.Forms.ColumnHeader descriptionColumnHeader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboFilter;
	}
}
