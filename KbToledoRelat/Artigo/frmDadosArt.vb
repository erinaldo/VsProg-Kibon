Public Class frmDadosArt

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtData = (From It In Ck.SdData Order By It.IdSdData Descending).ToList

        For Conta As Integer = 0 To dtData.Count - 1
            With dtData(Conta)

                gvDados.Rows.Add(.IdArt, .IdSdData, .PesoNom, .TaraMedia, .TamArt, .NumProdNok, .RendAlvo, _
                                 .FtCorrecao, .TamMax, .DensEspec, .CorrDens)

            End With
        Next

    End Sub

End Class