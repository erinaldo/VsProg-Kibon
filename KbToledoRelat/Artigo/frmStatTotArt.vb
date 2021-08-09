Public Class frmStatTotArt

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtStat = (From It In Ck.SdStat Order By It.IdSdStat Descending).ToList

        For Conta As Integer = 0 To dtStat.Count - 1
            With dtStat(Conta)

                gvDados.Rows.Add(.IdArt, .IdSdStat, .NumBatch, .LimTo2, .LimTo1, _
                                 .LimTu1, .LimTu2, .TolerSys, .Tu1Perc, .Tu1Perc, _
                                 .TipoIntervalo, .Escopo, .Estat, .DataHora)

            End With
        Next

    End Sub


End Class