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
Imports ZSDK_API.Discovery
Imports System.Threading
Imports ZSDK_API.Printer

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
	Public Partial Class SmartCardDemoForm
		Inherits ZebraForm

		Private Delegate Sub GenericEventHandler()
		Private lastButtonPressed As MenuItem

		Public Sub New()
			AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf connectionIsEstablished)
			AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf connectionIsClosed)
			InitializeComponent()
			zebraConnectionPanel = connectionPanel
			lastButtonPressed = sendCtAtrButton
		End Sub

		Private Sub ConnectedButtonSettings()
			sendCtAtrButton.Enabled = False
			sendCtDataButton.Enabled = False
		End Sub

		Private Sub connectionIsClosed()
			Invoke(New GenericEventHandler(AddressOf NoConnectionButtonSettings))
		End Sub

		Private Sub NoConnectionButtonSettings()
			sendCtAtrButton.Enabled = True
			sendCtDataButton.Enabled = True
		End Sub

		Private Sub sendCtAtrButtonPressed(sender As Object, e As EventArgs)
			handleButtonPressedEvent(sender)
		End Sub

		Private Sub sendCtDataButtonPressed(sender As Object, e As EventArgs)
			handleButtonPressedEvent(sender)
		End Sub

		Private tempResponseString As [String]

		Private Sub handleButtonPressedEvent(sender As Object)
			Invoke(New GenericEventHandler(AddressOf ConnectedButtonSettings))

			Me.tempResponseString = "Waiting for response..."
			Invoke(New GenericEventHandler(AddressOf updateResponseTextBox))
			lastButtonPressed = DirectCast(sender, MenuItem)
			connect()
		End Sub

		Private Sub updateResponseTextBox()
			responseTextBox.Text = Me.tempResponseString
		End Sub

		Private Sub connectionIsEstablished()
			Dim t As New Thread(AddressOf doCommand)
			t.Start()
			t.Join(10000)
			disconnect()
		End Sub

		Private Sub doCommand()
			Dim reader As SmartcardReader = getPrinter().GetSmartcardReader()
			If reader IsNot Nothing Then
				updateGuiFromWorkerThread("Sending Command...", Color.Gold)
                Thread.Sleep(1000)

				Dim smartCardResponse As Byte()

				If lastButtonPressed Is sendCtAtrButton Then
					smartCardResponse = reader.GetATR()
				Else
					smartCardResponse = reader.DoCommand("8010000008")
				End If
				reader.Close()
				formatAndDisplayResponse(smartCardResponse)
			Else
				updateGuiFromWorkerThread("Printer does not support Smartcard reader", Color.Red)
			End If
		End Sub

		Private Sub formatAndDisplayResponse(response As Byte())
			Dim sb As New StringBuilder()

			For Each b As Byte In response
				sb.Append(b.ToString("X2"))
			Next
			Me.tempResponseString = sb.ToString()
			Invoke(New GenericEventHandler(AddressOf updateResponseTextBox))
		End Sub

		Private Sub SmartCardDemoForm_Closing(sender As Object, e As CancelEventArgs)
			If getConnection() IsNot Nothing Then
				getConnection().Close()
			End If
		End Sub
	End Class
End Namespace
