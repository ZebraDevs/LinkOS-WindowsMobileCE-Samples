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
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports ZSDK_API.ApiException
Imports ZSDK_API.Comm
Imports ZSDK_API.Printer
Imports System.Text

Namespace ZebraDeveloperDemos
    <System.ComponentModel.DesignerCategory("Code")> _
    Partial Public Class StoredFormatDemoForm
        Inherits ZebraForm

        Private labels As New List(Of Label)()
        Private userInputVars As New List(Of TextBox)()

        Private Delegate Sub GenericEventHandler()

        Public Sub New()
            InitializeComponent()
            connectionPanel.BringToFront()
            zebraConnectionPanel = connectionPanel
            AddHandler connectionEstablished, (AddressOf Connected)
            AddHandler connectionClosed, (AddressOf Disconnected)
        End Sub

        Private Sub leftSideButtonPressed(ByVal sender As Object, ByVal e As EventArgs)
            If leftSideButton.Text.Equals("Back") Then
                leftSideButton.Enabled = False
                RemoveVariableFields()
                formatListPanel.BringToFront()
                Invoke(New GenericEventHandler(AddressOf ConnectedButtonSettings))
            ElseIf leftSideButton.Text.Equals("Disconnect") Then
                toggleMenuButtons(False)
                connectionPanel.BringToFront()
                disconnect()
            End If
        End Sub

        Private Sub RemoveVariableFields()
            SuspendLayout()
            For i As Integer = 0 To labels.Count - 1
                varFieldPanel.Controls.Remove(labels(i))
                labels(i).Dispose()
                varFieldPanel.Controls.Remove(userInputVars(i))
                userInputVars(i).Dispose()
            Next
            quantity.Value = 1
            labels.Clear()
            labels.TrimExcess()
            userInputVars.Clear()
            userInputVars.TrimExcess()
            varFieldPanel.AutoScrollPosition = New Point(0, 0)
            ResumeLayout(False)
        End Sub

        Private Sub Connected()
            Invoke(New GenericEventHandler(AddressOf ConnectedButtonSettings))
            Invoke(New GenericEventHandler(AddressOf DisplayFormatsThread))
        End Sub

        Private Sub ConnectedButtonSettings()
            formatListPanel.BringToFront()
            leftSideButton.Text = "Disconnect"
            rightSideButton.Text = "Refresh"
            toggleMenuButtons(True)
        End Sub

        Private Sub Disconnected()
            Invoke(New GenericEventHandler(AddressOf NoConnectionButtonSettings))
        End Sub

        Private Sub NoConnectionButtonSettings()
            rightSideButton.Text = "List Formats"
            rightSideButton.Enabled = True
            leftSideButton.Text = ""
            leftSideButton.Enabled = False
        End Sub


        Private Sub DisplayFormatsThread()
            formatListPanel.BringToFront()
            Dim t As New Thread(AddressOf doDisplayFormatsThread)
            t.Start()
        End Sub

        Private Sub doDisplayFormatsThread()
            Try
                GetListOfFormats()
            Catch generatedExceptionName As ZebraException
                Invoke(New GenericEventHandler(AddressOf bringConnectionPanelToFront))
                updateGuiFromWorkerThread("COMM Error! Disconnected", Color.Red)
            End Try
        End Sub

        Private Sub bringConnectionPanelToFront()
            connectionPanel.BringToFront()
        End Sub

        Private Delegate Sub FormatListEventHandler(ByVal formatList As List(Of [String]))

        Private Sub GetListOfFormats()
            Dim connection As ZebraPrinterConnection = getConnection()
            Dim printer As ZebraPrinter = ZebraPrinterFactory.GetInstance(connection)

            Dim zplFormatExtensions As [String]() = New [String]() {"ZPL"}
            Dim cpclFormatExtensions As [String]() = New [String]() {"FMT", "LBL"}
            Dim extensions As [String]() = If(printer.GetPrinterControlLanguage() = PrinterLanguage.ZPL, zplFormatExtensions, cpclFormatExtensions)

            Dim formatList As New List(Of [String])()
            For Each format As [String] In printer.GetFileUtil().RetrieveFileNames(extensions)
                formatList.Add(format)
            Next
            Invoke(New FormatListEventHandler(AddressOf DisplayNames), New Object() {formatList})
        End Sub

        Private Sub DisplayNames(ByVal formatList As List(Of [String]))
            formatListBox.DataSource = formatList
            formatListBox.Refresh()
            formatSelectButton.Enabled = True
            toggleMenuButtons(True)
        End Sub

        Private Sub rightSideButtonPressed(ByVal sender As Object, ByVal e As EventArgs)
            toggleMenuButtons(False)
            If rightSideButton.Text.Equals("List Formats") Then
                connect()
            ElseIf rightSideButton.Text.Equals("Print") Then
                SendLabelsToPrinter()
                toggleMenuButtons(True)
            ElseIf rightSideButton.Text.Equals("Refresh") Then
                formatSelectButton.Enabled = False
                formatListBox.DataSource = Nothing
                Invoke(New GenericEventHandler(AddressOf DisplayFormatsThread))
            End If
        End Sub

        Private Sub SendLabelsToPrinter()
            Dim varFieldNames As FieldDescriptionData() = GetVarFieldNames()
            Dim fieldNumbersAndNames As New Dictionary(Of Integer, [String])()
            For i As Integer = 0 To labels.Count - 1
                Dim fnNumber As Integer = varFieldNames(i).FieldNumber
                fieldNumbersAndNames(fnNumber) = userInputVars(i).Text
            Next
            PrintLabels(formatListBox.SelectedItem.ToString(), fieldNumbersAndNames, Convert.ToInt32(quantity.Value))
            printJobSentPanel.BringToFront()
        End Sub

        Private formatName As [String]
        Private fieldNumbersAndNames As Dictionary(Of Integer, [String])
        Private numLabels As Integer

        Private Sub PrintLabels(ByVal formatName As [String], ByVal fieldNumbersAndNames As Dictionary(Of Integer, [String]), ByVal qty As Integer)
            Me.formatName = formatName
            Me.fieldNumbersAndNames = fieldNumbersAndNames
            Me.numLabels = qty

            Dim t As New Thread(AddressOf doPrintLabels)
            t.Start()
        End Sub

        Private Sub doPrintLabels()
            For i As Integer = 0 To Me.numLabels - 1
                getPrinter().GetFormatUtil().PrintStoredFormat(Me.formatName, Me.fieldNumbersAndNames, "utf-8")
            Next
        End Sub

        Private Sub formatSelectButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            If formatListBox.SelectedItem IsNot Nothing Then
                RemoveVariableFields()
                SuspendLayout()
                Invoke(New GenericEventHandler(AddressOf BackAndPrintButtonUpdate))
                Dim varFieldNames As FieldDescriptionData() = GetVarFieldNames()

                titleLabel.Text = "Format " & formatListBox.SelectedItem.ToString() & ":"

                For i As Integer = 0 To varFieldNames.Length - 1
                    Dim labelText As [String] = If(varFieldNames(i).FieldName Is Nothing, Convert.ToString(varFieldNames(i).FieldNumber), varFieldNames(i).FieldName)
                    Dim label As New Label()
                    label.Text = labelText & " :"
                    labels.Add(label)
                    userInputVars.Add(New TextBox())
                Next

                layoutVariables()
                ResumeLayout(False)
            End If
        End Sub

        Private Sub layoutVariables()
            Const HorizontalPositionOfLabelStart As Integer = 21
            Const VerticalPositionOfLabelStart As Integer = 55
            Const SpacingBetweenGuiElements As Integer = 30
            For i As Integer = 0 To labels.Count - 1
                labels(i).Location = New Point(HorizontalPositionOfLabelStart, VerticalPositionOfLabelStart + (i * SpacingBetweenGuiElements))
                labels(i).Size = New Size(65, 20)
                userInputVars(i).Location = New Point(HorizontalPositionOfLabelStart + 80, VerticalPositionOfLabelStart + (i * SpacingBetweenGuiElements))
                userInputVars(i).Size = New Size(120, 20)
            Next

            Dim verticalLoc As Integer = VerticalPositionOfLabelStart + (labels.Count * SpacingBetweenGuiElements)
            quantityLabel.Location = New Point(HorizontalPositionOfLabelStart, verticalLoc + 5)
            quantity.Location = New Point(HorizontalPositionOfLabelStart + 110, verticalLoc)

            AutoScaleDimensions = New SizeF(96.0F, 96.0F)

            For i As Integer = 0 To labels.Count - 1
                varFieldPanel.Controls.Add(labels(i))
                varFieldPanel.Controls.Add(userInputVars(i))
            Next
        End Sub

        Private Sub BackAndPrintButtonUpdate()
            varFieldPanel.BringToFront()
            leftSideButton.Text = "Back"
            rightSideButton.Text = "Print"
        End Sub

        Private Function GetVarFieldNames() As FieldDescriptionData()
            Dim formatName As [String] = formatListBox.SelectedItem.ToString()
            Dim fieldNames As FieldDescriptionData() = New FieldDescriptionData() {}
            Try
                Dim printer As ZebraPrinter = getPrinter()
                Dim formatData As Byte() = printer.GetFormatUtil().RetrieveFormatFromPrinter(formatName)
                Dim formatString As [String] = Encoding.UTF8.GetString(formatData, 0, formatData.Length)
                fieldNames = printer.GetFormatUtil().GetVariableFields(formatString)
            Catch generatedExceptionName As ZebraPrinterConnectionException
                updateGuiFromWorkerThread("Communication Error", Color.Red)
            End Try
            Return fieldNames
        End Function

        Private Sub toggleMenuButtons(ByVal state As Boolean)
            rightSideButton.Enabled = state
            leftSideButton.Enabled = state

        End Sub

        Private Sub reprintButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            SendLabelsToPrinter()
        End Sub

        Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Close()
        End Sub

        Private Sub backToListFormatsButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            ConnectedButtonSettings()
        End Sub

        Private Sub reEnterDataButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            varFieldPanel.BringToFront()
        End Sub

        Private Sub StoredFormatDemoForm_Closing(ByVal sender As Object, ByVal e As CancelEventArgs)
            If getConnection() IsNot Nothing Then
                getConnection().Close()
            End If
            RemoveVariableFields()
        End Sub

    End Class
End Namespace
