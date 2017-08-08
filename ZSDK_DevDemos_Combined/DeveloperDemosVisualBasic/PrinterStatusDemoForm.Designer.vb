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
    Partial Class PrinterStatusDemoForm
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
            Me.statusPanel = New System.Windows.Forms.Panel()
            Me.statusMessages = New System.Windows.Forms.TextBox()
            Me.statusMsgsLabel = New System.Windows.Forms.Label()
            Me.mainMenu1 = New System.Windows.Forms.MainMenu()
            Me.leftSideButton = New System.Windows.Forms.MenuItem()
            Me.onScreenKeypad = New Microsoft.WindowsCE.Forms.InputPanel(Me.components)
            Me.connectionPanel = New ConnectionPanel()
            Me.statusPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' statusPanel
            ' 
            Me.statusPanel.BackColor = System.Drawing.Color.DarkGray
            Me.statusPanel.Controls.Add(Me.statusMsgsLabel)
            Me.statusPanel.Controls.Add(Me.statusMessages)
            Me.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.statusPanel.Location = New System.Drawing.Point(0, 0)
            Me.statusPanel.Name = "statusPanel"
            Me.statusPanel.Size = New System.Drawing.Size(240, 268)
            ' 
            ' statusMessages
            ' 
            Me.statusMessages.BackColor = System.Drawing.Color.DarkGray
            Me.statusMessages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.statusMessages.Font = New System.Drawing.Font("Tahoma", 9.0F, System.Drawing.FontStyle.Bold)
            Me.statusMessages.ForeColor = System.Drawing.Color.Crimson
            Me.statusMessages.Location = New System.Drawing.Point(29, 31)
            Me.statusMessages.Multiline = True
            Me.statusMessages.Name = "statusMessages"
            Me.statusMessages.[ReadOnly] = True
            Me.statusMessages.Size = New System.Drawing.Size(182, 139)
            Me.statusMessages.TabIndex = 22
            ' 
            ' statusMsgsLabel
            ' 
            Me.statusMsgsLabel.Location = New System.Drawing.Point(72, 8)
            Me.statusMsgsLabel.Name = "statusMsgsLabel"
            Me.statusMsgsLabel.Size = New System.Drawing.Size(100, 20)
            Me.statusMsgsLabel.Text = "Status Messages"
            Me.statusMsgsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' mainMenu1
            ' 
            Me.mainMenu1.MenuItems.Add(Me.leftSideButton)
            ' 
            ' leftSideButton
            ' 
            Me.leftSideButton.Text = "Connect"
            AddHandler Me.leftSideButton.Click, New System.EventHandler(AddressOf Me.leftSideButton_Click)
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
            ' PrinterStatusDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.statusPanel)
            Me.Controls.Add(Me.connectionPanel)
            Me.Menu = Me.mainMenu1
            Me.Name = "PrinterStatusDemoForm"
            Me.Text = "Printer Status Demo"
            AddHandler Me.Closed, New System.EventHandler(AddressOf Me.PrinterStatusDemoForm_Closed)
            Me.statusPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private leftSideButton As System.Windows.Forms.MenuItem
        Private onScreenKeypad As Microsoft.WindowsCE.Forms.InputPanel
        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private connectionPanel As ConnectionPanel
        Private statusMessages As System.Windows.Forms.TextBox
        Private statusMsgsLabel As System.Windows.Forms.Label
        Private statusPanel As System.Windows.Forms.Panel
    End Class
End Namespace
