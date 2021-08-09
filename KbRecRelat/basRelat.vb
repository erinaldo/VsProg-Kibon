Module basRelat

    Public Function MontaRelat(AreaSel As String, dtReceita As List(Of Geral.nsReceitas.Rec)) As Boolean

        Dim ArquivoCriado As String = "C:\Tmp\RecRelat.xlsx"""
        CopiaModelo(ArquivoCriado)

        Dim myFile As New System.IO.FileInfo(ArquivoCriado)
        Dim myEpplus As OfficeOpenXml.ExcelPackage = New OfficeOpenXml.ExcelPackage(myFile)

        '================================
        'Planilha Receitas
        '================================
        Dim MyPlan As OfficeOpenXml.ExcelWorksheet = myEpplus.Workbook.Worksheets("Receitas")
        MontaIndice(MyPlan, AreaSel, dtReceita)

        '================================
        'Planilhas Rec
        '================================
        MontaReceitas(myEpplus, AreaSel, dtReceita)

        myEpplus.Workbook.Worksheets.Delete("RecMod")

        'MyPlan.Protection.SetPassword(Geral.SENHA_PROTEGE_PLAN)

        myEpplus.Save()
        myEpplus = Nothing

        Geral.AbreXlsx(ArquivoCriado)

        Return True

    End Function

    Private Sub MontaIndice(MyPlan As OfficeOpenXml.ExcelWorksheet, AreaSel As String, dtReceita As List(Of Geral.nsReceitas.Rec))

        '================================
        'Planilha Receitas
        '================================

        'escreve data no cabeçalho e nome da área
        MyPlan.Cells(2, 7).Value = Format(Now, "dd/MM/yyyy")
        MyPlan.Cells(2, 7).Style.Font.Bold = True
        MyPlan.Cells(2, 7).Style.Font.Color.SetColor(Color.Blue)

        MyPlan.Cells(2, 4).Value = AreaSel.ToUpper
        MyPlan.Cells(2, 4).Style.Font.Bold = True
        MyPlan.Cells(2, 4).Style.Font.Color.SetColor(Color.Blue)


        Dim ContaLinha As Integer = 5

        For Each Reg In dtReceita

            MyPlan.Cells(ContaLinha, 2).Value = Reg.Codigo
            MyPlan.Cells(ContaLinha, 3).Value = Reg.RecNum
            MyPlan.Cells(ContaLinha, 4).Value = Reg.RecNome
            MyPlan.Cells(ContaLinha, 5).Value = Reg.RecDescr

            ContaLinha = ContaLinha + 1

        Next

    End Sub

    Private Sub MontaReceitas(myEpplus As OfficeOpenXml.ExcelPackage, Area As String,
                              dtReceita As List(Of Geral.nsReceitas.Rec))

        '================================
        'Planilhas Rec
        '================================
        For Each Rec In dtReceita

            Dim NovaPlan As String = NomePlanilha(Rec.RecNum)

            'Copia planilha modelo para a segunda receita em diante
            Dim MyPlan As OfficeOpenXml.ExcelWorksheet = Nothing
            Try
                MyPlan = myEpplus.Workbook.Worksheets.Copy("RecMod", NovaPlan)
            Catch : End Try

            MontaPlanilhaRelat(MyPlan, Area, Rec.RecNum, Rec.RecNome)

            'If Rec.RecNum > 2 Then Exit For

        Next

    End Sub

    Private Function NomePlanilha(ByVal RecId As Integer) As String

        Return "Rota" & Format(RecId, "000")

    End Function

    Function MontaPlanilhaRelat(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String, RecNum As Integer, RecNome As String) As Boolean

        Dim MyBlocos As New clsBlocos
        Dim ingReceita As New clsIngreds


        'Le arquivo de receita na estrutura MyBlocos
        Dim RecCod As String = "", RecDescr As String = ""
        ReceitaAbre(Area, RecNum, MyBlocos, RecCod, RecDescr)

        'Le arquivo de ingredientes na estrutura ingReceita
        IngAbre(RecNum, ingReceita)

        'Cabecalho
        MontaPlanCabecalho(MyPlan, Area, RecNum, RecNome, RecCod, RecDescr)

        'Monta blocos nas planilhas de receita
        Dim NRows As Integer = MontaPlanBlocos(MyPlan, MyBlocos, RecNum, RecNome)

        'Monta ingredientes nas planilhas de receita
        MontaPlanIng(MyPlan, ingReceita, RecNum, RecNome, NRows)

        Return True

    End Function

    Function ReceitaAbre(Area As String, RecNum As Integer, MyBlocos As clsBlocos, ByRef outReceitaCod As String,
                         ByRef outReceitaDescr As String) As Boolean

        Dim Blk As clsBloco

        'Le dados de receita
        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.RecNum = RecNum And It.Area = Area).ToList
        If dtRec.Count <= 0 Then Return False

        outReceitaDescr = dtRec.First.RecDescr
        outReceitaCod = dtRec.First.Codigo
        'outPesoRefer = Rec.PesoRefer


        'Dados dos blocos
        Dim dtRecBlocos = (From It In DbRc.RecBlocos Where It.RecNum = RecNum And It.Area = Area Order By It.ItemSeq).ToList

        For Each Rec In dtRecBlocos

            'Cria novo Blk
            Blk = New clsBloco
            MyBlocos.mCol.Add(Blk)
            Blk.LeModelo(Area, Rec.BlkNum)

            If Blk.MyParametros.mCol.Count > 0 Then Blk.MyParametros.mCol(0).Valor = Rec.Param01
            If Blk.MyParametros.mCol.Count > 1 Then Blk.MyParametros.mCol(1).Valor = Rec.Param02
            If Blk.MyParametros.mCol.Count > 2 Then Blk.MyParametros.mCol(2).Valor = Rec.Param03
            If Blk.MyParametros.mCol.Count > 3 Then Blk.MyParametros.mCol(3).Valor = Rec.Param04
            If Blk.MyParametros.mCol.Count > 4 Then Blk.MyParametros.mCol(4).Valor = Rec.Param05
            If Blk.MyParametros.mCol.Count > 5 Then Blk.MyParametros.mCol(5).Valor = Rec.Param06
            If Blk.MyParametros.mCol.Count > 6 Then Blk.MyParametros.mCol(6).Valor = Rec.Param07
            If Blk.MyParametros.mCol.Count > 7 Then Blk.MyParametros.mCol(7).Valor = Rec.Param08
            If Blk.MyParametros.mCol.Count > 8 Then Blk.MyParametros.mCol(8).Valor = Rec.Param09

        Next

        Return True

    End Function

    Function IngAbre(RecNum As Integer, ByRef ingReceita As clsIngreds) As Boolean

        'Abre o arquivo de receita
        Dim DbRc As New Geral.nsReceitas.dcReceitas

        'Dados de ingredientes da receita
        Dim dtDados = (From Ri In DbRc.RecIngred Join Ig In DbRc.Ingred On Ri.IngrCodigo Equals Ig.IngrCodigo _
                       And Ri.Area Equals Ig.Area
                       Where Ri.RecNum = RecNum
                       Order By Ri.ItemSeq).ToList

        For Each Rec In dtDados

            Dim IngCod As String = Trim(Rec.Ig.IngrCodigo)

            Dim NwIngr As New clsIngred With {.Codigo = IngCod, .Nome = Rec.Ig.IngrNome, .Peso = Rec.Ri.Peso}
            ingReceita.mCol.Add(NwIngr)

        Next

        Return True

    End Function

    Function MontaPlanCabecalho(MyPlan As OfficeOpenXml.ExcelWorksheet, Area As String, _
            RecNum As Integer, RecNome As String, RecCod As String, RecDescr As String) As Boolean

        'Inclui dados de cabecalho na plnilha Rec0XX

        'Data
        Dim DataTxt As String = "'" & Format(Now.Date, "dd/mm/yyyy")
        MyPlan.Cells("H2").Value = DataTxt

        'Area
        MyPlan.Cells("E2").Value = Area

        'Dados da receita
        MyPlan.Cells("E3").Value = RecNum
        MyPlan.Cells("E4").Value = RecNome
        MyPlan.Cells("E5").Value = RecCod
        MyPlan.Cells("E6").Value = RecDescr

        Return True

    End Function

    Function MontaPlanBlocos(MyPlan As OfficeOpenXml.ExcelWorksheet, _
            MyBlocos As clsBlocos, RecNum As Integer, RecNome As String) As Integer

        Dim Blk As clsBloco
        Dim Par As clsParametro
        Dim ColOffset As Integer = 2


        'Dimensiona matrix
        Dim ContaLinha As Integer = 11
        Dim ContaBloco As Integer = 1


        'Loop para cada bloco da receita
        For Each Blk In MyBlocos.mCol

            MyPlan.Cells(ContaLinha, ColOffset + 0).Value = ContaBloco
            MyPlan.Cells(ContaLinha, ColOffset + 1).Value = Blk.NumeroDoBloco
            MyPlan.Cells(ContaLinha, ColOffset + 3).Value = Blk.Descricao

            ContaLinha = ContaLinha + 1


            'Loop para cada parametro do bloco
            Dim ContaParam As Integer = 1
            For Each Par In Blk.MyParametros.mCol

                MyPlan.Cells(ContaLinha, ColOffset + 2).Value = ContaParam
                MyPlan.Cells(ContaLinha, ColOffset + 3).Value = Par.Descricao
                MyPlan.Cells(ContaLinha, ColOffset + 4).Value = Format(Par.Valor, "0.000")
                MyPlan.Cells(ContaLinha, ColOffset + 5).Value = Par.UnidadeEngenharia

                ContaLinha = ContaLinha + 1
                ContaParam = ContaParam + 1

            Next

            ContaBloco = ContaBloco + 1
            ContaLinha = ContaLinha + 1

        Next


        'Redimensiona matrix para o numero de linhas do Excel utilizadas
        'ReDim Preserve MyMatrix(ContaLinha, 4) As String

        'Escreve no excel
        'PosIni = "B" & 11
        'PosFim = "G" & 11 + ContaLinha - 1
        'MyRange = PosIni & ":" & PosFim

        'MyPlan.Range(MyRange) = MyMatrix

        Return ContaLinha

    End Function

    Function MontaPlanIng(MyPlan As OfficeOpenXml.ExcelWorksheet, _
            ingReceita As clsIngreds, RecNum As Integer, RecNome As String, NDados As Integer) As Boolean

        Dim Ing As clsIngred
        Dim MyRange As String = ""
        Dim ColOffset As Integer = 4
        Dim ContaLinha As Integer = NDados + 2

        If ingReceita.mCol.Count <= 0 Then Return False

        'Insere o cabecalho da parte de ingredientes
        MyRange = "E" & ContaLinha
        MyPlan.Cells(MyRange).Value = "Ingredientes"
        MyPlan.Cells(MyRange).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(MyRange).Style.Font.Bold = True

        MyRange = "F" & ContaLinha
        MyPlan.Cells(MyRange).Value = "%"
        MyPlan.Cells(MyRange).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(MyRange).Style.Font.Bold = True

        MyRange = "G" & ContaLinha
        MyPlan.Cells(MyRange).Value = "Codigo"
        MyPlan.Cells(MyRange).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
        MyPlan.Cells(MyRange).Style.Font.Bold = True

        ContaLinha = ContaLinha + 2

        'Loop para cada bloco da receita
        Dim Conta As Integer = 1
        For Each Ing In ingReceita.mCol

            MyPlan.Cells(ContaLinha, ColOffset + 0).Value = Conta
            MyPlan.Cells(ContaLinha, ColOffset + 1).Value = Ing.Nome
            MyPlan.Cells(ContaLinha, ColOffset + 2).Value = Format(Ing.Peso, "0.000")
            MyPlan.Cells(ContaLinha, ColOffset + 3).Value = Ing.Codigo

            ContaLinha = ContaLinha + 1
            Conta = Conta + 1

        Next

        'Escreve no excel
        'PosIni = "D" & NRows + 5
        'PosFim = "G" & NRows + 5 + ContaLinha - 1
        'MyRange = PosIni & ":" & PosFim

        'MyPlan.Cells(MyRange) = MyMatrix

        Return True

    End Function

End Module
