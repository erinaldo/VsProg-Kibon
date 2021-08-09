Public Module basTrataArquivo

    Public Const SENHA_PROTEGE_PLAN As String = "KIBON"

    Public Function PastaExiste(ByVal Caminho As String) As Boolean

        Try
            'verifica se existe pasta destino
            Dim myDirectory As New System.IO.DirectoryInfo(Caminho)
            If myDirectory.Exists = False Then
                myDirectory.Create()
            End If
        Catch
            Return False
        End Try

        Return True

    End Function

    Public Function CopiaArquivo(ByVal PathModelo, ByVal PathArqNovo) As Boolean

        Dim myFile As System.IO.FileInfo

        Try
            myFile = New System.IO.FileInfo(PathArqNovo)
            If myFile.Exists = True Then
                myFile.Delete()
            End If

            myFile = New System.IO.FileInfo(PathModelo)

            If myFile.Exists = False Then
                MsgBox("O arquivo de modelo do relatório não foi encontrado", MsgBoxStyle.Exclamation)
                Return False
            End If

            myFile.CopyTo(PathArqNovo)

            Return True
        Catch
            Return False
        End Try

    End Function

End Module
