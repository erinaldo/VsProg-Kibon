Public Class frmKbMatGravaRelat

    Private Sub frmMatGravaRelat_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Geral.DllInit()

        Dim DataAnt As Date = DateAdd(DateInterval.Hour, -8, Now)
        dpDataIni.Value = DataAnt.Date
        txtHoraIni.Text = Format(DataAnt, "HH:mm:ss")

        dpDataFim.Text = Now.Date
        txtHoraFim.Text = Format(Now, "HH:mm:ss")

        'Simulação
        'dpDataIni.Value = New Date(2013, 10, 31)
        'dpDataFim.Value = New Date(2013, 11, 1)

    End Sub

    Private Sub cmdRelat_Click(sender As System.Object, e As System.EventArgs) Handles cmdRelat.Click

        Dim Dih() As String = txtHoraIni.Text.Split(":")
        Dim Di As New Date(dpDataIni.Value.Year, dpDataIni.Value.Month, dpDataIni.Value.Day, Dih(0), Dih(1), Dih(2))
        Dim DataIniRel As String = Format(Di, "yyyyMMddHHmmss")

        Dim Dfh() As String = txtHoraFim.Text.Split(":")
        Dim Df As New Date(dpDataFim.Value.Year, dpDataFim.Value.Month, dpDataFim.Value.Day, Dfh(0), Dfh(1), Dfh(2))
        If Df > Now Then Df = New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, Now.Second)
        Dim DataFimRel As String = Format(Df, "yyyyMMddHHmmss")

        'Aciona mensagem ao operador
        lblAvisoOp.Visible = True
        lblAvisoOp.Refresh()

        'Gera o relatorio
        Dim Ret As Boolean = GeraRelat(DataIniRel, DataFimRel)
        If Ret = False Then
            MsgBox("Erro: Houve erro na geração do relatório")
        End If

        'Desliga mensagem ao operador
        lblAvisoOp.Visible = False

    End Sub

    Private Sub Cancela_Click(sender As System.Object, e As System.EventArgs) Handles Cancela.Click
        End
    End Sub
End Class
