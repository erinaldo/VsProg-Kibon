Public Class frmKbMatGrava

    Sub RefreshItens()

        grdItens.Rows.Clear()

        For Each M In MatD.Dados

            grdItens.Rows.Add(M.Tq, M.Te, M.CodProd, M.Hr, M.Cn, M.SeqTq)

        Next

        txtContaD.Text = MatD.ContaD

    End Sub

    Private Sub frmMatGrava_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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

        Mat.Iniciar()

        tmrPoll.Enabled = True

    End Sub

    Private Sub frmKbMatGrava_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrPoll.Enabled = False
        Mat.Parar()

    End Sub

    Private Sub tmrPoll_Tick(sender As System.Object, e As System.EventArgs) Handles tmrPoll.Tick

        RefreshItens()

        txtDataHora.Text = Format(Now, "dd/MM/yyyy HH:mm:ss")

    End Sub
End Class
