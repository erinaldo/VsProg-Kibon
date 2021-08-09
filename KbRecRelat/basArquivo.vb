Module basArquivo

    Public Function CopiaModelo(ByRef ArquivoCriado As String) As Boolean

        'monta data de controle do arquivo a ser criado
        Dim DataHora As String = Format(Now, "dd/MM/yyyy hh:mm:ss")
        Dim DataHoraTxt As String = Util.UtConvDataYmd(DataHora)

        Dim PathArqMod As String = Util.UtAppPath & "\..\Bin\RelatModelos\KbRecRelat.xlsx"
        Dim PathArqNovo As String = "C:\Tmp\RecRelat_" & DataHoraTxt & ".xlsx"

        Dim Ret As Boolean = Geral.CopiaArquivo(PathArqMod, PathArqNovo)

        If Ret = False Then
            MsgBox("Não foi possível copiar o arquivo modelo de relatório", MsgBoxStyle.Exclamation)
            Return False
        End If

        ArquivoCriado = PathArqNovo

        Return True

    End Function

End Module
