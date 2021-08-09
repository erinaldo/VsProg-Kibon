Public Module basLog

    'Lista de eventos para a janela frmLog
    Public ListaLog As New Collection

    Dim ArqNome As String = Util.UtAppPath & "\..\Bin\Log\KbMistGravaLog_"
    Dim LogHab As Boolean = True

    Public Sub LogAdd(ByVal LogNovo As String)

        If LogHab = False Then Return

        'Insere uma mensagem no log de eventos
        ListaLog.Add(Format(Now, "yyyy/MM/dd HH:mm:ss") & " - " & LogNovo)

        If ListaLog.Count > 20 Then
            ListaLog.Remove(1)
        End If

        LogApagaOld()

        LogEscreve(LogNovo)

    End Sub

    Public Sub LogApagaOld()

        Dim Dias As Integer = -30

        Dim DataOld As Date = DateAdd(DateInterval.Day, Dias, Now)

        Dim DataOldTxt As String = Format(DataOld, "yyyyMMdd") & ".txt"

        If System.IO.File.Exists(ArqNome & DataOldTxt) = True Then

            Try
                System.IO.File.Delete(ArqNome & DataOldTxt)
            Catch : End Try

        End If

    End Sub

    Private Sub LogEscreve(ByVal LogNovo As String)

        'Insere mensagem no arquivo txt
        Try

            Dim Data As String = Format(Now, "yyyyMMdd") & ".txt"

            Dim ArqLog As System.IO.StreamWriter

            If System.IO.File.Exists(ArqNome & Data) = True Then

                ArqLog = New IO.StreamWriter(ArqNome & Data, True)

                ArqLog.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " - " & LogNovo)

                ArqLog.Close()

            Else

                ArqLog = New IO.StreamWriter(ArqNome & Data)

                ArqLog.WriteLine(Format(Now, "yyyy/MM/dd HH:mm:ss") & " - Arquivo criado - " & LogNovo)

                ArqLog.Close()
            End If

        Catch : End Try

    End Sub

End Module
