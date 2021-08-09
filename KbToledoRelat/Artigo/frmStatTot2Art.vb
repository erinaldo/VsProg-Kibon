Public Class frmStatTot2Art

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtStat2 = (From It In Ck.SdStat2 Order By It.IdSdStat2 Descending).ToList

        For Conta As Integer = 0 To dtStat2.Count - 1
            With dtStat2(Conta)

                gvDados.Rows.Add(.IdArt, .IdSdStat2, .Tu1PercMax, .QtdProdNokTu1, .QtdProdNokTu2, _
                                 .VlMedioProNok, .VlMedioRef, .PrintAuto, .PrintHora, .PrintBatchHora, .DataHora)

            End With
        Next

    End Sub


End Class