Public Class frmCipSchedPerEdita

    Sub Abre(ByVal PerId As Integer)

        txtPerId.Text = PerId
    
        RefreshMes()
        RefreshSem()

        ShowDialog()

    End Sub

    Sub RefreshMes()

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPerMes = (From It In DbCv.CipSchedPerMes Where It.PerId = txtPerId.Text Order By It.DiaDoMes).ToList
 
        lbMes.Items.Clear()
        lbMesDisp.Items.Clear()

        For Conta As Integer = 1 To 31

            Dim Cn As Integer = Conta
            Dim MyRows = (From It In dtCipSchedPerMes Where It.DiaDoMes = Cn).ToList

            If MyRows.Count > 0 Then
                lbMes.Items.Add(Conta)
            Else
                lbMesDisp.Items.Add(Conta)
            End If

        Next

    End Sub

    Sub RefreshSem()

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPerSem = (From It In DbCv.CipSchedPerSem Where It.PerId = txtPerId.Text Order By It.DiaDaSemana).ToList

        lbSem.Items.Clear()
        lbSemDisp.Items.Clear()

        For Conta As Integer = 1 To 7

            Dim Cn As Integer = Conta
            Dim MyRows = (From It In dtCipSchedPerSem Where It.DiaDaSemana = Cn).ToList

            If MyRows.Count > 0 Then
                lbSem.Items.Add(Util.BuscaDiaSemTxt(Conta))
            Else
                lbSemDisp.Items.Add(Util.BuscaDiaSemTxt(Conta))
            End If

        Next

    End Sub

    Private Sub butMesAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMesAdd.Click

        If lbMesDisp.SelectedItems.Count <= 0 Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim NwCspm As New Geral.nsCipValid.CipSchedPerMes With {.PerId = txtPerId.Text, .DiaDoMes = lbMesDisp.SelectedItems(0)}
        DbCv.CipSchedPerMes.InsertOnSubmit(NwCspm)

        DbCv.SubmitChanges()

        RefreshMes()

    End Sub

    Private Sub butMesRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMesRem.Click

        If lbMes.SelectedItems.Count <= 0 Then Return

        Dim DiaMes As Integer = lbMes.SelectedItems(0)
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPerMes = (From It In DbCv.CipSchedPerMes Where It.PerId = txtPerId.Text And It.DiaDoMes = DiaMes).ToList

        DbCv.CipSchedPerMes.DeleteOnSubmit(dtCipSchedPerMes.First)
        DbCv.SubmitChanges()

        RefreshMes()

    End Sub

    Private Sub butSemAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSemAdd.Click

        If lbSemDisp.SelectedItems.Count <= 0 Then Return

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim NwCsps As New Geral.nsCipValid.CipSchedPerSem With {.PerId = txtPerId.Text,
                                                                .DiaDaSemana = Util.BuscaDiaSemId(lbSemDisp.SelectedItems(0))}
        DbCv.CipSchedPerSem.InsertOnSubmit(NwCsps)

        DbCv.SubmitChanges()

        RefreshSem()

    End Sub

    Private Sub butSemRem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSemRem.Click

        If lbSem.SelectedItems.Count <= 0 Then Return

        Dim DiaSem As Integer = Util.BuscaDiaSemId(lbSem.SelectedItems(0))
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipSchedPerSem = (From It In DbCv.CipSchedPerSem Where It.PerId = txtPerId.Text And It.DiaDaSemana = DiaSem).ToList

        DbCv.CipSchedPerSem.DeleteOnSubmit(dtCipSchedPerSem.First)
        DbCv.SubmitChanges()


        RefreshSem()

    End Sub

    Private Sub lbMesDisp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMesDisp.DoubleClick
        butMesAdd_Click(sender, e)
    End Sub

    Private Sub lbMes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMes.DoubleClick
        butMesRem_Click(sender, e)
    End Sub

    Private Sub lbSemDisp_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSemDisp.DoubleClick
        butSemAdd_Click(sender, e)
    End Sub

    Private Sub lbSem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSem.DoubleClick
        butSemRem_Click(sender, e)
    End Sub

End Class