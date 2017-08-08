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
    partial class StoredFormatDemoForm
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
            this.connectionPanel = new ConnectionPanel();
            this.rightSideButton = new System.Windows.Forms.MenuItem();
            this.leftSideButton = new System.Windows.Forms.MenuItem();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.printJobSentPanel = new System.Windows.Forms.Panel();
            this.printJobSentLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.backToListFormatsButton = new System.Windows.Forms.Button();
            this.reEnterDataButton = new System.Windows.Forms.Button();
            this.reprintButton = new System.Windows.Forms.Button();
            this.varFieldPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.pleaseFillLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.formatListPanel = new System.Windows.Forms.Panel();
            this.formatSelectButton = new System.Windows.Forms.Button();
            this.formatListBox = new System.Windows.Forms.ListBox();
            this.printJobSentPanel.SuspendLayout();
            this.varFieldPanel.SuspendLayout();
            this.formatListPanel.SuspendLayout();
            this.SuspendLayout();
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
            // rightSideButton
            // 
            this.rightSideButton.Text = "List Formats";
            this.rightSideButton.Click += new System.EventHandler(this.rightSideButtonPressed);
            // 
            // leftSideButton
            // 
            this.leftSideButton.Enabled = false;
            this.leftSideButton.Text = "";
            this.leftSideButton.Click += new System.EventHandler(this.leftSideButtonPressed);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.leftSideButton);
            this.mainMenu.MenuItems.Add(this.rightSideButton);
            // 
            // printJobSentPanel
            // 
            this.printJobSentPanel.AutoScroll = true;
            this.printJobSentPanel.BackColor = System.Drawing.Color.DarkGray;
            this.printJobSentPanel.Controls.Add(this.printJobSentLabel);
            this.printJobSentPanel.Controls.Add(this.exitButton);
            this.printJobSentPanel.Controls.Add(this.backToListFormatsButton);
            this.printJobSentPanel.Controls.Add(this.reEnterDataButton);
            this.printJobSentPanel.Controls.Add(this.reprintButton);
            this.printJobSentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printJobSentPanel.Location = new System.Drawing.Point(0, 0);
            this.printJobSentPanel.Name = "printJobSentPanel";
            this.printJobSentPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // printJobSentLabel
            // 
            this.printJobSentLabel.Location = new System.Drawing.Point(80, 21);
            this.printJobSentLabel.Name = "printJobSentLabel";
            this.printJobSentLabel.Size = new System.Drawing.Size(80, 20);
            this.printJobSentLabel.Text = "Print Job Sent";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(75, 167);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(90, 20);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // backToListFormatsButton
            // 
            this.backToListFormatsButton.Location = new System.Drawing.Point(44, 129);
            this.backToListFormatsButton.Name = "backToListFormatsButton";
            this.backToListFormatsButton.Size = new System.Drawing.Size(153, 20);
            this.backToListFormatsButton.TabIndex = 3;
            this.backToListFormatsButton.Text = "Back to Format List";
            this.backToListFormatsButton.Click += new System.EventHandler(this.backToListFormatsButton_Click);
            // 
            // reEnterDataButton
            // 
            this.reEnterDataButton.Location = new System.Drawing.Point(65, 92);
            this.reEnterDataButton.Name = "reEnterDataButton";
            this.reEnterDataButton.Size = new System.Drawing.Size(110, 20);
            this.reEnterDataButton.TabIndex = 2;
            this.reEnterDataButton.Text = "Re-Enter Data";
            this.reEnterDataButton.Click += new System.EventHandler(this.reEnterDataButton_Click);
            // 
            // reprintButton
            // 
            this.reprintButton.Location = new System.Drawing.Point(65, 57);
            this.reprintButton.Name = "reprintButton";
            this.reprintButton.Size = new System.Drawing.Size(110, 20);
            this.reprintButton.TabIndex = 0;
            this.reprintButton.Text = "Re-Print Label";
            this.reprintButton.Click += new System.EventHandler(this.reprintButton_Click);
            // 
            // varFieldPanel
            // 
            this.varFieldPanel.AutoScroll = true;
            this.varFieldPanel.BackColor = System.Drawing.Color.DarkGray;
            this.varFieldPanel.Controls.Add(this.titleLabel);
            this.varFieldPanel.Controls.Add(this.quantity);
            this.varFieldPanel.Controls.Add(this.pleaseFillLabel);
            this.varFieldPanel.Controls.Add(this.quantityLabel);
            this.varFieldPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.varFieldPanel.Location = new System.Drawing.Point(0, 0);
            this.varFieldPanel.Name = "varFieldPanel";
            this.varFieldPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(13, 1);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(191, 20);
            this.titleLabel.Text = "Format: ";
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(84, 55);
            this.quantity.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(61, 22);
            this.quantity.TabIndex = 5;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pleaseFillLabel
            // 
            this.pleaseFillLabel.Location = new System.Drawing.Point(13, 21);
            this.pleaseFillLabel.Name = "pleaseFillLabel";
            this.pleaseFillLabel.Size = new System.Drawing.Size(150, 20);
            this.pleaseFillLabel.Text = "Please fill in the variables:";
            // 
            // quantityLabel
            // 
            this.quantityLabel.Location = new System.Drawing.Point(13, 57);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(64, 20);
            this.quantityLabel.Text = "Quantity:";
            // 
            // formatListPanel
            // 
            this.formatListPanel.AutoScroll = true;
            this.formatListPanel.BackColor = System.Drawing.Color.DarkGray;
            this.formatListPanel.Controls.Add(this.formatSelectButton);
            this.formatListPanel.Controls.Add(this.formatListBox);
            this.formatListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formatListPanel.Location = new System.Drawing.Point(0, 0);
            this.formatListPanel.Name = "formatListPanel";
            this.formatListPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // formatSelectButton
            // 
            this.formatSelectButton.Enabled = false;
            this.formatSelectButton.Location = new System.Drawing.Point(90, 210);
            this.formatSelectButton.Name = "formatSelectButton";
            this.formatSelectButton.Size = new System.Drawing.Size(60, 30);
            this.formatSelectButton.TabIndex = 25;
            this.formatSelectButton.Text = "Next";
            this.formatSelectButton.Click += new System.EventHandler(this.formatSelectButton_Click);
            // 
            // formatListBox
            // 
            this.formatListBox.Location = new System.Drawing.Point(13, 24);
            this.formatListBox.Name = "formatListBox";
            this.formatListBox.Size = new System.Drawing.Size(210, 170);
            this.formatListBox.TabIndex = 24;
            // 
            // StoredFormatDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.varFieldPanel);
            this.Controls.Add(this.formatListPanel);
            this.Controls.Add(this.printJobSentPanel);
            this.Controls.Add(this.connectionPanel);
            this.Menu = this.mainMenu;
            this.Name = "StoredFormatDemoForm";
            this.Text = "Stored Format Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.StoredFormatDemoForm_Closing);
            this.printJobSentPanel.ResumeLayout(false);
            this.varFieldPanel.ResumeLayout(false);
            this.formatListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ConnectionPanel connectionPanel;
        private System.Windows.Forms.MenuItem rightSideButton;
        private System.Windows.Forms.MenuItem leftSideButton;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.Panel formatListPanel;
        private System.Windows.Forms.Button formatSelectButton;
        private System.Windows.Forms.ListBox formatListBox;
        private System.Windows.Forms.Panel varFieldPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.Label pleaseFillLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Panel printJobSentPanel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button backToListFormatsButton;
        private System.Windows.Forms.Button reEnterDataButton;
        private System.Windows.Forms.Button reprintButton;
        private System.Windows.Forms.Label printJobSentLabel;

    }
}