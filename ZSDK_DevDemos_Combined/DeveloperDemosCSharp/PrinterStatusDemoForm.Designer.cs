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
    partial class PrinterStatusDemoForm {
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
            this.statusPanel = new System.Windows.Forms.Panel();
            this.statusMessages = new System.Windows.Forms.TextBox();
            this.statusMsgsLabel = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.leftSideButton = new System.Windows.Forms.MenuItem();
            this.onScreenKeypad = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.connectionPanel = new ConnectionPanel();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.DarkGray;
            this.statusPanel.Controls.Add(this.statusMsgsLabel);
            this.statusPanel.Controls.Add(this.statusMessages);
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.Location = new System.Drawing.Point(0, 0);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // statusMessages
            // 
            this.statusMessages.BackColor = System.Drawing.Color.DarkGray;
            this.statusMessages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statusMessages.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.statusMessages.ForeColor = System.Drawing.Color.Crimson;
            this.statusMessages.Location = new System.Drawing.Point(29, 31);
            this.statusMessages.Multiline = true;
            this.statusMessages.Name = "statusMessages";
            this.statusMessages.ReadOnly = true;
            this.statusMessages.Size = new System.Drawing.Size(182, 139);
            this.statusMessages.TabIndex = 22;
            // 
            // statusMsgsLabel
            // 
            this.statusMsgsLabel.Location = new System.Drawing.Point(72, 8);
            this.statusMsgsLabel.Name = "statusMsgsLabel";
            this.statusMsgsLabel.Size = new System.Drawing.Size(100, 20);
            this.statusMsgsLabel.Text = "Status Messages";
            this.statusMsgsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.leftSideButton);
            // 
            // leftSideButton
            // 
            this.leftSideButton.Text = "Connect";
            this.leftSideButton.Click += new System.EventHandler(this.leftSideButton_Click);
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
            this.connectionPanel.TabIndex = 0;
            // 
            // PrinterStatusDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.connectionPanel);
            this.Menu = this.mainMenu1;
            this.Name = "PrinterStatusDemoForm";
            this.Text = "Printer Status Demo";
            this.Closed += new System.EventHandler(this.PrinterStatusDemoForm_Closed);
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem leftSideButton;
        private Microsoft.WindowsCE.Forms.InputPanel onScreenKeypad;
        private System.Windows.Forms.MainMenu mainMenu1;
        private ConnectionPanel connectionPanel;
        private System.Windows.Forms.TextBox statusMessages;
        private System.Windows.Forms.Label statusMsgsLabel;
        private System.Windows.Forms.Panel statusPanel;
    }
}