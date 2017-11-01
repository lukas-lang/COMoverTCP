'Licensed under Apache License 2.0
'Copyright Salvatore Novelli
'salvatore.novelli@tiscali.it
'Modified by Lukas Lang

Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

' State object for reading client data asynchronously
Public Class StateObject
    Public socket As Socket
    ' Size of receive buffer.
    Public Shared BufferSize As Integer = 256
    ' Receive buffer.
    Public buffer(256) As Byte
    ' Received data string.
    Public sb As New StringBuilder()
End Class 'StateObject

Public Class AsynchronousSocketListener
    Private Shared m_mainSocket As Socket
    Private Shared m_clients As New HashSet(Of Socket)

    Shared m_iPort As Integer

    Public Shared Event logEntry(ByVal strData As String)
    Public Shared Event dataRecived(ByVal buffer() As Byte, ByVal bytesRecived As Integer)
    Public Shared Event dataSent(ByVal buffer() As Byte, ByVal bytesSent As Integer)
    Public Shared Event clientNotReachable(ByVal sSocket As Socket)
    Public Shared m_SendTimeout As Integer
    Public Shared m_fNoDelay As Boolean

    Public Sub New(ByVal iPort As Integer)
        m_iPort = iPort
    End Sub

    Public Sub Start()
        StartListening()
    End Sub

    Public Sub StopServer()
        m_mainSocket.Close()

        For Each client As Socket In m_clients.ToList()
            client.Close()
        Next

        m_clients.Clear()

        RaiseEvent logEntry("Stopped the server...")
    End Sub

    Private Shared Sub StartListening()
        ' Data buffer for incoming data.
        Dim bytes() As Byte = New [Byte](1024) {}

        Dim localEndPoint As New IPEndPoint(IPAddress.Any, m_iPort)

        ' Intializes a TCP/IP socket.
        m_mainSocket = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        m_mainSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, CInt(m_SendTimeout))
        m_mainSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, m_fNoDelay)
        ' Bind the socket to the local endpoint and listen for incoming 
        ' connections.
        Try
            m_mainSocket.Bind(localEndPoint)
            m_mainSocket.Listen(4)

            Console.WriteLine("Waiting for a connection...")
            RaiseEvent logEntry("Waiting for a connection...")
            m_mainSocket.BeginAccept(New AsyncCallback(AddressOf onClientConnect), 0)
        Catch e As Exception
            Console.WriteLine(e.ToString())
            RaiseEvent logEntry(e.ToString())
        End Try
    End Sub

    Public Shared Sub onClientConnect(ByVal ar As IAsyncResult)
        Try
            Dim client As Socket = m_mainSocket.EndAccept(ar)

            m_clients.Add(client)

            Console.WriteLine("Client connected!")
            RaiseEvent logEntry("Client connected: " + client.RemoteEndPoint.ToString)

            m_mainSocket.BeginAccept(New AsyncCallback(AddressOf onClientConnect), 0)

            WaitForData(client)
        Catch dex As ObjectDisposedException
        Catch ex As Exception
            RaiseEvent logEntry(ex.ToString)
        End Try
    End Sub

    Private Shared Sub WaitForData(ByVal client As Socket)
        Try
            ' Create the state object.
            Dim state As New StateObject()

            state.socket = client

            If client.Connected Then
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, New AsyncCallback(AddressOf onDataReceived), state)
            Else
                RaiseEvent clientNotReachable(client)
            End If

        Catch dex As ObjectDisposedException
        Catch ex As Exception
            If client.Connected Then
                RaiseEvent logEntry(ex.ToString)
            Else
                RaiseEvent clientNotReachable(client)
            End If

        End Try
    End Sub

    Public Shared Sub onDataReceived(ByVal ar As IAsyncResult)
        Dim state As StateObject = CType(ar.AsyncState, StateObject)
        Dim client As Socket = state.socket
        Try
            Dim content As [String] = [String].Empty

            ' Retrieve the state object and the handler socket
            ' from the asynchronous state object.
            ' Read data from client socket. 
            Dim bytesRead As Integer
            If client.Connected Then
                bytesRead = client.EndReceive(ar)
            Else
                RaiseEvent clientNotReachable(client)
                Exit Sub
            End If
            If bytesRead > 0 Then
                content = Encoding.ASCII.GetString(state.buffer, 0, bytesRead)

                Console.Write(content)
                RaiseEvent dataRecived(state.buffer, bytesRead)
            End If

            WaitForData(client)
        Catch dex As ObjectDisposedException
        Catch ex As Exception
            If (client.Connected) Then
                RaiseEvent logEntry(ex.ToString)
            Else
                RaiseEvent clientNotReachable(client)
            End If
        End Try
    End Sub

    Public Sub StopListening()
    End Sub

    Public Sub SendData(ByVal buffer() As Byte, ByVal bytesToWrite As Integer)
        If m_clients.Count > 0 Then
            For Each client As Socket In m_clients.ToList()
                Send(client, buffer, bytesToWrite)
            Next
        Else
            RaiseEvent logEntry("Socket: Unable to send data, no clients connected!")
        End If
    End Sub

    Private Shared Sub Send(ByVal client As Socket, ByVal buffer() As Byte, ByVal bytesToWrite As Integer)
        ' Convert the string data to byte data using ASCII encoding.ù

        Try
            If (client.Connected) Then
                client.Send(buffer, bytesToWrite, SocketFlags.None)

                RaiseEvent dataSent(buffer, bytesToWrite)
            ElseIf m_clients.Contains(client) Then
                RaiseEvent clientNotReachable(client)
            End If
        Catch dex As ObjectDisposedException
        Catch ex As Exception
            If (client.Connected) Then
                RaiseEvent logEntry(ex.ToString)
            Else
                RaiseEvent clientNotReachable(client)
            End If
        End Try
    End Sub

    Private Sub AsynchronousSocketListener_clientNotReachable(ByVal sSocket As Socket) Handles Me.clientNotReachable
        m_clients.Remove(sSocket)
        RaiseEvent logEntry("Client not reachable: " + sSocket.RemoteEndPoint.ToString)
    End Sub
End Class