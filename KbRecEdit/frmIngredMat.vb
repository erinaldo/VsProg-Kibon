Public Class frmIngredMat

    Dim Area As String = ""
    Dim RecNum As Integer = 0

    Sub Abre(Area As String, RecNum As Integer, PesoRef As Double)

        Me.Area = Area
        Me.RecNum = RecNum
        lblPesoRef.Text = PesoRef

        RefreshDados()
        ShowDialog()

    End Sub

    Sub RefreshDados()

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtIngred = (From It In DbRc.Ingred).ToList

        gvItens.Rows.Clear()

        Dim PesoTotalRef As Double = 0, PesoTotalPrc As Double = 0

        For Each Ri In Rc.dtRecIngredMat

            Dim IngrCodigo As String = Ri.IngrCodigo
            Dim MyIng = (From It In dtIngred Where It.Area = Area And It.IngrCodigo = IngrCodigo).ToList
            If MyIng.Count <= 0 Then Continue For

            Dim PesoRef As Double = Ri.Peso * Val(lblPesoRef.Text) / 100

            gvItens.Rows.Add(Ri.ItemSeq, IngrCodigo, MyIng.First.IngrNome, Format(Ri.Peso, "0.000"), Format(PesoRef, "0.000"))

            PesoTotalPrc = PesoTotalPrc + Ri.Peso
            PesoTotalRef = PesoTotalRef + PesoRef

        Next

        txtTotalPrc.Text = Format(PesoTotalPrc, "0.000")
        txtTotalRef.Text = Format(PesoTotalRef, "0.000")

    End Sub

    Private Sub butSair_Click(sender As System.Object, e As System.EventArgs) Handles butSair.Click
        Close()
    End Sub

    Private Sub butNovo_Click(sender As System.Object, e As System.EventArgs) Handles butNovo.Click

        frmSelIngred.Abre(Area)
        If frmSelIngred.SelIngrCodigo = "" Then Return

        Dim dtIngrMat = (From It In Rc.dtRecIngredMat Order By It.ItemSeq Descending).Take(1).ToList
        Dim NwItemSeq As Integer = 1
        If dtIngrMat.Count > 0 Then NwItemSeq = dtIngrMat.First.ItemSeq + 1

        Dim NwRim As New Geral.nsReceitas.RecIngredMat With {.Area = Area, .RecNum = RecNum, .ItemSeq = NwItemSeq,
                                                         .IngrCodigo = frmSelIngred.SelIngrCodigo, .Peso = 0}

        Rc.dtRecIngredMat.Add(NwRim)

        RefreshDados()

    End Sub

    Private Sub butEditar_Click(sender As System.Object, e As System.EventArgs) Handles butEditar.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim ItemSeq As Integer = gvItens.SelectedRows(0).Cells(0).Value
        Dim PesoPrc As Double = gvItens.SelectedRows(0).Cells(3).Value

        frmIngredEdit.Abrir(lblPesoRef.Text, PesoPrc)
        If frmIngredEdit.SelPesoPrc < 0 Then Return

        Dim dtIngrMat = (From It In Rc.dtRecIngredMat Where It.ItemSeq = ItemSeq).ToList
        If dtIngrMat.Count <= 0 Then Return

        dtIngrMat.First.Peso = frmIngredEdit.SelPesoPrc

        RefreshDados()

    End Sub

    Private Sub butApagar_Click(sender As System.Object, e As System.EventArgs) Handles butApagar.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        Dim Ret As MsgBoxResult = MsgBox("Atenção!. O item selecionado será deletado. Confirma?", MsgBoxStyle.OkCancel, "Deletar item.")
        If Ret = MsgBoxResult.Cancel Then Return

        Dim ItemSeq As Integer = gvItens.SelectedRows(0).Cells(0).Value

        Dim dtIngrMat = (From It In Rc.dtRecIngredMat Where It.Area = Area And It.RecNum = RecNum And It.ItemSeq = ItemSeq).ToList
        If dtIngrMat.Count <= 0 Then Return

        Rc.dtRecIngredMat.Remove(dtIngrMat.First)

        RefreshDados()

    End Sub

    Private Sub gvItens_DoubleClick(sender As System.Object, e As System.EventArgs) Handles gvItens.DoubleClick
        butEditar_Click(sender, e)
    End Sub

End Class