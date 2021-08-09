Module basDadosAntigos

    Function DeletaDadosAntigos() As Boolean

        Dim DataAnt As Date = DateAdd(DateInterval.Month, -12, Now)
        Dim Datahora As String = Format(DataAnt, "yyyymmddhhnnss")

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava
        Dim dtPastGravaHistDados = (From It In DbPg.PastGravaHistDados Where It.DataHora <= Datahora).ToList

        DbPg.PastGravaHistDados.DeleteAllOnSubmit(dtPastGravaHistDados)
        DbPg.SubmitChanges()

        Return True

    End Function

End Module
