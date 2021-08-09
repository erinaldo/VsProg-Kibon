Public Class frmEstatBatchAtu

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()


    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtCharge = (From It In Ck.ProdCharge Order By It.IdProdCharge Descending).ToList

        For Conta As Integer = 0 To dtCharge.Count - 1
            With dtCharge(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdCharge, .Data, .Hora, .NumBatch, _
                                 .QtdProdOk, .QtdProdNok, .VlMedio, .DesvioPadrao, _
                                 .Tu1Lim, .QtdProdTu1Lim, .ProdTU1LimPerc, .Tu2Lim, _
                                 .QtdProdTu2Lim)

            End With
        Next

    End Sub

End Class