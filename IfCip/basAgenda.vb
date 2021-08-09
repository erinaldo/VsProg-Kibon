Module basAgenda

    Sub AgendaMontaColunas(ByVal dtDados As DataTable)

        dtDados.Columns.Add("Modo")
        dtDados.Columns.Add("Id")
        dtDados.Columns.Add("RotaId")
        dtDados.Columns.Add("Grupo")
        dtDados.Columns.Add("Subgrupo")
        dtDados.Columns.Add("DataHora")
        dtDados.Columns.Add("Tipo")
        dtDados.Columns.Add("FlagAtrasado")

    End Sub

    Sub AgendaBuscaCipSchedProg(ByVal dtDados As DataTable)

        'CIPs programados
        Dim taCipSchedProg As New Geral.dsxCipValidTableAdapters.taxCipSchedProg
        Dim dtCipSchedProg As New Geral.dsxCipValid.CipSchedProgDataTable
        taCipSchedProg.Fill(dtCipSchedProg)

        For Conta As Integer = 0 To dtCipSchedProg.Rows.Count - 1
            With dtCipSchedProg(Conta)

                Dim FlagAtrasado As Integer = 0

                If .DataHora <= Now Then FlagAtrasado = 1
                
                dtDados.Rows.Add(0, .ProgId, .RotaId, .Grupo, .Subgrupo, .DataHora, .Tipo, FlagAtrasado)

            End With
        Next

    End Sub

    Sub AgendaBuscaCipSchedPer(ByVal dtDados As DataTable)

        'CIPs Periódicos
        Dim taCipSchedPer As New Geral.dsxCipValidTableAdapters.taxCipSchedPer
        Dim dtCipSchedPer As New Geral.dsxCipValid.CipSchedPerDataTable
        taCipSchedPer.Fill(dtCipSchedPer)


        For Conta As Integer = 0 To dtCipSchedPer.Rows.Count - 1
            With dtCipSchedPer(Conta)

                Dim DhIni As DateTime = .DataHoraIni

                If .PerNDias > 0 Then

                    'Soma N dias apos o ultimo CIP
                    Dim DhUltCip As Date
                    Dim RetUc As Boolean = BuscaUltimoCip(.RotaId, .DataHoraIni, DhUltCip)
                    If RetUc = True Then
                        'Caso tenha ocorrido um algum CIP desta RotaId apos a data de inicio, a proxima é DataHora + NDias
                        DhIni = DateAdd(DateInterval.Day, .PerNDias, DhUltCip)
                    End If

                Else

                    'Busca o próximo dia do mes ou semana cadastrado
                    Dim DhPer As Date
                    Dim RetPer As Boolean = BuscaPerMesSem(.PerId, DhPer)
                    If RetPer = True Then
                        DhIni = DhPer
                    End If

                End If

                Dim MyDataHora As Date = New Date(DhIni.Year, DhIni.Month, DhIni.Day, .DataHoraIni.Hour, .DataHoraIni.Minute, .DataHoraIni.Second)

                Dim FlagAtrasado As Integer = 0
                If MyDataHora <= Now Then FlagAtrasado = 1

                dtDados.Rows.Add(1, .PerId, .RotaId, .Grupo, .Subgrupo, MyDataHora, .Tipo, FlagAtrasado)

            End With
        Next

    End Sub

    Function BuscaUltimoCip(ByVal RotaId As Integer, ByVal DataHoraIni As Date, ByRef outDhUltCip As Date) As Boolean

        'Busca ultimo CIP desta RotaId apos a data inicial
        Dim taCipHist As New Geral.dsxCipValidTableAdapters.taxCipHist
        Dim dtCipHist As New Geral.dsxCipValid.CipHistDataTable
        taCipHist.FillRotaIdDataHoraIni(dtCipHist, RotaId, DataHoraIni)

        If dtCipHist.Rows.Count <= 0 Then Return False

        outDhUltCip = dtCipHist(dtCipHist.Rows.Count - 1).DataHoraIni
        Return True

    End Function

    Function BuscaPerMesSem(ByVal PerId As Integer, ByRef outDhPer As Date) As Boolean

        Dim MyData As Date = Now
        Dim DhMes As Date = Date.MaxValue
        Dim DhSem As Date = Date.MaxValue

        'Busca dias do mes configurados
        Dim taCipSchedPerMes As New Geral.dsxCipValidTableAdapters.taxCipSchedPerMes
        Dim dtCipSchedPerMes As New Geral.dsxCipValid.CipSchedPerMesDataTable
        taCipSchedPerMes.FillPerId(dtCipSchedPerMes, PerId)

        MyData = Now
        For Conta As Integer = 1 To 31

            Dim MyRows() As Geral.dsxCipValid.CipSchedPerMesRow = dtCipSchedPerMes.Select("DiaDoMes = " & MyData.Day)

            If MyRows.Length > 0 Then
                'Achei o primeiro dia do mes cadastrado procurando a partir do dia atual
                DhMes = MyData
                Exit For
            End If

            MyData = MyData.AddDays(1)

        Next


        'Busca dias da semana configurados
        Dim taCipSchedPerSem As New Geral.dsxCipValidTableAdapters.taxCipSchedPerSem
        Dim dtCipSchedPerSem As New Geral.dsxCipValid.CipSchedPerSemDataTable
        taCipSchedPerSem.FillPerId(dtCipSchedPerSem, PerId)

        MyData = Now
        For Conta As Integer = 1 To 7

            Dim MyRows() As Geral.dsxCipValid.CipSchedPerSemRow = dtCipSchedPerSem.Select("DiaDaSemana = " & MyData.DayOfWeek + 1)

            If MyRows.Length > 0 Then
                'Achei o primeiro dia da semana cadastrado procurando a partir do dia atual
                DhSem = MyData
                Exit For
            End If

            MyData = MyData.AddDays(1)

        Next

        If DhMes = Date.MaxValue And DhSem = Date.MaxValue Then Return False

        'Verifica se a data do mes é anterior a da semana
        If DhMes < DhSem Then
            outDhPer = DhMes
            Return True
        End If

        outDhPer = DhSem
        Return True

    End Function

End Module
