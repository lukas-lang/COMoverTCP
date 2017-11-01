<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RXDataTB = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXDataTB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ServerPortNUD = New System.Windows.Forms.NumericUpDown()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Console = New System.Windows.Forms.TextBox()
        Me.PortNameCB = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ParityCB = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StopBitsCB = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.HandshakeCB = New System.Windows.Forms.ComboBox()
        Me.BaudRateNUD = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataBitsNUD = New System.Windows.Forms.NumericUpDown()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsolePB = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ServerPortNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BaudRateNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataBitsNUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RXDataTB)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TXDataTB)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ServerPortNUD)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 103)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server properties"
        '
        'RXDataTB
        '
        Me.RXDataTB.BackColor = System.Drawing.SystemColors.Menu
        Me.RXDataTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RXDataTB.Cursor = System.Windows.Forms.Cursors.Default
        Me.RXDataTB.ForeColor = System.Drawing.SystemColors.InfoText
        Me.RXDataTB.Location = New System.Drawing.Point(85, 73)
        Me.RXDataTB.Name = "RXDataTB"
        Me.RXDataTB.ReadOnly = True
        Me.RXDataTB.Size = New System.Drawing.Size(71, 20)
        Me.RXDataTB.TabIndex = 19
        Me.RXDataTB.TabStop = False
        Me.RXDataTB.Text = "0"
        Me.RXDataTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Recived Data"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Sent Data"
        '
        'TXDataTB
        '
        Me.TXDataTB.BackColor = System.Drawing.SystemColors.Menu
        Me.TXDataTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXDataTB.Cursor = System.Windows.Forms.Cursors.Default
        Me.TXDataTB.ForeColor = System.Drawing.SystemColors.InfoText
        Me.TXDataTB.Location = New System.Drawing.Point(85, 47)
        Me.TXDataTB.Name = "TXDataTB"
        Me.TXDataTB.ReadOnly = True
        Me.TXDataTB.Size = New System.Drawing.Size(71, 20)
        Me.TXDataTB.TabIndex = 15
        Me.TXDataTB.TabStop = False
        Me.TXDataTB.Text = "0"
        Me.TXDataTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Port"
        '
        'ServerPortNUD
        '
        Me.ServerPortNUD.Location = New System.Drawing.Point(85, 20)
        Me.ServerPortNUD.Maximum = New Decimal(New Integer() {65536, 0, 0, 0})
        Me.ServerPortNUD.Name = "ServerPortNUD"
        Me.ServerPortNUD.Size = New System.Drawing.Size(71, 20)
        Me.ServerPortNUD.TabIndex = 2
        Me.ServerPortNUD.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 150)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(170, 29)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Console
        '
        Me.Console.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Console.Cursor = System.Windows.Forms.Cursors.Default
        Me.Console.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Console.ForeColor = System.Drawing.Color.White
        Me.Console.Location = New System.Drawing.Point(12, 262)
        Me.Console.Multiline = True
        Me.Console.Name = "Console"
        Me.Console.ReadOnly = True
        Me.Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Console.Size = New System.Drawing.Size(473, 446)
        Me.Console.TabIndex = 10
        '
        'PortNameCB
        '
        Me.PortNameCB.FormattingEnabled = True
        Me.PortNameCB.Location = New System.Drawing.Point(82, 19)
        Me.PortNameCB.Name = "PortNameCB"
        Me.PortNameCB.Size = New System.Drawing.Size(121, 21)
        Me.PortNameCB.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Port"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Baud Rate"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Parity"
        '
        'ParityCB
        '
        Me.ParityCB.FormattingEnabled = True
        Me.ParityCB.Location = New System.Drawing.Point(82, 73)
        Me.ParityCB.Name = "ParityCB"
        Me.ParityCB.Size = New System.Drawing.Size(121, 21)
        Me.ParityCB.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Stop Bits"
        '
        'StopBitsCB
        '
        Me.StopBitsCB.FormattingEnabled = True
        Me.StopBitsCB.Location = New System.Drawing.Point(82, 127)
        Me.StopBitsCB.Name = "StopBitsCB"
        Me.StopBitsCB.Size = New System.Drawing.Size(121, 21)
        Me.StopBitsCB.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Data Bits"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Handshake"
        '
        'HandshakeCB
        '
        Me.HandshakeCB.FormattingEnabled = True
        Me.HandshakeCB.Location = New System.Drawing.Point(82, 154)
        Me.HandshakeCB.Name = "HandshakeCB"
        Me.HandshakeCB.Size = New System.Drawing.Size(121, 21)
        Me.HandshakeCB.TabIndex = 8
        '
        'BaudRateNUD
        '
        Me.BaudRateNUD.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.BaudRateNUD.Location = New System.Drawing.Point(82, 47)
        Me.BaudRateNUD.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.BaudRateNUD.Name = "BaudRateNUD"
        Me.BaudRateNUD.Size = New System.Drawing.Size(121, 20)
        Me.BaudRateNUD.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataBitsNUD)
        Me.GroupBox2.Controls.Add(Me.PortNameCB)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.BaudRateNUD)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ParityCB)
        Me.GroupBox2.Controls.Add(Me.HandshakeCB)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.StopBitsCB)
        Me.GroupBox2.Location = New System.Drawing.Point(188, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(220, 183)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COM Properties"
        '
        'DataBitsNUD
        '
        Me.DataBitsNUD.Location = New System.Drawing.Point(83, 101)
        Me.DataBitsNUD.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.DataBitsNUD.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.DataBitsNUD.Name = "DataBitsNUD"
        Me.DataBitsNUD.Size = New System.Drawing.Size(120, 20)
        Me.DataBitsNUD.TabIndex = 6
        Me.DataBitsNUD.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoToolStripMenuItem})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(494, 24)
        Me.MainMenu.TabIndex = 32
        Me.MainMenu.Text = "MainMenu"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.InfoToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "TCP &Settings..."
        '
        'ConsolePB
        '
        Me.ConsolePB.Location = New System.Drawing.Point(12, 230)
        Me.ConsolePB.Name = "ConsolePB"
        Me.ConsolePB.Size = New System.Drawing.Size(132, 26)
        Me.ConsolePB.TabIndex = 33
        Me.ConsolePB.Text = "Console >>"
        Me.ConsolePB.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(12, 182)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(170, 29)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'Form
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(494, 720)
        Me.Controls.Add(Me.ConsolePB)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Console)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.MainMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MainMenuStrip = Me.MainMenu
        Me.MaximizeBox = False
        Me.Name = "Form"
        Me.Text = "COM over TCP"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ServerPortNUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BaudRateNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataBitsNUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ServerPortNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents Console As System.Windows.Forms.TextBox
    Friend WithEvents PortNameCB As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ParityCB As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents StopBitsCB As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents HandshakeCB As System.Windows.Forms.ComboBox
    Friend WithEvents BaudRateNUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXDataTB As System.Windows.Forms.TextBox
    Friend WithEvents RXDataTB As System.Windows.Forms.TextBox
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsolePB As System.Windows.Forms.Button
    Friend WithEvents DataBitsNUD As NumericUpDown
    Friend WithEvents btnStop As Button
End Class
