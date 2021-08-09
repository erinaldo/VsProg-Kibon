Public Class frmContGood

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtGut = (From It In Ck.ProdGut Order By It.IdProdGut Descending).ToList

        For Conta As Integer = 0 To dtGut.Count - 1
            With dtGut(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdGut, .QtdProdGutOk, .PesoTotalGutOk, _
                                 .VlMedioGutOk, .QtdProdSpecial, .QtdProdMetalDt, .DataHora)

            End With
        Next

    End Sub

End Class