Module basTrataEnvio

    Dim dtFlipCad As List(Of Geral.nsCipRotas.FlipCad)

    Dim OpcCipEnv As OPCAutomation.OPCServer

    Dim OpcGrupoRec As OPCAutomation.OPCGroup
    Public Const cnstGroupRec = "EnvRec"

    Dim OpcGrupoPlan As OPCAutomation.OPCGroup
    Public Const cnstGroupPlan = "EnvPlan"

    Dim OpcGrupoRtAs1 As OPCAutomation.OPCGroup
    Public Const cnstGroupRtAs1 = "EnvRtAs1"

    Dim OpcGrupoRtAs2 As OPCAutomation.OPCGroup
    Public Const cnstGroupRtAs2 = "EnvRtAs2"


    Function CipPlanejEnvia(ByVal CircTxt As String, ByVal RotaId As Integer, ByVal RecNum As Integer) As Boolean

        'Verifica se algum cip ficou morto no banco de dados
        Planej.CipCircChk(Geral.CircNum(CircTxt))

        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        dtFlipCad = (From It In DbCr.FlipCad).ToList

        Dim listEndPlcs As New Collection

        'Monta a receita
        Dim DadosRec(REC_MAX_BLOCOS * 10 - 1) As Object
        Dim RecNome As String = ""
        '******* IVAN - Sanitização ***********
        Dim TipoCip As Integer = 0
        Dim Ret As Boolean = MontaReceita(RecNum, RecNome, DadosRec, TipoCip) '******* IVAN - Sanitização *********** (Adicionado TipoCip)
        If Ret = False Then Return False

        'Buscando dados da rota
        Dim Circ As String = "", Tipo As String = "", Desc As String = "", Tq1 As String = "", Tq2 As String = "", Tq3 As String = ""
        Dim BbaCipFw As Integer = 0
        PegaDadosRota(RotaId, Circ, Tipo, Desc, Tq1, Tq2, Tq3, BbaCipFw)


        'Monta a rota
        Dim lstRotaPlc = MontaRota(CInt(RotaId), Tq1, Tq2, Tq3)


        'Monta grupo de tags no OPC para o planejamento
        Dim CircNum As Integer = Geral.CircNum(CircTxt)

        Ret = PlcEnviaOpcMonta(CircNum)

        If Ret <> True Then Return False


        'Verificando se o status da receita é 0, ou seja, parada
        Dim DadosPlan(20 - 1) As Integer
        Dim RetSts As Boolean = OpcGrupoLe(OpcGrupoPlan, DadosPlan)
        If RetSts <> True Then

            'Falha na comunicacao
            LogAdd("Erro - Comunicacao com PLC [" & cnstGroupPlan & "] nao foi estabelecida")
            OpcCipEnv.Disconnect()
            Return False

        End If


        'Verificando o status atual
        Try
            If DadosPlan(0) <> RECEITA_PARADA And DadosPlan(0) <> RECEITA_FALHA_ALOCACAO Then

                LogAdd("Erro - Receita nao se encontra com status 'Parada'")
                OpcCipEnv.Disconnect()
                Return False

            End If
        Catch
            Return False
        End Try


        'Passa status para RECEITA_DOWNLOAD
        DadosPlan(0) = RECEITA_DOWNLOAD

        Dim Ret1 As Boolean = OpcGrupoEscreve(OpcGrupoPlan, DadosPlan)
        If Ret1 <> True Then

            'Falha na comunicacao
            LogAdd("Erro - Comunicacao com PLC [" & cnstGroupPlan & "] no envio do CMD Download")
            Return False

        End If


        'Enviando a receita contendo a velocodade da Bba de cip pressao no bloco 19 parametro 1
        DadosRec(19 * 10 + 1) = BbaCipFw

        '******* IVAN - Sanitização ***********
        'Enviando a receita contendo o tipo de CIP no parametro 2
        DadosRec(19 * 10 + 2) = TipoCip

        Dim Ret2 As Boolean = OpcGrupoEscreve(OpcGrupoRec, DadosRec)
        If Ret2 <> True Then
            'Falha na comunicacao
            LogAdd("Erro - Comunicacao com PLC [" & cnstGroupPlan & "] no envio do CMD Download")
            Return False
        End If

        'Enviando a rota para os PLCs
        Dim RtAs1 As clsRotaPlc = ProcuraRotaPlc(lstRotaPlc, 1)
        Dim Ret3 As Boolean = OpcGrupoEscreve(OpcGrupoRtAs1, RtAs1.lstItens)
        If Ret3 <> True Then
            'Falha na comunicacao
            LogAdd("Erro - Comunicacao com PLC [" & cnstGroupRtAs1 & "] no envio do CMD Download")
            Return False
        End If

        Dim RtAs2 As clsRotaPlc = ProcuraRotaPlc(lstRotaPlc, 2)
        Dim Ret4 As Boolean = OpcGrupoEscreve(OpcGrupoRtAs2, RtAs2.lstItens)
        If Ret4 <> True Then
            'Falha na comunicacao
            LogAdd("Erro - Comunicacao com PLC [" & cnstGroupRtAs2 & "] no envio do CMD Download")
            Return False
        End If

        'Enviando planejamento de producao
        Dim Filler As String = "                                "
        Dim NomeReceita As String = Left(RecNome & Filler, 30)

        DadosPlan(0) = RECEITA_INICIO                                 'Status
        DadosPlan(1) = RotaId                                         'Numero da rota
        If Tipo = "T" Then                                                'Tipo de CIP
            DadosPlan(2) = 256
        Else
            DadosPlan(2) = 0
        End If
        DadosPlan(3) = RecNum                                         'Numero da receita
        'DadosPlan(4) = ConvBytesWord(Len(NomeReceita), 0)             'Nome da receita string
        DadosPlan(4) = ConvBytesWord(30, 30)                          'Nome da receita string

        'Nome da receita de CIP
        For Conta = 0 To 14
            Dim Pos1 As Short = (Conta * 2) + 1
            Dim Pos2 As Short = Pos1 + 1
            Dim MyInt1 As Short = Asc(Mid(NomeReceita, Pos1, 1))
            Dim MyInt2 As Short = Asc(Mid(NomeReceita, Pos2, 1))
            Dim MyLong As Integer = ConvBytesWord(MyInt1, MyInt2)
            DadosPlan(Conta + 5) = CInt(MyLong)
            If DadosPlan(Conta + 5) <= 0 Then DadosPlan(Conta + 5) = "8224"

        Next
        DadosPlan(19) = 0

        Dim Ret6 As Boolean = OpcGrupoEscreve(OpcGrupoPlan, DadosPlan)
        If Ret6 <> True Then

            'Falha na comunicacao
            LogAdd("Erro - Comunicacao com PLC [" & cnstGroupPlan & "] no envio do planejamento")
            Return False

        End If

        'Passa status para RECEITA_INICIO
        LogAdd("Planejamento enviado. Circuito " & Circ & " ,Rota " & RotaId)
        'GravaDadosCip(Circ, RotaId, RotaDesc, RecNum, RecNome)

        'Ok
        OpcCipEnv.Disconnect()

        Return True

    End Function
    '******* IVAN - Sanitização *********
    Function MontaReceita(ByVal RecNum As Integer, ByRef outRecNome As String, ByRef outReceita As Object, ByRef outTipoCip As Integer) As Boolean

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtRec = (From It In DbRc.Rec Where It.Area = "CIP" And It.RecNum = RecNum).ToList
        If dtRec.Count <= 0 Then Return False

        'Receita encontrada
        outRecNome = dtRec(0).Codigo & " - " & dtRec(0).RecNome

        '******* IVAN - Sanitização *********
        'Carrega o valor do tipo do CIP (Campo Densidade)
        outTipoCip = dtRec(0).Densidade

        Dim dtRecBlocos = (From It In DbRc.RecBlocos Where It.Area = "CIP" And It.RecNum = RecNum Order By It.ItemSeq).ToList

        Dim ContaBloco As Integer = 0

        'limpa receita para evitar valores antigos
        For Conta As Integer = 0 To (REC_MAX_BLOCOS * 10) - 1
            outReceita(Conta) = 0
        Next

        For Each Blk In dtRecBlocos

            Dim MyBlocoPadrao As New clsBloco
            MyBlocoPadrao.LeModelo("CIP", Blk.BlkNum)

            Dim Pos As Integer = ContaBloco * 10
            outReceita(Pos) = Blk.BlkNum

            'On Error Resume Next
            Try
                outReceita(Pos + 1) = Blk.Param01 * MyBlocoPadrao.MyParametros(1).Multiplic
                outReceita(Pos + 2) = Blk.Param02 * MyBlocoPadrao.MyParametros(2).Multiplic
                outReceita(Pos + 3) = Blk.Param03 * MyBlocoPadrao.MyParametros(3).Multiplic
                outReceita(Pos + 4) = Blk.Param04 * MyBlocoPadrao.MyParametros(4).Multiplic
                outReceita(Pos + 5) = Blk.Param05 * MyBlocoPadrao.MyParametros(5).Multiplic
                outReceita(Pos + 6) = Blk.Param06 * MyBlocoPadrao.MyParametros(6).Multiplic
                outReceita(Pos + 7) = Blk.Param07 * MyBlocoPadrao.MyParametros(7).Multiplic
                outReceita(Pos + 8) = Blk.Param08 * MyBlocoPadrao.MyParametros(8).Multiplic
                outReceita(Pos + 9) = Blk.Param09 * MyBlocoPadrao.MyParametros(9).Multiplic
            Catch
                'MessageBox.Show("Opa!")
            End Try
            'On Error GoTo 0

            ContaBloco = ContaBloco + 1

            'No maximo 5 blocos de receita
            If ContaBloco >= REC_MAX_BLOCOS Then Exit For

        Next

        MontaReceita = True

    End Function

    'Function PegaDadorReceita(ByVal RecNum As Integer, ByRef outRecNome As String, ByRef outReceita As Object) As Boolean

    'End Function


    Function PegaDadosRota(ByVal RotaId As Integer, ByRef outCirc As String, ByRef outTipo As String,
                           ByRef outRotaDesc As String, ByRef outTq1 As String, ByRef outTq2 As String,
                           ByRef outTq3 As String, ByRef outBbaCipFw As Integer) As Boolean

        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        Dim dtRotaCad = (From It In DbCr.RotaCad Where It.RotaId = RotaId).ToList

        If dtRotaCad.Count <= 0 Then Return False

        With dtRotaCad(0)
            outCirc = .Circ
            outTipo = .Tipo
            outRotaDesc = .Descr
            outTq1 = .Tq1
            outTq2 = .Tq2
            outTq3 = .Tq3
            outBbaCipFw = .BbaCipFw
        End With

        PegaDadosRota = True

    End Function

    Function MontaRota(ByVal RotaId As Integer, ByVal Tq1 As String, ByVal Tq2 As String, ByVal Tq3 As String) As List(Of clsRotaPlc)

        Dim lstRotaPlc = New List(Of clsRotaPlc)
        Dim MyRp As clsRotaPlc = Nothing

        'Carrega Válvulas
        Dim DbCr As New Geral.nsCipRotas.dcCipRotas
        Dim dtCipRotaValv = (From ItRv In DbCr.RotaValv Join ItVc In DbCr.ValvCad On ItRv.Tag Equals ItVc.Tag
                             Where ItRv.RotaId = RotaId Order By ItVc.PlcIdx, ItVc.PlcNum).ToList

        For Each Valv In dtCipRotaValv

            MyRp = ProcuraRotaPlc(lstRotaPlc, Valv.ItVc.PlcNum)
            MyRp.Add(Valv.ItVc.PlcIdx, GetTipoValv(Valv.ItRv.Tipo))

        Next


        'Carrega Motores
        Dim dtCipRotaMot = (From ItRm In DbCr.RotaMot Join ItMc In DbCr.MotCad On ItRm.Tag Equals ItMc.Tag
                            Where ItRm.RotaId = RotaId Order By ItMc.PlcIdx, ItMc.PlcNum).ToList

        For Each Mot In dtCipRotaMot

            MyRp = ProcuraRotaPlc(lstRotaPlc, Mot.ItMc.PlcNum)
            MyRp.Add(Mot.ItMc.PlcIdx, GetTipoMot(Mot.ItRm.Tipo))

        Next


        'Carrega Placas de fluxo
        Dim dtCipRotaPf = (From ItRp In DbCr.RotaPf Join ItPc In DbCr.PfCad On ItRp.Tag Equals ItPc.Tag
                           Where ItRp.RotaId = RotaId Order By ItPc.PlcIdx, ItPc.PlcNum).ToList

        For Each Pf In dtCipRotaPf

            MyRp = ProcuraRotaPlc(lstRotaPlc, Pf.ItPc.PlcNum)
            MyRp.Add(Pf.ItPc.PlcIdx, 1049)

        Next


        'Tanques 1, 2 e 3
        Dim dtTqCad1 = (From It In DbCr.TqCad Where It.Tag = Tq1).ToList
        If dtTqCad1.Count > 0 Then
            'MyRp = ProcuraRotaPlc(lstRotaPlc, dtTqCad1(0).PlcNum)
            'MyRp.Add(dtTqCad1(0).PlcIdx, 1047)
            For Each Rp In lstRotaPlc
                Rp.Add(dtTqCad1(0).PlcIdx, 1047)
            Next
        End If

        Dim dtTqCad2 = (From It In DbCr.TqCad Where It.Tag = Tq2).ToList
        If dtTqCad2.Count > 0 Then
            'MyRp = ProcuraRotaPlc(lstRotaPlc, dtTqCad2(0).PlcNum)
            'MyRp.Add(dtTqCad2(0).PlcIdx, 1047)
            For Each Rp In lstRotaPlc
                Rp.Add(dtTqCad2(0).PlcIdx, 1047)
            Next
        End If

        Dim dtTqCad3 = (From It In DbCr.TqCad Where It.Tag = Tq3).ToList
        If dtTqCad3.Count > 0 Then
            'MyRp = ProcuraRotaPlc(lstRotaPlc, dtTqCad3(0).PlcNum)
            'MyRp.Add(dtTqCad3(0).PlcIdx, 1047)
            For Each Rp In lstRotaPlc
                Rp.Add(dtTqCad3(0).PlcIdx, 1047)
            Next
        End If

        Return lstRotaPlc

    End Function

    Function ProcuraRotaPlc(ByRef lstRotaPlc As List(Of clsRotaPlc), ByVal PlcNum As Integer) As clsRotaPlc

        'Busca na colecao MyPlcs o item correspondente ao PlcNum, caso nao tenha, cria na colecao
        For Conta As Integer = 0 To lstRotaPlc.Count - 1
            If lstRotaPlc(Conta).PlcId = PlcNum Then

                'Plc encontrado
                Return lstRotaPlc(Conta)

            End If
        Next

        'O Plc nao existe, ele sera criado
        Dim NovoRp As New clsRotaPlc
        NovoRp.PlcId = PlcNum

        lstRotaPlc.Add(NovoRp)

        Return NovoRp

    End Function

    Function EnviaRotas(ByVal CircNum As Integer) As Boolean

        ''Dim Estacao As clsPlc
        'Dim OpcSrvRota As New OPCAutomation.OPCServer

        'EnviaRotas = False
        'Dim EndRota As String = "CipReceita[" & CircNum & "]"

        'If MyPlcs.Count <= 0 Then Return False

        'Dim Caminho As String = Util.UtAppPath
        'Dim Config As New Util.clsTrataCfg(Caminho & "\..\Bin\cfgGeral.xml")

        ''Enviando a rota
        'For Estacao As Integer = 0 To MyPlcs.Count - 1


        '    Dim NumPlcId As Integer = -1
        '    Try
        '        NumPlcId = CInt(MyPlcs(Estacao).PlcId)
        '    Catch : End Try

        '    'Monta tags OPC
        '    Dim PlcTopico As String = ""

        '    Select Case NumPlcId
        '        Case 1
        '            PlcTopico = Config.colCfg("RsLinx_Topico_AdesL1")
        '        Case 2
        '            PlcTopico = Config.colCfg("RsLinx_Topico_AdesL2")
        '        Case 3
        '            PlcTopico = Config.colCfg("RsLinx_Topico_AdesL3")
        '        Case 4
        '            PlcTopico = Config.colCfg("RsLinx_Topico_AdesL4")
        '        Case 9
        '            PlcTopico = Config.colCfg("RsLinx_Topico_Ccips")
        '        Case 10
        '            PlcTopico = Config.colCfg("RsLinx_Topico_Comum")
        '    End Select

        '    Dim Ret0 As Boolean = PlcEnviaOpcMontaRota(OpcSrvRota, PlcTopico, EndRota)
        '    If Ret0 <> True Then
        '        Try
        '            OpcSrvRota.Disconnect()
        '            OpcSrvRota = Nothing
        '        Catch : End Try
        '        LogAdd("Erro - Não foi possível montar a Área de Receita de CIP para Circuito [" & CircNum & "] do PLC [" & NumPlcId & "]")
        '        Return False
        '    End If

        '    Dim CipReceita As Object = ""

        '    Dim Ret1 As Boolean = OpcGrupoLe(OpcSrvRota.OPCGroups(0), CipReceita)
        '    If Ret1 <> True Then
        '        Try
        '            OpcSrvRota.Disconnect()
        '            OpcSrvRota = Nothing
        '        Catch : End Try
        '        LogAdd("Erro - Área de Receita de CIP não encontrada para Circuito [" & CircNum & "] do PLC [" & NumPlcId & "]")
        '        Return False
        '    End If

        '    'Carrega receita na estrutura a ser escrita no plc
        '    Dim RecTq As Object = MyPlcs(Estacao).GetTqRota
        '    Dim RecDep As Object = MyPlcs(Estacao).GetDependRota
        '    Dim RecPf As Object = MyPlcs(Estacao).GetPfRota
        '    Dim RecValv As Object = MyPlcs(Estacao).GetValvRota1
        '    Dim RecMot As Object = MyPlcs(Estacao).GetMotRota

        '    For Conta As Integer = 0 To ROTA_MAX_TQ - 1

        '        CipReceita(Conta + 1) = RecTq(Conta + 1)

        '    Next

        '    For Conta As Integer = 0 To ROTA_MAX_PF - 1

        '        CipReceita(Conta + 7) = RecPf(Conta + 1)

        '    Next

        '    For Conta As Integer = 0 To ROTA_MAX_VALV - 1

        '        CipReceita(Conta + 17) = RecValv(Conta + 1)

        '    Next

        '    For Conta As Integer = 0 To ROTA_MAX_MOTOR - 1

        '        CipReceita(Conta + 117) = RecMot(Conta + 1)

        '    Next

        '    Dim Ret2 As Boolean = OpcGrupoEscreve(OpcSrvRota.OPCGroups(0), CipReceita)
        '    If Ret2 = False Then
        '        LogAdd("Falha no envio da Receita de CIP para Circuito [" & CircNum & "] do PLC [" & NumPlcId & "]")
        '        Try
        '            OpcSrvRota.Disconnect()
        '            OpcSrvRota = Nothing
        '            Return False
        '        Catch : End Try
        '    End If

        'Next

        ''Ok
        'Try
        '    OpcSrvRota.Disconnect()
        '    OpcSrvRota = Nothing
        'Catch : End Try

        Return True

    End Function

    Function PlcEnviaOpcMonta(ByVal CircNum As Integer)

        Dim EndReceita = "", EndPlanej = "", EndRotaPlc1 = "", EndRotaPlc2 = "", EndRotaPlc6 As String = "", EndRotaVazao As String = ""
        MontaEnderecos(CircNum, EndReceita, EndPlanej, EndRotaPlc1, EndRotaPlc2, EndRotaPlc6, EndRotaVazao)


        'Monta o grupo de tags OPC
        OpcCipEnv = New OPCAutomation.OPCServer
        OpcCipEnv.Connect(OPC_SRV_NAME)


        'Receitas
        PlcEnviaOpcMontaItem(OpcGrupoRec, cnstGroupRec, EndReceita)

        'Planejamento
        PlcEnviaOpcMontaItem(OpcGrupoPlan, cnstGroupPlan, EndPlanej)

        'Rota PLC AS1, AS2 e AS3
        PlcEnviaOpcMontaItem(OpcGrupoRtAs1, cnstGroupRtAs1, EndRotaPlc1)
        PlcEnviaOpcMontaItem(OpcGrupoRtAs2, cnstGroupRtAs2, EndRotaPlc2)

        'Vazao da Rota
        'PlcEnviaOpcMontaItem(OpcGrupoRtAs1, cnstGroupRtAs1, EndRotaVazao)

        Return True

    End Function

    Function PlcEnviaOpcMontaItem(ByRef OpcGrp As OPCAutomation.OPCGroup, ByVal GrpNome As String, ByVal EndStr As String)

        'Receitas
        Dim Hndl As Integer
        OpcGrp = OpcCipEnv.OPCGroups.Add(GrpNome)
        OpcGrp.UpdateRate = 10000

        Try
            With OpcGrp.OPCItems

                .AddItem(EndStr, Hndl)

            End With
        Catch
            LogAdd("Houve uma falha inserindo itens no OpcGroup " & GrpNome)
            Return False
        End Try

        OpcGrp.IsActive = True
        OpcGrp.UpdateRate = 500
        OpcGrp.IsSubscribed = True

        Return True

    End Function

    Function MontaEnderecos(ByVal Circ As Integer, ByRef outEndReceita As String, ByRef outEndPlanej As String,
                            ByRef outEndRotaPlc1 As String, ByRef outEndRotaPlc2 As String, ByRef outEndRotaPlc6 As String, ByRef outEndRotaVazao As String) As Boolean

        ''S7:[Opc2]DB200,W0,200
        'If Circ < 3 Then

        '    'CIP A, B e C
        '    'DB200, DB201, DB202
        '    outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 200 + Circ & ",W0,200"
        '    outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 200 + Circ & ",W400,20"

        '    'DB211, DB221, DB231
        '    outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 211 + 10 * Circ & ",W0,140"
        '    outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 211 + 10 * Circ & ",W0,140"

        'Else

        '    'CIP D e E
        '    'DB205, DB206
        '    outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 200 + Circ + 2 & ",W0,200"
        '    outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 200 + Circ + 2 & ",W400,20"

        '    'DB251, DB261
        '    outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 221 + 10 * Circ & ",W0,140"
        '    outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 221 + 10 * Circ & ",W0,140"

        'End If

        'Return True

        Select Case Circ

            Case 0
                'Cip A
                'DbNum = 200

                'DB200
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 200 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 200 & ",W400,20"

                'DB211
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 211 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 211 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 211 & ",REAL280"

            Case 1
                'Cip B
                'DbNum = 201

                'DB201
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 201 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 201 & ",W400,20"

                'DB221
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 221 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 221 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 221 & ",REAL280"

            Case 2
                'Cip C
                'DbNum = 202

                'DB202
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 202 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 202 & ",W400,20"

                'DB231
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 231 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 231 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 231 & ",REAL280"

            Case 3
                'Cip D
                'DbNum = 205

                'DB205
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 205 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 205 & ",W400,20"

                'DB251
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 251 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 251 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 251 & ",REAL280"

            Case 4
                'Cip E
                'DbNum = 206

                'DB206
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 206 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 206 & ",W400,20"

                'DB261
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 261 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 261 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 261 & ",REAL280"

            Case 5
                'Cip CA
                'DbNum = 300

                'DB300
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 300 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 300 & ",W400,20"

                'DB311
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 320 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 350 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 320 & ",REAL280"

            Case 6
                'Cip CB
                'DbNum = 301

                'DB301
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 301 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 301 & ",W400,20"

                'DB321
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 321 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 351 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 321 & ",REAL280"

            Case 7
                'Cip CC
                'DbNum = 302

                'DB302
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 302 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 302 & ",W400,20"

                'DB331
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 322 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 352 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 322 & ",REAL280"

            Case 8
                'Cip CD
                'DbNum = 303

                'DB303
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 303 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 303 & ",W400,20"

                'DB341
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 323 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 353 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 323 & ",REAL280"

            Case 9
                'Cip CE
                'DbNum = 304

                'DB304
                outEndReceita = "S7:[" & PlcTopicoAs1 & "]DB" & 304 & ",W0,200"
                outEndPlanej = "S7:[" & PlcTopicoAs1 & "]DB" & 304 & ",W400,20"

                'DB351
                outEndRotaPlc1 = "S7:[" & PlcTopicoAs1 & "]DB" & 324 & ",W0,140"
                outEndRotaPlc2 = "S7:[" & PlcTopicoAs2 & "]DB" & 354 & ",W0,140"

                'DB VAZAO
                'outEndRotaVazao = "S7:[" & PlcTopicoAs1 & "]DB" & 324 & ",REAL280"

        End Select

        Return True

    End Function

    Function PlcEnviaOpcMontaRota(ByRef OpcSrv As OPCAutomation.OPCServer, ByVal Topico As String, ByVal EndRota As String) As Boolean

        'Dim Conta As Integer

        ''Monta o grupo de tags OPC
        'OpcSrv.Connect(OPC_SRV_NAME)

        'Dim OpcGrupo As OPCAutomation.OPCGroup = OpcSrv.OPCGroups.Add()
        'OpcGrupo.UpdateRate = 10000

        'Try

        '    With OpcGrupo.OPCItems

        '        Dim NumItems As Int32 = 126
        '        Dim itemIDs(NumItems) As String
        '        Dim clientHandles(NumItems) As Int32
        '        Dim reqTypes(NumItems) As Int16
        '        Dim accessPaths(NumItems) As String
        '        Dim serverHandles As Array = Nothing
        '        Dim errors As Array = Nothing

        '        'posicao 1 até 3
        '        'Tanques que participam do CIP
        '        For Conta = 0 To ROTA_MAX_TQ - 1

        '            itemIDs(Conta + 1) = OpcTagMonta(Topico, EndRota & ".TnqCip[" & Conta & "]")

        '        Next

        '        'posicao 4 até 6
        '        'Tanques dos quais o CIP depende
        '        For Conta = 0 To ROTA_MAX_DEPEND - 1

        '            itemIDs(Conta + 4) = OpcTagMonta(Topico, EndRota & ".TnqBloq[" & Conta & "]")

        '        Next

        '        'posicao 7 até 16
        '        'Placas de fluxo
        '        For Conta = 0 To ROTA_MAX_PF - 1

        '            itemIDs(Conta + 7) = OpcTagMonta(Topico, EndRota & ".PX[" & Conta & "]")

        '        Next

        '        'posicao 17 até 116
        '        'Valvulas
        '        For Conta = 0 To ROTA_MAX_VALV - 1

        '            itemIDs(Conta + 17) = OpcTagMonta(Topico, EndRota & ".Valv[" & Conta & "]")

        '        Next

        '        'posicao 117 até 126
        '        'Motores
        '        For Conta = 0 To ROTA_MAX_MOTOR - 1

        '            itemIDs(Conta + 117) = OpcTagMonta(Topico, EndRota & ".Mot[" & Conta & "]")

        '        Next

        '        'Cria tags no OPC Rslinx
        '        OpcGrupo.OPCItems.AddItems(NumItems, itemIDs, clientHandles, serverHandles, errors, reqTypes, accessPaths)

        '    End With

        'Catch
        '    LogAdd("Houve uma falha inserindo itens no OpcGroup Topico " & Topico)
        '    Return False
        'End Try

        'OpcGrupo.IsActive = True
        'OpcGrupo.UpdateRate = 500
        'OpcGrupo.IsSubscribed = True

        Return True

    End Function

    Function GetTipoValv(ByVal TipoTxt As String) As Integer

        Dim ValorTipo As Integer = 0

        If TipoTxt = "A" Then
            ValorTipo = 1050
        ElseIf TipoTxt = "N" Then
            ValorTipo = 500
            'ALterado Projeto TETRIS para conseguir usar o Flip tipo Dreno (AGora qualquer flip cadastrado ira funcionar)
        ElseIf (TipoTxt <> "A") And (TipoTxt <> "N") Then
            ValorTipo = PesquisaFlip(TipoTxt)
        End If

        Return ValorTipo

    End Function

    Function PesquisaFlip(ByVal TipoFlip As String) As Integer

        Dim Codigo As Integer = 0

        Dim myFlip = (From It In dtFlipCad Where It.Tipo = TipoFlip).ToList

        If myFlip.Count <= 0 Then
            Codigo = 1001
        Else
            Codigo = myFlip(0).Codigo
        End If

        Return Codigo

    End Function

    Function GetTipoMot(ByVal TipoTxt As String) As Integer

        Dim ValorTipo As Integer = 0

        If TipoTxt = "BB" Then
            ValorTipo = 1041
        ElseIf TipoTxt = "BR" Then
            ValorTipo = 1042
        ElseIf TipoTxt = "AG" Then
            ValorTipo = 1043
        Else
            ValorTipo = 1042
        End If

        Return ValorTipo

    End Function

    Function ConvBytesWord(ByVal MyInt1 As Integer, ByVal MyInt2 As Integer) As Long

        Dim MyLng1 As Long
        Dim MyLng2 As Long

        MyLng1 = MyInt1
        MyLng2 = MyInt2

        If MyInt1 = 0 And MyInt2 = 0 Then

            Return 0

        End If

        Dim MyLong As Long = MyLng1 * &H100 + MyLng2
        If MyLong > 32767 Then MyLong = MyLong - (CLng(32767) * 2) - 2

        Return MyLong

    End Function

