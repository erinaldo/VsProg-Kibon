Public Class frmLogin

    Public SelUsrId As Integer
    Public SelUsrNome As String

    Public Sub Abre()

        SelUsrId = 0
        SelUsrNome = ""

        txtNome.Text = ""
        txtSenha.Text = ""

        txtNome.Focus()
        ShowDialog()

    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        'Busca usuario na lista
        Dim DbCv As New nsCipValid.dcCipValid

        Dim SenhaHash As String = Util.CalcHashHex(txtSenha.Text.ToUpper, Util.EncMode.UTF8, Util.HashMode.MD5)

        Dim SuperAdmin As Boolean = VerSuperAdmin(txtNome.Text.ToUpper, SenhaHash)

        If SuperAdmin = False Then
            Dim dtCadUsuario = (From It In DbCv.CadUser Where It.Login = txtNome.Text.ToUpper And It.Senha = SenhaHash).ToList

            If dtCadUsuario.Count <= 0 Then
                MsgBox("Login: usuário não cadastrado ou senha errada.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            SelUsrId = dtCadUsuario(0).USERID
            SelUsrNome = dtCadUsuario(0).NOME
        Else
            SelUsrId = 9999
            SelUsrNome = txtNome.Text.ToUpper
        End If
        Close()

    End Sub

    Private Function VerSuperAdmin(ByVal Nome As String, ByVal Senha As String) As Boolean
        'Senha=MARATASUPERADMIN
        If Nome = "SUPERADMIN" And Senha = "516A52E59206F93640820B86E63C4E55" Then
            Return True
        Else
            Return False
        End If

    End Function
End Class