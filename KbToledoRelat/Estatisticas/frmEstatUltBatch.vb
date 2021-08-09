Public Class frmEstatUltBatch

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Public Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtLastChr = (From It In Ck.ProdLastChr Order By It.IdProdLastChr Descending).ToList

        For Conta As Integer = 0 To dtLastChr.Count - 1
            With dtLastChr(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdLastChr, .Data, .Hora, .NumBatch, _
                                 .QtdProdOk, .QtdProdNok, .VlMedio, .DesvioPadrao, _
                                 .Tu1Lim, .QtdProdTu1Lim, .ProdTU1LimPerc, _
                                 .Tu2Lim, .QtdProdTu2Lim)

            End With
        Next

    End Sub

End Class