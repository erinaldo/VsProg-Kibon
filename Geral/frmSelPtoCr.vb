Public Class frmSelPtoCr

    Public SelPtoCrId As Integer
    Public SelPtoCrIdPergunta As String

    Sub Abre()

        SelPtoCrId = 0
        SelPtoCrIdPergunta = ""

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        Dim Cv As New nsCipValid.dcCipValid

        Dim dtCadPtoCr = (From It In Cv.CadPtoCr Order By It.PtoCrId).ToList

        gvItens.Rows.Clear()
        For Each It In dtCadPtoCr

            gvItens.Rows.Add(It.PtoCrId, It.Pergunta)

        Next

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        SelPtoCrId = CInt(gvItens.SelectedRows(0).Cells(0).Value)
        SelPtoCrIdPergunta = CStr(gvItens.SelectedRows(0).Cells(1).Value)

        Close()

    End Sub

    Private Sub gvItens_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvItens.DoubleClick
        butOk_Click(sender, e)
    End Sub

End Class