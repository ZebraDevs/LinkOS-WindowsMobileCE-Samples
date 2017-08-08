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
    Partial Class ConnectionPanel
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

#Region "Component Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.connLabel = New System.Windows.Forms.Label()
            Me.connectionMethodCombo = New System.Windows.Forms.ComboBox()
            Me.ipDnsPanel = New System.Windows.Forms.Panel()
            Me.portNumber = New System.Windows.Forms.TextBox()
            Me.ipDnsAddress = New System.Windows.Forms.TextBox()
            Me.portLabel = New System.Windows.Forms.Label()
            Me.ipDnsLabel = New System.Windows.Forms.Label()
            Me.bluetoothPanel = New System.Windows.Forms.Panel()
            Me.macAddress = New System.Windows.Forms.TextBox()
            Me.btLabel = New System.Windows.Forms.Label()
            Me.serialPanel = New System.Windows.Forms.Panel()
            Me.handshakeCombo = New System.Windows.Forms.ComboBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.dataBitsCombo = New System.Windows.Forms.ComboBox()
            Me.dataBitLabel = New System.Windows.Forms.Label()
            Me.stopBitsCombo = New System.Windows.Forms.ComboBox()
            Me.stopBitLabel = New System.Windows.Forms.Label()
            Me.parityCombo = New System.Windows.Forms.ComboBox()
            Me.parityLabel = New System.Windows.Forms.Label()
            Me.baudRateCombo = New System.Windows.Forms.ComboBox()
            Me.baudRateLabel = New System.Windows.Forms.Label()
            Me.portNamesCombo = New System.Windows.Forms.ComboBox()
            Me.portNameLabel = New System.Windows.Forms.Label()
            Me.statusLabel = New System.Windows.Forms.Label()
            Me.usbPanel = New System.Windows.Forms.Panel()
            Me.UsbPortNameCombo = New System.Windows.Forms.ComboBox()
            Me.usbPort = New System.Windows.Forms.Label()
            Me.ipDnsPanel.SuspendLayout()
            Me.bluetoothPanel.SuspendLayout()
            Me.serialPanel.SuspendLayout()
            Me.usbPanel.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' connLabel
            ' 
            Me.connLabel.Location = New System.Drawing.Point(6, 38)
            Me.connLabel.Name = "connLabel"
            Me.connLabel.Size = New System.Drawing.Size(118, 19)
            Me.connLabel.Text = "Connection Method: "
            ' 
            ' connectionMethodCombo
            ' 
            Me.connectionMethodCombo.Items.Add("IP/DNS")
            Me.connectionMethodCombo.Items.Add("Bluetooth(R)")
            Me.connectionMethodCombo.Items.Add("Serial")
            Me.connectionMethodCombo.Items.Add("USB")
            Me.connectionMethodCombo.Location = New System.Drawing.Point(130, 36)
            Me.connectionMethodCombo.Name = "connectionMethodCombo"
            Me.connectionMethodCombo.Size = New System.Drawing.Size(100, 22)
            Me.connectionMethodCombo.TabIndex = 1
            AddHandler Me.connectionMethodCombo.SelectedValueChanged, New System.EventHandler(AddressOf Me.connectionMethod_SelectedValueChanged)
            ' 
            ' ipDnsPanel
            ' 
            Me.ipDnsPanel.BackColor = System.Drawing.Color.DarkGray
            Me.ipDnsPanel.Controls.Add(Me.portNumber)
            Me.ipDnsPanel.Controls.Add(Me.ipDnsAddress)
            Me.ipDnsPanel.Controls.Add(Me.portLabel)
            Me.ipDnsPanel.Controls.Add(Me.ipDnsLabel)
            Me.ipDnsPanel.Location = New System.Drawing.Point(0, 64)
            Me.ipDnsPanel.Name = "ipDnsPanel"
            Me.ipDnsPanel.Size = New System.Drawing.Size(230, 81)
            Me.ipDnsPanel.Visible = False
            ' 
            ' portNumber
            ' 
            Me.portNumber.Location = New System.Drawing.Point(105, 42)
            Me.portNumber.Name = "portNumber"
            Me.portNumber.Size = New System.Drawing.Size(100, 21)
            Me.portNumber.TabIndex = 3
            AddHandler Me.portNumber.KeyPress, New System.Windows.Forms.KeyPressEventHandler(AddressOf Me.portNumber_KeyPress)
            ' 
            ' ipDnsAddress
            ' 
            Me.ipDnsAddress.Location = New System.Drawing.Point(105, 11)
            Me.ipDnsAddress.Name = "ipDnsAddress"
            Me.ipDnsAddress.Size = New System.Drawing.Size(100, 21)
            Me.ipDnsAddress.TabIndex = 2
            ' 
            ' portLabel
            ' 
            Me.portLabel.Location = New System.Drawing.Point(15, 43)
            Me.portLabel.Name = "portLabel"
            Me.portLabel.Size = New System.Drawing.Size(35, 20)
            Me.portLabel.Text = "Port:"
            ' 
            ' ipDnsLabel
            ' 
            Me.ipDnsLabel.Location = New System.Drawing.Point(15, 16)
            Me.ipDnsLabel.Name = "ipDnsLabel"
            Me.ipDnsLabel.Size = New System.Drawing.Size(54, 16)
            Me.ipDnsLabel.Text = "IP/DNS:"
            ' 
            ' bluetoothPanel
            ' 
            Me.bluetoothPanel.BackColor = System.Drawing.Color.DarkGray
            Me.bluetoothPanel.Controls.Add(Me.macAddress)
            Me.bluetoothPanel.Controls.Add(Me.btLabel)
            Me.bluetoothPanel.Location = New System.Drawing.Point(0, 73)
            Me.bluetoothPanel.Name = "bluetoothPanel"
            Me.bluetoothPanel.Size = New System.Drawing.Size(230, 54)
            Me.bluetoothPanel.Visible = False
            ' 
            ' macAddress
            ' 
            Me.macAddress.Location = New System.Drawing.Point(105, 15)
            Me.macAddress.Name = "macAddress"
            Me.macAddress.Size = New System.Drawing.Size(100, 21)
            Me.macAddress.TabIndex = 1
            ' 
            ' btLabel
            ' 
            Me.btLabel.Location = New System.Drawing.Point(15, 16)
            Me.btLabel.Name = "btLabel"
            Me.btLabel.Size = New System.Drawing.Size(84, 20)
            Me.btLabel.Text = "MAC Address:"
            ' 
            ' serialPanel
            ' 
            Me.serialPanel.BackColor = System.Drawing.Color.DarkGray
            Me.serialPanel.Controls.Add(Me.handshakeCombo)
            Me.serialPanel.Controls.Add(Me.label1)
            Me.serialPanel.Controls.Add(Me.dataBitsCombo)
            Me.serialPanel.Controls.Add(Me.dataBitLabel)
            Me.serialPanel.Controls.Add(Me.stopBitsCombo)
            Me.serialPanel.Controls.Add(Me.stopBitLabel)
            Me.serialPanel.Controls.Add(Me.parityCombo)
            Me.serialPanel.Controls.Add(Me.parityLabel)
            Me.serialPanel.Controls.Add(Me.baudRateCombo)
            Me.serialPanel.Controls.Add(Me.baudRateLabel)
            Me.serialPanel.Controls.Add(Me.portNamesCombo)
            Me.serialPanel.Controls.Add(Me.portNameLabel)
            Me.serialPanel.Location = New System.Drawing.Point(0, 64)
            Me.serialPanel.Name = "serialPanel"
            Me.serialPanel.Size = New System.Drawing.Size(233, 81)
            Me.serialPanel.Visible = False
            ' 
            ' handshakeCombo
            ' 
            Me.handshakeCombo.Items.Add("None")
            Me.handshakeCombo.Items.Add("XOnXOff")
            Me.handshakeCombo.Items.Add("RTS")
            Me.handshakeCombo.Items.Add("RTSXOnXOff")
            Me.handshakeCombo.Location = New System.Drawing.Point(170, 52)
            Me.handshakeCombo.Name = "handshakeCombo"
            Me.handshakeCombo.Size = New System.Drawing.Size(60, 22)
            Me.handshakeCombo.TabIndex = 18
            ' 
            ' label1
            ' 
            Me.label1.Location = New System.Drawing.Point(104, 54)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(76, 20)
            Me.label1.Text = "Handshake:"
            ' 
            ' dataBitsCombo
            ' 
            Me.dataBitsCombo.Items.Add("5")
            Me.dataBitsCombo.Items.Add("6")
            Me.dataBitsCombo.Items.Add("7")
            Me.dataBitsCombo.Items.Add("8")
            Me.dataBitsCombo.Location = New System.Drawing.Point(170, 2)
            Me.dataBitsCombo.Name = "dataBitsCombo"
            Me.dataBitsCombo.Size = New System.Drawing.Size(60, 22)
            Me.dataBitsCombo.TabIndex = 11
            ' 
            ' dataBitLabel
            ' 
            Me.dataBitLabel.Location = New System.Drawing.Point(104, 4)
            Me.dataBitLabel.Name = "dataBitLabel"
            Me.dataBitLabel.Size = New System.Drawing.Size(60, 20)
            Me.dataBitLabel.Text = "Data Bits:"
            ' 
            ' stopBitsCombo
            ' 
            Me.stopBitsCombo.Items.Add("1")
            Me.stopBitsCombo.Items.Add("1.5")
            Me.stopBitsCombo.Items.Add("2")
            Me.stopBitsCombo.Location = New System.Drawing.Point(170, 28)
            Me.stopBitsCombo.Name = "stopBitsCombo"
            Me.stopBitsCombo.Size = New System.Drawing.Size(60, 22)
            Me.stopBitsCombo.TabIndex = 9
            ' 
            ' stopBitLabel
            ' 
            Me.stopBitLabel.Location = New System.Drawing.Point(104, 28)
            Me.stopBitLabel.Name = "stopBitLabel"
            Me.stopBitLabel.Size = New System.Drawing.Size(60, 20)
            Me.stopBitLabel.Text = "Stop Bits:"
            ' 
            ' parityCombo
            ' 
            Me.parityCombo.Items.Add("None")
            Me.parityCombo.Items.Add("Even")
            Me.parityCombo.Items.Add("Odd")
            Me.parityCombo.Items.Add("Mark")
            Me.parityCombo.Items.Add("Space")
            Me.parityCombo.Location = New System.Drawing.Point(41, 52)
            Me.parityCombo.Name = "parityCombo"
            Me.parityCombo.Size = New System.Drawing.Size(57, 22)
            Me.parityCombo.TabIndex = 7
            ' 
            ' parityLabel
            ' 
            Me.parityLabel.Location = New System.Drawing.Point(3, 54)
            Me.parityLabel.Name = "parityLabel"
            Me.parityLabel.Size = New System.Drawing.Size(43, 20)
            Me.parityLabel.Text = "Parity:"
            ' 
            ' baudRateCombo
            ' 
            Me.baudRateCombo.Items.Add("300")
            Me.baudRateCombo.Items.Add("600")
            Me.baudRateCombo.Items.Add("1200")
            Me.baudRateCombo.Items.Add("2400")
            Me.baudRateCombo.Items.Add("4800")
            Me.baudRateCombo.Items.Add("7200")
            Me.baudRateCombo.Items.Add("9600")
            Me.baudRateCombo.Items.Add("14400")
            Me.baudRateCombo.Items.Add("19200")
            Me.baudRateCombo.Items.Add("28800")
            Me.baudRateCombo.Items.Add("38400")
            Me.baudRateCombo.Items.Add("57600")
            Me.baudRateCombo.Items.Add("115200")
            Me.baudRateCombo.Location = New System.Drawing.Point(41, 26)
            Me.baudRateCombo.Name = "baudRateCombo"
            Me.baudRateCombo.Size = New System.Drawing.Size(57, 22)
            Me.baudRateCombo.TabIndex = 5
            ' 
            ' baudRateLabel
            ' 
            Me.baudRateLabel.Location = New System.Drawing.Point(3, 27)
            Me.baudRateLabel.Name = "baudRateLabel"
            Me.baudRateLabel.Size = New System.Drawing.Size(43, 20)
            Me.baudRateLabel.Text = "Baud:"
            ' 
            ' portNamesCombo
            ' 
            Me.portNamesCombo.Items.Add("COM1")
            Me.portNamesCombo.Items.Add("COM2")
            Me.portNamesCombo.Items.Add("COM3")
            Me.portNamesCombo.Items.Add("COM4")
            Me.portNamesCombo.Items.Add("COM5")
            Me.portNamesCombo.Items.Add("COM6")
            Me.portNamesCombo.Items.Add("COM7")
            Me.portNamesCombo.Items.Add("COM8")
            Me.portNamesCombo.Items.Add("COM9")
            Me.portNamesCombo.Location = New System.Drawing.Point(41, 2)
            Me.portNamesCombo.Name = "portNamesCombo"
            Me.portNamesCombo.Size = New System.Drawing.Size(57, 22)
            Me.portNamesCombo.TabIndex = 3
            ' 
            ' portNameLabel
            ' 
            Me.portNameLabel.Location = New System.Drawing.Point(2, 4)
            Me.portNameLabel.Name = "portNameLabel"
            Me.portNameLabel.Size = New System.Drawing.Size(35, 20)
            Me.portNameLabel.Text = "Port:"
            ' 
            ' statusLabel
            ' 
            Me.statusLabel.BackColor = System.Drawing.Color.Red
            Me.statusLabel.Dock = System.Windows.Forms.DockStyle.Top
            Me.statusLabel.ForeColor = System.Drawing.Color.FromArgb(CInt(CByte(0)), CInt(CByte(0)), CInt(CByte(0)))
            Me.statusLabel.Location = New System.Drawing.Point(0, 0)
            Me.statusLabel.Name = "statusLabel"
            Me.statusLabel.Size = New System.Drawing.Size(233, 20)
            Me.statusLabel.Text = "Status : Not Connected"
            Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            ' 
            ' usbPanel
            ' 
            Me.usbPanel.BackColor = System.Drawing.Color.DarkGray
            Me.usbPanel.Controls.Add(Me.UsbPortNameCombo)
            Me.usbPanel.Controls.Add(Me.usbPort)
            Me.usbPanel.Location = New System.Drawing.Point(0, 64)
            Me.usbPanel.Name = "usbPanel"
            Me.usbPanel.Size = New System.Drawing.Size(233, 85)
            Me.usbPanel.Visible = False
            ' 
            ' UsbPortNameCombo
            ' 
            Me.UsbPortNameCombo.Items.Add("LPT1")
            Me.UsbPortNameCombo.Items.Add("LPT2")
            Me.UsbPortNameCombo.Location = New System.Drawing.Point(105, 15)
            Me.UsbPortNameCombo.Name = "UsbPortNameCombo"
            Me.UsbPortNameCombo.Size = New System.Drawing.Size(95, 22)
            Me.UsbPortNameCombo.TabIndex = 1
            ' 
            ' usbPort
            ' 
            Me.usbPort.Location = New System.Drawing.Point(15, 16)
            Me.usbPort.Name = "usbPort"
            Me.usbPort.Size = New System.Drawing.Size(84, 20)
            Me.usbPort.Text = "Port" & vbCr & vbLf
            ' 
            ' ConnectionPanel
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0F, 96.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.DarkGray
            Me.Controls.Add(Me.statusLabel)
            Me.Controls.Add(Me.connectionMethodCombo)
            Me.Controls.Add(Me.connLabel)
            Me.Controls.Add(Me.usbPanel)
            Me.Controls.Add(Me.bluetoothPanel)
            Me.Controls.Add(Me.serialPanel)
            Me.Controls.Add(Me.ipDnsPanel)
            Me.Name = "ConnectionPanel"
            Me.Size = New System.Drawing.Size(233, 149)
            Me.ipDnsPanel.ResumeLayout(False)
            Me.bluetoothPanel.ResumeLayout(False)
            Me.serialPanel.ResumeLayout(False)
            Me.usbPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private connLabel As System.Windows.Forms.Label
        Private connectionMethodCombo As System.Windows.Forms.ComboBox
        Private ipDnsLabel As System.Windows.Forms.Label
        Private portNumber As System.Windows.Forms.TextBox
        Private ipDnsAddress As System.Windows.Forms.TextBox
        Private portLabel As System.Windows.Forms.Label
        Private bluetoothPanel As System.Windows.Forms.Panel
        Private btLabel As System.Windows.Forms.Label
        Private macAddress As System.Windows.Forms.TextBox
        Private serialPanel As System.Windows.Forms.Panel
        Private portNameLabel As System.Windows.Forms.Label
        Private portNamesCombo As System.Windows.Forms.ComboBox
        Private baudRateLabel As System.Windows.Forms.Label
        Private stopBitsCombo As System.Windows.Forms.ComboBox
        Private stopBitLabel As System.Windows.Forms.Label
        Private parityCombo As System.Windows.Forms.ComboBox
        Private parityLabel As System.Windows.Forms.Label
        Private baudRateCombo As System.Windows.Forms.ComboBox
        Private dataBitsCombo As System.Windows.Forms.ComboBox
        Private dataBitLabel As System.Windows.Forms.Label
        Private statusLabel As System.Windows.Forms.Label
        Private handshakeCombo As System.Windows.Forms.ComboBox
        Private label1 As System.Windows.Forms.Label
        Private ipDnsPanel As System.Windows.Forms.Panel
        Private usbPanel As System.Windows.Forms.Panel
        Private usbPort As System.Windows.Forms.Label
        Private UsbPortNameCombo As System.Windows.Forms.ComboBox
    End Class
End Namespace
