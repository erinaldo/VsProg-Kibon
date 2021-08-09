Public Class frmCadRotasPtoCr

    Dim dtCadPtoCr As List(Of Geral.nsCipValid.CadPtoCr)

    Sub Abre(ByVal RotaId As Integer, ByVal Descr As String)

        txtRotaId.Text = RotaId
        txtDescr.Text = Descr

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        dtCadPtoCr = (From It In DbCv.CadPtoCr).ToList

        RefreshDisp()
        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDisp()

        gvCadPtoCr.Rows.Clear()

        For Each Cpc In dtCadPtoCr

            gvCadPtoCr.Rows.Add(Cpc.PtoCrId, Cpc.Pergunta)

        Next

    End Sub

    Sub RefreshDados()

        gvCadRotasPtoCr.Rows.Clear()

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotaPtoCr = (From It In DbCv.CadRotaPtoCr Where It.RotaId = txtRotaId.Text Order By It.Seq).ToList

        For Each Crpc In dtCadRotaPtoCr

            Dim Pergunta As String = ""
            Dim PtoCrId As Integer = Crpc.PtoCrId
            Dim MyPc = (From It In dtCadPtoCr Where It.PtoCrId = PtoCrId).ToList
            If MyPc.Count > 0 Then Pergunta = MyPc.First.Pergunta

            gvCadRotasPtoCr.Rows.Add(Crpc.Seq, Crpc.PtoCrId, Pergunta)
 
        Next

    End Sub

    Private Sub butInsere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butInsere.Click

        'PtoCrId a ser inserido
        If gvCadPtoCr.SelectedRows.Count <= 0 Then Return
        Dim PtoCrId As Integer = gvCadPtoCr.SelectedRows(0).Cells(0).Value


        'Seq nova
        Dim SeqNova As Integer = 1
        For Conta As Integer = 0 To gvCadRotasPtoCr.RowCount - 1
            If SeqNova <= gvCadRotasPtoCr.Rows(Conta).Cells(0).Value Then
                SeqNova = gvCadRotasPtoCr.Rows(Conta).Cells(0).Value + 1
            End If
        Next


        'Insere o item
        Dim DbCv As New Geral.nsCipValid.dcCipValid

        Dim NwCrpc As New Geral.nsCipValid.CadRotaPtoCr With {.RotaId = txtRotaId.Text,
                                                              .PtoCrId = PtoCrId, .Seq = SeqNova}
        DbCv.CadRotaPtoCr.InsertOnSubmit(NwCrpc)

        Try
            DbCv.SubmitChanges()
        Catch : End Try

        RefreshDados()

    End Sub

    Private Sub butExclui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExclui.Click

        'Remove o item da tabela de dados
        If gvCadRotasPtoCr.SelectedRows.Count <= 0 Then Return
        Dim PtoCrId As Integer = gvCadRotasPtoCr.SelectedRows(0).Cells(1).Value

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotaPtoCr = (From It In DbCv.CadRotaPtoCr Where It.RotaId = txtRotaId.Text And It.PtoCrId = PtoCrId).ToList
        If dtCadRotaPtoCr.Count <= 0 Then Return

        DbCv.CadRotaPtoCr.DeleteAllOnSubmit(dtCadRotaPtoCr)

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub gvCadPtoCr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        butInsere_Click(sender, e)
    End Sub

    Private Sub gvCadRotasPtoCr_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCadRotasPtoCr.DoubleClick
        butExclui_Click(sender, e)
    End Sub

    Private Sub butSair_Click(sender As System.Object, e As System.EventArgs) Handles butSair.Click
        Close()
    End Sub
End Class