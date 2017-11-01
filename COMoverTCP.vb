'Licensed under Apache License 2.0
'Copyright Salvatore Novelli
'salvatore.novelli@tiscali.it
'Modified by Lukas Lang

Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Form
    Delegate Sub ConsolleWriteDelegate(ByVal [text] As String)
    Delegate Sub RXDataTBWriteDelegate(ByVal [val] As Integer)
    Delegate Sub TXDataTBWriteDelegate(ByVal [val] As Integer)

    Private WithEvents sockServer As AsynchronousSocketListener
    Private WithEvents serialPort As New SerialPort

    Private lastConsoleMsg As String = ""
    Private lastConsoleMsgTime As Date

    Private m_fConsole As Boolean

    Const WINDOW_HEIGHT_BIG = 750
    Const WINDOW_HEIGHT_SMALL = 341

    Private m_TCP_SendTimeout As Integer = 3000
    Private m_TCP_fNoDelay As Boolean = True

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSerialPortInfo()

        LoadConfiguration()

        Dim strText As String = "Program Started"
        Dim time As String
        time = TimeOfDay.TimeOfDay.ToString()

        strText = time + ":   " + strText
        consoleWrite(strText)
        m_fConsole = My.Settings.ConsoleExpanded
        Me.Height = If(m_fConsole, WINDOW_HEIGHT_BIG, WINDOW_HEIGHT_SMALL)
        Me.Width = 500

        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CrashHandler
    End Sub

    Private Sub CrashHandler(sender As Object, e As UnhandledExceptionEventArgs)
        Using sw As StreamWriter = File.CreateText("crash_pid" & Process.GetCurrentProcess.Id & ".log")
            Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
            sw.Write(ex)
        End Using
    End Sub

    Private Sub loadSerialPortInfo()
        ' Allow the user to set the appropriate properties.

        Me.PortNameCB.DataSource = SerialPort.GetPortNames()
        Me.ParityCB.DataSource = [Enum].GetValues(GetType(Parity))
        Me.StopBitsCB.DataSource = [Enum].GetValues(GetType(StopBits))
        Me.HandshakeCB.DataSource = [Enum].GetValues(GetType(Handshake))

        Me.PortNameCB.SelectedItem = My.Settings.COMPort
        Me.BaudRateNUD.Value = My.Settings.Baudrate
        Me.ParityCB.SelectedItem = My.Settings.Parity
        Me.DataBitsNUD.Value = My.Settings.DataBits
        Me.StopBitsCB.SelectedItem = My.Settings.StopBits
        Me.HandshakeCB.SelectedItem = My.Settings.Handshake
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        openCOM()

        Me.Text = "COM By TCP - " & PortNameCB.Text

        setFormEnabled(False)
        sockServer = New AsynchronousSocketListener(Me.ServerPortNUD.Value)

        AsynchronousSocketListener.m_fNoDelay = m_TCP_fNoDelay
        AsynchronousSocketListener.m_SendTimeout = m_TCP_SendTimeout

        sockServer.Start()
    End Sub


    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        StopAll()
    End Sub

    Private Sub StopAll()
        If sockServer IsNot Nothing Then
            sockServer.StopServer()
        End If

        If serialPort.IsOpen Then
            serialPort.Close()

            consoleWriteline(serialPort.PortName + " closed!")
        End If

        Me.Text = "COM by TCP"

        setFormEnabled(True)

        Me.TXDataTB.Text = "0"
        Me.RXDataTB.Text = "0"
    End Sub

    Private Sub LoadConfiguration()
        Me.ServerPortNUD.Value = My.Settings.Port
    End Sub

    Private Sub addRXDataTBValue(ByVal dataRecived As Integer)
        If Me.InvokeRequired Then
            Dim d As New RXDataTBWriteDelegate(AddressOf addRXDataTBValue)
            Me.Invoke(d, New Object() {dataRecived})
        Else
            Me.RXDataTB.Text = CStr(CInt(Me.RXDataTB.Text) + dataRecived)
        End If
    End Sub

    Private Sub addTXDataTBValue(ByVal dataTransmitted As Integer)
        If Me.InvokeRequired Then
            Dim d As New TXDataTBWriteDelegate(AddressOf addTXDataTBValue)
            Me.Invoke(d, New Object() {dataTransmitted})
        Else
            Me.TXDataTB.Text = CStr(CInt(Me.TXDataTB.Text) + dataTransmitted)
        End If
    End Sub

    Private Function escapeString(ByVal c As Match) As String
        Return String.Format("\u{0:x2}", Asc(c.Value.Chars(0)))
    End Function

    Private Sub consoleWriteline(ByVal strText As String)
        strText = Regex.Replace(strText.TrimEnd({Chr(10), Chr(13)}), "[\p{Cc}-[\r\n]]", AddressOf escapeString)

        If strText <> lastConsoleMsg Then
            lastConsoleMsg = strText
            lastConsoleMsgTime = Now()
            consoleWriteEntry(strText)
        Else
            If (DateDiff(DateInterval.Second, lastConsoleMsgTime, Now) > 4) Then
                'la stessa cosa si può scrivere al massimo ogni 4 secondi
                consoleWriteEntry(strText)
                lastConsoleMsg = strText
                lastConsoleMsgTime = Now()
            Else
                consoleWrite(".")
            End If
        End If
    End Sub

    Private Sub consoleWriteEntry(ByVal strText As String)
        Dim time As String = TimeOfDay.TimeOfDay.ToString()
        strText = vbCrLf + time + ":  " + strText
        consoleWrite(strText)
    End Sub

    Private Sub consoleWrite(ByVal strText As String)
        If Me.InvokeRequired Then

            Dim d As New ConsolleWriteDelegate(AddressOf consoleWrite)
            Me.Invoke(d, New Object() {strText})
        Else
            Me.Console.AppendText(strText)
        End If
    End Sub

    Private Sub setFormEnabled(ByVal enabled As Boolean)
        Me.btnStart.Enabled = enabled
        Me.btnStop.Enabled = Not enabled
        Me.ServerPortNUD.Enabled = enabled
        Me.GroupBox2.Enabled = enabled
    End Sub

    Private Sub Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (Not IsNothing(sockServer)) Then
            sockServer.StopListening()
            sockServer = Nothing
        End If

        My.Settings.COMPort = Me.PortNameCB.SelectedItem
        My.Settings.Baudrate = Me.BaudRateNUD.Value
        My.Settings.Parity = Me.ParityCB.SelectedItem
        My.Settings.DataBits = Me.DataBitsNUD.Value
        My.Settings.StopBits = Me.StopBitsCB.SelectedItem
        My.Settings.Handshake = Me.HandshakeCB.SelectedItem

        My.Settings.Port = Me.ServerPortNUD.Value

        My.Settings.ConsoleExpanded = m_fConsole
    End Sub

    Private Sub openCOM()
        Try
            serialPort.PortName = Me.PortNameCB.Text
            serialPort.BaudRate = Me.BaudRateNUD.Value
            serialPort.Parity = Me.ParityCB.SelectedItem
            serialPort.DataBits = Me.DataBitsNUD.Value
            serialPort.StopBits = Me.StopBitsCB.SelectedItem
            serialPort.Handshake = Me.HandshakeCB.SelectedItem
            ' Set the read/write timeouts
            serialPort.ReadTimeout = 500
            serialPort.WriteTimeout = 500

            serialPort.Open()

            serialPort.DtrEnable = True
            serialPort.RtsEnable = True
            consoleWriteline(serialPort.PortName + " correctly opened!")

        Catch ex As Exception
            consoleWriteline("Unable to open " + Me.PortNameCB.Text + ".")
            StopAll()
        End Try
    End Sub


    Private Sub serialPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Dim buffSize As Integer = 5000
        Dim buffer(buffSize) As Byte
        Dim index As Integer = 0

        While serialPort.BytesToRead > 0
            buffer(index) = serialPort.ReadByte()
            index = index + 1
        End While

        consoleWriteline(">> " + Encoding.ASCII.GetString(buffer, 0, index))

        If Not IsNothing(sockServer) Then
            sockServer.SendData(buffer, index)
        Else
            consoleWriteline("COM Listener: Unable to forward data - socket not started!")
        End If
    End Sub

    Private Sub sockServer_dataRecived(ByVal buffer() As Byte, ByVal bytesRecived As Integer) Handles sockServer.dataRecived
        'consolleWriteline("Recived: " + strData)

        addRXDataTBValue(bytesRecived)

        Try
            serialPort.Write(buffer, 0, bytesRecived)
            consoleWriteline("<< " + Encoding.ASCII.GetString(buffer, 0, bytesRecived))
        Catch ex As Exception
            If serialPort.IsOpen Then
                consoleWriteline(ex.ToString)
            Else
                consoleWriteline("SOCK: Unable to write on COM. The port is CLOSED.")
            End If
        End Try
    End Sub

    Private Sub sockServer_dataSent(ByVal buffer() As Byte, ByVal bytesSent As Integer) Handles sockServer.dataSent
        addTXDataTBValue(bytesSent)
    End Sub

    Private Sub sockServer_logEntry(ByVal strData As String) Handles sockServer.logEntry
        TimeOfDay.ToString()

        consoleWriteline(strData)
    End Sub

    Private Sub ConsolePB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsolePB.Click
        If m_fConsole Then
            Me.Height = WINDOW_HEIGHT_SMALL
            Me.Width = 500
            Me.ConsolePB.Text = "Console >>"
        Else
            Me.Height = WINDOW_HEIGHT_BIG
            Me.Width = 500
            Me.ConsolePB.Text = "Console <<"
        End If

        m_fConsole = Not m_fConsole
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Dim settings As New TCPSettings

        settings.SendTimeoutTB.Text = m_TCP_SendTimeout
        settings.fNoDelay.Checked = m_TCP_fNoDelay

        settings.ShowDialog()

        If settings.DialogResult = Windows.Forms.DialogResult.OK Then
            m_TCP_SendTimeout = settings.SendTimeoutTB.Text
            m_TCP_fNoDelay = settings.fNoDelay.Checked
        End If
    End Sub
End Class
