<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class BluetoothDiscoveryDemoVBNETForm
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
        Me.discoveryButton = New System.Windows.Forms.MenuItem
        Me.connectButton = New System.Windows.Forms.MenuItem
        Me.statusBar = New System.Windows.Forms.Label
        Me.discoveredPrintersListBox = New System.Windows.Forms.ListBox
        Me.disconnectButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.discoveryButton)
        Me.mainMenu1.MenuItems.Add(Me.connectButton)
        '
        'discoveryButton
        '
        Me.discoveryButton.Text = "Discover"
        '
        'connectButton
        '
        Me.connectButton.Text = "Connect"
        '
        'statusBar
        '
        Me.statusBar.BackColor = System.Drawing.Color.Red
        Me.statusBar.ForeColor = System.Drawing.Color.Black
        Me.statusBar.Location = New System.Drawing.Point(3, 4)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(234, 20)
        Me.statusBar.Text = "Not Connected"
        Me.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'discoveredPrintersListBox
        '
        Me.discoveredPrintersListBox.Location = New System.Drawing.Point(3, 27)
        Me.discoveredPrintersListBox.Name = "discoveredPrintersListBox"
        Me.discoveredPrintersListBox.Size = New System.Drawing.Size(234, 212)
        Me.discoveredPrintersListBox.TabIndex = 1
        '
        'disconnectButton
        '
        Me.disconnectButton.Location = New System.Drawing.Point(153, 245)
        Me.disconnectButton.Name = "disconnectButton"
        Me.disconnectButton.Size = New System.Drawing.Size(84, 20)
        Me.disconnectButton.TabIndex = 3
        Me.disconnectButton.Text = "Disconnect"
        '
        'BluetoothDiscoveryDemoVBForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.disconnectButton)
        Me.Controls.Add(Me.discoveredPrintersListBox)
        Me.Controls.Add(Me.statusBar)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "BluetoothDiscoveryDemoVBForm"
        Me.Text = "Bluetooth Discovery Demo VB.Net"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents discoveryButton As System.Windows.Forms.MenuItem
    Friend WithEvents statusBar As System.Windows.Forms.Label
    Friend WithEvents discoveredPrintersListBox As System.Windows.Forms.ListBox
    Friend WithEvents connectButton As System.Windows.Forms.MenuItem
    Friend WithEvents disconnectButton As System.Windows.Forms.Button

End Class