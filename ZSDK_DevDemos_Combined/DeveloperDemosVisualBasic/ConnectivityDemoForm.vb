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
Imports ZSDK_API.Printer
Imports System.Text
Imports System.Threading

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
    Partial Public Class ConnectivityDemoForm
        Inherits ZebraForm

        Public Sub New()
            InitializeComponent()
            AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf sendLabel)
            AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf connectionIsClosed)
            zebraConnectionPanel = connectionPanel
        End Sub

        Private Sub connectButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            connect()
        End Sub

        Public Sub sendLabel()
            Dim printer As ZebraPrinter = getPrinter()
            If printer IsNot Nothing Then
                Dim configLabel As Byte() = getConfigLabel(printer.GetPrinterControlLanguage())
                getConnection().Write(configLabel)
                updateGuiFromWorkerThread("Sending Data", Color.CornflowerBlue)
                Thread.Sleep(2000)
            End If
            disconnect()
        End Sub

        Public Sub connectionIsClosed()
            Invoke(New EventHandler(AddressOf updateConnectButton))
        End Sub

        Private Sub updateConnectButton(ByVal sender As Object, ByVal e As EventArgs)
            connectButton.Enabled = True
        End Sub

        Private Function getConfigLabel(ByVal printerLanguage__1 As PrinterLanguage) As Byte()
            Dim configLabel As [String] = ""
            If printerLanguage__1 = PrinterLanguage.ZPL Then
                configLabel = "^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ"
            ElseIf printerLanguage__1 = PrinterLanguage.CPCL Then
                configLabel = "! 0 200 200 406 1" & vbCr & vbLf & "ON-FEED IGNORE" & vbCr & vbLf & "BOX 20 20 380 380 8" & vbCr & vbLf & "T 0 6 137 177 TEST" & vbCr & vbLf & "PRINT" & vbCr & vbLf
            End If
            Return Encoding.[Default].GetBytes(configLabel)
        End Function
    End Class
End Namespace
