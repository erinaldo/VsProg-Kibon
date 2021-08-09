Public Class frmCadUserHab

    Sub Abre(ByVal UserId As Integer, ByVal Nome As String)

        txtUserId.Text = UserId
        txtNome.Text = Nome

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        lbHab.Items.Clear()
        lbHabDisp.Items.Clear()

        For Conta As Integer = 0 To frmCadUser.dtCadUserSeg.Count - 1

            Dim ContaUser As Integer = Conta
            ' Dim Cmd As String = "SegId = " & frmCadUser.dtCadUserSeg(Conta).SegId

            Dim MyRows = From It In frmCadUser.dtCadUserHab Where It.UserId = txtUserId.Text And
            It.SegId = frmCadUser.dtCadUserSeg(ContaUser).SegId

            If MyRows.Count > 0 Then
                lbHab.Items.Add(frmCadUser.dtCadUserSeg(Conta).Nome)
            Else
                lbHabDisp.Items.Add(frmCadUser.dtCadUserSeg(Conta).Nome)
            End If

        Next

    End Sub

    Private Sub butHabAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butHabAdd.Click

        If lbHabDisp.SelectedItems.Count <= 0 Then Return

        Dim MySegRows = (From It In frmCadUser.dtCadUserSeg Where It.Nome = lbHabDisp.SelectedItems(0)).ToList
        If MySegRows.Count <= 0 Then Return
        Dim SegId As Integer = MySegRows(0).Segid

        'cria novo data table  para receber o novo registro inserido
        Dim CadUserHabNew As New List(Of Geral.nsCipValid.CadUserHab)
        CadUserHabNew.Add(New Geral.nsCipValid.CadUserHab With {.UserId = txtUserId.Text, .SegId = SegId})

        'insere o novo registro na tabela
        frmCadUser.Bp.CadUserHab.InsertAllOnSubmit(CadUserHabNew)

        'adiciona o novo registo ao data table geral, para visualizar o novo registro no refresh dados
        frmCadUser.dtCadUserHab = frmCadUser.dtCadUserHab.Union(CadUserHabNew).ToList

        frmCadUser.FlagDadosEdit = True
        RefreshDados()

    End Sub

    Private Sub butHabRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butHabRem.Click

        If lbHab.SelectedItems.Count <= 0 Then Return


        Dim MySegRows = (From It In frmCadUser.dtCadUserSeg Where It.Nome = lbHab.SelectedItems(0)).ToList
        If MySegRows.Count <= 0 Then Return
        Dim SegId As Integer = MySegRows(0).Segid

        Dim MyHabRows = (From It In frmCadUser.dtCadUserHab Where It.UserId = txtUserId.Text And It.SegId = SegId).ToList

        frmCadUser.Bp.CadUserHab.DeleteAllOnSubmit(MyHabRows)

        'remove o registro deletado do data table 
        frmCadUser.dtCadUserHab.Remove(MyHabRows(0))

        frmCadUser.FlagDadosEdit = True
        RefreshDados()

    End Sub

    Private Sub lbHabDisp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbHabDisp.DoubleClick
        butHabAdd_Click(sender, e)
    End Sub

    Private Sub lbHab_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbHab.DoubleClick
        butHabRem_Click(sender, e)
    End Sub

End Class