Public Class frmArtigos

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtArt = (From It In Ck.DadosArt Order By It.ArtId Descending).ToList

        For Conta As Integer = 0 To dtArt.Count - 1
            With dtArt(Conta)

                gvDados.Rows.Add(.IdMaq, .ArtId, .Nome, .Sts, .DataHora)

            End With
        Next

    End Sub


End Class