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
Imports System.Threading
Imports ZSDK_API.Printer

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
	Public Partial Class MagCardDemoForm
		Inherits ZebraForm

		Public Sub New()
			AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf connectionIsEstablished)
			AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf connectionIsClosed)
			InitializeComponent()
			zebraConnectionPanel = connectionPanel
		End Sub

		Private Sub doConnect(sender As Object, e As EventArgs)
			If connectButton.Text.Equals("Connect") Then
				connectButton.Enabled = False
				connect()
			Else
				disconnect()
			End If
		End Sub

		Private Sub magCardButtonPressed(sender As Object, e As EventArgs)
			readMagCardButton.Enabled = False
			Dim t As New Thread(AddressOf doReadMagCard)
			t.Start()
		End Sub

		Private Sub doReadMagCard()
			updateGuiFromWorkerThread("Waiting for swipe...", Color.Gold)
			Dim printer As ZebraPrinter = getPrinter()
			If printer IsNot Nothing Then
				Dim mcr As MagCardReader = printer.GetMagCardReader()
				If mcr IsNot Nothing Then
					Dim tracks As [String]() = mcr.Read(10 * 1000)
					updateGuiTracks(tracks)
					updateGuiFromWorkerThread("Done", Color.Blue)
				Else
					updateGuiFromWorkerThread("Failed to swipe", Color.Red)
				End If
			Else
				updateGuiFromWorkerThread("Connection error", Color.Red)
			End If
		End Sub

		Private Delegate Sub MagCardEventHandler(e As [String]())
		Public Sub updateGuiTracks(tracks As [String]())
			Dim pList As Object() = {tracks}
			Invoke(New MagCardEventHandler(AddressOf UpdateUI), pList)
		End Sub

		Private Sub UpdateUI(tracks As [String]())
			track1Value.Text = tracks(0)
			track2Value.Text = tracks(1)
			track3Value.Text = tracks(2)
			readMagCardButton.Enabled = True
		End Sub

		Private Delegate Sub GenericEventHandler()
		Private Sub connectionIsEstablished()
			Invoke(New GenericEventHandler(AddressOf ConnectedButtonSettings))
		End Sub

		Private Sub ConnectedButtonSettings()
			connectButton.Text = "Disconnect"
			connectButton.Enabled = True
			readMagCardButton.Enabled = True
		End Sub

		Private Sub connectionIsClosed()
			Invoke(New GenericEventHandler(AddressOf NoConnectionButtonSettings))
		End Sub

		Private Sub NoConnectionButtonSettings()
			connectButton.Text = "Connect"
			connectButton.Enabled = True
			readMagCardButton.Enabled = False
		End Sub

		Private Sub MagCardDemoForm_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs)
			If getConnection() IsNot Nothing Then
				getConnection().Close()
			End If
		End Sub
	End Class
End Namespace
