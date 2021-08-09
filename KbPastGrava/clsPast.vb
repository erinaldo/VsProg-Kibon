Public Class clsPast
    Implements clsIPast

    Dim Trd As Thread
    Dim TrdRun As Boolean = False

    Public CommCentral As Boolean = False
    Public OpcSrv As OPCAutomation.OPCServer
    Public Const cnstServerOpcGrupo = "PastPoll"


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
        PastD = New clsPastD

        PastD.Dados.Add(New clsPastDIt(1))
        PastD.Dados.Add(New clsPastDIt(2))

        PastD.DadosCip.Add(New clsCipDIt(1))
        PastD.DadosCip.Add(New clsCipDIt(2))

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

            'Atualiza a programação do dia à meia-noite
            If Now.Hour = 0 And HoraAnt <> 0 Then
                Geral.ChkSchedPer()
            End If
            HoraAnt = Now.Hour


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

        Static HoraAnt As Integer
        Static Conta As Integer

        'Conta ate 6 para executar gravacao de dados a cada (6 * 5) = 30 seg
        Conta = Conta + 1
        'If Conta >= 6 Then Conta = 0
        If Conta >= 30 Then Conta = 0

        Dim Ret1 As Boolean = TrataDados(Conta)
        Dim Ret2 As Boolean = TrataDadosCip(Conta)

        If Ret1 And Ret2 Then
            PastD.LeituraDadosPlc = True
        Else
            PastD.LeituraDadosPlc = False
        End If

        'Apaga dados antigos
        Dim Hora As Integer = Val(Format(Now, "HH"))
        If Hora = 0 And HoraAnt = 23 Then
            DeletaDadosAntigos()
        End If

        HoraAnt = Hora

        If PastD.LeituraDadosPlc = True Then PastD.ContaD = PastD.ContaD + 1
        If PastD.ContaD > 9999 Then PastD.ContaD = 1
        Geral.SrvChkGrava("KbPastGrava", PastD.ContaD)

    End Sub

    Function OpcMonta() As Boolean

        Dim Hndl As Integer

        OpcSrv = New OPCAutomation.OPCServer

        Try
            OpcSrv.OPCGroups.Remove(cnstServerOpcGrupo)
        Catch : End Try

        Try

            'Monta o grupo de tags OPC para Poll no CIP
            OpcSrv.Connect(OPC_SRV_NAME)
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupo)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = False

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).OPCItems

                'S7:[Opc2]DB191,INT0,40
                PastT = .AddItem(OpcTagMonta(PlcTopicoAs2, 191, OpcTagMontaTipo.Int, 0, 40), Hndl)

            End With

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).OPCItems

                'S7:[Opc2]DB191,INT0,40
                CipRT = .AddItem(OpcTagMonta(PlcTopicoAs2, 241, OpcTagMontaTipo.Real, 0, 6), Hndl)
                CipIT = .AddItem(OpcTagMonta(PlcTopicoAs2, 241, OpcTagMontaTipo.Int, 24, 12), Hndl)
 
            End With


            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).OPCItems.Count <> 3 Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupo).IsSubscribed = True

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

    Public Function BuscaDados() As clsPastD Implements clsIPast.BuscaDados
        Return PastD
    End Function

End Class

<ServiceContract()> _
Public Interface clsIPast

    <OperationContract()> _
    Function BuscaDados() As clsPastD

End Interface
