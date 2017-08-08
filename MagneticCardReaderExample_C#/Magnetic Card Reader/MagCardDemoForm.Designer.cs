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
 File:   MagCardDemoForm.Designer.cs

 Description: Layout and design for MagCardDemoForm.

 $Revision: 1 $
 $Date: 2010/06/07 $
 *******************************************************************************/

namespace Magnetic_Card_Reader
{
    partial class MagCardDemoForm
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
            this.readButton = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.track1Value = new System.Windows.Forms.TextBox();
            this.track2Value = new System.Windows.Forms.TextBox();
            this.track3Value = new System.Windows.Forms.TextBox();
            this.macTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.Label();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.connectButton);
            this.mainMenu1.MenuItems.Add(this.readButton);
            // 
            // connectButton
            // 
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.onConnectButtonClick);
            // 
            // readButton
            // 
            this.readButton.Text = "Read";
            this.readButton.Click += new System.EventHandler(this.onReadButtonClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.Text = "Track 1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.Text = "Track 2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.Text = "Track 3";
            // 
            // track1Value
            // 
            this.track1Value.Location = new System.Drawing.Point(61, 163);
            this.track1Value.Name = "track1Value";
            this.track1Value.Size = new System.Drawing.Size(174, 21);
            this.track1Value.TabIndex = 3;
            // 
            // track2Value
            // 
            this.track2Value.Location = new System.Drawing.Point(61, 190);
            this.track2Value.Name = "track2Value";
            this.track2Value.Size = new System.Drawing.Size(174, 21);
            this.track2Value.TabIndex = 4;
            // 
            // track3Value
            // 
            this.track3Value.Location = new System.Drawing.Point(61, 217);
            this.track3Value.Name = "track3Value";
            this.track3Value.Size = new System.Drawing.Size(174, 21);
            this.track3Value.TabIndex = 5;
            // 
            // macTextBox
            // 
            this.macTextBox.Location = new System.Drawing.Point(143, 24);
            this.macTextBox.Name = "macTextBox";
            this.macTextBox.Size = new System.Drawing.Size(92, 21);
            this.macTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.Text = "Bluetooth MAC Address";
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(5, 4);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(230, 20);
            this.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(5, 245);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(105, 20);
            this.disconnectButton.TabIndex = 13;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButtonClicked);
            // 
            // MagCardDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.macTextBox);
            this.Controls.Add(this.track3Value);
            this.Controls.Add(this.track2Value);
            this.Controls.Add(this.track1Value);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "MagCardDemoForm";
            this.Text = "Mag Card Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.onFrameClose);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox track1Value;
        private System.Windows.Forms.TextBox track2Value;
        private System.Windows.Forms.TextBox track3Value;
        private System.Windows.Forms.MenuItem connectButton;
        private System.Windows.Forms.MenuItem readButton;
        private System.Windows.Forms.TextBox macTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label statusBar;
        private System.Windows.Forms.Button disconnectButton;
    }
}