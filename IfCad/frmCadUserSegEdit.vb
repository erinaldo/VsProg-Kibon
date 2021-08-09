Public Class frmCadUserSegEdit

    Public SelNome As String
    Public SelDescr As String

    Sub Abre(ByVal SegId As String, Optional ByVal Nome As String = "", Optional ByVal Descr As String = "")

        txtSegId.Text = SegId
        txtNome.Text = Nome
        txtDescr.Text = Descr

        SelNome = ""
        SelDescr = ""

        ShowDialog()

    End Sub

    Private Sub frmCadUserEdit_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNome.Focus()
    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If txtNome.Text = "" Then
            MsgBox("Erro: o Nome não pode ser nulo.", MsgBoxStyle.Critical)
            Return
        End If

        SelNome = txtNome.Text
        SelDescr = txtDescr.Text
        Close()

    End Sub

End Class