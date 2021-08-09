Public Class clsMist
    Implements clsIMist

    Dim Trd As Thread
    Dim TrdRun As Boolean = False

    Public CommCentral As Boolean = False
    Public OpcSrv As OPCAutomation.OPCServer
    Public Const cnstServerOpcGrupo = "KbMistGrava"
    Public Const cnstServerOpcGrupoSts = "KbMistGravaSts"


    Public Sub Iniciar()

        LogAdd("Iniciar...")
        InicializaDados()

        Trd = New Thread(AddressOf TrdTrata)
        TrdRun = True
        Trd.Start()

        'Inicia serviço Wcf (servidor de dados via Http)
        LogAdd("Inicializando Servicehost...")
        Try
            serviceHost.Open()
        Catch
            LogAdd("Erro: Falha inicializando Servicehost")
        End Try

        LogAdd("Iniciado.")

    End Sub

    Public Sub Parar()

        LogAdd("Parar...")
        OpcDesmonta()

        'Para serviço Wcf (servidor de dados via Http)
        serviceHost.Close()

        TrdRun = False
        Trd.Join()

        LogAdd("Parado.")

    End Sub

    Private Sub InicializaDados()

        'PlanejD
        MistD = New clsMistD

        Dim DbMi As New Geral.nsMistGrava.dcMistGrava
        Dim dtTanques = (From It In DbMi.Tanques Order By It.TqId).ToList
        For Each Tq In dtTanques
            MistD.Dados.Add(New clsMistDIt With {.TqId = Tq.TqId, .TqNome = Tq.TqNome, .DBDados = Tq.DbDados, .DBSts = Tq.DbSts, .Tipo = Tq.Tipo})
        Next


        CommCentral = False

    End Sub

    Sub TrdTrata()

        'Try
        Dim HoraAnt As Integer = -1

        While TrdRun = True

            'Verifica comunicação com os PLCs
            VerificaComunicacao()

            'Monta Dados para comunicacao com os Clientes
            LeDados()

            Thread.Sleep(1000)

        End While

    End Sub

    Private Sub VerificaComunicacao()

        Try
            'Verifica comunicação com o PLC da Central 1
            If CommCentral <> True Then

                CommCentral = OpcMonta()

                If CommCentral = True Then
                    LogAdd("===> CommCentral1 - OPC criado - retornou True <===")
                Else
                    LogAdd("===> CommCentral1 - OPC retornou False <===")
                End If
            End If
        Catch
            LogAdd("===> CommCentral1 - ERRO ao montar OPC <===")
        End Try

    End Sub

    Private Sub LeDados()

        Static ContaTimer As Integer = 0
        Static ContaTq As Integer = 0

        ContaTimer = ContaTimer + 1
        If ContaTimer <= 2 Then Return
        ContaTimer = 0

        MistD.LeituraDadosPlc = True

        'Incrementa contador
        If ContaTq > MistD.Dados.Count - 1 Then ContaTq = 0

        If MistD.Dados(ContaTq).Tipo = clsMistDIt.enmTqTipo.Tanque Then

            'Tq
            Dim Ret As Boolean = TrataTq(MistD.Dados(ContaTq))
            If Ret = False Then MistD.LeituraDadosPlc = False

        ElseIf MistD.Dados(ContaTq).Tipo = clsMistDIt.enmTqTipo.Past Then

            'Pasteurizador
            Dim Ret As Boolean = TrataPast(MistD.Dados(ContaTq))
            If Ret = False Then MistD.LeituraDadosPlc = False

        ElseIf MistD.Dados(ContaTq).Tipo = clsMistDIt.enmTqTipo.Dosagem Then

            'Dosagem
            Dim Ret As Boolean = TrataDos(MistD.Dados(ContaTq))
            If Ret = False Then MistD.LeituraDadosPlc = False

        ElseIf MistD.Dados(ContaTq).Tipo = clsMistDIt.enmTqTipo.Relogio Then

            'Relogio
            Dim Ret As Boolean = TrataRelogio(MistD.Dados(ContaTq))
            If Ret = False Then MistD.LeituraDadosPlc = False

        End If
        ContaTq = ContaTq + 1


        If MistD.LeituraDadosPlc = True Then MistD.ContaD = MistD.ContaD + 1
        If MistD.ContaD > 9999 Then MistD.ContaD = 1
        Geral.SrvChkGrava("KbMistGrava", MistD.ContaD)

    End Sub

    Function OpcMonta() As Boolean

        Dim Hndl As Integer

        OpcSrv = New OPCAutomation.OPCServer

        Try
            OpcSrv.OPCGroups.Remove(cnstServerOpcGrupo)
            OpcSrv.OPCGroups.Remove(cnstServerOpcGrupoSts)
        Catch : End Try

        Try

            'Monta o grupo de tags OPC para Poll no CIP
            OpcSrv.Connect(OPC_SRV_NAME)
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupo)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = False


            For Each Tq In MistD.Dados
                With OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).OPCItems

                    'Ex: S7:[Opc2]DB1501,W868,5
                    Tq.MistT = .AddItem(Tq.DBDados, Hndl)

                End With
            Next

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).OPCItems.Count <> MistD.Dados.Count Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsSubscribed = True


            'Sts
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupoSts)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoSts).IsActive = False

            For Each Tq In MistD.Dados
                With OpcSrv.OPCGroups.Item(cnstServerOpcGrupoSts).OPCItems

                    'Ex: S7:[Opc2]DB1501,W868,5
                    Tq.MistTSts = .AddItem(Tq.DBSts, Hndl)

                End With
            Next

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupoSts).OPCItems.Count <> MistD.Dados.Count Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoSts).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoSts).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoSts).IsSubscribed = True


            Return True

        Catch ex As Exception

            LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

        End Try

        Return True

    End Function

    Function OpcDesmonta() As Boolean

        Try
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = False
        Catch ex As Exception
        End Try

        Try
            OpcSrv.OPCGroups.RemoveAll()
            OpcSrv.Disconnect()

            Return True

        Catch ex As Exception

            LogAdd("OpcDesmonta - Ocorreu uma falha ao desconectar o OPC CipSts")
            Return False

        End Try

    End Function

    Public Function BuscaDados() As clsMistD Implements clsIMist.BuscaDados
        Return MistD
    End Function

End Class

<ServiceContract()> _
Public Interface clsIMist

    <OperationContract()> _
    Function BuscaDados() As clsMistD

End Interface
