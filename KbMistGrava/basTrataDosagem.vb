Module basTrataDosagem

    Function TrataDos(Mi As clsMistDIt) As Boolean


        Dim ListaResp() As Integer = Nothing

        Try
            ListaResp = Mi.MistT.Value
        Catch
            Return False
        End Try

        Dim W1QuantPed As Long
        Dim W2QuantPed As Long
        Dim W1QuantDsg As Long
        Dim W2QuantDsg As Long
        Dim W1Temp As Long
        Dim W2Temp As Long

        If ListaResp(1) <= 0 Then Return True

        'Insere novo dado na tabela

        'DataHora
        Dim ano As String = ListaResp(14)
        Dim mes As String = ListaResp(15)
        Dim dia As String = ListaResp(16)
        Dim hora As String = ListaResp(17)
        Dim Min As String = ListaResp(18)
        Dim seg As String = ListaResp(19)

        If ano = 0 Then Return True

        If mes < 10 Then
            mes = 0 & ListaResp(15)
        End If

        If dia < 10 Then
            dia = 0 & ListaResp(16)
        End If

        If hora < 10 Then
            hora = 0 & ListaResp(17)
        End If

        If Min < 10 Then
            Min = 0 & ListaResp(18)
        End If

        If seg < 10 Then
            seg = 0 & ListaResp(19)
        End If

        Dim DataHora As String = ano & mes & dia & hora & Min & seg

        'BatchId
        Dim BatchId As Integer = ListaResp(3) * 65536 + ListaResp(4)

        'Quantidade Dosada
        W1QuantDsg = ListaResp(7)
        W2QuantDsg = ListaResp(8)
        Dim QuantDsg As Double = TwoSIntToFloat(W2QuantDsg, W1QuantDsg)

        'Quantidade Pedida
        W1QuantPed = ListaResp(9)
        W2QuantPed = ListaResp(10)
        Dim QuantPed As Double = TwoSIntToFloat(W2QuantPed, W1QuantPed)

        'Temperatura
        W1Temp = ListaResp(11)
        W2Temp = ListaResp(12)
        Dim Temp As Double = TwoSIntToFloat(W2Temp, W1Temp)

        'Area
        Dim Area As String = ""
        If ListaResp(1) = 6103 Then
            Area = "Acucar"
        ElseIf ListaResp(1) = 6104 Then
            Area = "Acucar"
        ElseIf ListaResp(2) = 6103 Then
            Area = "Acucar"
        ElseIf ListaResp(2) = 6104 Then
            Area = "Acucar"
        Else
            Area = "Mistura"
        End If

        Dim DbMi As New Geral.nsMistGrava.dcMistGrava

        Try
            Dim NwPmd As New Geral.nsMistGrava.ProdMistDos With {.BatchId = BatchId, .DataHora = DataHora,
                        .Origem = ListaResp(1), .Destino = ListaResp(2), .RecNum = ListaResp(5),
                        .MatPrima = ListaResp(6), .QuantPed = QuantPed, .QuantDsg = QuantDsg,
                        .Tempet = Temp, .StsDos = ListaResp(13), .Area = Area}
            DbMi.ProdMistDos.InsertOnSubmit(NwPmd)
            DbMi.SubmitChanges()
        Catch ex As Exception
            LogAdd("Erro em TrataDos: " & ex.Message)
        End Try

        'Flag de fim de batch
        Mi.MistTSts.Write(1)

        Return True

    End Function

End Module
