Public Class frmKbMatGrava

    Sub RefreshItens()

        grdItens.Rows.Clear()
        If frmIfSrvChk.KbMatGravaSt = False Then Return

        For Each M In frmIfSrvChk.KbMatGravaDd.Dados

            grdItens.Rows.Add(M.Tq, M.Te, M.CodProd, M.Hr, M.Cn, M.SeqTq)

        Next

    End Sub

    Private Sub frmMatGrava_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        tmrPoll.Enabled = True

    End Sub

    Private Sub frmKbMatGrava_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrPoll.Enabled = False

    End Sub

    Private Sub tmrPoll_Tick(sender As System.Object, e As System.EventArgs) Handles tmrPoll.Tick

        RefreshItens()

        txtDataHora.Text = Format(Now, "dd/MM/yyyy HH:mm:ss")

    End Sub
End Class
