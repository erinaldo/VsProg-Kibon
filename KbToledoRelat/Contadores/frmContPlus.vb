Public Class frmContPlus

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtPlus = (From It In Ck.ProdPlus Order By It.IdProdPlus Descending).ToList

        For Conta As Integer = 0 To dtPlus.Count - 1
            With dtPlus(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdPlus, .QtdProdPlusZ1, .PesoTotalPlusZ1, .VlMedioPlusZ1, _
                                 .QtdProdPlusZ2, .PesoTotalPlusZ2, .VlMedioPlusZ2, _
                                 .QtdProdPlusZ3, .PesoTotalPlusZ3, .VlMedioPlusZ3, .DataHora)

            End With
        Next

    End Sub

End Class