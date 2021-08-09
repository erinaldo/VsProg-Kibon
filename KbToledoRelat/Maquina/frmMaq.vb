Public Class frmMaq


    Public Sub Abre()

        RefreshDados()

        Show()
        Activate()


    End Sub

    Public Sub RefreshDados()

        gvDados.Rows.Clear()

        Dim Ck As New Geral.dcToledo
        Dim dtMaq = (From It In Ck.DadosMaq Order By It.IdMaq Descending).ToList

        For Conta As Integer = 0 To dtMaq.Count - 1
            With dtMaq(Conta)

                gvDados.Rows.Add(.IdMaq, .Maquina, .DataHora)

            End With
        Next

    End Sub



End Class