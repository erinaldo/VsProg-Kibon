Public Class frmKbCipPlanejCtrl

    Private Sub RefreshDados()

        gvItens.Rows.Clear()
        If frmIfSrvChk.KbCipPlanejCtrlSt = False Then Return

        Try
            For Each Dd In frmIfSrvChk.KbCipPlanejCtrlDd.Dados

                Dim Exec As String = "Desligado"
                If Dd.Exec = True Then Exec = "Ligado"

                Dim PausaTxt As String = "Ok"
                If Dd.Pausa = True Then PausaTxt = "Pausa"

                gvItens.Rows.Add(Geral.CircTxt(Dd.CircNum), Dd.Sts, Dd.RotaId, Dd.RecNum, Exec,
                                 Format(Dd.Vazao, "0.00"), Format(Dd.Temp, "0.00"), Format(Dd.Cond, "0.00"),
                                 Dd.BlkNum, Dd.BlkPasso, PausaTxt)

            Next

        Catch : End Try

    End Sub

    Private Sub frmCipPlanejCtrl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        tmrPoll.Enabled = True

    End Sub

    Private Sub frmCipPlanejCtrl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrPoll.Enabled = False

    End Sub

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick

        RefreshDados()

    End Sub

    Private Sub butSair_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butSair.Click

        Close()

    End Sub

End Class
