Public Class frmCadPtoCr

    Sub Abre()

        RefreshDados()

        ShowDialog()

    End Sub

    Sub RefreshDados()

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCr = (From It In DbCv.CadPtoCr Order By It.PtoCrId).ToList

        gvCadPtoCr.Rows.Clear()

        For Conta As Integer = 0 To dtCadPtoCr.Count - 1

            With dtCadPtoCr(Conta)

                gvCadPtoCr.Rows.Add(.PtoCrId, .Pergunta)

            End With
        Next
    End Sub

    Private Sub btnSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Close()
    End Sub

    Private Sub btnNovaPergunta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNovaPergunta.Click

        Dim Ret As String = InputBox("Digite a pergunta.", "Novo Ponto Crítico", "")
        If Ret.Trim = "" Then Return

        Dim PtoCrLdNova As Integer = Geral.BuscaAnormIdNew

        Dim DbCv As New Geral.nsCipValid.dcCipValid

        Dim NwPc As New Geral.nsCipValid.CadPtoCr With {.PtoCrId = PtoCrLdNova, .Pergunta = Ret.Trim}
        DbCv.CadPtoCr.InsertOnSubmit(NwPc)

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub btnEdita_Click(sender As System.Object, e As System.EventArgs) Handles btnEdita.Click

        If gvCadPtoCr.SelectedRows.Count <= 0 Then Return
        Dim PtoCrld As Integer = gvCadPtoCr.SelectedRows(0).Cells(0).Value
        Dim Pergunta As String = gvCadPtoCr.SelectedRows(0).Cells(1).Value

        Dim Ret As String = InputBox("Digite a pergunta.", "Novo Ponto Crítico", Pergunta)
        If Ret.Trim = "" Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCr = (From It In DbCv.CadPtoCr Where It.PtoCrId = PtoCrld).ToList

        dtCadPtoCr.First.Pergunta = Ret

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub btnDeleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleta.Click

        If gvCadPtoCr.SelectedRows.Count <= 0 Then Return
        Dim PtoCrld As Integer = gvCadPtoCr.SelectedRows(0).Cells(0).Value

        Dim Ret As MsgBoxResult = MsgBox("A Pergunta selecionada será excluida. Confirma?", MsgBoxStyle.OkCancel)
        If Ret = MsgBoxResult.Cancel Then Return

        'Apaga este cadastro
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadPtoCr = (From It In DbCv.CadPtoCr Where It.PtoCrId = PtoCrld).ToList
        DbCv.CadPtoCr.DeleteAllOnSubmit(dtCadPtoCr)

        Dim dtCadRotaPtoCr = (From It In DbCv.CadRotaPtoCr Where It.PtoCrId = PtoCrld).ToList
        DbCv.CadRotaPtoCr.DeleteAllOnSubmit(dtCadRotaPtoCr)

        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

End Class