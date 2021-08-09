
Public Class clsTcpSokSrv

    'Status
    Private Status As Boolean = False
    Private LocalHostName As String
    Private LocalPort As Integer
    Private CltConta As Integer = 0

    'Tcp
    Private lstCltSok As List(Of clsTcpSokClientHandler)
    Private SokListener As TcpListener

    'Threads
    Private ThreadReclaim As Thread
    Private ThreadListener As Thread

    'Mensagens recebidas
    Private tmrChkMsgRec As New System.Windows.Forms.Timer()
    Private colMsgRec As New List(Of clsTcpSokMsgInfo)
    Public Event MsgRec(ByVal Clientid As Integer, ByVal MsgRcv As String)

    'Inicializacao e fim
    Protected Overrides Sub Finalize()
        LogConsole("TcpSokSrv: Finalize")
        ListeningStop()
        MyBase.Finalize()
    End Sub

    Public Sub ListeningStart(ByVal HostName As String, ByVal Port As Integer)

        LogConsole("TcpSokSrv: ListeningStart ...")

        'Status ligado
        Status = True

        'Memoriza a porta do soquete do SokListener
        LocalHostName = HostName
        LocalPort = Port

        'Lista de clientes
        lstCltSok = New List(Of clsTcpSokClientHandler)

        'Dispara a task de recuperacao (desativacao) de soquetes fechados
        ThreadReclaim = New Thread(AddressOf Reclaim)
        ThreadReclaim.Name = "SockReclaim"
        ThreadReclaim.Start()

        'Dispara a task do SokListener
        ThreadListener = New Thread(AddressOf Listen)
        ThreadListener.Name = "SockListener"
        ThreadListener.Start()

        LogConsole("TcpSokSrv: ListeningStart Fim")

        AddHandler tmrChkMsgRec.Tick, AddressOf TrataTmrMsgRec
        tmrChkMsgRec.Interval = 10
        tmrChkMsgRec.Enabled = True

    End Sub

    Public Sub ListeningStop()

        LogConsole("TcpSokSrv: ListeningStop ...")

        'Status ligado
        Status = False
        tmrChkMsgRec.Enabled = False

        Try

            'Fecha o soquete listenet
            SokListener.Stop()

            'Encerra a task de recuperacao de soquetes fechados
            ThreadReclaim.Join()

            'Fecha todos os clientes da lista
            Dim Client As Object
            For Each Client In lstCltSok
                Client.StopIt()
            Next

        Catch ex As Exception

        End Try

        lstCltSok = New List(Of clsTcpSokClientHandler)

        LogConsole("TcpSokSrv: ListeningStop Fim")

    End Sub

    'Threads do Listener 
    Private Sub Listen()

        LogConsole("TcpSokSrv: Listen ...")

        'Abre o soquete SokListener
        Dim ipAddress As IPAddress = Dns.GetHostEntry(LocalHostName).AddressList(0)
        SokListener = New TcpListener(ipAddress, LocalPort)

        Try

            'Inicia o SokListener
            SokListener.Start()

            'Start listening for connections.
            While True

                'A task do SokListener fica parada no AcceptTcpClient ate que um cliente se conecte
                LogConsole("TcpSokSrv: Listen - SokListener aguardando uma conexao ...")
                Dim TcpClt As TcpClient = SokListener.AcceptTcpClient()

                If (TcpClt Is Nothing) = False Then

                    CltConta = CltConta + 1
                    LogConsole("TcpSokSrv: Listen - Conexao aceita Cliente " & CltConta)

                    'Trava a lista de clientes e insere o novo TcpClient
                    SyncLock lstCltSok

                        Dim CltHandler As New clsTcpSokClientHandler(CltConta, TcpClt, Me)

                        LogConsole("TcpSokSrv: Listen - Criando CltHandler " & CltConta)
                        lstCltSok.Add(CltHandler)
                        CltHandler.StartIt()

                    End SyncLock

                Else
                    'Falhou ao aceitar conexao
                    LogConsole("TcpSokSrv: Listen - Falhou ao aceitar conexao")
                End If

            End While

            'Fim do loop do SokListener
            ListeningStop()

        Catch ex As Exception

            'Falha na criacao do SokListener
            LogConsole("TcpSokSrv: Listen - Exception " & ex.ToString())

        End Try

        LogConsole("TcpSokSrv: Listen Stop (Listener encerrado)")

    End Sub

    Private Sub Reclaim()

        Dim Idx As Integer
        LogConsole("TcpSokSrv: Reclaim - Iniciando ... ")

        'Fecha os soquetes em falha
        While Status = True

            'Trava a lista de clintes para verificar um a um
            SyncLock (lstCltSok)

                'Loop para cada cliente do fim para o comeco
                For Idx = lstCltSok.Count - 1 To 0 Step -1

                    Dim Client As clsTcpSokClientHandler = lstCltSok(Idx)
                    If Client.Alive = False Then

                        LogConsole("TcpSokSrv: Reclaim - O cliente esta em falha sera fechado " & Client.ClientId)
                        lstCltSok.Remove(Client)
                        Client.StopIt()

                    End If
                Next

                Thread.Sleep(1000)

            End SyncLock

        End While

        LogConsole("TcpSokSrv: Reclaim - Finalizado ")

    End Sub

    'Status
    Public Function Sts(Optional ByRef dtItens As DataTable = Nothing) As Boolean

        'Status do Listener
        Sts = Status

        'Cria a tabela de status e as suas colunas
        dtItens = New DataTable("SokClt")
        dtItens.Columns.Add("Id")
        dtItens.Columns.Add("Sts")
        dtItens.Columns.Add("ProgNome")
        dtItens.Columns.Add("ProgId")

        If lstCltSok Is Nothing Then Exit Function
        If lstCltSok.Count <= 0 Then Exit Function


        Dim Conta As Integer
        Dim Cliente As clsTcpSokClientHandler

        For Conta = 0 To lstCltSok.Count - 1

            Cliente = lstCltSok(Conta)

            Dim myDataRow As DataRow
            myDataRow = dtItens.NewRow()

            myDataRow.Item(0) = Cliente.ClientId
            myDataRow.Item(1) = Cliente.Status
            myDataRow.Item(2) = Cliente.ProgNome
            myDataRow.Item(3) = Cliente.ProgId

            dtItens.Rows.Add(myDataRow)

        Next

    End Function

    Public Function GetCltQtd() As Integer

        Try
            Return lstCltSok.Count
        Catch : End Try

    End Function

    'Envio de mensagens
    Public Sub MsgEnv(ByVal Id As Integer, ByVal Msg As String)

        If lstCltSok Is Nothing Then Exit Sub

        'Procura o cliente com esta identificacao
        For Conta As Integer = 0 To lstCltSok.Count - 1

            If lstCltSok(Conta).ClientId = Id Then

                Try
                    lstCltSok(Conta).MsgSend(Msg)
                Catch : End Try
                Return

            End If
        Next

    End Sub

    Public Sub MsgEnvIdx(ByVal Idx As Integer, ByVal Msg As String)

        If lstCltSok Is Nothing Then Exit Sub

        'Procura o cliente com esta identificacao
        If Idx < lstCltSok.Count - 1 Then Exit Sub

        Try
            lstCltSok(Idx).MsgSend(Msg)
        Catch : End Try

    End Sub

    Public Function TrataMsg(ByVal ClientId As Integer, ByVal MsgRcv As String) As Integer
        'Insere mensagens na lista para serem reised pela Thread dos Forms
        'RaiseEvent MsgRec(ClientId, MsgRcv)
        Try
            SyncLock colMsgRec
                colMsgRec.Add(New clsTcpSokMsgInfo(ClientId, MsgRcv))
            End SyncLock
        Catch : End Try

    End Function

    Private Sub TrataTmrMsgRec(ByVal myObject As Object, ByVal myEventArgs As EventArgs)

        'Pega  aprimeira mensagem recebida e envia para o form via evento
        'Este tipo de timer usa a Thread principal e pode usar os controles dos Forms
        If colMsgRec.Count <= 0 Then Return
        Try

            RaiseEvent MsgRec(colMsgRec(0).CltId, colMsgRec(0).Msg)
            SyncLock colMsgRec
                colMsgRec.RemoveAt(0)
            End SyncLock

        Catch : End Try

    End Sub

    Public Sub LogConsole(ByVal Txt As String)
        'Habilita ou nao o debug do soquete
        'Console.WriteLine(Txt)
    End Sub

