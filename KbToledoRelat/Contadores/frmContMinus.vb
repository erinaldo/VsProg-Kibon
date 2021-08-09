Public Class frmContMinus

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtMinus = (From It In Ck.ProdMinus Order By It.IdProdMinus Descending).ToList

        For Conta As Integer = 0 To dtMinus.Count - 1
            With dtMinus(Conta)

                gvDados.Rows.Add(.IdArt, .IdProdMinus, .QtdProdMinusZ1, .PesoTotalMinusZ1, .VlMedioMinusZ1, _
                                 .QtdProdMinusZ2, .PesoTotalMinusZ2, .VlMedioMinusZ2, _
                                 .QtdProdMinusZ3, .PesoTotalMinusZ3, .VlMedioMinusZ3, .DataHora)

            End With
        Next

    End Sub

End Class