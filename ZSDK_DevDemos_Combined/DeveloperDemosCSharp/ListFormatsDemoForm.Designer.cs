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
    partial class ListFormatsDemoForm
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.connectButton = new System.Windows.Forms.MenuItem();
            this.optionsMenu = new System.Windows.Forms.MenuItem();
            this.listFilesButton = new System.Windows.Forms.MenuItem();
            this.listFormatsButton = new System.Windows.Forms.MenuItem();
            this.onScreenKeypad = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.fileListPanel = new System.Windows.Forms.Panel();
            this.filesOnPrinterListBox = new System.Windows.Forms.TextBox();
            this.fileNamesLabel = new System.Windows.Forms.Label();
            this.connectionPanel = new ConnectionPanel();
            this.fileListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.connectButton);
            this.mainMenu1.MenuItems.Add(this.optionsMenu);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectDisconnectButtonPressed);
            // 
            // optionsMenu
            // 
            this.optionsMenu.Enabled = false;
            this.optionsMenu.MenuItems.Add(this.listFilesButton);
            this.optionsMenu.MenuItems.Add(this.listFormatsButton);
            this.optionsMenu.Text = "Retrieve";
            // 
            // listFilesButton
            // 
            this.listFilesButton.Text = "Files";
            this.listFilesButton.Click += new System.EventHandler(this.listFilesButton_Click);
            // 
            // listFormatsButton
            // 
            this.listFormatsButton.Text = "Formats";
            this.listFormatsButton.Click += new System.EventHandler(this.listFormatsButton_Click);
            // 
            // fileListPanel
            // 
            this.fileListPanel.BackColor = System.Drawing.Color.DarkGray;
            this.fileListPanel.Controls.Add(this.filesOnPrinterListBox);
            this.fileListPanel.Controls.Add(this.fileNamesLabel);
            this.fileListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListPanel.Location = new System.Drawing.Point(0, 0);
            this.fileListPanel.Name = "fileListPanel";
            this.fileListPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // filesOnPrinterListBox
            // 
            this.filesOnPrinterListBox.BackColor = System.Drawing.Color.LightGray;
            this.filesOnPrinterListBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filesOnPrinterListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesOnPrinterListBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.filesOnPrinterListBox.ForeColor = System.Drawing.Color.OrangeRed;
            this.filesOnPrinterListBox.Location = new System.Drawing.Point(0, 20);
            this.filesOnPrinterListBox.Multiline = true;
            this.filesOnPrinterListBox.Name = "filesOnPrinterListBox";
            this.filesOnPrinterListBox.ReadOnly = true;
            this.filesOnPrinterListBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.filesOnPrinterListBox.Size = new System.Drawing.Size(240, 248);
            this.filesOnPrinterListBox.TabIndex = 22;
            // 
            // fileNamesLabel
            // 
            this.fileNamesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileNamesLabel.Location = new System.Drawing.Point(0, 0);
            this.fileNamesLabel.Name = "fileNamesLabel";
            this.fileNamesLabel.Size = new System.Drawing.Size(240, 20);
            this.fileNamesLabel.Text = "Files on Printer";
            this.fileNamesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // connectionPanel
            // 
            this.connectionPanel.BackColor = System.Drawing.Color.DarkGray;
            this.connectionPanel.BluetoothMacAddress = "";
            this.connectionPanel.ConnectionType = "IP/DNS";
            this.connectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.connectionPanel.Size = new System.Drawing.Size(240, 268);
            this.connectionPanel.TabIndex = 1;
            // 
            // ListFormatsDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.connectionPanel);
            this.Controls.Add(this.fileListPanel);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "ListFormatsDemoForm";
            this.Text = "List Formats Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ListFormatsDemoForm_Closing);
            this.fileListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem connectButton;
        private Microsoft.WindowsCE.Forms.InputPanel onScreenKeypad;
        private System.Windows.Forms.MenuItem optionsMenu;
        private System.Windows.Forms.MenuItem listFilesButton;
        private System.Windows.Forms.MenuItem listFormatsButton;
        private System.Windows.Forms.Panel fileListPanel;
        private System.Windows.Forms.TextBox filesOnPrinterListBox;
        private System.Windows.Forms.Label fileNamesLabel;
        private ConnectionPanel connectionPanel;

    }
}