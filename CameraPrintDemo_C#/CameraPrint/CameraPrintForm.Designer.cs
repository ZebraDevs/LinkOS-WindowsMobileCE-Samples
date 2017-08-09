namespace CameraPrint
{
    partial class CameraPrintForm
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
            this.CameraPrintButton = new System.Windows.Forms.Button();
            this.macAddrBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CameraPrintButton
            // 
            this.CameraPrintButton.BackColor = System.Drawing.Color.DimGray;
            this.CameraPrintButton.Location = new System.Drawing.Point(29, 220);
            this.CameraPrintButton.Name = "CameraPrintButton";
            this.CameraPrintButton.Size = new System.Drawing.Size(177, 45);
            this.CameraPrintButton.TabIndex = 0;
            this.CameraPrintButton.Text = "Camera Print";
            this.CameraPrintButton.Click += new System.EventHandler(this.CameraPrintButton_Click);
            // 
            // macAddrBox
            // 
            this.macAddrBox.Location = new System.Drawing.Point(9, 73);
            this.macAddrBox.Name = "macAddrBox";
            this.macAddrBox.Size = new System.Drawing.Size(223, 21);
            this.macAddrBox.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.BackColor = System.Drawing.Color.DimGray;
            this.connectButton.Location = new System.Drawing.Point(9, 114);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(91, 20);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.BackColor = System.Drawing.Color.DimGray;
            this.disconnectButton.Location = new System.Drawing.Point(145, 114);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(87, 20);
            this.disconnectButton.TabIndex = 3;
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.Text = "Enter MAC Address to connect Printer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(0, 2);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(240, 31);
            this.statusLabel.Text = "Status: Disconnected";
            // 
            // CameraPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.macAddrBox);
            this.Controls.Add(this.CameraPrintButton);
            this.Menu = this.mainMenu1;
            this.Name = "CameraPrintForm";
            this.Text = "CameraPrint";
            this.Load += new System.EventHandler(this.CameraPrintForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CameraPrintButton;
        private System.Windows.Forms.TextBox macAddrBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusLabel;
    }
}

