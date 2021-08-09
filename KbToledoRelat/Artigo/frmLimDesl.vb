Public Class frmLimDesl

    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()

    End Sub

    Private Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtGleit = (From It In Ck.SdGleit Order By It.IdSdGleit Descending).ToList

        For Conta As Integer = 0 To dtGleit.Count - 1
            With dtGleit(Conta)

                gvDados.Rows.Add(.IdArt, .IdSdGleit, .PesoRef, .LimAlto, .T1LimPos, _
                                 .T1LimNeg, .LimBaixo, .VarLim, .QtdPcs, .RangeTol, .DataHora)

            End With
        Next

    End Sub

End Class