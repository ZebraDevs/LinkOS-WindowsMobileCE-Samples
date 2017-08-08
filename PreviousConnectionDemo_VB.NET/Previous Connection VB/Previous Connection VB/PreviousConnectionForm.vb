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
' File:   PreviousConnectionForm.vb
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
Imports System.Xml.Serialization
Imports System.IO
Imports System.Xml

Public Class PreviousConnectionForm
    Private macAddress As [String]
    Dim connection As ZebraPrinterConnection
    Dim printer As ZebraPrinter
    Dim savedPrinters As ArrayList
    Dim sSaveAndRecallMacAddressFileName As [String]
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        savedPrinters = New ArrayList
        sSaveAndRecallMacAddressFileName = "saved_macaddress.xml"
        RetrieveMacAddressFromXML()
    End Sub
    Private Sub connectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectButton.Click
        Me.macAddress = macAddressTextBox.Text.Trim
        Dim t As New Thread(AddressOf doConnectBT)
        t.Start()
    End Sub
    Private Sub disconnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnectButton.Click
        disconnect()
    End Sub
    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
        Dim deleteMacAddress As String
        deleteMacAddress = savedPrintersListBox.SelectedItem.ToString.Trim
        If deleteMacAddress.Equals(macAddressTextBox.Text.ToString.Trim) Then
            macAddressTextBox.Text = ""
        End If
        savedPrinters.Remove(deleteMacAddress)
        UpdateSavedMacAddressXML()
    End Sub
    Private Sub deleteAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteAllButton.Click
        If savedPrinters.Contains(macAddressTextBox.Text) Then
            macAddressTextBox.Text = ""
        End If
        savedPrinters.Clear()
        UpdateSavedMacAddressXML()
    End Sub
    'Check that macAddress is valid
    'Connect to device using BluetoothPrinterConnection class
    Private Sub doConnectBT()
        'for testing
        'AddMacAddressToXML(Me.macAddress)
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
                    AddMacAddressToXML(Me.macAddress)

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

    'Save MAc Address to the file
    Private Sub AddMacAddressToXML(ByVal e As String)
        If Not savedPrinters.Contains(e) Then
            savedPrinters.Add(e)
        End If
        UpdateSavedMacAddressXML()
    End Sub
    ' Update Save Mac Addresses to the XML file
    Private Sub UpdateSavedMacAddressXML()
        If File.Exists(sSaveAndRecallMacAddressFileName) Then
            File.Delete(sSaveAndRecallMacAddressFileName)
        End If
        Try
            Dim ser As New XmlSerializer(savedPrinters.GetType)
            Dim writer As Stream = New FileStream(sSaveAndRecallMacAddressFileName, FileMode.Create)
            ser.Serialize(writer, savedPrinters)
            writer.Close()
            updateListFromWorkerThread(savedPrinters)
        Catch e As Exception
            Console.WriteLine(e.Message)
            MessageBox.Show(e.Message)
        End Try
    End Sub
    'Retrieve Saved MacAddress XML file and read it into printers Listbox
    Private Sub RetrieveMacAddressFromXML()
        If File.Exists(sSaveAndRecallMacAddressFileName) Then
            ' Create an instance of the XmlSerializer specifying type and namespace.
            Dim serializer As New XmlSerializer(savedPrinters.GetType)
            ' A FileStream is needed to read the XML document.
            Dim fs As New FileStream(sSaveAndRecallMacAddressFileName, FileMode.Open)
            Dim reader As New XmlTextReader(fs)
            savedPrinters.Clear()
            ' Use the Deserialize method to restore the object's state.
            savedPrinters = CType(serializer.Deserialize(reader), ArrayList)
            updateListFromWorkerThread(savedPrinters)
            fs.Close()
            reader.Close()
        End If
    End Sub
    ' The following methods update the discovered printers listbox
    Private Sub handleException(ByVal message As [String])
        updateGuiFromWorkerThread(message, Color.Red)
    End Sub
    ' The following methods update the status bar at top of screen
    Public Sub updateListFromWorkerThread(ByVal e As ArrayList)
        Invoke(New UpdateListEventHandler(AddressOf UpdateListSavedPritners), e)
    End Sub
    'Delegate for the update list event handler
    Private Delegate Sub UpdateListEventHandler(ByVal e As ArrayList)
    ' Show Saved printers in ListBox
    Private Sub UpdateListSavedPritners(ByVal e As ArrayList)
        savedPrintersListBox.Items.Clear()
        For Each printer As String In e
            savedPrintersListBox.Items.Add(printer)
        Next
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
        connectButton.Enabled = enabled
        disconnectButton.Enabled = enabled
    End Sub
    ' The following method is called before the form is being closed
    Private Sub PreviousConnectionForm_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If connection IsNot Nothing Then
            connection.Close()
        End If
    End Sub
    Private Sub savedPrintersListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savedPrintersListBox.SelectedIndexChanged
        macAddressTextBox.Text = savedPrintersListBox.SelectedItem
    End Sub
End Class
