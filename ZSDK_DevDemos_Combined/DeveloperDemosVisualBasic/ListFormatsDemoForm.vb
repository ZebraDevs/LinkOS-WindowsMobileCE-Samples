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
Imports System.Drawing
Imports System.Text
Imports ZSDK_API.Printer
Imports System.Threading
Imports ZSDK_API.ApiException


Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
    Partial Public Class ListFormatsDemoForm
        Inherits ZebraForm
        Private Delegate Sub ButtonEnablingEventHandler(ByVal state As Boolean)
        Private Delegate Sub ListBoxEventHandler(ByVal listOfFiles As [String])

        Public Sub New()
            InitializeComponent()
            Me.zebraConnectionPanel = connectionPanel
            AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf connected)
            AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf connectionIsClosed)
        End Sub

        Private Sub connectDisconnectButtonPressed(ByVal sender As Object, ByVal e As EventArgs)
            Invoke(New ButtonEnablingEventHandler(AddressOf toggleButtonEnabled), False)
            fileListPanel.SendToBack()
            If getConnection() IsNot Nothing AndAlso getConnection().IsConnected() Then
                disconnect()
            Else
                connect()
            End If
        End Sub

        Private Sub listFormatsButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            fileListPanel.SendToBack()
            Dim t As New Thread(AddressOf getListOfAllFormats)
            t.Start()
        End Sub

        Private Sub getListOfAllFormats()
            Invoke(New ButtonEnablingEventHandler(AddressOf toggleButtonEnabled), False)
            updateGuiFromWorkerThread("Retrieving Formats...", Color.Gold)
            Dim printer As ZebraPrinter = getPrinter()
            Try
                Dim formats As [String]()
                Dim pl As PrinterLanguage = printer.GetPrinterControlLanguage()
                If pl = PrinterLanguage.ZPL Then
                    formats = New [String]() {"ZPL"}
                Else
                    formats = New [String]() {"FMT", "LBL"}
                End If
                Dim formatNames As [String]() = printer.GetFileUtil().RetrieveFileNames(formats)
                Dim sb As New StringBuilder()
                sb.Append("Printer Format Files:" & vbCr & vbLf)
                For Each formatName As [String] In formatNames
                    sb.Append(vbCr & vbLf & formatName)
                Next
                updateGuiFromWorkerThread("Done Retrieving Formats...", Color.Lime)
                Thread.Sleep(500)
                Invoke(New ListBoxEventHandler(AddressOf displayNames), sb.ToString())
            Catch generatedExceptionName As ZebraException
                updateGuiFromWorkerThread("Error Retrieving Formats", Color.Red)
            End Try
            Invoke(New ButtonEnablingEventHandler(AddressOf toggleButtonEnabled), True)
        End Sub

        Private Sub listFilesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            fileListPanel.SendToBack()
            Dim t As New Thread(AddressOf getListOfAllFiles)
            t.Start()
        End Sub

        Private Sub getListOfAllFiles()
            Invoke(New ButtonEnablingEventHandler(AddressOf toggleButtonEnabled), False)
            updateGuiFromWorkerThread("Retrieving Files...", Color.Gold)
            Dim printer As ZebraPrinter = getPrinter()
            Try
                Dim fileNames As [String]() = printer.GetFileUtil().RetrieveFileNames()
                Dim sb As New StringBuilder()
                sb.Append("All Files:" & vbCr & vbLf)
                For Each fileName As [String] In fileNames
                    sb.Append(vbCr & vbLf & fileName)
                Next
                updateGuiFromWorkerThread("Done Retrieving Files...", Color.Lime)
                Thread.Sleep(500)
                Invoke(New ListBoxEventHandler(AddressOf displayNames), sb.ToString())
            Catch generatedExceptionName As ZebraException
                updateGuiFromWorkerThread("Error Retrieving Files", Color.Red)
            End Try
            Invoke(New ButtonEnablingEventHandler(AddressOf toggleButtonEnabled), True)
        End Sub


        Public Sub toggleButtonEnabled(ByVal state As Boolean)
            connectButton.Enabled = state
            optionsMenu.Enabled = state
        End Sub

        Private Sub displayNames(ByVal listOfFiles As [String])
            fileListPanel.BringToFront()
            filesOnPrinterListBox.Text = listOfFiles
        End Sub

        Private Sub connected()
            Invoke(New PrinterConnectionHandler(AddressOf enableDisconnectButton))
        End Sub

        Private Sub enableDisconnectButton()
            optionsMenu.Enabled = True
            connectButton.Text = "Disconnect"
            connectButton.Enabled = True
        End Sub

        Private Sub connectionIsClosed()
            Invoke(New PrinterConnectionHandler(AddressOf enableConnectButton))
        End Sub

        Private Sub enableConnectButton()
            connectButton.Text = "Connect"
            connectButton.Enabled = True
        End Sub

        Private Sub ListFormatsDemoForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            If getConnection() IsNot Nothing Then
                getConnection().Close()
            End If
        End Sub

    End Class
End Namespace
