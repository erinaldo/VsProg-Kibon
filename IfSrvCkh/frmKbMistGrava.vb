Public Class frmKbMistGrava

    Private Sub frmMistGrava_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        tmrPoll.Enabled = True

    End Sub

    Private Sub frmKbMistGrava_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        tmrPoll.Enabled = False

    End Sub

    Private Sub tmrPoll_Tick(sender As System.Object, e As System.EventArgs) Handles tmrPoll.Tick

        txtDataHora.Text = Format(Now, "dd/MM/yyyy HH:mm:ss")

    End Sub
End Class
