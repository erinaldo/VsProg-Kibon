Module basRelatProd

    Dim dtRec As List(Of Geral.nsReceitas.Rec)

    Function GeraRelatProd(HistId As Integer) As Boolean

        Dim myEpplus As OfficeOpenXml.ExcelPackage

        'Cria arquivo
        Dim HistIdTxt As String = Strings.Right("00000000" & HistId, 8)
        Dim PathnameMod As String = Util.UtAppPath & "\..\Bin\RelatModelos\KbPastProdRelat.xlsx"
        Dim PathnameRel As String = "C:\Tmp\PastProdRelat_" & HistIdTxt & ".xlsx"

        Dim RetCria As Boolean
        RetCria = Geral.CopiaArquivo(PathnameMod, PathnameRel)

        If RetCria <> True Then
            MsgBox("Falha na criacao do arquivo.")
            Return False
        End If


        Dim myFile As New System.IO.FileInfo(PathnameRel)
        myEpplus = New OfficeOpenXml.ExcelPackage(myFile)


        'Monta planilhas inividuais de tanques
        Dim MyPlan As OfficeOpenXml.ExcelWorksheet = myEpplus.Workbook.Worksheets("Dados")
        Dim MyGraf As OfficeOpenXml.ExcelWorksheet = myEpplus.Workbook.Worksheets("Graf")
        MontaPlanilhaProdRelat(MyPlan, MyGraf, HistId)

        MyPlan.Protection.SetPassword(Geral.SENHA_PROTEGE_PLAN)

        myEpplus.Save()
        myEpplus = Nothing

        Geral.AbreXlsx(PathnameRel)

        Return True

    End Function

    Private Sub MontaPlanilhaProdRelat(MyPlan As OfficeOpenXml.ExcelWorksheet, MyGraf As OfficeOpenXml.ExcelWorksheet, HistId As Integer)

        'O Excel suporta no maximo 32000 linhas. Em
        '    DataIni = CDate(ConvDataOrclVb(DataIniRel))
        '
        '    DataIniOrcl = ConvDataVbOrcl(Format(DataIni, "dd/mm/yyyy hh:nn:ss"))

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Where It.Area = "Mistura" Order By It.RecNum).ToList

        'Atualiza planilha Rec0XX
        MontaPlanCabecalho(MyPlan, HistId)

        Dim NRows As Integer = MontaDados(MyPlan, HistId)
        AtualizaGrafico(MyGraf, NRows)

    End Sub

    Private Function MontaPlanCabecalho(MyPlan As OfficeOpenXml.ExcelWorksheet, HistId As Integer) As Boolean

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim dtPastGravaHist = (From It In DbPg.PastGravaHist Where It.HistId = HistId).ToList
        If dtPastGravaHist.Count <= 0 Then Return False

        MyPlan.Cells("C4").Value = dtPastGravaHist.First.HistId
        MyPlan.Cells("C5").Value = dtPastGravaHist.First.PastId

        Return True

    End Function

    Private Function MontaDados(MyPlan As OfficeOpenXml.ExcelWorksheet, HistId As Integer) As Integer

        Dim RowOffset As Integer = 9
        Dim ColOffset As Integer = 1

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim dtPastGravaHistDados = (From It In DbPg.PastGravaHistDados Where It.HistId = HistId
                                    Order By It.DataHora).ToList

        Dim Conta As Integer = 1
        For Each Rec In dtPastGravaHistDados

            MyPlan.Cells(Conta + RowOffset, ColOffset + 1).Value = "'" & Util.UtConvDataYmd(Rec.DataHora)
            MyPlan.Cells(Conta + RowOffset, ColOffset + 2).Value = ""
            MyPlan.Cells(Conta + RowOffset, ColOffset + 3).Value = BuscaRecCod(Rec.RecNum)
            MyPlan.Cells(Conta + RowOffset, ColOffset + 4).Value = Rec.TqOrig
            MyPlan.Cells(Conta + RowOffset, ColOffset + 5).Value = Rec.TqDest
            MyPlan.Cells(Conta + RowOffset, ColOffset + 6).Value = Rec.PressaoEst1
            MyPlan.Cells(Conta + RowOffset, ColOffset + 7).Value = Rec.PressaoEst2
            MyPlan.Cells(Conta + RowOffset, ColOffset + 8).Value = Rec.TempFdvPv
            MyPlan.Cells(Conta + RowOffset, ColOffset + 9).Value = Rec.TempFdvSp
            MyPlan.Cells(Conta + RowOffset, ColOffset + 10).Value = Rec.TempFinalPast
            MyPlan.Cells(Conta + RowOffset, ColOffset + 11).Value = Rec.PresFinalPast

            If Rec.ValvFdvA = 1 Then
                MyPlan.Cells(Conta + RowOffset, ColOffset + 12).Value = "0 - Circ"
            Else
                MyPlan.Cells(Conta + RowOffset, ColOffset + 12).Value = "1 - Prod"
            End If

            If Rec.ValvFdvB = 1 Then
                MyPlan.Cells(Conta + RowOffset, ColOffset + 13).Value = "0 - Circ"
            Else
                MyPlan.Cells(Conta + RowOffset, ColOffset + 13).Value = "1 - Prod"
            End If

            MyPlan.Cells(Conta + RowOffset, ColOffset + 14).Value = Rec.PresHomoEntr
            MyPlan.Cells(Conta + RowOffset, ColOffset + 15).Value = Rec.PresHomoSaida
            MyPlan.Cells(Conta + RowOffset, ColOffset + 16).Value = Rec.TempAguaAlcool

            Conta = Conta + 1

        Next

        'Escreve no excel
        'Dim PosIni As String = "B" & 9
        'Dim PosFim As String = "Q" & 9 + Conta
        'Dim MyRange As String = PosIni & ":" & PosFim

        'MyPlan.Cells(MyRange).Value = MyPlan.Cells

        Return dtPastGravaHistDados.Count

    End Function

    Private Function BuscaRecCod(RecNum As Integer) As String

        Static RecNumAnt As Integer
        Static CodigoAnt As String

        'Acelerador de busca
        If RecNumAnt = RecNum Then Return CodigoAnt


        'Busca
        Dim MyRec = (From It In dtRec Where It.RecNum = RecNum).ToList
        If MyRec.Count > 0 Then

            'Encontrado
            RecNumAnt = RecNum
            CodigoAnt = MyRec.First.Codigo

            BuscaRecCod = MyRec.First.Codigo
            Exit Function

        End If

        'Nao encontrado
        RecNumAnt = RecNum
        CodigoAnt = ""

        Return ""

    End Function

    Private Function AtualizaGrafico(MyGraf As OfficeOpenXml.ExcelWorksheet, NDados As Integer) As Boolean

        Dim NRows As Integer = NDados + 9

        Dim MyRange As String = ""
        Dim Cht As OfficeOpenXml.Drawing.Chart.ExcelChart = MyGraf.Drawings("Chart 3")

        'Atualizar grafico
        Cht.Series(1).XSeries = "=Dados!R9C2:R" & NRows & "C2"

        'Pena 1
        MyRange = "=Dados!R9C7:R" & NRows & "C7"
        Cht.Series(0).Series = MyRange

        'Pena 2
        MyRange = "=Dados!R9C8:R" & NRows & "C8"
        Cht.Series(1).Series = MyRange

        'Pena 3
        MyRange = "=Dados!R9C9:R" & NRows & "C9"
        Cht.Series(2).Series = MyRange

        'Pena 4
        MyRange = "=Dados!R9C10:R" & NRows & "C10"
        Cht.Series(3).Series = MyRange

        Return True

    End Function
End Module