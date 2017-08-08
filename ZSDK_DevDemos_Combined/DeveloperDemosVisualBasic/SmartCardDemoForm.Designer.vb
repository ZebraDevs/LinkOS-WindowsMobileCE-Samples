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
    Partial Class SmartCardDemoForm
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
            Me.components = New System.ComponentModel.Container()
            Me.connectionPanel = New ConnectionPanel()
            Me.mainMenu = New System.Windows.Forms.MainMenu()
            Me.sendCtAtrButton = New System.Windows.Forms.MenuItem()
            Me.sendCtDataButton = New System.Windows.Forms.MenuItem()
            Me.responsePanel = New System.Windows.Forms.Panel()
            Me.responseLabel = New System.Windows.Forms.Label()
            Me.responseTextBox = New System.Windows.Forms.TextBox()
            Me.onScreenKeypad = New Microsoft.WindowsCE.Forms.InputPanel(Me.components)
            Me.responsePanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' connectionPanel
            ' 
            Me.connectionPanel.BackColor = System.Drawing.Color.DarkGray
            Me.connectionPanel.BluetoothMacAddress = ""
            Me.connectionPanel.ConnectionType = "IP/DNS"
            Me.connectionPanel.Dock = System.Windows.Forms.DockStyle.Top
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
            Me.connectionPanel.Size = New System.Drawing.Size(240, 147)
            Me.connectionPanel.TabIndex = 0
            ' 
            ' mainMenu
            ' 
            Me.mainMenu.MenuItems.Add(Me.sendCtAtrButton)
            Me.mainMenu.MenuItems.Add(Me.sendCtDataButton)
            ' 
            ' sendCtAtrButton
            ' 
            Me.sendCtAtrButton.Text = "Send ATR"
            AddHandler Me.sendCtAtrButton.Click, New System.EventHandler(AddressOf Me.sendCtAtrButtonPressed)
            ' 
            ' sendCtDataButton
            ' 
            Me.sendCtDataButton.Text = "Send DATA"
            AddHandler Me.sendCtDataButton.Click, New System.EventHandler(AddressOf Me.sendCtDataButtonPressed)
            ' 
            ' responsePanel
            ' 
            Me.responsePanel.BackColor = System.Drawing.Color.DarkGray
            Me.responsePanel.Controls.Add(Me.responseLabel)
            Me.responsePanel.Controls.Add(Me.responseTextBox)
            Me.responsePanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.responsePanel.Location = New System.Drawing.Point(0, 147)
            Me.responsePanel.Name = "responsePanel"
            Me.responsePanel.Size = New System.Drawing.Size(240, 100)
            ' 
            ' responseLabel
            ' 
            Me.responseLabel.Location = New System.Drawing.Point(20, 7)
            Me.responseLabel.Name = "responseLabel"
            Me.responseLabel.Size = New System.Drawing.Size(193, 20)
            Me.responseLabel.Text = "Response from Printer"
            ' 
            ' responseTextBox
            ' 
            Me.responseTextBox.Location = New System.Drawing.Point(20, 30)
            Me.responseTextBox.Multiline = True
            Me.responseTextBox.Name = "responseTextBox"
            Me.responseTextBox.[ReadOnly] = True
            Me.responseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.responseTextBox.Size = New System.Drawing.Size(193, 67)
            Me.responseTextBox.TabIndex = 0
            ' 
            ' SmartCardDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.responsePanel)
            Me.Controls.Add(Me.connectionPanel)
            Me.KeyPreview = True
            Me.Menu = Me.mainMenu
            Me.Name = "SmartCardDemoForm"
            Me.Text = "Smart Card Demo"
            AddHandler Me.Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.SmartCardDemoForm_Closing)
            Me.responsePanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private connectionPanel As ConnectionPanel
        Private mainMenu As System.Windows.Forms.MainMenu
        Private sendCtAtrButton As System.Windows.Forms.MenuItem
        Private sendCtDataButton As System.Windows.Forms.MenuItem
        Private responsePanel As System.Windows.Forms.Panel
        Private responseLabel As System.Windows.Forms.Label
        Private responseTextBox As System.Windows.Forms.TextBox
        Private onScreenKeypad As Microsoft.WindowsCE.Forms.InputPanel
    End Class
End Namespace
