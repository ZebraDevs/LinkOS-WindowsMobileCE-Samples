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
 ***********************************************
 File:   ConnectionPanel.Designer.cs

 Description: Form design for ConnectionPanel.cs.

 $Revision: 1 $
 $Date: 06/14/2010 $
 *******************************************************************************/

namespace Connectivity_Demo
{
    partial class ConnectionPanel {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.connLabel = new System.Windows.Forms.Label();
            this.connectionMethodCombo = new System.Windows.Forms.ComboBox();
            this.ipDnsPanel = new System.Windows.Forms.Panel();
            this.portNumber = new System.Windows.Forms.TextBox();
            this.ipDnsAddress = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipDnsLabel = new System.Windows.Forms.Label();
            this.bluetoothPanel = new System.Windows.Forms.Panel();
            this.macAddress = new System.Windows.Forms.TextBox();
            this.btLabel = new System.Windows.Forms.Label();
            this.serialPanel = new System.Windows.Forms.Panel();
            this.handshakeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataBitsCombo = new System.Windows.Forms.ComboBox();
            this.dataBitLabel = new System.Windows.Forms.Label();
            this.stopBitsCombo = new System.Windows.Forms.ComboBox();
            this.stopBitLabel = new System.Windows.Forms.Label();
            this.parityCombo = new System.Windows.Forms.ComboBox();
            this.parityLabel = new System.Windows.Forms.Label();
            this.baudRateCombo = new System.Windows.Forms.ComboBox();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.portNamesCombo = new System.Windows.Forms.ComboBox();
            this.portNameLabel = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.connectButton = new System.Windows.Forms.MenuItem();
            this.ipDnsPanel.SuspendLayout();
            this.bluetoothPanel.SuspendLayout();
            this.serialPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // connLabel
            // 
            this.connLabel.Location = new System.Drawing.Point(6, 38);
            this.connLabel.Name = "connLabel";
            this.connLabel.Size = new System.Drawing.Size(118, 19);
            this.connLabel.Text = "Connection Method: ";
            // 
            // connectionMethodCombo
            // 
            this.connectionMethodCombo.Items.Add("IP/DNS");
            this.connectionMethodCombo.Items.Add("Bluetooth(R)");
            this.connectionMethodCombo.Items.Add("Serial");
            this.connectionMethodCombo.Location = new System.Drawing.Point(130, 36);
            this.connectionMethodCombo.Name = "connectionMethodCombo";
            this.connectionMethodCombo.Size = new System.Drawing.Size(100, 22);
            this.connectionMethodCombo.TabIndex = 1;
            this.connectionMethodCombo.SelectedValueChanged += new System.EventHandler(this.connectionMethod_SelectedValueChanged);
            // 
            // ipDnsPanel
            // 
            this.ipDnsPanel.BackColor = System.Drawing.Color.DarkGray;
            this.ipDnsPanel.Controls.Add(this.portNumber);
            this.ipDnsPanel.Controls.Add(this.ipDnsAddress);
            this.ipDnsPanel.Controls.Add(this.portLabel);
            this.ipDnsPanel.Controls.Add(this.ipDnsLabel);
            this.ipDnsPanel.Location = new System.Drawing.Point(0, 64);
            this.ipDnsPanel.Name = "ipDnsPanel";
            this.ipDnsPanel.Size = new System.Drawing.Size(230, 81);
            this.ipDnsPanel.Visible = false;
            // 
            // portNumber
            // 
            this.portNumber.Location = new System.Drawing.Point(105, 42);
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(100, 21);
            this.portNumber.TabIndex = 3;
            this.portNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portNumber_KeyPress);
            // 
            // ipDnsAddress
            // 
            this.ipDnsAddress.Location = new System.Drawing.Point(105, 11);
            this.ipDnsAddress.Name = "ipDnsAddress";
            this.ipDnsAddress.Size = new System.Drawing.Size(100, 21);
            this.ipDnsAddress.TabIndex = 2;
            // 
            // portLabel
            // 
            this.portLabel.Location = new System.Drawing.Point(15, 43);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(35, 20);
            this.portLabel.Text = "Port:";
            // 
            // ipDnsLabel
            // 
            this.ipDnsLabel.Location = new System.Drawing.Point(15, 16);
            this.ipDnsLabel.Name = "ipDnsLabel";
            this.ipDnsLabel.Size = new System.Drawing.Size(54, 16);
            this.ipDnsLabel.Text = "IP/DNS:";
            // 
            // bluetoothPanel
            // 
            this.bluetoothPanel.BackColor = System.Drawing.Color.DarkGray;
            this.bluetoothPanel.Controls.Add(this.macAddress);
            this.bluetoothPanel.Controls.Add(this.btLabel);
            this.bluetoothPanel.Location = new System.Drawing.Point(0, 73);
            this.bluetoothPanel.Name = "bluetoothPanel";
            this.bluetoothPanel.Size = new System.Drawing.Size(230, 54);
            this.bluetoothPanel.Visible = false;
            // 
            // macAddress
            // 
            this.macAddress.Location = new System.Drawing.Point(105, 15);
            this.macAddress.Name = "macAddress";
            this.macAddress.Size = new System.Drawing.Size(100, 21);
            this.macAddress.TabIndex = 1;
            // 
            // btLabel
            // 
            this.btLabel.Location = new System.Drawing.Point(15, 16);
            this.btLabel.Name = "btLabel";
            this.btLabel.Size = new System.Drawing.Size(84, 20);
            this.btLabel.Text = "MAC Address:";
            // 
            // serialPanel
            // 
            this.serialPanel.BackColor = System.Drawing.Color.DarkGray;
            this.serialPanel.Controls.Add(this.handshakeCombo);
            this.serialPanel.Controls.Add(this.label1);
            this.serialPanel.Controls.Add(this.dataBitsCombo);
            this.serialPanel.Controls.Add(this.dataBitLabel);
            this.serialPanel.Controls.Add(this.stopBitsCombo);
            this.serialPanel.Controls.Add(this.stopBitLabel);
            this.serialPanel.Controls.Add(this.parityCombo);
            this.serialPanel.Controls.Add(this.parityLabel);
            this.serialPanel.Controls.Add(this.baudRateCombo);
            this.serialPanel.Controls.Add(this.baudRateLabel);
            this.serialPanel.Controls.Add(this.portNamesCombo);
            this.serialPanel.Controls.Add(this.portNameLabel);
            this.serialPanel.Location = new System.Drawing.Point(0, 64);
            this.serialPanel.Name = "serialPanel";
            this.serialPanel.Size = new System.Drawing.Size(233, 81);
            this.serialPanel.Visible = false;
            // 
            // handshakeCombo
            // 
            this.handshakeCombo.Items.Add("None");
            this.handshakeCombo.Items.Add("XOnXOff");
            this.handshakeCombo.Items.Add("RTS");
            this.handshakeCombo.Items.Add("RTSXOnXOff");
            this.handshakeCombo.Location = new System.Drawing.Point(170, 52);
            this.handshakeCombo.Name = "handshakeCombo";
            this.handshakeCombo.Size = new System.Drawing.Size(60, 22);
            this.handshakeCombo.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(104, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.Text = "Handshake:";
            // 
            // dataBitsCombo
            // 
            this.dataBitsCombo.Items.Add("5");
            this.dataBitsCombo.Items.Add("6");
            this.dataBitsCombo.Items.Add("7");
            this.dataBitsCombo.Items.Add("8");
            this.dataBitsCombo.Location = new System.Drawing.Point(170, 2);
            this.dataBitsCombo.Name = "dataBitsCombo";
            this.dataBitsCombo.Size = new System.Drawing.Size(60, 22);
            this.dataBitsCombo.TabIndex = 11;
            // 
            // dataBitLabel
            // 
            this.dataBitLabel.Location = new System.Drawing.Point(104, 4);
            this.dataBitLabel.Name = "dataBitLabel";
            this.dataBitLabel.Size = new System.Drawing.Size(60, 20);
            this.dataBitLabel.Text = "Data Bits:";
            // 
            // stopBitsCombo
            // 
            this.stopBitsCombo.Items.Add("1");
            this.stopBitsCombo.Items.Add("1.5");
            this.stopBitsCombo.Items.Add("2");
            this.stopBitsCombo.Location = new System.Drawing.Point(170, 28);
            this.stopBitsCombo.Name = "stopBitsCombo";
            this.stopBitsCombo.Size = new System.Drawing.Size(60, 22);
            this.stopBitsCombo.TabIndex = 9;
            // 
            // stopBitLabel
            // 
            this.stopBitLabel.Location = new System.Drawing.Point(104, 28);
            this.stopBitLabel.Name = "stopBitLabel";
            this.stopBitLabel.Size = new System.Drawing.Size(60, 20);
            this.stopBitLabel.Text = "Stop Bits:";
            // 
            // parityCombo
            // 
            this.parityCombo.Items.Add("None");
            this.parityCombo.Items.Add("Even");
            this.parityCombo.Items.Add("Odd");
            this.parityCombo.Items.Add("Mark");
            this.parityCombo.Items.Add("Space");
            this.parityCombo.Location = new System.Drawing.Point(41, 52);
            this.parityCombo.Name = "parityCombo";
            this.parityCombo.Size = new System.Drawing.Size(57, 22);
            this.parityCombo.TabIndex = 7;
            // 
            // parityLabel
            // 
            this.parityLabel.Location = new System.Drawing.Point(3, 54);
            this.parityLabel.Name = "parityLabel";
            this.parityLabel.Size = new System.Drawing.Size(43, 20);
            this.parityLabel.Text = "Parity:";
            // 
            // baudRateCombo
            // 
            this.baudRateCombo.Items.Add("300");
            this.baudRateCombo.Items.Add("600");
            this.baudRateCombo.Items.Add("1200");
            this.baudRateCombo.Items.Add("2400");
            this.baudRateCombo.Items.Add("4800");
            this.baudRateCombo.Items.Add("7200");
            this.baudRateCombo.Items.Add("9600");
            this.baudRateCombo.Items.Add("14400");
            this.baudRateCombo.Items.Add("19200");
            this.baudRateCombo.Items.Add("28800");
            this.baudRateCombo.Items.Add("38400");
            this.baudRateCombo.Items.Add("57600");
            this.baudRateCombo.Items.Add("115200");
            this.baudRateCombo.Location = new System.Drawing.Point(41, 26);
            this.baudRateCombo.Name = "baudRateCombo";
            this.baudRateCombo.Size = new System.Drawing.Size(57, 22);
            this.baudRateCombo.TabIndex = 5;
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.Location = new System.Drawing.Point(3, 27);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(43, 20);
            this.baudRateLabel.Text = "Baud:";
            // 
            // portNamesCombo
            // 
            this.portNamesCombo.Items.Add("COM1");
            this.portNamesCombo.Items.Add("COM2");
            this.portNamesCombo.Items.Add("COM3");
            this.portNamesCombo.Items.Add("COM4");
            this.portNamesCombo.Items.Add("COM5");
            this.portNamesCombo.Items.Add("COM6");
            this.portNamesCombo.Items.Add("COM7");
            this.portNamesCombo.Items.Add("COM8");
            this.portNamesCombo.Items.Add("COM9");
            this.portNamesCombo.Location = new System.Drawing.Point(41, 2);
            this.portNamesCombo.Name = "portNamesCombo";
            this.portNamesCombo.Size = new System.Drawing.Size(57, 22);
            this.portNamesCombo.TabIndex = 3;
            // 
            // portNameLabel
            // 
            this.portNameLabel.Location = new System.Drawing.Point(2, 4);
            this.portNameLabel.Name = "portNameLabel";
            this.portNameLabel.Size = new System.Drawing.Size(35, 20);
            this.portNameLabel.Text = "Port:";
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Red;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(240, 20);
            this.statusBar.Text = "Status : Not Connected";
            this.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.connectButton);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Test";
            this.connectButton.Click += new System.EventHandler(this.onTestButtonClick);
            // 
            // ConnectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.connectionMethodCombo);
            this.Controls.Add(this.connLabel);
            this.Controls.Add(this.serialPanel);
            this.Controls.Add(this.bluetoothPanel);
            this.Controls.Add(this.ipDnsPanel);
            this.Menu = this.mainMenu1;
            this.Name = "ConnectionPanel";
            this.Text = "Connectivity Demo";
            this.ipDnsPanel.ResumeLayout(false);
            this.bluetoothPanel.ResumeLayout(false);
            this.serialPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label connLabel;
        private System.Windows.Forms.ComboBox connectionMethodCombo;
        private System.Windows.Forms.Label ipDnsLabel;
        private System.Windows.Forms.TextBox portNumber;
        private System.Windows.Forms.TextBox ipDnsAddress;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Panel bluetoothPanel;
        private System.Windows.Forms.Label btLabel;
        private System.Windows.Forms.TextBox macAddress;
        private System.Windows.Forms.Panel serialPanel;
        private System.Windows.Forms.Label portNameLabel;
        private System.Windows.Forms.ComboBox portNamesCombo;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.ComboBox stopBitsCombo;
        private System.Windows.Forms.Label stopBitLabel;
        private System.Windows.Forms.ComboBox parityCombo;
        private System.Windows.Forms.Label parityLabel;
        private System.Windows.Forms.ComboBox baudRateCombo;
        private System.Windows.Forms.ComboBox dataBitsCombo;
        private System.Windows.Forms.Label dataBitLabel;
        private System.Windows.Forms.Label statusBar;
        private System.Windows.Forms.ComboBox handshakeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ipDnsPanel;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem connectButton;
    }
}
