Public Class frmCadCfgEdit

    Public SelCfg As String
    Public SelValor As String

    Sub Abre(Optional ByVal Cfg As String = "", Optional ByVal Valor As String = "")

        txtCfg.Text = Cfg
        txtValor.Text = Valor

        SelCfg = ""
        SelValor = ""

        If frmCadCfg.btnNovo.CheckOnClick = True Then
            txtCfg.Focus()
        End If

        ShowDialog()

    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click
        SelCfg = ""
        SelValor = ""
        Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        'se for elemento novo verifica
        If frmCadCfg.btnNovo.CheckOnClick = True Then

            Dim MyRows = From It In frmCadCfg.dtCadCfg Where It.Cfg = txtCfg.Text
            If MyRows.Count > 0 Then
                MsgBox("Erro: o item [" & txtCfg.Text & "] já existe na lista. Digite outro nome.")
                Return
            End If

        End If

        'verifica se todos os dados foram preenchidos
        If txtValor.Text = "" Then
            MsgBox("Erro: o valor não pode ser nulo.", MsgBoxStyle.Critical)
            Return
        End If

        SelCfg = txtCfg.Text
        SelValor = txtValor.Text
        Close()

    End Sub

End Class