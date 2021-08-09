Public Module basTrataExcel

    Function XlsAbreObj(ByRef MyXl As Excel.Application, ByVal PathRelat As String, ByVal Abrir As Boolean) As Boolean

        'Chama o excel abrindo o arquivo indicado
        Try

            MyXl = CreateObject("Excel.Application")
            MyXl.Workbooks.Open(PathRelat)

            'Torna este excel visivel
            If Abrir = True Then
                MyXl.Visible = True
            End If

        Catch ex As Exception

            XlsAbreObj = False
            Exit Function

        End Try

        XlsAbreObj = True

    End Function

    Function XlsFechaObj(ByVal MyXl As Excel.Application, ByVal Fechar As Boolean) As Boolean

        'Salva em disco
        MyXl.ActiveWorkbook.Save()

        'Torna este excel visivel
        'MyXl.Visible = True

        'Fecha excel
        If Fechar = True Then
            MyXl.Parent.Quit()
        End If

        'Libera objeto da memoria
        MyXl = Nothing

    End Function

    Function XlsCopiaMdelo(ByVal PathnameModelo As String, ByVal PathnameRel As String) As Boolean

        'Copia arqivo modelo para geracao de relatorio
        Try
            Kill(PathnameRel)
        Catch
        End Try

        Try
            FileCopy(PathnameModelo, PathnameRel)
        Catch ex As Exception
            Debug.Print("Erro: " & ex.Message)
            XlsCopiaMdelo = False
            Exit Function
        End Try

        XlsCopiaMdelo = True
        Exit Function

    End Function

End Module
