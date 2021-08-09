Module basRelat


    Sub GeraRelat(Area As String, RecAtual As Integer, RecNome As String, IdBatch As String)

        Dim myEpplus As OfficeOpenXml.ExcelPackage
        Dim MyPlan As OfficeOpenXml.ExcelWorksheet

        'Cria arquivo
        Dim PathnameMod As String = Util.UtAppPath & "\..\Bin\RelatModelos\KbImprimeReceita.xlsx"
        If Area = "CIP" Then PathnameMod = Util.UtAppPath & "\..\Bin\RelatModelos\KbImprimeReceitaCIP.xlsx"

        Dim PathnameRel As String = "C:\Tmp\ReceitaPreench.xlsx"

        Dim RetCria As Boolean = Geral.CopiaArquivo(PathnameMod, PathnameRel)

        If RetCria <> True Then
            MsgBox("Falha na criacao do arquivo.")
            Exit Sub
        End If


        Dim myFile As New System.IO.FileInfo(PathnameRel)
        myEpplus = New OfficeOpenXml.ExcelPackage(myFile)
        MyPlan = myEpplus.Workbook.Worksheets("Receita")


        'Transforma a string em array de strings
        Dim stringSeparators() As String = {","}
        Dim batchIdArray() As String
        batchIdArray = IdBatch.Split(stringSeparators,
                      StringSplitOptions.RemoveEmptyEntries)


        MontaPlanilhaRelat(MyPlan, Area, RecDados.Num, RecDados.Nome, batchIdArray)

        MyPlan.Protection.SetPassword(Geral.SENHA_PROTEGE_PLAN)

        myEpplus.Save()
        myEpplus = Nothing

        Geral.AbreXlsx(PathnameRel)

    End Sub

End Module