Public Class frmCadIngred

    Dim Area As String = ""

    Sub Abre(Area As String)

        Me.Area = Area

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        'Guarda posição selecionada inicialmente
        Dim RowTop As Integer = gvItens.FirstDisplayedScrollingRowIndex
        Dim RowSel As Integer = -1
        Dim CodSel As String = 0
        If gvItens.SelectedRows.Count > 0 Then CodSel = gvItens.SelectedRows(0).Cells(0).Value


        Dim DbRc = New Geral.nsReceitas.dcReceitas
        Dim dtIngred = (From It In DbRc.Ingred Where It.Area = Area Order By It.IngrCodigo).ToList

        Dim Pos As Integer = 0
        gvItens.Rows.Clear()

        For Each Ingr In dtIngred

            gvItens.Rows.Add(Ingr.IngrCodigo, Ingr.IngrNome)

            'Procura a linha selecionada
            If Ingr.IngrCodigo = CodSel Then RowSel = Pos
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

    Private Sub butSair_Click(sender As System.Object, e As System.EventArgs) Handles butSair.Click

        Close()

    End Sub

    Private Sub butNovo_Click(sender As System.Object, e As System.EventArgs) Handles butNovo.Click

        frmCadIngrEdita.Abre(Area, "")

        RefreshDados()

    End Sub

    Private Sub butEditar_Click(sender As System.Object, e As System.EventArgs) Handles butEditar.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        frmCadIngrEdita.Abre(Area, gvItens.SelectedRows(0).Cells(0).Value)

        RefreshDados()

    End Sub

    Private Sub butApagar_Click(sender As System.Object, e As System.EventArgs) Handles butApagar.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim IngrCodigo As String = gvItens.SelectedRows(0).Cells(0).Value

        Dim DbRc As New Geral.nsReceitas.dcReceitas

        Dim dtRecIngred = (From It In DbRc.RecIngred Where It.Area = Area And It.IngrCodigo = IngrCodigo).ToList
        If dtRecIngred.Count > 0 Then
            MsgBox("Erro: este ingrediente não pode ser excluído porque está em uso na receita [" & dtRecIngred.First.RecNum & "].")
            Return
        End If

        Dim dtRecIngredMat = (From It In DbRc.RecIngredMat Where It.Area = Area And It.IngrCodigo = IngrCodigo).ToList
        If dtRecIngredMat.Count > 0 Then
            MsgBox("Erro: este ingrediente não pode ser excluído porque está em uso na receita [" & dtRecIngredMat.First.RecNum & "].")
            Return
        End If


        'Excluir
        Dim Ret As MsgBoxResult = MsgBox("Confirma exclusao do item selecionado?", MsgBoxStyle.OkCancel)
        If Ret <> MsgBoxResult.Ok Then Return


        Dim dtProp = (From It In DbRc.Ingred Where It.Area = Area And It.IngrCodigo = IngrCodigo).ToList
        DbRc.Ingred.DeleteAllOnSubmit(dtProp)

        DbRc.SubmitChanges()

        RefreshDados()

    End Sub

    Private Sub gvItens_DoubleClick(sender As System.Object, e As System.EventArgs) Handles gvItens.DoubleClick
        butEditar_Click(sender, e)
    End Sub
End Class