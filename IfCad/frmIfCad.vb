Public Class frmIfCad

    Private Sub UserLogin(ByVal UserId As Integer)

        Dim Nome As String = Geral.BuscaUserLogin(UserId)

        'Login
        lblUser.Tag = UserId
        lblUser.Text = Nome
        btnLogin.Text = "Logout"
        menuLogin.Text = "Logout"

        If Geral.ChkUserSeg(UserId, "Superv") = True Then


            btnCadRotas.Enabled = True
            menuRotas.Enabled = True

            btnCadCfg.Enabled = True
            menuCadCfg.Enabled = True

            btnCadPtoCr.Enabled = True
            menuCadPerg.Enabled = True

            btnCadUser.Enabled = True
            menuCadUser.Enabled = True

            btnCadUserSeg.Enabled = True
            menuCadUserSeg.Enabled = True

            btnCadRotasPtCritico.Enabled = True

        End If

    End Sub

    Private Sub UserLogout(Optional ByVal DesligaProg As Boolean = False)

        'Logout
        lblUser.Tag = ""
        lblUser.Text = ""

        btnLogin.Text = "Login"
        menuLogin.Text = "Login"

        btnCadRotas.Enabled = False
        menuRotas.Enabled = False

        btnCadCfg.Enabled = False
        menuCadCfg.Enabled = False

        btnCadPtoCr.Enabled = False
        menuCadPerg.Enabled = False

        btnCadUser.Enabled = False
        menuCadUser.Enabled = False

        btnCadUserSeg.Enabled = False
        menuCadUserSeg.Enabled = False

        btnCadRotasPtCritico.Enabled = False

    End Sub



#Region "Botoes"

    Private Sub butSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub butLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        If btnLogin.Text = "Logout" Then
            UserLogout(True)
            Return
        End If

        Dim MyLogin As New Geral.frmLogin
        MyLogin.Abre()

        If MyLogin.SelUsrId > 0 Then
            UserLogin(MyLogin.SelUsrId)
        End If

    End Sub

    Private Sub butCadCfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmCadCfg.MdiParent = Me
        frmCadCfg.Show()
        frmCadCfg.Activate()

    End Sub

    Private Sub butCadPtoCr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCadPtoCr.MdiParent = Me
        frmCadPtoCr.Show()
        frmCadPtoCr.Activate()
    End Sub

    Private Sub butCadUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCadUser.MdiParent = Me
        frmCadUser.Show()
        frmCadUser.Activate()
    End Sub

    Private Sub butCadUserSeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCadUserSeg.MdiParent = Me
        frmCadUserSeg.Show()
        frmCadUserSeg.Activate()
    End Sub

    Private Sub butCadUserHab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCadUserHab.MdiParent = Me
        frmCadUserHab.Show()
        frmCadUserHab.Activate()
    End Sub

    Private Sub butCadRotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadRotas.Click

        Dim Cmd As String = Util.UtAppPath & "\..\Bin\KbCipRotas.exe"

        Try
            Call Shell(Cmd, AppWinStyle.NormalFocus, True)
        Catch : End Try

    End Sub

#End Region

#Region "Menu"

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuLogin.Click
        butLogin_Click(sender, e)
    End Sub

    Private Sub mnuCadRotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRotas.Click
        butCadRotas_Click(sender, e)
    End Sub

    Private Sub menuCadPtoCr_Click(sender As System.Object, e As System.EventArgs) Handles menuCadPtoCr.Click
        btnCadRotasPtCritico_Click(sender, e)
    End Sub

    Private Sub mnuCadCfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCadCfg.Click
        butCadCfg_Click(sender, e)
    End Sub

    Private Sub mnuCadPtoCr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCadPerg.Click
        butCadPtoCr_Click(sender, e)
    End Sub

    Private Sub mnuCadUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCadUser.Click
        butCadUser_Click(sender, e)
    End Sub

    Private Sub mnuCadUserSeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCadUserSeg.Click
        butCadUserSeg_Click(sender, e)
    End Sub

    Private Sub mnuCadUserHab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        butCadUserHab_Click(sender, e)
    End Sub

#End Region

    Private Sub btnCadCfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadCfg.Click
        frmCadCfg.MdiParent = Me
        frmCadCfg.Show()
        frmCadCfg.Activate()
    End Sub

    Private Sub btnCadUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadUser.Click
        frmCadUser.MdiParent = Me
        frmCadUser.Show()
        frmCadUser.Activate()
    End Sub

    Private Sub btnCadUserSeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadUserSeg.Click
        frmCadUserSeg.MdiParent = Me
        frmCadUserSeg.Show()
        frmCadUserSeg.Activate()
    End Sub

    Private Sub btnCadPtoCr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadPtoCr.Click
        frmCadPtoCr.MdiParent = Me
        frmCadPtoCr.Show()
        frmCadPtoCr.Activate()
    End Sub

    Private Sub btnCadRotasPtCritico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadRotasPtCritico.Click

        frmCadProduto.MdiParent = Me
        frmCadProduto.Show()
        frmCadProduto.Activate()

    End Sub

    Private Sub frmIfCad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Verifica se a data das configurações regionais está configurada como d/M/yyyy
        Dim RetDataConf As Boolean = Util.ChkDataConfReg(Me.Text)
        If RetDataConf = False Then End

        Geral.DllInit()

        If Command() <> "" Then
            UserLogin(Command)
        End If

        UserLogout()
    End Sub

End Class


