Public Class frmKbPastGrava

    Sub RefreshItens()

        grdItens.Rows.Clear()

        For Each P In PastD.Dados

            grdItens.Rows.Add(P.PastId, P.Sts, P.RecNum, P.TqOrig, P.TqDest, P.PressaoEst1, P.PressaoEst2,
                              P.TempFdvPv, P.TempFdvSp, P.TempFinalPast, P.PresFinalPast,
                              P.ValvFdvA, P.ValvFdvB, P.PresHomoEntr, P.PresHomoSaida, P.AguaAlcool)

        Next

        txtContaD.Text = PastD.ContaD

    End Sub

    Private Sub frmKbPastGrava_Load(sender As Object, e As System.EventArgs) Handles Me.Load

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

        Past.Iniciar()

        tmrPoll.Enabled = True

    End Sub

    Private Sub frmKbPastGrava_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrPoll.Enabled = False
        Past.Parar()

    End Sub
    Private Sub tmrPoll_Tick(sender As System.Object, e As System.EventArgs) Handles tmrPoll.Tick

        RefreshItens()
        txtDataHora.Text = Format(Now, "dd/MM/yyyy HH:mm:ss")

    End Sub

End Class
