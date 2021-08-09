Public Class frmKbPastGravaRelat

    Private Sub frmKbPastGravaRelat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Geral.DllInit()

    End Sub

    Private Sub Cancela_Click(sender As System.Object, e As System.EventArgs) Handles Cancela.Click
        End
    End Sub

    Private Sub butRelatProd_Click(sender As System.Object, e As System.EventArgs) Handles butRelatProd.Click

        If txtHistId.Text = "" Then
            MsgBox("Erro: Selecione o CIP")
            Return
        End If

        'Aciona mensagem ao operador
        lblAvisoOp.Visible = True
        lblAvisoOp.Refresh()

        'Gera o relatorio
        Dim Ret As Boolean = GeraRelatProd(txtHistId.Text)
        If Ret = False Then
            MsgBox("Erro: Houve erro na geração do relatório")
        End If

        'Desliga mensagem ao operador
        lblAvisoOp.Visible = False

        End

    End Sub

    Private Sub butSelProd_Click(sender As System.Object, e As System.EventArgs) Handles butSelProd.Click

        frmSelProd.Abre()
        If frmSelProd.SelHistId <= 0 Then Return

        txtHistId.Text = frmSelProd.SelHistId

    End Sub

    Private Sub butSelCip_Click(sender As System.Object, e As System.EventArgs) Handles butSelCip.Click

        frmSelCip.Abre()
        If frmSelCip.SelCipId <= 0 Then Return

        txtCipId.Text = frmSelCip.SelCipId

    End Sub

    Private Sub butRelatCip_Click(sender As System.Object, e As System.EventArgs) Handles butRelatCip.Click

        If txtCipId.Text = "" Then
            MsgBox("Erro: Selecione o CIP")
            Return
        End If

        'Aciona mensagem ao operador
        lblAvisoOp.Visible = True
        lblAvisoOp.Refresh()

        'Gera o relatorio
        Dim Ret As Boolean = GeraRelatCip(txtCipId.Text)
        If Ret = False Then
            MsgBox("Erro: Houve erro na geração do relatório")
        End If

        'Desliga mensagem ao operador
        lblAvisoOp.Visible = False

        End

    End Sub
End Class
