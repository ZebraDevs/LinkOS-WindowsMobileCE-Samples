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
 File:   BluetoothDiscoverForm.Designer.cs

 Description: Form layout and design for BluetoothDiscoverForm.

 $Revision: 1 $
 $Date: 2010/06/03 $
 *******************************************************************************/

namespace Bluetooth_Discovery_Demo
{
    partial class BluetoothDiscoveryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.discoveryButton = new System.Windows.Forms.MenuItem();
            this.connectButton = new System.Windows.Forms.MenuItem();
            this.discoveredPrintersListBox = new System.Windows.Forms.ListBox();
            this.statusBar = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.discoveryButton);
            this.mainMenu1.MenuItems.Add(this.connectButton);
            // 
            // discoveryButton
            // 
            this.discoveryButton.Text = "Discover";
            this.discoveryButton.Click += new System.EventHandler(this.discoverButtonClicked);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButtonClicked);
            // 
            // discoveredPrintersListBox
            // 
            this.discoveredPrintersListBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.discoveredPrintersListBox.Location = new System.Drawing.Point(3, 29);
            this.discoveredPrintersListBox.Name = "discoveredPrintersListBox";
            this.discoveredPrintersListBox.Size = new System.Drawing.Size(234, 212);
            this.discoveredPrintersListBox.TabIndex = 0;
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Red;
            this.statusBar.Location = new System.Drawing.Point(4, 4);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(233, 23);
            this.statusBar.Text = "Not Connected";
            this.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(125, 245);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(112, 20);
            this.disconnectButton.TabIndex = 1;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Click += new System.EventHandler(this.onDisconnectButtonClicked);
            // 
            // BluetoothDiscoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.discoveredPrintersListBox);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "BluetoothDiscoveryForm";
            this.Text = "Bluetooth Discovery";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.onFrameClose);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem discoveryButton;
        private System.Windows.Forms.MenuItem connectButton;
        private System.Windows.Forms.ListBox discoveredPrintersListBox;
        private System.Windows.Forms.Label statusBar;
        private System.Windows.Forms.Button disconnectButton;
    }
}

