Imports System.ServiceModel
Imports System.Runtime.Serialization

<DataContract()> Public Class clsMistD

    <DataMember()> Public Dados As New List(Of clsMistDIt)

    <DataMember()> Public ContaD As Integer
    <DataMember()> Public LeituraDadosPlc As Boolean

End Class

<DataContract()> Public Class clsMistDIt

    Public Enum enmTqTipo As Integer
        Tanque = 0
        Past = 1
        Dosagem = 2
        Relogio = 3
    End Enum

    <DataMember()> Public TqId As Integer = 0
    <DataMember()> Public TqNome As String = ""
    <DataMember()> Public DBDados As String = ""
    <DataMember()> Public DBSts As String = ""
    <DataMember()> Public Tipo As enmTqTipo = 0

    Public MistT As OPCAutomation.OPCItem
    Public MistTSts As OPCAutomation.OPCItem

End Class