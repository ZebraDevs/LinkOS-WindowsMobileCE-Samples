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
    Partial Class SignatureCaptureDemoForm
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
            Me.connectButton = New System.Windows.Forms.MenuItem()
            Me.printButton = New System.Windows.Forms.MenuItem()
            Me.inputPanel = New Microsoft.WindowsCE.Forms.InputPanel(Me.components)
            Me.signatureBox = New System.Windows.Forms.PictureBox()
            Me.signatureLabel = New System.Windows.Forms.Label()
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
            Me.connectionPanel.Size = New System.Drawing.Size(240, 149)
            Me.connectionPanel.TabIndex = 0
            ' 
            ' mainMenu
            ' 
            Me.mainMenu.MenuItems.Add(Me.connectButton)
            Me.mainMenu.MenuItems.Add(Me.printButton)
            ' 
            ' connectButton
            ' 
            Me.connectButton.Text = "Connect"
            AddHandler Me.connectButton.Click, New System.EventHandler(AddressOf Me.connectButton_Click)
            ' 
            ' printButton
            ' 
            Me.printButton.Enabled = False
            Me.printButton.Text = "Print"
            AddHandler Me.printButton.Click, New System.EventHandler(AddressOf Me.printButton_Click)
            ' 
            ' signatureBox
            ' 
            Me.signatureBox.BackColor = System.Drawing.Color.White
            Me.signatureBox.Location = New System.Drawing.Point(0, 172)
            Me.signatureBox.Name = "signatureBox"
            Me.signatureBox.Size = New System.Drawing.Size(240, 96)
            AddHandler Me.signatureBox.MouseMove, New System.Windows.Forms.MouseEventHandler(AddressOf Me.signatureBox_MouseMove)
            AddHandler Me.signatureBox.MouseDown, New System.Windows.Forms.MouseEventHandler(AddressOf Me.signatureBox_MouseDown)
            AddHandler Me.signatureBox.MouseUp, New System.Windows.Forms.MouseEventHandler(AddressOf Me.signatureBox_MouseUp)
            ' 
            ' signatureLabel
            ' 
            Me.signatureLabel.Dock = System.Windows.Forms.DockStyle.Top
            Me.signatureLabel.Location = New System.Drawing.Point(0, 149)
            Me.signatureLabel.Name = "signatureLabel"
            Me.signatureLabel.Size = New System.Drawing.Size(240, 20)
            Me.signatureLabel.Text = "Sign Name:"
            ' 
            ' SignatureCaptureDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.signatureLabel)
            Me.Controls.Add(Me.signatureBox)
            Me.Controls.Add(Me.connectionPanel)
            Me.Menu = Me.mainMenu
            Me.Name = "SignatureCaptureDemoForm"
            Me.Text = "Signature Demo"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private connectionPanel As ConnectionPanel
        Private mainMenu As System.Windows.Forms.MainMenu
        Private inputPanel As Microsoft.WindowsCE.Forms.InputPanel
        Private connectButton As System.Windows.Forms.MenuItem
        Private printButton As System.Windows.Forms.MenuItem
        Private signatureBox As System.Windows.Forms.PictureBox
        Private signatureLabel As System.Windows.Forms.Label
    End Class
End Namespace
