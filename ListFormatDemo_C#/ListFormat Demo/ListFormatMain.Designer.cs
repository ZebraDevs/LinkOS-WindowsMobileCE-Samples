namespace ListFormatDemo
{
    partial class ListFormatMain
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
            this.Retrieve = new System.Windows.Forms.MenuItem();
            this.Print = new System.Windows.Forms.MenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.macAddrBox = new System.Windows.Forms.TextBox();
            this.btLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.cbFormatList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.varFieldPanel = new System.Windows.Forms.Panel();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.varFieldPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.Retrieve);
            this.mainMenu1.MenuItems.Add(this.Print);
            // 
            // Retrieve
            // 
            this.Retrieve.Text = "Retrieve";
            this.Retrieve.Click += new System.EventHandler(this.Retrieve_Click);
            // 
            // Print
            // 
            this.Print.Text = "Print";
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(-2, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(242, 29);
            this.statusLabel.Text = "Status : Disconnected";
            // 
            // macAddrBox
            // 
            this.macAddrBox.Location = new System.Drawing.Point(100, 37);
            this.macAddrBox.Name = "macAddrBox";
            this.macAddrBox.Size = new System.Drawing.Size(121, 21);
            this.macAddrBox.TabIndex = 1;
            // 
            // btLabel
            // 
            this.btLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btLabel.Location = new System.Drawing.Point(16, 37);
            this.btLabel.Name = "btLabel";
            this.btLabel.Size = new System.Drawing.Size(78, 19);
            this.btLabel.Text = "BT Address:";
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.DimGray;
            this.connectButton.Location = new System.Drawing.Point(43, 64);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(89, 20);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.Color.DimGray;
            this.disconnectButton.Location = new System.Drawing.Point(138, 64);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(81, 20);
            this.disconnectButton.TabIndex = 4;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // cbFormatList
            // 
            this.cbFormatList.Location = new System.Drawing.Point(97, 91);
            this.cbFormatList.Name = "cbFormatList";
            this.cbFormatList.Size = new System.Drawing.Size(122, 22);
            this.cbFormatList.TabIndex = 5;
            this.cbFormatList.SelectedIndexChanged += new System.EventHandler(this.cbFormatList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.Text = "Formats:";
            // 
            // varFieldPanel
            // 
            this.varFieldPanel.BackColor = System.Drawing.Color.DarkGray;
            this.varFieldPanel.Controls.Add(this.quantity);
            this.varFieldPanel.Controls.Add(this.quantityLabel);
            this.varFieldPanel.Location = new System.Drawing.Point(3, 116);
            this.varFieldPanel.Name = "varFieldPanel";
            this.varFieldPanel.Size = new System.Drawing.Size(234, 149);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(83, 14);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(100, 22);
            this.quantity.TabIndex = 2;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quantityLabel
            // 
            this.quantityLabel.Location = new System.Drawing.Point(13, 16);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(64, 20);
            this.quantityLabel.Text = "Quantity:";
            // 
            // ListFormatMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.varFieldPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFormatList);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.btLabel);
            this.Controls.Add(this.macAddrBox);
            this.Controls.Add(this.statusLabel);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "ListFormatMain";
            this.Text = "ListFormat Demo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ListFormatMain_Closing);
            this.varFieldPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox macAddrBox;
        private System.Windows.Forms.Label btLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ComboBox cbFormatList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuItem Retrieve;
        private System.Windows.Forms.MenuItem Print;
        private System.Windows.Forms.Panel varFieldPanel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.NumericUpDown quantity;
    }
}

