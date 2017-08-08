<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class BluetoothScanPairVBNETForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.statusLabel = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.macAddrBox = New System.Windows.Forms.TextBox
        Me.pairButton = New System.Windows.Forms.Button
        Me.unpairButton = New System.Windows.Forms.Button
        Me.sendTxtBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.sendFileBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.browseButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.sendFileButton = New System.Windows.Forms.Button
        Me.sendTxtButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.Color.Red
        Me.statusLabel.Location = New System.Drawing.Point(0, 0)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(240, 20)
        Me.statusLabel.Text = "Status: Unpaired"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 20)
        Me.Label2.Text = "Scan the MAC Address and Click Pair:"
        '
        'macAddrBox
        '
        Me.macAddrBox.Location = New System.Drawing.Point(3, 44)
        Me.macAddrBox.Name = "macAddrBox"
        Me.macAddrBox.Size = New System.Drawing.Size(234, 21)
        Me.macAddrBox.TabIndex = 2
        '
        'pairButton
        '
        Me.pairButton.Location = New System.Drawing.Point(3, 68)
        Me.pairButton.Name = "pairButton"
        Me.pairButton.Size = New System.Drawing.Size(72, 20)
        Me.pairButton.TabIndex = 3
        Me.pairButton.Text = "Pair"
        '
        'unpairButton
        '
        Me.unpairButton.Location = New System.Drawing.Point(165, 68)
        Me.unpairButton.Name = "unpairButton"
        Me.unpairButton.Size = New System.Drawing.Size(72, 20)
        Me.unpairButton.TabIndex = 4
        Me.unpairButton.Text = "Unpair"
        '
        'sendTxtBox
        '
        Me.sendTxtBox.Location = New System.Drawing.Point(3, 118)
        Me.sendTxtBox.Name = "sendTxtBox"
        Me.sendTxtBox.Size = New System.Drawing.Size(234, 21)
        Me.sendTxtBox.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(240, 20)
        Me.Label3.Text = "Send plain text to device:"
        '
        'sendFileBox
        '
        Me.sendFileBox.BackColor = System.Drawing.SystemColors.Info
        Me.sendFileBox.Location = New System.Drawing.Point(3, 195)
        Me.sendFileBox.Name = "sendFileBox"
        Me.sendFileBox.Size = New System.Drawing.Size(234, 21)
        Me.sendFileBox.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(0, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 20)
        Me.Label4.Text = "Send file to device:"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(3, 223)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(72, 20)
        Me.browseButton.TabIndex = 13
        Me.browseButton.Text = "Browse"
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(165, 223)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(72, 20)
        Me.quitButton.TabIndex = 15
        Me.quitButton.Text = "Quit"
        '
        'sendFileButton
        '
        Me.sendFileButton.Location = New System.Drawing.Point(84, 223)
        Me.sendFileButton.Name = "sendFileButton"
        Me.sendFileButton.Size = New System.Drawing.Size(72, 20)
        Me.sendFileButton.TabIndex = 14
        Me.sendFileButton.Text = "Send File"
        '
        'sendTxtButton
        '
        Me.sendTxtButton.Location = New System.Drawing.Point(165, 145)
        Me.sendTxtButton.Name = "sendTxtButton"
        Me.sendTxtButton.Size = New System.Drawing.Size(72, 20)
        Me.sendTxtButton.TabIndex = 20
        Me.sendTxtButton.Text = "Send Text"
        '
        'BluetoothScanPairVBForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.sendTxtButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.sendFileButton)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.sendFileBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.sendTxtBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.unpairButton)
        Me.Controls.Add(Me.pairButton)
        Me.Controls.Add(Me.macAddrBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.statusLabel)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "BluetoothScanPairVBForm"
        Me.Text = "Bluetooth Scan and Pair"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents macAddrBox As System.Windows.Forms.TextBox
    Friend WithEvents pairButton As System.Windows.Forms.Button
    Friend WithEvents unpairButton As System.Windows.Forms.Button
    Friend WithEvents sendTxtBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sendFileBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents sendFileButton As System.Windows.Forms.Button
    Friend WithEvents sendTxtButton As System.Windows.Forms.Button

End Class
