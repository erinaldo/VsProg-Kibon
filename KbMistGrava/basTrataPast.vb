Module basTrataPast


    Function TrataPast(Mi As clsMistDIt) As Boolean

        If Mi.MistTSts.Value <= 0 Then Return True

        Dim ListaResp() As Integer = Nothing

        Try
            ListaResp = Mi.MistT.Value
        Catch
            Return False
        End Try

        Dim TOrigem As Integer

        ' Rotina inserida para verificar qual é o Tanque
        ' O Pateurizador informa o número do Tanque completo mas o SQL só usa o último número
        If ListaResp(2) = 6113 Then
            TOrigem = 3
        End If

        If ListaResp(2) = 6114 Then
            TOrigem = 4
        End If

        If ListaResp(2) = 6115 Then
            TOrigem = 5
        End If

        If ListaResp(2) = 6116 Then
            TOrigem = 6
        End If

        'Atualiza dados na tabela
        Dim DbMi As New Geral.nsMistGrava.dcMistGrava
        Dim dtProdMist = (From It In DbMi.ProdMist Where It.TqOrigem = TOrigem And It.NumSeqTq = ListaResp(1)).ToList
        If dtProdMist.Count <= 0 Then Return False

        Dim DataHora As String = Format(Now, "yyyyMMddHHmmss")
        dtProdMist.First.DataHoraTransf = DataHora
        dtProdMist.First.Past = Mi.TqId
        dtProdMist.First.Dest = ListaResp(3)

        DbMi.SubmitChanges()


        'Zera flag de fim de batch
        Mi.MistTSts.Write(0)

        Return True

    End Function

End Module
