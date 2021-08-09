Public Class frmKbSrvIni

    Sub RefreshDados()

        gvItens.Rows.Clear()

        For Each Dd In ChkD.Dados

            gvItens.Rows.Add(Dd.ServNome, Dd.ContaErro, Dd.SrvTxt)

        Next

    End Sub

    Private Sub frmKbSrvCkh_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Geral.DllInit()

        Dim Caminho As String = Util.UtAppPath
        Dim Cfg As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")

        Dim IpServer As String = Cfg.colCfg("ServerIp")

        Dim Ret As Boolean = Util.clsObtemIP.VerificaIP(IpServer)

        If Ret <> True Then
            MsgBox("O programa [KbSrvChk.exe] somente deve ser executado no computador Servidor!" & vbCr & _
                   "Este computador não está autorizado a executar este programa!", MsgBoxStyle.Critical, "Permissão Negada")
            End
        End If

        Chk = New clsChkIni
        Chk.Iniciar()

        tmrRefresh.Enabled = True

    End Sub

    Private Sub frmKbSrvCkh_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrRefresh.Enabled = False
        Chk.Parar()

    End Sub

    Private Sub tmrRefresh_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRefresh.Tick

        RefreshDados()

    End Sub

End Class
