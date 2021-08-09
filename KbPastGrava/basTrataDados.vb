Module basTrataDados

    Function TrataDados(ContaGrava) As Boolean

        'Le dados do PLC
        Dim Ret As Boolean = ExtraiDadosLidos()
        If Ret = False Then Return False

        For Conta = 0 To PastD.Dados.Count - 1

            'Relatorio do pasteurizador
            If PastD.Dados(Conta).Sts > 17 Then

                'Busca o CIpId
                If PastD.Dados(Conta).HistId = 0 Then
                    PastD.Dados(Conta).HistId = BuscaHistId(Conta)
                    CriaHist(PastD.Dados(Conta).PastId, PastD.Dados(Conta).HistId)
                End If

                'Grava a cada 30 segundos
                If ContaGrava = 0 Then
                    GravaDados(Conta)
                End If

            Else

                'Verifica se parou agora para marcar o CIP como finalizado
                'If PastD.Dados(Conta).Dado1 = 0 And PastD.Dados(Conta).Dado8 >= 2 Then
                '    'Parou agora
                '    MarcaCipFinalizado Conta
                'End If

                'Se o Cip estiver parado, zara o CIpId
                PastD.Dados(Conta).HistId = 0

            End If

            ' Fdv
            If PastD.Dados(Conta).Sts > 20 And PastD.Dados(Conta).Sts <= 46 Then

                'Busca o CIpId
                If PastD.Dados(Conta).FdvId = 0 Then
                    PastD.Dados(Conta).FdvId = BuscaFdvId(Conta)
                    CriaFdv(PastD.Dados(Conta).PastId, PastD.Dados(Conta).FdvId)
                End If

                'Grava a cada segundo
                GravaFdv(Conta)

            Else

                'Se o Cip estiver parado, zara o CIpId
                PastD.Dados(Conta).FdvId = 0

            End If


            'Memoriza o status anterior
            PastD.Dados(Conta).StsAnt = PastD.Dados(Conta).Sts

        Next

        Return True

    End Function

    'Comunicação
    Function ExtraiDadosLidos() As Boolean

        Try

            'Status de cada CIP
            Dim ListaRespPc() As Int16 = PastT.Value

            PastD.Dados(0).Sts = ListaRespPc(0)
            PastD.Dados(0).RecNum = ListaRespPc(0)
            PastD.Dados(0).TqOrig = ListaRespPc(2)
            PastD.Dados(0).TqDest = ListaRespPc(3)
            PastD.Dados(0).PressaoEst1 = ListaRespPc(4) / 10.0#
            PastD.Dados(0).PressaoEst2 = ListaRespPc(5) / 10.0#
            PastD.Dados(0).TempFdvPv = ListaRespPc(6) / 10.0#
            PastD.Dados(0).TempFdvSp = ListaRespPc(7) / 10.0#
            PastD.Dados(0).TempFinalPast = ListaRespPc(8) / 10.0#
            PastD.Dados(0).PresFinalPast = ListaRespPc(9) / 10.0#
            PastD.Dados(0).ValvFdvA = ListaRespPc(10) / 10.0#
            PastD.Dados(0).ValvFdvB = ListaRespPc(11) / 10.0#
            PastD.Dados(0).PresHomoEntr = ListaRespPc(12) / 10.0#
            PastD.Dados(0).PresHomoSaida = ListaRespPc(13) / 10.0#
            PastD.Dados(0).AguaAlcool = ListaRespPc(14) / 10.0#
            PastD.Dados(0).Reserva2 = ListaRespPc(15) / 10.0#
            PastD.Dados(0).Reserva3 = ListaRespPc(16) / 10.0#
            PastD.Dados(0).Reserva4 = ListaRespPc(17) / 10.0#
            PastD.Dados(0).Reserva5 = ListaRespPc(18) / 10.0#
            PastD.Dados(0).Reserva6 = ListaRespPc(19) / 10.0#


            PastD.Dados(1).Sts = ListaRespPc(20)
            PastD.Dados(1).RecNum = ListaRespPc(21)
            PastD.Dados(1).TqOrig = ListaRespPc(22)
            PastD.Dados(1).TqDest = ListaRespPc(23)
            PastD.Dados(1).PressaoEst1 = ListaRespPc(24) / 10.0#
            PastD.Dados(1).PressaoEst2 = ListaRespPc(25) / 10.0#
            PastD.Dados(1).TempFdvPv = ListaRespPc(26) / 10.0#
            PastD.Dados(1).TempFdvSp = ListaRespPc(27) / 10.0#
            PastD.Dados(1).TempFinalPast = ListaRespPc(28) / 10.0#
            PastD.Dados(1).PresFinalPast = ListaRespPc(29) / 10.0#
            PastD.Dados(1).ValvFdvA = ListaRespPc(30) / 10.0#
            PastD.Dados(1).ValvFdvB = ListaRespPc(31) / 10.0#
            PastD.Dados(1).PresHomoEntr = ListaRespPc(32) / 10.0#
            PastD.Dados(1).PresHomoSaida = ListaRespPc(33) / 10.0#
            PastD.Dados(1).AguaAlcool = ListaRespPc(34) / 10.0#
            PastD.Dados(1).Reserva2 = ListaRespPc(35) / 10.0#
            PastD.Dados(1).Reserva3 = ListaRespPc(36) / 10.0#
            PastD.Dados(1).Reserva4 = ListaRespPc(37) / 10.0#
            PastD.Dados(1).Reserva5 = ListaRespPc(38) / 10.0#
            PastD.Dados(1).Reserva6 = ListaRespPc(39) / 10.0#

        Catch
            Return False
        End Try

        Return True

    End Function

    'Relatório do pasteurizador
    Function BuscaHistId(Conta) As Long

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava
        Dim dtPastGravaHist = (From It In DbPg.PastGravaHist Order By It.HistId Descending).Take(1).ToList
        If dtPastGravaHist.Count <= 0 Then Return 1

        Return dtPastGravaHist.First.HistId + 1

    End Function

    Sub CriaHist(PastId, HistId)

        Dim Datahora As String = Format(Now, "yyyyMMddHHmmss")

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim NwPgh As New Geral.nsPastGrava.PastGravaHist With {.HistId = HistId, .DataHora = Datahora, .PastId = PastId}
        DbPg.PastGravaHist.InsertOnSubmit(NwPgh)
        DbPg.SubmitChanges()

    End Sub

    Function GravaDados(Conta) As Boolean

        If PastD.Dados(Conta).HistId = 0 Then Return False

        Dim Datahora As String = Format(Now, "yyyyMMddHHmmss")

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim NwPghd As New Geral.nsPastGrava.PastGravaHistDados With {.HistId = PastD.Dados(Conta).HistId,
                    .DataHora = Datahora,
                    .Sts = PastD.Dados(Conta).Sts,
                    .RecNum = PastD.Dados(Conta).RecNum,
                    .TqOrig = PastD.Dados(Conta).TqOrig,
                    .TqDest = PastD.Dados(Conta).TqDest,
                    .PressaoEst1 = PastD.Dados(Conta).PressaoEst1,
                    .PressaoEst2 = PastD.Dados(Conta).PressaoEst2,
                    .TempFdvPv = PastD.Dados(Conta).TempFdvPv,
                    .TempFdvSp = PastD.Dados(Conta).TempFdvSp,
                    .TempFinalPast = PastD.Dados(Conta).TempFinalPast,
                    .PresFinalPast = PastD.Dados(Conta).PresFinalPast,
                    .ValvFdvA = PastD.Dados(Conta).ValvFdvA,
                    .ValvFdvB = PastD.Dados(Conta).ValvFdvB,
                    .PresHomoEntr = PastD.Dados(Conta).PresHomoEntr,
                    .PresHomoSaida = PastD.Dados(Conta).PresHomoSaida,
                    .TempAguaAlcool = PastD.Dados(Conta).AguaAlcool,
                    .Reserva2 = 0,
                    .Reserva3 = 0,
                    .Reserva4 = 0,
                    .Reserva5 = 0,
                    .Reserva6 = 0}

        DbPg.PastGravaHistDados.InsertOnSubmit(NwPghd)
        DbPg.SubmitChanges()

        Return True

    End Function

    'Relatório do FDV
    Function BuscaFdvId(Conta) As Long

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava
        Dim dtFdvGravaHist = (From It In DbPg.FdvGravaHist Order By It.FdvId Descending).Take(1).ToList
        If dtFdvGravaHist.Count <= 0 Then Return 1

        Return dtFdvGravaHist.First.FdvId + 1

    End Function

    Sub CriaFdv(PastId, FdvId)

        Dim Datahora As String = Format(Now, "yyyyMMddHHmmss")

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim NwFgh As New Geral.nsPastGrava.FdvGravaHist With {.FdvId = FdvId, .DataHora = Datahora, .PastId = PastId}

        DbPg.FdvGravaHist.InsertOnSubmit(NwFgh)
        DbPg.SubmitChanges()

    End Sub

    Function GravaFdv(Conta) As Boolean

        Dim ValvA As Integer
        Dim ValvB As Integer

        If PastD.Dados(Conta).HistId = 0 Then Return False

        Dim Datahora As String = Format(Now, "yyyyMMddHHmmss")

        'Inverte as válvulas
        If PastD.Dados(Conta).ValvFdvA = 0 Then ValvA = 1
        If PastD.Dados(Conta).ValvFdvB = 0 Then ValvB = 1

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim NwFghd As New Geral.nsPastGrava.FdvGravaHistDados With {.FdvID = PastD.Dados(Conta).FdvId,
                                                                    .DataHora = Datahora,
                                                                    .TempFdvPv = PastD.Dados(Conta).TempFdvPv,
                                                                    .TempFdvSp = PastD.Dados(Conta).Reserva2,
                                                                    .ValvFdvA = ValvA,
                                                                    .ValvFdvB = ValvB}

        DbPg.FdvGravaHistDados.InsertOnSubmit(NwFghd)
        DbPg.SubmitChanges()

        Return True

    End Function

End Module
