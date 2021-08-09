Public Class frmCadUserEdit

    Public SelNome As String
    Public SelLogin As String

    Sub Abre(ByVal UserId As String, Optional ByVal Nome As String = "", Optional ByVal Login As String = "")

        txtUserId.Text = UserId
        txtNome.Text = Nome
        txtLogin.Text = Login

        SelNome = ""
        SelLogin = ""

        ShowDialog()

    End Sub

    Private Sub frmCadUserEdit_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNome.Focus()
    End Sub

    Private Sub btnCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancela.Click
        Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If txtNome.Text = "" Then
            MsgBox("Erro: o Nome não pode ser nulo.", MsgBoxStyle.Critical)
            Return
        End If

        If txtLogin.Text = "" Then
            MsgBox("Erro: o login não pode ser nulo.", MsgBoxStyle.Critical)
            Return
        End If

        SelNome = txtNome.Text
        SelLogin = txtLogin.Text.ToUpper
        Close()

    End Sub

End Class