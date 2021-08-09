Public Class frmSelDataHora

    Public SelOk As Boolean = False
    Public SelDataHora As Date

    Sub Abre(ByVal DataHora As Date)

        mcCalend.SetDate(DataHora)
        txtDataHora.Text = Format(DataHora, "dd/MM/yyyy HH:mm:ss")
        SelOk = False

        ShowDialog()

    End Sub

    Private Sub mcCalend_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcCalend.DateChanged

        Dim Hora As String = Mid(txtDataHora.Text, 12, 8)

        txtDataHora.Text = Format(mcCalend.SelectionEnd.Date, "dd/MM/yyyy") & " " & Hora

    End Sub

    Private Sub butCancela_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancela.Click
        SelOk = False
        Close()
    End Sub

    Private Sub butOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOk.Click

        SelOk = True

        Dim Dia As Integer = Mid(txtDataHora.Text, 1, 2)
        Dim Mes As Integer = Mid(txtDataHora.Text, 4, 2)
        Dim Ano As Integer = Mid(txtDataHora.Text, 7, 4)
        Dim Hora As Integer = Mid(txtDataHora.Text, 12, 2)
        Dim Min As Integer = Mid(txtDataHora.Text, 15, 2)
        Dim Seg As Integer = Mid(txtDataHora.Text, 18, 2)

        SelDataHora = New Date(Ano, Mes, Dia, Hora, Min, Seg)
        Close()

    End Sub
End Class