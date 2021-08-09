Module basTrataRelogio

    Function TrataRelogio(Mi As clsMistDIt) As Boolean

        'Atualiza Relogio do PLC
        Dim ListaResp() As Integer = Nothing

        Try
            ListaResp = Mi.MistT.Value
        Catch
            Return False
        End Try

        Dim DataHora As String = Format(Now, "yyyyMMddHHmmss")

        Dim ano As Integer = Mid$(DataHora, 1, 4)
        Dim mes As Integer = Mid$(DataHora, 5, 2)
        Dim dia As Integer = Mid$(DataHora, 7, 2)
        Dim hora As Integer = Mid$(DataHora, 9, 2)
        Dim Min As Integer = Mid$(DataHora, 11, 2)
        Dim seg As Integer = Mid$(DataHora, 13, 2)

        ListaResp(0) = ano
        ListaResp(1) = mes
        ListaResp(2) = dia
        ListaResp(3) = hora
        ListaResp(4) = Min
        ListaResp(5) = seg

        Try
            Mi.MistT.Write(ListaResp)
        Catch : End Try

        Return True

    End Function

End Module
