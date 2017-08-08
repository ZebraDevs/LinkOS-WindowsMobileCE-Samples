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
    partial class ImagePrintDemoForm
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
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.connectMenu = new System.Windows.Forms.MenuItem();
            this.getImageMenu = new System.Windows.Forms.MenuItem();
            this.fileExplorerButton = new System.Windows.Forms.MenuItem();
            this.cameraButton = new System.Windows.Forms.MenuItem();
            this.screenPanel = new System.Windows.Forms.Panel();
            this.connectionPanel = new ConnectionPanel();
            this.fileNameOnPrinterLabel = new System.Windows.Forms.Label();
            this.fileNameOnPrinterText = new System.Windows.Forms.TextBox();
            this.storeImageOnPrinter = new System.Windows.Forms.CheckBox();
            this.onScreenKeypad = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.screenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.connectMenu);
            this.mainMenu.MenuItems.Add(this.getImageMenu);
            // 
            // connectMenu
            // 
            this.connectMenu.Text = "Connect";
            this.connectMenu.Click += new System.EventHandler(this.connectMenu_Click);
            // 
            // getImageMenu
            // 
            this.getImageMenu.Enabled = false;
            this.getImageMenu.MenuItems.Add(this.fileExplorerButton);
            this.getImageMenu.MenuItems.Add(this.cameraButton);
            this.getImageMenu.Text = "Get Image";
            // 
            // fileExplorerButton
            // 
            this.fileExplorerButton.Text = "From File";
            this.fileExplorerButton.Click += new System.EventHandler(this.fileExplorerButton_Click);
            // 
            // cameraButton
            // 

            this.cameraButton.Text = "From Camera";
            if (Microsoft.WindowsCE.Forms.SystemSettings.Platform == Microsoft.WindowsCE.Forms.WinCEPlatform.WinCEGeneric) {
                this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click_CE_Device);
            } else {
                this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
            }
            // 
            // screenPanel
            // 
            this.screenPanel.AutoScroll = true;
            this.screenPanel.BackColor = System.Drawing.Color.DarkGray;
            this.screenPanel.Controls.Add(this.connectionPanel);
            this.screenPanel.Controls.Add(this.fileNameOnPrinterLabel);
            this.screenPanel.Controls.Add(this.fileNameOnPrinterText);
            this.screenPanel.Controls.Add(this.storeImageOnPrinter);
            this.screenPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenPanel.Location = new System.Drawing.Point(0, 0);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(240, 268);
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
            this.connectionPanel.TabIndex = 1;
            // 
            // fileNameOnPrinterLabel
            // 
            this.fileNameOnPrinterLabel.BackColor = System.Drawing.Color.DarkGray;
            this.fileNameOnPrinterLabel.Location = new System.Drawing.Point(3, 179);
            this.fileNameOnPrinterLabel.Name = "fileNameOnPrinterLabel";
            this.fileNameOnPrinterLabel.Size = new System.Drawing.Size(100, 20);
            this.fileNameOnPrinterLabel.Text = "Path on Printer:";
            this.fileNameOnPrinterLabel.Visible = false;
            // 
            // fileNameOnPrinterText
            // 
            this.fileNameOnPrinterText.BackColor = System.Drawing.Color.White;
            this.fileNameOnPrinterText.Enabled = false;
            this.fileNameOnPrinterText.Location = new System.Drawing.Point(109, 179);
            this.fileNameOnPrinterText.Name = "fileNameOnPrinterText";
            this.fileNameOnPrinterText.Size = new System.Drawing.Size(115, 21);
            this.fileNameOnPrinterText.TabIndex = 1;
            this.fileNameOnPrinterText.Visible = false;
            // 
            // storeImageOnPrinter
            // 
            this.storeImageOnPrinter.BackColor = System.Drawing.Color.DarkGray;
            this.storeImageOnPrinter.Location = new System.Drawing.Point(3, 153);
            this.storeImageOnPrinter.Name = "storeImageOnPrinter";
            this.storeImageOnPrinter.Size = new System.Drawing.Size(100, 20);
            this.storeImageOnPrinter.TabIndex = 0;
            this.storeImageOnPrinter.Text = "Store image";
            this.storeImageOnPrinter.CheckStateChanged += new System.EventHandler(this.storeImageOnPrinter_CheckStateChanged);
            // 
            // ImagePrintDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.screenPanel);
            this.Menu = this.mainMenu;
            this.Name = "ImagePrintDemoForm";
            this.Text = "Image Print Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ImagePrintDemoForm_Closing);
            this.screenPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem connectMenu;
        private System.Windows.Forms.MenuItem getImageMenu;
        private System.Windows.Forms.MenuItem fileExplorerButton;
        private System.Windows.Forms.MenuItem cameraButton;
        private Microsoft.WindowsCE.Forms.InputPanel onScreenKeypad;
        private ConnectionPanel connectionPanel;
        private System.Windows.Forms.Panel screenPanel;
        private System.Windows.Forms.Label fileNameOnPrinterLabel;
        private System.Windows.Forms.TextBox fileNameOnPrinterText;
        private System.Windows.Forms.CheckBox storeImageOnPrinter;
    }
}