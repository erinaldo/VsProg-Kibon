Public Class frmAnorm

    Public Sub Abre(ByVal CipId As Integer, ByVal RotaId As Integer, ByVal RecNum As Integer)

        txtCipId.Text = CipId
        txtRotaId.Text = RotaId
        txtRecNum.Text = RecNum

        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        Dim dtCadRotas = (From It In DbCr.RotaCad Where It.RotaId = RotaId).ToList

        If dtCadRotas.Count > 0 Then
            txtRotaDescr.Text = dtCadRotas(0).Descr
            txtRotaCirc.Text = dtCadRotas(0).Circ
        End If

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP" And It.RecNum = RecNum).ToList

        If dtCadRotas.Count > 0 Then
            txtRecNome.Text = dtRec(0).RecNome & " - " & dtRec(0).RecDescr
            txtRecCodigo.Text = dtRec(0).Codigo
        End If


        RefreshDados()
        txtObs.Text = ""

        ShowDialog()

    End Sub

    Sub RefreshDados()

        'Memoriza o item selecionado
        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim AnormIdSel As Integer = 0
        If gvItens.SelectedRows.Count > 0 Then AnormIdSel = gvItens.SelectedRows(0).Cells(0).Value

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHistAnorm = (From It In DbCv.CipHistAnorm Where It.CipId = txtCipId.Text And It.ObsSts <> 2 Order By It.AnormId).ToList

        gvItens.Rows.Clear()

        For Conta As Integer = 0 To dtCipHistAnorm.Count - 1
            With dtCipHistAnorm(Conta)

                Dim EvTxt As String = Geral.BuscaAnormEvento(dtCipHistAnorm(Conta).AnormEquip, dtCipHistAnorm(Conta).AnormEvnt)
                Dim ObsSts As String = Geral.BuscaAnormObsSts(dtCipHistAnorm(Conta).ObsSts)

                gvItens.Rows.Add(.AnormId, .DataHora, .BlkNum, .BlkPasso, EvTxt, ObsSts, Trim(.Obs))

                'Procura a linha selecionada
                If .AnormId = AnormIdSel Then RowSel = Conta

            End With
        Next

        Try
            If RowSel >= 0 Then
                'Vai para a linha selecionada
                gvItens.FirstDisplayedScrollingRowIndex = RowTop
                gvItens.CurrentCell = gvItens.Rows(RowSel).Cells(1)
            Else
                'Nenhuma linha selecionada vai para o fim
                gvItens.FirstDisplayedScrollingRowIndex = gvItens.Rows.Count - 1
                gvItens.CurrentCell = gvItens.Rows(gvItens.Rows.Count - 1).Cells(1)
            End If
        Catch : End Try

    End Sub

    Private Sub butCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFecha.Click
        Close()
    End Sub

    Private Sub gvItens_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvItens.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        txtObs.Text = gvItens.SelectedRows(0).Cells(5).Value

    End Sub

    Private Sub butObsAceita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butObsAceita.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim AnormId As Integer = gvItens.SelectedRows(0).Cells(0).Value
 
        Dim ObsSts As Boolean = False
        If Trim(txtObs.Text) <> "" Then ObsSts = 1

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHistAnorm = (From It In DbCv.CipHistAnorm Where It.CipId = txtCipId.Text And It.AnormId = AnormId).ToList

        If dtCipHistAnorm.Count > 0 Then
            dtCipHistAnorm.First.ObsSts = ObsSts
            dtCipHistAnorm.First.Obs = txtObs.Text
        End If
        DbCv.SubmitChanges()

        RefreshDados()

    End Sub

End Class