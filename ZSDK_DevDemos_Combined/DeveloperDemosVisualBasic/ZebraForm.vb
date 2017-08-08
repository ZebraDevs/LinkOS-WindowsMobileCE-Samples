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
Imports ZSDK_API.Comm
Imports ZSDK_API.Printer
Imports System.Threading
Imports ZSDK_API.ApiException
Imports System.Drawing
Imports System.IO.Ports

Namespace ZebraDeveloperDemos

    Public Delegate Sub PrinterConnectionHandler()
    <System.ComponentModel.DesignerCategory("Code")> _
    Public Class ZebraForm
        Inherits Form
        Public Event connectionEstablished As PrinterConnectionHandler
        Public Event connectionClosed As PrinterConnectionHandler

        Protected zebraConnectionPanel As ConnectionPanel

        Private connection As ZebraPrinterConnection
        Private printer As ZebraPrinter

        Public Sub connect()
            Dim connectionType As [String] = zebraConnectionPanel.ConnectionType
            If connectionType.Equals("IP/DNS") Then
                Try
                    connectTCP(zebraConnectionPanel.IPAddress, zebraConnectionPanel.PortNum)
                Catch generatedExceptionName As FormatException
                    updateGuiFromWorkerThread("Invalid data on form", Color.Red)
                End Try
            ElseIf connectionType.Equals("Bluetooth(R)") Then
                connectBluetooth(zebraConnectionPanel.BluetoothMacAddress)
            ElseIf connectionType.Equals("Serial") Then
                Try
                    connectSerial(zebraConnectionPanel.SerialComPortName, zebraConnectionPanel.SerialBaudRate, zebraConnectionPanel.SerialDataBits, zebraConnectionPanel.SerialParity, zebraConnectionPanel.SerialStopBits, zebraConnectionPanel.SerialHandshake)
                Catch generatedExceptionName As FormatException
                    updateGuiFromWorkerThread("Invalid data on form", Color.Red)
                End Try
            ElseIf connectionType.Equals("USB") Then
                connectUsb(zebraConnectionPanel.UsbPortName)
            Else
                RaiseEvent connectionClosed()
            End If
        End Sub

        Private portName As [String]
        Private baudRate As Integer
        Private dataBits As Integer
        Private parity As Parity
        Private stopBits As StopBits
        Private handshake As Handshake

        Private Sub connectSerial(ByVal portName As [String], ByVal baudRate As Integer, ByVal dataBits As Integer, ByVal parity As Parity, ByVal stopBits As StopBits, ByVal handshake As Handshake)
            Me.portName = portName
            Me.baudRate = baudRate
            Me.dataBits = dataBits
            Me.parity = parity
            Me.stopBits = stopBits
            Me.handshake = handshake
            Dim t As New Thread(AddressOf doConnectSerial)
            t.Start()
        End Sub

        Private Sub doConnectSerial()
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod)
            Try
                connection = New SerialPrinterConnection(Me.portName, Me.baudRate, Me.dataBits, Me.parity, Me.stopBits, Me.handshake)
                threadedConnect(Me.portName)
            Catch generatedExceptionName As ZebraException
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
            End Try
        End Sub

        Private ipAddress As [String]
        Private portNumber As Integer

        Private Sub connectTCP(ByVal ipAddress As [String], ByVal portNumber As Integer)
            Me.ipAddress = ipAddress
            Me.portNumber = portNumber
            Dim t As New Thread(AddressOf doConnectTcp)
            t.Start()
        End Sub

        Private Sub doConnectTcp()
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod)
            Try
                connection = New TcpPrinterConnection(Me.ipAddress, Me.portNumber)
                threadedConnect(Me.ipAddress)
            Catch generatedExceptionName As ZebraException
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
            End Try
        End Sub

        Private macAddress As [String]

        Private Sub connectBluetooth(ByVal macAddress As [String])
            Me.macAddress = macAddress.Trim()
            Dim t As New Thread(AddressOf doConnectBT)
            t.Start()
        End Sub

        Private Sub doConnectBT()
            If Me.macAddress.Length <> 12 Then
                updateGuiFromWorkerThread("Invalid MAC Address", Color.Red)
                disconnect()
            Else
                updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod)
                Try
                    connection = New BluetoothPrinterConnection(Me.macAddress)
                    threadedConnect(Me.macAddress)
                Catch generatedExceptionName As ZebraException
                    updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
                End Try
            End If
        End Sub

        Private usbPort As [String]

        Private Sub connectUsb(ByVal usbPort As [String])
            Me.usbPort = usbPort.Trim() & ":"
            Dim t As New Thread(AddressOf doConnectUsb)
            t.Start()
        End Sub

        Private Sub doConnectUsb()
            updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod)
            Try
                connection = New UsbPrinterConnection(Me.usbPort)
                threadedConnect(Me.usbPort)
            Catch generatedExceptionName As ZebraException
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
                RaiseEvent connectionClosed()
            End Try
        End Sub

        Private Sub threadedConnect(ByVal addressName As [String])
            Try
                connection.Open()
                Thread.Sleep(1000)
            Catch generatedExceptionName As ZebraPrinterConnectionException
                updateGuiFromWorkerThread("Unable to connect with printer", Color.Red)
                disconnect()
            Catch e As ZebraGeneralException
                updateGuiFromWorkerThread(e.Message, Color.Red)
                disconnect()
            Catch generatedExceptionName As Exception
                updateGuiFromWorkerThread("Error communicating with printer", Color.Red)
                disconnect()
            End Try

            printer = Nothing
            If connection IsNot Nothing AndAlso connection.IsConnected() Then
                Try
                    printer = ZebraPrinterFactory.GetInstance(connection)
                    Dim pl As PrinterLanguage = printer.GetPrinterControlLanguage()
                    updateGuiFromWorkerThread("Printer Language " & pl.ToString(), Color.LemonChiffon)
                    Thread.Sleep(1000)
                    updateGuiFromWorkerThread("Connected to " & addressName, Color.Green)
                    Thread.Sleep(1000)
                    RaiseEvent connectionEstablished()
                Catch generatedExceptionName As ZebraPrinterConnectionException
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red)
                    printer = Nothing
                    Thread.Sleep(1000)
                    disconnect()
                Catch generatedExceptionName As ZebraPrinterLanguageUnknownException
                    updateGuiFromWorkerThread("Unknown Printer Language", Color.Red)
                    printer = Nothing
                    Thread.Sleep(1000)
                    disconnect()
                End Try
            End If
        End Sub

        Public Sub disconnect()
            Dim t As New Thread(AddressOf doDisconnect)
            t.Start()
        End Sub

        Private Sub doDisconnect()
            Try
                If connection IsNot Nothing AndAlso connection.IsConnected() Then
                    updateGuiFromWorkerThread("Disconnecting", Color.Honeydew)
                    connection.Close()
                End If
            Catch generatedExceptionName As ZebraException
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
            End Try
            Thread.Sleep(1000)
            RaiseEvent connectionClosed()
            updateGuiFromWorkerThread("Not Connected", Color.Red)
            connection = Nothing
        End Sub

        Public Sub updateGuiFromWorkerThread(ByVal message As [String], ByVal color As Color)
            Invoke(New StatusEventHandler(AddressOf UpdateUI), New StatusArguments(message, color))
        End Sub

        Private Delegate Sub StatusEventHandler(ByVal e As StatusArguments)

        Private Sub UpdateUI(ByVal e As StatusArguments)
            zebraConnectionPanel.SetStatus("Status: " & e.message, e.color)
        End Sub

        Public Function getConnection() As ZebraPrinterConnection
            Return connection
        End Function

        Public Function getPrinter() As ZebraPrinter
            Return printer
        End Function

        Private Class StatusArguments
            Inherits System.EventArgs
            Public message As [String]
            Public color As Color

            Public Sub New(ByVal message As [String], ByVal color As Color)
                Me.message = message
                Me.color = color
            End Sub

        End Class
    End Class
End Namespace

