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
Imports System.IO
Imports ZSDK_API.Printer
Imports System.Text
Imports System.Threading

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
    Partial Public Class SendFileDemoForm
        Inherits ZebraForm

        Public Sub New()
            InitializeComponent()
            AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf connected)
            AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf disconnected)
            zebraConnectionPanel = connectionPanel
        End Sub

        Private Sub connectButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            connectButton.Enabled = False
            connect()
        End Sub

        Private Sub connected()
            updateGuiFromWorkerThread("Sending file...", Color.Plum)
            Invoke(New EventHandler(AddressOf sendFile))
            disconnect()
        End Sub

        Private Sub disconnected()
            Invoke(New EventHandler(AddressOf updateConnectButton))
        End Sub

        Private Sub updateConnectButton(ByVal sender As Object, ByVal e As EventArgs)
            connectButton.Enabled = True
        End Sub

        Private Sub sendFile(ByVal sender As Object, ByVal e As EventArgs)
            Dim filePath As String = "\TEMP\TEST.LBL"
            Try
                createFile(filePath)
                Thread.Sleep(500)
                getPrinter().GetFileUtil().SendFileContents(filePath)
            Catch e1 As IOException
                updateGuiFromWorkerThread(e1.Message, Color.Red)
            End Try
        End Sub

        Private Sub createFile(ByVal filePath As String)
            Dim printer As ZebraPrinter = getPrinter()
            Dim printerLang As PrinterLanguage = printer.GetPrinterControlLanguage()

            If File.Exists(filePath) Then
                File.Delete(filePath)
            End If

            Using fileStream As FileStream = File.Open(filePath, FileMode.OpenOrCreate)
                If printerLang.Equals(PrinterLanguage.ZPL) Then
                    Dim zplLabel As [Byte]() = Encoding.[Default].GetBytes("^XA^FO17,16^GB379,371,8^FS^FT65,255^A0N,135,134^FDTEST^FS^XZ")
                    fileStream.Write(zplLabel, 0, zplLabel.Length)
                ElseIf printerLang.Equals(PrinterLanguage.CPCL) Then
                    Dim cpclLabel As [Byte]() = Encoding.[Default].GetBytes("! 0 200 200 406 1" & vbCr & vbLf & "ON-FEED IGNORE" & vbCr & vbLf & "BOX 20 20 380 380 8" & vbCr & vbLf & "T 0 6 137 177 TEST" & vbCr & vbLf & "PRINT" & vbCr & vbLf)
                    fileStream.Write(cpclLabel, 0, cpclLabel.Length)
                End If
                fileStream.Close()
            End Using
        End Sub
    End Class
End Namespace
