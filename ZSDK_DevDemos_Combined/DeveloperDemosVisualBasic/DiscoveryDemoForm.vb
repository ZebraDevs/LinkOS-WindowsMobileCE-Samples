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
Imports ZSDK_API.Discovery
Imports System.Threading
Imports ZSDK_API.ApiException

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
	Public Partial Class DiscoveryDemoForm
		Inherits Form

		Public Sub New()
			InitializeComponent()
			discoveryMethodsComboBox.SelectedIndex = discoveryMethodsComboBox.Items.IndexOf("Multicast")
		End Sub

		Private Sub discoveryMethodsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim methodSelection As Integer = discoveryMethodsComboBox.SelectedIndex
			Select Case methodSelection
				Case 0
					showMulticastPanel()
					Exit Select
				Case 1
					showDirectBroadcastPanel()
					Exit Select
				Case 3
					showSubnetPanel()
					Exit Select
				Case Else
					hidePanels()
					Exit Select
			End Select
		End Sub

		Private Sub showMulticastPanel()
			directBroadcastPanel.Visible = False
			subnetPanel.Visible = False
			multicastPanel.Visible = True
		End Sub

		Private Sub showDirectBroadcastPanel()
			directBroadcastPanel.Visible = True
			subnetPanel.Visible = False
			multicastPanel.Visible = False
		End Sub

		Private Sub showSubnetPanel()
			directBroadcastPanel.Visible = False
			subnetPanel.Visible = True
			multicastPanel.Visible = False
		End Sub

		Private Sub hidePanels()
			directBroadcastPanel.Visible = False
			subnetPanel.Visible = False
			multicastPanel.Visible = False
		End Sub

		Private discoveryMethodIndex As Integer
		Private multicastValue As Integer
		Private directedBroadcastAddress As [String]
		Private subnetAddress As [String]

		Private Sub discoverButtonClicked(sender As Object, e As EventArgs)
			discoveryButton.Enabled = False
			updateGuiFromWorkerThread("Discovery in progress...", Color.HotPink)
			discoveredPrintersListBox.Items.Clear()

			Me.discoveryMethodIndex = discoveryMethodsComboBox.SelectedIndex
			Me.multicastValue = Convert.ToInt32(multicastHopUpDown.Value)
			Me.directedBroadcastAddress = directBroadcastTextBox.Text
			Me.subnetAddress = subnetTextBox.Text

			Dim t As New Thread(AddressOf doDiscovery)
			t.Start()
		End Sub

		Private Sub doDiscovery()
			Select Case Me.discoveryMethodIndex
				Case 0
					doMulticast(Me.multicastValue)
					Exit Select
				Case 1
					doDirectBroadcast(Me.directedBroadcastAddress)
					Exit Select
				Case 2
					doLocalBroadcast()
					Exit Select
				Case 3
					doSubnetSearch(Me.subnetAddress)
					Exit Select
				Case Else
					doBluetoothDiscovery()
					Exit Select
			End Select
		End Sub

		Private Sub doMulticast(hops As Integer)
			Try
				Dim printers As DiscoveredPrinter() = NetworkDiscoverer.Multicast(hops)
				displayPrinters(printers)
			Catch ex As DiscoveryException
				handleException(ex.Message)
			End Try
		End Sub

		Private Sub doDirectBroadcast(directBroadcastRange As [String])
			Try
				Dim printers As DiscoveredPrinter() = NetworkDiscoverer.DirectedBroadcast(directBroadcastRange)
				displayPrinters(printers)
			Catch ex As DiscoveryException
				handleException(ex.Message)
			End Try
		End Sub

		Private Sub doLocalBroadcast()
			Try
				Dim printers As DiscoveredPrinter() = NetworkDiscoverer.LocalBroadcast()
				displayPrinters(printers)
			Catch ex As DiscoveryException
				handleException(ex.Message)
			End Try
		End Sub

		Private Sub doSubnetSearch(subnetRange As [String])
			Try
				Dim printers As DiscoveredPrinter() = NetworkDiscoverer.SubnetSearch(subnetRange)
				displayPrinters(printers)
			Catch ex As DiscoveryException
				handleException(ex.Message)
			End Try
		End Sub

		Private Sub doBluetoothDiscovery()
			Try
                displayPrinters(BluetoothDiscoverer.FindPrinters())
			Catch ex As DiscoveryException
                handleException(ex.Message)
            Catch ex1 As ZebraGeneralException
                handleException("Bluetooth not available")
            End Try
		End Sub

		Private Sub handleException(message As [String])
			updateGuiFromWorkerThread(message, Color.Red)
			BeginInvoke(New MyProgressEventsHandler(AddressOf UpdateDiscoveredPrinters), New Object() {Me, New DiscoveredPrinter() {}})
		End Sub

		Private Delegate Sub MyProgressEventsHandler(sender As Object, printers As DiscoveredPrinter())

		Private Sub UpdateDiscoveredPrinters(sender As Object, printers As DiscoveredPrinter())
			For Each printer As DiscoveredPrinter In printers
				discoveredPrintersListBox.Items.Add(printer.Address)
			Next
			discoveryButton.Enabled = True
		End Sub

		Private Sub displayPrinters(printers As DiscoveredPrinter())
			updateGuiFromWorkerThread("Discovered " & printers.Length & " printers", Color.Green)
			BeginInvoke(New MyProgressEventsHandler(AddressOf UpdateDiscoveredPrinters), New Object() {Me, printers})
		End Sub

		Public Sub updateGuiFromWorkerThread(message As [String], color As Color)
			Invoke(New StatusEventHandler(AddressOf UpdateUI), New StatusArguments(message, color))
		End Sub

		Private Delegate Sub StatusEventHandler(e As StatusArguments)

		Private Sub UpdateUI(e As StatusArguments)
			statusBar.Text = e.message
			statusBar.BackColor = e.color
		End Sub

        Private Class StatusArguments
            Inherits System.EventArgs
            Public message As [String]
            Public color As Color

            Public Sub New(ByVal message As [String], ByVal color As Color)
                Me.message = message
                Me.color = color
            End Sub
        End Class
	End Class
End Namespace
