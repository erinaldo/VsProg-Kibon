Public Class frmSelIngred

    Public Area As String
    Public SelIngrCodigo As String = ""
    Public SelIngrNome As String = ""

    Public Sub Abre(ByVal Area As String)

        Me.Area = Area
        SelIngrCodigo = ""
        SelIngrNome = ""

        RefreshDados()

        ShowDialog()

    End Sub

    Sub RefreshDados()

        Dim DbRc As New Geral.nsReceitas.dcReceitas

        Dim dtIngred = (From It In DbRc.Ingred Where It.Area = Area Order By It.IngrNome).ToList

        gvItens.Rows.Clear()

        For Each Ingr In dtIngred

            If Ingr.IngrCodigo.ToUpper.Contains(txtFiltro.Text.ToUpper) = False And
               Ingr.IngrNome.ToUpper.Contains(txtFiltro.Text.ToUpper) = False Then
                Continue For
            End If

            gvItens.Rows.Add(Ingr.IngrCodigo, Ingr.IngrNome)

        Next

    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click

        Me.Close()

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        SelIngrCodigo = gvItens.SelectedRows(0).Cells(0).Value
        SelIngrNome = gvItens.SelectedRows(0).Cells(1).Value

        FlagDadosEdit = True
        Me.Close()

    End Sub

    Private Sub dgBlocos_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvItens.DoubleClick
        butOk_Click(sender, e)
    End Sub

    Private Sub txtFiltro_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFiltro.KeyUp

        RefreshDados()

    End Sub
End Class