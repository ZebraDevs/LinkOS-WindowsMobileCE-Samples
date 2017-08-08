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
    Partial Class DeveloperDemoForm
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
            Me.connectivityDemoButton = New System.Windows.Forms.Button()
            Me.discoveryDemoButton = New System.Windows.Forms.Button()
            Me.listFormatsDemoButton = New System.Windows.Forms.Button()
            Me.sendFileDemoButton = New System.Windows.Forms.Button()
            Me.storedFormatDemoButton = New System.Windows.Forms.Button()
            Me.imagePrintDemoButton = New System.Windows.Forms.Button()
            Me.magCardDemoButton = New System.Windows.Forms.Button()
            Me.smartCardDemoButton = New System.Windows.Forms.Button()
            Me.printerStatusDemoButton = New System.Windows.Forms.Button()
            Me.signatureCaptureDemoButton = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            ' 
            ' connectivityDemoButton
            ' 
            Me.connectivityDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.connectivityDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.connectivityDemoButton.ForeColor = System.Drawing.Color.White
            Me.connectivityDemoButton.Location = New System.Drawing.Point(24, 7)
            Me.connectivityDemoButton.Name = "connectivityDemoButton"
            Me.connectivityDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.connectivityDemoButton.TabIndex = 0
            Me.connectivityDemoButton.Text = "Connectivity Demo"
            AddHandler Me.connectivityDemoButton.Click, New System.EventHandler(AddressOf Me.connectivityDemoButton_Click)
            ' 
            ' discoveryDemoButton
            ' 
            Me.discoveryDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.discoveryDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.discoveryDemoButton.ForeColor = System.Drawing.Color.White
            Me.discoveryDemoButton.Location = New System.Drawing.Point(24, 39)
            Me.discoveryDemoButton.Name = "discoveryDemoButton"
            Me.discoveryDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.discoveryDemoButton.TabIndex = 1
            Me.discoveryDemoButton.Text = "Discovery Demo"
            AddHandler Me.discoveryDemoButton.Click, New System.EventHandler(AddressOf Me.discoveryDemoButton_Click)
            ' 
            ' listFormatsDemoButton
            ' 
            Me.listFormatsDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.listFormatsDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.listFormatsDemoButton.ForeColor = System.Drawing.Color.White
            Me.listFormatsDemoButton.Location = New System.Drawing.Point(24, 71)
            Me.listFormatsDemoButton.Name = "listFormatsDemoButton"
            Me.listFormatsDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.listFormatsDemoButton.TabIndex = 2
            Me.listFormatsDemoButton.Text = "List Formats Demo"
            AddHandler Me.listFormatsDemoButton.Click, New System.EventHandler(AddressOf Me.listFormatsDemoButton_Click)
            ' 
            ' sendFileDemoButton
            ' 
            Me.sendFileDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.sendFileDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.sendFileDemoButton.ForeColor = System.Drawing.Color.White
            Me.sendFileDemoButton.Location = New System.Drawing.Point(24, 103)
            Me.sendFileDemoButton.Name = "sendFileDemoButton"
            Me.sendFileDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.sendFileDemoButton.TabIndex = 3
            Me.sendFileDemoButton.Text = "Send File Demo"
            AddHandler Me.sendFileDemoButton.Click, New System.EventHandler(AddressOf Me.sendFileDemoButton_Click)
            ' 
            ' storedFormatDemoButton
            ' 
            Me.storedFormatDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.storedFormatDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.storedFormatDemoButton.ForeColor = System.Drawing.Color.White
            Me.storedFormatDemoButton.Location = New System.Drawing.Point(24, 135)
            Me.storedFormatDemoButton.Name = "storedFormatDemoButton"
            Me.storedFormatDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.storedFormatDemoButton.TabIndex = 4
            Me.storedFormatDemoButton.Text = "Stored Format Demo"
            AddHandler Me.storedFormatDemoButton.Click, New System.EventHandler(AddressOf Me.storedFormatDemoButton_Click)
            ' 
            ' imagePrintDemoButton
            ' 
            Me.imagePrintDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.imagePrintDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.imagePrintDemoButton.ForeColor = System.Drawing.Color.White
            Me.imagePrintDemoButton.Location = New System.Drawing.Point(24, 167)
            Me.imagePrintDemoButton.Name = "imagePrintDemoButton"
            Me.imagePrintDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.imagePrintDemoButton.TabIndex = 5
            Me.imagePrintDemoButton.Text = "Image Print Demo"
            AddHandler Me.imagePrintDemoButton.Click, New System.EventHandler(AddressOf Me.imagePrintDemoButton_Click)
            ' 
            ' magCardDemoButton
            ' 
            Me.magCardDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.magCardDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.magCardDemoButton.ForeColor = System.Drawing.Color.White
            Me.magCardDemoButton.Location = New System.Drawing.Point(24, 263)
            Me.magCardDemoButton.Name = "magCardDemoButton"
            Me.magCardDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.magCardDemoButton.TabIndex = 8
            Me.magCardDemoButton.Text = "MagCard Demo"
            AddHandler Me.magCardDemoButton.Click, New System.EventHandler(AddressOf Me.magCardDemoButton_Click)
            ' 
            ' smartCardDemoButton
            ' 
            Me.smartCardDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.smartCardDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.smartCardDemoButton.ForeColor = System.Drawing.Color.White
            Me.smartCardDemoButton.Location = New System.Drawing.Point(24, 231)
            Me.smartCardDemoButton.Name = "smartCardDemoButton"
            Me.smartCardDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.smartCardDemoButton.TabIndex = 7
            Me.smartCardDemoButton.Text = "Smart Card Demo"
            AddHandler Me.smartCardDemoButton.Click, New System.EventHandler(AddressOf Me.smartCardDemoButton_Click)
            ' 
            ' printerStatusDemoButton
            ' 
            Me.printerStatusDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.printerStatusDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.printerStatusDemoButton.ForeColor = System.Drawing.Color.White
            Me.printerStatusDemoButton.Location = New System.Drawing.Point(24, 199)
            Me.printerStatusDemoButton.Name = "printerStatusDemoButton"
            Me.printerStatusDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.printerStatusDemoButton.TabIndex = 6
            Me.printerStatusDemoButton.Text = "Printer Status Demo"
            AddHandler Me.printerStatusDemoButton.Click, New System.EventHandler(AddressOf Me.printerStatusDemoButton_Click)
            ' 
            ' signatureCaptureDemoButton
            ' 
            Me.signatureCaptureDemoButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.signatureCaptureDemoButton.BackColor = System.Drawing.Color.DimGray
            Me.signatureCaptureDemoButton.ForeColor = System.Drawing.Color.White
            Me.signatureCaptureDemoButton.Location = New System.Drawing.Point(24, 295)
            Me.signatureCaptureDemoButton.Name = "signatureCaptureDemoButton"
            Me.signatureCaptureDemoButton.Size = New System.Drawing.Size(172, 26)
            Me.signatureCaptureDemoButton.TabIndex = 9
            Me.signatureCaptureDemoButton.Text = "Signature Capture Demo"
            AddHandler Me.signatureCaptureDemoButton.Click, New System.EventHandler(AddressOf Me.signatureCaptureDemoButton_Click)
            ' 
            ' DeveloperDemoForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.ClientSize = New System.Drawing.Size(240, 294)
            Me.Controls.Add(Me.signatureCaptureDemoButton)
            Me.Controls.Add(Me.printerStatusDemoButton)
            Me.Controls.Add(Me.smartCardDemoButton)
            Me.Controls.Add(Me.magCardDemoButton)
            Me.Controls.Add(Me.imagePrintDemoButton)
            Me.Controls.Add(Me.storedFormatDemoButton)
            Me.Controls.Add(Me.sendFileDemoButton)
            Me.Controls.Add(Me.listFormatsDemoButton)
            Me.Controls.Add(Me.discoveryDemoButton)
            Me.Controls.Add(Me.connectivityDemoButton)
            Me.KeyPreview = True
            Me.MinimizeBox = False
            Me.Name = "DeveloperDemoForm"
            Me.Text = getTitle()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private connectivityDemoButton As System.Windows.Forms.Button
        Private discoveryDemoButton As System.Windows.Forms.Button
        Private listFormatsDemoButton As System.Windows.Forms.Button
        Private sendFileDemoButton As System.Windows.Forms.Button
        Private storedFormatDemoButton As System.Windows.Forms.Button
        Private imagePrintDemoButton As System.Windows.Forms.Button
        Private magCardDemoButton As System.Windows.Forms.Button
        Private smartCardDemoButton As System.Windows.Forms.Button
        Private printerStatusDemoButton As System.Windows.Forms.Button
        Private signatureCaptureDemoButton As System.Windows.Forms.Button
    End Class
End Namespace

