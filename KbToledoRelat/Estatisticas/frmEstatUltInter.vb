Public Class frmEstatUltInter

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtLastInt = (From It In Ck.ProdLastInt Order By It.IdProdLastInt Descending).ToList

        For Conta As Integer = 0 To dtLastInt.Count - 1
            With dtLastInt(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdLastInt, .Data, .Hora, .QtdProdOk, _
                                 .QtdProdNok, .VlMedio, .DesvioPadrao, .TuLim, _
                                 .QtdProdTU1Lim, .ProdTU1LimPerc, .Tu2Lim)

            End With
        Next

    End Sub

End Class