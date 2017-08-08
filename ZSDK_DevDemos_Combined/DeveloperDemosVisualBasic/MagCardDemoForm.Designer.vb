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
    Partial Class MagCardDemoForm
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
            Me.mainMenu1 = New System.Windows.Forms.MainMenu()
            Me.connectButton = New System.Windows.Forms.MenuItem()
            Me.readMagCardButton = New System.Windows.Forms.MenuItem()
            Me.onScreenKeypad = New Microsoft.WindowsCE.Forms.InputPanel(Me.components)
            Me.magCardTrackPanel = New System.Windows.Forms.Panel()
            Me.track3Value = New System.Windows.Forms.TextBox()
            Me.track2Value = New System.Windows.Forms.TextBox()
            Me.track1Value = New System.Windows.Forms.TextBox()
            Me.track3Label = New System.Windows.Forms.Label()
            Me.track2Label = New System.Windows.Forms.Label()
            Me.track1Label = New System.Windows.Forms.Label()
            Me.connectionPanel = New ConnectionPanel()
            Me.magCardTrackPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mainMenu1
            ' 
            Me.mainMenu1.MenuItems.Add(Me.connectButton)
            Me.mainMenu1.MenuItems.Add(Me.readMagCardButton)
            ' 
            ' connectButton
            ' 
            Me.connectButton.Text = "Connect"
            AddHandler Me.connectButton.Click, New System.EventHandler(AddressOf Me.doConnect)
            ' 
            ' readMagCardButton
            ' 
            Me.readMagCardButton.Enabled = False
            Me.readMagCardButton.Text = "Read..."
            AddHandler Me.readMagCardButton.Click, New System.EventHandler(AddressOf Me.magCardButtonPressed)
            ' 
            ' magCardTrackPanel
            ' 
            Me.magCardTrackPanel.BackColor = System.Drawing.Color.DarkGray
            Me.magCardTrackPanel.Controls.Add(Me.track3Value)
            Me.magCardTrackPanel.Controls.Add(Me.track2Value)
            Me.magCardTrackPanel.Controls.Add(Me.track1Value)
            Me.magCardTrackPanel.Controls.Add(Me.track3Label)
            Me.magCardTrackPanel.Controls.Add(Me.track2Label)
            Me.magCardTrackPanel.Controls.Add(Me.track1Label)
            Me.magCardTrackPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.magCardTrackPanel.Location = New System.Drawing.Point(0, 145)
            Me.magCardTrackPanel.Name = "magCardTrackPanel"
            Me.magCardTrackPanel.Size = New System.Drawing.Size(240, 123)
            ' 
            ' track3Value
            ' 
            Me.track3Value.Location = New System.Drawing.Point(45, 65)
            Me.track3Value.Name = "track3Value"
            Me.track3Value.[ReadOnly] = True
            Me.track3Value.Size = New System.Drawing.Size(181, 21)
            Me.track3Value.TabIndex = 36
            ' 
            ' track2Value
            ' 
            Me.track2Value.Location = New System.Drawing.Point(46, 37)
            Me.track2Value.Name = "track2Value"
            Me.track2Value.[ReadOnly] = True
            Me.track2Value.Size = New System.Drawing.Size(181, 21)
            Me.track2Value.TabIndex = 35
            ' 
            ' track1Value
            ' 
            Me.track1Value.Location = New System.Drawing.Point(46, 9)
            Me.track1Value.Name = "track1Value"
            Me.track1Value.[ReadOnly] = True
            Me.track1Value.Size = New System.Drawing.Size(181, 21)
            Me.track1Value.TabIndex = 34
            ' 
            ' track3Label
            ' 
            Me.track3Label.Location = New System.Drawing.Point(9, 67)
            Me.track3Label.Name = "track3Label"
            Me.track3Label.Size = New System.Drawing.Size(30, 20)
            Me.track3Label.Text = "T3:"
            ' 
            ' track2Label
            ' 
            Me.track2Label.Location = New System.Drawing.Point(9, 40)
            Me.track2Label.Name = "track2Label"
            Me.track2Label.Size = New System.Drawing.Size(30, 20)
            Me.track2Label.Text = "T2:"
            ' 
            ' track1Label
            ' 
            Me.track1Label.Location = New System.Drawing.Point(9, 11)
            Me.track1Label.Name = "track1Label"
            Me.track1Label.Size = New System.Drawing.Size(30, 20)
            Me.track1Label.Text = "T1:"
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
            Me.connectionPanel.Size = New System.Drawing.Size(240, 145)
            Me.connectionPanel.TabIndex = 1
            ' 
            ' MagCardDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.magCardTrackPanel)
            Me.Controls.Add(Me.connectionPanel)
            Me.KeyPreview = True
            Me.Menu = Me.mainMenu1
            Me.Name = "MagCardDemoForm"
            Me.Text = "MagCard Demo"
            AddHandler Me.Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.MagCardDemoForm_Closing)
            Me.magCardTrackPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private onScreenKeypad As Microsoft.WindowsCE.Forms.InputPanel
        Private magCardTrackPanel As System.Windows.Forms.Panel
        Private connectButton As System.Windows.Forms.MenuItem
        Private readMagCardButton As System.Windows.Forms.MenuItem
        Private track3Label As System.Windows.Forms.Label
        Private track2Label As System.Windows.Forms.Label
        Private track1Label As System.Windows.Forms.Label
        Private track1Value As System.Windows.Forms.TextBox
        Private track2Value As System.Windows.Forms.TextBox
        Private track3Value As System.Windows.Forms.TextBox
        Private connectionPanel As ConnectionPanel

    End Class
End Namespace
