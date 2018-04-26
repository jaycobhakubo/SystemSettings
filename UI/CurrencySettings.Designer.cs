namespace GTI.Modules.SystemSettings.UI
{
	partial class CurrencySettings
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencySettings));
            this.curenceyGroupBox = new System.Windows.Forms.GroupBox();
            this.btnDelete = new GTI.Controls.ImageButton();
            this.btnEdit = new GTI.Controls.ImageButton();
            this.btnAdd = new GTI.Controls.ImageButton();
            this.currencyListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numTaxFormAmt = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            label1 = new System.Windows.Forms.Label();
            this.curenceyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxFormAmt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // curenceyGroupBox
            // 
            this.curenceyGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.curenceyGroupBox.Controls.Add(this.btnDelete);
            this.curenceyGroupBox.Controls.Add(this.btnEdit);
            this.curenceyGroupBox.Controls.Add(this.btnAdd);
            this.curenceyGroupBox.Controls.Add(this.currencyListView);
            resources.ApplyResources(this.curenceyGroupBox, "curenceyGroupBox");
            this.curenceyGroupBox.Name = "curenceyGroupBox";
            this.curenceyGroupBox.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageNormal")));
            this.btnDelete.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImagePressed")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageNormal")));
            this.btnEdit.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImagePressed")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageNormal")));
            this.btnAdd.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImagePressed")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // currencyListView
            // 
            this.currencyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            resources.ApplyResources(this.currencyListView, "currencyListView");
            this.currencyListView.GridLines = true;
            this.currencyListView.Name = "currencyListView";
            this.currencyListView.UseCompatibleStateImageBehavior = false;
            this.currencyListView.View = System.Windows.Forms.View.Details;
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
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // numTaxFormAmt
            // 
            this.numTaxFormAmt.DecimalPlaces = 2;
            resources.ApplyResources(this.numTaxFormAmt, "numTaxFormAmt");
            this.numTaxFormAmt.Name = "numTaxFormAmt";
            this.numTaxFormAmt.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageNormal")));
            this.btnReset.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnReset.ImagePressed")));
            this.btnReset.Name = "btnReset";
            this.btnReset.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Leave += new System.EventHandler(this.btnReset_Leave);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageNormal = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageNormal")));
            this.btnSave.ImagePressed = ((System.Drawing.Image)(resources.GetObject("btnSave.ImagePressed")));
            this.btnSave.Name = "btnSave";
            this.btnSave.SecondaryTextPadding = new System.Windows.Forms.Padding(5);
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // CurrencySettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numTaxFormAmt);
            this.Controls.Add(label1);
            this.Controls.Add(this.curenceyGroupBox);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "CurrencySettings";
            this.curenceyGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTaxFormAmt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox curenceyGroupBox;
		private GTI.Controls.ImageButton btnEdit;
		private GTI.Controls.ImageButton btnAdd;
		private System.Windows.Forms.ListView currencyListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.NumericUpDown numTaxFormAmt;
		private GTI.Controls.ImageButton btnReset;
		private GTI.Controls.ImageButton btnSave;
		private GTI.Controls.ImageButton btnDelete;
	}
}
