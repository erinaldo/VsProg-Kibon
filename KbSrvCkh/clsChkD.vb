Imports System.ServiceModel
Imports System.Runtime.Serialization

<DataContract()> Public Class clsChkD

    <DataMember()> Public Dados As New List(Of clsChkDIt)

End Class

<DataContract()> Public Class clsChkDIt

    <DataMember()> Public ServNome As String = ""
    <DataMember()> Public ContaD As Integer = 0
    <DataMember()> Public ContaDAnt As Integer = -1
    <DataMember()> Public ContaErro As Integer = 0

    Public Sc As ServiceController

    Sub New(ServNome As String, ContaD As Integer)

        Me.ServNome = ServNome
        Me.ContaD = ContaD

        Sc = New ServiceController(ServNome)

    End Sub

    Public Function SrvTxt() As String

        Dim Txt As String = ""
        Select Sc.Status

            Case ServiceControllerStatus.Running
                Txt = "Running"
            Case ServiceControllerStatus.Stopped
                Txt = "Stopped"
            Case ServiceControllerStatus.Paused
                Txt = "Paused"
            Case ServiceControllerStatus.StopPending
                Txt = "Stopping"
            Case ServiceControllerStatus.StartPending
                Txt = "Starting"
            Case Else
                Txt = "Status Changing"
        End Select

        Return Txt

    End Function

End Class