End Class

Class clsTcpSokClientHandler

    'Status
    Public Status As Boolean = False
    Public ClientId As Integer
    Public ProgNome As String = ""
    Public ProgId As String = ""

    Dim Srv As clsTcpSokSrv

    'Tcp
    Private TcpClt As TcpClient

    'Threads
    Private ClientThread As Thread

    'Inicio e fim
    Public Sub New(ByVal ClientId As Integer, ByVal TcpClt As TcpClient, ByRef Srv As clsTcpSokSrv)
        Me.ClientId = ClientId
        Me.TcpClt = TcpClt
        Me.Srv = Srv
    End Sub

    Protected Overrides Sub Finalize()
        StopIt()
        MyBase.Finalize()
    End Sub

    'Inicia e para as threads
    Public Sub StartIt()

        Srv.LogConsole("TcpSokClientHandler: StartIt ...")

        Status = True
        Try
            ClientThread = New Thread(AddressOf CltLoop)
            ClientThread.Name = "SockClient" & ClientId
            ClientThread.Start()
        Catch : End Try


        Srv.LogConsole("TcpSokClientHandler: StartIt Fim")

    End Sub

    Public Sub StopIt()

        Srv.LogConsole("TcpSokClientHandler: StopIt ...")

        Status = False
        If (ClientThread Is Nothing) = False And ClientThread.IsAlive = True Then
            Try
                Dim Ns As NetworkStream = TcpClt.GetStream()
                Ns.Close()
                ClientThread.Join()
            Catch
            End Try
        End If

        Srv.LogConsole("TcpSokClientHandler: StopIt Fim")

    End Sub

    Public Function Alive() As Boolean
        Try
            Alive = (ClientThread Is Nothing) = False And ClientThread.IsAlive = True And Status = True
        Catch : End Try
    End Function

    'Comunica
    Private Sub CltLoop()

        Srv.LogConsole("TcpSokClientHandler: CltLoop ...")

        If (TcpClt Is Nothing) = False Then

            Dim Ns As NetworkStream = TcpClt.GetStream()

            'Timeout =  1000 milisegundos
            TcpClt.ReceiveTimeout = 60000


            While Status = True

                Try
                    Srv.LogConsole("TcpSokClientHandler: CltLoop - Receive Aguarda ...")
                    Dim DataRcv As String = Nothing
                    Dim DataRcvBytes(TcpClt.ReceiveBufferSize) As Byte
                    Dim BytesRead As Integer = Ns.Read(DataRcvBytes, 0, TcpClt.ReceiveBufferSize)
                    Srv.LogConsole("TcpSokClientHandler: CltLoop - Received " & BytesRead & "Bytes")

                    If BytesRead > 0 Then

                        'Zera o contador de inatividade
                        DataRcv = Encoding.ASCII.GetString(DataRcvBytes, 0, BytesRead)

                        'Show the data on the console.
                        Srv.LogConsole("TcpSokClientHandler: CltLoop - Cliente " & ClientId & " recebeu msg: " & DataRcv)

                        If Strings.Left(DataRcv, 9) = "<SokCltId" Then

                            'Verifica se é mensagem de identificacao do programa cliente
                            Try
                                Dim MyMsg As New clsTcpSokMsg(DataRcv)
                                If MyMsg.Param.Count = 2 Then
                                    ProgNome = MyMsg.Param(0)
                                    ProgId = MyMsg.Param(1)
                                End If
                            Catch : End Try

                        Else

                            'RaiseEvent MsgRec(DataRcv)
                            Try
                                Srv.TrataMsg(ClientId, DataRcv)
                            Catch : End Try

                        End If


                        If DataRcv = "<#FIM>" Then Exit While

                    Else
                        'A conexao esta fechada
                        Srv.LogConsole("TcpSokClientHandler: CltLoop - Conexao fechada para Cliente " & ClientId)
                        Exit While
                    End If

                Catch ex As Exception   ' Timeout

                    Srv.LogConsole("TcpSokClientHandler: CltLoop - exception " & ex.Message)
                    Srv.LogConsole("TcpSokClientHandler: CltLoop - O cliente esta' inativo sera fechado " & ClientId)
                    Status = False

                End Try

                Thread.Sleep(200)

            End While

            'Fechamento deste soquete
            Srv.LogConsole("TcpSokClientHandler: CltLoop - Fechando soquete")
            Ns.Close()
            TcpClt.Close()

        End If

        Srv.LogConsole("TcpSokClientHandler: CltLoop Fim")

    End Sub

    Public Sub MsgSend(ByVal DataSnd As String)

        Srv.LogConsole("TcpSokClientHandler: Enviando Msg " & DataSnd)
        Try
            Dim Ns As NetworkStream = TcpClt.GetStream()

            Dim DataSndBytes() As Byte = Encoding.ASCII.GetBytes(DataSnd)
            Ns.Write(DataSndBytes, 0, DataSndBytes.Length)
        Catch
        End Try

    End Sub

End Class

Class clsTcpSokMsgInfo

    Public CltId As Integer
    Public Msg As String

    Sub New(ByVal NovoCltId As Integer, ByVal NovoMsg As String)
        CltId = NovoCltId
        Msg = NovoMsg
    End Sub
End Class