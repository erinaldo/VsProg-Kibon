Module basTrataDadosCip

    Function TrataDadosCip(ContaGrava) As Boolean

        'Le dados do PLC
        Dim Ret As Boolean = ExtraiDadosLidos()
        If Ret = False Then Return False


        'Trata Pasteurizador 1
        PastD.DadosCip(0).TrataPastCip()

        'TrataPasteurizador 2
        PastD.DadosCip(1).TrataPastCip()

        Return True

    End Function

    'Comunicação
    Function ExtraiDadosLidos() As Boolean

        Try

            'Status de cada CIP
            Dim ListaR() As Single = CipRT.Value
            Dim ListaI() As Int16 = CipIT.Value

            PastD.DadosCip(0).VazaoPast = ListaR(0)
            PastD.DadosCip(1).VazaoPast = ListaR(1)
            PastD.DadosCip(0).TempPast = ListaR(2)
            PastD.DadosCip(1).TempPast = ListaR(3)
            PastD.DadosCip(0).CondPast = ListaR(4)
            PastD.DadosCip(1).CondPast = ListaR(5)

            PastD.DadosCip(0).PastSts = ListaI(0)
            PastD.DadosCip(1).PastSts = ListaI(1)
            PastD.DadosCip(0).PastBlkExec = ListaI(2)
            PastD.DadosCip(1).PastBlkExec = ListaI(3)
            PastD.DadosCip(0).PastRec = ListaI(4)
            PastD.DadosCip(1).PastRec = ListaI(5)
            PastD.DadosCip(0).PastRota = ListaI(6)
            PastD.DadosCip(1).PastRota = ListaI(7)
            PastD.DadosCip(0).PastHistSts = ListaI(8)
            PastD.DadosCip(1).PastHistSts = ListaI(9)

        Catch
            Return False
        End Try

        Return True

    End Function

End Module
