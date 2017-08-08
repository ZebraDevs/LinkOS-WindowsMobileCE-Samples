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
 File:   DiscoveryMain.Designer.cs

 Description: Form and code demonstrating how to discover and connect to printers
 * located on the network.

 $Revision: 1 $
 $Date: 06/30/2010 $
 *******************************************************************************/

namespace Discovery_Demo
{
    partial class DiscoveryMain
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
            this.discoveryButton = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.connectButton = new System.Windows.Forms.MenuItem();
            this.multicastPanel = new System.Windows.Forms.Panel();
            this.multicastHopUpDown = new System.Windows.Forms.NumericUpDown();
            this.multicastHopsLabel = new System.Windows.Forms.Label();
            this.discoveredPrintersLabel = new System.Windows.Forms.Label();
            this.discoveredPrintersListBox = new System.Windows.Forms.ListBox();
            this.methodLabel = new System.Windows.Forms.Label();
            this.discoveryMethodsComboBox = new System.Windows.Forms.ComboBox();
            this.topScreenPanel = new System.Windows.Forms.Panel();
            this.userLayoutPanel = new System.Windows.Forms.Panel();
            this.directBroadcastPanel = new System.Windows.Forms.Panel();
            this.directBroadcastTextBox = new System.Windows.Forms.TextBox();
            this.directLabel = new System.Windows.Forms.Label();
            this.subnetPanel = new System.Windows.Forms.Panel();
            this.subnetTextBox = new System.Windows.Forms.TextBox();
            this.subnetLabel = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.Label();
            this.printerListPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.multicastPanel.SuspendLayout();
            this.topScreenPanel.SuspendLayout();
            this.userLayoutPanel.SuspendLayout();
            this.directBroadcastPanel.SuspendLayout();
            this.subnetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // discoveryButton
            // 
            this.discoveryButton.Text = "Discovery";
            this.discoveryButton.Click += new System.EventHandler(this.discoveryButton_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.discoveryButton);
            this.mainMenu1.MenuItems.Add(this.connectButton);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // multicastPanel
            // 
            this.multicastPanel.BackColor = System.Drawing.Color.DarkGray;
            this.multicastPanel.Controls.Add(this.multicastHopUpDown);
            this.multicastPanel.Controls.Add(this.multicastHopsLabel);
            this.multicastPanel.Location = new System.Drawing.Point(1, 31);
            this.multicastPanel.Name = "multicastPanel";
            this.multicastPanel.Size = new System.Drawing.Size(196, 32);
            // 
            // multicastHopUpDown
            // 
            this.multicastHopUpDown.Location = new System.Drawing.Point(98, 2);
            this.multicastHopUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.multicastHopUpDown.Name = "multicastHopUpDown";
            this.multicastHopUpDown.Size = new System.Drawing.Size(53, 22);
            this.multicastHopUpDown.TabIndex = 6;
            this.multicastHopUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // multicastHopsLabel
            // 
            this.multicastHopsLabel.Location = new System.Drawing.Point(3, 4);
            this.multicastHopsLabel.Name = "multicastHopsLabel";
            this.multicastHopsLabel.Size = new System.Drawing.Size(89, 20);
            this.multicastHopsLabel.Text = "Multicast Hops:";
            // 
            // discoveredPrintersLabel
            // 
            this.discoveredPrintersLabel.Location = new System.Drawing.Point(22, 73);
            this.discoveredPrintersLabel.Name = "discoveredPrintersLabel";
            this.discoveredPrintersLabel.Size = new System.Drawing.Size(155, 14);
            this.discoveredPrintersLabel.Text = "Discovered Printers";
            this.discoveredPrintersLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // discoveredPrintersListBox
            // 
            this.discoveredPrintersListBox.BackColor = System.Drawing.Color.LightGray;
            this.discoveredPrintersListBox.Location = new System.Drawing.Point(0, 126);
            this.discoveredPrintersListBox.Name = "discoveredPrintersListBox";
            this.discoveredPrintersListBox.Size = new System.Drawing.Size(240, 114);
            this.discoveredPrintersListBox.TabIndex = 13;
            // 
            // methodLabel
            // 
            this.methodLabel.Location = new System.Drawing.Point(1, 7);
            this.methodLabel.Name = "methodLabel";
            this.methodLabel.Size = new System.Drawing.Size(54, 20);
            this.methodLabel.Text = "Method:";
            // 
            // discoveryMethodsComboBox
            // 
            this.discoveryMethodsComboBox.Items.Add("Multicast");
            this.discoveryMethodsComboBox.Items.Add("Directed Broadcast");
            this.discoveryMethodsComboBox.Items.Add("Local Broadcast");
            this.discoveryMethodsComboBox.Items.Add("Subnet Search");
            this.discoveryMethodsComboBox.Location = new System.Drawing.Point(61, 3);
            this.discoveryMethodsComboBox.Name = "discoveryMethodsComboBox";
            this.discoveryMethodsComboBox.Size = new System.Drawing.Size(129, 22);
            this.discoveryMethodsComboBox.TabIndex = 12;
            this.discoveryMethodsComboBox.SelectedIndexChanged += new System.EventHandler(this.discoveryMethodsComboBox_SelectedIndexChanged);
            // 
            // topScreenPanel
            // 
            this.topScreenPanel.BackColor = System.Drawing.Color.DarkGray;
            this.topScreenPanel.Controls.Add(this.userLayoutPanel);
            this.topScreenPanel.Controls.Add(this.statusBar);
            this.topScreenPanel.Location = new System.Drawing.Point(0, 0);
            this.topScreenPanel.Name = "topScreenPanel";
            this.topScreenPanel.Size = new System.Drawing.Size(240, 127);
            // 
            // userLayoutPanel
            // 
            this.userLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userLayoutPanel.BackColor = System.Drawing.Color.DarkGray;
            this.userLayoutPanel.Controls.Add(this.multicastPanel);
            this.userLayoutPanel.Controls.Add(this.directBroadcastPanel);
            this.userLayoutPanel.Controls.Add(this.subnetPanel);
            this.userLayoutPanel.Controls.Add(this.discoveredPrintersLabel);
            this.userLayoutPanel.Controls.Add(this.methodLabel);
            this.userLayoutPanel.Controls.Add(this.discoveryMethodsComboBox);
            this.userLayoutPanel.Location = new System.Drawing.Point(9, 23);
            this.userLayoutPanel.Name = "userLayoutPanel";
            this.userLayoutPanel.Size = new System.Drawing.Size(228, 101);
            // 
            // directBroadcastPanel
            // 
            this.directBroadcastPanel.BackColor = System.Drawing.Color.DarkGray;
            this.directBroadcastPanel.Controls.Add(this.directBroadcastTextBox);
            this.directBroadcastPanel.Controls.Add(this.directLabel);
            this.directBroadcastPanel.Location = new System.Drawing.Point(20, 30);
            this.directBroadcastPanel.Name = "directBroadcastPanel";
            this.directBroadcastPanel.Size = new System.Drawing.Size(177, 33);
            this.directBroadcastPanel.Visible = false;
            // 
            // directBroadcastTextBox
            // 
            this.directBroadcastTextBox.Location = new System.Drawing.Point(55, 3);
            this.directBroadcastTextBox.Name = "directBroadcastTextBox";
            this.directBroadcastTextBox.Size = new System.Drawing.Size(111, 21);
            this.directBroadcastTextBox.TabIndex = 8;
            this.directBroadcastTextBox.Text = ".255";
            // 
            // directLabel
            // 
            this.directLabel.Location = new System.Drawing.Point(3, 3);
            this.directLabel.Name = "directLabel";
            this.directLabel.Size = new System.Drawing.Size(46, 20);
            this.directLabel.Text = "Range: ";
            // 
            // subnetPanel
            // 
            this.subnetPanel.BackColor = System.Drawing.Color.DarkGray;
            this.subnetPanel.Controls.Add(this.subnetTextBox);
            this.subnetPanel.Controls.Add(this.subnetLabel);
            this.subnetPanel.Location = new System.Drawing.Point(20, 31);
            this.subnetPanel.Name = "subnetPanel";
            this.subnetPanel.Size = new System.Drawing.Size(173, 32);
            this.subnetPanel.Visible = false;
            // 
            // subnetTextBox
            // 
            this.subnetTextBox.Location = new System.Drawing.Point(55, 0);
            this.subnetTextBox.Name = "subnetTextBox";
            this.subnetTextBox.Size = new System.Drawing.Size(111, 21);
            this.subnetTextBox.TabIndex = 8;
            this.subnetTextBox.Text = ".*";
            // 
            // subnetLabel
            // 
            this.subnetLabel.Location = new System.Drawing.Point(3, 3);
            this.subnetLabel.Name = "subnetLabel";
            this.subnetLabel.Size = new System.Drawing.Size(46, 20);
            this.subnetLabel.Text = "Subnet:";
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Red;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(240, 20);
            this.statusBar.Text = "Status: Not Connected";
            this.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // printerListPanel
            // 
            this.printerListPanel.Location = new System.Drawing.Point(0, 0);
            this.printerListPanel.Name = "printerListPanel";
            this.printerListPanel.Size = new System.Drawing.Size(100, 100);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(147, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.Text = "Port:";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(185, 243);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(51, 21);
            this.portTextBox.TabIndex = 15;
            this.portTextBox.Text = "6101";
            // 
            // DiscoveryMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topScreenPanel);
            this.Controls.Add(this.discoveredPrintersListBox);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "DiscoveryMain";
            this.Text = "Discovery Demo";
            this.multicastPanel.ResumeLayout(false);
            this.topScreenPanel.ResumeLayout(false);
            this.userLayoutPanel.ResumeLayout(false);
            this.directBroadcastPanel.ResumeLayout(false);
            this.subnetPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        

        private System.Windows.Forms.Panel multicastPanel;
        private System.Windows.Forms.NumericUpDown multicastHopUpDown;
        private System.Windows.Forms.Label multicastHopsLabel;
        private System.Windows.Forms.Label discoveredPrintersLabel;
        private System.Windows.Forms.ListBox discoveredPrintersListBox;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.ComboBox discoveryMethodsComboBox;
        private System.Windows.Forms.Panel topScreenPanel;
        private System.Windows.Forms.Label statusBar;
        private System.Windows.Forms.TextBox directBroadcastTextBox;
        private System.Windows.Forms.TextBox subnetTextBox;
        private System.Windows.Forms.Panel directBroadcastPanel;
        private System.Windows.Forms.Label subnetLabel;
        private System.Windows.Forms.Panel subnetPanel;
        private System.Windows.Forms.Label directLabel;
        private System.Windows.Forms.Panel userLayoutPanel;
        private System.Windows.Forms.Panel printerListPanel;
        private System.Windows.Forms.MenuItem connectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.MenuItem discoveryButton;
    }
}

