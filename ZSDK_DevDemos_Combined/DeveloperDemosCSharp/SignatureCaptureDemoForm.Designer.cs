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
    partial class SignatureCaptureDemoForm {
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
            this.connectButton = new System.Windows.Forms.MenuItem();
            this.printButton = new System.Windows.Forms.MenuItem();
            this.inputPanel = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.signatureBox = new System.Windows.Forms.PictureBox();
            this.signatureLabel = new System.Windows.Forms.Label();
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
            this.connectionPanel.Size = new System.Drawing.Size(240, 149);
            this.connectionPanel.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.connectButton);
            this.mainMenu.MenuItems.Add(this.printButton);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Text = "Print";
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // signatureBox
            // 
            this.signatureBox.BackColor = System.Drawing.Color.White;
            this.signatureBox.Location = new System.Drawing.Point(0, 172);
            this.signatureBox.Name = "signatureBox";
            this.signatureBox.Size = new System.Drawing.Size(240, 96);
            this.signatureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.signatureBox_MouseMove);
            this.signatureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.signatureBox_MouseDown);
            this.signatureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.signatureBox_MouseUp);
            // 
            // signatureLabel
            // 
            this.signatureLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.signatureLabel.Location = new System.Drawing.Point(0, 149);
            this.signatureLabel.Name = "signatureLabel";
            this.signatureLabel.Size = new System.Drawing.Size(240, 20);
            this.signatureLabel.Text = "Sign Name:";
            // 
            // SignatureCaptureDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.signatureLabel);
            this.Controls.Add(this.signatureBox);
            this.Controls.Add(this.connectionPanel);
            this.Menu = this.mainMenu;
            this.Name = "SignatureCaptureDemoForm";
            this.Text = "Signature Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private ConnectionPanel connectionPanel;
        private System.Windows.Forms.MainMenu mainMenu;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel;
        private System.Windows.Forms.MenuItem connectButton;
        private System.Windows.Forms.MenuItem printButton;
        private System.Windows.Forms.PictureBox signatureBox;
        private System.Windows.Forms.Label signatureLabel;
    }
}