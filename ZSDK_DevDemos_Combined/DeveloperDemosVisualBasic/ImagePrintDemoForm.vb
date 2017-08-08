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
Imports System.Windows.Forms
Imports Microsoft.WindowsMobile.Forms
Imports ZSDK_API.ApiException

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
	Public Partial Class ImagePrintDemoForm
		Inherits ZebraForm

		Private Delegate Sub GenericEventHandler()
		Private Delegate Sub MenuEventHandler(state As Boolean)

		Public Sub New()
			InitializeComponent()
			AddHandler connectionEstablished, New PrinterConnectionHandler(AddressOf Connected)
			AddHandler connectionClosed, New PrinterConnectionHandler(AddressOf Disconnected)

			connectionPanel.BringToFront()
			zebraConnectionPanel = connectionPanel
		End Sub

        Private Sub cameraButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("After taking the photo, some devices require exiting the Camera App for the image to be sent to the printer.", "Note:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)

            Dim cam As New CameraCaptureDialog()
            cam.Owner = Me
            Try
                Dim result As DialogResult = cam.ShowDialog()
                If result = DialogResult.OK Then
                    printImage(cam.FileName)
                End If
            Catch generatedExceptionName As Exception
                updateGuiFromWorkerThread("Camera error or no camera", Color.Red)
            End Try

        End Sub

        Private Sub cameraButton_Click_CE_Device(ByVal sender As Object, ByVal e As EventArgs)
            updateGuiFromWorkerThread("No Camera available", Color.Red)
        End Sub

        Private storeImage As Boolean
        Private destinationOnPrinter As [String]
        Private filePath As [String]

        Private Sub printImage(ByVal filePath As [String])
            screenPanel.BringToFront()
            Me.storeImage = storeImageOnPrinter.Checked
            Me.destinationOnPrinter = fileNameOnPrinterText.Text
            Me.filePath = filePath

            updateGuiFromWorkerThread("Formatting Graphic...", Color.LightBlue)
            connectionPanel.BringToFront()
            Dim t As New Thread(AddressOf doPrintImage)
            t.Start()
        End Sub

        Private Sub doPrintImage()
            Try
                Invoke(New MenuEventHandler(AddressOf toggleMenu), New Object() {False})
                If Me.storeImage Then
                    getPrinter().GetGraphicsUtil().StoreImage(Me.destinationOnPrinter, Me.filePath, 550, 412)
                Else
                    getPrinter().GetGraphicsUtil().PrintImage(Me.filePath, 0, 0, 550, 412, False)
                End If
                updateGuiFromWorkerThread("Sent Graphic", Color.LawnGreen)
            Catch generatedExceptionName As ZebraGeneralException
                updateGuiFromWorkerThread("Error communicating with printer", Color.Red)
            End Try
            Invoke(New MenuEventHandler(AddressOf toggleMenu), New Object() {True})
        End Sub

        Private Sub fileExplorerButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim fDialog As New OpenFileDialog()
            fDialog.Filter = " |*.jpg;*.gif;*.bmp;*.png;*.tif"
            Dim fDialogResult As DialogResult = fDialog.ShowDialog()
            If DialogResult.OK = fDialogResult Then
                printImage(fDialog.FileName())
            End If
        End Sub

        Private Sub connectMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
            toggleMenu(False)
            If connectMenu.Text.Equals("Connect") Then
                connect()
            Else
                disconnect()
            End If
        End Sub

        Private Sub Connected()
            Invoke(New GenericEventHandler(AddressOf SetMenuStateAfterConnecting))
        End Sub

        Private Sub SetMenuStateAfterConnecting()
            connectMenu.Text = "Disconnect"
            getImageMenu.Enabled = True
            connectMenu.Enabled = True
        End Sub

        Private Sub Disconnected()
            Invoke(New GenericEventHandler(AddressOf SetMenuStateAfterDisconnecting))
        End Sub

        Private Sub SetMenuStateAfterDisconnecting()
            connectMenu.Text = "Connect"
            getImageMenu.Enabled = False
            connectMenu.Enabled = True
        End Sub

        Private Sub toggleMenu(ByVal state As Boolean)
            connectMenu.Enabled = state
            getImageMenu.Enabled = state
        End Sub

        Private Sub ImagePrintDemoForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
            If getConnection() IsNot Nothing Then
                getConnection().Close()
            End If
        End Sub

        Private Sub storeImageOnPrinter_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs)
            If storeImageOnPrinter.Checked = True Then
                fileNameOnPrinterText.Visible = True
                fileNameOnPrinterText.Enabled = True
                fileNameOnPrinterLabel.Visible = True
            Else
                fileNameOnPrinterText.Visible = False
                fileNameOnPrinterText.Enabled = False
                fileNameOnPrinterLabel.Visible = False
            End If
        End Sub
    End Class
End Namespace
