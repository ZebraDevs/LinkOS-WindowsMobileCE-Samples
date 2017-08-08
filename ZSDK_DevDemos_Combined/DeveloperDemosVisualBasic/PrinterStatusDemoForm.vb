'********************************************* 
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
' **********************************************


Imports System
Imports System.Drawing
Imports ZSDK_API.Comm
Imports ZSDK_API.Printer
Imports System.Threading
Imports ZSDK_API.ApiException

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
    Partial Public Class PrinterStatusDemoForm
        Inherits ZebraForm

        Public Sub New()
            InitializeComponent()
            AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf connected)
            AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf disconnected)
            zebraConnectionPanel = connectionPanel
            connectionPanel.BringToFront()
        End Sub

        Private Sub leftSideButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            leftSideButton.Enabled = False
            If leftSideButton.Text.Equals("Connect") Then
                connect()
            Else
                Dim t As New Thread(AddressOf doDisconnect)
                t.Start()
            End If
        End Sub

        Private Sub doDisconnect()
            disconnect()
            Invoke(New EventHandler(AddressOf updateConnectButton))
        End Sub

        Private Sub updateConnectButton(ByVal sender As Object, ByVal e As EventArgs)
            statusPanel.SendToBack()
            leftSideButton.Text = "Connect"
            leftSideButton.Enabled = True
        End Sub
        Private Sub connected()
            Invoke(New EventHandler(AddressOf connectedThread))
        End Sub

        Private Sub disconnected()
            Invoke(New EventHandler(AddressOf updateConnectButton))
        End Sub

        Private Sub connectedThread(ByVal sender As Object, ByVal e As EventArgs)
            statusPanel.BringToFront()
            leftSideButton.Text = "Disconnect"
            leftSideButton.Enabled = True

            Dim t As New Thread(AddressOf statusUpdateThread)
            t.Start()
        End Sub

        Private Sub statusUpdateThread()
            Try
                Dim connection As ZebraPrinterConnection = getConnection()
                Dim printer As ZebraPrinter = ZebraPrinterFactory.GetInstance(connection)
                Dim statusMessages As [String]

                While getConnection() IsNot Nothing AndAlso connection.IsConnected()
                    Dim printerStatus As PrinterStatus = printer.GetCurrentStatus()
                    Dim messages As New PrinterStatusMessages(printerStatus)
                    Dim messagesArray As [String]() = messages.GetStatusMessage()

                    statusMessages = "Ready to Print: " & Convert.ToString(printerStatus.IsReadyToPrint)
                    statusMessages += vbCr & vbLf & "Labels in Batch: " & Convert.ToString(printerStatus.LabelsRemainingInBatch)
                    statusMessages += vbCr & vbLf & "Labels in Buffer: " & Convert.ToString(printerStatus.NumberOfFormatsInReceiveBuffer) & vbCr & vbLf & vbCr & vbLf

                    For Each message As [String] In messagesArray
                        statusMessages += message & vbCr & vbLf
                    Next
                    Invoke(New statusEventHandler(AddressOf updateStatusMessage), statusMessages)
                    Thread.Sleep(4000)
                End While
            Catch generatedExceptionName As ZebraException
                disconnected()
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
            End Try
        End Sub

        Private Delegate Sub statusEventHandler(ByVal statusMessages As [String])

        Private Sub updateStatusMessage(ByVal messages As [String])
            statusMessages.Text = messages
        End Sub

        Private Sub PrinterStatusDemoForm_Closed(ByVal sender As Object, ByVal e As EventArgs)
            disconnect()
        End Sub
    End Class
End Namespace
