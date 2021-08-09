Module basTrataTanques

    Function TrataTq(Mi As clsMistDIt) As Boolean

        If Mi.MistTSts.Value <= 0 Then Return True

        Dim ListaResp() As Integer = Nothing

        Try
            ListaResp = Mi.MistT.Value
        Catch
            Return False
        End Try

        'Apaga dado deste tanque com este numero sequencial, caso exista
        Dim DbMi As New Geral.nsMistGrava.dcMistGrava
        Dim dtProdMist = (From It In DbMi.ProdMist Where It.TqOrigem = Mi.TqId And It.NumSeqTq = ListaResp(1)).ToList
        If dtProdMist.Count > 0 Then

            DbMi.ProdMist.DeleteOnSubmit(dtProdMist.First)

        End If

        'Insere novo dado na tabela (completar demais dados do Batch)
        Dim DataHora As String = Format(Now, "yyyyMMddHHmmss")

        Dim NwPm As New Geral.nsMistGrava.ProdMist With {.TqOrigem = Mi.TqId, .NumSeqTq = ListaResp(1),
                    .DataHoraMist = DataHora, .RecRej = ListaResp(3), .RecNum = ListaResp(2),
                    .Peso = ListaResp(4), .DataHoraTransf = "", .Past = 0, .Dest = 0,
                    .Ing1 = ListaResp(5), .Ing2 = ListaResp(6), .Ing3 = ListaResp(7),
                    .Ing4 = ListaResp(8), .Ing5 = ListaResp(9), .Ing6 = ListaResp(10),
                    .Ing7 = ListaResp(11), .Ing8 = ListaResp(12), .Ing9 = ListaResp(13)}
        DbMi.ProdMist.InsertOnSubmit(NwPm)

        DbMi.SubmitChanges()

        'Zera flag de fim de batch
        Mi.MistTSts.Write(0)

        Return True

    End Function


End Module
