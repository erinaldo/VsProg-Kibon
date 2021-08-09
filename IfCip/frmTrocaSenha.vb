Public Class frmTrocaSenha

    Public UserId As Integer

    Sub Abre(ByVal CodUser As Integer)

        txtSenhaAtual.Text = ""
        txtSenha.Text = ""
        txtSenhaConf.Text = ""
        UserId = CodUser

        ShowDialog()

    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click
        Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        If txtSenhaAtual.Text = "" Then
            MsgBox("Erro: digite a sua senha atual.", MsgBoxStyle.Critical)
            Return
        End If

        If txtSenha.Text = "" Then
            MsgBox("Erro: a senha não pode ser nula.", MsgBoxStyle.Critical)
            Return
        End If

        If txtSenha.Text.ToUpper <> txtSenhaConf.Text.ToUpper Then
            MsgBox("Erro: confira a redigitação da senha.", MsgBoxStyle.Critical)
            Return
        End If

        Dim HashSenhaAtual As String = Util.CalcHashHex(txtSenhaAtual.Text.ToUpper, Util.EncMode.UTF8, Util.HashMode.MD5)
        Dim HashSenhaNova As String = Util.CalcHashHex(txtSenha.Text.ToUpper, Util.EncMode.UTF8, Util.HashMode.MD5)

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadUser = (From It In DbCv.CadUser Where It.UserId = UserId).ToList
        If dtCadUser.Count <= 0 Then Return

        If dtCadUser(0).Senha.Trim.ToUpper <> HashSenhaAtual.ToUpper Then
            MsgBox("ERRO: a senha atual não confere com a senha registrada para este usuário.", _
                    MsgBoxStyle.Critical)
            Return
        End If

        dtCadUser(0).Senha = HashSenhaNova.ToUpper
        DbCv.SubmitChanges()
 
        MsgBox("Senha alterada com sucesso!", MsgBoxStyle.Exclamation)

        Close()

    End Sub

End Class