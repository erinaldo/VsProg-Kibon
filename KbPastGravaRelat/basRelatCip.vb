Module basRelatCip

    Function GeraRelatCip(CipId As Integer) As Boolean

        Dim myEpplus As OfficeOpenXml.ExcelPackage

        'Cria arquivo
        Dim HistIdTxt As String = Strings.Right("00000000" & CipId, 8)
        Dim PathnameMod As String = Util.UtAppPath & "\..\Bin\RelatModelos\KbPastCipRelat.xlsx"
        Dim PathnameRel As String = "C:\Tmp\PastCipRelat_" & HistIdTxt & ".xlsx"

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
        MontaPlanilhaCipRelat(MyPlan, MyGraf, CipId)

        MyPlan.Protection.SetPassword(Geral.SENHA_PROTEGE_PLAN)

        myEpplus.Save()
        myEpplus = Nothing

        Geral.AbreXlsx(PathnameRel)

        Return True

    End Function

    Private Sub MontaPlanilhaCipRelat(MyPlan As OfficeOpenXml.ExcelWorksheet, MyGraf As OfficeOpenXml.ExcelWorksheet, CipId As Integer)

        'Atualiza planilha Rec0XX
        MontaPlanCabecalho(MyPlan, CipId)

        Dim NRows As Integer = MontaPlan(MyPlan, CipId)
        AtualizaGrafico(MyGraf, NRows)

    End Sub

    Private Function MontaPlanCabecalho(MyPlan As OfficeOpenXml.ExcelWorksheet, CipId As Integer) As Boolean

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim dtCipGravaHist = (From It In DbPg.CipGravaHist Where It.CipId = CipId).ToList
        If dtCipGravaHist.Count <= 0 Then Return False

        MyPlan.Cells("G2").Value = Util.UtConvYmdData(dtCipGravaHist.First.DataHora).Substring(0, 10)

        MyPlan.Cells("C3").Value = dtCipGravaHist.First.CipId
        MyPlan.Cells("C4").Value = dtCipGravaHist.First.Circ
        MyPlan.Cells("C5").Value = dtCipGravaHist.First.RotaId
        MyPlan.Cells("D5").Value = dtCipGravaHist.First.RotaDescr
        MyPlan.Cells("C6").Value = dtCipGravaHist.First.RecId
        MyPlan.Cells("D6").Value = dtCipGravaHist.First.RecDescr
        MyPlan.Cells("C7").Value = dtCipGravaHist.First.Analise

        Return True

    End Function

    Private Function MontaPlan(MyPlan As OfficeOpenXml.ExcelWorksheet, CipId As Integer) As Integer

        Dim RowOffset As Integer = 9
        Dim ColOffset As Integer = 1

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava
        Dim dtCipGravaHistDados = (From It In DbPg.CipGravaHistDados Where It.CipId = CipId
                                   Order By It.DataHora).ToList

        Dim Conta As Integer = 0
        For Each Rec In dtCipGravaHistDados

            MyPlan.Cells(Conta + RowOffset, ColOffset + 1).Value = Util.UtConvYmdData(Rec.DataHora)
            MyPlan.Cells(Conta + RowOffset, ColOffset + 2).Value = Rec.Cond
            MyPlan.Cells(Conta + RowOffset, ColOffset + 3).Value = Rec.Temp
            MyPlan.Cells(Conta + RowOffset, ColOffset + 4).Value = Rec.Vazao
            MyPlan.Cells(Conta + RowOffset, ColOffset + 5).Value = Rec.Blk
            MyPlan.Cells(Conta + RowOffset, ColOffset + 6).Value = BlkDescr(Rec.Blk)

            Conta = Conta + 1

        Next

        Return dtCipGravaHistDados.Count

    End Function

    Private Function BlkDescr(Blk As Integer) As String

        Dim Resp As String = ""

        Select Case Blk
            Case 1
                Resp = "TPCOLD"
            Case 2
                Resp = "ÁCIDO"

                'Case 1
                '    Resp = "Início"
                'Case 2
                '    Resp = "Drena BTD Ate Nivel Baixo"
                'Case 3
                '    Resp = "Recirculação Inicial"
                'Case 4
                '    Resp = "Drena BTD Ate Nivel Baixo"
                'Case 5
                '    Resp = "Recirculação Prod."
                'Case 6
                '    Resp = "Drena BTD Ate Nivel Baixo"
                'Case 7
                '    Resp = "Drena Sist. ate < 0.5ms + Flip"
                'Case 8
                '    Resp = "Drena Sist. ate < 0.5ms - Flip"
                'Case 9
                '    Resp = "Drena BTD Ate Nivel Baixo"
                'Case 10
                '    Resp = "Drena Sist. ate < 1.0ms - Flip"
                'Case 11
                '    Resp = "Finalizando Sistema"
        End Select

        Return Resp

    End Function

    Private Function AtualizaGrafico(MyGraf As OfficeOpenXml.ExcelWorksheet, NDados As Integer) As Boolean

        Dim NRows As Integer = NDados + 8

        Dim MyRange As String = ""
        Dim Cht As OfficeOpenXml.Drawing.Chart.ExcelChart = MyGraf.Drawings("Chart 3")

        'Atualizar grafico
        Cht.Series(0).XSeries = "=Dados!R9C2:R" & NRows & "C2"
        'Cht.Series(1).XSeries = "=Dados!$B$9:$B$" & NRows

        'Pena 1
        MyRange = "=Dados!R9C3:R" & NRows & "C3"
        Cht.Series(0).Series = MyRange

        'Pena 2
        MyRange = "=Dados!R9C4:R" & NRows & "C4"
        Cht.Series(1).Series = MyRange

        'Pena 3
        MyRange = "=Dados!R9C5:R" & NRows & "C5"
        Cht.Series(2).Series = MyRange

        Return True

    End Function
End Module
