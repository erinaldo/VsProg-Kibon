Public Class frmSelecionaReceitaRelat

    Dim RecNum As Integer
    Dim TamanhoBatch As String
    Dim DestTq As String

    Sub Abre(RecNum As Integer, TamanhoBatch As String, DestTq As String)

        Me.RecNum = RecNum
        Me.TamanhoBatch = TamanhoBatch
        Me.DestTq = DestTq

        'RefreshDados()
        ShowDialog()

    End Sub


    Private Sub btnImprimirRelatorio_Click(sender As Object, e As EventArgs) Handles btnImprimirRelatorio.Click


        'Dim Cmd As String = """" & Util.UtAppPath & "\..\KbImprimeReceitaPreench\bin\Debug\KbImprimeReceitaPreench.exe"" " &
        '            RecNum & " " &
        '            TamanhoBatch & " " &
        '            DestTq & " " &
        '            tbIdBatch.Text




        Dim Cmd As String = """" & Util.UtAppPath & "\..\Bin\KbImprimeReceitaPreench.exe"" " &
                    RecNum & " " &
                    TamanhoBatch & " " &
                    DestTq & " " &
                    tbIdBatch.Text
        Try
            Shell(Cmd)
        Catch : End Try

    End Sub
End Class