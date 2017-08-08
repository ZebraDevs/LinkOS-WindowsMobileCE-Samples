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
' File:   DiscoveryMain.vb
'
' Description: Form and code demonstrating how to discover and connect to printers
' located on the network
'
'$Revision: 1 $
'$Date: 2011/04/01 $

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports ZSDK_API.Discovery
Imports System.Threading
Imports ZSDK_API.ApiException
Imports ZSDK_API.Comm
Imports ZSDK_API.Printer
Imports System.Text

Public Class DiscoveryMain
    Private ipAddress As String = "127.0.0.1"
    Private portNumber As Integer = 6101
    Private connection As ZebraPrinterConnection
    Private printer As ZebraPrinter
    Private discoveryMethodIndex As Integer
    Private multicastValue As Integer
    Private directedBroadcastAddress As String
    Private subnetAddress As String

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        discoveryMethodsComboBox.SelectedIndex = discoveryMethodsComboBox.Items.IndexOf("Multicast")
    End Sub

    Private Sub discoveryMethodsComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles discoveryMethodsComboBox.SelectedIndexChanged
        Dim methodSelection As Integer = discoveryMethodsComboBox.SelectedIndex
        Select Case (methodSelection)
            Case 0
                showMulticastPanel()
            Case 1
                showDirectBroadcastPanel()
            Case 3
                showSubnetPanel()
            Case Else
                hidePanels()
        End Select
    End Sub

    Private Sub showMulticastPanel()
        directBroadcastPanel.Visible = False
        subnetPanel.Visible = False
        multicastPanel.Visible = True
    End Sub

    Private Sub showDirectBroadcastPanel()
        directBroadcastPanel.Visible = True
        subnetPanel.Visible = False
        multicastPanel.Visible = False
    End Sub

    Private Sub showSubnetPanel()
        directBroadcastPanel.Visible = False
        subnetPanel.Visible = True
        multicastPanel.Visible = False
    End Sub

    Private Sub hidePanels()
        directBroadcastPanel.Visible = False
        subnetPanel.Visible = False
        multicastPanel.Visible = False
    End Sub

    Private Sub discoveryButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles discoveryButton.Click
        updateButtonFromWorkerThread(False)
        updateGuiFromWorkerThread("Discovery in progress...", Color.HotPink)
        discoveredPrintersListBox.Items.Clear()
        Me.discoveryMethodIndex = discoveryMethodsComboBox.SelectedIndex
        Me.multicastValue = Convert.ToInt32(multicastHopUpDown.Value)
        Me.directedBroadcastAddress = directBroadcastTextBox.Text
        Me.subnetAddress = subnetTextBox.Text
        Dim t As New Thread(AddressOf doDiscovery)
        t.Start()
    End Sub

    Private Sub doDiscovery()
        Select Case (Me.discoveryMethodIndex)
            Case 0
                doMulticast(Me.multicastValue)
            Case 1
                doDirectBroadcast(Me.directedBroadcastAddress)
            Case 2
                doLocalBroadcast()
            Case Else
                doSubnetSearch(Me.subnetAddress)
        End Select
    End Sub

    Private Sub doMulticast(ByVal hops As Integer)
        Try
            Dim printers() As DiscoveredPrinter = NetworkDiscoverer.Multicast(hops)
            displayPrinters(printers)
        Catch ex As DiscoveryException
            handleException(ex.Message)
        End Try
    End Sub

    Private Sub doDirectBroadcast(ByVal directBroadcastRange As String)
        Try
            Dim printers() As DiscoveredPrinter = NetworkDiscoverer.DirectedBroadcast(directBroadcastRange)
            displayPrinters(printers)
        Catch ex As DiscoveryException
            handleException(ex.Message)
        End Try
    End Sub

    Private Sub doLocalBroadcast()
        Try
            Dim printers() As DiscoveredPrinter = NetworkDiscoverer.LocalBroadcast
            displayPrinters(printers)
        Catch ex As DiscoveryException
            handleException(ex.Message)
        End Try
    End Sub

    Private Sub doSubnetSearch(ByVal subnetRange As String)
        Try
            Dim printers() As DiscoveredPrinter = NetworkDiscoverer.SubnetSearch(subnetRange)
            displayPrinters(printers)
        Catch ex As DiscoveryException
            handleException(ex.Message)
        End Try
    End Sub
    Public Sub sendLabel()
        Dim printer As ZebraPrinter = getPrinter()
        If (Not (printer) Is Nothing) Then
            Dim configLabel() As Byte = getConfigLabel(printer.GetPrinterControlLanguage)
            getConnection.Write(configLabel)
            updateGuiFromWorkerThread("Sending Data", Color.CornflowerBlue)
            Thread.Sleep(2000)
        End If
        disconnect()
    End Sub

    Private Function getConfigLabel(ByVal printerLanguage As PrinterLanguage) As Byte()
        Dim configLabel As String = ""
        If (printerLanguage = printerLanguage.ZPL) Then
            configLabel = "^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ"
        ElseIf (printerLanguage = printerLanguage.CPCL) Then
            configLabel = ("! 0 200 200 406 1" & vbCrLf + ("ON-FEED IGNORE" & vbCrLf + ("BOX 20 20 380 380 8" & vbCrLf + ("T 0 6 137 177 TEST" & vbCrLf + "PRINT" & vbCrLf))))
        End If
        Return Encoding.Default.GetBytes(configLabel)
    End Function

    Private Sub doConnectTcp()
        updateGuiFromWorkerThread("Connecting... Please wait...", Color.Goldenrod)
        Try
            connection = New TcpPrinterConnection(Me.ipAddress, Me.portNumber)
            threadedConnect(Me.ipAddress)
            sendLabel()
            disconnect()
        Catch generatedExceptionName As ZebraException
            updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
            doDisconnect()
        End Try
    End Sub

    Private Sub threadedConnect(ByVal addressName As String)
        Try
            connection.Open()
            Thread.Sleep(1000)
        Catch generatedExceptionName As ZebraPrinterConnectionException
            updateGuiFromWorkerThread("Unable to connect with printer", Color.Red)
            disconnect()
        Catch generatedExceptionName As Exception
            updateGuiFromWorkerThread("Error communicating with printer", Color.Red)
            disconnect()
        End Try
        printer = Nothing
        If connection IsNot Nothing AndAlso connection.IsConnected() Then
            Try
                printer = ZebraPrinterFactory.GetInstance(connection)
                Dim pl As PrinterLanguage = printer.GetPrinterControlLanguage
                updateGuiFromWorkerThread(("Printer Language " + pl.ToString), Color.LemonChiffon)
                Thread.Sleep(1000)
                updateGuiFromWorkerThread(("Connected to " + addressName), Color.Green)
                Thread.Sleep(1000)
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

    Public Function getPrinter() As ZebraPrinter
        Return printer
    End Function

    Public Function getConnection() As ZebraPrinterConnection
        Return connection
    End Function

    Private Sub connectButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles connectButton.Click
        updateButtonFromWorkerThread(False)
        ipAddress = CType(discoveredPrintersListBox.SelectedItem, String)
        If ((Not (portTextBox.Text) Is Nothing) _
                    AndAlso (portTextBox.Text <> "")) Then
            portNumber = Convert.ToInt32(portTextBox.Text)
        End If
        Dim t As New Thread(AddressOf doConnectTcp)
        t.Start()
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
        updateButtonFromWorkerThread(True)
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
    End Sub
    ' The following method is called before the form is being closed
    Private Sub DiscoveryDemoMain_closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If connection IsNot Nothing Then
            connection.Close()
        End If
    End Sub
End Class
