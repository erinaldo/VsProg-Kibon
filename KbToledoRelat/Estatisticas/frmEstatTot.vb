Public Class frmEstatTot

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtStat = (From It In Ck.ProdStat Order By It.IdProdStat Descending).ToList

        For Conta As Integer = 0 To dtStat.Count - 1
            With dtStat(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdStat, .Data, .Hora, .Artigo, _
                                 .NumBatch, .PesoNominal, .Tara, .QtdProdOk, _
                                 .QtdProdNok, .VlMedio, .DesvioPadrao, .Tu1Lim, _
                                 .QtdProdTu1Lim, .QtdProdPerc, .Tu2Lim, .QtdProdTu2Lim)

            End With
        Next

    End Sub

End Class