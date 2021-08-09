Module basTrataHist

    Sub TrataCipDados(ByVal CircNum As Integer)

        Dim MyCip As clsPlanejDados = PlanejD.Dados(CircNum)

        If MyCip.CipId <= 0 Then

            Dim Ret As Boolean = MyCip.BuscaRotaDados(CircNum)
            If Ret = False Then Return

        End If


        'Mudou de passo, memoriza a hora de inicio deste passo
        If MyCip.BlkNum <> MyCip.BlkNumAnt Then
            MyCip.DataPassoIni = Geral.TseNow
        End If
        MyCip.BlkNumAnt = MyCip.BlkNum


        Dim Lims = (From It In MyCip.dtCadRotasLim Where It.blkNum = MyCip.BlkNum).tolist
        If Lims.Count > 0 Then

            'Gera os eventos
            Dim TempStsNovo As clsCipVarSts = BuscaTempSts(MyCip, MyCip.Temp, Lims(0))
            If MyCip.TempSts <> TempStsNovo Then
                AnormGrava(MyCip.CipId, 1, MyCip.TempSts, TempStsNovo, MyCip.BlkNum, MyCip.BlkPasso)
                MyCip.TempSts = TempStsNovo
            End If

            Dim CondStsNovo As clsCipVarSts = BuscaCondSts(MyCip, MyCip.Cond, Lims(0))
            If MyCip.CondSts <> CondStsNovo Then
                AnormGrava(MyCip.CipId, 2, MyCip.CondSts, CondStsNovo, MyCip.BlkNum, MyCip.BlkPasso)
                MyCip.CondSts = CondStsNovo
            End If

            Dim VazaoStsNovo As clsCipVarSts = BuscaVazaoSts(MyCip, MyCip.Vazao, Lims(0))
            If MyCip.VazaoSts <> VazaoStsNovo Then
                AnormGrava(MyCip.CipId, 3, MyCip.VazaoSts, VazaoStsNovo, MyCip.BlkNum, MyCip.BlkPasso)
                MyCip.VazaoSts = VazaoStsNovo
            End If

            'Verifica intervalo de gravação
            Dim NSeg As Integer = DateDiff(DateInterval.Second, MyCip.DataUltGravacao, Now)
            If TempStsNovo = clsCipVarSts.Ok And CondStsNovo = clsCipVarSts.Ok And VazaoStsNovo = clsCipVarSts.Ok Then

                'Nao está ocorrendo nenhuma anormalidade
                If NSeg < 30 Then Return

            Else

                'Está ocorrendo algum anormalidade
                If NSeg < 10 Then Return

            End If

        End If


        'Salva no banco de dados
        Dim DbCv As New Geral.nsCipValid.dcCipValid

        Try
            Dim NwChd As New Geral.nsCipValid.CipHistDados With {.CipId = MyCip.CipId, .DataHora = Geral.TseNow,
                                                .Temp = MyCip.Temp, .Cond = MyCip.Cond, .Vazao = MyCip.Vazao,
                                                .BlkNum = MyCip.BlkNum, .BlkPasso = MyCip.BlkPasso}
            DbCv.CipHistDados.InsertOnSubmit(NwChd)
        Catch : End Try

        MyCip.DataUltGravacao = Geral.TseNow


        'Gera anormalidade de Pausa
        If MyCip.Pausa = True And MyCip.PausaAnt = False Then
            Dim AnormIdNovo As Integer = Geral.BuscaAnormIdNew(MyCip.CipId)

            Dim NwCha As New Geral.nsCipValid.CipHistAnorm With {.CipId = MyCip.CipId, .AnormId = AnormIdNovo, .DataHora = Now,
                                                                 .AnormEquip = 6, .AnormEvnt = 0, .ObsSts = 0, .Obs = "",
                                                                 .BlkNum = MyCip.BlkNum, .BlkPasso = MyCip.BlkPasso}
            DbCv.CipHistAnorm.InsertOnSubmit(NwCha)

        End If

        DbCv.SubmitChanges()

        MyCip.PausaAnt = MyCip.Pausa

    End Sub

    Function BuscaTempSts(ByVal MyCip As clsPlanejDados, ByVal Temp As Double,
                          ByVal Lim As Geral.nsCipValid.CadRotasLim) As clsCipVarSts

        'Verifica se neste bloco se usa temperatura
        Dim ChkTemp As Boolean = BuscaBlkTemp(MyCip.BlkNum, MyCip.BlkPasso)
        If ChkTemp = False Then Return clsCipVarSts.Ok

        'Verifica se o tempo de ajuste do passo já acabou
        Dim DataPassoOk As Date = DateAdd(DateInterval.Second, CDbl(Lim.TempoAjuste), MyCip.DataPassoIni)
        If Now < DataPassoOk Then Return clsCipVarSts.Ok

        If Temp > Lim.TempMax Then Return clsCipVarSts.Acima
        If Temp < Lim.TempMin Then Return clsCipVarSts.Abaixo

        Return clsCipVarSts.Ok

    End Function

    Function BuscaBlkTemp(BlkNum As Integer, BlkPasso As Integer) As Boolean

        If BlkNum = 1 Then

            'Enxágue inicial
            If BlkPasso = 3 Then Return True

        ElseIf BlkNum = 2 Then

            'TPCOLD - Soda
            If BlkPasso = 1 Or BlkPasso = 3 Then Return True

        ElseIf BlkNum = 3 Then

            'Ácido
            If BlkPasso >= 1 And BlkPasso <= 5 Then Return True

        ElseIf BlkNum = 4 Then

            'Sanitização
            If BlkPasso >= 1 And BlkPasso <= 3 Then Return True

        ElseIf BlkNum = 7 Then

            'Enxágue Final

        End If

        'Não usa temperatura
        Return False

    End Function

    Function BuscaCondSts(ByVal MyCip As clsPlanejDados, ByVal Cond As Double,
                          ByVal Lim As Geral.nsCipValid.CadRotasLim) As clsCipVarSts

        'Verifica se neste bloco se usa condutividade
        Dim ChkCond As Boolean = BuscaBlkCond(MyCip.BlkNum, MyCip.BlkPasso)
        If ChkCond = False Then Return clsCipVarSts.Ok

        'Verifica se o tempo de ajuste do passo já acabou
        Dim DataPassoOk As Date = DateAdd(DateInterval.Second, CDbl(Lim.TempoAjuste), MyCip.DataPassoIni)
        If Now < DataPassoOk Then Return clsCipVarSts.Ok

        If Cond > Lim.CondMax Then Return clsCipVarSts.Acima
        If Cond < Lim.CondMin Then Return clsCipVarSts.Abaixo

        Return clsCipVarSts.Ok

    End Function

    Function BuscaBlkCond(BlkNum As Integer, BlkPasso As Integer) As Boolean

        If BlkNum = 1 Then

            'Enxágue inicial
 
        ElseIf BlkNum = 2 Then

            'TPCOLD - Soda
            If BlkPasso = 3 Then Return True

        ElseIf BlkNum = 3 Then

            'Ácido
            If BlkPasso = 3 Then Return True

        ElseIf BlkNum = 4 Then

            'Sanitização

        ElseIf BlkNum = 7 Then

            'Enxágue Final

        End If

        'Não usa condutividade
        Return False

    End Function

    Function BuscaVazaoSts(ByVal MyCip As clsPlanejDados, ByVal Vazao As Double,
                           ByVal Lim As Geral.nsCipValid.CadRotasLim) As clsCipVarSts

        'Verifica se neste bloco se usa vazão
        Dim ChkVazao As Boolean = BuscaBlkVazao(MyCip.BlkNum, MyCip.BlkPasso)
        If ChkVazao = False Then Return clsCipVarSts.Ok

        'Verifica se o tempo de ajuste do passo já acabou
        Dim DataPassoOk As Date = DateAdd(DateInterval.Second, CDbl(Lim.TempoAjuste), MyCip.DataPassoIni)
        If Now < DataPassoOk Then Return clsCipVarSts.Ok

        If Vazao > Lim.VazaoMax Then Return clsCipVarSts.Acima
        If Vazao < Lim.VazaoMin Then Return clsCipVarSts.Abaixo

        Return clsCipVarSts.Ok

    End Function

    Function BuscaBlkVazao(BlkNum As Integer, BlkPasso As Integer) As Boolean

        If BlkNum = 1 Then

            'Enxágue inicial
            If BlkPasso = 1 Or BlkPasso = 3 Then Return True

        ElseIf BlkNum = 2 Then

            'TPCOLD - Soda
            If BlkPasso = 1 Or BlkPasso = 3 Or
               BlkPasso = 4 Or BlkPasso = 6 Then Return True

        ElseIf BlkNum = 3 Then

            'Ácido
            If BlkPasso >= 1 And BlkPasso <= 5 Then Return True

        ElseIf BlkNum = 4 Then

            'Sanitização
            If BlkPasso >= 1 And BlkPasso <= 3 Then Return True

        ElseIf BlkNum = 7 Then

            'Enxágue Final
            If BlkPasso = 1 Then Return True

        End If

        'Não usa temperatura
        Return False

    End Function

    Sub AnormGrava(ByVal CipId As Integer, ByVal AnormEquip As Integer, _
                ByVal StsAtual As clsCipVarSts, ByVal StsNovo As clsCipVarSts, _
                ByVal BlkNum As Integer, ByVal BlkPasso As Integer)


        Dim AnormEvnt As Integer = 0
        If StsAtual = clsCipVarSts.Ok And StsNovo = clsCipVarSts.Acima Then
            'Normal->Alto
            AnormEvnt = 1
        ElseIf StsAtual = clsCipVarSts.Acima And StsNovo = clsCipVarSts.Ok Then
            'Alto->Normal
            AnormEvnt = 2
        ElseIf StsAtual = clsCipVarSts.Ok And StsNovo = clsCipVarSts.Abaixo Then
            'Normal->Baixo
            AnormEvnt = 3
        ElseIf StsAtual = clsCipVarSts.Abaixo And StsNovo = clsCipVarSts.Ok Then
            'Baixo->Normal
            AnormEvnt = 4
        End If


        'Verifica se é necessário que o operador digite a observacao posteriormente
        Dim ObsSts As Integer = 0
        If AnormEvnt = 2 Or AnormEvnt = 4 Then ObsSts = 2

        Dim AnormIdNovo As Integer = Geral.BuscaAnormIdNew(CipId)

        'Salva no banco de dados
        Dim DbCv As New Geral.nsCipValid.dcCipValid

        Dim NwCha As New Geral.nsCipValid.CipHistAnorm With {.CipId = CipId, .AnormId = AnormIdNovo, .DataHora = Now,
                                                               .AnormEquip = AnormEquip, .AnormEvnt = AnormEvnt, .ObsSts = ObsSts,
                                                               .Obs = "", .BlkNum = BlkNum, .BlkPasso = BlkPasso}
        DbCv.CipHistAnorm.InsertOnSubmit(NwCha)

        DbCv.SubmitChanges()

    End Sub

    Sub TrataCipFim(ByRef CircNum As Integer, ByVal Sts As Integer)

        Dim MyCip As clsPlanejDados = PlanejD.Dados(CircNum)

        If MyCip.CipId <= 0 Then

            Dim Ret As Boolean = MyCip.BuscaRotaDados(CircNum)
            If Ret = False Then
                LogAdd("TrataCipFim - Erro: BuscaRotaDados retornou False CircNum = [" & CircNum & "]; Sts = [" & Sts & "]")
                Return
            End If

        End If

        'Verifica se o tempo de CIP foi ultrapassado
        AnormFimTempoMax(MyCip.CipId, MyCip.RotaId, MyCip.RecNum)

        'Verifica se foi cancelado
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.CipId = MyCip.CipId).ToList
        If Sts = RECEITA_ABORTADO Then
            If dtCipHist.Count > 0 Then dtCipHist.First.FlagCancelado = 1
        End If

        'Finaliza este CIP
        If dtCipHist.Count > 0 Then
            dtCipHist.First.DataHoraFim = Geral.TseNow
            dtCipHist.First.Status = 2
        End If
        DbCv.SubmitChanges()

        'Reseta os dados deste grupo de CIP
        MyCip.CipId = 0
        MyCip.RotaId = 0
        MyCip.LimRev = 0

        'Variaveis de status de eventos
        MyCip.TempSts = 0
        MyCip.CondSts = 0
        MyCip.VazaoSts = 0
        MyCip.DataUltGravacao = New Date(2000, 1, 1)
        MyCip.DataPassoIni = New Date(2000, 1, 1)

        LogAdd("TrataCipFim - Cip Finalizado CircNum = [" & CircNum & "]; Sts = [" & Sts & "]")

    End Sub

    Function AnormFimTempoMax(ByVal CipId As Integer, ByVal RotaId As Integer, ByVal RecNum As Integer) As Boolean

        'Verifica se o tempo total deste CIP ultrapassou o previsto mais uma porcentagem programada em CadRotas

        'Dados de cadastro
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotasVl = (From It In DbCv.CadRotasVl Where It.RotaId = RotaId).ToList
        If dtCadRotasVl.Count <= 0 Then Return False

        Dim PrcTempoMax As Integer = dtCadRotasVl(0).PrcTempoMax


        'Dados deste CIP
        Dim dtCipHist = (From It In DbCv.CipHist Where It.CipId = CipId).ToList
        If dtCipHist.Count <= 0 Then Return False

        Dim DataHoraIni As Date = dtCipHist(0).DataHoraIni


        'Dados de tempo programado
        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtBlocosItens = (From It In DbRc.BlocosItens Where It.Area = "CIP"
                             Order By It.BlkNum, It.ItemSeq).ToList

        Dim dtRecBlocos = (From It In DbRc.RecBlocos Where It.Area = "CIP" And It.RecNum = RecNum
                           Order By It.ItemSeq).ToList

        'Loop para cada bloco de CIP
        Dim TempoProg As Integer = 0
        For ContaBlk As Integer = 0 To dtRecBlocos.Count - 1

            'Verifica se este bloco de CIP tem parametros de temporização
            Dim BlkNum As Integer = dtRecBlocos(ContaBlk).BlkNum
            Dim Prms = (From It In dtBlocosItens Where It.BlkNum = BlkNum).ToList

            For ContaPrm As Integer = 0 To Prms.Count - 1

                If Prms(ContaPrm).UEng = "seg" Then

                    'É parâmetro de tempo, acumula o tempo programado
                    TempoProg = TempoProg + BuscaPrm(dtRecBlocos(ContaBlk), ContaPrm)

                End If
            Next
        Next


        'Tempo decorrido
        Dim TempoCip As Integer = DateDiff(DateInterval.Second, DataHoraIni, Geral.TseNow)
        Dim TempoMax = TempoProg + TempoProg * PrcTempoMax / 100.0
        If TempoCip < TempoMax Then Return False

        'Anormalidade de tempo de CIP acima do maximo mais porcentagem configurada
        Dim AnormIdNovo As Integer = Geral.BuscaAnormIdNew(CipId)

        'Salva no banco de dados

        Dim NwCha As New Geral.nsCipValid.CipHistAnorm With {.CipId = CipId, .AnormId = AnormIdNovo,
                                .DataHora = Now, .AnormEquip = 7, .AnormEvnt = 0, .ObsSts = 0, .Obs = "",
                                .BlkNum = 99, .BlkPasso = 99}
        DbCv.CipHistAnorm.InsertOnSubmit(NwCha)
        DbCv.SubmitChanges()

        Return True

    End Function

    Function BuscaPrm(ByVal rwRecBlocos As Geral.nsReceitas.RecBlocos, ByVal ContaPrm As Integer) As Integer

        Dim Prm As Integer = 0

        Select Case ContaPrm
            Case 0
                Prm = rwRecBlocos.Param01
            Case 1
                Prm = rwRecBlocos.Param02
            Case 2
                Prm = rwRecBlocos.Param03
            Case 3
                Prm = rwRecBlocos.Param04
            Case 4
                Prm = rwRecBlocos.Param05
            Case 5
                Prm = rwRecBlocos.Param06
            Case 6
                Prm = rwRecBlocos.Param07
            Case 7
                Prm = rwRecBlocos.Param08
            Case 8
                Prm = rwRecBlocos.Param09
        End Select

        Return Prm

    End Function

End Module
