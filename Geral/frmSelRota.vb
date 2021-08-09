Public Class frmSelRota

    Public SelOk As Boolean
    Public SelRotaId As Integer

    Dim dtCadRotas As List(Of nsCipRotas.RotaCad)

    Public Sub Abre(Optional Circ As String = "")

        SelOk = 0

        Dim DbCr As New nsCipRotas.dcCipRotas
        dtCadRotas = (From It In DbCr.RotaCad).ToList

        RefreshDados()
        cmbCircuito.Text = Circ

        ShowDialog()

    End Sub

    Private Sub RefreshDados()

        gvItens.Rows.Clear()

        For Conta As Integer = 0 To dtCadRotas.Count - 1
            With dtCadRotas(Conta)

                If cmbCircuito.Text <> "" And cmbCircuito.Text <> "*" Then

                    If .Circ <> cmbCircuito.Text Then
                        Continue For
                    End If

                End If

                If .Descr.ToUpper.Contains(txtFiltro.Text.ToUpper) = False Then
                    Continue For
                End If

                If .RotaId < 1000 Then
                    Continue For
                End If



                gvItens.Rows.Add(.RotaId, .Descr, .Circ, .Tipo, .Tq1, .Tq2, .Tq3)

            End With
        Next

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If gvItens.SelectedRows.Count <= 0 Then Return

        SelOk = True
        SelRotaId = gvItens.SelectedRows(0).Cells(0).Value

        Close()

    End Sub

    Private Sub gvItens_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        butOk_Click(sender, e)
    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click
        Close()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        RefreshDados()
    End Sub

    Private Sub cmbCircuito_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCircuito.SelectedIndexChanged
        RefreshDados()
    End Sub

    Private Sub gvItens_DoubleClick1(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvItens.DoubleClick
        butOk_Click(sender, e)
    End Sub
End Class