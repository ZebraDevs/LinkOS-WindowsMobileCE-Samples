namespace WinSDKImageRotate
{
    partial class ImageRotate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageRotate));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.PrintButton = new System.Windows.Forms.MenuItem();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.radioButton90 = new System.Windows.Forms.RadioButton();
            this.radioButton180 = new System.Windows.Forms.RadioButton();
            this.radioButton270 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.macAddressTextBox = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbxFolder = new System.Windows.Forms.PictureBox();
            this.ImagePathtextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.PrintButton);
            // 
            // PrintButton
            // 
            this.PrintButton.Text = "Print";
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(56, 155);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(100, 20);
            this.radioButtonNormal.TabIndex = 1;
            this.radioButtonNormal.Text = "0 degrees";
            // 
            // radioButton90
            // 
            this.radioButton90.Location = new System.Drawing.Point(56, 172);
            this.radioButton90.Name = "radioButton90";
            this.radioButton90.Size = new System.Drawing.Size(100, 20);
            this.radioButton90.TabIndex = 2;
            this.radioButton90.Text = "90 degrees";
            // 
            // radioButton180
            // 
            this.radioButton180.Location = new System.Drawing.Point(56, 189);
            this.radioButton180.Name = "radioButton180";
            this.radioButton180.Size = new System.Drawing.Size(100, 20);
            this.radioButton180.TabIndex = 3;
            this.radioButton180.Text = "180 degrees";
            // 
            // radioButton270
            // 
            this.radioButton270.Location = new System.Drawing.Point(56, 206);
            this.radioButton270.Name = "radioButton270";
            this.radioButton270.Size = new System.Drawing.Size(100, 20);
            this.radioButton270.TabIndex = 4;
            this.radioButton270.Text = "270 degrees";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 20);
            this.label1.Text = "Enter Printer Bluetooth MAC Address:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 14);
            this.label2.Text = "Rotation:";
            // 
            // macAddressTextBox
            // 
            this.macAddressTextBox.Location = new System.Drawing.Point(4, 101);
            this.macAddressTextBox.Name = "macAddressTextBox";
            this.macAddressTextBox.Size = new System.Drawing.Size(177, 21);
            this.macAddressTextBox.TabIndex = 13;
            this.macAddressTextBox.Text = "00037A6D5177";
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Red;
            this.statusBar.Location = new System.Drawing.Point(0, 0);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(237, 20);
            this.statusBar.Text = "Not Connected";
            this.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 20);
            this.label3.Text = "Select / Enter file to send to printer";
            // 
            // pbxFolder
            // 
            this.pbxFolder.BackColor = System.Drawing.Color.Silver;
            this.pbxFolder.Image = ((System.Drawing.Image)(resources.GetObject("pbxFolder.Image")));
            this.pbxFolder.Location = new System.Drawing.Point(202, 51);
            this.pbxFolder.Name = "pbxFolder";
            this.pbxFolder.Size = new System.Drawing.Size(30, 30);
            this.pbxFolder.Click += new System.EventHandler(this.pbxFolder_Click);
            // 
            // ImagePathtextBox
            // 
            this.ImagePathtextBox.Location = new System.Drawing.Point(5, 51);
            this.ImagePathtextBox.Name = "ImagePathtextBox";
            this.ImagePathtextBox.Size = new System.Drawing.Size(196, 21);
            this.ImagePathtextBox.TabIndex = 16;
            // 
            // ImageRotate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.ImagePathtextBox);
            this.Controls.Add(this.pbxFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.macAddressTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton270);
            this.Controls.Add(this.radioButton180);
            this.Controls.Add(this.radioButton90);
            this.Controls.Add(this.radioButtonNormal);
            this.Menu = this.mainMenu1;
            this.Name = "ImageRotate";
            this.Text = "Image Rotation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.RadioButton radioButton90;
        private System.Windows.Forms.RadioButton radioButton180;
        private System.Windows.Forms.RadioButton radioButton270;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox macAddressTextBox;
        private System.Windows.Forms.Label statusBar;
        private System.Windows.Forms.MenuItem PrintButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbxFolder;
        private System.Windows.Forms.TextBox ImagePathtextBox;

    }
}

