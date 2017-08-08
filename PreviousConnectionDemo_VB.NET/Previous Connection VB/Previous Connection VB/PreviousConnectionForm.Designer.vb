<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class PreviousConnectionForm
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
        Me.connectButton = New System.Windows.Forms.MenuItem
        Me.disconnectButton = New System.Windows.Forms.MenuItem
        Me.macAddressTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.statusBar = New System.Windows.Forms.Label
        Me.savedPrintersListBox = New System.Windows.Forms.ListBox
        Me.deleteButton = New System.Windows.Forms.Button
        Me.deleteAllButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.connectButton)
        Me.mainMenu1.MenuItems.Add(Me.disconnectButton)
        '
        'connectButton
        '
        Me.connectButton.Text = "Connect"
        '
        'disconnectButton
        '
        Me.disconnectButton.Text = "Disconnect"
        '
        'macAddressTextBox
        '
        Me.macAddressTextBox.Location = New System.Drawing.Point(111, 25)
        Me.macAddressTextBox.Name = "macAddressTextBox"
        Me.macAddressTextBox.Size = New System.Drawing.Size(127, 21)
        Me.macAddressTextBox.TabIndex = 5
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(5, 25)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(100, 20)
        Me.label2.Text = "MAC Address:"
        '
        'statusBar
        '
        Me.statusBar.BackColor = System.Drawing.Color.Red
        Me.statusBar.Location = New System.Drawing.Point(1, 1)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(237, 20)
        Me.statusBar.Text = "Not Connected"
        Me.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'savedPrintersListBox
        '
        Me.savedPrintersListBox.Location = New System.Drawing.Point(3, 50)
        Me.savedPrintersListBox.Name = "savedPrintersListBox"
        Me.savedPrintersListBox.Size = New System.Drawing.Size(234, 184)
        Me.savedPrintersListBox.TabIndex = 8
        '
        'deleteButton
        '
        Me.deleteButton.Location = New System.Drawing.Point(75, 240)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(78, 25)
        Me.deleteButton.TabIndex = 9
        Me.deleteButton.Text = "Delete"
        '
        'deleteAllButton
        '
        Me.deleteAllButton.Location = New System.Drawing.Point(159, 240)
        Me.deleteAllButton.Name = "deleteAllButton"
        Me.deleteAllButton.Size = New System.Drawing.Size(78, 25)
        Me.deleteAllButton.TabIndex = 10
        Me.deleteAllButton.Text = "Delete All"
        '
        'PreviousConnectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.deleteAllButton)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.savedPrintersListBox)
        Me.Controls.Add(Me.macAddressTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.statusBar)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "PreviousConnectionForm"
        Me.Text = "Previous Connection VB"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents macAddressTextBox As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents statusBar As System.Windows.Forms.Label
    Friend WithEvents connectButton As System.Windows.Forms.MenuItem
    Friend WithEvents disconnectButton As System.Windows.Forms.MenuItem
    Friend WithEvents savedPrintersListBox As System.Windows.Forms.ListBox
    Friend WithEvents deleteButton As System.Windows.Forms.Button
    Friend WithEvents deleteAllButton As System.Windows.Forms.Button

End Class
