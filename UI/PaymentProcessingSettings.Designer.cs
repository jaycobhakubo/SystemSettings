namespace GTI.Modules.SystemSettings.UI
{
    partial class PaymentProcessingSettings
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
            this.btnReset = new GTI.Controls.ImageButton();
            this.btnSave = new GTI.Controls.ImageButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPaymentProcessingEnabled = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbProcessor = new System.Windows.Forms.ComboBox();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelShift4 = new System.Windows.Forms.Panel();
            this.nudShift4ComTimeout = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAuthToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPrecidiaSupport = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTransnetPort = new System.Windows.Forms.TextBox();
            this.txtTransnetAddress = new System.Windows.Forms.TextBox();
            this.txtPaymentAppPort = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPaymentAppAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.grpPrecidiaPINPad = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.chkPINPadItemDetail = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chkPINPadAmountDue = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.chkPINPadEnabled = new System.Windows.Forms.CheckBox();
            this.chkPINPadSubtotal = new System.Windows.Forms.CheckBox();
            this.chkAllowManualEntry = new System.Windows.Forms.CheckBox();
            this.nudMaxWithoutSignature = new System.Windows.Forms.NumericUpDown();
            this.txtGreetingMessage = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFailedMessage = new System.Windows.Forms.TextBox();
            this.txtStationClosedMessage = new System.Windows.Forms.TextBox();
            this.txtAfterSaleMessage = new System.Windows.Forms.TextBox();
            this.panelCommon = new System.Windows.Forms.Panel();
            this.txtProcessorPort = new System.Windows.Forms.TextBox();
            this.txtProcessorAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.grpShift4PINPad = new System.Windows.Forms.GroupBox();
            this.nudPINPadDisplayColumns = new System.Windows.Forms.NumericUpDown();
            this.nudPINPadDisplayLines = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkPINPadItemDetail2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelShift4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShift4ComTimeout)).BeginInit();
            this.grpPrecidiaSupport.SuspendLayout();
            this.grpPrecidiaPINPad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxWithoutSignature)).BeginInit();
            this.panelCommon.SuspendLayout();
            this.grpShift4PINPad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPINPadDisplayColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPINPadDisplayLines)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.FocusColor = System.Drawing.Color.Black;
            this.btnReset.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnReset.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(395, 608);
            this.btnReset.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnReset.Name = "btnReset";
            this.btnReset.RepeatRate = 150;
            this.btnReset.RepeatWhenHeldFor = 750;
            this.btnReset.Size = new System.Drawing.Size(121, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FocusColor = System.Drawing.Color.Black;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ImageNormal = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonUp;
            this.btnSave.ImagePressed = global::GTI.Modules.SystemSettings.Properties.Resources.BlueButtonDown;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(246, 608);
            this.btnSave.MinimumSize = new System.Drawing.Size(30, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.RepeatRate = 150;
            this.btnSave.RepeatWhenHeldFor = 750;
            this.btnSave.Size = new System.Drawing.Size(121, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkPaymentProcessingEnabled);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cmbProcessor);
            this.groupBox1.Controls.Add(this.grpSettings);
            this.groupBox1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(23, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Processor Settings";
            // 
            // chkPaymentProcessingEnabled
            // 
            this.chkPaymentProcessingEnabled.AutoSize = true;
            this.chkPaymentProcessingEnabled.Checked = true;
            this.chkPaymentProcessingEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPaymentProcessingEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkPaymentProcessingEnabled.Location = new System.Drawing.Point(18, 28);
            this.chkPaymentProcessingEnabled.Name = "chkPaymentProcessingEnabled";
            this.chkPaymentProcessingEnabled.Size = new System.Drawing.Size(236, 26);
            this.chkPaymentProcessingEnabled.TabIndex = 0;
            this.chkPaymentProcessingEnabled.Text = "Payment Processor Enabled";
            this.chkPaymentProcessingEnabled.UseVisualStyleBackColor = true;
            this.chkPaymentProcessingEnabled.CheckedChanged += new System.EventHandler(this.OnModified);
            this.chkPaymentProcessingEnabled.CheckStateChanged += new System.EventHandler(this.chkPaymentProcessingEnabled_CheckStateChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(211, 22);
            this.label17.TabIndex = 1;
            this.label17.Text = "Payment Processor System";
            // 
            // cmbProcessor
            // 
            this.cmbProcessor.FormattingEnabled = true;
            this.cmbProcessor.Items.AddRange(new object[] {
            "None",
            "Shift4",
            "Precidia"});
            this.cmbProcessor.Location = new System.Drawing.Point(346, 54);
            this.cmbProcessor.Name = "cmbProcessor";
            this.cmbProcessor.Size = new System.Drawing.Size(299, 30);
            this.cmbProcessor.TabIndex = 2;
            this.cmbProcessor.SelectedIndexChanged += new System.EventHandler(this.cmbProcessor_SelectedIndexChanged);
            // 
            // grpSettings
            // 
            this.grpSettings.BackColor = System.Drawing.Color.Transparent;
            this.grpSettings.Controls.Add(this.panelMain);
            this.grpSettings.Location = new System.Drawing.Point(0, 90);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(716, 493);
            this.grpSettings.TabIndex = 3;
            this.grpSettings.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(181)))), ((int)(((byte)(206)))));
            this.panelMain.Controls.Add(this.panelShift4);
            this.panelMain.Controls.Add(this.grpPrecidiaSupport);
            this.panelMain.Controls.Add(this.grpPrecidiaPINPad);
            this.panelMain.Controls.Add(this.panelCommon);
            this.panelMain.Controls.Add(this.grpShift4PINPad);
            this.panelMain.Location = new System.Drawing.Point(6, 15);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(704, 470);
            this.panelMain.TabIndex = 0;
            // 
            // panelShift4
            // 
            this.panelShift4.Controls.Add(this.nudShift4ComTimeout);
            this.panelShift4.Controls.Add(this.label6);
            this.panelShift4.Controls.Add(this.txtAuthToken);
            this.panelShift4.Controls.Add(this.label1);
            this.panelShift4.Location = new System.Drawing.Point(0, 79);
            this.panelShift4.Name = "panelShift4";
            this.panelShift4.Size = new System.Drawing.Size(683, 68);
            this.panelShift4.TabIndex = 1;
            // 
            // nudShift4ComTimeout
            // 
            this.nudShift4ComTimeout.Location = new System.Drawing.Point(340, 37);
            this.nudShift4ComTimeout.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.nudShift4ComTimeout.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudShift4ComTimeout.Name = "nudShift4ComTimeout";
            this.nudShift4ComTimeout.Size = new System.Drawing.Size(67, 26);
            this.nudShift4ComTimeout.TabIndex = 3;
            this.nudShift4ComTimeout.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudShift4ComTimeout.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(274, 22);
            this.label6.TabIndex = 2;
            this.label6.Text = "Communication Timeout (seconds)";
            // 
            // txtAuthToken
            // 
            this.txtAuthToken.Location = new System.Drawing.Point(340, 3);
            this.txtAuthToken.MaxLength = 200;
            this.txtAuthToken.Name = "txtAuthToken";
            this.txtAuthToken.Size = new System.Drawing.Size(339, 26);
            this.txtAuthToken.TabIndex = 1;
            this.txtAuthToken.UseSystemPasswordChar = true;
            this.txtAuthToken.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Authorization Token";
            // 
            // grpPrecidiaSupport
            // 
            this.grpPrecidiaSupport.Controls.Add(this.label4);
            this.grpPrecidiaSupport.Controls.Add(this.txtTransnetPort);
            this.grpPrecidiaSupport.Controls.Add(this.txtTransnetAddress);
            this.grpPrecidiaSupport.Controls.Add(this.txtPaymentAppPort);
            this.grpPrecidiaSupport.Controls.Add(this.label12);
            this.grpPrecidiaSupport.Controls.Add(this.label7);
            this.grpPrecidiaSupport.Controls.Add(this.txtPaymentAppAddress);
            this.grpPrecidiaSupport.Controls.Add(this.label14);
            this.grpPrecidiaSupport.Location = new System.Drawing.Point(0, 502);
            this.grpPrecidiaSupport.Name = "grpPrecidiaSupport";
            this.grpPrecidiaSupport.Size = new System.Drawing.Size(680, 163);
            this.grpPrecidiaSupport.TabIndex = 3;
            this.grpPrecidiaSupport.TabStop = false;
            this.grpPrecidiaSupport.Text = "Precidia Support Modules";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Transnet Address";
            // 
            // txtTransnetPort
            // 
            this.txtTransnetPort.Location = new System.Drawing.Point(340, 62);
            this.txtTransnetPort.Name = "txtTransnetPort";
            this.txtTransnetPort.Size = new System.Drawing.Size(299, 26);
            this.txtTransnetPort.TabIndex = 3;
            this.txtTransnetPort.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtTransnetAddress
            // 
            this.txtTransnetAddress.Location = new System.Drawing.Point(340, 30);
            this.txtTransnetAddress.Name = "txtTransnetAddress";
            this.txtTransnetAddress.Size = new System.Drawing.Size(299, 26);
            this.txtTransnetAddress.TabIndex = 1;
            this.txtTransnetAddress.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtPaymentAppPort
            // 
            this.txtPaymentAppPort.Location = new System.Drawing.Point(340, 126);
            this.txtPaymentAppPort.Name = "txtPaymentAppPort";
            this.txtPaymentAppPort.Size = new System.Drawing.Size(299, 26);
            this.txtPaymentAppPort.TabIndex = 7;
            this.txtPaymentAppPort.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 65);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 22);
            this.label12.TabIndex = 2;
            this.label12.Text = "Transnet Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Payment App Listening Port";
            // 
            // txtPaymentAppAddress
            // 
            this.txtPaymentAppAddress.Location = new System.Drawing.Point(340, 94);
            this.txtPaymentAppAddress.Name = "txtPaymentAppAddress";
            this.txtPaymentAppAddress.Size = new System.Drawing.Size(299, 26);
            this.txtPaymentAppAddress.TabIndex = 5;
            this.txtPaymentAppAddress.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(8, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(245, 22);
            this.label14.TabIndex = 4;
            this.label14.Text = "Payment App Listening Address";
            // 
            // grpPrecidiaPINPad
            // 
            this.grpPrecidiaPINPad.Controls.Add(this.label24);
            this.grpPrecidiaPINPad.Controls.Add(this.label18);
            this.grpPrecidiaPINPad.Controls.Add(this.chkPINPadItemDetail);
            this.grpPrecidiaPINPad.Controls.Add(this.label23);
            this.grpPrecidiaPINPad.Controls.Add(this.label16);
            this.grpPrecidiaPINPad.Controls.Add(this.chkPINPadAmountDue);
            this.grpPrecidiaPINPad.Controls.Add(this.label22);
            this.grpPrecidiaPINPad.Controls.Add(this.chkPINPadEnabled);
            this.grpPrecidiaPINPad.Controls.Add(this.chkPINPadSubtotal);
            this.grpPrecidiaPINPad.Controls.Add(this.chkAllowManualEntry);
            this.grpPrecidiaPINPad.Controls.Add(this.nudMaxWithoutSignature);
            this.grpPrecidiaPINPad.Controls.Add(this.txtGreetingMessage);
            this.grpPrecidiaPINPad.Controls.Add(this.label21);
            this.grpPrecidiaPINPad.Controls.Add(this.txtFailedMessage);
            this.grpPrecidiaPINPad.Controls.Add(this.txtStationClosedMessage);
            this.grpPrecidiaPINPad.Controls.Add(this.txtAfterSaleMessage);
            this.grpPrecidiaPINPad.Location = new System.Drawing.Point(-1, 156);
            this.grpPrecidiaPINPad.Name = "grpPrecidiaPINPad";
            this.grpPrecidiaPINPad.Size = new System.Drawing.Size(680, 340);
            this.grpPrecidiaPINPad.TabIndex = 2;
            this.grpPrecidiaPINPad.TabStop = false;
            this.grpPrecidiaPINPad.Text = "PIN Pad";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(8, 303);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(184, 22);
            this.label24.TabIndex = 13;
            this.label24.Text = "Station Closed Message";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(321, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 22);
            this.label18.TabIndex = 3;
            this.label18.Text = "$";
            // 
            // chkPINPadItemDetail
            // 
            this.chkPINPadItemDetail.AutoSize = true;
            this.chkPINPadItemDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkPINPadItemDetail.Location = new System.Drawing.Point(12, 179);
            this.chkPINPadItemDetail.Name = "chkPINPadItemDetail";
            this.chkPINPadItemDetail.Size = new System.Drawing.Size(174, 26);
            this.chkPINPadItemDetail.TabIndex = 6;
            this.chkPINPadItemDetail.Text = "Display Item Details";
            this.chkPINPadItemDetail.UseVisualStyleBackColor = true;
            this.chkPINPadItemDetail.CheckedChanged += new System.EventHandler(this.chkPINPadItemDetail_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(8, 271);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(151, 22);
            this.label23.TabIndex = 11;
            this.label23.Text = "After Sale Message";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(8, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(249, 22);
            this.label16.TabIndex = 2;
            this.label16.Text = "Signature required if more than";
            // 
            // chkPINPadAmountDue
            // 
            this.chkPINPadAmountDue.AutoSize = true;
            this.chkPINPadAmountDue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkPINPadAmountDue.Location = new System.Drawing.Point(12, 115);
            this.chkPINPadAmountDue.Name = "chkPINPadAmountDue";
            this.chkPINPadAmountDue.Size = new System.Drawing.Size(178, 26);
            this.chkPINPadAmountDue.TabIndex = 4;
            this.chkPINPadAmountDue.Text = "Display Amount Due";
            this.chkPINPadAmountDue.UseVisualStyleBackColor = true;
            this.chkPINPadAmountDue.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(8, 240);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(162, 22);
            this.label22.TabIndex = 9;
            this.label22.Text = "Card Failed Message";
            // 
            // chkPINPadEnabled
            // 
            this.chkPINPadEnabled.AutoSize = true;
            this.chkPINPadEnabled.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkPINPadEnabled.Location = new System.Drawing.Point(12, 29);
            this.chkPINPadEnabled.Name = "chkPINPadEnabled";
            this.chkPINPadEnabled.Size = new System.Drawing.Size(139, 26);
            this.chkPINPadEnabled.TabIndex = 0;
            this.chkPINPadEnabled.Text = "Enable PIN Pad";
            this.chkPINPadEnabled.UseVisualStyleBackColor = true;
            this.chkPINPadEnabled.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkPINPadSubtotal
            // 
            this.chkPINPadSubtotal.AutoSize = true;
            this.chkPINPadSubtotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkPINPadSubtotal.Location = new System.Drawing.Point(12, 147);
            this.chkPINPadSubtotal.Name = "chkPINPadSubtotal";
            this.chkPINPadSubtotal.Size = new System.Drawing.Size(185, 26);
            this.chkPINPadSubtotal.TabIndex = 5;
            this.chkPINPadSubtotal.Text = "Display Item Subtotal";
            this.chkPINPadSubtotal.UseVisualStyleBackColor = true;
            this.chkPINPadSubtotal.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // chkAllowManualEntry
            // 
            this.chkAllowManualEntry.AutoSize = true;
            this.chkAllowManualEntry.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkAllowManualEntry.Location = new System.Drawing.Point(12, 61);
            this.chkAllowManualEntry.Name = "chkAllowManualEntry";
            this.chkAllowManualEntry.Size = new System.Drawing.Size(213, 26);
            this.chkAllowManualEntry.TabIndex = 1;
            this.chkAllowManualEntry.Text = "Allow Manual Card Entry";
            this.chkAllowManualEntry.UseVisualStyleBackColor = true;
            this.chkAllowManualEntry.CheckedChanged += new System.EventHandler(this.OnModified);
            // 
            // nudMaxWithoutSignature
            // 
            this.nudMaxWithoutSignature.DecimalPlaces = 2;
            this.nudMaxWithoutSignature.Location = new System.Drawing.Point(341, 86);
            this.nudMaxWithoutSignature.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxWithoutSignature.Name = "nudMaxWithoutSignature";
            this.nudMaxWithoutSignature.Size = new System.Drawing.Size(93, 26);
            this.nudMaxWithoutSignature.TabIndex = 7;
            this.nudMaxWithoutSignature.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMaxWithoutSignature.Value = new decimal(new int[] {
            1999,
            0,
            0,
            131072});
            this.nudMaxWithoutSignature.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // txtGreetingMessage
            // 
            this.txtGreetingMessage.Location = new System.Drawing.Point(341, 205);
            this.txtGreetingMessage.Name = "txtGreetingMessage";
            this.txtGreetingMessage.Size = new System.Drawing.Size(299, 26);
            this.txtGreetingMessage.TabIndex = 8;
            this.txtGreetingMessage.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(8, 208);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(142, 22);
            this.label21.TabIndex = 7;
            this.label21.Text = "Greeting Message";
            // 
            // txtFailedMessage
            // 
            this.txtFailedMessage.Location = new System.Drawing.Point(341, 237);
            this.txtFailedMessage.Name = "txtFailedMessage";
            this.txtFailedMessage.Size = new System.Drawing.Size(299, 26);
            this.txtFailedMessage.TabIndex = 10;
            this.txtFailedMessage.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtStationClosedMessage
            // 
            this.txtStationClosedMessage.Location = new System.Drawing.Point(341, 300);
            this.txtStationClosedMessage.Name = "txtStationClosedMessage";
            this.txtStationClosedMessage.Size = new System.Drawing.Size(299, 26);
            this.txtStationClosedMessage.TabIndex = 14;
            this.txtStationClosedMessage.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtAfterSaleMessage
            // 
            this.txtAfterSaleMessage.Location = new System.Drawing.Point(341, 269);
            this.txtAfterSaleMessage.Name = "txtAfterSaleMessage";
            this.txtAfterSaleMessage.Size = new System.Drawing.Size(299, 26);
            this.txtAfterSaleMessage.TabIndex = 12;
            this.txtAfterSaleMessage.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // panelCommon
            // 
            this.panelCommon.BackColor = System.Drawing.Color.Transparent;
            this.panelCommon.Controls.Add(this.txtProcessorPort);
            this.panelCommon.Controls.Add(this.txtProcessorAddress);
            this.panelCommon.Controls.Add(this.label2);
            this.panelCommon.Controls.Add(this.label15);
            this.panelCommon.Location = new System.Drawing.Point(0, 12);
            this.panelCommon.Name = "panelCommon";
            this.panelCommon.Size = new System.Drawing.Size(683, 66);
            this.panelCommon.TabIndex = 0;
            // 
            // txtProcessorPort
            // 
            this.txtProcessorPort.Location = new System.Drawing.Point(340, 35);
            this.txtProcessorPort.Name = "txtProcessorPort";
            this.txtProcessorPort.Size = new System.Drawing.Size(299, 26);
            this.txtProcessorPort.TabIndex = 3;
            this.txtProcessorPort.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // txtProcessorAddress
            // 
            this.txtProcessorAddress.Location = new System.Drawing.Point(340, 2);
            this.txtProcessorAddress.Name = "txtProcessorAddress";
            this.txtProcessorAddress.Size = new System.Drawing.Size(299, 26);
            this.txtProcessorAddress.TabIndex = 1;
            this.txtProcessorAddress.TextChanged += new System.EventHandler(this.OnModified);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Processor Address";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(223, 22);
            this.label15.TabIndex = 2;
            this.label15.Text = "Processor Listening Port";
            // 
            // grpShift4PINPad
            // 
            this.grpShift4PINPad.Controls.Add(this.nudPINPadDisplayColumns);
            this.grpShift4PINPad.Controls.Add(this.nudPINPadDisplayLines);
            this.grpShift4PINPad.Controls.Add(this.label5);
            this.grpShift4PINPad.Controls.Add(this.label3);
            this.grpShift4PINPad.Controls.Add(this.chkPINPadItemDetail2);
            this.grpShift4PINPad.Location = new System.Drawing.Point(-1, 671);
            this.grpShift4PINPad.Name = "grpShift4PINPad";
            this.grpShift4PINPad.Size = new System.Drawing.Size(680, 138);
            this.grpShift4PINPad.TabIndex = 4;
            this.grpShift4PINPad.TabStop = false;
            this.grpShift4PINPad.Text = "PIN Pad";
            // 
            // nudPINPadDisplayColumns
            // 
            this.nudPINPadDisplayColumns.Location = new System.Drawing.Point(341, 100);
            this.nudPINPadDisplayColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPINPadDisplayColumns.Name = "nudPINPadDisplayColumns";
            this.nudPINPadDisplayColumns.Size = new System.Drawing.Size(120, 26);
            this.nudPINPadDisplayColumns.TabIndex = 4;
            this.nudPINPadDisplayColumns.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudPINPadDisplayColumns.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // nudPINPadDisplayLines
            // 
            this.nudPINPadDisplayLines.Location = new System.Drawing.Point(341, 64);
            this.nudPINPadDisplayLines.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPINPadDisplayLines.Name = "nudPINPadDisplayLines";
            this.nudPINPadDisplayLines.Size = new System.Drawing.Size(120, 26);
            this.nudPINPadDisplayLines.TabIndex = 2;
            this.nudPINPadDisplayLines.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudPINPadDisplayLines.ValueChanged += new System.EventHandler(this.OnModified);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Display Columns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Display Lines";
            // 
            // chkPINPadItemDetail2
            // 
            this.chkPINPadItemDetail2.AutoSize = true;
            this.chkPINPadItemDetail2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkPINPadItemDetail2.Location = new System.Drawing.Point(12, 28);
            this.chkPINPadItemDetail2.Name = "chkPINPadItemDetail2";
            this.chkPINPadItemDetail2.Size = new System.Drawing.Size(174, 26);
            this.chkPINPadItemDetail2.TabIndex = 0;
            this.chkPINPadItemDetail2.Text = "Display Item Details";
            this.chkPINPadItemDetail2.UseVisualStyleBackColor = true;
            this.chkPINPadItemDetail2.CheckedChanged += new System.EventHandler(this.chkPINPadItemDetail2_CheckedChanged);
            // 
            // PaymentProcessingSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "PaymentProcessingSettings";
            this.Size = new System.Drawing.Size(762, 644);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelShift4.ResumeLayout(false);
            this.panelShift4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShift4ComTimeout)).EndInit();
            this.grpPrecidiaSupport.ResumeLayout(false);
            this.grpPrecidiaSupport.PerformLayout();
            this.grpPrecidiaPINPad.ResumeLayout(false);
            this.grpPrecidiaPINPad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxWithoutSignature)).EndInit();
            this.panelCommon.ResumeLayout(false);
            this.panelCommon.PerformLayout();
            this.grpShift4PINPad.ResumeLayout(false);
            this.grpShift4PINPad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPINPadDisplayColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPINPadDisplayLines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.ImageButton btnSave;
        private Controls.ImageButton btnReset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPaymentAppPort;
        private System.Windows.Forms.TextBox txtPaymentAppAddress;
        private System.Windows.Forms.TextBox txtTransnetAddress;
        private System.Windows.Forms.TextBox txtProcessorAddress;
        private System.Windows.Forms.CheckBox chkPaymentProcessingEnabled;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox txtTransnetPort;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtProcessorPort;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkPINPadItemDetail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkPINPadAmountDue;
        private System.Windows.Forms.CheckBox chkPINPadSubtotal;
        private System.Windows.Forms.NumericUpDown nudMaxWithoutSignature;
        private System.Windows.Forms.CheckBox chkAllowManualEntry;
        private System.Windows.Forms.CheckBox chkPINPadEnabled;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtStationClosedMessage;
        private System.Windows.Forms.TextBox txtAfterSaleMessage;
        private System.Windows.Forms.TextBox txtFailedMessage;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtGreetingMessage;
        private System.Windows.Forms.ComboBox cmbProcessor;
        private System.Windows.Forms.GroupBox grpPrecidiaPINPad;
        private System.Windows.Forms.GroupBox grpPrecidiaSupport;
        private System.Windows.Forms.Panel panelCommon;
        private System.Windows.Forms.GroupBox grpShift4PINPad;
        private System.Windows.Forms.CheckBox chkPINPadItemDetail2;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Panel panelShift4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAuthToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudShift4ComTimeout;
        private System.Windows.Forms.NumericUpDown nudPINPadDisplayColumns;
        private System.Windows.Forms.NumericUpDown nudPINPadDisplayLines;
    }
}