End Module

Public Class clsRotaPlc

    Private mCol As Collection

    Public PlcId As Integer

    Public ItemConta As Integer
    Public lstItens((MAX_ITENS_ROTA * 2) - 1) As Integer

    Public Function Add(ByVal Idx As Integer, ByVal Tipo As Integer) As Boolean

        If ItemConta >= MAX_ITENS_ROTA Then Return False

        'Guarda o item na lista
        lstItens(ItemConta * 2) = Idx
        lstItens(ItemConta * 2 + 1) = Tipo

        'Incrementa contador
        ItemConta = ItemConta + 1

        Return True

    End Function

End Class

Public Class clsBloco

    Public NumeroDoBloco As Integer
    Public Descricao As String
    Public MyParametros As New clsParametros
    Public Mnemonico As String

    Public Function LeModelo(ByVal Area As String, ByVal BlkNum As Integer) As Boolean

        Dim Param As clsParametro

        Dim DbRc As New Geral.nsReceitas.dcReceitas
        Dim dtBlocos = (From It In DbRc.Blocos Where It.Area = "CIP" And It.BlkNum = BlkNum).ToList
        If dtBlocos.Count <= 0 Then Return False

        NumeroDoBloco = BlkNum
        Descricao = dtBlocos(0).BlkDescr
        Mnemonico = dtBlocos(0).Mnemonico


        Dim dtBlocosItens = (From It In DbRc.BlocosItens Where It.Area = "CIP" And It.BlkNum = BlkNum Order By It.ItemSeq).ToList

        For Each Prm In dtBlocosItens

            Param = MyParametros.Add

            Try
                Param.Descricao = Prm.ItemDescr
                Param.UnidadeEngenharia = Prm.UEng
                Param.ValorDefault = Prm.ValorDefault
                Param.Valor = Prm.ValorDefault
                Param.Multiplic = Prm.Multiplic
                Param.FlagPeso = Prm.FlagPeso
            Catch : End Try

        Next

        Return True

    End Function

    'Function MyParametros(ByVal Idx As Integer) As clsParametros

    '    Return Me.MyParametros(Idx)

    'End Function

