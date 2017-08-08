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
    Partial Class ImagePrintDemoForm
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
            Me.mainMenu = New System.Windows.Forms.MainMenu()
            Me.connectMenu = New System.Windows.Forms.MenuItem()
            Me.getImageMenu = New System.Windows.Forms.MenuItem()
            Me.fileExplorerButton = New System.Windows.Forms.MenuItem()
            Me.cameraButton = New System.Windows.Forms.MenuItem()
            Me.screenPanel = New System.Windows.Forms.Panel()
            Me.connectionPanel = New ConnectionPanel()
            Me.fileNameOnPrinterLabel = New System.Windows.Forms.Label()
            Me.fileNameOnPrinterText = New System.Windows.Forms.TextBox()
            Me.storeImageOnPrinter = New System.Windows.Forms.CheckBox()
            Me.onScreenKeypad = New Microsoft.WindowsCE.Forms.InputPanel(Me.components)
            Me.screenPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mainMenu
            ' 
            Me.mainMenu.MenuItems.Add(Me.connectMenu)
            Me.mainMenu.MenuItems.Add(Me.getImageMenu)
            ' 
            ' connectMenu
            ' 
            Me.connectMenu.Text = "Connect"
            AddHandler Me.connectMenu.Click, New System.EventHandler(AddressOf Me.connectMenu_Click)
            ' 
            ' getImageMenu
            ' 
            Me.getImageMenu.Enabled = False
            Me.getImageMenu.MenuItems.Add(Me.fileExplorerButton)
            Me.getImageMenu.MenuItems.Add(Me.cameraButton)
            Me.getImageMenu.Text = "Get Image"
            ' 
            ' fileExplorerButton
            ' 
            Me.fileExplorerButton.Text = "From File"
            AddHandler Me.fileExplorerButton.Click, New System.EventHandler(AddressOf Me.fileExplorerButton_Click)
            ' 
            ' cameraButton
            ' 
            Me.cameraButton.Text = "From Camera"
            If (Microsoft.WindowsCE.Forms.SystemSettings.Platform = Microsoft.WindowsCE.Forms.WinCEPlatform.WinCEGeneric) Then
                AddHandler Me.cameraButton.Click, New System.EventHandler(AddressOf Me.cameraButton_Click_CE_Device)
            Else
                AddHandler Me.cameraButton.Click, New System.EventHandler(AddressOf Me.cameraButton_Click)
            End If

            ' 
            ' screenPanel
            ' 
            Me.screenPanel.AutoScroll = True
            Me.screenPanel.BackColor = System.Drawing.Color.DarkGray
            Me.screenPanel.Controls.Add(Me.connectionPanel)
            Me.screenPanel.Controls.Add(Me.fileNameOnPrinterLabel)
            Me.screenPanel.Controls.Add(Me.fileNameOnPrinterText)
            Me.screenPanel.Controls.Add(Me.storeImageOnPrinter)
            Me.screenPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.screenPanel.Location = New System.Drawing.Point(0, 0)
            Me.screenPanel.Name = "screenPanel"
            Me.screenPanel.Size = New System.Drawing.Size(240, 268)
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
            Me.connectionPanel.TabIndex = 1
            ' 
            ' fileNameOnPrinterLabel
            ' 
            Me.fileNameOnPrinterLabel.BackColor = System.Drawing.Color.DarkGray
            Me.fileNameOnPrinterLabel.Location = New System.Drawing.Point(3, 179)
            Me.fileNameOnPrinterLabel.Name = "fileNameOnPrinterLabel"
            Me.fileNameOnPrinterLabel.Size = New System.Drawing.Size(100, 20)
            Me.fileNameOnPrinterLabel.Text = "Path on Printer:"
            Me.fileNameOnPrinterLabel.Visible = False
            ' 
            ' fileNameOnPrinterText
            ' 
            Me.fileNameOnPrinterText.BackColor = System.Drawing.Color.White
            Me.fileNameOnPrinterText.Enabled = False
            Me.fileNameOnPrinterText.Location = New System.Drawing.Point(109, 179)
            Me.fileNameOnPrinterText.Name = "fileNameOnPrinterText"
            Me.fileNameOnPrinterText.Size = New System.Drawing.Size(115, 21)
            Me.fileNameOnPrinterText.TabIndex = 1
            Me.fileNameOnPrinterText.Visible = False
            ' 
            ' storeImageOnPrinter
            ' 
            Me.storeImageOnPrinter.BackColor = System.Drawing.Color.DarkGray
            Me.storeImageOnPrinter.Location = New System.Drawing.Point(3, 153)
            Me.storeImageOnPrinter.Name = "storeImageOnPrinter"
            Me.storeImageOnPrinter.Size = New System.Drawing.Size(100, 20)
            Me.storeImageOnPrinter.TabIndex = 0
            Me.storeImageOnPrinter.Text = "Store image"
            AddHandler Me.storeImageOnPrinter.CheckStateChanged, New System.EventHandler(AddressOf Me.storeImageOnPrinter_CheckStateChanged)
            ' 
            ' ImagePrintDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 268)
            Me.Controls.Add(Me.screenPanel)
            Me.Menu = Me.mainMenu
            Me.Name = "ImagePrintDemoForm"
            Me.Text = "Image Print Demo"
            AddHandler Me.Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.ImagePrintDemoForm_Closing)
            Me.screenPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private mainMenu As System.Windows.Forms.MainMenu
        Private connectMenu As System.Windows.Forms.MenuItem
        Private getImageMenu As System.Windows.Forms.MenuItem
        Private fileExplorerButton As System.Windows.Forms.MenuItem
        Private cameraButton As System.Windows.Forms.MenuItem
        Private onScreenKeypad As Microsoft.WindowsCE.Forms.InputPanel
        Private connectionPanel As ConnectionPanel
        Private screenPanel As System.Windows.Forms.Panel
        Private fileNameOnPrinterLabel As System.Windows.Forms.Label
        Private fileNameOnPrinterText As System.Windows.Forms.TextBox
        Private storeImageOnPrinter As System.Windows.Forms.CheckBox
    End Class
End Namespace
