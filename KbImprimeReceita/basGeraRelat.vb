Module basGeraRelat

    Dim ContaLinha As Integer = 0
    Dim ROW_HEIGHT As Integer = 18

    Sub MontaPlanilhaRelat(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String, RecNum As Integer, RecNome As String)

        '    Dim MyPlan As OfficeOpenXml.ExcelWorksheet
        Dim Blocos As New clsBlocos
        Dim ingReceita As New clsIngreds
        Dim ingReceitaMat As New clsIngredsMat


        Dim NumSeqMensal As Integer = 0

        'Le arquivo de receita na estrutura Blocos
        Dim RecCod As String = "", RecDescr As String = "", RecDens As Double
        RecAbre(Area, RecNum, Blocos, RecCod, RecDescr, RecDens)

        'Le arquivo de ingredientes na estrutura ingReceita
        IngAbre(Area, RecNum, ingReceita)
        IngAbreMat(Area, RecNum, ingReceitaMat)


        'Atualiza planilha Rec0XX
        Dim PlanNome As String = "Rec" & Format(RecNum, "000")

        'Cabecalho
        MontaPlanCabecalho(MyPlan, Area, RecNum, RecNome, RecCod, RecDescr, RecDens)

        'Monta blocos nas planilhas de receita
        MontaPlanBlocos(MyPlan, Area, Blocos, RecNum, RecNome)

        'Monta ingredientes de Receita na planilha
        MontaPlanIngRec(MyPlan, ingReceita, RecNum, RecNome)

        'Monta ingredientes de Maturador na planilha
        MontaPlanIngMat(MyPlan, ingReceitaMat, RecNum, RecNome)

        'Monta ranges
        Dim RecNomeArq As String = ""
        MontaRanges(MyPlan, Area, RecNum, RecNomeArq)

    End Sub

    Function IngAbre(Area As String, RecNum As Integer, ByRef ingReceita As clsIngreds) As Boolean

        'Abre o arquivo de receita
        Dim CodigoTxt As String
        Dim Nome As String
        Dim Peso As Double

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRecIngred = (From It In DbRc.RecIngred Where It.Area = Area And It.RecNum = RecNum Order By It.ItemSeq).ToList

        'For Each Rec In dtRecIngred

        '    Peso = Rec.Peso * (TamBatch / 100.0#)
        '    CodigoTxt = Rec.IngrCodigo
        '    Nome = BuscaIngrNome(Area, Rec.IngrCodigo)
        '    ingReceita.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso})

        'Next


        ' Query para pegar as misturas pre setadas para as receitas
        Dim ingrMisturaRecManual = (From rcb In DbRc.RecBlocos
                                    Join tpm In DbRc.tb_TPM_TipoMistura On tpm.TPM_ID Equals rcb.Param02
                                    Join mta In DbRc.tb_MTA_Mistura On mta.TPM_ID Equals tpm.TPM_ID
                                    Join ing In DbRc.Ingred On ing.IngrCodigo Equals mta.IngrCodigo
                                    Where rcb.BlkNum = 2017 And rcb.RecNum = RecNum
                                    Select ing.IngrNome, ing.IngrCodigo, mta.MTA_Peso).ToList

        ' Para cada ingrediente adiciona uma linha na planilha
        For Each Ing In ingrMisturaRecManual
            Peso = Ing.MTA_Peso * (TamBatch / 1000.0#)
            CodigoTxt = Ing.IngrCodigo
            Nome = Ing.IngrNome
            ingReceita.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso})
        Next

        ' Query para pegar os ingredientes pre setados para as receitas
        Dim pequenoIngrRecManual = (From rcb In DbRc.RecBlocos
                                    Join ing In DbRc.Ingred On ing.ID Equals rcb.Param01
                                    Where rcb.Param01 IsNot Nothing And rcb.BlkNum = 2017 And rcb.RecNum = RecNum
                                    Select ing.IngrNome, rcb.Param03, ing.IngrCodigo).ToList
        ' Para cada ingrediente adiciona uma linha na planilha
        For Each Ing In pequenoIngrRecManual
            Peso = Ing.Param03 * (TamBatch / 1000.0#)
            CodigoTxt = Ing.IngrCodigo
            Nome = Ing.IngrNome
            ingReceita.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso})
        Next


        Return True

    End Function

    Function IngAbreMat(Area As String, RecNum As Integer, ByRef ingReceitaMat As clsIngredsMat) As Boolean

        'Abre o arquivo de receita
        Dim CodigoTxt As String
        Dim Nome As String
        Dim Peso As Double


        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRecIngredMat = (From It In DbRc.RecIngredMat Where It.Area = Area And It.RecNum = RecNum Order By It.ItemSeq).ToList

        For Each Rec In dtRecIngredMat

            Peso = Rec.Peso * (TamBatch / 100.0#)
            CodigoTxt = Rec.IngrCodigo
            Nome = BuscaIngrNome(Area, Rec.IngrCodigo)
            ingReceitaMat.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso})

        Next

        Return True

    End Function

    Function MontaPlanCabecalho(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String,
            RecNum As Integer, RecNome As String, RecCod As String, RecDescr As String, RecDens As Double) As Boolean

        'Inclui dados de cabecalho na plnilha Rec0XX

        'Area
        If Area <> "CIP" Then
            MyPlan.Cells("E2").Value = NomeDaAreaAtual & " - " & NomeDoTqDestino
        Else
            MyPlan.Cells("E2").Value = "CIP"
        End If

        'Dados da receita
        MyPlan.Cells("E3").Value = Format(RecNum, "000")
        MyPlan.Cells("E4").Value = RecNome
        MyPlan.Cells("E5").Value = RecCod
        MyPlan.Cells("E6").Value = RecDescr
        MyPlan.Cells("E7").Value = Format(RecDens, "0.000")
        MyPlan.Cells("E8").Value = Format(PesoReferImpr, "0.000") & "  Kg"

        If Area <> "CIP" Then
            MyPlan.Cells("E9").Value = Format(CDbl(TamBatch), "0.000") & "  Kg"

            'Data da impressão
            Dim DataTxt As String = "'" & DataTurno()
            MyPlan.Cells("J8").Value = DataTxt

            'hora da impressão
            Dim HorasTxt As String = "'" & Format(Now, "HH:mm:ss")
            MyPlan.Cells("J9").Value = HorasTxt

        Else
            MyPlan.Cells("E9").Value = "CIP"
        End If

        'Codigo Juliano
        'MyPlan.Cells("J7") = CodJulianoCalc

        Return True

    End Function

    Function MontaPlanBlocos(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String,
            Blocos As clsBlocos, RecNum As Integer, RecNome As String) As Boolean

        Dim Blk As clsBloco
        Dim Par As clsParametro


        'Dimensiona matrix
        ContaLinha = 14
        Dim ContaBloco As Integer = 1


        'Loop para cada bloco da receita
        For Each Blk In Blocos.mCol

            MyPlan.Cells(ContaLinha, 2).Value = ContaBloco
            MyPlan.Cells(ContaLinha, 3).Value = Blk.NumeroDoBloco
            MyPlan.Cells(ContaLinha, 5).Value = Blk.Descricao
            MyPlan.Row(ContaLinha).Height = ROW_HEIGHT

            ContaLinha = ContaLinha + 1


            'Loop para cada parametro do bloco
            Dim ContaParam As Integer = 0
            For Each Par In Blk.MyParametros.mCol

                Dim UnidEng As String = ""
                If ContaParam < Blk.MyParametros.mCol.Count Then Left(Blk.MyParametros.mCol(ContaParam).UnidadeEngenharia, 2)

                If UCase(UnidEng) = "KG" Or
                   Blk.MyParametros.mCol(ContaParam).FlagPeso = True Or Area = "CIP" Then
                    MyPlan.Cells(ContaLinha, 4).Value = ContaParam
                    MyPlan.Cells(ContaLinha, 5).Value = Par.Descricao
                    MyPlan.Cells(ContaLinha, 6).Value = Format(Par.Valor, "0.000")
                    MyPlan.Cells(ContaLinha, 7).Value = Par.UnidadeEngenharia
                    MyPlan.Row(ContaLinha).Height = ROW_HEIGHT

                    ContaLinha = ContaLinha + 1
                End If

                ContaParam = ContaParam + 1

            Next

            ContaBloco = ContaBloco + 1
            'ContaLinha = ContaLinha + 1

        Next


        Return True

    End Function

    Function MontaPlanIngRec(MyPlan As OfficeOpenXml.ExcelWorksheet,
            ingReceita As clsIngreds, RecNum As String, RecNome As String) As Boolean

        Dim Ing As clsIngred


        If ingReceita.mCol.Count <= 0 Then Return False

        Dim MyRange As String = ""

        ContaLinha = ContaLinha + 2

        MyRange = "C" & ContaLinha
        MyPlan.Cells(MyRange).Value = "ASSINAT."
        MyPlan.Cells(MyRange).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(MyRange).Style.Font.Bold = True

        MyRange = "E" & ContaLinha
        MyPlan.Cells(MyRange).Value = "Ingredientes manuais de Receita"
        MyPlan.Cells(MyRange).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(MyRange).Style.Font.Bold = True

        MyRange = "F" & ContaLinha
        MyPlan.Cells(MyRange).Value = "kg"
        MyPlan.Cells(MyRange).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(MyRange).Style.Font.Bold = True

        'Insere o cabecalho da parte de ingredientes
        MyRange = "G" & ContaLinha
        MyPlan.Cells(MyRange).Value = "Codigo"
        MyPlan.Cells(MyRange).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(MyRange).Style.Font.Bold = True

        ContaLinha = ContaLinha + 2

        'Loop para cada bloco da receita
        Dim Conta As Integer = 1
        For Each Ing In ingReceita.mCol

            MyPlan.Cells(ContaLinha, 3).Value = Conta
            'MyPlan.Cells(ContaLinha, 4).Value = Conta
            MyPlan.Cells(ContaLinha, 5).Value = Ing.Nome
            MyPlan.Cells(ContaLinha, 6).Value = Format(Ing.Peso, "0.000")
            MyPlan.Cells(ContaLinha, 7).Value = Ing.Codigo
            MyPlan.Row(ContaLinha).Height = ROW_HEIGHT

            ContaLinha = ContaLinha + 1
            Conta = Conta + 1

        Next


        Return True

    End Function

    Function MontaPlanIngMat(MyPlan As OfficeOpenXml.ExcelWorksheet,
            ingReceita As clsIngredsMat, RecNum As Integer, RecNome As String) As Boolean

        If ingReceita.mCol.Count <= 0 Then Return False

        Dim MyRange As String = ""
        ContaLinha = ContaLinha + 2

        MyPlan.Cells(ContaLinha, 3).Value = "ASSINAT."
        MyPlan.Cells(ContaLinha, 3).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(ContaLinha, 3).Style.Font.Bold = True

        MyPlan.Cells(ContaLinha, 5).Value = "Ingredientes manuais de Maturador"
        MyPlan.Cells(ContaLinha, 5).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(ContaLinha, 5).Style.Font.Bold = True

        MyPlan.Cells(ContaLinha, 6).Value = "kg"
        MyPlan.Cells(ContaLinha, 6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(ContaLinha, 6).Style.Font.Bold = True

        'Insere o cabecalho da parte de ingredientes
        MyPlan.Cells(ContaLinha, 7).Value = "Codigo"
        MyPlan.Cells(ContaLinha, 7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(ContaLinha, 7).Style.Font.Bold = True

        ContaLinha = ContaLinha + 2

        'Loop para cada bloco da receita
        For Conta = 0 To ingReceita.mCol.Count - 1

            MyPlan.Cells(ContaLinha, 3).Value = Conta
            MyPlan.Cells(ContaLinha, 5).Value = ingReceita.mCol(Conta).Nome
            MyPlan.Cells(ContaLinha, 6).Value = Format(ingReceita.mCol(Conta).Peso, "0.000")
            MyPlan.Cells(ContaLinha, 7).Value = ingReceita.mCol(Conta).Codigo
            MyPlan.Row(ContaLinha).Height = ROW_HEIGHT

            ContaLinha = ContaLinha + 1

        Next


        Return True

    End Function

    Function CodJulianoCalc() As String

        'Codigo Juliano
        '1o caracter = caracter final do ano Ex: 2003 -> 3
        Dim CodJuliano As String = Right(Now.Year, 1)

        '3 caracteres com o numero do dia no ano
        Dim Conta As Integer = 0
        Dim DataIniJu As Date = CDate("01/01/" & Format(Now, "yyyy"))
        For Conta = 1 To 366
            Dim DataJu As Date = DateAdd("d", Conta, DataIniJu)
            If DataJu >= Now Then Exit For
        Next

        Conta = Conta + 1

        'Se a hora for anterior a 6:00 da manha vale o dia anterior
        '    If Val(Format(Time, "hh")) < 6 Then conta = conta - 1


        CodJuliano = CodJuliano & Right("000" & Conta, 3)

        CodJulianoCalc = CodJuliano

    End Function

    Function DataTurno() As String

        'Se a hora for anterior a 6:00 da manha vale o dia anterior
        '    If Val(Format(Time, "hh")) < 6 Then
        '        DataAjust = DateAdd("d", -1, Date)
        '    Else
        Dim DataAjust As Date = Now.Date
        '    End If

        DataTurno = Format(DataAjust, "dd/MM/yyyy")

    End Function

    Function MontaRanges(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String, RecNum As Integer, RecNomeArq As String) As Boolean

        'Numero sequencial mensal
        If Area <> "CIP" Then
            MyPlan.Cells("J6").Value = BuscaNumSeqMensal()
        End If

        Dim DbRg As New Geral.nsRanges.dcRanges
        Dim dtRanges = (From It In DbRg.Ranges Where It.RecNum = RecNum).ToList

        If dtRanges.Count <= 0 Then Return False
        Dim Rec = dtRanges.First

        Dim MyRange As String = ""
        Dim NRows As Integer = MyPlan.Dimension.End.Row - MyPlan.Dimension.Start.Row

        MyPlan.Cells("H" & NRows).Value = "Max"
        MyPlan.Cells("I" & NRows).Value = "Med"
        MyPlan.Cells("J" & NRows).Value = "Min"

        MyPlan.Cells("G" & NRows + 1).Value = "Densidade"
        MyPlan.Cells("H" & NRows + 1).Value = Rec.DensMax
        MyPlan.Cells("I" & NRows + 1).Value = Rec.DensMed
        MyPlan.Cells("J" & NRows + 1).Value = Rec.DensMin

        MyPlan.Cells("G" & NRows + 2).Value = "Solidos"
        MyPlan.Cells("H" & NRows + 2).Value = Rec.SolMax
        MyPlan.Cells("I" & NRows + 2).Value = Rec.SolMed
        MyPlan.Cells("J" & NRows + 2).Value = Rec.SolMin

        'Centraliza e ajusta font das celulas
        MyPlan.Cells("G" & NRows & ":" & "J" & NRows + 2).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells("G" & NRows & ":" & "J" & NRows).Style.Font.Bold = True
        MyPlan.Cells("G" & NRows & ":" & "G" & NRows + 2).Style.Font.Bold = True

        Return True

    End Function

    Function BuscaNumSeqMensal() As Integer

        Dim DbRg As New Geral.nsRanges.dcRanges
        Dim dtNumSeqMensal = (From It In DbRg.NumSeqMensal).ToList

        'Numero sequencial mensal
        Dim AnoAtual As String = Val(Format(Now.Date, "yyyy"))
        Dim MesAtual As String = Val(Format(Now.Date, "mm"))


        'Verifica se o mes mudou
        Dim NumSeq As Integer = 1
        If dtNumSeqMensal.Count > 0 Then
            If AnoAtual = dtNumSeqMensal.First.AnoUlt Or MesAtual = dtNumSeqMensal.First.MesUlt Then
                'Nao virou o mes, incrementa
                NumSeq = dtNumSeqMensal.First.NumSeqMensal + 1
            End If
        End If


        'Apaga tudo desta tabela e atualiza
        DbRg.NumSeqMensal.DeleteAllOnSubmit(dtNumSeqMensal)


        DbRg.NumSeqMensal.InsertOnSubmit(New Geral.nsRanges.NumSeqMensal With {.AnoUlt = AnoAtual,
                                        .MesUlt = MesAtual, .NumSeqMensal = NumSeq})


        DbRg.SubmitChanges()

        Return NumSeq

    End Function

    Function BuscaIngrNome(Area As String, Codigo As String) As String

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtIngred = (From It In DbRc.Ingred Where It.Area = Area And It.IngrCodigo = Codigo).ToList

        If dtIngred.Count <= 0 Then Return ""

        Return dtIngred.First.IngrNome

    End Function

End Module
