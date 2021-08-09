Imports System.ServiceModel
Imports System.Runtime.Serialization

<DataContract()> Public Class clsPastD

    <DataMember()> Public Dados As New List(Of clsPastDIt)
    <DataMember()> Public DadosCip As New List(Of clsCipDIt)

    <DataMember()> Public ContaD As Integer
    <DataMember()> Public LeituraDadosPlc As Boolean

End Class

<DataContract()> Public Class clsPastDIt

    <DataMember()> Public PastId As Integer = 0
    <DataMember()> Public HistId As Integer
    <DataMember()> Public FdvId As Integer

    <DataMember()> Public Sts As Integer
    <DataMember()> Public StsAnt As Integer

    <DataMember()> Public RecNum As Integer
    <DataMember()> Public TqOrig As Integer
    <DataMember()> Public TqDest As Integer
    <DataMember()> Public PressaoEst1 As Double
    <DataMember()> Public PressaoEst2 As Double
    <DataMember()> Public TempFdvPv As Double
    <DataMember()> Public TempFdvSp As Double
    <DataMember()> Public TempFinalPast As Double
    <DataMember()> Public PresFinalPast As Double
    <DataMember()> Public ValvFdvA As Integer
    <DataMember()> Public ValvFdvB As Integer
    <DataMember()> Public PresHomoEntr As Double
    <DataMember()> Public PresHomoSaida As Double
    <DataMember()> Public AguaAlcool As Double
    <DataMember()> Public Reserva2 As Double
    <DataMember()> Public Reserva3 As Double
    <DataMember()> Public Reserva4 As Double
    <DataMember()> Public Reserva5 As Double
    <DataMember()> Public Reserva6 As Double

    Sub New(PastId As Integer)

        Me.PastId = PastId

    End Sub

End Class

<DataContract()> Public Class clsCipDIt

    <DataMember()> Public PastId As Integer
    <DataMember()> Public CipId As Integer
    <DataMember()> Public ContaGrava As Integer = 0
    <DataMember()> Public PastStsAnt As Integer = -1

    <DataMember()> Public VazaoPast As Double
    <DataMember()> Public TempPast As Double
    <DataMember()> Public CondPast As Double
    <DataMember()> Public PastSts As Integer
    <DataMember()> Public PastBlkExec As Integer
    <DataMember()> Public PastRec As Integer
    <DataMember()> Public PastRota As Integer
    <DataMember()> Public PastHistSts As Integer

    Sub New(PastId As Integer)

        Me.PastId = PastId
        Inicializa()

    End Sub

    Function Inicializa() As Boolean

        'Inicialização
        Dim DbPg As New Geral.nsPastGrava.dcPastGrava


        'Caso haja um cip rodando quando o programa foi iniciado, busca o último ID não finalizado
        Dim Circ As String = "P" & PastId
        Dim dtCipGravaHist = (From It In DbPg.CipGravaHist Where It.Circ = Circ And It.Fim = 0 Order By It.CipId Descending).Take(1).ToList
        If dtCipGravaHist.Count > 0 Then

            'Já havia um CIP sendo executado, continuar gravando com o mesmo CipId
            PastSts = 2
            PastStsAnt = 2
            CipId = dtCipGravaHist.First.CipId

        End If

        Return True

    End Function

    Public Function TrataPastCip() As Boolean

        If PastStsAnt <> 2 And PastSts = 2 Then

            'Inicializa o histórico de CIP
            CipIni()
            CipGrava()
            ContaGrava = 0

        ElseIf PastSts = 2 Then

            'Grava dados históricos a cada 30 segundos
            ContaGrava = ContaGrava + 1

            If ContaGrava >= 30 Then
                CipGrava()
                ContaGrava = 0
            End If

        ElseIf PastStsAnt = 2 And PastSts <> 2 Then

            'Finaliza o hostórico de CIP
            CipFim()

        End If

        'Guarda o status anterior
        PastStsAnt = PastSts

        Return True

    End Function

    Function BuscaCipIdNovo() As Integer

        'Busca o novo CipId
        Dim CipIdNw As Integer = 1

        'Caso haja um cip rodando quando o programa foi iniciado, busca o último ID não finalizado
        Dim DbPg As New Geral.nsPastGrava.dcPastGrava
        Dim dtCipGravaHist = (From It In DbPg.CipGravaHist Order By It.CipId Descending).Take(1).ToList
        If dtCipGravaHist.Count > 0 Then
            CipIdNw = dtCipGravaHist.First.CipId + 1
        End If

        Return CipIdNw

    End Function

    Function CipIni() As Boolean

        'Busca o novo CipId
        CipId = BuscaCipIdNovo()

        Dim SrtRotaDescr As String = "CIP do Past" & PastId
        Dim StrRecIdDescr As String = ""
        Dim DataHora As String = Format(Geral.TseNow, "yyyyMMddHHmmss")

        'Descricao da receita
        Select Case PastRec

            Case 1
                StrRecIdDescr = "Lavagem com Soda"
            Case 2
                StrRecIdDescr = "Lavagem com Acido"
            Case 3
                StrRecIdDescr = "Lavagem com Soda + Acido"

        End Select


        'Grava no banco de dados
        Dim DbCg As New Geral.nsPastGrava.dcPastGrava

        Dim CipGravaHistNw As New Geral.nsPastGrava.CipGravaHist With {.CipId = CipId, .DataHora = DataHora, .Circ = "P" & PastId,
                                                                      .Fim = 0, .RotaId = PastId, .RotaDescr = SrtRotaDescr,
                                                                      .RecId = PastRec, .RecDescr = StrRecIdDescr}

        DbCg.CipGravaHist.InsertOnSubmit(CipGravaHistNw)
        DbCg.SubmitChanges()

        Return True

    End Function

    Function CipGrava() As Boolean

        Dim DataHora As String = Format(Geral.TseNow, "yyyyMMddHHmmss")

        'Grava dados históricos
        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim CipGravaHistDadosNw As New Geral.nsPastGrava.CipGravaHistDados With {.CipId = CipId, .DataHora = DataHora,
                                                               .Cond = CondPast, .Temp = TempPast, .Vazao = VazaoPast,
                                                               .Blk = PastBlkExec, .Passo = PastHistSts}

        DbPg.CipGravaHistDados.InsertOnSubmit(CipGravaHistDadosNw)
        DbPg.SubmitChanges()

        Return True

    End Function

    Function CipFim() As Boolean

        'Fm do histórico de CIP
        Dim DbPg As New Geral.nsPastGrava.dcPastGrava

        Dim dtCipGravaHist = (From It In DbPg.CipGravaHist Where It.CipId = CipId).Take(1).ToList
        If dtCipGravaHist.Count > 0 Then
            dtCipGravaHist.First.Fim = 1
        End If

        DbPg.SubmitChanges()

        Return True

    End Function

End Class
