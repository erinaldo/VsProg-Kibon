Public Class frmCadRotasLimEdit

    Dim RotaId As Integer
    Dim LimRev As Integer
    Dim BlkNum As Integer

    Sub Abre(RotaId As Integer, LimRev As Integer, BlkNum As Integer)

        Me.RotaId = RotaId
        Me.LimRev = LimRev
        Me.BlkNum = BlkNum

        RefreshDados()

        ShowDialog()

    End Sub

    Sub RefreshDados()

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = RotaId And It.LimRev = LimRev And It.BlkNum = BlkNum).ToList
        If dtCadRotasLim.Count <= 0 Then Return

        txtTempMax.Text = Format(dtCadRotasLim.First.TempMax, "0.00")
        txtTempMin.Text = Format(dtCadRotasLim.First.TempMin, "0.00")

        txtCondMax.Text = Format(dtCadRotasLim.First.CondMax, "0.00")
        txtCondMin.Text = Format(dtCadRotasLim.First.CondMin, "0.00")

        txtVazaoMax.Text = Format(dtCadRotasLim.First.VazaoMax, "0.00")
        txtVazaoMin.Text = Format(dtCadRotasLim.First.VazaoMin, "0.00")

        txtTempoAjuste.Text = dtCadRotasLim.First.TempoAjuste

    End Sub

    Private Sub butCancela_Click(sender As System.Object, e As System.EventArgs) Handles butCancela.Click
        Close()
    End Sub

    Private Sub butOk_Click(sender As System.Object, e As System.EventArgs) Handles butOk.Click

        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = RotaId And It.LimRev = LimRev And It.BlkNum = BlkNum).ToList
        If dtCadRotasLim.Count <= 0 Then Return

        dtCadRotasLim.First.TempMax = txtTempMax.Text
        dtCadRotasLim.First.TempMin = txtTempMin.Text

        dtCadRotasLim.First.CondMax = txtCondMax.Text
        dtCadRotasLim.First.CondMin = txtCondMin.Text

        dtCadRotasLim.First.VazaoMax = txtVazaoMax.Text
        dtCadRotasLim.First.VazaoMin = txtVazaoMin.Text

        dtCadRotasLim.First.TempoAjuste = txtTempoAjuste.Text

        DbCv.SubmitChanges()

        Close()

    End Sub
End Class