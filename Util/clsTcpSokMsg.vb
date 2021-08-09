Public Class clsTcpSokMsg

    Public Cmd As String

    Public Param As New List(Of String)

    Public Sub New()
    End Sub

    Public Sub New(ByVal vData As String)
        SetTxt(vData)
    End Sub

    Public Sub SetTxt(ByVal vData As String)

        Dim NovoParam As String = ""
        Dim Letra As String
        Dim ContaParam As Integer

        'Esta funcao recebe a mensagem com os caracteres de inicio "<" e fim ">"
        ' <Cmd;Param1;Param2>

        Cmd = ""
        Param = New List(Of String)

        For Conta As Integer = 2 To Len(vData)

            Letra = Mid(vData, Conta, 1)

            If Letra = ";" Or _
                Letra = ">" Then

                If ContaParam = 0 Then
                    Cmd = NovoParam
                Else
                    Param.Add(NovoParam)
                End If

                ContaParam = ContaParam + 1
                NovoParam = ""

            Else

                'Adiciona letra ao buffer
                NovoParam = NovoParam & Letra

            End If
        Next

    End Sub

    Public Function GetTxt() As String

        Dim MsgTxt As String
        Dim MyParam As String

        'Inicio
        MsgTxt = "<" & Cmd

        'Parametros
        For Each MyParam In Param

            MsgTxt = MsgTxt & ";" & MyParam

        Next

        'Fim
        MsgTxt = MsgTxt & ">"

        Return MsgTxt

    End Function

End Class
