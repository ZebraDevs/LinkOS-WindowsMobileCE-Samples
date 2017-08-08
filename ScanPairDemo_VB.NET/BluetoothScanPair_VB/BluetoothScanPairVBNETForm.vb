'
' CONFIDENTIAL AND PROPRIETARY 
'
' The source code and other information contained herein is the confidential and the exclusive property of
' Zebra Technologies Corporation and is subject to the terms and conditions in your end user license agreement.
' This source code, and any other information contained herein, shall not be copied, reproduced, published, 
' displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
' expressly permitted under such license agreement.
' 
' Copyright Zebra Technologies Corporation 2010
'
' ALL RIGHTS RESERVED 
'
' File:   BluetoothScanPairVBNETForm.vb
'
'Descr:  This demo application allows the user to enter a MAC address and then pairs the zebra printer 
'to the windows mobile device using MAC address.
'
' Date: 03/16/2011 

Imports ZSDK_API.Comm
Imports ZSDK_API.ApiException
Imports ZSDK_API.Util.Internal
Imports System.IO
' Commented code of Symbol.dll
'Imports Symbol
'Imports Symbol.Barcode

Public Class BluetoothScanPairVBNETForm
    Private connection As ZebraPrinterConnection
    Private isConnected As Boolean = False

    ' Commented code of Symbol.dll

    'Private MyReader As Symbol.Barcode.Reader = Nothing
    'Private MyReaderData As Symbol.Barcode.ReaderData = Nothing
    'Private MyEventHandler As System.EventHandler = Nothing

    ' The following method is called on loading the form
    Private Sub BluetoothScanPairVBForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Commented code of Symbol.dll

        'If Me.InitReader() Then
        '    Me.StartRead()
        'Else
        '    Me.Close()
        '    Return
        'End If

    End Sub
    '' Commented code of Symbol.dll starts here

    ' This method is called to intialize the symbol reader

    'Private Function InitReader() As Boolean
    '    If Me.MyReader IsNot Nothing Then
    '        Return False
    '    End If
    '    Me.MyReader = New Symbol.Barcode.Reader()
    '    Me.MyReaderData = New Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text, Symbol.Barcode.ReaderDataLengths.MaximumLabel)
    '    Me.MyEventHandler = New EventHandler(AddressOf MyReader_ReadNotify)
    '    Me.MyReader.Actions.Enable()
    '    Me.MyReader.Parameters.Feedback.Success.BeepTime = 0
    '    Me.MyReader.Parameters.Feedback.Success.WaveFile = "\windows\alarm3.wav"
    '    AddHandler Me.Activated, New EventHandler(AddressOf ReaderForm_Activated)
    '    AddHandler Me.Deactivate, New EventHandler(AddressOf ReaderForm_Deactivate)
    '    Return True
    'End Function

    'Private Sub StartRead()
    '    If (Me.MyReader IsNot Nothing) AndAlso (Me.MyReaderData IsNot Nothing) Then
    '        AddHandler Me.MyReader.ReadNotify, Me.MyEventHandler
    '        Me.MyReader.Actions.Read(Me.MyReaderData)
    '    End If
    'End Sub

    'Private Sub MyReader_ReadNotify(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim TheReaderData As Symbol.Barcode.ReaderData = Me.MyReader.GetNextReaderData()
    '    If TheReaderData.Result = Symbol.Results.SUCCESS Then
    '        Me.HandleData(TheReaderData)
    '        Me.StartRead()
    '    End If
    'End Sub

    'Private Sub HandleData(ByVal TheReaderData As Symbol.Barcode.ReaderData)
    '    macAddrBox.Text = TheReaderData.Text
    'End Sub

    'Private Sub ReaderForm_Activated(ByVal sender As Object, ByVal e As EventArgs)
    '    If Not Me.MyReaderData.IsPending Then
    '        Me.StartRead()
    '    End If
    'End Sub

    'Private Sub ReaderForm_Deactivate(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.StopRead()
    'End Sub

    'Private Sub StopRead()
    '    If Me.MyReader IsNot Nothing Then
    '        RemoveHandler Me.MyReader.ReadNotify, Me.MyEventHandler
    '        Me.MyReader.Actions.Flush()
    '    End If
    'End Sub

    '' Symbol code ends here

    ' This method is called when Pair button is clicked. Open a bluetooth connection with printer using MAC address
    Private Sub pairButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pairButton.Click
        If macAddrBox.Text.Length <> 12 Then
            MessageBox.Show("Enter valid MAC address!")
            Return
        End If

        'Creating a bluetooth connection with zebra printer
        If connection Is Nothing AndAlso macAddrBox.Text.Length = 12 Then
            connection = New BluetoothPrinterConnection(macAddrBox.Text)
            statusLabel.Text = "Status: Pairing to..." + macAddrBox.Text
            statusLabel.BackColor = System.Drawing.Color.Gold
            Application.DoEvents()
            Try
                connection.Open()
                While Not connection.IsConnected()
                End While
            Catch generatedExceptionName As ZebraPrinterConnectionException
                statusLabel.Text = "Status: Unpaired"
                statusLabel.BackColor = System.Drawing.Color.Red
                connection = Nothing
                isConnected = False
                MessageBox.Show("Unable to pair with printer.")
                Return
            Catch generatedExceptionName As ZebraException
                statusLabel.BackColor = System.Drawing.Color.Red
                statusLabel.Text = "Status : Unpaired."
                connection = Nothing
                isConnected = False
                MessageBox.Show("Unable to pair with printer." & vbCr & vbLf & "Check that printer is on.")
                Return
            Catch generatedExceptionName As Exception
                statusLabel.BackColor = System.Drawing.Color.Red
                statusLabel.Text = "Status : Unpaired."
                connection = Nothing
                isConnected = False
                MessageBox.Show("Pairing Failed.")
                Return
            End Try
            statusLabel.Text = "Status: Paired to " + macAddrBox.Text
            statusLabel.BackColor = System.Drawing.Color.Green
            isConnected = True
        End If
    End Sub
    ' This method is called when Unpair button is clicked. Close the Bluetooth connection with printer.
    Private Sub unpairButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unpairButton.Click
        Try
            ' Close the connection
            If connection IsNot Nothing Then
                connection.Close()
            End If
        Catch generatedExceptionName As ZebraPrinterConnectionException
            isConnected = False
            MessageBox.Show("Unable to unpair with printer.")
            Return
        Catch generatedExceptionName As ZebraException
            isConnected = False
            MessageBox.Show("Unable to unpair with printer." & vbCr & vbLf & "Check that printer is on.")
            Return
        Catch generatedExceptionName As Exception
            isConnected = False
            MessageBox.Show("Unpair Failed.")
            Return
        End Try
        connection = Nothing
        isConnected = False
        statusLabel.Text = "Status: Unpaired"
        statusLabel.BackColor = System.Drawing.Color.Red
        sendTxtBox.Text = ""
        sendFileBox.Text = ""
    End Sub
    ' This method is called when Quit button is clicked.Close the Bluetooth connection and application.
    Private Sub quitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quitButton.Click
        If connection IsNot Nothing Then
            connection.Close()
        End If

        Me.Dispose()
    End Sub
    ' This method is called when Send File button is clicked. Sends selected file to zebra printer.
    Private Sub sendFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendFileButton.Click
        If False = isConnected Then
            MessageBox.Show("Device not paired!")
            Return
        End If

        If sendFileBox.Text.Length = 0 Then
            MessageBox.Show("Please Select file to print!!!")
            Return
        End If
        ' Read file content, convert into bytes and send it to zebra printer.
        If connection IsNot Nothing AndAlso sendFileBox.Text IsNot Nothing Then
            Try
                Dim fs As FileStream = File.OpenRead(sendFileBox.Text)
                Dim data As Byte() = New Byte(fs.Length - 1) {}
                fs.Read(data, 0, data.Length)
                connection.Write(data)
                fs.Close()
            Catch generatedExceptionName As ZebraPrinterConnectionException
                isConnected = False
                connection = Nothing
                MessageBox.Show("Unable to send file!!!" & vbCr & vbLf & "Check that printer is connected.")
                Return
            Catch generatedExceptionName As ZebraException
                isConnected = False
                connection = Nothing
                MessageBox.Show("Unable to send file!!!." & vbCr & vbLf & "Check that printer is on.")
                Return
            Catch generatedExceptionName As Exception
                isConnected = False
                connection = Nothing
                MessageBox.Show("Send file Failed.")
                Return
            End Try
        End If
    End Sub
    ' This method is called when Browse button is clicked. Opens file dialog to select a file.
    Private Sub browseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseButton.Click
        Dim ofd As New OpenFileDialog()
        If ofd.ShowDialog() = DialogResult.OK Then
            sendFileBox.Text = ofd.FileName
        Else
            sendFileBox.Text = Nothing
        End If
    End Sub
    ' This method is called when Send Text button is clicked.Sends raw text to zebra printer.
    Private Sub sendTxtButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendTxtButton.Click
        Dim printString As [String] = ""
        If False = isConnected Then
            MessageBox.Show("Device not paired!")
            Return
        End If

        If sendTxtBox.Text.Length = 0 Then
            MessageBox.Show("Please Enter text to print!!!")
            Return
        End If

        If connection IsNot Nothing AndAlso sendTxtBox.Text.Length <> 0 Then
            Try
                printString = "! 0 200 200 500 1" & vbCr & vbLf & "LABEL" & vbCr & vbLf & "PAGE-WIDTH 600" & vbCr & vbLf
                printString += "T 7 0 125 158 "
                printString += sendTxtBox.Text
                printString += vbCr & vbLf
                printString += "PRINT" & vbCr & vbLf
                connection.Write(StringUtilities.GetBytes(printString))
            Catch generatedExceptionName As ZebraPrinterConnectionException
                isConnected = False
                connection = Nothing
                MessageBox.Show("Unable to send text!!!" & vbCr & vbLf & "Check that printer is connected.")
                Return
            Catch generatedExceptionName As ZebraException
                isConnected = False
                connection = Nothing
                MessageBox.Show("Unable to send text!!!." & vbCr & vbLf & "Check that printer is on.")
                Return
            Catch generatedExceptionName As Exception
                isConnected = False
                connection = Nothing
                MessageBox.Show("Send text Failed.")
                Return
            End Try
        End If
    End Sub

    Private Sub BluetoothScanPairVBForm_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If connection IsNot Nothing Then
            connection.Close()
        End If
    End Sub
End Class
