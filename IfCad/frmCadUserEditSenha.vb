Public Class frmCadUserEditSenha

    Public SelSenha As String

    Sub Abre()

        txtSenha.Text = ""
        txtSenhaConf.Text = ""
        SelSenha = ""

        ShowDialog()

    End Sub

    Private Sub frmCadUserEditSenha_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        txtSenha.Focus()
    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click
        Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If txtSenha.Text = "" Then
            MsgBox("Erro: a senha não pode ser nula.", MsgBoxStyle.Critical)
            Return
        End If

        If txtSenha.Text.ToUpper <> txtSenhaConf.Text.ToUpper Then
            MsgBox("Erro: confira a redigitação da senha.", MsgBoxStyle.Critical)
            Return
        End If

        SelSenha = Util.CalcHashHex(txtSenha.Text.ToUpper, Util.EncMode.UTF8, Util.HashMode.MD5)
        Close()

    End Sub

End Class