End Class

Public Class clsParametro

    Public Descricao As String
    Public UnidadeEngenharia As String
    Public ValorDefault As Double
    Public Multiplic As Double
    Public Valor As Double
    Public FlagPeso As Boolean

End Class

Public Class clsParametros

    Private mCol As Collection

    Public Function Add(Optional ByVal sKey As String = "") As clsParametro
        'create a new object
        Dim objNewMember As clsParametro
        objNewMember = New clsParametro

        'set the properties passed into the method
        If Len(sKey) = 0 Then
            mCol.Add(objNewMember)
        Else
            mCol.Add(objNewMember, sKey)
        End If

        'return the object created
        Add = objNewMember
        objNewMember = Nothing

    End Function

    Default Public Property Item(ByVal vntIndexKey As Integer) As clsParametro
        Get
            Item = mCol(vntIndexKey)
        End Get
        Set(ByVal value As clsParametro)

        End Set
    End Property

    Public Property Count() As Long
        Get
            Count = mCol.Count
        End Get
        Set(ByVal value As Long)

        End Set
    End Property

    Public Sub Remove(ByVal vntIndexKey As Object)
        'used when removing an element from the collection
        'vntIndexKey contains either the Index or Key, which is why
        'it is declared as a Variant
        'Syntax: x.Remove(xyz)

        mCol.Remove(vntIndexKey)
    End Sub

    Public Sub New()
        'creates the collection when this class is created
        mCol = New Collection
    End Sub

    Protected Overrides Sub Finalize()
        'destroys collection when this class is terminated
        mCol = Nothing
    End Sub

End Class