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
    Partial Class ListFormatsDemoForm
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
            Me.optionsMenu = New System.Windows.Forms.MenuItem()
            Me.listFilesButton = New System.Windows.Forms.MenuItem()
            Me.listFormatsButton = New System.Windows.Forms.MenuItem()
            Me.onScreenKeypad = New Microsoft.WindowsCE.Forms.InputPanel(Me.components)
            Me.fileListPanel = New System.Windows.Forms.Panel()
            Me.filesOnPrinterListBox = New System.Windows.Forms.TextBox()
            Me.fileNamesLabel = New System.Windows.Forms.Label()
            Me.connectionPanel = New ConnectionPanel()
            Me.fileListPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mainMenu1
            ' 
            Me.mainMenu1.MenuItems.Add(Me.connectButton)
            Me.mainMenu1.MenuItems.Add(Me.optionsMenu)
            ' 
            ' connectButton
            ' 
            Me.connectButton.Text = "Connect"
            AddHandler Me.connectButton.Click, New System.EventHandler(AddressOf Me.connectDisconnectButtonPressed)
            ' 
            ' optionsMenu
            ' 
            Me.optionsMenu.Enabled = False
            Me.optionsMenu.MenuItems.Add(Me.listFilesButton)
            Me.optionsMenu.MenuItems.Add(Me.listFormatsButton)
            Me.optionsMenu.Text = "Retrieve"
            ' 
            ' listFilesButton
            ' 
            Me.listFilesButton.Text = "Files"
            AddHandler Me.listFilesButton.Click, New System.EventHandler(AddressOf Me.listFilesButton_Click)
            ' 
            ' listFormatsButton
            ' 
            Me.listFormatsButton.Text = "Formats"
            AddHandler Me.listFormatsButton.Click, New System.EventHandler(AddressOf Me.listFormatsButton_Click)
            ' 
            ' fileListPanel
            ' 
            Me.fileListPanel.BackColor = System.Drawing.Color.DarkGray
            Me.fileListPanel.Controls.Add(Me.filesOnPrinterListBox)
            Me.fileListPanel.Controls.Add(Me.fileNamesLabel)
            Me.fileListPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.fileListPanel.Location = New System.Drawing.Point(0, 0)
            Me.fileListPanel.Name = "fileListPanel"
            Me.fileListPanel.Size = New System.Drawing.Size(240, 268)
            ' 
            ' filesOnPrinterListBox
            ' 
            Me.filesOnPrinterListBox.BackColor = System.Drawing.Color.LightGray
            Me.filesOnPrinterListBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.filesOnPrinterListBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.filesOnPrinterListBox.Font = New System.Drawing.Font("Tahoma", 9.0F, System.Drawing.FontStyle.Bold)
            Me.filesOnPrinterListBox.ForeColor = System.Drawing.Color.OrangeRed
            Me.filesOnPrinterListBox.Location = New System.Drawing.Point(0, 20)
            Me.filesOnPrinterListBox.Multiline = True
            Me.filesOnPrinterListBox.Name = "filesOnPrinterListBox"
            Me.filesOnPrinterListBox.[ReadOnly] = True
            Me.filesOnPrinterListBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.filesOnPrinterListBox.Size = New System.Drawing.Size(240, 248)
            Me.filesOnPrinterListBox.TabIndex = 22
            ' 
            ' fileNamesLabel
            ' 
            Me.fileNamesLabel.Dock = System.Windows.Forms.DockStyle.Top
            Me.fileNamesLabel.Location = New System.Drawing.Point(0, 0)
            Me.fileNamesLabel.Name = "fileNamesLabel"
            Me.fileNamesLabel.Size = New System.Drawing.Size(240, 20)
            Me.fileNamesLabel.Text = "Files on Printer"
            Me.fileNamesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
            Me.connectionPanel.TabIndex = 1
            ' 
            ' ListFormatsDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.connectionPanel)
            Me.Controls.Add(Me.fileListPanel)
            Me.KeyPreview = True
            Me.Menu = Me.mainMenu1
            Me.Name = "ListFormatsDemoForm"
            Me.Text = "List Formats Demo"
            AddHandler Me.Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.ListFormatsDemoForm_Closing)
            Me.fileListPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private connectButton As System.Windows.Forms.MenuItem
        Private onScreenKeypad As Microsoft.WindowsCE.Forms.InputPanel
        Private optionsMenu As System.Windows.Forms.MenuItem
        Private listFilesButton As System.Windows.Forms.MenuItem
        Private listFormatsButton As System.Windows.Forms.MenuItem
        Private fileListPanel As System.Windows.Forms.Panel
        Private filesOnPrinterListBox As System.Windows.Forms.TextBox
        Private fileNamesLabel As System.Windows.Forms.Label
        Private connectionPanel As ConnectionPanel

    End Class
End Namespace
