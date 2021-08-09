Imports System.ServiceModel
Imports System.Runtime.Serialization

<DataContract()> Public Class clsChkIniD

    <DataMember()> Public Dados As New List(Of clsChkIniDIt)

End Class

<DataContract()> Public Class clsChkIniDIt

    <DataMember()> Public ServNome As String = ""
    <DataMember()> Public ContaErro As Integer = 0

    Public Sc As ServiceController

    Sub New(ServNome As String)

        Me.ServNome = ServNome

        Sc = New ServiceController(ServNome)

    End Sub

    Public Function SrvTxt() As String

        Dim Txt As String = ""
        Select Case Sc.Status

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
