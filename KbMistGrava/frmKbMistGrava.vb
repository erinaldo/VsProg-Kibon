Public Class frmKbMistGrava

    Private Sub frmMistGrava_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Geral.DllInit()

        Dim Caminho As String = Util.UtAppPath
        Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")

        Dim IpServer As String = Cfg.colCfg("ServerIp")

        Dim Ret As Boolean = Util.clsObtemIP.VerificaIP(IpServer)

        If Ret <> True Then
            MsgBox("O programa [KbMatGrava.exe] somente deve ser executado no computador Servidor!" & vbCr & _
                   "Este computador não está autorizado a executar este programa!", MsgBoxStyle.Critical, "Permissão Negada")
            End
        End If

        Mist.Iniciar()

        tmrPoll.Enabled = True

    End Sub

    Private Sub frmKbMistGrava_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrPoll.Enabled = False

        Mist.Parar()

    End Sub

    Private Sub tmrPoll_Tick(sender As System.Object, e As System.EventArgs) Handles tmrPoll.Tick

        txtDataHora.Text = Format(Now, "dd/MM/yyyy HH:mm:ss")
        txtContaD.Text = MistD.ContaD

    End Sub
End Class
