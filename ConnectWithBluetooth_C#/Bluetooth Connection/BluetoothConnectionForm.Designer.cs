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
 File:    BluetoothConnectionForm.Designer.cs

 Description: Layout and design for BluetoothConnectionForm.

 $Revision: 1 $
 $Date: 2010/06/04 $
 *******************************************************************************/

namespace Bluetooth_Connection
{
    partial class BluetoothConnectionForm
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
            this.connectButton = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.macAddressTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.connectButton);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.onConnectButtonClick);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 4);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(237, 20);
            this.statusBar.Text = "Not Connected";
            this.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "MAC Address:";
            // 
            // macAddressTextBox
            // 
            this.macAddressTextBox.Location = new System.Drawing.Point(111, 28);
            this.macAddressTextBox.Name = "macAddressTextBox";
            this.macAddressTextBox.Size = new System.Drawing.Size(126, 21);
            this.macAddressTextBox.TabIndex = 2;
            this.macAddressTextBox.Text = "00037a2522e2";
            // 
            // BluetoothConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.macAddressTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusBar);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "BluetoothConnectionForm";
            this.Text = "Bluetooth Connection Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem connectButton;
        private System.Windows.Forms.Label statusBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox macAddressTextBox;
    }
}

