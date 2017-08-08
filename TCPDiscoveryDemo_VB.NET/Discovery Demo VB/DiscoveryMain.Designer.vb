<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DiscoveryMain
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
        Me.portTextBox = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.topScreenPanel = New System.Windows.Forms.Panel
        Me.userLayoutPanel = New System.Windows.Forms.Panel
        Me.multicastPanel = New System.Windows.Forms.Panel
        Me.multicastHopUpDown = New System.Windows.Forms.NumericUpDown
        Me.multicastHopsLabel = New System.Windows.Forms.Label
        Me.directBroadcastPanel = New System.Windows.Forms.Panel
        Me.directBroadcastTextBox = New System.Windows.Forms.TextBox
        Me.directLabel = New System.Windows.Forms.Label
        Me.subnetPanel = New System.Windows.Forms.Panel
        Me.subnetTextBox = New System.Windows.Forms.TextBox
        Me.subnetLabel = New System.Windows.Forms.Label
        Me.discoveredPrintersLabel = New System.Windows.Forms.Label
        Me.methodLabel = New System.Windows.Forms.Label
        Me.discoveryMethodsComboBox = New System.Windows.Forms.ComboBox
        Me.statusBar = New System.Windows.Forms.Label
        Me.discoveredPrintersListBox = New System.Windows.Forms.ListBox
        Me.topScreenPanel.SuspendLayout()
        Me.userLayoutPanel.SuspendLayout()
        Me.multicastPanel.SuspendLayout()
        Me.directBroadcastPanel.SuspendLayout()
        Me.subnetPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.discoveryButton)
        Me.mainMenu1.MenuItems.Add(Me.connectButton)
        '
        'discoveryButton
        '
        Me.discoveryButton.Text = "Discovery"
        '
        'connectButton
        '
        Me.connectButton.Text = "Connect"
        '
        'portTextBox
        '
        Me.portTextBox.Location = New System.Drawing.Point(188, 244)
        Me.portTextBox.Name = "portTextBox"
        Me.portTextBox.Size = New System.Drawing.Size(51, 21)
        Me.portTextBox.TabIndex = 17
        Me.portTextBox.Text = "6101"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(150, 244)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(32, 20)
        Me.label1.Text = "Port:"
        '
        'topScreenPanel
        '
        Me.topScreenPanel.BackColor = System.Drawing.Color.DarkGray
        Me.topScreenPanel.Controls.Add(Me.userLayoutPanel)
        Me.topScreenPanel.Controls.Add(Me.statusBar)
        Me.topScreenPanel.Location = New System.Drawing.Point(0, 1)
        Me.topScreenPanel.Name = "topScreenPanel"
        Me.topScreenPanel.Size = New System.Drawing.Size(240, 127)
        '
        'userLayoutPanel
        '
        Me.userLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.userLayoutPanel.BackColor = System.Drawing.Color.DarkGray
        Me.userLayoutPanel.Controls.Add(Me.multicastPanel)
        Me.userLayoutPanel.Controls.Add(Me.directBroadcastPanel)
        Me.userLayoutPanel.Controls.Add(Me.subnetPanel)
        Me.userLayoutPanel.Controls.Add(Me.discoveredPrintersLabel)
        Me.userLayoutPanel.Controls.Add(Me.methodLabel)
        Me.userLayoutPanel.Controls.Add(Me.discoveryMethodsComboBox)
        Me.userLayoutPanel.Location = New System.Drawing.Point(9, 23)
        Me.userLayoutPanel.Name = "userLayoutPanel"
        Me.userLayoutPanel.Size = New System.Drawing.Size(228, 101)
        '
        'multicastPanel
        '
        Me.multicastPanel.BackColor = System.Drawing.Color.DarkGray
        Me.multicastPanel.Controls.Add(Me.multicastHopUpDown)
        Me.multicastPanel.Controls.Add(Me.multicastHopsLabel)
        Me.multicastPanel.Location = New System.Drawing.Point(1, 31)
        Me.multicastPanel.Name = "multicastPanel"
        Me.multicastPanel.Size = New System.Drawing.Size(196, 32)
        '
        'multicastHopUpDown
        '
        Me.multicastHopUpDown.Location = New System.Drawing.Point(98, 2)
        Me.multicastHopUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.multicastHopUpDown.Name = "multicastHopUpDown"
        Me.multicastHopUpDown.Size = New System.Drawing.Size(53, 22)
        Me.multicastHopUpDown.TabIndex = 6
        Me.multicastHopUpDown.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'multicastHopsLabel
        '
        Me.multicastHopsLabel.Location = New System.Drawing.Point(3, 4)
        Me.multicastHopsLabel.Name = "multicastHopsLabel"
        Me.multicastHopsLabel.Size = New System.Drawing.Size(89, 20)
        Me.multicastHopsLabel.Text = "Multicast Hops:"
        '
        'directBroadcastPanel
        '
        Me.directBroadcastPanel.BackColor = System.Drawing.Color.DarkGray
        Me.directBroadcastPanel.Controls.Add(Me.directBroadcastTextBox)
        Me.directBroadcastPanel.Controls.Add(Me.directLabel)
        Me.directBroadcastPanel.Location = New System.Drawing.Point(20, 30)
        Me.directBroadcastPanel.Name = "directBroadcastPanel"
        Me.directBroadcastPanel.Size = New System.Drawing.Size(177, 33)
        Me.directBroadcastPanel.Visible = False
        '
        'directBroadcastTextBox
        '
        Me.directBroadcastTextBox.Location = New System.Drawing.Point(55, 3)
        Me.directBroadcastTextBox.Name = "directBroadcastTextBox"
        Me.directBroadcastTextBox.Size = New System.Drawing.Size(111, 21)
        Me.directBroadcastTextBox.TabIndex = 8
        Me.directBroadcastTextBox.Text = ".255"
        '
        'directLabel
        '
        Me.directLabel.Location = New System.Drawing.Point(3, 3)
        Me.directLabel.Name = "directLabel"
        Me.directLabel.Size = New System.Drawing.Size(46, 20)
        Me.directLabel.Text = "Range: "
        '
        'subnetPanel
        '
        Me.subnetPanel.BackColor = System.Drawing.Color.DarkGray
        Me.subnetPanel.Controls.Add(Me.subnetTextBox)
        Me.subnetPanel.Controls.Add(Me.subnetLabel)
        Me.subnetPanel.Location = New System.Drawing.Point(20, 31)
        Me.subnetPanel.Name = "subnetPanel"
        Me.subnetPanel.Size = New System.Drawing.Size(173, 32)
        Me.subnetPanel.Visible = False
        '
        'subnetTextBox
        '
        Me.subnetTextBox.Location = New System.Drawing.Point(55, 0)
        Me.subnetTextBox.Name = "subnetTextBox"
        Me.subnetTextBox.Size = New System.Drawing.Size(111, 21)
        Me.subnetTextBox.TabIndex = 8
        Me.subnetTextBox.Text = ".*"
        '
        'subnetLabel
        '
        Me.subnetLabel.Location = New System.Drawing.Point(3, 3)
        Me.subnetLabel.Name = "subnetLabel"
        Me.subnetLabel.Size = New System.Drawing.Size(46, 20)
        Me.subnetLabel.Text = "Subnet:"
        '
        'discoveredPrintersLabel
        '
        Me.discoveredPrintersLabel.Location = New System.Drawing.Point(22, 73)
        Me.discoveredPrintersLabel.Name = "discoveredPrintersLabel"
        Me.discoveredPrintersLabel.Size = New System.Drawing.Size(155, 14)
        Me.discoveredPrintersLabel.Text = "Discovered Printers"
        Me.discoveredPrintersLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'methodLabel
        '
        Me.methodLabel.Location = New System.Drawing.Point(1, 7)
        Me.methodLabel.Name = "methodLabel"
        Me.methodLabel.Size = New System.Drawing.Size(54, 20)
        Me.methodLabel.Text = "Method:"
        '
        'discoveryMethodsComboBox
        '
        Me.discoveryMethodsComboBox.Items.Add("Multicast")
        Me.discoveryMethodsComboBox.Items.Add("Directed Broadcast")
        Me.discoveryMethodsComboBox.Items.Add("Local Broadcast")
        Me.discoveryMethodsComboBox.Items.Add("Subnet Search")
        Me.discoveryMethodsComboBox.Location = New System.Drawing.Point(61, 3)
        Me.discoveryMethodsComboBox.Name = "discoveryMethodsComboBox"
        Me.discoveryMethodsComboBox.Size = New System.Drawing.Size(129, 22)
        Me.discoveryMethodsComboBox.TabIndex = 12
        '
        'statusBar
        '
        Me.statusBar.BackColor = System.Drawing.Color.Red
        Me.statusBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.statusBar.Location = New System.Drawing.Point(0, 0)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(240, 20)
        Me.statusBar.Text = "Status: Not Connected"
        Me.statusBar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'discoveredPrintersListBox
        '
        Me.discoveredPrintersListBox.BackColor = System.Drawing.Color.LightGray
        Me.discoveredPrintersListBox.Location = New System.Drawing.Point(0, 127)
        Me.discoveredPrintersListBox.Name = "discoveredPrintersListBox"
        Me.discoveredPrintersListBox.Size = New System.Drawing.Size(240, 114)
        Me.discoveredPrintersListBox.TabIndex = 20
        '
        'DiscoveryMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.topScreenPanel)
        Me.Controls.Add(Me.discoveredPrintersListBox)
        Me.Controls.Add(Me.portTextBox)
        Me.Controls.Add(Me.label1)
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "DiscoveryMain"
        Me.Text = "Discovery Demo VB"
        Me.topScreenPanel.ResumeLayout(False)
        Me.userLayoutPanel.ResumeLayout(False)
        Me.multicastPanel.ResumeLayout(False)
        Me.directBroadcastPanel.ResumeLayout(False)
        Me.subnetPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents discoveryButton As System.Windows.Forms.MenuItem
    Friend WithEvents connectButton As System.Windows.Forms.MenuItem
    Private WithEvents portTextBox As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents topScreenPanel As System.Windows.Forms.Panel
    Private WithEvents userLayoutPanel As System.Windows.Forms.Panel
    Private WithEvents multicastPanel As System.Windows.Forms.Panel
    Private WithEvents multicastHopUpDown As System.Windows.Forms.NumericUpDown
    Private WithEvents multicastHopsLabel As System.Windows.Forms.Label
    Private WithEvents directBroadcastPanel As System.Windows.Forms.Panel
    Private WithEvents directBroadcastTextBox As System.Windows.Forms.TextBox
    Private WithEvents directLabel As System.Windows.Forms.Label
    Private WithEvents subnetPanel As System.Windows.Forms.Panel
    Private WithEvents subnetTextBox As System.Windows.Forms.TextBox
    Private WithEvents subnetLabel As System.Windows.Forms.Label
    Private WithEvents discoveredPrintersLabel As System.Windows.Forms.Label
    Private WithEvents methodLabel As System.Windows.Forms.Label
    Private WithEvents discoveryMethodsComboBox As System.Windows.Forms.ComboBox
    Private WithEvents statusBar As System.Windows.Forms.Label
    Private WithEvents discoveredPrintersListBox As System.Windows.Forms.ListBox

End Class
