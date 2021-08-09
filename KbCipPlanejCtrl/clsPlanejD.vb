Imports System.ServiceModel
Imports System.Runtime.Serialization

<DataContract()> Public Class clsPlanejD

    <DataMember()> Public Dados As New List(Of clsPlanejDados)

    <DataMember()> Public ContaD As Integer
    <DataMember()> Public LeituraDadosPlc As Boolean

End Class

<DataContract()> Public Class clsPlanejDados

    <DataMember()> Public Exec As Boolean = False
    <DataMember()> Public CircNum As Integer = 0
    <DataMember()> Public CipId As Integer = 0

    <DataMember()> Public Sts As Integer = 0
    <DataMember()> Public RotaId As Integer = 0
    <DataMember()> Public RecNum As Integer = 0

    'DB240
    <DataMember()> Public Vazao As Double = 0
    <DataMember()> Public Temp As Double = 0
    <DataMember()> Public Cond As Double = 0
    <DataMember()> Public BlkNum As Integer = 0
    <DataMember()> Public BlkPasso As Integer = 0
    <DataMember()> Public Pausa As Boolean = False

    Public LimRev As Integer

    'Status das variaveis que geram eventos (0=Ok; 1=Acima do limite; 2= Abaixo do limite)
    Public TempSts As clsCipVarSts
    Public CondSts As clsCipVarSts
    Public VazaoSts As clsCipVarSts

    Public PausaAnt As Integer
    Public BlkNumAnt As Integer = 0
    Public BlkPassoAnt As Integer = 0

    Public DataPassoIni As New Date(2000, 1, 1)
    Public DataUltGravacao As New Date(2000, 1, 1)

    Public dtCadRotasLim As New List(Of Geral.nsCipValid.CadRotasLim)

    Sub New(ByVal CircNum As Integer, ByVal Exec As Boolean)

        Me.CircNum = CircNum
        Me.Exec = Exec

    End Sub

    Function BuscaRotaDados(ByVal CircNum As Integer) As Boolean

        'Busca a identificacao da rota deste gurpo que esta em execucao
        Dim Circ As String = Geral.CircTxt(CircNum)
        Dim DbCv As New Geral.nsCipValid.dcCipValid
        Dim dtCipHist = (From It In DbCv.CipHist Where It.Status <= 1 And It.Circ = Circ).ToList
        If dtCipHist.Count <= 0 Then Return False

        CipId = dtCipHist(0).CipId
        RotaId = dtCipHist(0).RotaId
        LimRev = dtCipHist(0).LimRev

        'Variaveis de status de eventos
        TempSts = 0
        CondSts = 0
        VazaoSts = 0
        DataUltGravacao = New Date(2000, 1, 1)
        DataPassoIni = New Date(2000, 1, 1)

        dtCadRotasLim = (From It In DbCv.CadRotasLim Where It.RotaId = RotaId And It.LimRev = LimRev Order By It.BlkNum).ToList

        Return True

    End Function

End Class

Public Enum clsCipVarSts

    Ok = 0
    Acima = 1
    Abaixo = 2

End Enum
