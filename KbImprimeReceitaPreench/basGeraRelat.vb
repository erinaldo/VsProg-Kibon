Imports Microsoft.VisualBasic.PowerPacks

Module basGeraRelat

    Dim ContaLinha As Integer = 0
    Dim ROW_HEIGHT As Integer = 18
    ' Declaracao das lista para serem populadas com os ingredientes
    'Dim dtOrdemIngred = New ArrayList()
    'Dim dtOrdemPequenoIngred = New ArrayList()
    'Dim dtOrdemIngredMat = New ArrayList()
    ' Lista de BATCH ID'S passados pelo USUARIO
    'Dim listBatchID = New ArrayList()

    Sub MontaPlanilhaRelat(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String, RecNum As Integer, RecNome As String, IdBatch As String())

        '    Dim MyPlan As OfficeOpenXml.ExcelWorksheet
        Dim Blocos As New clsBlocos
        Dim ingReceita As New clsIngreds
        Dim ingReceitaMat As New clsIngredsMat


        Dim NumSeqMensal As Integer = 0

        'Le arquivo de receita na estrutura Blocos
        Dim RecCod As String = "", RecDescr As String = "", RecDens As Double
        RecAbre(Area, RecNum, Blocos, RecCod, RecDescr, RecDens)


        'Le arquivo de ingredientes na estrutura ingReceita
        IngAbre(Area, RecNum, ingReceita, IdBatch)
        IngAbreMat(Area, RecNum, ingReceitaMat, IdBatch)


        'Atualiza planilha Rec0XX
        Dim PlanNome As String = "Rec" & Format(RecNum, "000")

        'Cabecalho
        MontaPlanCabecalho(MyPlan, Area, RecNum, RecNome, RecCod, RecDescr, RecDens, IdBatch)

        'Monta ingredientes de Receita na planilha
        'MontaPlanIngRec(MyPlan, ingReceita, RecNum, RecNome)

        'Monta blocos nas planilhas de receita
        MontaPlanBlocos(ingReceita, MyPlan, Area, Blocos, RecNum, RecNome)

        'Monta ingredientes de Maturador na planilha
        MontaPlanIngMat(MyPlan, ingReceitaMat, RecNum, RecNome)

        'Monta ranges
        Dim RecNomeArq As String = ""
        MontaRanges(MyPlan, Area, RecNum, RecNomeArq)

    End Sub

    Function IngAbre(Area As String, RecNum As Integer, ByRef ingReceita As clsIngreds, IdBatch As String()) As Boolean

        'Abre o arquivo de receita
        Dim CodigoTxt As String
        Dim Nome As String
        Dim Peso As Double
        Dim Lote As String
        Dim DataValidade As String
        Dim ItemSeq1 As Int32
        Dim NomeOperador1 As String

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRecIngred = (From It In DbRc.RecIngred Where It.Area = Area And It.RecNum = RecNum Order By It.ItemSeq).ToList


        ' Pega qual o ID da ordem de misturas
        Dim dtCBTOrdemID = (From It In DbRc.tb_CBT_CadastroBatch Where It.RecNum = RecNum And IdBatch.Contains(It.CBT_IDBatch) And It.CBT_Finalizado = True Order By It.CBT_ID Select It.CBT_ID).ToList
        ' De acordo com o ID, faz um group e um sum com todos os ingredientes utilizados nos pacotes de misturas
        Dim dtOrdemIngred = From pct In DbRc.tb_PCT_Pacotes
                            Join ppc In DbRc.tb_PPC_PesagemPacote On ppc.PCT_ID Equals pct.PCT_ID
                            Join ing In DbRc.Ingred On ing.IngrCodigo Equals ppc.IngrCodigo
                            Where dtCBTOrdemID.Contains(pct.CBT_ID) And pct.PCT_Utilizado = True
                            Group ppc By ppc.IngrCodigo, ing.IngrNome, ppc.PPC_Lote, ppc.PPC_DataValidade, pct.PCT_UsuarioOperador Into Group
                            Select IngrCodigo, IngrNome, PesoTotal = Group.Sum(Function(ppc) ppc.PPC_Peso), PPC_Lote, PPC_DataValidade, PCT_UsuarioOperador

        ' Group ppc By ppc.IngrCodigo, ing.IngrNome, ppc.PPC_Lote, ppc.PPC_DataValidade Into Group
        ' Select IngrCodigo, IngrNome, PesoTotal = Group.Sum(Function(ppc) ppc.PPC_Peso), PPC_Lote, PPC_DataValidade
        ' Para cada ingrediente adiciona uma linha na planilha
        For Each Ing In dtOrdemIngred

            'Peso = Ing.PesoTotal
            'CodigoTxt = Ing.IngrCodigo
            'Nome = Ing.IngrNome
            'Lote = Ing.PPC_Lote
            'DataValidade = Ing.PPC_DataValidade
            'ingReceita.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso, .Lote = Lote, .DataValidade = DataValidade})

            'Dim ingrID = (From it In DbRc.Ingred Where it.IngrCodigo = Ing.IngrCodigo Select it.ID).FirstOrDefault()
            'Dim seqNumeroIngred = (From it In DbRc.RecBlocos Where it.RecNum = RecNum And it.Param01 = ingrID Select it.ItemSeq).FirstOrDefault()

            'Dim ingrID = (From it In DbRc.Ingred Where it.IngrCodigo = Ing.IngrCodigo Select it.ID).FirstOrDefault()

            Dim seqNumeroIngred = (From it In DbRc.RecBlocos Where it.RecNum = RecNum And it.Param02 <> 0 And it.Param06 = 1 Select it.ItemSeq).FirstOrDefault()

            Peso = Ing.PesoTotal
            CodigoTxt = Ing.IngrCodigo
            Nome = Ing.IngrNome
            Lote = Ing.PPC_Lote
            DataValidade = Ing.PPC_DataValidade
            ItemSeq1 = seqNumeroIngred
            NomeOperador1 = Ing.PCT_UsuarioOperador
            ingReceita.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso, .Lote = Lote, .DataValidade = DataValidade, .ItemSeq = ItemSeq1, .NomeOperador = NomeOperador1})

        Next




        ' Pega qual o ID da ordem de Pequenos Ingredientes
        Dim dtCPIOrdemID = (From It In DbRc.tb_CPI_CadastroPequenoIngrediente Where It.RecNum = RecNum And IdBatch.Contains(It.CPI_IDBlend) And It.CPI_Finalizado = True Order By It.CPI_ID Select It.CPI_ID).ToList

        ' De acordo com o ID, faz um group e um sum com todos os pequenos ingredientes utilizados na receita
        Dim dtOrdemPequenoIngred = From pin In DbRc.tb_PIN_PequenoIngrediente
                                   Join ppi In DbRc.tb_PPI_PesagemPequenoIngr On ppi.PIN_ID Equals pin.PIN_ID
                                   Join ing In DbRc.Ingred On ing.IngrCodigo Equals ppi.IngrCodigo
                                   Where dtCPIOrdemID.Contains(pin.CPI_ID) And pin.PIN_Utilizado = True
                                   Group ppi By ppi.IngrCodigo, ing.IngrNome, ppi.PPI_Lote, ppi.PPI_DataValidade, pin.PIN_UsuarioOperador Into Group
                                   Select IngrCodigo, IngrNome, PesoTotal = Group.Sum(Function(ppi) ppi.PPI_Peso), PPI_Lote, PPI_DataValidade, PIN_UsuarioOperador

        ' Para cada ingrediente adiciona uma linha na planilha
        For Each Ing In dtOrdemPequenoIngred

            Dim ingrID = (From it In DbRc.Ingred Where it.IngrCodigo = Ing.IngrCodigo Select it.ID).FirstOrDefault()
            Dim seqNumeroIngred = (From it In DbRc.RecBlocos Where it.RecNum = RecNum And it.Param01 = ingrID Select it.ItemSeq).FirstOrDefault()

            Peso = Ing.PesoTotal
            CodigoTxt = Ing.IngrCodigo
            Nome = Ing.IngrNome
            Lote = Ing.PPI_Lote
            DataValidade = Ing.PPI_DataValidade
            ItemSeq1 = seqNumeroIngred
            NomeOperador1 = Ing.PIN_UsuarioOperador
            ingReceita.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso, .Lote = Lote, .DataValidade = DataValidade, .ItemSeq = ItemSeq1, .NomeOperador = NomeOperador1})
        Next



        'For Each Rec In dtRecIngred

        '    Peso = Rec.Peso * (TamBatch / 100.0#)
        '    CodigoTxt = Rec.IngrCodigo
        '    Nome = BuscaIngrNome(Area, Rec.IngrCodigo)
        '    ingReceita.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso})

        'Next




        Return True

    End Function

    Function IngAbreMat(Area As String, RecNum As Integer, ByRef ingReceitaMat As clsIngredsMat, IdBatch As String()) As Boolean

        'Abre o arquivo de receita
        Dim CodigoTxt As String
        Dim Nome As String
        Dim Peso As Double
        Dim Lote As String
        Dim DataValidade As String
        Dim NomeOperador1 As String

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRecIngredMat = (From It In DbRc.RecIngredMat Where It.Area = Area And It.RecNum = RecNum Order By It.ItemSeq).ToList



        Dim dtCBMOrdemID = (From It In DbRc.tb_CBM_CadastroBatchMaturacao Where It.RecNum = RecNum And IdBatch.Contains(It.CBM_IDBatch) And It.CBM_Finalizado = True Order By It.CBM_ID Select It.CBM_ID).ToArray
        Dim dtOrdemIngredMat = From bld In DbRc.tb_BLD_Baldes
                               Join pbd In DbRc.tb_PBD_PesagemBalde On pbd.BLD_ID Equals bld.BLD_ID
                               Join ing In DbRc.Ingred On ing.IngrCodigo Equals pbd.IngrCodigo
                               Where dtCBMOrdemID.Contains(bld.CBM_ID) And bld.BLD_Utilizado = True
                               Group pbd By pbd.IngrCodigo, ing.IngrNome, pbd.PBD_Lote, pbd.PBD_DataValidade, bld.BLD_UsuarioOperador Into Group
                               Select IngrCodigo, IngrNome, PesoTotal = Group.Sum(Function(pbd) pbd.PBD_Peso), PBD_Lote, PBD_DataValidade, BLD_UsuarioOperador

        If dtOrdemIngredMat.Count > 0 Then

            For Each Ing In dtOrdemIngredMat
                Peso = Ing.PesoTotal
                CodigoTxt = Ing.IngrCodigo
                Nome = Ing.IngrNome
                Lote = Ing.PBD_Lote
                DataValidade = Ing.PBD_DataValidade
                NomeOperador1 = Ing.BLD_UsuarioOperador
                ingReceitaMat.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso, .Lote = Lote, .DataValidade = DataValidade, .NomeOperador = NomeOperador1})
            Next
        Else
            For Each Rec In dtRecIngredMat

                Peso = Rec.Peso * (TamBatch / 100.0#)
                CodigoTxt = Rec.IngrCodigo
                Nome = BuscaIngrNome(Area, Rec.IngrCodigo)
                ingReceitaMat.mCol.Add(New clsIngred With {.Codigo = CodigoTxt, .Nome = Nome, .Peso = Peso})

            Next
        End If




        Return True

    End Function

    Function MontaPlanCabecalho(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String,
            RecNum As Integer, RecNome As String, RecCod As String, RecDescr As String, RecDens As Double, IdBatch As String()) As Boolean

        'Inclui dados de cabecalho na plnilha Rec0XX


        Dim DbRc As New Geral.nsReceitas.dcReceitas
        ''Query para pegar os valores de Tq Maturador, Volume Final, Volume Convertido, Densidade
        Dim tanqueMaturacao = ""
        Dim prefixoMat = ""
        Dim informacoesCabecalhoMat = (From cbm In DbRc.tb_CBM_CadastroBatchMaturacao Where cbm.RecNum = RecNum And IdBatch.Contains(cbm.CBM_IDBatch) Select cbm).FirstOrDefault
        If informacoesCabecalhoMat IsNot Nothing Then
            MyPlan.Cells("B11").Value = informacoesCabecalhoMat.CBM_Tanque
            tanqueMaturacao = informacoesCabecalhoMat.CBM_Tanque
            MyPlan.Cells("G11").Value = Format(informacoesCabecalhoMat.CBM_Densidade, "0.000")

            Dim vSolidos = Math.Round(Convert.ToDouble(informacoesCabecalhoMat.CBM_Solidos), 3)
            Dim vGordura = Math.Round(Convert.ToDouble(informacoesCabecalhoMat.CBM_Gordura), 3)
            Dim vPH = Math.Round(Convert.ToDouble(informacoesCabecalhoMat.CBM_PH), 3)

            MyPlan.Cells("E11").Value = "              " + Convert.ToString(informacoesCabecalhoMat.CBM_VolumeFinal) + "                            " + Convert.ToString(Format((informacoesCabecalhoMat.CBM_VolumeFinal * informacoesCabecalhoMat.CBM_Densidade), "0"))
            MyPlan.Cells("F11").Value = Convert.ToString(vSolidos)
            MyPlan.Cells("H11").Value = "       " + Convert.ToString(vGordura) + "                      " + Convert.ToString(vPH)

            If informacoesCabecalhoMat.CBM_Remonte IsNot Nothing Then
                MyPlan.Cells("F4").Value = "    ( X ) SIM (   )NÃO"
                MyPlan.Cells("F7").Value = "TQ (    )    Mist ( X )    Qtde"
                MyPlan.Cells("F8").Value = Convert.ToString(informacoesCabecalhoMat.CBM_Remonte)
            End If

            If informacoesCabecalhoMat.CBM_Reprocesso IsNot Nothing Then
                MyPlan.Cells("F13").Value = Convert.ToString(informacoesCabecalhoMat.CBM_Reprocesso)
            End If

            If tanqueMaturacao = "TQ6201" Or tanqueMaturacao = "TQ6202" Or tanqueMaturacao = "TQ6203" Or tanqueMaturacao = "TQ6204" Or tanqueMaturacao = "TQ6211" Or tanqueMaturacao = "TQ6212" Then
                prefixoMat = "TH2"
            End If

            If tanqueMaturacao = "TQ6207" Or tanqueMaturacao = "TQ6208" Then
                prefixoMat = "Rollo32"
            End If

            If tanqueMaturacao = "TQ6205" Or tanqueMaturacao = "TQ6206" Or tanqueMaturacao = "TQ6209" Or tanqueMaturacao = "TQ6210" Or tanqueMaturacao = "TQ6213" Or tanqueMaturacao = "TQ6214" Or tanqueMaturacao = "TQ6215" Or tanqueMaturacao = "TQ6216" Then
                prefixoMat = "TH1"
            End If

            If tanqueMaturacao = "TQ6255" Or tanqueMaturacao = "TQ6256" Or tanqueMaturacao = "TQ6257" Or tanqueMaturacao = "TQ6258" Or tanqueMaturacao = "TQ6259" Or tanqueMaturacao = "TQ6260" Then
                prefixoMat = "TH3"
            End If

        End If

        Dim informacoesCabecalhoPrep = (From cbt In DbRc.tb_CBT_CadastroBatch Where cbt.RecNum = RecNum And IdBatch.Contains(cbt.CBT_IDBatch) Select cbt).ToList
        If informacoesCabecalhoPrep IsNot Nothing Then
            If informacoesCabecalhoPrep.Count = 2 Then
                NomeDoTqDestino = informacoesCabecalhoPrep.ElementAt(0).CBT_Tanque
                MyPlan.Cells("I1").Value = prefixoMat + "-" + Convert.ToString(informacoesCabecalhoPrep.ElementAt(0).CBT_IDBatch)
                MyPlan.Cells("F2").Value = informacoesCabecalhoPrep.ElementAt(1).CBT_Tanque
            End If

            If informacoesCabecalhoPrep.Count = 1 Then
                NomeDoTqDestino = informacoesCabecalhoPrep.ElementAt(0).CBT_Tanque
                MyPlan.Cells("I1").Value = prefixoMat + "-" + Convert.ToString(informacoesCabecalhoPrep.ElementAt(0).CBT_IDBatch)
            End If

        End If



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

    Function MontaPlanBlocos(ingReceita As clsIngreds, MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String,
            Blocos As clsBlocos, RecNum As Integer, RecNome As String) As Boolean

        Dim Blk As clsBloco
        Dim Par As clsParametro


        'Dimensiona matrix
        ContaLinha = 15
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
                    'MyPlan.Cells(ContaLinha, 7).Value = Par.UnidadeEngenharia

                    ''Blocos de codigos inseridos por Hardcode para identificar Açucar invertido, Oleo e Glucose
                    'If Blk.NumeroDoBloco = 2003 Then
                    '    MyPlan.Cells(ContaLinha, 7).Value = "925843"
                    'End If

                    'If Blk.NumeroDoBloco = 2009 Then
                    '    MyPlan.Cells(ContaLinha, 7).Value = "935606"
                    'End If

                    'If Blk.NumeroDoBloco = 2011 Then
                    '    MyPlan.Cells(ContaLinha, 7).Value = "67434836"
                    'End If

                    MyPlan.Row(ContaLinha).Height = ROW_HEIGHT

                    ContaLinha = ContaLinha + 1

                    If Blk.NumeroDoBloco = 2017 Then

                        'Loop para cada bloco da receita
                        Dim Conta As Integer = 1
                        For Each Ing In ingReceita.mCol

                            If Ing.ItemSeq = ContaBloco Then

                                MyPlan.Cells(ContaLinha, 3).Value = Ing.NomeOperador
                                'MyPlan.Cells(ContaLinha, 4).Value = Ing.ItemSeq
                                MyPlan.Cells(ContaLinha, 5).Value = Ing.Nome
                                MyPlan.Cells(ContaLinha, 6).Value = Format(Ing.Peso, "0.000")
                                MyPlan.Cells(ContaLinha, 7).Value = Ing.Codigo
                                MyPlan.Cells(ContaLinha, 8).Value = Ing.Lote
                                MyPlan.Cells(ContaLinha, 10).Value = Ing.DataValidade
                                MyPlan.Row(ContaLinha).Height = ROW_HEIGHT

                                ContaLinha = ContaLinha + 1
                                Conta = Conta + 1

                            End If

                        Next

                    End If


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

        ''Loop para cada bloco da receita
        'Dim Conta As Integer = 1
        'For Each Ing In ingReceita.mCol

        '    MyPlan.Cells(ContaLinha, 3).Value = Conta
        '    MyPlan.Cells(ContaLinha, 4).Value = Ing.ItemSeq
        '    MyPlan.Cells(ContaLinha, 5).Value = Ing.Nome
        '    MyPlan.Cells(ContaLinha, 6).Value = Format(Ing.Peso, "0.000")
        '    MyPlan.Cells(ContaLinha, 7).Value = Ing.Codigo
        '    MyPlan.Cells(ContaLinha, 8).Value = Ing.Lote
        '    MyPlan.Cells(ContaLinha, 10).Value = Ing.DataValidade
        '    MyPlan.Row(ContaLinha).Height = ROW_HEIGHT

        '    ContaLinha = ContaLinha + 1
        '    Conta = Conta + 1

        'Next


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

            'MyPlan.Cells(ContaLinha, 3).Value = Conta
            MyPlan.Cells(ContaLinha, 3).Value = ingReceita.mCol(Conta).NomeOperador
            MyPlan.Cells(ContaLinha, 5).Value = ingReceita.mCol(Conta).Nome
            MyPlan.Cells(ContaLinha, 6).Value = Format(ingReceita.mCol(Conta).Peso, "0.000")
            MyPlan.Cells(ContaLinha, 7).Value = ingReceita.mCol(Conta).Codigo
            MyPlan.Cells(ContaLinha, 8).Value = ingReceita.mCol(Conta).Lote
            MyPlan.Cells(ContaLinha, 10).Value = ingReceita.mCol(Conta).DataValidade
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
