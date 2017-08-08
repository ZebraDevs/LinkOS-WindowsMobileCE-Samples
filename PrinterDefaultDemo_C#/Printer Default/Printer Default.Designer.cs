namespace Printer_Default
{
    partial class PrinterDefaultForm
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
            this.DefaultButton = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.macAddressTextBox = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.DefaultButton);
            // 
            // DefaultButton
            // 
            this.DefaultButton.Text = "Default Printer";
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.Text = "Enter Printer Bluetooth MAC Address:";
            // 
            // macAddressTextBox
            // 
            this.macAddressTextBox.Location = new System.Drawing.Point(47, 58);
            this.macAddressTextBox.Name = "macAddressTextBox";
            this.macAddressTextBox.Size = new System.Drawing.Size(133, 21);
            this.macAddressTextBox.TabIndex = 7;
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
            // PrinterDefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.macAddressTextBox);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "PrinterDefaultForm";
            this.Text = "Printer Default Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox macAddressTextBox;
        private System.Windows.Forms.Label statusBar;
        private System.Windows.Forms.MenuItem DefaultButton;
    }
}

