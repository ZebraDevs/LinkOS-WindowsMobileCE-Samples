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
    Partial Class StoredFormatDemoForm
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
            Me.connectionPanel = New ConnectionPanel()
            Me.rightSideButton = New System.Windows.Forms.MenuItem()
            Me.leftSideButton = New System.Windows.Forms.MenuItem()
            Me.mainMenu = New System.Windows.Forms.MainMenu()
            Me.printJobSentPanel = New System.Windows.Forms.Panel()
            Me.printJobSentLabel = New System.Windows.Forms.Label()
            Me.exitButton = New System.Windows.Forms.Button()
            Me.backToListFormatsButton = New System.Windows.Forms.Button()
            Me.reEnterDataButton = New System.Windows.Forms.Button()
            Me.reprintButton = New System.Windows.Forms.Button()
            Me.varFieldPanel = New System.Windows.Forms.Panel()
            Me.titleLabel = New System.Windows.Forms.Label()
            Me.quantity = New System.Windows.Forms.NumericUpDown()
            Me.pleaseFillLabel = New System.Windows.Forms.Label()
            Me.quantityLabel = New System.Windows.Forms.Label()
            Me.formatListPanel = New System.Windows.Forms.Panel()
            Me.formatSelectButton = New System.Windows.Forms.Button()
            Me.formatListBox = New System.Windows.Forms.ListBox()
            Me.printJobSentPanel.SuspendLayout()
            Me.varFieldPanel.SuspendLayout()
            Me.formatListPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' connectionPanel
            ' 
            Me.connectionPanel.BackColor = System.Drawing.Color.DarkGray
            Me.connectionPanel.BluetoothMacAddress = ""
            Me.connectionPanel.ConnectionType = "IP/DNS"
            Me.connectionPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.connectionPanel.IPAddress = ""
            Me.connectionPanel.Location = New System.Drawing.Point(0, 0)
            Me.connectionPanel.Name = "connectionPanel"
            Me.connectionPanel.PortNum = 6101
            Me.connectionPanel.SerialBaudRate = 9600
            Me.connectionPanel.SerialComPortName = "COM1"
            Me.connectionPanel.SerialDataBits = 8
            Me.connectionPanel.SerialHandshake = System.IO.Ports.Handshake.None
            Me.connectionPanel.SerialParity = System.IO.Ports.Parity.None
            Me.connectionPanel.SerialStopBits = System.IO.Ports.StopBits.One
            Me.connectionPanel.Size = New System.Drawing.Size(240, 268)
            Me.connectionPanel.TabIndex = 0
            ' 
            ' rightSideButton
            ' 
            Me.rightSideButton.Text = "List Formats"
            AddHandler Me.rightSideButton.Click, New System.EventHandler(AddressOf Me.rightSideButtonPressed)
            ' 
            ' leftSideButton
            ' 
            Me.leftSideButton.Enabled = False
            Me.leftSideButton.Text = ""
            AddHandler Me.leftSideButton.Click, New System.EventHandler(AddressOf Me.leftSideButtonPressed)
            ' 
            ' mainMenu
            ' 
            Me.mainMenu.MenuItems.Add(Me.leftSideButton)
            Me.mainMenu.MenuItems.Add(Me.rightSideButton)
            ' 
            ' printJobSentPanel
            ' 
            Me.printJobSentPanel.AutoScroll = True
            Me.printJobSentPanel.BackColor = System.Drawing.Color.DarkGray
            Me.printJobSentPanel.Controls.Add(Me.printJobSentLabel)
            Me.printJobSentPanel.Controls.Add(Me.exitButton)
            Me.printJobSentPanel.Controls.Add(Me.backToListFormatsButton)
            Me.printJobSentPanel.Controls.Add(Me.reEnterDataButton)
            Me.printJobSentPanel.Controls.Add(Me.reprintButton)
            Me.printJobSentPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.printJobSentPanel.Location = New System.Drawing.Point(0, 0)
            Me.printJobSentPanel.Name = "printJobSentPanel"
            Me.printJobSentPanel.Size = New System.Drawing.Size(240, 268)
            ' 
            ' printJobSentLabel
            ' 
            Me.printJobSentLabel.Location = New System.Drawing.Point(80, 21)
            Me.printJobSentLabel.Name = "printJobSentLabel"
            Me.printJobSentLabel.Size = New System.Drawing.Size(80, 20)
            Me.printJobSentLabel.Text = "Print Job Sent"
            ' 
            ' exitButton
            ' 
            Me.exitButton.Location = New System.Drawing.Point(75, 167)
            Me.exitButton.Name = "exitButton"
            Me.exitButton.Size = New System.Drawing.Size(90, 20)
            Me.exitButton.TabIndex = 4
            Me.exitButton.Text = "Exit"
            AddHandler Me.exitButton.Click, New System.EventHandler(AddressOf Me.exitButton_Click)
            ' 
            ' backToListFormatsButton
            ' 
            Me.backToListFormatsButton.Location = New System.Drawing.Point(44, 129)
            Me.backToListFormatsButton.Name = "backToListFormatsButton"
            Me.backToListFormatsButton.Size = New System.Drawing.Size(153, 20)
            Me.backToListFormatsButton.TabIndex = 3
            Me.backToListFormatsButton.Text = "Back to Format List"
            AddHandler Me.backToListFormatsButton.Click, New System.EventHandler(AddressOf Me.backToListFormatsButton_Click)
            ' 
            ' reEnterDataButton
            ' 
            Me.reEnterDataButton.Location = New System.Drawing.Point(65, 92)
            Me.reEnterDataButton.Name = "reEnterDataButton"
            Me.reEnterDataButton.Size = New System.Drawing.Size(110, 20)
            Me.reEnterDataButton.TabIndex = 2
            Me.reEnterDataButton.Text = "Re-Enter Data"
            AddHandler Me.reEnterDataButton.Click, New System.EventHandler(AddressOf Me.reEnterDataButton_Click)
            ' 
            ' reprintButton
            ' 
            Me.reprintButton.Location = New System.Drawing.Point(65, 57)
            Me.reprintButton.Name = "reprintButton"
            Me.reprintButton.Size = New System.Drawing.Size(110, 20)
            Me.reprintButton.TabIndex = 0
            Me.reprintButton.Text = "Re-Print Label"
            AddHandler Me.reprintButton.Click, New System.EventHandler(AddressOf Me.reprintButton_Click)
            ' 
            ' varFieldPanel
            ' 
            Me.varFieldPanel.AutoScroll = True
            Me.varFieldPanel.BackColor = System.Drawing.Color.DarkGray
            Me.varFieldPanel.Controls.Add(Me.titleLabel)
            Me.varFieldPanel.Controls.Add(Me.quantity)
            Me.varFieldPanel.Controls.Add(Me.pleaseFillLabel)
            Me.varFieldPanel.Controls.Add(Me.quantityLabel)
            Me.varFieldPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.varFieldPanel.Location = New System.Drawing.Point(0, 0)
            Me.varFieldPanel.Name = "varFieldPanel"
            Me.varFieldPanel.Size = New System.Drawing.Size(240, 268)
            ' 
            ' titleLabel
            ' 
            Me.titleLabel.Location = New System.Drawing.Point(13, 1)
            Me.titleLabel.Name = "titleLabel"
            Me.titleLabel.Size = New System.Drawing.Size(191, 20)
            Me.titleLabel.Text = "Format: "
            ' 
            ' quantity
            ' 
            Me.quantity.Location = New System.Drawing.Point(84, 55)
            Me.quantity.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
            Me.quantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.quantity.Name = "quantity"
            Me.quantity.Size = New System.Drawing.Size(61, 22)
            Me.quantity.TabIndex = 5
            Me.quantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
            ' 
            ' pleaseFillLabel
            ' 
            Me.pleaseFillLabel.Location = New System.Drawing.Point(13, 21)
            Me.pleaseFillLabel.Name = "pleaseFillLabel"
            Me.pleaseFillLabel.Size = New System.Drawing.Size(150, 20)
            Me.pleaseFillLabel.Text = "Please fill in the variables:"
            ' 
            ' quantityLabel
            ' 
            Me.quantityLabel.Location = New System.Drawing.Point(13, 57)
            Me.quantityLabel.Name = "quantityLabel"
            Me.quantityLabel.Size = New System.Drawing.Size(64, 20)
            Me.quantityLabel.Text = "Quantity:"
            ' 
            ' formatListPanel
            ' 
            Me.formatListPanel.AutoScroll = True
            Me.formatListPanel.BackColor = System.Drawing.Color.DarkGray
            Me.formatListPanel.Controls.Add(Me.formatSelectButton)
            Me.formatListPanel.Controls.Add(Me.formatListBox)
            Me.formatListPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.formatListPanel.Location = New System.Drawing.Point(0, 0)
            Me.formatListPanel.Name = "formatListPanel"
            Me.formatListPanel.Size = New System.Drawing.Size(240, 268)
            ' 
            ' formatSelectButton
            ' 
            Me.formatSelectButton.Enabled = False
            Me.formatSelectButton.Location = New System.Drawing.Point(90, 210)
            Me.formatSelectButton.Name = "formatSelectButton"
            Me.formatSelectButton.Size = New System.Drawing.Size(60, 30)
            Me.formatSelectButton.TabIndex = 25
            Me.formatSelectButton.Text = "Next"
            AddHandler Me.formatSelectButton.Click, New System.EventHandler(AddressOf Me.formatSelectButton_Click)
            ' 
            ' formatListBox
            ' 
            Me.formatListBox.Location = New System.Drawing.Point(13, 24)
            Me.formatListBox.Name = "formatListBox"
            Me.formatListBox.Size = New System.Drawing.Size(210, 170)
            Me.formatListBox.TabIndex = 24
            ' 
            ' StoredFormatDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.varFieldPanel)
            Me.Controls.Add(Me.formatListPanel)
            Me.Controls.Add(Me.printJobSentPanel)
            Me.Controls.Add(Me.connectionPanel)
            Me.Menu = Me.mainMenu
            Me.Name = "StoredFormatDemoForm"
            Me.Text = "Stored Format Demo"
            AddHandler Me.Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.StoredFormatDemoForm_Closing)
            Me.printJobSentPanel.ResumeLayout(False)
            Me.varFieldPanel.ResumeLayout(False)
            Me.formatListPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private connectionPanel As ConnectionPanel
        Private rightSideButton As System.Windows.Forms.MenuItem
        Private leftSideButton As System.Windows.Forms.MenuItem
        Private mainMenu As System.Windows.Forms.MainMenu
        Private formatListPanel As System.Windows.Forms.Panel
        Private formatSelectButton As System.Windows.Forms.Button
        Private formatListBox As System.Windows.Forms.ListBox
        Private varFieldPanel As System.Windows.Forms.Panel
        Private titleLabel As System.Windows.Forms.Label
        Private quantity As System.Windows.Forms.NumericUpDown
        Private pleaseFillLabel As System.Windows.Forms.Label
        Private quantityLabel As System.Windows.Forms.Label
        Private printJobSentPanel As System.Windows.Forms.Panel
        Private exitButton As System.Windows.Forms.Button
        Private backToListFormatsButton As System.Windows.Forms.Button
        Private reEnterDataButton As System.Windows.Forms.Button
        Private reprintButton As System.Windows.Forms.Button
        Private printJobSentLabel As System.Windows.Forms.Label

    End Class
End Namespace
