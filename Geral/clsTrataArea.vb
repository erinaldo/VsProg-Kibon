Public Class clsTrataArea

    Public AreaDados As New Collection

    Function AreaLe(ByVal Area As String) As Boolean

        Dim Banco = New Geral.nsReceitas.dcReceitas

        Dim dtAreas = (From It In Banco.Areas Where It.Area = Area).ToList()

        If dtAreas.Count <= 0 Then
            Return False
        End If

        With dtAreas(0)

            'Insere dados da area na colecao
            AreaDados.Add(Area, "Area")
            AreaDados.Add(.Descr, "Descr")
            AreaDados.Add(.UsaPlanejBrix, "UsaPlanejBrix")
            AreaDados.Add(.UsaIngredMan, "UsaIngredMan")
            AreaDados.Add(.UsaPesoRef, "UsaPesoRef")
            AreaDados.Add(.RsLinxTopic, "RsLinxTopic")

        End With

        Return True

    End Function


End Class
