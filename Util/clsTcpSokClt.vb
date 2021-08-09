Public Class clsTcpSokClt

    'Status
    Public Status As Boolean = False
    Public Quality As Boolean = False
    Private HostName As String
    Private Port As Integer

    'Tcp
    Dim tcpClt As TcpClient
    Dim Ns As NetworkStream

    'Threads
    Private CltThread As Thread
    Private CltThreadAlive As Thread

    'Mensagem recebida
    Private tmrChkMsgRec As New System.Windows.Forms.Timer()
    Public colMsgRec As New List(Of String)
    Public Event MsgRec(ByVal MsgRcv As String)

    Public Sub New(ByVal HostName As String, ByVal Port As Integer)
        Me.HostName = HostName
        Me.Port = Port
    End Sub

    Protected Overrides Sub Finalize()
        StopIt()
        MyBase.Finalize()
    End Sub

    Public Sub StartIt()

        LogConsole("TcpSokClt: StartIt ...")
        Status = True

        CltThread = New Thread(AddressOf CltLoop)
        CltThread.Name = "SockClt"
        CltThread.Start()

        CltThreadAlive = New Thread(AddressOf CltAlive)
        CltThreadAlive.Name = "SockCltAlive"
        CltThreadAlive.Start()

        LogConsole("TcpSokClt: StartIt Fim")

        AddHandler tmrChkMsgRec.Tick, AddressOf TrataTmrMsgRec
        tmrChkMsgRec.Interval = 10
        tmrChkMsgRec.Enabled = True

    End Sub

    Public Sub StopIt()

        LogConsole("TcpSokClt: StopIt ...")

        tmrChkMsgRec.Enabled = False

        Status = False
        Try
            If (CltThread Is Nothing) = False And CltThread.IsAlive = True Then
                tcpClt.Close()
                Dim Ns As NetworkStream = tcpClt.GetStream()
                Ns.Close()
                CltThread.Join()
                CltThreadAlive.Join()
            End If
        Catch
        End Try

        LogConsole("TcpSokClt: StopIt Fim")

    End Sub

    Private Sub CltLoop()

        LogConsole("TcpSokClt: CltLoop ...")

        While Status = True

            If Quality = False Then

                tcpClt = New TcpClient()
                Try

                    LogConsole("TcpSokClt: CltLoop - Tentando conectar com o servidor " & HostName & " Port " & Port)

                    tcpClt.Connect(HostName, Port)
                    Ns = tcpClt.GetStream()

                    If Ns.CanWrite = False Or Ns.CanRead = False Then
                        MsgBox("TcpSokClt: CltLoop - Ns.CanWrite = True Or Ns.CanRead = True")
                    End If

                    Quality = True

                Catch ex As Exception

                    LogConsole("TcpSokClt: exception - " & ex.Message)
                    LogConsole("TcpSokClt: CltLoop - Servidor nao encontrado!")
                    Quality = False

                End Try

            Else

                Try
                    LogConsole("TcpSokClt: CltLoop - Receive Aguarda ...")

                    Dim DataRcv As String = Nothing
                    Dim DataRcvBytes(tcpClt.ReceiveBufferSize) As Byte
                    Dim BytesRead As Integer = Ns.Read(DataRcvBytes, 0, tcpClt.ReceiveBufferSize)
                    LogConsole("TcpSokClt: CltLoop - Received " & BytesRead & "Bytes")

                    If BytesRead > 0 Then

                        'Zera o contador de inatividade
                        DataRcv = Encoding.ASCII.GetString(DataRcvBytes, 0, BytesRead)

                        'Show the data on the console.
                        LogConsole("Clt: Recebeu msg: " & DataRcv)
                        LogConsole("TcpSokClt: CltLoop - Recebi a mensagem " & DataRcv)

                        'RaiseEvent MsgRec(DataRcv)
                        colMsgRec.Add(DataRcv)

                        If DataRcv = "<#FIM>" Then Exit While

                    Else
                        'A conexao esta fechada
                        LogConsole("TcpSokClt: CltLoop - Soquete fechado ")
                        Quality = False
                    End If

                Catch ex As Exception   ' Timeout

                    LogConsole("TcpSokClt: CltLoop - exception " & ex.Message)
                    LogConsole("TcpSokClt: CltLoop - O servidor esta' inativo, o soquete sera fechado ")
                    Quality = False

                End Try

            End If

            Thread.Sleep(200)

        End While

        'Fechamento deste soquete
        Try
            Ns.Close()
            tcpClt.Close()
        Catch
        End Try

        LogConsole("TcpSokClt: CltLoop Fim")

    End Sub

    Private Sub CltAlive()

        LogConsole("TcpSokClt: CltAlive ...")

        While Status = True

            Thread.Sleep(10000)

            If Quality = True Then
                MsgSend("<#Alive>")
            End If

        End While

        LogConsole("TcpSokClt: CltAlive Fim")

    End Sub

    Public Sub MsgSend(ByVal DataSnd As String)

        LogConsole("TcpSokClt: Enviando Msg " & DataSnd)

        Try
            Dim Ns As NetworkStream = tcpClt.GetStream()

            Dim DataSndBytes() As Byte = Encoding.ASCII.GetBytes(DataSnd)
            Ns.Write(DataSndBytes, 0, DataSndBytes.Length)
        Catch
        End Try

    End Sub

    Public Sub MsgSendCltId(ByVal ProgNome As String, ByVal ProgId As String)

        Dim MyMsg As New Util.clsTcpSokMsg()

        MyMsg.Cmd = "SokCltId"
        MyMsg.Param.Add(ProgNome)
        MyMsg.Param.Add(ProgId)

        Try
            MsgSend(MyMsg.GetTxt)
        Catch : End Try

    End Sub

    Private Sub TrataTmrMsgRec(ByVal myObject As Object, ByVal myEventArgs As EventArgs)

        'Pega  aprimeira mensagem recebida e envia para o form via evento
        'Este tipo de timer usa a Thread principal e pode usar os controles dos Forms
        Try
            If colMsgRec.Count <= 0 Then Return
            RaiseEvent MsgRec(colMsgRec(0))
            colMsgRec.RemoveAt(0)
        Catch : End Try
    End Sub

    Private Sub LogConsole(ByVal Txt As String)
        'Habilita ou nao o debug do soquete
        Console.WriteLine(Txt)
    End Sub

End Class
