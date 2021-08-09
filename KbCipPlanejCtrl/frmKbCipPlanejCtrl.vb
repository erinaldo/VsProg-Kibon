Public Class frmKbCipPlanejCtrl

    Private Sub RefreshDados()

        gvItens.Rows.Clear()

        Try
            For Conta As Integer = 0 To CIRC_MAX_NUM

                With basGlobal.PlanejD.Dados(Conta)

                    Dim Exec As String = "Desligado"
                    If .Exec = True Then Exec = "Ligado"

                    Dim PausaTxt As String = "Ok"
                    If .Pausa = True Then PausaTxt = "Pausa"

                    gvItens.Rows.Add(Geral.CircTxt(.CircNum), .Sts, .RotaId, .RecNum, Exec,
                                     Format(.Vazao, "0.00"), Format(.Temp, "0.00"), Format(.Cond, "0.00"),
                                     .BlkNum, .BlkPasso, PausaTxt)

                End With

            Next

        Catch : End Try

    End Sub

    Private Sub frmCipPlanejCtrl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Geral.DllInit()

        Dim Caminho As String = Util.UtAppPath
        Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")

        Dim IpServer As String = Cfg.colCfg("ServerIp")

        Dim Ret As Boolean = Util.clsObtemIP.VerificaIP(IpServer)

        If Ret <> True Then
            MsgBox("O programa [CipPlanejCtrl.exe] somente deve ser executado no computador Servidor!" & vbCr & _
                   "Este computador não está autorizado a executar este programa!", MsgBoxStyle.Critical, "Permissão Negada")
            End
        End If

        Planej.Iniciar()

        tmrPoll.Enabled = True

        LogAdd("PlanejCtrl Ligado via EXE")

    End Sub

    Private Sub frmCipPlanejCtrl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim Ret As DialogResult = frmConfirmaFim.ShowDialog
        If Ret <> Windows.Forms.DialogResult.OK Then

            e.Cancel = True
            Exit Sub

        End If

        NotifyIcon.Visible = False
        NotifyIcon.Dispose()

        Planej.Parar()

    End Sub

    Private Sub mnuFechar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFechar.Click
        Me.Close()
    End Sub

    Private Sub mnuAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbrir.Click

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.Activate()

    End Sub

    Private Sub butLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLog.Click

        frmLog.Show()

    End Sub

    Private Sub gvItens_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvItens.DoubleClick

        Dim Linha As Integer = gvItens.CurrentRow.Index
        If Linha < 0 Then Return

        Dim myCircTxt As String = gvItens.Rows(Linha).Cells(0).Value

        Dim myCircNum As Integer = Geral.CircNum(myCircTxt)

        If PlanejD.Dados(myCircNum).Exec = False Then
            PlanejD.Dados(myCircNum).Exec = True
        Else
            PlanejD.Dados(myCircNum).Exec = False
        End If

        RefreshDados()

    End Sub

    Private Sub NotifyIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon.MouseDoubleClick
        Visible = True
        WindowState = FormWindowState.Minimized
        WindowState = FormWindowState.Normal
        Focus()
    End Sub

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick

        tmrPoll.Enabled = False

        Dim Ret As Boolean = VerificaOpcTransf()

        RefreshDados()

        tmrPoll.Enabled = True

    End Sub

    Private Function VerificaOpcTransf() As Boolean

        Static Conta As Integer = 0
        Static ContaHist As Boolean = False

        Conta = Conta + 1
        If Conta >= 5 Then Conta = 0
        txtConta.Text = Conta

        txtPollConta.Text = PlanejD.ContaD

        'verifica se comunicacao com o plc foi estabelecida
        If Planej.CommCentral <> True Then
            txtPollSts.Text = "Desconectado"
            Return False
        Else
            txtPollSts.Text = "Conectado"
            Return True
        End If

    End Function

    Private Sub butSair_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSair.Click

        Me.Visible = False
        Me.WindowState = FormWindowState.Minimized

    End Sub

End Class
