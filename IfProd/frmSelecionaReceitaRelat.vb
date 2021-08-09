Public Class frmSelecionaReceitaRelat

    Dim RecNum As Integer
    Dim TamanhoBatch As String
    Dim DestTq As String


    Sub Abre()
        'Sub Abre(RecNum As Integer, TamanhoBatch As String, DestTq As String)
        'Me.RecNum = RecNum
        'Me.TamanhoBatch = TamanhoBatch
        'Me.DestTq = DestTq

        'RefreshDados()
        ShowDialog()

    End Sub


    Private Sub btnImprimirRelatorio_Click(sender As Object, e As EventArgs) Handles btnImprimirRelatorio.Click


        'Dim Cmd As String = """" & Util.UtAppPath & "\..\KbImprimeReceitaPreench\bin\Debug\KbImprimeReceitaPreench.exe"" " &
        '            RecNum & " " &
        '            TamanhoBatch & " " &
        '            DestTq & " " &
        '            tbIdBatch.Text




        Dim Rc As New Geral.nsReceitas.dcReceitas

        'Dim vBatches = (From it In Rc.tb_CBT_CadastroBatch Where it.CBT_IDBatch = tbIdBatch.Text Order By it.CBT_Tanque).FirstOrDefault
        Dim vBatches = (From it In Rc.tb_CPI_CadastroPequenoIngrediente Where it.CPI_IDBlend = tbIdBatch.Text Order By it.CPI_Tanque).FirstOrDefault

        If IsNothing(vBatches) Then
            tbIdBatch.Text = ""
            MsgBox("Número de BatchId inválido. Por favor digite novamente.")
            Me.Close()

            Exit Sub

        End If

        Dim tanquesDoBatch = (From it In Rc.tb_CPI_CadastroPequenoIngrediente Where it.CPI_IDBlend = tbIdBatch.Text Select it.CPI_Tanque).ToList().Distinct()

        Dim volumeBatchTotal = 0

        For Each tanque In tanquesDoBatch
            Dim tamanhoBatchDesseTanque = (From it In Rc.tb_CPI_CadastroPequenoIngrediente Where it.CPI_IDBlend = tbIdBatch.Text And it.CPI_Tanque = tanque Select it.CPI_VolumeBatch).FirstOrDefault()
            volumeBatchTotal = volumeBatchTotal + tamanhoBatchDesseTanque
        Next



        'Dim vTamanhoBatch = ((From it In Rc.tb_CBT_CadastroBatch Where it.CBT_IDBatch = tbIdBatch.Text Select it.CBT_VolumeBatch).Sum) * 1000
        Dim vTamanhoBatch = volumeBatchTotal * 1000


        'Dim Cmd As String = """" & Util.UtAppPath & "\..\Bin\KbImprimeReceitaPreench.exe"" " &
        '            vBatches.RecNum & " " &
        '            vTamanhoBatch & " " &
        '            vBatches.CBT_Tanque & " " &
        '            tbIdBatch.Text

        Dim Cmd As String = """" & Util.UtAppPath & "\..\Bin\KbImprimeReceitaPreench.exe"" " &
                    vBatches.RecNum & " " &
                    vTamanhoBatch & " " &
                    vBatches.CPI_Tanque & " " &
                    tbIdBatch.Text

        Try
            Shell(Cmd)
        Catch : End Try

        Me.Close()

    End Sub
End Class