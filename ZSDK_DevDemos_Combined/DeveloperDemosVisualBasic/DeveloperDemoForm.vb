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
Imports System.Windows.Forms
Imports System.Reflection

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
    Partial Public Class DeveloperDemoForm
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub connectivityDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim connectivityDemoForm As New ConnectivityDemoForm()
            connectivityDemoForm.ShowDialog()
        End Sub

        Private Sub discoveryDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim discoveryDemoForm As New DiscoveryDemoForm()
            discoveryDemoForm.ShowDialog()
        End Sub

        Private Sub listFormatsDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim listFormatsDemoForm As New ListFormatsDemoForm()
            listFormatsDemoForm.ShowDialog()
        End Sub

        Private Sub sendFileDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim sendFileDemoForm As New SendFileDemoForm()
            sendFileDemoForm.ShowDialog()
        End Sub

        Private Sub storedFormatDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim storedFormatDemoForm As New StoredFormatDemoForm()
            storedFormatDemoForm.ShowDialog()
        End Sub

        Private Sub imagePrintDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim imagePrintDemoForm As New ImagePrintDemoForm()
            imagePrintDemoForm.ShowDialog()
        End Sub

        Private Sub magCardDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim magCardDemoForm As New MagCardDemoForm()
            magCardDemoForm.ShowDialog()
        End Sub

        Private Sub smartCardDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim smartCardDemoForm As New SmartCardDemoForm()
            smartCardDemoForm.ShowDialog()
        End Sub

        Private Sub printerStatusDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim printerStatusDemoForm As New PrinterStatusDemoForm()
            printerStatusDemoForm.ShowDialog()
        End Sub

        Private Sub signatureCaptureDemoButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim sigCaptureDemoForm As New SignatureCaptureDemoForm()
            sigCaptureDemoForm.ShowDialog()
        End Sub

        Private Function getTitle() As [String]
            Dim customAttribs As [Object]() = Assembly.GetExecutingAssembly().GetCustomAttributes(False)
            For Each attrib As [Object] In customAttribs
                If TypeOf attrib Is AssemblyDescriptionAttribute Then
                    Return DirectCast(attrib, AssemblyDescriptionAttribute).Description
                End If
            Next
            Return "Developer Demos"
        End Function
    End Class
End Namespace
