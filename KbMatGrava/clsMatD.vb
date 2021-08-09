Imports System.ServiceModel
Imports System.Runtime.Serialization

<DataContract()> Public Class clsMatD

    <DataMember()> Public Dados As New List(Of clsMatDIt)

    <DataMember()> Public ContaD As Integer
    <DataMember()> Public LeituraDadosPlc As Boolean

End Class

<DataContract()> Public Class clsMatDIt

    <DataMember()> Public Tq As Integer = 0

    <DataMember()> Public Te As Double = 0
    <DataMember()> Public CodProd As Integer = 0
    <DataMember()> Public Hr As Double = 0
    <DataMember()> Public Cn As Integer = 0
    <DataMember()> Public SeqTq As Integer = 0

    Public TeAddr As Integer = 0
    Public CodProdAddr As Integer = 0
    Public HrAddr As Integer = 0
    Public CnAddr As Integer = 0

    Public TeT As OPCAutomation.OPCItem
    Public CodProdT As OPCAutomation.OPCItem
    Public HrT As OPCAutomation.OPCItem
    Public CnT As OPCAutomation.OPCItem


    Sub New(Tq As Integer, TeAddr As Integer, CodProdAddr As Integer, HrAddr As Integer, CnAddr As Integer)

        Me.Tq = Tq

        Me.TeAddr = TeAddr
        Me.CodProdAddr = CodProdAddr
        Me.HrAddr = HrAddr
        Me.CnAddr = CnAddr

        'Busca a sequencia atual
        Dim DbMa As New Geral.nsMatGrava.dcMatGrava
        Dim dtMatHistDados = (From It In DbMa.MatHistDados Where It.Tq = Tq
                              Order By It.DataHora Descending).ToList.Take(1).ToList
        If dtMatHistDados.Count > 0 Then
            SeqTq = dtMatHistDados.First.SeqTq
        End If

    End Sub

End Class