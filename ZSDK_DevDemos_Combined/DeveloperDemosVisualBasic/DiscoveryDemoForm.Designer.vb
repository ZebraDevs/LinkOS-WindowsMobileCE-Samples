' ********************************************** 
' * CONFIDENTIAL AND PROPRIETARY 
' *
' * The source code and other information contained herein is the confidential and the exclusive property of
' * ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
' * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
' * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
' * expressly permitted under such license agreement.
' * 
' * Copyright ZIH Corp. 2010
' *
' * ALL RIGHTS RESERVED 
' *********************************************** 

Namespace ZebraDeveloperDemos
    Partial Class DiscoveryDemoForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.topScreenPanel = New System.Windows.Forms.Panel()
            Me.userLayoutPanel = New System.Windows.Forms.Panel()
            Me.multicastPanel = New System.Windows.Forms.Panel()
            Me.multicastHopUpDown = New System.Windows.Forms.NumericUpDown()
            Me.multicastHopsLabel = New System.Windows.Forms.Label()
            Me.directBroadcastPanel = New System.Windows.Forms.Panel()
            Me.directBroadcastTextBox = New System.Windows.Forms.TextBox()
            Me.directLabel = New System.Windows.Forms.Label()
            Me.subnetPanel = New System.Windows.Forms.Panel()
            Me.subnetTextBox = New System.Windows.Forms.TextBox()
            Me.subnetLabel = New System.Windows.Forms.Label()
            Me.discoveredPrintersLabel = New System.Windows.Forms.Label()
            Me.methodLabel = New System.Windows.Forms.Label()
            Me.discoveryMethodsComboBox = New System.Windows.Forms.ComboBox()
            Me.statusBar = New System.Windows.Forms.Label()
            Me.discoveryButton = New System.Windows.Forms.MenuItem()
            Me.mainMenu = New System.Windows.Forms.MainMenu()
            Me.printerListPanel = New System.Windows.Forms.Panel()
            Me.discoveredPrintersListBox = New System.Windows.Forms.ListBox()
            Me.topScreenPanel.SuspendLayout()
            Me.userLayoutPanel.SuspendLayout()
            Me.multicastPanel.SuspendLayout()
            Me.directBroadcastPanel.SuspendLayout()
            Me.subnetPanel.SuspendLayout()
            Me.printerListPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' topScreenPanel
            ' 
            Me.topScreenPanel.BackColor = System.Drawing.Color.DarkGray
            Me.topScreenPanel.Controls.Add(Me.userLayoutPanel)
            Me.topScreenPanel.Controls.Add(Me.statusBar)
            Me.topScreenPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.topScreenPanel.Location = New System.Drawing.Point(0, 0)
            Me.topScreenPanel.Name = "topScreenPanel"
            Me.topScreenPanel.Size = New System.Drawing.Size(240, 111)
            ' 
            ' userLayoutPanel
            ' 
            Me.userLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.userLayoutPanel.BackColor = System.Drawing.Color.DarkGray
            Me.userLayoutPanel.Controls.Add(Me.multicastPanel)
            Me.userLayoutPanel.Controls.Add(Me.directBroadcastPanel)
            Me.userLayoutPanel.Controls.Add(Me.subnetPanel)
            Me.userLayoutPanel.Controls.Add(Me.discoveredPrintersLabel)
            Me.userLayoutPanel.Controls.Add(Me.methodLabel)
            Me.userLayoutPanel.Controls.Add(Me.discoveryMethodsComboBox)
            Me.userLayoutPanel.Location = New System.Drawing.Point(6, 23)
            Me.userLayoutPanel.Name = "userLayoutPanel"
            Me.userLayoutPanel.Size = New System.Drawing.Size(228, 88)
            ' 
            ' multicastPanel
            ' 
            Me.multicastPanel.BackColor = System.Drawing.Color.DarkGray
            Me.multicastPanel.Controls.Add(Me.multicastHopUpDown)
            Me.multicastPanel.Controls.Add(Me.multicastHopsLabel)
            Me.multicastPanel.Location = New System.Drawing.Point(20, 31)
            Me.multicastPanel.Name = "multicastPanel"
            Me.multicastPanel.Size = New System.Drawing.Size(194, 32)
            ' 
            ' multicastHopUpDown
            ' 
            Me.multicastHopUpDown.Location = New System.Drawing.Point(98, 2)
            Me.multicastHopUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.multicastHopUpDown.Name = "multicastHopUpDown"
            Me.multicastHopUpDown.Size = New System.Drawing.Size(53, 22)
            Me.multicastHopUpDown.TabIndex = 6
            Me.multicastHopUpDown.Value = New Decimal(New Integer() {5, 0, 0, 0})
            ' 
            ' multicastHopsLabel
            ' 
            Me.multicastHopsLabel.Location = New System.Drawing.Point(3, 3)
            Me.multicastHopsLabel.Name = "multicastHopsLabel"
            Me.multicastHopsLabel.Size = New System.Drawing.Size(89, 20)
            Me.multicastHopsLabel.Text = "Multicast Hops:"
            ' 
            ' directBroadcastPanel
            ' 
            Me.directBroadcastPanel.BackColor = System.Drawing.Color.DarkGray
            Me.directBroadcastPanel.Controls.Add(Me.directBroadcastTextBox)
            Me.directBroadcastPanel.Controls.Add(Me.directLabel)
            Me.directBroadcastPanel.Location = New System.Drawing.Point(20, 30)
            Me.directBroadcastPanel.Name = "directBroadcastPanel"
            Me.directBroadcastPanel.Size = New System.Drawing.Size(177, 33)
            Me.directBroadcastPanel.Visible = False
            ' 
            ' directBroadcastTextBox
            ' 
            Me.directBroadcastTextBox.Location = New System.Drawing.Point(55, 3)
            Me.directBroadcastTextBox.Name = "directBroadcastTextBox"
            Me.directBroadcastTextBox.Size = New System.Drawing.Size(111, 21)
            Me.directBroadcastTextBox.TabIndex = 8
            Me.directBroadcastTextBox.Text = ".255"
            ' 
            ' directLabel
            ' 
            Me.directLabel.Location = New System.Drawing.Point(3, 3)
            Me.directLabel.Name = "directLabel"
            Me.directLabel.Size = New System.Drawing.Size(46, 20)
            Me.directLabel.Text = "Range: "
            ' 
            ' subnetPanel
            ' 
            Me.subnetPanel.BackColor = System.Drawing.Color.DarkGray
            Me.subnetPanel.Controls.Add(Me.subnetTextBox)
            Me.subnetPanel.Controls.Add(Me.subnetLabel)
            Me.subnetPanel.Location = New System.Drawing.Point(20, 31)
            Me.subnetPanel.Name = "subnetPanel"
            Me.subnetPanel.Size = New System.Drawing.Size(173, 32)
            Me.subnetPanel.Visible = False
            ' 
            ' subnetTextBox
            ' 
            Me.subnetTextBox.Location = New System.Drawing.Point(55, 0)
            Me.subnetTextBox.Name = "subnetTextBox"
            Me.subnetTextBox.Size = New System.Drawing.Size(111, 21)
            Me.subnetTextBox.TabIndex = 8
            Me.subnetTextBox.Text = ".*"
            ' 
            ' subnetLabel
            ' 
            Me.subnetLabel.Location = New System.Drawing.Point(3, 3)
            Me.subnetLabel.Name = "subnetLabel"
            Me.subnetLabel.Size = New System.Drawing.Size(46, 20)
            Me.subnetLabel.Text = "Subnet:"
            ' 
            ' discoveredPrintersLabel
            ' 
            Me.discoveredPrintersLabel.Location = New System.Drawing.Point(38, 66)
            Me.discoveredPrintersLabel.Name = "discoveredPrintersLabel"
            Me.discoveredPrintersLabel.Size = New System.Drawing.Size(155, 14)
            Me.discoveredPrintersLabel.Text = "Discovered Printers"
            Me.discoveredPrintersLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' methodLabel
            ' 
            Me.methodLabel.Location = New System.Drawing.Point(12, 8)
            Me.methodLabel.Name = "methodLabel"
            Me.methodLabel.Size = New System.Drawing.Size(54, 20)
            Me.methodLabel.Text = "Method:"
            ' 
            ' discoveryMethodsComboBox
            ' 
            Me.discoveryMethodsComboBox.Items.Add("Multicast")
            Me.discoveryMethodsComboBox.Items.Add("Directed Broadcast")
            Me.discoveryMethodsComboBox.Items.Add("Local Broadcast")
            Me.discoveryMethodsComboBox.Items.Add("Subnet Search")
            Me.discoveryMethodsComboBox.Items.Add("Bluetooth(R)")
            Me.discoveryMethodsComboBox.Location = New System.Drawing.Point(88, 8)
            Me.discoveryMethodsComboBox.Name = "discoveryMethodsComboBox"
            Me.discoveryMethodsComboBox.Size = New System.Drawing.Size(129, 22)
            Me.discoveryMethodsComboBox.TabIndex = 6
            AddHandler Me.discoveryMethodsComboBox.SelectedIndexChanged, New System.EventHandler(AddressOf Me.discoveryMethodsComboBox_SelectedIndexChanged)
            ' 
            ' statusBar
            ' 
            Me.statusBar.BackColor = System.Drawing.Color.Red
            Me.statusBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.statusBar.Location = New System.Drawing.Point(0, 0)
            Me.statusBar.Name = "statusBar"
            Me.statusBar.Size = New System.Drawing.Size(240, 20)
            Me.statusBar.Text = "Status: Not Connected"
            Me.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' discoveryButton
            ' 
            Me.discoveryButton.Text = "Discover"
            AddHandler Me.discoveryButton.Click, New System.EventHandler(AddressOf Me.discoverButtonClicked)
            ' 
            ' mainMenu
            ' 
            Me.mainMenu.MenuItems.Add(Me.discoveryButton)
            ' 
            ' printerListPanel
            ' 
            Me.printerListPanel.BackColor = System.Drawing.Color.DarkGray
            Me.printerListPanel.Controls.Add(Me.discoveredPrintersListBox)
            Me.printerListPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.printerListPanel.Location = New System.Drawing.Point(0, 111)
            Me.printerListPanel.Name = "printerListPanel"
            Me.printerListPanel.Size = New System.Drawing.Size(240, 157)
            ' 
            ' discoveredPrintersListBox
            ' 
            Me.discoveredPrintersListBox.BackColor = System.Drawing.Color.LightGray
            Me.discoveredPrintersListBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.discoveredPrintersListBox.Location = New System.Drawing.Point(0, 0)
            Me.discoveredPrintersListBox.Name = "discoveredPrintersListBox"
            Me.discoveredPrintersListBox.Size = New System.Drawing.Size(240, 156)
            Me.discoveredPrintersListBox.TabIndex = 8
            ' 
            ' DiscoveryDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.printerListPanel)
            Me.Controls.Add(Me.topScreenPanel)
            Me.Menu = Me.mainMenu
            Me.Name = "DiscoveryDemoForm"
            Me.Text = "Discovery Demo"
            Me.topScreenPanel.ResumeLayout(False)
            Me.userLayoutPanel.ResumeLayout(False)
            Me.multicastPanel.ResumeLayout(False)
            Me.directBroadcastPanel.ResumeLayout(False)
            Me.subnetPanel.ResumeLayout(False)
            Me.printerListPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private topScreenPanel As System.Windows.Forms.Panel
        Private discoveryButton As System.Windows.Forms.MenuItem
        Private mainMenu As System.Windows.Forms.MainMenu
        Private statusBar As System.Windows.Forms.Label
        Private printerListPanel As System.Windows.Forms.Panel
        Private discoveredPrintersListBox As System.Windows.Forms.ListBox
        Private userLayoutPanel As System.Windows.Forms.Panel
        Private multicastPanel As System.Windows.Forms.Panel
        Private multicastHopUpDown As System.Windows.Forms.NumericUpDown
        Private multicastHopsLabel As System.Windows.Forms.Label
        Private directBroadcastPanel As System.Windows.Forms.Panel
        Private directBroadcastTextBox As System.Windows.Forms.TextBox
        Private directLabel As System.Windows.Forms.Label
        Private subnetPanel As System.Windows.Forms.Panel
        Private subnetTextBox As System.Windows.Forms.TextBox
        Private subnetLabel As System.Windows.Forms.Label
        Private discoveredPrintersLabel As System.Windows.Forms.Label
        Private methodLabel As System.Windows.Forms.Label
        Private discoveryMethodsComboBox As System.Windows.Forms.ComboBox

    End Class
End Namespace
