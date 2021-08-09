
Public Class frmKbToledoCtrl

    Dim Com As clsCom

    'Inicia transmissao
    Private Sub butIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butIniciar.Click

        Com = New clsCom
        Com.Inicia()

        If basComTcpIp.FlagCom Then
            lblSts.Text = "Conectado"
        End If

        TmrRefresh.Enabled = True


    End Sub

    'Encerra a transmissao
    Private Sub butParar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butParar.Click

        Com.Para()
        Com = Nothing
        TmrRefresh.Enabled = False

    End Sub

    'Testa Comunicação
    Private Sub butTestCom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butTestCom.Click

        Com = New clsCom
        Com.Conecta()
        Com.TestCom()

        If basComTcpIp.FlagCom Then
            lblSts.Text = "Conectado"
        End If

        TmrRefresh.Enabled = True

    End Sub

    'Fecha o cliente
    Private Sub butEncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butFecha.Click

        Close()

    End Sub

    'Atualiza informações no Form    
    Private Sub TmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrRefresh.Tick

        'Exibe o comando a ser enviado
        txtCmd.Text = ""
        txtCmd.Text = basTrataDados.DadosCli

        'Exibe resposta
        txtResp.Text = ""
        txtResp.Text = basTrataDados.DadosServ


    End Sub


End Class
