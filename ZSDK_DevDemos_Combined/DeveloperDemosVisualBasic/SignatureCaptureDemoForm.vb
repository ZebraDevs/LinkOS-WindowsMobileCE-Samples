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
Imports System.Linq
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
	Public Partial Class SignatureCaptureDemoForm
		Inherits ZebraForm

		Private Delegate Sub GenericEventHandler()
		Private isMouseDown As Boolean = False
		Private lastPointX As Integer = -1
		Private lastPointY As Integer = -1
		Private b As Bitmap
		Private g As Graphics
		Private pen As Pen


		Public Sub New()
			AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf connectionIsEstablished)
			AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf connectionIsClosed)
			InitializeComponent()
			zebraConnectionPanel = connectionPanel
			b = New Bitmap(signatureBox.Width, signatureBox.Height)
			g = Graphics.FromImage(b)
			g.Clear(Color.White)
			signatureBox.Image = b
			pen = New Pen(Color.Black, 2)
		End Sub

		Private Sub connectionIsEstablished()
			Invoke(New GenericEventHandler(AddressOf ConnectedButtonSettings))
		End Sub

		Private Sub ConnectedButtonSettings()
			connectButton.Text = "Disconnect"
			connectButton.Enabled = True
			printButton.Enabled = True
		End Sub

		Private Sub connectionIsClosed()
			Invoke(New GenericEventHandler(AddressOf NoConnectionButtonSettings))
		End Sub

		Private Sub NoConnectionButtonSettings()
			connectButton.Text = "Connect"
			connectButton.Enabled = True
			printButton.Enabled = False
		End Sub

		Private Sub connectButton_Click(sender As Object, e As EventArgs)
			If connectButton.Text.Equals("Connect") Then
				connect()
			Else
				disconnect()
			End If
		End Sub

		Private bitmapToPrint As Bitmap

		Private Sub printButton_Click(sender As Object, e As EventArgs)
			Me.bitmapToPrint = DirectCast(b.Clone(), Bitmap)

			Dim t As New Thread(AddressOf doPrintImage)
			t.Start()

			g.Clear(Color.White)
			signatureBox.Invalidate()
		End Sub

		Private Sub doPrintImage()
			getPrinter().GetGraphicsUtil().PrintImage(Me.bitmapToPrint, 0, 0, Me.bitmapToPrint.Width, Me.bitmapToPrint.Height, False)
		End Sub

		Private Sub signatureBox_MouseDown(sender As Object, e As MouseEventArgs)
			isMouseDown = True
			lastPointX = e.X
			lastPointY = e.Y
		End Sub

		Private Sub signatureBox_MouseMove(sender As Object, e As MouseEventArgs)
			If isMouseDown Then
				g.DrawLine(pen, lastPointX, lastPointY, e.X, e.Y)
				signatureBox.Invalidate()
				lastPointX = e.X
				lastPointY = e.Y
			End If
		End Sub

		Private Sub signatureBox_MouseUp(sender As Object, e As MouseEventArgs)
			isMouseDown = False
		End Sub
	End Class
End Namespace
