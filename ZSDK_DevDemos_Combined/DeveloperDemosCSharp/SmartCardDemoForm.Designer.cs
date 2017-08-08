/********************************************** 
 * CONFIDENTIAL AND PROPRIETARY 
 *
 * The source code and other information contained herein is the confidential and the exclusive property of
 * ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corp. 2010
 *
 * ALL RIGHTS RESERVED 
 ***********************************************/

namespace ZebraDeveloperDemos
{
    partial class SmartCardDemoForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.connectionPanel = new ConnectionPanel();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.sendCtAtrButton = new System.Windows.Forms.MenuItem();
            this.sendCtDataButton = new System.Windows.Forms.MenuItem();
            this.responsePanel = new System.Windows.Forms.Panel();
            this.responseLabel = new System.Windows.Forms.Label();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.onScreenKeypad = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.responsePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectionPanel
            // 
            this.connectionPanel.BackColor = System.Drawing.Color.DarkGray;
            this.connectionPanel.BluetoothMacAddress = "";
            this.connectionPanel.ConnectionType = "IP/DNS";
            this.connectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.connectionPanel.IPAddress = "";
            this.connectionPanel.Location = new System.Drawing.Point(0, 0);
            this.connectionPanel.Name = "connectionPanel";
            this.connectionPanel.PortNum = 6101;
            this.connectionPanel.SerialBaudRate = 9600;
            this.connectionPanel.SerialComPortName = "COM1";
            this.connectionPanel.SerialDataBits = 8;
            this.connectionPanel.SerialHandshake = System.IO.Ports.Handshake.None;
            this.connectionPanel.SerialParity = System.IO.Ports.Parity.None;
            this.connectionPanel.SerialStopBits = System.IO.Ports.StopBits.One;
            this.connectionPanel.Size = new System.Drawing.Size(240, 147);
            this.connectionPanel.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.sendCtAtrButton);
            this.mainMenu.MenuItems.Add(this.sendCtDataButton);
            // 
            // sendCtAtrButton
            // 
            this.sendCtAtrButton.Text = "Send ATR";
            this.sendCtAtrButton.Click += new System.EventHandler(this.sendCtAtrButtonPressed);
            // 
            // sendCtDataButton
            // 
            this.sendCtDataButton.Text = "Send DATA";
            this.sendCtDataButton.Click += new System.EventHandler(this.sendCtDataButtonPressed);
            // 
            // responsePanel
            // 
            this.responsePanel.BackColor = System.Drawing.Color.DarkGray;
            this.responsePanel.Controls.Add(this.responseLabel);
            this.responsePanel.Controls.Add(this.responseTextBox);
            this.responsePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.responsePanel.Location = new System.Drawing.Point(0, 147);
            this.responsePanel.Name = "responsePanel";
            this.responsePanel.Size = new System.Drawing.Size(240, 100);
            // 
            // responseLabel
            // 
            this.responseLabel.Location = new System.Drawing.Point(20, 7);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(193, 20);
            this.responseLabel.Text = "Response from Printer";
            // 
            // responseTextBox
            // 
            this.responseTextBox.Location = new System.Drawing.Point(20, 30);
            this.responseTextBox.Multiline = true;
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.ReadOnly = true;
            this.responseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.responseTextBox.Size = new System.Drawing.Size(193, 67);
            this.responseTextBox.TabIndex = 0;
            // 
            // SmartCardDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.responsePanel);
            this.Controls.Add(this.connectionPanel);
            this.KeyPreview = true;
            this.Menu = this.mainMenu;
            this.Name = "SmartCardDemoForm";
            this.Text = "Smart Card Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SmartCardDemoForm_Closing);
            this.responsePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ConnectionPanel connectionPanel;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem sendCtAtrButton;
        private System.Windows.Forms.MenuItem sendCtDataButton;
        private System.Windows.Forms.Panel responsePanel;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.TextBox responseTextBox;
        private Microsoft.WindowsCE.Forms.InputPanel onScreenKeypad;
    }
}