Module basGeraRelat

    Dim dtRec As List(Of Geral.nsReceitas.Rec)

    Sub MontaPlanilhaRelat(MyPlan As OfficeOpenXml.ExcelWorksheet, DataIniRel As String, DataFimRel As String)

        'O Excel suporta no maximo 32000 linhas. Em
        '    DataIni = CDate(ConvDataOrclVb(DataIniRel))
        '
        '    DataIniOrcl = ConvDataVbOrcl(Format(DataIni, "dd/mm/yyyy hh:nn:ss"))

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        dtRec = (From It In DbRc.Rec Where It.Area = "Mistura" Order By It.RecNum).ToList

        'Atualiza planilha Rec0XX
        MontaPlanCabecalho(MyPlan, DataIniRel, DataFimRel)

        MontaDados(MyPlan, DataIniRel, DataFimRel)

    End Sub

    Function MontaPlanCabecalho(MyPlan As OfficeOpenXml.ExcelWorksheet, DataIniRel As String, DataFimRel As String) As Boolean

        Dim InDataIni As String = Util.UtConvDataYmd(DataIniRel)
        Dim InDataFim As String = Util.UtConvDataYmd(DataFimRel)

        Dim DataIni As String = "'" & Format(InDataIni, "dd/MM/yy")
        Dim HoraIni As String = "'" & Format(InDataIni, "HH:mm")

        Dim DataFim As String = "'" & Format(InDataFim, "dd/MM/yy")
        Dim HoraFim As String = "'" & Format(InDataFim, "HH:mm")

        'Dados do intervalo de relatório
        MyPlan.Cells("B3").Value = DataIni
        MyPlan.Cells("B4").Value = HoraIni
        MyPlan.Cells("B5").Value = DataFim
        MyPlan.Cells("B6").Value = HoraFim

        'Data da impressão
        Dim DataTxt As String = "'" & Format(Now, "dd/MM/yyyy")
        MyPlan.Cells("E5").Value = DataTxt

        'hora da impressão
        Dim HorasTxt As String = "'" & Format(Now, "HH:mm:ss")
        MyPlan.Cells("E6").Value = HorasTxt

        Return True

    End Function

    Function MontaDados(MyPlan As OfficeOpenXml.ExcelWorksheet, DataIniRel As String, DataFimRel As String) As Boolean

        Dim MatPrima As String = ""


        'Obtem intervalo da pesquisa
        Dim DbMi As New Geral.nsMistGrava.dcMistGrava
        Dim dtProdMistDos = (From It In DbMi.ProdMistDos Where It.DataHora >= DataIniRel And It.DataHora <= DataFimRel And
                             It.Area = "Acucar" Order By It.BatchId).ToList


        'Escreve dados no excel
        If dtProdMistDos.Count <= 0 Then Return False

        'Relatorio
        Dim ContaReg As Integer = 9

        For Each Rec In dtProdMistDos

            Dim DataHoraFinTransf As String = Util.UtConvDataYmd(Rec.DataHora)

            'Definicao do produto
            If Rec.MatPrima = 1 Then
                MatPrima = "Leite"
            ElseIf Rec.MatPrima = 2 Then
                MatPrima = "Soro"
            ElseIf Rec.MatPrima = 3 Then
                MatPrima = "Acucar"
            End If

            'BatchId
            MyPlan.Cells("A" & ContaReg).Value = Rec.BatchId

            'Data e Hora do Final da transferencia do Batch
            MyPlan.Cells("B" & ContaReg).Value = DataHoraFinTransf

            'Produto
            MyPlan.Cells("C" & ContaReg).Value = MatPrima

            'Temperatura
            MyPlan.Cells("D" & ContaReg).Value = Rec.Tempet

            'Destino
            MyPlan.Cells("E" & ContaReg).Value = "TQ" & Rec.Destino


            ContaReg = ContaReg + 1
            MatPrima = ""

        Next

        Return True

    End Function

End Module
