Public Class clsPlcEnviaReceitas

    Public Rc As New Geral.nsReceitas.dcReceitas

    Public TrataAreaRec As New Geral.clsTrataArea()

    Public lstLetrasAlergTank As List(Of LetrasAlergTank)
    Public lstLetrasAlergRecNova As List(Of LetrasAlergRecNova)

    'Número de parametros a serem enviados por bloco do PLC
    Public NumParametrosPorBloco = 9

    'Estados da receita no PLC
    Public Const RECEITA_PARADA = 0
    Public Const RECEITA_DOWNLOAD = 1
    Public Const RECEITA_INICIO = 2
    Public Const RECEITA_EXECUCAO = 3
    Public Const RECEITA_CIPADO = 8


    Public Formula As String = ""
    Public EndReceita As String = ""
    Public VarBrix As String = ""
    Public EndStatus As String = ""
    Public EndPlanejamento As String = ""
    Public RecNum As Integer = 0
    Public RecNome As String = ""
    Public RecCodigo As String = 0
    Public RecDensidade As Double = 0

    'Alergenicos
    Public RecAlergenicos As String = String.Empty
    Public EndAlerg As String = String.Empty

    'Pressoes dos estagios 01 e 02
    Public EndPressao01 As String = String.Empty
    Public ValorPressao01 As Integer = 0

    Public EndPressao02 As String = String.Empty
    Public ValorPressao02 As Integer = 0

    Dim MyReceita As clsBlocos
    Public Const cnstServerOpcGrupoRec = "ProdPlanejRec"
    Public Const cnstServerOpcGrupoRecId = 0
    Public Const cnstServerOpcGrupoPlan = "ProdPlanejPlan"
    Public Const cnstServerOpcGrupoPlanId = 1
    Public Const cnstServerOpcGrupoAlerg = "ProdPlanejAlerg"
    Public Const cnstServerOpcGrupoAlergId = 2
    Public Const cnstServerOpcGrupoPressoesStg01 = "ProdPlanejPressoesStg01"
    Public Const cnstServerOpcGrupoPressoesStg01Id = 3
    Public Const cnstServerOpcGrupoPressoesStg02 = "ProdPlanejPressoesStg02"
    Public Const cnstServerOpcGrupoPressoesStg02Id = 4

    Public Sub New(ByVal EndPressao01 As String, ByVal ValorPressao01 As Integer, ByVal EndPressao02 As String, ByVal ValorPressao02 As Integer, ByVal EndAlergenicos As String, ByVal Alergenicos As String, ByVal Formula As String, ByVal EndReceita As String, ByVal VarBrix As String, Optional ByVal EndStatus As String = "", Optional ByVal EndPlanejamento As String = "", Optional ByVal RecNum As Integer = 0,
                         Optional ByVal RecNome As String = "", Optional ByVal RecCodigo As Integer = 0, Optional Densidade As Double = 0)

        Me.Formula = Formula
        Me.EndReceita = EndReceita
        Me.VarBrix = VarBrix
        Me.EndStatus = EndStatus
        Me.EndPlanejamento = EndPlanejamento
        Me.RecNum = RecNum
        Me.RecNome = RecNome
        Me.RecCodigo = RecCodigo
        Me.RecDensidade = Densidade
        Me.RecAlergenicos = Alergenicos
        Me.EndAlerg = EndAlergenicos

        Me.EndPressao01 = EndPressao01
        Me.ValorPressao01 = ValorPressao01

        Me.EndPressao02 = EndPressao02
        Me.ValorPressao02 = ValorPressao02

    End Sub

    Function PlcEnviaDados(TamanhoBatch As Integer, TotalProduzir As Integer, ByRef outMsg As String) As Boolean

        Dim Ret As Boolean = False
        Dim Rec(399) As Object
        'Dim ListaDadosP1(99) As VariantType
        'Dim ListaDadosP2(99) As VariantType
        'Dim ListaDadosP3(49) As VariantType
        Dim OpcSrv As New OPCAutomation.OPCServer

        Dim Values As Object = ""
        Dim ValuesAlergTank As Object = ""
        Dim ValuesPressao01 As Object = ""
        Dim ValuesPressao02 As Object = ""

        Dim FlagAlergDifTank As Integer = 0
        Dim StrAlergMsg As String = String.Empty

        lstLetrasAlergTank = New List(Of LetrasAlergTank)
        lstLetrasAlergRecNova = New List(Of LetrasAlergRecNova)

        'Consistencia de dados
        Ret = EnvConsist()
        If Ret = False Then Return False

        'Montando a receita
        ReceitaAbre(RecNum)

        'Verificando se nao ha mais de 255 elementos na receita (blocos+parametros)
        If MyReceita.mCol.Count > 40 Then
            outMsg = "Erro tamanho da receita foi excedido. " & Chr(13) & _
                "Esta receita possui " & MyReceita.mCol.Count & "blocos." & Chr(13) & _
                "O tamanho maximo é de 12 blocos."
            Return False
        End If

        MontaReceita(Rec)

        Dim BatchIdNovo As Integer = BuscaBatchIdNovo()
        If BatchIdNovo <= 0 Then
            outMsg = "Erro: a identificacao do batch nao foi gerada."
            Return False
        End If

        Dim BatchIdH As Integer, BatchIdL As Integer
        ConvLongInts(BatchIdNovo, BatchIdH, BatchIdL)

        '########   Comunicando com o plc   ########

        'MONTA GRUPO DE TAGS DAS INFORMACOES QUE SERAO ESCRITAS NO PLC
        Ret = PlcEnviaOpcMonta(OpcSrv, EndStatus, EndPlanejamento, EndAlerg, EndPressao01, EndPressao02)
        If Ret <> True Then Return False


        'Dim Valuesz = PlanT.Value

        Dim RetSts As Boolean = OpcGrupoLe(OpcSrv.OPCGroups(cnstServerOpcGrupoPlanId), Values)
        If RetSts <> True Then
            'Falha na comunicacao
            OpcSrv.Disconnect()
            outMsg = "Erro - Comunicacao com PLC [" & TrataAreaRec.AreaDados("RslinxTopic") & "] nao foi estabelecida"
            Return False
        End If

        'Verificando o status atual
        If (Values(0) <> RECEITA_PARADA) And _
           (Values(0) <> RECEITA_CIPADO) Then
            OpcSrv.Disconnect()
            outMsg = "Erro - Receita nao se encontra com status 'Parada'"
            Return False
        End If

        '------------------------VERIFICA ALERGENICOS------------------------------

        If RecAlergenicos.ToString <> "" Then

            Dim RetStsAlerg As Boolean = OpcGrupoLe(OpcSrv.OPCGroups(cnstServerOpcGrupoAlergId), ValuesAlergTank)
            If RetStsAlerg <> True Then
                OpcSrv.Disconnect()
                outMsg = "Erro - Comunicacao com PLC [" & TrataAreaRec.AreaDados("RslinxTopic") & "] nao foi estabelecida"
                Return False
            End If

            StrAlergMsg = "Receita do Tanque:           " & ValuesAlergTank & Chr(13) & "Receita a ser Planejada:   " & RecAlergenicos.ToString

            For contAleg As Integer = 0 To RecAlergenicos.ToString.Length - 1
                lstLetrasAlergRecNova.Add(New LetrasAlergRecNova(RecAlergenicos(contAleg).ToString))
            Next

            'VERIFICA SE OS ALERGENICOS DA NOVA RECEITA EXISTEM NA RECEITA ANTERIOR DO TANQUE
            For contAlergTank As Integer = 0 To ValuesAlergTank.ToString.Length - 1

                Dim dtVerifAlerg = (From It In lstLetrasAlergRecNova Where It.Letra = ValuesAlergTank(contAlergTank).ToString).ToList
                If dtVerifAlerg.Count = 0 Then
                    FlagAlergDifTank = FlagAlergDifTank + 1
                End If

            Next
            'QUANTIDADE DE ALERGENICOS DIFERENTE PARA A NOVA RECEITA
            If FlagAlergDifTank <> 0 Then
                outMsg = "O tanque precisa ser limpo com CIP." & Chr(13) & "Presença de Alergënico(s)." & Chr(13) & Chr(13) & StrAlergMsg
                Return False
            End If

            ValuesAlergTank = RecAlergenicos

            'Dim RetAlerg = ChkAlerg(Values(5), RecNum, outMsg)
            'If RetAlerg = False Then Return False

        End If

        '------------------------FIM VERIFICA ALERGENICOS------------------------------

        '-----------------------PRESSOES------------------------------------------

        Dim RetStsPressao01 As Boolean = OpcGrupoLe(OpcSrv.OPCGroups(cnstServerOpcGrupoPressoesStg01Id), ValuesPressao01)
        If RetStsPressao01 <> True Then
            OpcSrv.Disconnect()
            outMsg = "Erro - Comunicacao com PLC [" & TrataAreaRec.AreaDados("RslinxTopic") & "] nao foi estabelecida"
            Return False
        End If

        ValuesPressao01 = ValorPressao01

        Dim RetStsPressao02 As Boolean = OpcGrupoLe(OpcSrv.OPCGroups(cnstServerOpcGrupoPressoesStg02Id), ValuesPressao02)
        If RetStsPressao02 <> True Then
            OpcSrv.Disconnect()
            outMsg = "Erro - Comunicacao com PLC [" & TrataAreaRec.AreaDados("RslinxTopic") & "] nao foi estabelecida"
            Return False
        End If

        ValuesPressao02 = ValorPressao02

        '---------------------PRESSOES FIM----------------------------------------

        'Montando o planejamento
        'Monta planejamento
        Values(0) = RECEITA_INICIO
        Values(1) = Val(TamanhoBatch)
        Values(2) = Val(TotalProduzir)
        Values(3) = 0
        Values(4) = Values(4)
        Values(5) = 0

        Values(5) = RecNum
        'Nome da receita de CIP
        For Conta = 0 To 14
            Dim MyInt1 As Integer = 0
            Dim MyInt2 As Integer = 0
            Dim Pos1 As Integer = (Conta * 2) + 1
            Dim Pos2 As Integer = Pos1 + 1
            Dim MyLong As Long

            Dim Txt As String = "AA" & RecCodigo
            If Txt.Count >= Pos1 Then MyInt1 = Asc(Mid(Txt, Pos1, 1))
            If Txt.Count >= Pos2 Then MyInt2 = Asc(Mid(Txt, Pos2, 1))

            ConvBytesWord(MyLong, MyInt1, MyInt2)
            Values(Conta + 6) = CInt(MyLong)

        Next

        Values(22) = RecDensidade * 100

        ConvLongInts(BatchIdNovo, BatchIdH, BatchIdL)
        Values(23) = BatchIdH
        Values(24) = BatchIdL

        'Envia a receita
        Ret = OpcGrupoEscreve(OpcSrv.OPCGroups(cnstServerOpcGrupoRecId), Rec)
        If Ret <> True Then
            OpcSrv.Disconnect()
            outMsg = "Erro - houve falha no envio da receita"
            Return False
        End If


        'Enviando o planejamento
        Ret = OpcGrupoEscreve(OpcSrv.OPCGroups(cnstServerOpcGrupoPlanId), Values)
        If Ret <> True Then
            OpcSrv.Disconnect()
            outMsg = "Erro - houve falha no envio do planejamento de producao"
            Return False
        End If

        'Verificando se houve falha no envio da receita
        If Ret = False Then

            Values(0) = RECEITA_PARADA
            'OpcSrv.OPCGroups(0).OPCItems(1).Write(Values(1))
            OpcGrupoEscreve(OpcSrv.OPCGroups(cnstServerOpcGrupoPlanId), Values)

            OpcSrv.Disconnect()
            outMsg = "Erro - houve falha no envio do planejamento de producao"
            Return False

        End If

        'ENVIANDO ALERGENICOS 
        If RecAlergenicos.ToString <> "" Then

            Ret = OpcGrupoEscreve(OpcSrv.OPCGroups(cnstServerOpcGrupoAlergId), ValuesAlergTank)
            If Ret <> True Then
                OpcSrv.Disconnect()
                outMsg = "Erro - houve falha no envio do(s) Alergënico(s) da receita de produção"
                Return False
            End If

        End If

        'ENVIANDO PRESSOES 01
        Ret = OpcGrupoEscreve(OpcSrv.OPCGroups(cnstServerOpcGrupoPressoesStg01Id), ValuesPressao01)
        If Ret <> True Then
            OpcSrv.Disconnect()
            outMsg = "Erro - houve falha no envio das pressoes dos estagios 01"
            Return False
        End If

        'ENVIANDO PRESSOES 02
        Ret = OpcGrupoEscreve(OpcSrv.OPCGroups(cnstServerOpcGrupoPressoesStg02Id), ValuesPressao02)
        If Ret <> True Then
            OpcSrv.Disconnect()
            outMsg = "Erro - houve falha no envio das pressoes dos estagios 02"
            Return False
        End If

        'Passa status para RECEITA_INICIO
        Values(0) = RECEITA_INICIO

        OpcSrv.Disconnect()

        outMsg = "A receita foi enviada ao PLC."

        Return True

    End Function

    Function EnvConsist() As Boolean

        'Consistencia para envio de receita
        EnvConsist = False

        TrataAreaRec.AreaLe(Formula)

        Return True

    End Function

    Function ReceitaAbre(ByVal RecNum As Integer) As Boolean

        Dim MyCol As String = ""
        Dim Area As String = TrataAreaRec.AreaDados("Area")

        'ResetMyBlocos
        MyReceita = New clsBlocos

        'Pegando dados da tabela Receitas
        Dim dtReceita = (From It In Rc.Rec Where It.RecNum = RecNum And It.Area = Area).ToList

        RecNome = dtReceita.First.RecNome
        RecCodigo = dtReceita.First.Codigo

        'Pegando dados da tabela ReceitasBlocos
        Dim dtBlocos = (From It In Rc.RecBlocos Where It.RecNum = RecNum And It.Area = Area).ToList

        For Conta As Integer = 0 To dtBlocos.Count - 1

            'Novo Bloco
            Dim Blk As New clsBloco
            MyReceita.mCol.Add(Blk)
            Blk.LeModelo(TrataAreaRec.AreaDados("Area"), dtBlocos(Conta).BlkNum)

            'Lê o valor de cada parametro

            If Blk.MyParametros.mCol.Count > 0 Then Blk.MyParametros.mCol(0).Valor = dtBlocos(Conta).Param01
            If Blk.MyParametros.mCol.Count > 1 Then Blk.MyParametros.mCol(1).Valor = dtBlocos(Conta).Param02
            If Blk.MyParametros.mCol.Count > 2 Then Blk.MyParametros.mCol(2).Valor = dtBlocos(Conta).Param03
            If Blk.MyParametros.mCol.Count > 3 Then Blk.MyParametros.mCol(3).Valor = dtBlocos(Conta).Param04
            If Blk.MyParametros.mCol.Count > 4 Then Blk.MyParametros.mCol(4).Valor = dtBlocos(Conta).Param05
            If Blk.MyParametros.mCol.Count > 5 Then Blk.MyParametros.mCol(5).Valor = dtBlocos(Conta).Param06
            If Blk.MyParametros.mCol.Count > 6 Then Blk.MyParametros.mCol(6).Valor = dtBlocos(Conta).Param07
            If Blk.MyParametros.mCol.Count > 7 Then Blk.MyParametros.mCol(7).Valor = dtBlocos(Conta).Param08
            If Blk.MyParametros.mCol.Count > 8 Then Blk.MyParametros.mCol(8).Valor = dtBlocos(Conta).Param09

        Next

        Return True

    End Function

    Sub MontaReceita(ByRef ListaDados As Object)

        'Lista os MyReceita e parametros em um array para enviar ao PLC
        For conta = 0 To UBound(ListaDados)
            ListaDados(conta) = 0
        Next

        'Executa para cada bloco da receita
        Dim ContaPos As Integer = 0

        For Each Blk In MyReceita.mCol

            'Adiciona o bloco
            ListaDados(ContaPos) = Blk.NumeroDoBloco
            ContaPos = ContaPos + 1

            Dim ContaParam As Integer = 0
            'Adiciona os parametros do bloco
            For ContaParam = 0 To NumParametrosPorBloco - 1

                'Caso o bloco possua menos parametros que o necessario o resto e' preenchido com zeros
                If ContaParam < Blk.MyParametros.mCol.Count Then
                    'ListaDados(ContaPos) = Blk.MyParametros(ContaParam).Valor
                    ListaDados(ContaPos) = Blk.MyParametros.mCol(ContaParam).Valor * Blk.MyParametros.mCol(ContaParam).Multiplic
                Else
                    ListaDados(ContaPos) = 0
                End If
                ContaPos = ContaPos + 1

            Next

        Next

    End Sub

    Function EnvConsist(ByVal outEndReceita As String, ByVal outEndStatus As String, ByVal outEndPlanejamento As String,
                        ByVal outRecNum As Integer, ByVal outRecNome As String, ByVal outRecCodigo As String,
                        ByRef outMsg As String) As Boolean

        'Verifica se o tanque destino foi selecionado
        Dim Ret As Boolean = frmKbProdPlanejCtrl.DadosTqSel(, , outEndStatus, outEndPlanejamento)
        If Ret = False Then
            outMsg = "Selecione o tanque destino!"
            Return False
        End If


        'Verificando se a receita foi selecionada
        Ret = frmKbProdPlanejCtrl.DadosReceita(outRecNum, outRecNome, outRecCodigo)
        If Ret = False Then
            outMsg = "Selecione a receita a ser enviada!"
            Return False
        End If


        Return True

    End Function

    Function PlcEnviaOpcMonta(ByRef OpcSrv As OPCAutomation.OPCServer, ByVal EndRec As String, ByVal EndPlanej As String, ByVal EndAlerg As String, ByVal EndPressao01 As String, ByVal EndPressao02 As String) As Boolean

        Dim Hndl As Integer

        OpcSrv = New OPCAutomation.OPCServer

        Try
            OpcSrv.OPCGroups.Remove(cnstServerOpcGrupoRec)
            OpcSrv.OPCGroups.Remove(cnstServerOpcGrupoPlan)
        Catch : End Try

        Try

            'Monta o grupo de tags OPC para Poll no CIP Rec
            OpcSrv.Connect(OPC_SRV_NAME)
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupoRec)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoRec).IsActive = False

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupoRec).OPCItems

                'S7:[Opc2]DB191,INT0,40
                RecT = .AddItem(EndRec, Hndl)

            End With

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupoRec).OPCItems.Count <> 1 Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoRec).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoRec).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoRec).IsSubscribed = True


        Catch ex As Exception

            'LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

        End Try



        'Monta o grupo de tags OPC para Poll no CIP Plan
        Try
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupoPlan)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPlan).IsActive = False

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPlan).OPCItems

                'S7:[Opc2]DB191,INT0,40
                PlanT = .AddItem(EndPlanej, Hndl)

            End With

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPlan).OPCItems.Count <> 1 Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPlan).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPlan).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPlan).IsSubscribed = True

        Catch ex As Exception

            'LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

        End Try

        'MONTA GRUPO ALERGENICOS
        Try
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupoAlerg)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoAlerg).IsActive = False

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupoAlerg).OPCItems

                AlergT = .AddItem(EndAlerg, Hndl)

            End With

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupoAlerg).OPCItems.Count <> 1 Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoAlerg).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoAlerg).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoAlerg).IsSubscribed = True

        Catch ex As Exception

            'LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

            End Try


        'MONTA GRUPO PRESSOES 01
        Try
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupoPressoesStg01)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg01).IsActive = False

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg01).OPCItems

                Pressoes01T = .AddItem(EndPressao01, Hndl)

            End With

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg01).OPCItems.Count <> 1 Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg01).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg01).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg01).IsSubscribed = True

        Catch ex As Exception

            'LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

        End Try

        'MONTA GRUPO PRESSOES 02
        Try
            OpcSrv.OPCGroups.Add(cnstServerOpcGrupoPressoesStg02)
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg02).IsActive = False

            With OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg02).OPCItems

                Pressoes02T = .AddItem(EndPressao02, Hndl)

            End With

            If OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg02).OPCItems.Count <> 1 Then
                'MsgBox("Houve uma falha inserindo itens no OpcGroup Poll", MsgBoxStyle.Exclamation)
                Return False
            End If

            'Ok
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg02).UpdateRate = 1000
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg02).IsActive = True
            OpcSrv.OPCGroups.Item(cnstServerOpcGrupoPressoesStg02).IsSubscribed = True

        Catch ex As Exception

            'LogAdd("OpcMontaStsCentral1 - " & ex.Message)
            Return False

        End Try

            Return True

    End Function

    Function BuscaBatchIdNovo() As Long

        Dim DbPg As New Geral.nsPastGrava.dcPastGrava
        Dim dtCfg = (From It In DbPg.Cfg Where It.Item = "BatchIdMistura").ToList

        If dtCfg.Count <= 0 Then

            'Nao encontrado, cria sequencia

            DbPg.Cfg.InsertOnSubmit(New Geral.nsPastGrava.Cfg With {.Item = "BatchIdMistura", .Valor = "1"})
            DbPg.SubmitChanges()

            Return 1

        End If

        'Soma um
        Dim BatchIdNovo As Integer = dtCfg.First.Valor + 1

        dtCfg.First.Valor = BatchIdNovo
        DbPg.SubmitChanges()


        'Retorna o novo numero de batch
        Return BatchIdNovo

    End Function

    Function ChkAlerg(RecNumAnt As Integer, RecNumNovo As Integer, ByRef outMsg As String) As Boolean

        'Caso a receita atual esteja zerada nao precisa verificar, segue em frente pois o CIP foi feito
        If RecNumAnt = 0 Then Return True


        'Busca a receita atual e nova
        Dim Area As String = TrataAreaRec.AreaDados("Area")
        Dim RecCodAnt As String = "", RecCodNova As String = ""
        Dim DbRc As New Geral.nsReceitas.dcReceitas

        Dim dtRecAnt = (From It In DbRc.Rec Where It.Area = Area And It.RecNum = RecNumAnt).ToList
        If dtRecAnt.Count > 0 Then RecCodAnt = dtRecAnt.First.Codigo

        Dim dtRecNova = (From It In DbRc.Rec Where It.Area = Area And It.RecNum = RecNumNovo).ToList
        If dtRecNova.Count > 0 Then RecCodNova = dtRecNova.First.Codigo


        If Trim(RecCodAnt) = "" Or Trim(RecCodNova) = "" Then
            Return True
        End If

        'Caso o codigo seja igual segue em frente
        If Trim(RecCodAnt) = Trim(RecCodNova) Then
            Return True
        End If

        'Busca o codigo atual na lista de alergenicos, caso nao esteja segue a vida
        Dim dtCadAlerg = (From It In DbRc.CadAlergenicos Where It.Codigo = RecCodAnt).ToList
        If dtCadAlerg.Count <= 0 Then
            'Nao encontrado na tabela de alergencios, pode enviar a nova receita
            Return True
        End If

        'Caso a nova receita seja a 175 verificar se pode ser enviada a receita de cõdigo 175
        If RecCodNova = "175" And dtCadAlerg.First.Hab175 = 1 Then
            Return True
        End If



        'O codigo da receita atual esta na lista de alergenicos e a nova receita nao pode ser enviada
        '   antes que o CIP seja feito
        outMsg = "O codigo da receita atual [" & RecCodAnt & "] esta cadastrado na lista de alergenicos." & Chr(13) & _
                "O tanque precisa ser limpo com CIP."

        ChkAlerg = False

    End Function

End Class

Public Class LetrasAlergTank

    Public Letra As String

    Public Sub New(ByVal pLetra As String)
        Me.Letra = pLetra
    End Sub

End Class

Public Class LetrasAlergRecNova

    Public Letra As String

    Public Sub New(ByVal pLetra As String)
        Me.Letra = pLetra
    End Sub

End Class