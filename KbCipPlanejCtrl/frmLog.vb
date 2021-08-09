Public Class frmLog


    Sub RefreshItens()

        gvLog.Visible = False

        gvLog.Rows.Clear()

        For Conta = 1 To ListaLog.Count

            gvLog.Rows.Add(Conta, ListaLog(Conta))

        Next

        gvLog.Visible = True

    End Sub

    Private Sub frmLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RefreshItens()

    End Sub

    Private Sub butSair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSair.Click

        Me.Close()

    End Sub

    Private Sub butRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRefresh.Click

        RefreshItens()

    End Sub

    Private Sub butLimpar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLimpar.Click

        'Reseta log
        ListaLog = New Collection
        RefreshItens()

    End Sub

End Class