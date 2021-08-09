Public Class frmKbPastGrava

    Sub RefreshItens()

        grdItens.Rows.Clear()
        If frmIfSrvChk.KbPastGravaSt = False Then Return

        For Each P In frmIfSrvChk.KbPastGravaDd.Dados

            grdItens.Rows.Add(P.PastId, P.Sts, P.RecNum, P.TqOrig, P.TqDest, P.PressaoEst1, P.PressaoEst2,
                              P.TempFdvPv, P.TempFdvSp, P.TempFinalPast, P.PresFinalPast,
                              P.ValvFdvA, P.ValvFdvB, P.PresHomoEntr, P.PresHomoSaida, P.AguaAlcool)

        Next

    End Sub

    Private Sub frmKbPastGrava_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        tmrPoll.Enabled = True

    End Sub

    Private Sub frmKbPastGrava_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrPoll.Enabled = False
 
    End Sub

    Private Sub tmrPoll_Tick(sender As System.Object, e As System.EventArgs) Handles tmrPoll.Tick

        RefreshItens()
        txtDataHora.Text = Format(Now, "dd/MM/yyyy HH:mm:ss")

    End Sub

End Class
