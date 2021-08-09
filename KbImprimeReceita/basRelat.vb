Module basRelat


    Sub GeraRelat(Area As String, RecAtual As Integer, RecNome As String)

        Dim myEpplus As OfficeOpenXml.ExcelPackage
        Dim MyPlan As OfficeOpenXml.ExcelWorksheet

        'Cria arquivo
        Dim PathnameMod As String = Util.UtAppPath & "\..\Bin\RelatModelos\KbImprimeReceita.xlsx"
        If Area = "CIP" Then PathnameMod = Util.UtAppPath & "\..\Bin\RelatModelos\KbImprimeReceitaCIP.xlsx"

        Dim PathnameRel As String = "C:\Tmp\Receita.xlsx"

        Dim RetCria As Boolean = Geral.CopiaArquivo(PathnameMod, PathnameRel)

        If RetCria <> True Then
            MsgBox("Falha na criacao do arquivo.")
            Exit Sub
        End If


        Dim myFile As New System.IO.FileInfo(PathnameRel)
        myEpplus = New OfficeOpenXml.ExcelPackage(myFile)
        MyPlan = myEpplus.Workbook.Worksheets("Receita")


        MontaPlanilhaRelat(MyPlan, Area, RecDados.Num, RecDados.Nome)

        MyPlan.Protection.SetPassword(Geral.SENHA_PROTEGE_PLAN)
 
        myEpplus.Save()
        myEpplus = Nothing

        Geral.AbreXlsx(PathnameRel)

    End Sub

End Module