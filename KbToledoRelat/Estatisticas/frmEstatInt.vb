Public Class frmEstatInt

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtAktInt = (From It In Ck.ProdAktInt Order By It.IdProdAkt Descending).ToList

        For Conta As Integer = 0 To dtAktInt.Count - 1
            With dtAktInt(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdAkt, .Data, .Hora, .QtdProdOk, .QtdProdNok, _
                                 .VlMedio, .DesvioPadrao, .QtdProdTU1Lim, .ProdTU1LimPerc, .Tu2Lim)

            End With
        Next


    End Sub

End Class