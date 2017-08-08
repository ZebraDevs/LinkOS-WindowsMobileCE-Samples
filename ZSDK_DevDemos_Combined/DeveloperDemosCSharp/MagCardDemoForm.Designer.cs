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
    partial class MagCardDemoForm
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
            this.readMagCardButton = new System.Windows.Forms.MenuItem();
            this.onScreenKeypad = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.magCardTrackPanel = new System.Windows.Forms.Panel();
            this.track3Value = new System.Windows.Forms.TextBox();
            this.track2Value = new System.Windows.Forms.TextBox();
            this.track1Value = new System.Windows.Forms.TextBox();
            this.track3Label = new System.Windows.Forms.Label();
            this.track2Label = new System.Windows.Forms.Label();
            this.track1Label = new System.Windows.Forms.Label();
            this.connectionPanel = new ConnectionPanel();
            this.magCardTrackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.connectButton);
            this.mainMenu1.MenuItems.Add(this.readMagCardButton);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.doConnect);
            // 
            // readMagCardButton
            // 
            this.readMagCardButton.Enabled = false;
            this.readMagCardButton.Text = "Read...";
            this.readMagCardButton.Click += new System.EventHandler(this.magCardButtonPressed);
            // 
            // magCardTrackPanel
            // 
            this.magCardTrackPanel.BackColor = System.Drawing.Color.DarkGray;
            this.magCardTrackPanel.Controls.Add(this.track3Value);
            this.magCardTrackPanel.Controls.Add(this.track2Value);
            this.magCardTrackPanel.Controls.Add(this.track1Value);
            this.magCardTrackPanel.Controls.Add(this.track3Label);
            this.magCardTrackPanel.Controls.Add(this.track2Label);
            this.magCardTrackPanel.Controls.Add(this.track1Label);
            this.magCardTrackPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.magCardTrackPanel.Location = new System.Drawing.Point(0, 145);
            this.magCardTrackPanel.Name = "magCardTrackPanel";
            this.magCardTrackPanel.Size = new System.Drawing.Size(240, 123);
            // 
            // track3Value
            // 
            this.track3Value.Location = new System.Drawing.Point(45, 65);
            this.track3Value.Name = "track3Value";
            this.track3Value.ReadOnly = true;
            this.track3Value.Size = new System.Drawing.Size(181, 21);
            this.track3Value.TabIndex = 36;
            // 
            // track2Value
            // 
            this.track2Value.Location = new System.Drawing.Point(46, 37);
            this.track2Value.Name = "track2Value";
            this.track2Value.ReadOnly = true;
            this.track2Value.Size = new System.Drawing.Size(181, 21);
            this.track2Value.TabIndex = 35;
            // 
            // track1Value
            // 
            this.track1Value.Location = new System.Drawing.Point(46, 9);
            this.track1Value.Name = "track1Value";
            this.track1Value.ReadOnly = true;
            this.track1Value.Size = new System.Drawing.Size(181, 21);
            this.track1Value.TabIndex = 34;
            // 
            // track3Label
            // 
            this.track3Label.Location = new System.Drawing.Point(9, 67);
            this.track3Label.Name = "track3Label";
            this.track3Label.Size = new System.Drawing.Size(30, 20);
            this.track3Label.Text = "T3:";
            // 
            // track2Label
            // 
            this.track2Label.Location = new System.Drawing.Point(9, 40);
            this.track2Label.Name = "track2Label";
            this.track2Label.Size = new System.Drawing.Size(30, 20);
            this.track2Label.Text = "T2:";
            // 
            // track1Label
            // 
            this.track1Label.Location = new System.Drawing.Point(9, 11);
            this.track1Label.Name = "track1Label";
            this.track1Label.Size = new System.Drawing.Size(30, 20);
            this.track1Label.Text = "T1:";
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
            this.connectionPanel.Size = new System.Drawing.Size(240, 145);
            this.connectionPanel.TabIndex = 1;
            // 
            // MagCardDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.magCardTrackPanel);
            this.Controls.Add(this.connectionPanel);
            this.KeyPreview = true;
            this.Menu = this.mainMenu1;
            this.Name = "MagCardDemoForm";
            this.Text = "MagCard Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MagCardDemoForm_Closing);
            this.magCardTrackPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private Microsoft.WindowsCE.Forms.InputPanel onScreenKeypad;
        private System.Windows.Forms.Panel magCardTrackPanel;
        private System.Windows.Forms.MenuItem connectButton;
        private System.Windows.Forms.MenuItem readMagCardButton;
        private System.Windows.Forms.Label track3Label;
        private System.Windows.Forms.Label track2Label;
        private System.Windows.Forms.Label track1Label;
        private System.Windows.Forms.TextBox track1Value;
        private System.Windows.Forms.TextBox track2Value;
        private System.Windows.Forms.TextBox track3Value;
        private ConnectionPanel connectionPanel;

    }
}