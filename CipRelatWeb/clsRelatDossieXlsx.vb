Public Class clsRelatDossieXlsx

    Public CipId As Integer = 0
    Public RecNum As Integer = 0
    Public DataHoraIni As New Date(2000, 1, 1)
    Public DataHoraFim As New Date(2000, 1, 1)

    Public ArqDest As String


    Sub New(ByVal CipId As Integer)
        Me.CipId = CipId
        Me.ArqDest = "\Xls\RelatDossie_" & CipId & ".xlsx"
    End Sub

    Function GeraRelat() As Boolean

        'Cria o arquivo destino
        Dim RetCria As Boolean = CriaArqDest()
        If RetCria = False Then Return False

        'Abre o arquivo Excel destino
        Dim Fi As New FileInfo(My.Request.MapPath("") & ArqDest)
        Dim Ep As New OfficeOpenXml.ExcelPackage(Fi)

        Dim WsC As OfficeOpenXml.ExcelWorksheet = Ep.Workbook.Worksheets("Cip")
        PlanCipMonta(WsC, CipId)

        Dim WsH As OfficeOpenXml.ExcelWorksheet = Ep.Workbook.Worksheets("Hist")
        Dim HistRwMax As Integer = PlanHistMonta(WsH, CipId)

        'Executa macros para modificar os graficos
        Dim WsG As OfficeOpenXml.ExcelWorksheet = Ep.Workbook.Worksheets("Graf")
        PlanGrafMonta(WsG, CipId, HistRwMax)

        'Remove a planilha modelo e salva o arquivo
        'Ep.Workbook.Worksheets.Delete(1)
        Ep.Save()

        Return True

    End Function

    Function CriaArqDest() As Boolean

        Try
            'Deleta os arquivos
            Dim MyPath As String = My.Request.MapPath("") & "\Xls\RelatDossie*.xlsx"
            Dim MyName As String = Dir(MyPath)
            Do While MyName <> ""

                Dim MyFile As String = My.Request.MapPath("") & "\Xls\" & MyName

                Try
                    Kill(MyFile)
                Catch : End Try

                MyName = Dir()

            Loop

        Catch : End Try


        'Copia o arquivo modelo
        Dim ArqOrig As String = My.Request.MapPath("") & "\XlsMod\RelatDossieMod.xlsx"
        Try
            FileCopy(ArqOrig, My.Request.MapPath("") & ArqDest)
        Catch ex As Exception
            'MsgBox("Erro: não foi possível copiaro o arquivo modelo." & ControlChars.CrLf &
            '       "de   [" & ArqOrig & "]" & ControlChars.CrLf &
            '       "para [" & ArqDest & "]")
            Return False
        End Try


        Return True

    End Function

    Sub PlanCipMonta(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer)

        'Monta planilhas
        PlanCipMontaCabecalho(Ws, CipId)

        Dim Linha As Integer = 14
        PlanCipMontaTempos(Ws, CipId, Linha)
        PlanCipMontaAnormalidades(Ws, CipId, Linha)
        PlanCipMontaPtoCr(Ws, CipId, Linha)

    End Sub

    Function PlanCipMontaCabecalho(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer) As Boolean

        'Inclui dados de cabecalho na plnilha Rec0XX
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.CipId = CipId).ToList
        If dtCipHist.Count <= 0 Then Return False

        RecNum = dtCipHist(0).RecNum
        DataHoraIni = dtCipHist(0).DataHoraIni
        DataHoraFim = dtCipHist(0).DataHoraFim

        Ws.Cells("H4").Value = Format(Now, "dd/MM/yyyy")
        Ws.Cells("H4").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

        Ws.Cells("C5").Value = CipId
        Ws.Cells("C5").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

        Ws.Cells("C6").Value = dtCipHist(0).RotaId
        Ws.Cells("C6").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

        Ws.Cells("H6").Value = dtCipHist(0).Circ
        Ws.Cells("H6").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

        Ws.Cells("C7").Value = dtCipHist(0).RecNum
        Ws.Cells("C7").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

        Ws.Cells("C8").Value = Format(dtCipHist(0).DataHoraIni, "dd/MM/yyyy HH:mm:ss")
        Ws.Cells("F8").Value = Format(dtCipHist(0).DataHoraFim, "dd/MM/yyyy HH:mm:ss")

        If dtCipHist(0).FlagCancelado = 0 Then
            Ws.Cells("C11").Value = "Não"
        Else
            Ws.Cells("C11").Value = "Sim"
        End If
        Ws.Cells("C11").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

        If dtCipHist(0).FlagAtrasado = 0 Then
            Ws.Cells("C12").Value = "Não"
        Else
            Ws.Cells("C12").Value = "Sim"
        End If
        Ws.Cells("C12").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


        'Dados do cadastro de rotas
        Dim DbCr As New nsCipRotas.dcCipRotas
        Dim RotaId As Integer = dtCipHist(0).RotaId
        Dim dtRotaCad = (From It In DbCr.RotaCad Where It.RotaId = RotaId).ToList
        If dtRotaCad.Count <= 0 Then Return False
        Ws.Cells("D6").Value = dtRotaCad(0).Descr


        'Dados da receita
        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP" And It.RecNum = RecNum).ToList

        If dtRec.Count <= 0 Then Return False
        Ws.Cells("D7").Value = dtRec(0).RecNome & " - " & dtRec(0).RecDescr
        Ws.Cells("D7").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left

        Ws.Cells("H7").Value = dtRec(0).Codigo
        Ws.Cells("H7").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center


        'Dados do cadastro do usuário
        Dim UserId As Integer = dtCipHist(0).UserId
        Dim dtCadUser = (From It In DbCv.CadUser Where It.UserId = UserId).tolist
        If dtCadUser.Count > 0 Then
            Ws.Cells("C9").Value = dtCadUser(0).Nome
            Ws.Cells("C9").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        End If

        'Usuario que validou o CIP
        Dim UserIdValid As Integer = dtCipHist(0).UserIdValid
        Dim dtCadUserValid = (From It In DbCv.CadUser Where It.UserId = UserIdValid).ToList
        If dtCadUser.Count > 0 Then
            Ws.Cells("C10").Value = dtCadUser(0).Nome
            Ws.Cells("C10").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        End If

        Return True

    End Function

    Sub PlanCipMontaTempos(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer, ByRef Linha As Integer)

        'Dados do grid
        Dim MyDados As New Data.DataTable("Dados")
        MyDados.Columns.Add("BlkNum")
        MyDados.Columns.Add("BlkDescr")
        MyDados.Columns.Add("DataHoraIni")
        MyDados.Columns.Add("Duracao")
        MyDados.Columns.Add("Prog")


        'Busca os tempos programados para este CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHistDados = (From It In DbCv.CipHistDados Where It.CipId = CipId Order By It.DataHora).ToList

        If dtCipHistDados.Count <= 0 Then Return
        Dim BlkDataIni As Date = dtCipHistDados(0).DataHora

        Dim BlkNumAnt As Integer = -1
        For Conta As Integer = 0 To dtCipHistDados.Count - 1
            With dtCipHistDados(Conta)

                If .BlkNum <> BlkNumAnt Then

                    'Termino de um bloco de CIP
                    If BlkNumAnt <> -1 Then

                        Dim Duracao As Integer = DateDiff(DateInterval.Second, BlkDataIni, .DataHora)
                        MyDados.Rows.Add(BlkNumAnt, BuscaBlkDescr(BlkNumAnt), Format(BlkDataIni, "dd/MM/yyyy HH:mm:ss"),
                                         UtConvDhms(Duracao), BuscaBlkDuracao(BlkNumAnt))
                    End If

                    'Memoriza dados do bloco atual
                    BlkNumAnt = .BlkNum
                    BlkDataIni = .DataHora

                End If

            End With
        Next

        'Calcula duracao do ultimo passo do loop
        Dim DuracaoFim As Integer = DateDiff(DateInterval.Second, BlkDataIni, DataHoraFim)
        MyDados.Rows.Add(BlkNumAnt, BuscaBlkDescr(BlkNumAnt), Format(BlkDataIni, "dd/MM/yyyy HH:mm:ss"),
                         UtConvDhms(DuracaoFim), BuscaBlkDuracao(BlkNumAnt))

        'Cabecalho desta parte
        Ws.Cells("A" & Linha & ":I" & Linha).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium
        Linha = Linha + 1

        Ws.Cells("B" & Linha).Value = "Fases"
        Ws.Cells("B" & Linha).Style.Font.Bold = True
        Ws.Cells("B" & Linha).Style.Font.Color.SetColor(Drawing.Color.Red)
        Linha = Linha + 1

        Ws.Cells("B" & Linha).Value = "BlkNum"
        Ws.Cells("B" & Linha).Style.Font.Bold = True
        Ws.Cells(Linha, 3, Linha, 4).Merge = True

        Ws.Cells("C" & Linha).Value = "Início"
        Ws.Cells("C" & Linha).Style.Font.Bold = True
        Ws.Cells("C" & Linha).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

        Ws.Cells("E" & Linha).Value = "Duração"
        Ws.Cells("E" & Linha).Style.Font.Bold = True
        Ws.Cells("F" & Linha).Value = "Prog"
        Ws.Cells("F" & Linha).Style.Font.Bold = True
        Linha = Linha + 1


        For Conta As Integer = 0 To MyDados.Rows.Count - 1

            Ws.Cells("B" & Linha).Value = MyDados.Rows(Conta).Item("BlkNum")

            Ws.Cells("C" & Linha).Value = MyDados.Rows(Conta).Item("DataHoraIni")
            Ws.Cells("C" & Linha & ":D" & Linha).Merge = True
            Ws.Cells("C" & Linha).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center

            Ws.Cells("E" & Linha).Value = MyDados.Rows(Conta).Item("Duracao")
            Ws.Cells("F" & Linha).Value = MyDados.Rows(Conta).Item("Prog")
            Linha = Linha + 1

        Next

        'Fecha esta parte
        Linha = Linha + 1
        Ws.Cells("A" & Linha & ":I" & Linha).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium
        Linha = Linha + 1

    End Sub

    Function BuscaBlkDescr(ByVal BlkNum As Integer) As String

        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtBlocos = (From It In DbRc.Blocos Where It.Area = "CIP" And It.BlkNum = BlkNum).ToList

        If dtBlocos.Count <= 0 Then Return ""

        Return dtBlocos(0).BlkDescr

    End Function

    Function BuscaBlkDuracao(ByVal BlkNum As Integer) As Integer

        Dim DbRc As New nsReceitas.dcReceitas
        Dim dtRecBlocos = (From It In DbRc.RecBlocos Where It.Area = "CIP" And It.RecNum = RecNum And
                           It.BlkNum = BlkNum Order By It.ItemSeq).ToList
        If dtRecBlocos.Count <= 0 Then Return 0


        Dim dtBlocosItens = (From It In DbRc.BlocosItens Where It.Area = "CIP" And It.BlkNum = BlkNum
                             Order By It.ItemSeq).ToList

        Dim Duracao As Integer = 0
        For Conta As Integer = 0 To dtBlocosItens.Count - 1
            With dtBlocosItens(Conta)

                If .UEng <> "seg" Then Continue For

                Dim NSeg As Integer = BuscaPrm(dtRecBlocos(0), .ItemSeq)
                Duracao = Duracao + NSeg

            End With
        Next

        Return Duracao

    End Function

    Function BuscaPrm(ByVal rwRecBlocos As nsReceitas.RecBlocos, ByVal ContaPrm As Integer) As Integer

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

    Sub PlanCipMontaAnormalidades(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer, ByRef Linha As Integer)

        'Busca os tempos programados para este CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHistAnorm As List(Of nsCipValid.CipHistAnorm) = Nothing
        Try
            dtCipHistAnorm = (From It In DbCv.CipHistAnorm Where It.CipId = CipId Order By It.DataHora).ToList
        Catch : End Try

        If dtCipHistAnorm.Count <= 0 Then Return


        'Cabecalho desta parte
        Linha = Linha + 1
        Ws.Cells("B" & Linha).Value = "Anormalidades"
        Ws.Cells("B" & Linha).Style.Font.Bold = True
        Ws.Cells("B" & Linha).Style.Font.Color.SetColor(Drawing.Color.Red)
        Linha = Linha + 1

        Ws.Cells("B" & Linha).Value = "Data e Hora"
        Ws.Cells("B" & Linha).Style.Font.Bold = True
        Ws.Cells("C" & Linha & ":D" & Linha).Merge = True
        Ws.Cells("C" & Linha).Value = "Mensagem"
        Ws.Cells("C" & Linha).Style.Font.Bold = True
        Ws.Cells("E" & Linha).Value = "Obs"
        Ws.Cells("E" & Linha).Style.Font.Bold = True
        Ws.Cells("H" & Linha).Value = "Passo"
        Ws.Cells("H" & Linha).Style.Font.Bold = True

        'Macete para ajustar a altura dos textos Obs
        'A função Autofit ajusta automaticamente a altura da linha de uma celula com quebra automática de texto
        'Só que isto não funciona com celulas mergeadas, portanto eu fiz uma tramóia.
        'Estiquei a coluna E com a largura des 3 colunas a serem mergeadas e depois
        '   ajustei a altura. Depois que o excel achou a altura do texto e ajustou a altura da linha e fiz o merge.
        'No final basta voltar a largura original da coluna E, pois a altura das linhas já está Ok
        Ws.Column(5).Width = 11 * 3
        Linha = Linha + 1


        For Conta As Integer = 0 To dtCipHistAnorm.Count - 1

            Ws.Cells("B" & Linha).Value = Format(dtCipHistAnorm(Conta).DataHora, "dd/MM/yyyy HH:mm:ss")
            Ws.Cells("B" & Linha).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top
            Ws.Cells("C" & Linha).Value = BuscaAnormEvento(dtCipHistAnorm(Conta).AnormEquip, dtCipHistAnorm(Conta).AnormEvnt)
            Ws.Cells("C" & Linha).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left
            Ws.Cells("C" & Linha).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top

            Ws.Cells(Linha, 5, Linha, 7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left
            Ws.Cells(Linha, 5, Linha, 7).Style.WrapText = True
            Ws.Cells("E" & Linha).Value = dtCipHistAnorm(Conta).Obs
            'Ws.Row(Linha, 5, Linha, 7).Rows.AutoFit()
            Ws.Cells(Linha, 5, Linha, 7).Merge = True

            Ws.Cells("H" & Linha).Value = dtCipHistAnorm(Conta).BlkNum
            Ws.Cells("H" & Linha).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top
            'Ws.Cells("H" & Linha).NumberFormat = "General"

            Linha = Linha + 1

        Next

        'Volta o tamanho original da coluna E
        Ws.Column(5).Width = 11

        'Fecha esta parte
        Linha = Linha + 1
        Ws.Cells("A" & Linha & ":I" & Linha).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium
        Linha = Linha + 1

    End Sub

    Sub PlanCipMontaPtoCr(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer, ByRef Linha As Integer)

        ''Busca os tempos programados para este CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHistPtoCr As List(Of nsCipValid.CipHistPtoCr) = Nothing
        Try
            dtCipHistPtoCr = (From It In DbCv.CipHistPtoCr Where It.CipId = CipId Order By It.PtoCrId).ToList
        Catch : End Try

        If dtCipHistPtoCr.Count <= 0 Then Return

        Dim dtCadPtoCr = (From It In DbCv.CadPtoCr).ToList

        'Cabecalho desta parte
        Linha = Linha + 1
        Ws.Cells("B" & Linha).Value = "Pontos críticos"
        Ws.Cells("B" & Linha).Style.Font.Bold = True
        Ws.Cells("B" & Linha).Style.Font.Color.SetColor(Drawing.Color.Red)
        Linha = Linha + 1

        Ws.Cells("B" & Linha & ":G" & Linha).Merge = True
        Ws.Cells("B" & Linha).Value = "Pergunta"
        Ws.Cells("B" & Linha).Style.Font.Bold = True
        Ws.Cells("H" & Linha).Value = "Resposta"
        Ws.Cells("H" & Linha).Style.Font.Bold = True
        Linha = Linha + 1

        For Conta As Integer = 0 To dtCipHistPtoCr.Count - 1

            Dim PtoCrId As Integer = dtCipHistPtoCr(Conta).PtoCrId
            Dim MyRow = (From It In dtCadPtoCr Where It.PtoCrId = PtoCrId).ToList

            If MyRow.Count > 0 Then
                Ws.Cells("B" & Linha).Value = MyRow(0).Pergunta
                Ws.Cells("B" & Linha).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left
            End If

            Ws.Cells("H" & Linha).Value = BuscaPtoCriticoResp(dtCipHistPtoCr(Conta).Resp)
            Linha = Linha + 1

        Next

        'Fecha esta parte
        Linha = Linha + 1
        Ws.Cells("A" & Linha & ":I" & Linha).Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium
        Linha = Linha + 1

    End Sub

    Function PlanHistMonta(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer) As Integer

        Ws.Cells("O3").Value = Format(Now, "dd/MM/yyyy")
        Ws.Cells("O3").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right

        'Monta planilhas
        Dim dtHistDados As New List(Of nsCipValid.CipHistDados)
        Dim dtCadRotasLim As New List(Of nsCipValid.CadRotasLim)

        PlanHistMontaBuscaDados(CipId, dtHistDados, dtCadRotasLim)
        Dim HistRwMax As Integer = PlanHistMontaDados(Ws, CipId, dtHistDados, dtCadRotasLim)

        Return HistRwMax

    End Function

    Sub PlanHistMontaBuscaDados(ByVal CipId As Integer, ByRef dtHistDados As List(Of nsCipValid.CipHistDados), _
                                ByRef dtCadRotasLim As List(Of nsCipValid.CadRotasLim))

        'Registro deste CIP
        Dim DbCv As New nsCipValid.dcCipValid
        Dim dtCipHist As List(Of nsCipValid.CipHist) = Nothing
        Try
            dtCipHist = (From It In DbCv.CipHist Where It.CipId = CipId).ToList
        Catch : End Try

        If dtCipHist.Count <= 0 Then Return
        Dim RotaId As Integer = dtCipHist(0).RotaId


        'Dados deste CIP
        dtHistDados = (From It In DbCv.CipHistDados Where It.CipId = CipId Order By It.DataHora).ToList


        'Dados do cadastro de rotas
        Dim dtCadRotasVl = (From It In DbCv.CadRotasVl Where It.RotaId = RotaId).ToList

        If dtCadRotasVl.Count <= 0 Then Return
        Dim LimRevAtual As Integer = dtCadRotasVl(0).LimRevAtual


        'Limites das variáveis por passo do CIP
        Try
            dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = RotaId And It.LimRev = LimRevAtual
                             Order By It.BlkNum).ToList
        Catch : End Try

    End Sub

    Function PlanHistMontaDados(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer, _
                    ByRef dtHistDados As List(Of nsCipValid.CipHistDados), _
                    ByRef dtCadRotasLim As List(Of nsCipValid.CadRotasLim)) As Integer

        Dim Linha As Integer = 6
        Dim MyRow As List(Of nsCipValid.CadRotasLim) = Nothing
        Dim CipPassoMaxAnt As Integer = -1
        For Conta As Integer = 0 To dtHistDados.Count - 1

            'Busca os máximos e mínimos

            'Otimiza as chamadas de Select
            Dim CipPassoMax As Integer = dtHistDados(Conta).BlkNum
            If CipPassoMax <> CipPassoMaxAnt Then
                MyRow = (From It In dtCadRotasLim Where It.BlkNum = CipPassoMax).ToList
            End If
            CipPassoMaxAnt = CipPassoMax


            Ws.Cells(Linha, 2).Value = Format(dtHistDados(Conta).DataHora, "dd/MM/yyyy HH:mm:ss")

            Ws.Cells(Linha, 3).Value = dtHistDados(Conta).Temp
            If MyRow.Count > 0 Then
                Ws.Cells(Linha, 4).Value = MyRow(0).TempMax
                Ws.Cells(Linha, 5).Value = MyRow(0).TempMin
            End If

            Ws.Cells(Linha, 6).Value = dtHistDados(Conta).Cond
            If MyRow.Count > 0 Then
                Ws.Cells(Linha, 7).Value = MyRow(0).CondMax
                Ws.Cells(Linha, 8).Value = MyRow(0).CondMin
            End If

            Ws.Cells(Linha, 9).Value = dtHistDados(Conta).Vazao
            If MyRow.Count > 0 Then
                Ws.Cells(Linha, 10).Value = MyRow(0).VazaoMax
                Ws.Cells(Linha, 11).Value = MyRow(0).VazaoMin
            End If

            Ws.Cells(Linha, 12).Value = dtHistDados(Conta).BlkNum
            Linha = Linha + 1

        Next

        Ws.Cells("F3").Value = CipId

        Return Linha - 1

    End Function

    Sub PlanGrafMonta(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal CipId As Integer, ByVal HistRwMax As Integer)

        'Cabecalho
        Ws.Cells("J4").Value = CipId
        Ws.Cells("J39").Value = CipId
        Ws.Cells("J76").Value = CipId
        Ws.Cells("J113").Value = CipId

        'Atualizar graficos
        PlanGrafMontaTemp(Ws, HistRwMax)
        PlanGrafMontaCond(Ws, HistRwMax)
        PlanGrafMontaVazao(Ws, HistRwMax)
        PlanGrafMontaBlkNum(Ws, HistRwMax)

    End Sub

    Private Sub PlanGrafMontaTemp(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal NRows As Integer)

        'Temperatura
        Dim Ch As OfficeOpenXml.Drawing.Chart.ExcelChart = Ws.Drawings("GrafTemp")
        Ch.Series(0).Series = "Hist!C6:C" & NRows
        Ch.Series(0).XSeries = "Hist!B6:B" & NRows

        Ch.Series(1).Series = "Hist!D6:D" & NRows
        Ch.Series(1).XSeries = "Hist!B6:B" & NRows

        Ch.Series(2).Series = "Hist!E6:E" & NRows
        Ch.Series(2).XSeries = "Hist!B6:B" & NRows

        Ch.Series(0).Header = "Temperatura"
        Ch.Series(1).Header = "Máximo"
        Ch.Series(2).Header = "Mínimo"

    End Sub

    Private Sub PlanGrafMontaCond(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal NRows As Integer)

        'Condutividade
        Dim Ch As OfficeOpenXml.Drawing.Chart.ExcelChart = Ws.Drawings("GrafCond")
        Ch.Series(0).Series = "Hist!F6:F" & NRows
        Ch.Series(0).XSeries = "Hist!B6:B" & NRows

        Ch.Series(1).Series = "Hist!G6:G" & NRows
        Ch.Series(1).XSeries = "Hist!B6:B" & NRows

        Ch.Series(2).Series = "Hist!H6:H" & NRows
        Ch.Series(2).XSeries = "Hist!B6:B" & NRows

        Ch.Series(0).Header = "Condutividade"
        Ch.Series(1).Header = "Máximo"
        Ch.Series(2).Header = "Mínimo"

    End Sub

    Private Sub PlanGrafMontaVazao(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal NRows As Integer)

        'Vazao
        Dim Ch As OfficeOpenXml.Drawing.Chart.ExcelChart = Ws.Drawings("GrafVazao")
        Ch.Series(0).Series = "Hist!I6:I" & NRows
        Ch.Series(0).XSeries = "Hist!B6:B" & NRows

        Ch.Series(1).Series = "Hist!J6:J" & NRows
        Ch.Series(1).XSeries = "Hist!B6:B" & NRows

        Ch.Series(2).Series = "Hist!K6:K" & NRows
        Ch.Series(2).XSeries = "Hist!B6:B" & NRows

        Ch.Series(0).Header = "Vazão"
        Ch.Series(1).Header = "Máximo"
        Ch.Series(2).Header = "Mínimo"

    End Sub

    Private Sub PlanGrafMontaBlkNum(ByRef Ws As OfficeOpenXml.ExcelWorksheet, ByVal NRows As Integer)

        'BlkNum
        Dim Ch As OfficeOpenXml.Drawing.Chart.ExcelChart = Ws.Drawings("GrafBlkNum")
        Ch.Series(0).Series = "Hist!L6:L" & NRows
        Ch.Series(0).XSeries = "Hist!B6:B" & NRows

        Ch.Series(0).Header = ""

        Ch.Series.Delete(2)
        Ch.Series.Delete(1)

    End Sub

End Class
