Module basRelat


    Function GeraRelat(DataIniRel As String, DataFimRel As String) As Boolean

        Dim myEpplus As OfficeOpenXml.ExcelPackage
        Dim MyPlan As OfficeOpenXml.ExcelWorksheet

        'Cria arquivo
        Dim DataHoraTxt As String = Left(DataIniRel, 8)

        Dim PathnameMod As String = Util.UtAppPath & "\..\Bin\RelatModelos\KbMatGravaRelat.xlsx"
        Dim PathnameRel As String = "C:\Tmp\MatRelat.xlsx"

        Dim RetCria As Boolean
        RetCria = Geral.CopiaArquivo(PathnameMod, PathnameRel)

        If RetCria <> True Then
            MsgBox("Falha na criacao do arquivo.")
            Return False
        End If


        Dim myFile As New System.IO.FileInfo(PathnameRel)
        myEpplus = New OfficeOpenXml.ExcelPackage(myFile)
        MyPlan = myEpplus.Workbook.Worksheets("Dados")


        'Monta planilhas inividuais de tanques
        MontaPlanilhaRelat(myEpplus, DataIniRel, DataFimRel)

        MyPlan.Protection.SetPassword(Geral.SENHA_PROTEGE_PLAN)

        myEpplus.Save()
        myEpplus = Nothing

        Geral.AbreXlsx(PathnameRel)

        Return True

    End Function

End Module