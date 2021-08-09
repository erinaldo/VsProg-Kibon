Public Class frmDadosArtAtv

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()


        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtArtAtv = (From It In Ck.SdGrund Order By It.IdGrund Descending).ToList

        For Conta As Integer = 0 To dtArtAtv.Count - 1
            With dtArtAtv(Conta)

                gvDados.Rows.Add(.IdArt, .IdGrund, .NumVersion, .NomeArt, .CodEAN, .UnidPeso, .DataHora)

            End With
        Next

    End Sub

End Class