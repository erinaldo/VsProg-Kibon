Public Class frmCadAlerg

    Sub Abre()

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        'Guarda posição selecionada inicialmente
        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim CodSel As String = 0
        If gvItens.SelectedRows.Count > 0 Then CodSel = gvItens.SelectedRows(0).Cells(0).Value


        Dim DbAlerg = New Geral.nsReceitas.dcReceitas
        Dim dtIngredAllergy = (From It In DbAlerg.Alergenico Order By It.Letra).ToList

        Dim Pos As Integer = 0
        gvItens.Rows.Clear()

        For Each IAllergy In dtIngredAllergy

            gvItens.Rows.Add(IAllergy.CodAlergenico, IAllergy.Nome, IAllergy.Letra)

            'Procura a linha selecionada
            If IAllergy.CodAlergenico = CodSel Then RowSel = Pos
            Pos = Pos + 1

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

    Private Sub butNovo_Click(sender As Object, e As EventArgs) Handles butNovo.Click

        frmCadAlergEdit.Abre()
        RefreshDados()

    End Sub

    Private Sub butEditar_Click(sender As Object, e As EventArgs) Handles butEditar.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        frmCadAlergEdit.Abre(gvItens.SelectedRows(0).Cells(0).Value)

        RefreshDados()

    End Sub

    Private Sub butApagar_Click(sender As Object, e As EventArgs) Handles butApagar.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim AlergCodigo As String = gvItens.SelectedRows(0).Cells(0).Value

        Dim DbAlerg As New Geral.nsReceitas.dcReceitas

        Dim dtAlergRec = (From It In DbAlerg.AlergenicosRec Where It.CodAlergenico = AlergCodigo).ToList
        If dtAlergRec.Count > 0 Then
            MsgBox("Erro: Este Alergênico não pode ser excluído porque está em uso na receita [" & dtAlergRec.First.RecNum & "].")
            Return
        End If

        'Excluir
        Dim Ret As MsgBoxResult = MsgBox("Confirma exclusao o alergênico selecionado?", MsgBoxStyle.OkCancel)
        If Ret <> MsgBoxResult.Ok Then Return


        Dim dtAlergExcluir = (From It In DbAlerg.Alergenico Where It.CodAlergenico = AlergCodigo).ToList
        DbAlerg.Alergenico.DeleteAllOnSubmit(dtAlergExcluir)

        DbAlerg.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub butSair_Click(sender As Object, e As EventArgs) Handles butSair.Click

        Close()

    End Sub

End Class