' CONFIDENTIAL AND PROPRIETARY 
'
' The source code and other information contained herein is the confidential and the exclusive property of
' ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
' This source code, and any other information contained herein, shall not be copied, reproduced, published, 
' displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
' expressly permitted under such license agreement.
'
' Copyright ZIH Corp. 2010
'
' ALL RIGHTS RESERVED 
'
' File:   BluetoothDiscoveryDemoVBForm.vb
'
' Description: Form and code demonstrating how to discover nearby devices via
' Bluetooth. Code detects all broadcasting Bluetooth devices, not just Zebra
' Bluetooth devices. Demo also allows users to connect to Zebra devices via
' Bluetooth that have been discovered.
'
'$Revision: 1 $
'$Date: 2011/03/16 $

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports ZSDK_API.Discovery
Imports System.Threading
Imports ZSDK_API.ApiException
Imports ZSDK_API.Comm
Imports ZSDK_API.Printer
Imports System.Text

Public Class BluetoothDiscoveryDemoVBNETForm
    Private macAddress As [String]
    Dim connection As ZebraPrinterConnection
    Dim printer As ZebraPrinter

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'When discoverButton is clicked, start new thread to discover nearby bluetooth devices
    Private Sub discoverButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles discoveryButton.Click
        updateGuiFromWorkerThread("Discovery in progress...", Color.HotPink)
        Dim t As New Thread(AddressOf doBluetoothDiscovery)
        t.Start()
    End Sub
    ' When connectButton is clicked, start new thread to connect to the mac address that is selected in the listbox
    Private Sub connectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectButton.Click
        Me.macAddress = discoveredPrintersListBox.SelectedItem.ToString.Trim
        Dim t As New Thread(AddressOf doConnectBT)
        t.Start()
    End Sub
    ' When disconnectButton is clicked, spawn a thread to disconnect from the currently connected printer
    Private Sub disconnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnectButton.Click
        disconnect()
    End Sub
    ' Called when the frame has been closed. Closes the open connection to a printer if one exists.
    ' Use BlutoothDiscoverer class to get an array of printers detected. Display printers in listbox
    Private Sub doBluetoothDiscovery()
        Try
            displayPrinters(BluetoothDiscoverer.FindPrinters())
        Catch ex As DiscoveryException
            handleException(ex.Message)
        End Try
    End Sub
    'Check that macAddress is valid
    'Connect to device using BluetoothPrinterConnection class
    Private Sub doConnectBT()
        If connection IsNot Nothing Then
            doDisconnect()
        End If
        updateButtonFromWorkerThread(False)

        If Me.macAddress Is Nothing OrElse Me.macAddress.Length <> 12 Then
            updateGuiFromWorkerThread("Invalid MAC Address", Color.Red)
            disconnect()
        Else
            updateGuiFromWorkerThread("Connecting to " + Me.macAddress + " ...", Color.Goldenrod)
            Try
                connection = New BluetoothPrinterConnection(Me.macAddress)
                connection.Open()
                Thread.Sleep(1000)
            Catch generatedExceptionName As ZebraPrinterConnectionException
                updateGuiFromWorkerThread("Unable to connect with printer", Color.Red)
                disconnect()
            Catch generatedExceptionName As ZebraException
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
                disconnect()

            Catch generatedExceptionName As Exception
                updateGuiFromWorkerThread("Error communicating with printer", Color.Red)
                disconnect()
            End Try

            ' Get printer from ZebraPrinterFactory
            ' Get printer language
            ' Thread.Sleep allow statusBar updates to be seen before they change

            printer = Nothing
            If connection IsNot Nothing AndAlso connection.IsConnected() Then
                Try
                    updateGuiFromWorkerThread("Getting printer...", Color.Goldenrod)
                    Thread.Sleep(1000)
                    printer = ZebraPrinterFactory.GetInstance(connection)
                    updateGuiFromWorkerThread("Got Printer, getting Language...", Color.LemonChiffon)
                    Thread.Sleep(1000)

                    Dim pl As PrinterLanguage = printer.GetPrinterControlLanguage()
                    updateGuiFromWorkerThread("Printer Language " & pl.ToString(), Color.LemonChiffon)
                    Thread.Sleep(1000)
                    updateGuiFromWorkerThread("Connected to " & macAddress, Color.Green)
                    Thread.Sleep(1000)

                Catch generatedExceptionName As ZebraPrinterConnectionException
                    updateGuiFromWorkerThread("ZebraPrinterConnectionException - Unknown Printer", Color.Red)
                    printer = Nothing
                    Thread.Sleep(1000)
                    disconnect()

                Catch generatedExceptionName As ZebraPrinterLanguageUnknownException
                    updateGuiFromWorkerThread("ZebraPrinterLanguageUnknownException - Unknown Printer Language", Color.Red)
                    printer = Nothing
                    Thread.Sleep(1000)
                    disconnect()

                End Try
                updateButtonFromWorkerThread(True)
            End If
        End If
    End Sub
    'Start disconnect thread
    Public Sub disconnect()
        Dim t As New Thread(AddressOf doDisconnect)
        t.Start()
    End Sub
    'Close connection to printer
    Private Sub doDisconnect()
        updateButtonFromWorkerThread(False)
        Try
            If connection IsNot Nothing AndAlso connection.IsConnected() Then
                updateGuiFromWorkerThread("Disconnecting...", Color.Honeydew)

                connection.Close()
            End If
        Catch generatedExceptionName As ZebraException
            updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
        End Try

        Thread.Sleep(1000)
        updateGuiFromWorkerThread("Not Connected", Color.Red)
        connection = Nothing
        updateButtonFromWorkerThread(True)
    End Sub
    ' The following methods update the discovered printers listbox
    Private Sub handleException(ByVal message As [String])
        updateGuiFromWorkerThread(message, Color.Red)
        BeginInvoke(New MyProgressEventsHandler(AddressOf UpdateDiscoveredPrinters), New Object() {Me, New DiscoveredPrinter() {}})
    End Sub
    Private Delegate Sub MyProgressEventsHandler(ByVal sender As Object, ByVal printers As DiscoveredPrinter())
    Private Sub UpdateDiscoveredPrinters(ByVal sender As Object, ByVal printers As DiscoveredPrinter())
        For Each printer As DiscoveredPrinter In printers
            discoveredPrintersListBox.Items.Add(printer.Address)
        Next
        discoveryButton.Enabled = True
    End Sub
    Private Sub displayPrinters(ByVal printers As DiscoveredPrinter())
        updateGuiFromWorkerThread("Discovered " & printers.Length & " printers", Color.Green)
        BeginInvoke(New MyProgressEventsHandler(AddressOf UpdateDiscoveredPrinters), New Object() {Me, printers})
    End Sub
    ' The following methods update the status bar at top of screen
    Public Sub updateGuiFromWorkerThread(ByVal message As [String], ByVal color As Color)
        Invoke(New StatusEventHandler(AddressOf UpdateUI), New StatusArguments(message, color))
    End Sub
    'Delegate for the status event handler
    Private Delegate Sub StatusEventHandler(ByVal e As StatusArguments)
    ' The following method updates the status bar
    Private Sub UpdateUI(ByVal e As StatusArguments)
        statusBar.Text = e.message
        statusBar.BackColor = e.color
    End Sub
    ' Status Bar data class - holds the text to be displayed and the background color of the label
    Private Class StatusArguments
        Inherits System.EventArgs
        Public message As [String]
        Public color As Color
        Public Sub New(ByVal message As [String], ByVal color As Color)
            Me.message = message
            Me.color = color
        End Sub
    End Class
    'The following methods enable and disable buttons as needed
    Public Sub updateButtonFromWorkerThread(ByVal enabled As Boolean)
        Invoke(New ButtonStatusHandler(AddressOf UpdateButton), enabled)
    End Sub
    ' Delegate for the Button status handler
    Private Delegate Sub ButtonStatusHandler(ByVal enabled As Boolean)
    'The following method sets the state of the buttons on the form
    Private Sub UpdateButton(ByVal enabled As Boolean)
        discoveryButton.Enabled = enabled
        connectButton.Enabled = enabled
        disconnectButton.Enabled = enabled
    End Sub
    ' The following method is called before the form is being closed
    Private Sub BluetoothDiscoveryDemoVBForm_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If connection IsNot Nothing Then
            connection.Close()
        End If

    End Sub
End Class


