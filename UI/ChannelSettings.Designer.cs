namespace GTI.Modules.SystemSettings.UI
{
    partial class ChannelSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelSettings));
            this.channelGroupBox = new System.Windows.Forms.GroupBox();
            this.btnEdit = new GTI.Controls.ImageButton();
            this.lstChannels = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.channelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelGroupBox
            // 
            this.channelGroupBox.Controls.Add(this.btnEdit);
            this.channelGroupBox.Controls.Add(this.lstChannels);
            resources.ApplyResources(this.channelGroupBox, "channelGroupBox");
            this.channelGroupBox.Name = "channelGroupBox";
            this.channelGroupBox.TabStop = false;
            // 
            // btnEdit
            // 
            this.btnEdit.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageNormal")));
            this.btnEdit.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImagePressed")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lstChannels
            // 
            this.lstChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            resources.ApplyResources(this.lstChannels, "lstChannels");
            this.lstChannels.FullRowSelect = true;
            this.lstChannels.GridLines = true;
            this.lstChannels.HideSelection = false;
            this.lstChannels.MultiSelect = false;
            this.lstChannels.Name = "lstChannels";
            this.lstChannels.UseCompatibleStateImageBehavior = false;
            this.lstChannels.View = System.Windows.Forms.View.Details;
            this.lstChannels.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstChannels_ColumnClick);
            this.lstChannels.DoubleClick += new System.EventHandler(this.lstChannels_DoubleClick);
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
            // ChannelSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.channelGroupBox);
            this.DoubleBuffered = true;
            this.Name = "ChannelSettings";
            resources.ApplyResources(this, "$this");
            this.channelGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox channelGroupBox;
        private System.Windows.Forms.ListView lstChannels;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private Controls.ImageButton btnEdit;
    }
}
