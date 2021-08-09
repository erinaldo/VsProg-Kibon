Public Class clsPlcLeReceitas

    Public TrataAreaRec As New Geral.clsTrataArea()

    Public Formula As String = ""
    Public tqNome As String = ""
    Public tqDescr As String = ""
    Public EndStatus As String = ""
    Public EndPlanejamento As String = ""
    Public Endproduzido As String = ""
    Public RecAlergenicos As String = String.Empty
    Public EndAlerg As String = String.Empty

    Public Const cnstServerOpcGrupoRec = "ProdPlanejRec"
    Public Const cnstServerOpcGrupoRecId = 0
    Public Const cnstServerOpcGrupoPlan = "ProdPlanejPlan"
    Public Const cnstServerOpcGrupoPlanId = 1
    Public Const cnstServerOpcGrupoAlerg = "ProdPlanejAlerg"
    Public Const cnstServerOpcGrupoAlergId = 2


    Public Sub New(ByVal EndAlergenicos As String, ByVal Alergenicos As String, ByVal Formula As String, Optional ByVal tqNome As String = "", Optional ByVal tqDescr As String = "", Optional ByVal EndStatus As String = "",
                         Optional ByVal EndPlanejamento As String = "", Optional ByVal Endproduzido As String = "")

        Me.Formula = Formula
        Me.tqNome = tqNome
        Me.tqDescr = tqDescr
        Me.EndStatus = EndStatus
        Me.EndPlanejamento = EndPlanejamento
        Me.Endproduzido = Endproduzido
        Me.RecAlergenicos = Alergenicos
        Me.EndAlerg = EndAlergenicos

    End Sub

    Function PlcLeDados(ByRef outMsg As String, ByRef Alergenicos As String) As clsResultadosLidos

        Dim OpcSrv As New OPCAutomation.OPCServer

        Dim Values As New Object()
        Dim ValuesAlerg As New Object()

        Dim BrixDouble As Double = 0
        Dim RecNum As Double = 0
        Dim RetOpc As Boolean = False
        Dim RetPocPlanej As Boolean = False
        Dim RetAlerg As Boolean = False

        Values = Nothing

        TrataAreaRec.AreaLe(Formula)

        'Monta grupo de tags no OPC
        RetOpc = PlcLeOpcMonta(OpcSrv, TrataAreaRec.AreaDados("RslinxTopic"), EndStatus, EndPlanejamento, EndAlerg)
        If RetOpc = False Then Return Nothing

        'Lendo dados do planejamento
        RetPocPlanej = OpcGrupoLe(OpcSrv.OPCGroups(cnstServerOpcGrupoPlanId), Values)
        If RetPocPlanej = False Then
            'Falha na comuniação
            outMsg = "Falha de comunicação com PLC [" & TrataAreaRec.AreaDados("RslinxTopic") & "]"
            Return Nothing
        End If

        'LENDO ALERGENICOS DA ECEITA DO TANQUE
        RetAlerg = OpcGrupoLe(OpcSrv.OPCGroups(cnstServerOpcGrupoAlergId), ValuesAlerg)
        If RetAlerg = False Then
            'Falha na comuniação
            outMsg = "Falha de comunicação com PLC [" & TrataAreaRec.AreaDados("RslinxTopic") & "]"
            Return Nothing
        End If

        OpcSrv.Disconnect()

        'Carregando os Dados lidos
        outMsg = "Receita carregada com sucesso."
        Return New clsResultadosLidos(Values(1), Values(2), Values(3), Values(4), Values(5), TrataAreaRec.AreaDados("UsaPlanejBrix"), ValuesAlerg)

    End Function

    Function PlcLeOpcMonta(ByRef OpcSrv As OPCAutomation.OPCServer, ByVal Topico As String, ByVal EndRec As String, ByVal EndPlanej As String, ByVal EndAlerg As String) As Boolean

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

                PlanT = .AddItem(EndAlerg, Hndl)

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

        Return True

    End Function

End Class

Public Class clsResultadosLidos

    Public tamanhoBatch As Double
    Public totalProd As Double
    Public Produzido As Double
    Public BrixDouble As Double
    Public RecNum As Double
    Public UsaPlanejBrix As Integer
    Public Alergenicos As String

    Sub New(ByVal tamanhoBatch As Double, ByVal totalProd As Double, ByVal Produzido As Double, ByVal BrixDouble As Double, ByVal RecNum As Integer, ByVal UsaPlanejBrix As Integer, ByVal Alergenicos As String)

        Me.tamanhoBatch = tamanhoBatch
        Me.totalProd = totalProd
        Me.Produzido = Produzido
        Me.BrixDouble = BrixDouble
        Me.RecNum = RecNum
        Me.UsaPlanejBrix = UsaPlanejBrix
        Me.Alergenicos = Alergenicos

    End Sub

End Class