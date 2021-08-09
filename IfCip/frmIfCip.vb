Public Class frmIfCip

    Private Sub UserLogin(ByVal UserId As Integer)

        Dim Nome As String = Geral.BuscaUserLogin(UserId)

        'Login
        lblUser.Tag = UserId
        lblUser.Text = Nome

        butLogin.Text = "Logout"
        mnuLogin.Text = "Logout"

        If Geral.ChkUserSeg(UserId, "Opera") = True Then

            butCipProg.Enabled = True
            mnuCipProg.Enabled = True

            butCipCorr.Enabled = True
            mnuCipCorr.Enabled = True

            butCipFim.Enabled = True
            mnuCipFim.Enabled = True

            butSenha.Enabled = True
            mnuSenha.Enabled = True

            butRelat.Enabled = True
            mnuRelat.Enabled = True

        End If

        If Geral.ChkUserSeg(UserId, "Superv") = True Then

            butCipSchedPer.Enabled = True
            mnuCipSchedPer.Enabled = True

            butCadastro.Enabled = True
            mnuCadastro.Enabled = True

        End If

        butSenha.Enabled = True
        mnuSenha.Enabled = True

    End Sub

    Private Sub UserLogout()

        'Logout
        lblUser.Tag = "0"
        lblUser.Text = ""

        butLogin.Text = "Login"
        mnuLogin.Text = "Login"

        butCipProg.Enabled = False
        mnuCipProg.Enabled = False

        butCipCorr.Enabled = False
        mnuCipCorr.Enabled = False

        butCipFim.Enabled = False
        mnuCipFim.Enabled = False

        butCipSchedPer.Enabled = False
        mnuCipSchedPer.Enabled = False

        butCadastro.Enabled = False
        mnuCadastro.Enabled = False

        butSenha.Enabled = False
        mnuSenha.Enabled = False

        butRelat.Enabled = False
        mnuRelat.Enabled = False

        FechaJanelas()

    End Sub

    Private Sub FechaJanelas()

        'quio
        'fecha as janelas do sistema para garantir que a operacao seja feita somente quando logado
        frmAnorm.Close()
        frmCipFim.Close()
        frmCipCorr.Close()
        frmCipSchedPer.Close()
        frmCipSchedPerEdita.Close()
        frmCipSchedProg.Close()
        frmPtoCr.Close()
        frmTrocaSenha.Close()

    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Verifica se a data das configurações regionais está configurada como d/M/yyyy
        Dim RetDataConf As Boolean = Util.ChkDataConfReg(Me.Text)
        If RetDataConf = False Then End

        Geral.DllInit()

        UserLogout()

        If Command() <> "" Then
            UserLogin(Command)
        End If

        'Atualiza a programação do dia
        Geral.ChkSchedPer()

        lblPollSts.Text = ""
 
    End Sub

    Private Sub frmIfCip_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            'OpcGrupo = Nothing
            'OpcSrvPoll.Disconnect()
        Catch : End Try

    End Sub

    Private Sub butFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFechar.Click
        Close()
    End Sub

    Private Sub butCipProg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCipProg.Click

        FechaJanelas()

        frmCipSchedProg.MdiParent = Me
        frmCipSchedProg.Show()
        frmCipSchedProg.Activate()

    End Sub

    Private Sub butCipCorr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCipCorr.Click

        FechaJanelas()

        frmCipCorr.MdiParent = Me
        frmCipCorr.Activate()
        frmCipCorr.Show()

    End Sub

    Private Sub butCipFim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCipFim.Click

        FechaJanelas()

        frmCipFim.MdiParent = Me
        frmCipFim.Activate()
        frmCipFim.Show()

    End Sub

    Private Sub butRelat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRelat.Click

        'Dim Browser As Object = CreateObject("InternetExplorer.Application")
        'Browser.Navigate2("http://" & ServerIp & "/CipRelatWeb/Default.aspx")
        'Browser.Visible = True
        Geral.AbreCipRelatWeb()

    End Sub

    Private Sub butCipSchedPer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCipSchedPer.Click

        FechaJanelas()

        frmCipSchedPer.MdiParent = Me
        frmCipSchedPer.Activate()
        frmCipSchedPer.Show()

    End Sub

    Private Sub butCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCadastro.Click

        Dim Cmd As String = Util.UtAppPath & "\..\Bin\IfCad.exe " & lblUser.Tag
        Shell(Cmd, AppWinStyle.NormalFocus)

    End Sub

    Private Sub butLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLogin.Click

        If butLogin.Text = "Logout" Then
            UserLogout()
            Return
        End If

        Dim MyLogin As New Geral.frmLogin
        MyLogin.Abre()

        If MyLogin.SelUsrId <= 0 Then Return

        UserLogin(MyLogin.SelUsrId)


        'Verifica se há CIPs atrasados
        Dim dtDados As New DataTable

        'quio
        'AgendaMontaColunas(dtDados)
        'AgendaBuscaCipSchedProg(dtDados)
        'AgendaBuscaCipSchedPer(dtDados)

        For Conta As Integer = 0 To dtDados.Rows.Count - 1

            If dtDados.Rows(Conta).Item("FlagAtrasado") = 1 Then

                MsgBox("Atenção: Verifique os CIPs atrasados na Agenda!", _
                        MsgBoxStyle.Exclamation, "CIP da DPA Itabuna")

                'quio
                'frmAgenda.MdiParent = Me
                'frmAgenda.Activate()
                'frmAgenda.Show()

                Exit For

            End If

        Next

    End Sub

    Private Sub butSenha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSenha.Click

        frmTrocaSenha.Abre(lblUser.Tag)

    End Sub

    Private Sub butUser_Click(sender As System.Object, e As System.EventArgs) Handles butUser.Click

        Dim Cmd As String = Util.UtAppPath & "\..\Bin\IfCad.exe"

        Try
            Call Shell(Cmd, AppWinStyle.NormalFocus, True)
        Catch : End Try

    End Sub

    Private Sub mnuLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLogin.Click
        butLogin_Click(sender, e)
    End Sub

    Private Sub mnuFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFechar.Click
        butFechar_Click(sender, e)
    End Sub

    Private Sub mnuCipProg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCipProg.Click
        butCipProg_Click(sender, e)
    End Sub

    Private Sub mnuCipCorr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCipCorr.Click
        butCipCorr_Click(sender, e)
    End Sub

    Private Sub mnuCipFim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCipFim.Click
        butCipFim_Click(sender, e)
    End Sub

    Private Sub mnuRelat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRelat.Click
        butRelat_Click(sender, e)
    End Sub

    Private Sub mnuCipSchedPer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCipSchedPer.Click
        butCipSchedPer_Click(sender, e)
    End Sub

    Private Sub mnuCadastro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCadastro.Click
        butCadastro_Click(sender, e)
    End Sub

    Private Sub mnuSenha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSenha.Click
        butSenha_Click(sender, e)
    End Sub

    Private Sub mnuUsuarios_Click(sender As System.Object, e As System.EventArgs) Handles mnuUsuarios.Click
        butUser_Click(sender, e)
    End Sub

End Class
