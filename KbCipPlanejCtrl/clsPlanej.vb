Public Class clsPlanej
    Implements clsIPlanej

    Dim Trd As Thread
    Dim TrdRun As Boolean = False

    Public CommCentral As Boolean = False
    Public OpcCipSts As OPCAutomation.OPCServer
    Public Const cnstServerOpcGrupo = "CipSts"
    Public ContaEnviaErro As Integer = 0

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

        ReDim PlanejT(CIRC_MAX_NUM)
 
        'PlanejT e PlanejHist
        For Conta As Integer = 0 To CIRC_MAX_NUM

            PlanejT(Conta) = New clsPlanejT
 
        Next


        'PlanejD
        PlanejD = New clsPlanejD

        For Conta As Integer = 0 To CIRC_MAX_NUM
            PlanejD.Dados.Add(New clsPlanejDados(Conta, 1))
        Next


        CommCentral = False

    End Sub

    Sub TrdTrata()

        'Try
        Dim HoraAnt As Integer = -1

        'Verifica comunicação com os PLCs
        'VerificaComunicacao()

        While TrdRun = True

            ''Verifica comunicação com os PLCs
            VerificaComunicacao()

            'Monta Dados para comunicacao com os Clientes
            LeDados()

            'Verifica o estado dos circuitos de CIP
            VerificaPlanej()

            'Atualiza a programação do dia à meia-noite
            If Now.Hour = 0 And HoraAnt <> 0 Then
                Geral.ChkSchedPer()
            End If
            HoraAnt = Now.Hour


            Thread.Sleep(1000)

        End While

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    LogAdd("===> TrdTrata - Erro ao verificar dados <===")
        'End Try

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

        PlanejD.LeituraDadosPlc = True

        'Atualiza dados de PlanejD
        For Conta As Integer = 0 To CIRC_MAX_NUM

            Try

                PlanejD.Dados(Conta).Sts = PlanejT(Conta).Sts.Value
                PlanejD.Dados(Conta).RotaId = PlanejT(Conta).RotaId.Value
                PlanejD.Dados(Conta).RecNum = PlanejT(Conta).RecNum.Value

                'DB240
                PlanejD.Dados(Conta).Vazao = PlanejT(Conta).Vazao.Value
                PlanejD.Dados(Conta).Temp = PlanejT(Conta).Temp.Value
                PlanejD.Dados(Conta).Cond = PlanejT(Conta).Cond.Value
                PlanejD.Dados(Conta).BlkNum = PlanejT(Conta).BlkNum.Value
                PlanejD.Dados(Conta).BlkPasso = PlanejT(Conta).BlkPasso.Value

                If PlanejT(Conta).Pausa.Value = 0 Then
                    PlanejD.Dados(Conta).Pausa = False
                Else
                    PlanejD.Dados(Conta).Pausa = True
                End If


            Catch ex As Exception
                PlanejD.LeituraDadosPlc = False
            End Try

        Next

        If PlanejD.LeituraDadosPlc = True Then PlanejD.ContaD = PlanejD.ContaD + 1
        If PlanejD.ContaD > 9999 Then PlanejD.ContaD = 1
        Geral.SrvChkGrava("KbCipPlanejCtrl", PlanejD.ContaD)

    End Sub

    Private Sub VerificaPlanej()

        Static Conta As Integer = 0

        'Verifica se um circuito está executando ou finalizou o CIP para salvar o historico
        'For Conta As Integer = 0 To CIRC_MAX_NUM

        If PlanejD.Dados(Conta).Sts = RECEITA_EXECUCAO Then

            'Cip em execução
            TrataCipDados(Conta)

        ElseIf PlanejD.Dados(Conta).Sts = RECEITA_FIM Or PlanejD.Dados(Conta).Sts = RECEITA_ABORTADO Then

            'Fim de CIP
            LogAdd("Verifica Planej - Circuito [" & Conta & "] Finalizado, registrando historico")

            'Cip finalizado, salva o historico
            TrataCipFim(Conta, PlanejD.Dados(Conta).Sts)

            'Passa circuito para estado parado
            PlanejT(Conta).Sts.Write(RECEITA_PARADA)

        End If

        'Next

        'Procura proximo planejamento
        'For Conta As Integer = 0 To CIRC_MAX_NUM

        If PlanejD.Dados(Conta).Sts = RECEITA_PARADA And PlanejD.Dados(Conta).Exec = True Then

            'Inicia o CIP
            CipIniCtrl(Conta)

        End If
        'Next

        'Soma 1
        Conta = Conta + 1
        If Conta > CIRC_MAX_NUM Then Conta = 0

    End Sub

    Function OpcMonta() As Boolean

        Dim Hndl As Integer

        OpcCipSts = New OPCAutomation.OPCServer

        Try
            OpcCipSts.OPCGroups.Remove(cnstServerOpcGrupo)
        Catch : End Try

        Try

            'Monta o grupo de tags OPC para Poll no CIP
            OpcCipSts.Connect(OPC_SRV_NAME)
            OpcCipSts.OPCGroups.Add(cnstServerOpcGrupo)
            OpcCipSts.OPCGroups.Item(cnstServerOpcGrupo).IsActive = False

            For Conta As Integer = 0 To CIRC_MAX_NUM

                With OpcCipSts.OPCGroups.Item(cnstServerOpcGrupo).OPCItems

                    PlanejT(Conta).Sts = .AddItem(OpcTagMonta(PlcTopicoAs1, OpcCipDbCtrl(Conta), OpcTagMontaTipo.Word, 400), Hndl)
                    PlanejT(Conta).RotaId = .AddItem(OpcTagMonta(PlcTopicoAs1, OpcCipDbCtrl(Conta), OpcTagMontaTipo.Word, 402), Hndl)
                    PlanejT(Conta).RecNum = .AddItem(OpcTagMonta(PlcTopicoAs1, OpcCipDbCtrl(Conta), OpcTagMontaTipo.Word, 406), Hndl)

                    If Conta >= 0 And Conta <= 4 Then

                        'DB DE GRAFICO 240
                        PlanejT(Conta).Vazao = .AddItem(OpcTagMonta(PlcTopicoAs1, 240, OpcTagMontaTipo.Real, OpcCipDbVlPos(Conta, OpcTagVl.Vazao)), Hndl)
                        PlanejT(Conta).Temp = .AddItem(OpcTagMonta(PlcTopicoAs1, 240, OpcTagMontaTipo.Real, OpcCipDbVlPos(Conta, OpcTagVl.Temp)), Hndl)
                        PlanejT(Conta).Cond = .AddItem(OpcTagMonta(PlcTopicoAs1, 240, OpcTagMontaTipo.Real, OpcCipDbVlPos(Conta, OpcTagVl.Cond)), Hndl)
                        PlanejT(Conta).BlkNum = .AddItem(OpcTagMonta(PlcTopicoAs1, 240, OpcTagMontaTipo.Word, OpcCipDbVlPos(Conta, OpcTagVl.BlkNum)), Hndl)
                        PlanejT(Conta).BlkPasso = .AddItem(OpcTagMonta(PlcTopicoAs1, 240, OpcTagMontaTipo.Word, OpcCipDbVlPos(Conta, OpcTagVl.BlkPasso)), Hndl)
                        PlanejT(Conta).Pausa = .AddItem(OpcTagMonta(PlcTopicoAs1, 240, OpcTagMontaTipo.Word, OpcCipDbVlPos(Conta, OpcTagVl.Pausa)), Hndl)

                    ElseIf Conta >= 5 And Conta <= 9 Then

                        'DB DE GRAFICO 380
                        PlanejT(Conta).Vazao = .AddItem(OpcTagMonta(PlcTopicoAs1, 380, OpcTagMontaTipo.Real, OpcCipDbVlPos(Conta, OpcTagVl.Vazao)), Hndl)
                        PlanejT(Conta).Temp = .AddItem(OpcTagMonta(PlcTopicoAs1, 380, OpcTagMontaTipo.Real, OpcCipDbVlPos(Conta, OpcTagVl.Temp)), Hndl)
                        PlanejT(Conta).Cond = .AddItem(OpcTagMonta(PlcTopicoAs1, 380, OpcTagMontaTipo.Real, OpcCipDbVlPos(Conta, OpcTagVl.Cond)), Hndl)
                        PlanejT(Conta).BlkNum = .AddItem(OpcTagMonta(PlcTopicoAs1, 380, OpcTagMontaTipo.Word, OpcCipDbVlPos(Conta, OpcTagVl.BlkNum)), Hndl)
                        PlanejT(Conta).BlkPasso = .AddItem(OpcTagMonta(PlcTopicoAs1, 380, OpcTagMontaTipo.Word, OpcCipDbVlPos(Conta, OpcTagVl.BlkPasso)), Hndl)
                        PlanejT(Conta).Pausa = .AddItem(OpcTagMonta(PlcTopicoAs1, 380, OpcTagMontaTipo.Word, OpcCipDbVlPos(Conta, OpcTagVl.Pausa)), Hndl)

                    End If

                End With

            Next

            If OpcCipSts.OPCGroups.Item(cnstServerOpcGrupo).OPCItems.Count <> ((CIRC_MAX_NUM + 1) * 9) Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcCipSts.OPCGroups.Item(cnstServerOpcGrupo).UpdateRate = 1000
            OpcCipSts.OPCGroups.Item(cnstServerOpcGrupo).IsActive = True
            OpcCipSts.OPCGroups.Item(cnstServerOpcGrupo).IsSubscribed = True

            Return True

        Catch ex As Exception

            LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

        End Try

        Return True

    End Function

    Function OpcDesmonta() As Boolean

        Try
            OpcCipSts.OPCGroups.Item("CipSts").IsActive = False
        Catch ex As Exception
        End Try

        Try
            OpcCipSts.OPCGroups.RemoveAll()
            OpcCipSts.Disconnect()

            Return True

        Catch ex As Exception

            LogAdd("OpcDesmonta - Ocorreu uma falha ao desconectar o OPC CipSts")
            Return False

        End Try

    End Function

    Public Function CipIniCtrl(ByVal CircNum As Integer) As Boolean

        'Busca dados do banco de dados
        Dim myCircTxt As String = Geral.CircTxt(CircNum)

        LogAdd("Verifica Planej - Verificando novo planejamento no Circuito [" & CircNum & "]")

        'Verifica se há um CIP aberto neste circuito
        'CipCircChk(CircNum)

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedProg = (From It In DbCv.CipSchedProg Where It.Circ = myCircTxt And It.Sts = 1
                              Order By It.DataHora).ToList
        If dtCipSchedProg.Count <= 0 Then Return False

        Dim RotaId As Integer = dtCipSchedProg(0).RotaId
        Dim dtCadRotasVl = (From It In DbCv.CadRotasVl Where It.RotaId = RotaId).ToList
        If dtCadRotasVl.Count <= 0 Then Return False

        Dim DataLim As Date = DateAdd(DateInterval.Minute, -2, Now)
        Dim FlagAtrasado As Boolean = False
        If dtCipSchedProg(0).DataHora <= DataLim Then FlagAtrasado = True


        'Insere registros de histórico de CIP
        Dim CipIdNw As Integer = Geral.BuscaCipIdNew
        Dim NwCh As New Geral.nsCipValid.CipHist With {.CipId = CipIdNw, .RotaId = dtCipSchedProg(0).RotaId,
                            .Circ = Geral.CircTxt(CircNum), .RecNum = dtCipSchedProg(0).RecNum,
                            .DataHoraIni = Geral.TseNow, .DataHoraFim = Util.DataInvalida,
                            .UserId = dtCipSchedProg(0).UserId, .Status = 1, .LimRev = dtCadRotasVl(0).LimRevAtual,
                            .UserIdValid = 0, .FlagAtrasado = FlagAtrasado, .FlagCancelado = 0}
        DbCv.CipHist.InsertOnSubmit(NwCh)

        Dim dtCadRotaPtoCr = (From It In DbCv.CadRotaPtoCr Where It.RotaId = RotaId
                              Order By It.Seq).ToList

        For ContaPtCr As Integer = 0 To dtCadRotaPtoCr.Count - 1

            Dim NwChpc As New Geral.nsCipValid.CipHistPtoCr With {.CipId = CipIdNw,
                        .PtoCrId = dtCadRotaPtoCr(ContaPtCr).PtoCrId, .Resp = 0}
            DbCv.CipHistPtoCr.InsertOnSubmit(NwChpc)

        Next

        If FlagAtrasado = 1 Then

            'Caso o CIP esteja atrasado, insere uma anormalidade
            Dim NwCha As New Geral.nsCipValid.CipHistAnorm With {.CipId = CipIdNw, .AnormId = 1,
                            .DataHora = Now, .AnormEquip = 4, .AnormEvnt = 0, .ObsSts = 1,
                            .Obs = "Este CIP iniciou atrasado.", .BlkNum = 0, .BlkPasso = 0}

            DbCv.CipHistAnorm.InsertOnSubmit(NwCha)

        End If


        'Envia dados aos PLCs
        LogAdd("Verifica Planej - Enviando planejamento no Circuito [" & CircNum & "] - Rota [" & dtCipSchedProg(0).RotaId & "]" &
               " - Receita [" & dtCipSchedProg(0).RecNum & "]")

        Dim Ret As Boolean = CipPlanejEnvia(myCircTxt, dtCipSchedProg(0).RotaId, dtCipSchedProg(0).RecNum)

        If Ret = False Then
            'Erro enviando planejamento de CIP
            ContaEnviaErro = ContaEnviaErro + 1
            LogAdd("Verifica Planej - ERRO [" & ContaEnviaErro & "] enviando planejamento no Circuito [" & CircNum & "] - Rota [" & dtCipSchedProg(0).RotaId & "]" &
                   " - Receita [" & dtCipSchedProg(0).RecNum & "]")

            If ContaEnviaErro > 5 Then
                LogAdd("Verifica Planej - DESLIGAMENTO DO PROGRAMA devido a ERRO de envio de planejamento de CIP")
                End
            End If

            Return False
        End If

        ContaEnviaErro = 0


        'Deleta item da programação de CIP
        Try
            LogAdd("Verifica Planej - Apagando planejamento do Circuito [" & CircNum & "] no banco de dados")

            Dim ProgId As Integer = dtCipSchedProg.First.ProgId
            Dim dtCsp = (From It In DbCv.CipSchedProg Where It.ProgId = ProgId).ToList
            If dtCsp.Count > 0 Then DbCv.CipSchedProg.DeleteOnSubmit(dtCsp.First)
        Catch ex As Exception
            LogAdd("Verifica Planej - Falha ao apagar planejamento no banco de dados")
        End Try

        DbCv.SubmitChanges()

        Return True

    End Function

    Function CipCircChk(ByVal CircNum As Integer) As Boolean

        'Busca a identificacao da rota deste gurpo que esta em execucao
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.Status = 1 And It.Circ = Geral.CircTxt(CircNum)).ToList
 
        For Conta As Integer = 0 To dtCipHist.Count - 1

            'Fecha históricos de CIP anteriores que morreram erradamente no status 1 para este circuito
            dtCipHist(Conta).Status = 2
            dtCipHist(Conta).UserIdValid = 0

        Next

        DbCv.SubmitChanges()

        Return True

    End Function

    Public Sub CmdStart(ByVal CircNum As Integer) Implements clsIPlanej.CmdStart

        If CircNum < 0 Or CircNum > CIRC_MAX_NUM Then Return

        PlanejD.Dados(CircNum).Exec = True

    End Sub

    Public Sub CmdStop(ByVal CircNum As Integer) Implements clsIPlanej.CmdStop

        If CircNum < 0 Or CircNum > CIRC_MAX_NUM Then Return

        PlanejD.Dados(CircNum).Exec = False

    End Sub

    Public Function BuscaDados() As clsPlanejD Implements clsIPlanej.BuscaDados
        Return PlanejD
    End Function

End Class

<ServiceContract()> _
Public Interface clsIPlanej

    <OperationContract()> _
    Function BuscaDados() As clsPlanejD

    <OperationContract()> _
    Sub CmdStart(ByVal CircNum As Integer)

    <OperationContract()> _
    Sub CmdStop(ByVal CircNum As Integer)

End Interface
