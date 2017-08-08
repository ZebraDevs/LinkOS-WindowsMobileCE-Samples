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

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO.Ports

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
    Partial Public Class ConnectionPanel
        Inherits UserControl
        Public Sub New()
            InitializeComponent()
            connectionMethodCombo.SelectedIndex = 0
            Me.SerialBaudRate = 9600
            Me.SerialComPortName = "COM1"
            Me.SerialDataBits = 8
            Me.SerialHandshake = System.IO.Ports.Handshake.None
            Me.SerialParity = System.IO.Ports.Parity.None
            Me.SerialStopBits = System.IO.Ports.StopBits.One
        End Sub

        Public Sub SetStatus(ByVal message As [String], ByVal color As Color)
            statusLabel.Text = message
            statusLabel.BackColor = color
        End Sub

        Public Property ConnectionType() As [String]
            Get
                Return connectionMethodCombo.Text
            End Get
            Set(ByVal value As [String])
            End Set
        End Property

        Public Property IPAddress() As [String]
            Get
                Return ipDnsAddress.Text
            End Get
            Set(ByVal value As [String])
                ipDnsAddress.Text = Value
            End Set
        End Property

        Public Property PortNum() As Integer
            Get
                Dim retVal As Integer = 6101
                If portNumber.Text.Equals("") = False Then
                    retVal = Convert.ToInt32(portNumber.Text)
                End If
                Return retVal
            End Get
            Set(ByVal value As Integer)
                portNumber.Text = Convert.ToString(value)
            End Set
        End Property

        Public Property BluetoothMacAddress() As [String]
            Get
                Return macAddress.Text
            End Get
            Set(ByVal value As [String])
                macAddress.Text = value
            End Set
        End Property
        Public ReadOnly Property UsbPortName() As [String]
            Get
                Dim retVal As [String] = "LPT1"
                If UsbPortNameCombo.Text.Equals("") = False Then
                    retVal = UsbPortNameCombo.Text
                End If
                Return retVal
            End Get
        End Property
        Public Property SerialComPortName() As [String]
            Get
                Dim retVal As [String] = "COM1"
                If portNamesCombo.Text.Equals("") = False Then
                    retVal = portNamesCombo.Text
                End If
                Return retVal
            End Get
            Set(ByVal value As [String])
                portNamesCombo.Text = value
            End Set
        End Property

        Public Property SerialBaudRate() As Integer
            Get
                Dim retVal As Integer = 9600
                If baudRateCombo.Text.Equals("") = False Then
                    retVal = Convert.ToInt32(baudRateCombo.Text)
                End If
                Return retVal
            End Get
            Set(ByVal value As Integer)
                baudRateCombo.Text = Convert.ToString(value)
            End Set
        End Property

        Public Property SerialDataBits() As Integer
            Get
                Dim retVal As Integer = 8
                If dataBitsCombo.Text.Equals("") = False Then
                    retVal = Convert.ToInt32(dataBitsCombo.Text)
                End If
                Return retVal
            End Get
            Set(ByVal value As Integer)
                dataBitsCombo.Text = Convert.ToString(value)
            End Set
        End Property

        Public Property SerialParity() As Parity
            Get
                Dim retVal As Parity = Parity.None
                If parityCombo.Text.Equals("") = False Then
                    retVal = CType([Enum].Parse(GetType(Parity), parityCombo.Text, True), Parity)
                End If
                Return retVal
            End Get
            Set(ByVal value As Parity)
                parityCombo.Text = value.ToString()
            End Set
        End Property

        Public Property SerialStopBits() As StopBits
            Get
                Return convertStopBitsTextToEnum(stopBitsCombo.Text)
            End Get
            Set(ByVal value As StopBits)
                stopBitsCombo.Text = convertStopBitsEnumToText(value)
            End Set
        End Property

        Private Function convertStopBitsEnumToText(ByVal value As StopBits) As [String]
            Dim retVal As [String] = "1"
            Select Case value
                Case StopBits.OnePointFive
                    retVal = "1.5"
                    Exit Select
                Case StopBits.Two
                    retVal = "2"
                    Exit Select
                Case StopBits.One
                Case Else
                    retVal = "1"
                    Exit Select
            End Select

            Return retVal
        End Function

        Private Function convertStopBitsTextToEnum(ByVal stopBitsText As [String]) As StopBits
            Dim retVal As StopBits = StopBits.One
            If stopBitsText.Equals("1.5") = True Then
                retVal = StopBits.OnePointFive
            ElseIf stopBitsText.Equals("2") = True Then
                retVal = StopBits.Two
            End If
            Return retVal
        End Function

        Public Property SerialHandshake() As Handshake
            Get
                Dim retVal As Handshake = Handshake.None
                If handshakeCombo.SelectedIndex > -1 Then
                    retVal = CType(handshakeCombo.SelectedIndex, Handshake)
                End If
                Return retVal
            End Get
            Set(ByVal value As Handshake)
                handshakeCombo.Text = value.ToString()
            End Set
        End Property
        Private Sub connectionMethod_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim selectedConnectionMethod As [String] = DirectCast(sender, ComboBox).Text

            ipDnsPanel.Visible = False
            bluetoothPanel.Visible = False
            serialPanel.Visible = False
            usbPanel.Visible = False

            Select Case selectedConnectionMethod
                Case "IP/DNS"
                    ipDnsPanel.Visible = True
                    Exit Select
                Case "Bluetooth(R)"
                    bluetoothPanel.Visible = True
                    Exit Select
                Case "Serial"
                    serialPanel.Visible = True
                    Exit Select
                Case "USB"
                    usbPanel.Visible = True
                    Exit Select
                Case Else
                    Exit Select
            End Select
        End Sub

        Private Sub portNumber_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            'numeric values only
            If (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
                e.Handled = True
            End If
            MyBase.OnKeyPress(e)
        End Sub
    End Class
End Namespace
