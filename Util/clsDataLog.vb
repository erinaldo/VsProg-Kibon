Public Class clsDataLog

    Dim LogProg As String
    Dim LogDir As String
    Dim LogMaxDias As Integer
    Dim DiaAnt As Integer = 0

    Sub New(ByVal LogProg As String, ByVal LogDir As String, ByVal LogMaxDias As Integer)

        Me.LogProg = LogProg
        Me.LogDir = LogDir
        Me.LogMaxDias = LogMaxDias
        LogAdd("Inicio")

    End Sub

    Sub LogAdd(ByVal Evento As String)

        'Cria arquivos diarios de log em modo texto
        'dd/MM/yyyy HH:mm:ss - LogProg - Evento
        If LogDir = "" Then Return

        'Log_20070522.txt
        Dim FileName As String = LogDir & "\Log_" & Format(Now, "yyyyMMdd") & ".txt"
        Dim Txt As String = Format(Now, "dd/MM/yyyy HH:mm:ss") & " - " & LogProg & " - " & Evento

        Dim Arq As Integer = FreeFile()
        Try
            FileOpen(Arq, FileName, OpenMode.Append, OpenAccess.Write)
            PrintLine(Arq, Txt)
        Catch : End Try

        Try
            FileClose(Arq)
        Catch : End Try


        'Verifica se mudou o dia e apaga os arquivos antigos
        Dim Dia As Integer = Val(Format(Now, "dd"))
        If Dia <> DiaAnt Then
            ApagaAntigos()
            DiaAnt = Dia
        End If

    End Sub

    Sub ApagaAntigos()

        Dim MyFile As String = Dir(LogDir & "\Log_*.txt")
        Dim DataTmp As Date = DateAdd(DateInterval.Day, LogMaxDias * -1, Now.Date)
        Dim DataLim As Date = Format(DataTmp, "dd/MM/yyyy")

        Do While MyFile <> ""

            'Log_20070522.txt
            If MyFile.Length < 16 Then Continue Do
            If Left(MyFile, 4) <> "Log_" Then Continue Do
            If Right(MyFile, 4) <> ".txt" Then Continue Do

            Dim Ano As String = Mid(MyFile, 5, 4)
            Dim Mes As String = Mid(MyFile, 9, 2)
            Dim Dia As String = Mid(MyFile, 11, 2)
            Dim Data As Date

            Try
                Data = CDate(Dia & "/" & Mes & "/" & Ano)

                If Data < DataLim Then

                    Try
                        'Deleta o arquivo
                        Kill(LogDir & "\" & MyFile)
                    Catch : End Try
                End If

            Catch ex As Exception
                Continue Do
            End Try

            'Proximo
            MyFile = Dir()

        Loop

    End Sub

End Class
