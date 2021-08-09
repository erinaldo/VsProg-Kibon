Public Class frmIngredEdit

    Public SelPesoPrc As Double = -1

    Sub Abrir(PesoRef As Double, PesoPrc As Double)

        SelPesoPrc = -1

        txtPesoRef.Text = Format(PesoRef, "0.000")
        txtPesoPrc.Text = Format(PesoPrc, "0.000")

        CalcKg()

        ShowDialog()

    End Sub

    Sub CalcKg()

        txtPesoKg.Text = Format(txtPesoPrc.Text * txtPesoRef.Text / 100.0)

    End Sub

    Sub CalcPrc()

        txtPesoPrc.Text = Format(txtPesoKg.Text / txtPesoRef.Text * 100.0)

    End Sub

    Private Sub txtPesoKg_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPesoKg.KeyUp
        CalcPrc()
    End Sub

    Private Sub txtPesoPrc_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPesoPrc.KeyUp
        CalcKg()
    End Sub

    Private Sub butOk_Click(sender As System.Object, e As System.EventArgs) Handles butOk.Click

        SelPesoPrc = txtPesoPrc.Text

    End Sub

    Private Sub butCancela_Click(sender As System.Object, e As System.EventArgs) Handles butCancela.Click
        Close()
    End Sub
End Class