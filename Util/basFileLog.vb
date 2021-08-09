
Imports System.IO       'Carrega tratamento de arquivos
Imports System.Text     'Tratamento de texto

Public Module basFileLog

    Public Sub GravaLog(ByVal Arquivo As String, ByVal Texto As String)

        Dim myPath As String = Util.UtAppPath
        Dim myData As String = Format(Now, "yyyyMMdd")
        Dim NomeArq As String = Path.Combine(myPath, Arquivo & "_" & myData & ".csv")

        Try
            If Not File.Exists(NomeArq) Then
                Using swArq As StreamWriter = File.CreateText(NomeArq)
                    Log(swArq, "Arquivo de LOG criado")
                    swArq.Close()
                End Using
            End If

            Using swArq As StreamWriter = File.AppendText(NomeArq)
                Log(swArq, Texto)
                ' Close the writer and underlying file.
                swArq.Close()
            End Using
        Catch : End Try

    End Sub

    Private Sub Log(ByVal twArq As TextWriter, ByVal logMessage As String)
        'twArq.Write(ControlChars.CrLf)
        Dim Data As String = Format(Now, "dd/MM/yyyy")
        Dim Hora As String = Format(Now, "HH:mm:ss:fff")
        twArq.WriteLine("{0},{1},{2}", Data, Hora, logMessage)
        ' Update the underlying file.
        twArq.Flush()
    End Sub

End Module
