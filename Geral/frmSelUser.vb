Public Class frmSelUser

    Public SelUserId As String
    Public SelUserNome As String

    Dim dtCadUser As List(Of nsCipValid.CadUser)

    Sub Abre()

        SelUserId = ""
        SelUserNome = ""

        Dim DbCv As New nsCipValid.dcCipValid

        dtCadUser = (From It In DbCv.CadUser).ToList
        ShowDialog()

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If gvItens.SelectedRows.Count <= 0 Then Return
        SelUserId = gvItens.SelectedRows(0).Cells(0).Value
        SelUserNome = gvItens.SelectedRows(0).Cells(1).Value

        Close()

    End Sub

    Private Sub gvItens_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvItens.DoubleClick
        butOk_Click(sender, e)
    End Sub

End Class