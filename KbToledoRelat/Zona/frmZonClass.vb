Public Class frmZonClass

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtZones = (From It In Ck.SdZones Order By It.IdSdZones Descending).ToList

        For Conta As Integer = 0 To dtZones.Count - 1
            With dtZones(Conta)

                gvDados.Rows.Add(.IdArt, .IdSdZones, .NomeZ1, .OkZona1, .NokZona1, _
                                 .NomeZ2, .OkZona2, .NokZona2, _
                                 .NomeZ3, .OkZona3, .NokZona3, _
                                 .NomeZ4, .OkZona4, .NokZona4, _
                                 .NomeZ5, .OkZona5, .NokZona5, .DataHora)

            End With
        Next

    End Sub

End Class