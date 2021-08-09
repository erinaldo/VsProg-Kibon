Public Class frmHist

    Dim dtHist As List(Of Geral.DadosHist)

    Public Sub Abre()

        Dim Ck As New Geral.dcToledo
        Dim dtHist = (From It In Ck.DadosHist Order By It.IdHist Descending).ToList

        RefreshDados()

        Show()
        Activate()


    End Sub

    Public Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtHist = (From It In Ck.DadosHist Order By It.IdHist Descending).ToList

        For Conta As Integer = 0 To dtHist.Count - 1
            With dtHist(Conta)

                gvDados.Rows.Add(.IdHist, .HorIni, .DataIni, .Horfin, .DataFin, .Rendimento, .ValorMedio, .TU1Infrac)
            End With

        Next


    End Sub

End Class