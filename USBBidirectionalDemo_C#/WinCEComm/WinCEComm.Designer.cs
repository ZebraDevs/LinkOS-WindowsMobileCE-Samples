namespace USBComm
{
    partial class WinCEComm
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
            this.commType = new System.Windows.Forms.ComboBox();
            this.bluetoothPanel = new System.Windows.Forms.Panel();
            this.btAddrLabel = new System.Windows.Forms.Label();
            this.btnBtExit = new System.Windows.Forms.Button();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.btConnect = new System.Windows.Forms.Button();
            this.btAddress = new System.Windows.Forms.TextBox();
            this.bluetoothSndList = new System.Windows.Forms.ListBox();
            this.bluetoothListResponse = new System.Windows.Forms.ListBox();
            this.bluetoothBtnSend = new System.Windows.Forms.Button();
            this.bluetoothLabelResponse = new System.Windows.Forms.Label();
            this.bluetoothLabelSend = new System.Windows.Forms.Label();
            this.usbPanel = new System.Windows.Forms.Panel();
            this.btnUsbExit = new System.Windows.Forms.Button();
            this.usbSndList = new System.Windows.Forms.ListBox();
            this.usbBtnSend = new System.Windows.Forms.Button();
            this.usbListResponse = new System.Windows.Forms.ListBox();
            this.usbLabelSend = new System.Windows.Forms.Label();
            this.usbLabelResponse = new System.Windows.Forms.Label();
            this.labelCommType = new System.Windows.Forms.Label();
            this.bluetoothPanel.SuspendLayout();
            this.usbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // commType
            // 
            this.commType.Items.Add("USB");
            this.commType.Items.Add("Bluetooth");
            this.commType.Location = new System.Drawing.Point(191, 43);
            this.commType.Name = "commType";
            this.commType.Size = new System.Drawing.Size(100, 23);
            this.commType.TabIndex = 19;
            this.commType.SelectedIndexChanged += new System.EventHandler(this.commType_SelectedIndexChanged);
            // 
            // bluetoothPanel
            // 
            this.bluetoothPanel.AutoScroll = true;
            this.bluetoothPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bluetoothPanel.Controls.Add(this.btAddrLabel);
            this.bluetoothPanel.Controls.Add(this.btnBtExit);
            this.bluetoothPanel.Controls.Add(this.btDisconnect);
            this.bluetoothPanel.Controls.Add(this.btConnect);
            this.bluetoothPanel.Controls.Add(this.btAddress);
            this.bluetoothPanel.Controls.Add(this.bluetoothSndList);
            this.bluetoothPanel.Controls.Add(this.bluetoothListResponse);
            this.bluetoothPanel.Controls.Add(this.bluetoothBtnSend);
            this.bluetoothPanel.Controls.Add(this.bluetoothLabelResponse);
            this.bluetoothPanel.Controls.Add(this.bluetoothLabelSend);
            this.bluetoothPanel.Location = new System.Drawing.Point(29, 302);
            this.bluetoothPanel.Name = "bluetoothPanel";
            this.bluetoothPanel.Size = new System.Drawing.Size(568, 252);
            this.bluetoothPanel.Tag = "Bluetooth";
            // 
            // btAddrLabel
            // 
            this.btAddrLabel.Location = new System.Drawing.Point(11, 30);
            this.btAddrLabel.Name = "btAddrLabel";
            this.btAddrLabel.Size = new System.Drawing.Size(125, 20);
            this.btAddrLabel.Text = "Bluetooth Address:";
            // 
            // btnBtExit
            // 
            this.btnBtExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnBtExit.Location = new System.Drawing.Point(450, 132);
            this.btnBtExit.Name = "btnBtExit";
            this.btnBtExit.Size = new System.Drawing.Size(83, 26);
            this.btnBtExit.TabIndex = 21;
            this.btnBtExit.Text = "Exit";
            this.btnBtExit.Click += new System.EventHandler(this.btnBtExit_Click);
            // 
            // btDisconnect
            // 
            this.btDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btDisconnect.Location = new System.Drawing.Point(226, 60);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(82, 26);
            this.btDisconnect.TabIndex = 26;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // btConnect
            // 
            this.btConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btConnect.Location = new System.Drawing.Point(138, 60);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(82, 26);
            this.btConnect.TabIndex = 25;
            this.btConnect.Text = "Connect";
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btAddress
            // 
            this.btAddress.Location = new System.Drawing.Point(138, 27);
            this.btAddress.Name = "btAddress";
            this.btAddress.Size = new System.Drawing.Size(119, 23);
            this.btAddress.TabIndex = 24;
            // 
            // bluetoothSndList
            // 
            this.bluetoothSndList.Items.Add("~HS");
            this.bluetoothSndList.Items.Add("~WC");
            this.bluetoothSndList.Location = new System.Drawing.Point(138, 92);
            this.bluetoothSndList.Name = "bluetoothSndList";
            this.bluetoothSndList.Size = new System.Drawing.Size(292, 66);
            this.bluetoothSndList.TabIndex = 21;
            // 
            // bluetoothListResponse
            // 
            this.bluetoothListResponse.Location = new System.Drawing.Point(138, 175);
            this.bluetoothListResponse.Name = "bluetoothListResponse";
            this.bluetoothListResponse.Size = new System.Drawing.Size(292, 66);
            this.bluetoothListResponse.TabIndex = 16;
            // 
            // bluetoothBtnSend
            // 
            this.bluetoothBtnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.bluetoothBtnSend.Location = new System.Drawing.Point(451, 92);
            this.bluetoothBtnSend.Name = "bluetoothBtnSend";
            this.bluetoothBtnSend.Size = new System.Drawing.Size(82, 26);
            this.bluetoothBtnSend.TabIndex = 17;
            this.bluetoothBtnSend.Text = "Send";
            this.bluetoothBtnSend.Click += new System.EventHandler(this.bluetoothBtnSend_Click);
            // 
            // bluetoothLabelResponse
            // 
            this.bluetoothLabelResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
            this.bluetoothLabelResponse.Location = new System.Drawing.Point(28, 175);
            this.bluetoothLabelResponse.Name = "bluetoothLabelResponse";
            this.bluetoothLabelResponse.Size = new System.Drawing.Size(74, 16);
            this.bluetoothLabelResponse.Text = "Response:";
            // 
            // bluetoothLabelSend
            // 
            this.bluetoothLabelSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
            this.bluetoothLabelSend.Location = new System.Drawing.Point(28, 93);
            this.bluetoothLabelSend.Name = "bluetoothLabelSend";
            this.bluetoothLabelSend.Size = new System.Drawing.Size(108, 16);
            this.bluetoothLabelSend.Text = "Send Command:";
            // 
            // usbPanel
            // 
            this.usbPanel.AutoScroll = true;
            this.usbPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.usbPanel.Controls.Add(this.btnUsbExit);
            this.usbPanel.Controls.Add(this.usbSndList);
            this.usbPanel.Controls.Add(this.usbBtnSend);
            this.usbPanel.Controls.Add(this.usbListResponse);
            this.usbPanel.Controls.Add(this.usbLabelSend);
            this.usbPanel.Controls.Add(this.usbLabelResponse);
            this.usbPanel.Location = new System.Drawing.Point(29, 79);
            this.usbPanel.Name = "usbPanel";
            this.usbPanel.Size = new System.Drawing.Size(568, 204);
            this.usbPanel.Tag = "USB";
            // 
            // btnUsbExit
            // 
            this.btnUsbExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnUsbExit.Location = new System.Drawing.Point(450, 60);
            this.btnUsbExit.Name = "btnUsbExit";
            this.btnUsbExit.Size = new System.Drawing.Size(83, 26);
            this.btnUsbExit.TabIndex = 23;
            this.btnUsbExit.Text = "Exit";
            this.btnUsbExit.Click += new System.EventHandler(this.usbExit_Click);
            // 
            // usbSndList
            // 
            this.usbSndList.Items.Add("~HS");
            this.usbSndList.Items.Add("~WC");
            this.usbSndList.Location = new System.Drawing.Point(138, 28);
            this.usbSndList.Name = "usbSndList";
            this.usbSndList.Size = new System.Drawing.Size(292, 50);
            this.usbSndList.TabIndex = 32;
            // 
            // usbBtnSend
            // 
            this.usbBtnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.usbBtnSend.Location = new System.Drawing.Point(451, 28);
            this.usbBtnSend.Name = "usbBtnSend";
            this.usbBtnSend.Size = new System.Drawing.Size(82, 26);
            this.usbBtnSend.TabIndex = 28;
            this.usbBtnSend.Text = "Send";
            this.usbBtnSend.Click += new System.EventHandler(this.usbBtnSend_Click);
            // 
            // usbListResponse
            // 
            this.usbListResponse.Location = new System.Drawing.Point(138, 95);
            this.usbListResponse.Name = "usbListResponse";
            this.usbListResponse.Size = new System.Drawing.Size(292, 66);
            this.usbListResponse.TabIndex = 27;
            // 
            // usbLabelSend
            // 
            this.usbLabelSend.BackColor = System.Drawing.Color.Gray;
            this.usbLabelSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
            this.usbLabelSend.Location = new System.Drawing.Point(28, 28);
            this.usbLabelSend.Name = "usbLabelSend";
            this.usbLabelSend.Size = new System.Drawing.Size(108, 16);
            this.usbLabelSend.Text = "Send Command:";
            // 
            // usbLabelResponse
            // 
            this.usbLabelResponse.BackColor = System.Drawing.Color.Gray;
            this.usbLabelResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular);
            this.usbLabelResponse.Location = new System.Drawing.Point(28, 95);
            this.usbLabelResponse.Name = "usbLabelResponse";
            this.usbLabelResponse.Size = new System.Drawing.Size(74, 16);
            this.usbLabelResponse.Text = "Response:";
            // 
            // labelCommType
            // 
            this.labelCommType.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelCommType.Location = new System.Drawing.Point(29, 43);
            this.labelCommType.Name = "labelCommType";
            this.labelCommType.Size = new System.Drawing.Size(156, 20);
            this.labelCommType.Text = "Communication Type:";
            // 
            // WinCEComm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.labelCommType);
            this.Controls.Add(this.usbPanel);
            this.Controls.Add(this.bluetoothPanel);
            this.Controls.Add(this.commType);
            this.MinimizeBox = false;
            this.Name = "WinCEComm";
            this.Text = "WinCEComm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.USBComm_Load);
            this.bluetoothPanel.ResumeLayout(false);
            this.usbPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox commType;
        private System.Windows.Forms.Panel bluetoothPanel;
        private System.Windows.Forms.ListBox bluetoothListResponse;
        private System.Windows.Forms.Button bluetoothBtnSend;
        private System.Windows.Forms.Label bluetoothLabelResponse;
        private System.Windows.Forms.Label bluetoothLabelSend;
        private System.Windows.Forms.Button btnBtExit;
        private System.Windows.Forms.Panel usbPanel;
        private System.Windows.Forms.ListBox usbListResponse;
        private System.Windows.Forms.Button usbBtnSend;
        private System.Windows.Forms.Label usbLabelResponse;
        private System.Windows.Forms.Label usbLabelSend;
        private System.Windows.Forms.ListBox bluetoothSndList;
        private System.Windows.Forms.ListBox usbSndList;
        private System.Windows.Forms.Label btAddrLabel;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.TextBox btAddress;
        private System.Windows.Forms.Button btnUsbExit;
        private System.Windows.Forms.Label labelCommType;
    }
}

