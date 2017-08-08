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
    Partial Class SendFileDemoForm
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
            Me.onScreenKeypad = New Microsoft.WindowsCE.Forms.InputPanel(Me.components)
            Me.connectButton = New System.Windows.Forms.MenuItem()
            Me.mainMenu1 = New System.Windows.Forms.MainMenu()
            Me.connectionPanel = New ConnectionPanel()
            Me.SuspendLayout()
            ' 
            ' connectButton
            ' 
            Me.connectButton.Text = "Connect"
            AddHandler Me.connectButton.Click, New System.EventHandler(AddressOf Me.connectButton_Click)
            ' 
            ' mainMenu1
            ' 
            Me.mainMenu1.MenuItems.Add(Me.connectButton)
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
            ' SendFileDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.connectionPanel)
            Me.Menu = Me.mainMenu1
            Me.Name = "SendFileDemoForm"
            Me.Text = "Send File Demo"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private onScreenKeypad As Microsoft.WindowsCE.Forms.InputPanel
        Private connectButton As System.Windows.Forms.MenuItem
        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private connectionPanel As ConnectionPanel

    End Class
End Namespace
